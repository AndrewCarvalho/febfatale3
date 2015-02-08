﻿using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody2D ) )]
public class ElevatorComponent : InteractiveObstacleComponent
{
    private GameObject m_touchObject;
    private Touch m_touch;
    private Camera m_camera;
    private Vector2 m_initialTouchPoint;
    private Vector2 m_initialLocalTouchPoint;
    private Rigidbody2D m_body;

    private bool m_isClicked = false;

    // Use this for initialization
    void Start()
    {
        m_camera = FindObjectOfType<Camera>();
        m_body = GetComponent<Rigidbody2D>();

    }

    public override void HandleTouch( Touch touch )
    {
        m_touch = touch;
        m_initialTouchPoint = m_camera.ScreenToWorldPoint( m_touch.position );
        m_initialLocalTouchPoint = this.transform.InverseTransformPoint( m_initialTouchPoint );

        m_touchObject = new GameObject();
        SpringJoint2D spring = m_touchObject.AddComponent<SpringJoint2D>();
        spring.anchor = Vector2.zero;
        spring.connectedAnchor = m_initialLocalTouchPoint;
        spring.dampingRatio = 1;
    }

    public override void HandleClickBecauseFuckingUnity()
    {
        m_isClicked = true;
        m_initialTouchPoint = m_camera.ScreenToWorldPoint( Input.mousePosition );
        m_initialLocalTouchPoint = this.transform.InverseTransformPoint( m_initialTouchPoint );

        m_touchObject = new GameObject();
        SpringJoint2D spring = m_touchObject.AddComponent<SpringJoint2D>();
        spring.connectedBody = m_body;
        spring.anchor = Vector2.zero;
        spring.connectedAnchor = m_initialLocalTouchPoint;
        spring.dampingRatio = 1;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if ( m_isClicked )
        {
            if ( Input.GetMouseButtonDown( 1 ) )
            {
                Debug.Break();
            }
            if ( !Input.GetMouseButton( 0 ) )
            {
                Destroy( m_touchObject );
                m_isClicked = false;
            }
            else
            {
                Vector2 worldPosition = m_camera.ScreenToWorldPoint( Input.mousePosition );
                m_touchObject.transform.position = worldPosition;
            }
        }
#else
        if ( !( m_touch.phase == TouchPhase.Ended || m_touch.phase == TouchPhase.Canceled ) )
        {
            Vector2 worldPosition = m_camera.ScreenToWorldPoint( m_touch.position );
            //Vector2 localPosition = this.transform.InverseTransformDirection( worldPosition );
            //Vector2 forcePosition = this.transform.TransformPoint( m_initialLocalTouchPoint );
            //Vector2 distance = worldPosition - forcePosition;

            //m_body.AddForceAtPosition( distance * m_forceScale, forcePosition );
            m_touchObject.transform.position = worldPosition;
        }
        else
        {
            Destroy( m_touchObject );
        }
#endif
    }

    
}