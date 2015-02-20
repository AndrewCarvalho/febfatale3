using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Collider ) )]
public class DeathBox : MonoBehaviour
{
    public void OnTriggerExit( Collider collider )
    {
        if ( collider.GetComponent<Runner3DComponent>() != null )
        {
            // END THE GAME!!
            PlatformSpawner.Instance.ResetSpeed();
            Application.LoadLevel( Application.loadedLevel );
        }
    }
}
