using System.Collections;
using UnityEngine;

public enum Type {
    MainMenu,
    PauseMenu
}

[CreateAssetMenu(fileName = "NewMenu", menuName = "Scene Data/Menu")]
public class Menu : GameScene {
    [Header("Menu Specific")]
    public Type type;
}