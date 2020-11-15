using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName="NewLevel", menuName="Scene Data/Level")]
public class Level : GameScene {
    [Header("Level specific")]
    public string difficultyRating;
}