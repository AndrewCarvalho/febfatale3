using UnityEngine;
using System.Collections;

using Discord;

public class PlatformSpawner : SingletonComponent<PlatformSpawner>
{
	public float m_startingSpeed = 0.5f;
    public float CurrentSpeed = 0;

    public float m_speedIncreaseRate = 1;

    // Use this for initialization
    void Start()
    {
        GameObject chunk = ( GameObject )GameObject.Instantiate( Resources.Load( "Prefabs/3D/PlatformChunks/Chunk 00" ) );
        //chunk.transform.position = Vector3.zero;
        chunk.GetComponent<PlatformChunkDriver>().SetMoveAmount( 32 );

		CurrentSpeed = m_startingSpeed;

        SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpeed += Time.deltaTime * m_speedIncreaseRate;
    }

    public static void SpawnPlatform()
    {
        string chunkNumber = "Prefabs/3D/PlatformChunks/Chunk " + UnityEngine.Random.Range( 0, 4 ).ToString( "00" );
        Debug.Log( "Spawning chunk " + chunkNumber );
        GameObject chunk = ( GameObject )GameObject.Instantiate( Resources.Load( chunkNumber ) );
        chunk.transform.Translate( Vector3.right * 32 );
        chunk.GetComponent<PlatformChunkDriver>().SetMoveAmount( 64 );
    }

	public void ResetSpeed()
	{
		CurrentSpeed = m_startingSpeed;
	}

}
