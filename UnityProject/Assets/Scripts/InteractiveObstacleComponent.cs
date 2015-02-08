using UnityEngine;
using System.Collections;

public abstract class InteractiveObstacleComponent : MonoBehaviour
{
    protected Canvas m_canvas;

    public void Start()
    {
        m_canvas = GetComponentInParent<Canvas>();
    }

    public abstract void HandleTouch( Touch touch );

    public abstract void HandleClickBecauseFuckingUnity();

    public abstract float GetWidth();
}
