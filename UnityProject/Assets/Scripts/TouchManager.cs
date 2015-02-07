using UnityEngine;
using System.Collections;

using Discord;

public class TouchManager : SingletonComponent<TouchManager>
{

    private Camera m_camera;

    public void Start()
    {
        m_camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // get touches
        // check hits
        // touches get handles by interactive objects

        Touch[] touches = Input.touches;

        for ( int touchIndex = 0; touchIndex < Input.touchCount; touchIndex++ )
        {
            if ( touches[touchIndex].phase == TouchPhase.Began )
            {
                Touch touch = touches[ touchIndex ];
                Vector2 touchWorldPosition = m_camera.ScreenToWorldPoint( touch.position );

                Collider2D collider = Physics2D.OverlapPoint( touchWorldPosition );
                if ( collider != null )
                {
                    // do stuffs...
                    InteractiveObstacleComponent obstacleComponent = collider.GetComponent<InteractiveObstacleComponent>();

                    if ( obstacleComponent != null )
                    {
                        obstacleComponent.HandleTouch( touch );
                    }
                }
            }
        }

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            Vector2 touchWorldPosition = m_camera.ScreenToWorldPoint( Input.mousePosition );
            Debug.Log( touchWorldPosition );
            Collider2D collider = Physics2D.OverlapPoint( touchWorldPosition );
            if ( collider != null )
            {
                // do stuffs...
                InteractiveObstacleComponent obstacleComponent = collider.GetComponent<InteractiveObstacleComponent>();

                if ( obstacleComponent != null )
                {
                    obstacleComponent.HandleClickBecauseFuckingUnity();
                }
            }
        }
    }

}
