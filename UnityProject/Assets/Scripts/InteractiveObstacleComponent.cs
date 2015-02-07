using UnityEngine;
using System.Collections;

public abstract class InteractiveObstacleComponent : MonoBehaviour
{
    public abstract void HandleTouch( Touch touch );

    public abstract void HandleClickBecauseFuckingUnity();
}
