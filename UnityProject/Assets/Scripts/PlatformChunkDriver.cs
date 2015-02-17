using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody ) )]
public class PlatformChunkDriver : MonoBehaviour
{

    // spawn, move, destry
    private PlatformSpawner m_spawner;
    private Rigidbody m_body;
    [SerializeField]
    private float m_amountToMove = 32;

    // Use this for initialization
    void Start()
    {
        m_spawner = GameObject.FindObjectOfType<PlatformSpawner>();
        m_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_body.MovePosition( this.transform.position + Vector3.left * PlatformSpawner.CurrentSpeed );
        m_amountToMove += ( Vector3.left * PlatformSpawner.CurrentSpeed ).x;
        //if ( m_amountToMove <= 0 )
        if ( this.transform.position.x < -32 )
        {
            Destroy( this.gameObject );
            PlatformSpawner.SpawnPlatform();
        }
    }

    public void SetMoveAmount( float moveAmount )
    {
        m_amountToMove = moveAmount;
    }
}
