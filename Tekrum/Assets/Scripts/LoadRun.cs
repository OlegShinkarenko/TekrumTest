using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadRun : MonoBehaviour {

    public Text _runSpeed;

    void Start()
    {
        _runSpeed = GetComponent<Text>();

        PlayerController.running = PlayerPrefs.GetFloat("RunSpeed");
    }

    void Update()
    {

        if (PlayerController.running > PlayerController.speedRun)
        {
            PlayerController.speedRun = PlayerController.running;
            PlayerPrefs.SetFloat("RunSpeed", PlayerController.speedRun);
        }

        PlayerPrefs.SetFloat("RunSpeed", PlayerController.running);
        _runSpeed.text = " " + PlayerPrefs.GetFloat("RunSpeed").ToString("f2");
    }
}
