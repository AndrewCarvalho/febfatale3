using UnityEngine;
using System.Collections;

public class BlockManualMover : MonoBehaviour
{
    public float m_runStartSpeed = 5;
    public float m_speedIncrease = 1;

    private float m_currentSpeed;
    private Rigidbody2D m_body;

    public void Start()
    {
        m_currentSpeed = m_runStartSpeed;
        //m_body = GetComponent<Rigidbody2D>();
        //m_body.velocity = new Vector2( -m_currentSpeed, 0 );
    }

    public void Update()
    {
        m_currentSpeed += Time.deltaTime * m_speedIncrease;
        //m_body.velocity = new Vector2( -m_currentSpeed, 0 );
        this.gameObject.transform.Translate( Vector3.left * m_currentSpeed );
    }
}
