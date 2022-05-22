using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement m_playerMovement;

    [InspectorName("Check ground")]
    public Transform m_feetPos;
    public float m_feetRadius;
    public LayerMask m_groundLayer;

    private Vector2 m_inputDir = Vector2.zero;
    private bool m_jump = false;
    private bool m_onGround = false;
    

    // Start is called before the first frame update
    void Start()
    {
        m_playerMovement.Init(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        m_inputDir.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && m_onGround)
        {
            m_jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (m_jump)
        {
            m_playerMovement.Jump();
            m_jump = false;
            //todo:: sound effects
            //todo:: particle effects
        }

        m_onGround = Physics2D.OverlapCircle(m_feetPos.position, m_feetRadius, m_groundLayer);

        m_playerMovement.Fall();
        m_playerMovement.MoveHorizontal(m_inputDir.x);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(m_feetPos.position, m_feetRadius);
    }
}
