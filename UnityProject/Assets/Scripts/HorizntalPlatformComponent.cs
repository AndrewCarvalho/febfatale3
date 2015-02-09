using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody2D ) )]
public class HorizntalPlatformComponent : InteractiveObstacleComponent
{
    public float m_speedMultipler = 10;

    private GameObject m_touchObject;
    private Touch m_touch;
    private Camera m_camera;
    private Vector2 m_initialTouchPoint;
    private Vector2 m_initialLocalTouchPoint;
    private Rigidbody2D m_body;
    private SliderJoint2D m_sliderJoint;
    //private GameObject m_touchedGameObject;

    private bool m_isClicked = false, m_isTouched = false;

    public void Start()
    {
        m_camera = FindObjectOfType<Camera>();
        m_body = GetComponent<Rigidbody2D>();
        m_sliderJoint = GetComponentInParent<SliderJoint2D>();
        //m_sliderJoint.useMotor = true;
        JointMotor2D jointMotor = new JointMotor2D();
        jointMotor.motorSpeed = 0;
        jointMotor.maxMotorTorque = 10000;
        m_sliderJoint.motor = jointMotor;
    }

    public override void HandleTouch( Touch touch )
    {
        m_isTouched = true;

        m_sliderJoint.useMotor = true;
        JointMotor2D jointMotor = new JointMotor2D();
        jointMotor.motorSpeed = 0;
        jointMotor.maxMotorTorque = 10000;
        m_sliderJoint.motor = jointMotor;

        m_touch = touch;
        m_initialTouchPoint = m_camera.ScreenToWorldPoint( m_touch.position );
        m_initialLocalTouchPoint = this.transform.InverseTransformPoint( m_initialTouchPoint );

        m_touchObject = new GameObject();
        m_touchObject.name = "Touch";
        m_touchObject.layer = 9;
        m_touchObject.transform.position = m_initialTouchPoint;

        //Rigidbody2D touchBody = m_touchObject.AddComponent<Rigidbody2D>();
        //touchBody.mass = 0;
        //touchBody.isKinematic = true;

        //SpringJoint2D spring = m_touchObject.AddComponent<SpringJoint2D>();
        //spring.connectedBody = m_body;
        //spring.anchor = Vector2.zero;
        //spring.connectedAnchor = m_initialLocalTouchPoint;
        //spring.dampingRatio = 0f;
        //spring.frequency = 0f;
        //spring.distance = 0;

        //DistanceJoint2D distance = m_touchObject.AddComponent<DistanceJoint2D>();
        //distance.distance = 0;
        //distance.connectedBody = m_body;
        //distance.connectedAnchor = m_initialLocalTouchPoint;
    }

    public override void HandleClickBecauseFuckingUnity()
    {
        m_isClicked = true;

        m_sliderJoint.useMotor = true;
        JointMotor2D jointMotor = new JointMotor2D();
        jointMotor.motorSpeed = 0;
        jointMotor.maxMotorTorque = 10000;
        m_sliderJoint.motor = jointMotor;

        m_initialTouchPoint = m_camera.ScreenToWorldPoint( Input.mousePosition );
        m_initialLocalTouchPoint = this.transform.InverseTransformPoint( m_initialTouchPoint );

        m_touchObject = new GameObject();
        m_touchObject.name = "Touch";
        m_touchObject.layer = 9;
        m_touchObject.transform.position = m_initialTouchPoint;

        //Rigidbody2D touchBody = m_touchObject.AddComponent<Rigidbody2D>();
        //touchBody.mass = 0;
        //touchBody.isKinematic = true;

        //SpringJoint2D spring = m_touchObject.AddComponent<SpringJoint2D>();
        //spring.connectedBody = m_body;
        //spring.anchor = Vector2.zero;
        //spring.connectedAnchor = m_initialLocalTouchPoint;
        //spring.dampingRatio = 0f;
        //spring.frequency = 0f;
        //spring.distance = 0;

        //DistanceJoint2D distance = m_touchObject.AddComponent<DistanceJoint2D>();
        //distance.distance = 0;
        //distance.connectedBody = m_body;
        //distance.connectedAnchor = m_initialLocalTouchPoint;
    }

    public void Update()
    {

        if ( m_isClicked )
        {
            if ( Input.GetMouseButtonDown( 1 ) )
            {
                Debug.Break();
            }
            if ( !Input.GetMouseButton( 0 ) )
            {
                //JointMotor2D jointMotor = new JointMotor2D();
                //jointMotor.motorSpeed = 0;
                //jointMotor.maxMotorTorque = 10000;
                //m_sliderJoint.motor = jointMotor;
                m_sliderJoint.useMotor = false;
                Destroy( m_touchObject );
                m_isClicked = false;
            }
            else
            {
                Vector2 worldPosition = m_camera.ScreenToWorldPoint( Input.mousePosition );

                JointMotor2D jointMotor = new JointMotor2D();
                jointMotor.motorSpeed = ( worldPosition.x - this.transform.TransformPoint( m_initialLocalTouchPoint ).x ) * m_speedMultipler;
                jointMotor.maxMotorTorque = 10000;
                m_sliderJoint.motor = jointMotor;
                m_touchObject.transform.position = worldPosition;
                //this.transform.position = worldPosition - m_initialLocalTouchPoint;
            }
        }

        if ( m_isTouched )
        {
            if ( m_touch.phase == TouchPhase.Ended || m_touch.phase == TouchPhase.Canceled )
            {
                //JointMotor2D jointMotor = new JointMotor2D();
                //jointMotor.motorSpeed = 0;
                //jointMotor.maxMotorTorque = 10000;
                //m_sliderJoint.motor = jointMotor;
                m_sliderJoint.useMotor = false;
                Destroy( m_touchObject );
                m_isTouched = false;
            }
            else
            {
                Vector2 worldPosition = m_camera.ScreenToWorldPoint( m_touch.position );
                JointMotor2D jointMotor = new JointMotor2D();
                jointMotor.motorSpeed = ( worldPosition.x - this.transform.TransformPoint( m_initialLocalTouchPoint ).x ) * m_speedMultipler;
                jointMotor.maxMotorTorque = 10000;
                m_sliderJoint.motor = jointMotor;
                m_touchObject.transform.position = worldPosition;
                //this.transform.position = worldPosition - m_initialLocalTouchPoint;
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
            Gizmos.DrawLine( forcePosition, m_touchObject.transform.position );

            //Gizmos.color = Color.red;
            //Gizmos.DrawLine( m_initialTouchPoint, worldPosition );

            Gizmos.color = Color.red;
            Gizmos.DrawLine( m_touchObject.transform.position - new Vector3( -0.5f, -0.5f ), m_touchObject.transform.position - new Vector3( 0.5f, 0.5f ) );
            Gizmos.DrawLine( m_touchObject.transform.position - new Vector3( -0.5f, 0.5f ), m_touchObject.transform.position - new Vector3( 0.5f, -0.5f ) );

        }
    }

    public override float GetWidth()
    {
        return GetComponentInChildren<RectTransform>().rect.width * m_canvas.scaleFactor;
    }
}
