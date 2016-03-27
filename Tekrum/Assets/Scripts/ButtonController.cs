using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void StartGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void SecondTest()
    {
        SceneManager.LoadScene("SecondTest");
    }

    public void Exit() {
        Application.Quit();
    }
}
