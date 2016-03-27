using UnityEngine;
using System.Collections;

public class LoadInfo : MonoBehaviour {

     float speedWallk;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (PlayerPrefs.HasKey("SpeedWallk"))
                speedWallk = PlayerPrefs.GetFloat("SpeedWallk");
            else speedWallk = 0f;
        }
        Debug.Log("Load");
	}
}
