using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadJump : MonoBehaviour {

    public Text _jumpForce;

    void Start()
    {
        _jumpForce = GetComponent<Text>();
        PlayerController.jumpForce = PlayerPrefs.GetFloat("JumpForce");
    }

    void Update()
    {
        if (PlayerController.jumpForce > PlayerController.startJump)
        {
            PlayerController.startJump = PlayerController.jumpForce;
            PlayerPrefs.SetFloat("JumpForce", PlayerController.startJump);
        }

        PlayerPrefs.SetFloat("WallkSpeed", PlayerController.jumpForce);
        _jumpForce.text = " " + PlayerPrefs.GetFloat("JumpForce").ToString("f2");
    }

}
