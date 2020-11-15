using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName="sceneDatabase", menuName="Scene Data/Database")]
public class ScenesData : ScriptableObject {

    public enum Scene {
        MainMenu,
        FlightType1,
    }

    [SerializeField]
    List<Level> levels;

    [SerializeField]
    List<Menu> menus;

    public Scene currentScene;

    public void LoadCurrentScene() {
        LoadScene(currentScene);
    }

    public void LoadScene(Scene scene) {
        SceneManager.LoadSceneAsync(scene.ToString());
    }

    public void LoadMainMenu() {
        SceneManager.LoadSceneAsync(menus[(int)Type.MainMenu].sceneName);
    }
}