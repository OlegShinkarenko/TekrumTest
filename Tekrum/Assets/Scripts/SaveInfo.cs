using UnityEngine;
using System.Collections;

public class SaveInfo : MonoBehaviour {

    float speedWallk;

	void Start () {
       // jumpForce = PlayerPrefs.GetFloat("JumpForce");
       // speedRun = PlayerPrefs.GetFloat("SpeedRun");
        PlayerPrefs.SetFloat("SpeedWallk", speedWallk);

        
    }

	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.U))
        PlayerPrefs.Save();
    Debug.Log("Saved");
	}
}
