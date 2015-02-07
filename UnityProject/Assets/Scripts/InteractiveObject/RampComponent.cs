using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody2D ) )]
public class RampComponent : InteractiveObstacleComponent
{
    public float m_forceScale = 1;

    private GameObject m_touchObject;
    private Touch m_touch;
    private Camera m_camera;
    private Vector2 m_initialTouchPoint;
    private Vector2 m_initialLocalTouchPoint;
    private Rigidbody2D m_body;

    private bool m_isClicked = false;

    public void Start()
    {
        m_camera = FindObjectOfType<Camera>();
        m_body = GetComponent<Rigidbody2D>();
    }

    public override void HandleTouch( Touch touch )
    {
        m_touch = touch;
        m_initialTouchPoint = m_camera.ScreenToWorldPoint( m_touch.position );
        m_initialLocalTouchPoint = this.transform.InverseTransformPoint( m_initialTouchPoint );
    }

    public override void HandleClickBecauseFuckingUnity()
    {
        Debug.Log( "fuck" );
        m_isClicked = true;
        m_initialTouchPoint = m_camera.ScreenToWorldPoint( Input.mousePosition );
        m_initialLocalTouchPoint = this.transform.InverseTransformPoint( m_initialTouchPoint );
    }

    public void Update()
    {
        if ( !( m_touch.phase == TouchPhase.Ended || m_touch.phase == TouchPhase.Canceled ) )
        {
            Vector2 worldPosition = m_camera.ScreenToWorldPoint( m_touch.position );
            Vector2 localPosition = this.transform.InverseTransformDirection( worldPosition );
            Vector2 forcePosition = this.transform.TransformPoint( m_initialLocalTouchPoint );
            Vector2 distance = worldPosition - forcePosition;

            m_body.AddForceAtPosition( distance * m_forceScale, forcePosition );
        }
        else
        {
            Destroy( m_touchObject );
        }

        if ( m_isClicked )
        {
            if ( !Input.GetMouseButton( 0 ) )
            {
                Debug.Log( "end fuck" );
                m_isClicked = false;
            }
            else
            {
                Vector2 worldPosition = m_camera.ScreenToWorldPoint( Input.mousePosition );
                Vector2 localPosition = this.transform.InverseTransformDirection( worldPosition );
                Vector2 forcePosition = this.transform.TransformPoint( m_initialLocalTouchPoint );
                Vector2 distance = worldPosition - forcePosition;

                m_body.AddForceAtPosition( distance * m_forceScale, forcePosition );

                //m_body.angularVelocity = distance.magnitude;
            }
        }

    }

    public void OnDrawGizmos()
    {
        if ( m_isClicked )
        {
            Vector2 worldPosition = m_camera.ScreenToWorldPoint( Input.mousePosition );
            Vector2 localPosition = this.transform.InverseTransformDirection( worldPosition );
            Vector2 forcePosition = this.transform.TransformPoint( m_initialLocalTouchPoint );
            Vector2 distance = worldPosition - forcePosition;


            //m_body.AddForceAtPosition( distance * m_forceScale, forcePosition );
            Gizmos.color = Color.green;
            //Gizmos.DrawLine( forcePosition, forcePosition + distance );
            Gizmos.DrawLine( forcePosition, forcePosition + distance );

            Gizmos.color = Color.red;
            Gizmos.DrawLine( m_initialTouchPoint, worldPosition );

        }
    }
}
