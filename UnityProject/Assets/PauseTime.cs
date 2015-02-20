using UnityEngine;
using System.Collections;

public class PauseTime : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void StartTime()
    {
        Time.timeScale = 1;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
}
