using UnityEngine;
using System.Collections;

public class BlockManualMover : MonoBehaviour
{
    public float m_runStartSpeed = 5;
    public float m_speedIncrease = 1;

    private float m_currentSpeed = 0;
    private Rigidbody2D m_body;

    public void Start()
    {
    }

    public void Update()
    {
        m_currentSpeed += Time.deltaTime * m_speedIncrease;
        //m_body.velocity = new Vector2( -m_currentSpeed, 0 );
        this.gameObject.transform.Translate( Vector3.left * m_currentSpeed );
    }

    public void StartRunning()
    {
        m_currentSpeed = m_runStartSpeed;
    }
}
