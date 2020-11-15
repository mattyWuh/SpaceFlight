using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

    public void ButtonStart() {
        SceneManager.LoadScene("FlightType1");
    }

    public void ButtonQuit() {
        Application.Quit();
    }
}