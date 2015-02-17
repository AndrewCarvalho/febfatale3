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

        //Touch[] touches = Input.touches;

        //for ( int touchIndex = 0; touchIndex < Input.touchCount; touchIndex++ )
        //{
        //    if ( touches[touchIndex].phase == TouchPhase.Began )
        //    {
        //        Touch touch = touches[ touchIndex ];
        //        Vector2 touchWorldPosition = m_camera.ScreenToWorldPoint( touch.position );

        //        Collider2D collider = Physics2D.OverlapPoint( touchWorldPosition );
        //        if ( collider != null )
        //        {
        //            // do stuffs...
        //            InteractiveObstacleComponent obstacleComponent = collider.GetComponent<InteractiveObstacleComponent>();

        //            if ( obstacleComponent != null )
        //            {
        //                obstacleComponent.HandleTouch( touch );
        //            }
        //        }
        //    }
        //}

        if ( Input.GetMouseButtonDown( 0 ) )
        {
            Vector2 touchWorldPosition = m_camera.ScreenToWorldPoint( Input.mousePosition );
            Collider2D collider = Physics2D.OverlapPoint( touchWorldPosition );
            Collider[] colliders3D = Physics.OverlapSphere( new Vector3( touchWorldPosition.x, touchWorldPosition.y, 0 ), 0.001f );
            if ( collider != null )
            {
                // do stuffs...
                InteractiveObstacleComponent obstacleComponent = collider.GetComponent<InteractiveObstacleComponent>();

                if ( obstacleComponent != null )
                {
                    obstacleComponent.HandleClickBecauseFuckingUnity();
                }
            }
            if (colliders3D.Length > 0)
            {
                InteractiveObstacleComponent collider3D = null;
                int colliderIndex = 0;
                while ( colliderIndex < colliders3D.Length )
                {
                    collider3D = colliders3D[ colliderIndex ].GetComponent<InteractiveObstacleComponent>();
                    if ( collider3D != null )
                    {
                        break;
                    }
                    ++colliderIndex;
                }

                if ( collider3D != null )
                {
                    collider3D.HandleClickBecauseFuckingUnity();
                }
            }
        }
    }


}
