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
            PlatformSpawner.CurrentSpeed = 0;
            Application.LoadLevel( Application.loadedLevel );
        }
    }
}
