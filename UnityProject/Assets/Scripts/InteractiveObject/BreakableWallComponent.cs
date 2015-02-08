using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( Collider2D ) )]
public class BreakableWallComponent : InteractiveObstacleComponent
{

    public int m_numHits = 5;
    private int m_health;

    public void Start()
    {
        m_health = m_numHits;
    }

    public override void HandleTouch( Touch touch )
    {
        --m_health;

        if ( m_health == 0 )
        {
            Destroy( this.gameObject );
        }
    }

    public override void HandleClickBecauseFuckingUnity()
    {
        --m_health;

        if ( m_health == 0 )
        {
            Destroy( this.gameObject );
        }
    }
}
