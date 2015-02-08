using UnityEngine;
using System.Collections;

public class BlockManualMover : MonoBehaviour
{
    public float m_runSpeed = 300;

    public void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2( -m_runSpeed, 0 );
    }
}
