using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement m_playerMovement = new PlayerMovement();
    public PlayerActions m_PlayerActions = new PlayerActions();
    public PlayerVisualFX m_visualFX;

    [InspectorName("Check ground")]
    public Transform m_feetPos;
    public float m_feetRadius;
    public LayerMask m_groundLayer;

    private Vector2 m_inputDir = Vector2.zero;
    private Vector2 m_faceDir = Vector2.right; //which dir player is curr facing

    //states
    private bool m_jump = false;
    private bool m_onGround = false;

    private delegate void NotifyJump();
    private static NotifyJump m_NotifyJump;

    // Start is called before the first frame update
    void Start()
    {
        m_playerMovement.Init(GetComponent<Rigidbody2D>());
        m_visualFX = new PlayerVisualFX(GetComponent<Animator>(), GetComponent<SpriteRenderer>());
    }

    public void RegisterJumpListener(Action listener)
    {
        m_NotifyJump += new NotifyJump(listener);
    }

    // Update is called once per frame
    void Update()
    {
        m_inputDir.x = Input.GetAxisRaw("Horizontal");
        MoveUpdate();

        if (Input.GetKeyDown(KeyCode.Space) && m_onGround)
        {
            StartJump();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartAttack();
        }
    }

    private void MoveUpdate()
    {
        if (m_inputDir.x != 0)
        {
            m_faceDir = m_inputDir;
        }

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
            m_jump = false;
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
