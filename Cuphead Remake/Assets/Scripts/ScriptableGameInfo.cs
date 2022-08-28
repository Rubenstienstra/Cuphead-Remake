using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "GameInfo", menuName = "ScriptableObject/GameInfo")]
public class ScriptableGameInfo : ScriptableObject
{
    public bool playerLeft;
    public bool playerRight;
}
