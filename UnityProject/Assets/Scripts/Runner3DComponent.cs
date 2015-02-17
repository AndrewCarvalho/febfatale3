using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Collider ) )]
[RequireComponent( typeof( Rigidbody ) )]
public class Runner3DComponent : MonoBehaviour
{

    public float m_targetNormalizedHorizontalScreenPosition = 0.2f;
    public float m_returnAccel = 1;

    private Rigidbody m_body;
    private Vector2 m_screenSize;

    // Use this for initialization
    void Start()
    {
        m_body = GetComponent<Rigidbody>();
        Camera camera = GameObject.Find( "Main Camera" ).GetComponent<Camera>();
        m_screenSize = new Vector2( camera.orthographicSize * camera.aspect, camera.orthographicSize ) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        // always try to run to a specific X value

        // accel is 0 is on the point, positive if behind and negative if in front
        if ( this.transform.position.x != m_targetNormalizedHorizontalScreenPosition * m_screenSize.x - m_screenSize.x / 2 )
        {
            float distanceOut = this.transform.position.x - ( m_targetNormalizedHorizontalScreenPosition * m_screenSize.x - m_screenSize.x / 2 );
            if ( distanceOut > 0 )
            {
                distanceOut = Mathf.Clamp( distanceOut, 1, 2 );
            }
            else
            {
                distanceOut = Mathf.Clamp( distanceOut, -2, -1 );
            }
            m_body.AddForce( Vector3.left * distanceOut * m_returnAccel, ForceMode.Force );
            //m_body.velocity = -Vector2.right * distanceOut * m_returnAccel;
        }


        // how fast the runner returns to their position should be exposed to the inspector 

    }

    public void OnDrawGizmos()
    {
        // draw return line
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine( new Vector3( m_targetNormalizedHorizontalScreenPosition * m_screenSize.x - m_screenSize.x / 2, -m_screenSize.y / 2, 0 ), new Vector3( m_targetNormalizedHorizontalScreenPosition * m_screenSize.x - m_screenSize.x / 2, m_screenSize.y / 2, 0 ) );
    }
}
