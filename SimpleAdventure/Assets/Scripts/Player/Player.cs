using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement m_playerMovement = new PlayerMovement();
    public PlayerActions m_PlayerActions = new PlayerActions();
    public PlayerVisualFX m_visualFX = new PlayerVisualFX();

    [InspectorName("Check ground")]
    public Transform m_feetPos;
    public float m_feetRadius;
    public LayerMask m_groundLayer;

    private Vector2 m_inputDir = Vector2.zero;
    private Vector2 m_faceDir = Vector2.right; //which dir player is curr facing

    //states
    private bool m_jump = false;
    private bool m_onGround = false;

    public delegate void NotifyJump();
    private static NotifyJump m_NotifyJump;

    // Start is called before the first frame update
    void Start()
    {
        m_playerMovement.Init(GetComponent<Rigidbody2D>());
        m_visualFX.Init(GetComponent<Animator>(), GetComponent<SpriteRenderer>());
    }

    public void RegisterJumpListener(NotifyJump listener)
    {
        m_NotifyJump += listener;
    }

    // Update is called once per frame
    void Update()
    {
        m_inputDir.x = Input.GetAxis("Horizontal");
        MoveVisualsUpdate();

        if (Input.GetKeyDown(KeyCode.Space) && !m_jump)
        {
            StartJump();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartAttack();
        }
    }

    /*
     * Doing this method as I wanted to decouple the state transition from the animator 
     * Give more control to code instead
     * 
     * Note: This project wanted a more "cleaner" state machine (without all the lines)
     * But if you do not want the code to handle all the update (what the animator state machine does), do not do this
     */
    private void MoveVisualsUpdate()
    {
        if (m_inputDir.x != 0)
            m_faceDir = m_inputDir;

        if (!m_onGround)
        {
            if (m_playerMovement.IsFalling())
                m_visualFX.PlayerFall();
            else
                m_visualFX.Jump();

            return;
        }

        if (m_inputDir.x != 0)
            m_visualFX.MoveOnGround(m_faceDir);
        else
            m_visualFX.Idle(m_faceDir);
    }

    private void StartJump()
    {
        m_jump = true;
        if (m_NotifyJump != null)
            m_NotifyJump.Invoke();
    }

    private void StartAttack()
    {
        m_PlayerActions.Shoot(transform.position, m_faceDir);
        m_visualFX.Attack(this);
    }

    private void FixedUpdate()
    {
        if (m_jump)
        {
            m_playerMovement.Jump();
        }

        m_onGround = Physics2D.OverlapCircle(m_feetPos.position, m_feetRadius, m_groundLayer);
        m_playerMovement.MoveHorizontal(m_inputDir.x);

        if (!m_onGround)
            m_playerMovement.Fall();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_feetPos.position, m_feetRadius);
    }
}
