using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadWallk : MonoBehaviour {

    public Text _wallkSpeed;
 
	void Start () {
       _wallkSpeed = GetComponent<Text>();
        PlayerController.speedWallk = PlayerPrefs.GetFloat("WallkSpeed");
    }

    void Update()
    {
        if (PlayerController.speedWallk > PlayerController.startSpeed)
        {
            PlayerController.startSpeed = PlayerController.speedWallk;
            PlayerPrefs.SetFloat("WallkSpeed", PlayerController.startSpeed);
        }

        PlayerPrefs.SetFloat("WallkSpeed", PlayerController.speedWallk);
        _wallkSpeed.text = " " + PlayerPrefs.GetFloat("WallkSpeed").ToString("f2");
    }
}
