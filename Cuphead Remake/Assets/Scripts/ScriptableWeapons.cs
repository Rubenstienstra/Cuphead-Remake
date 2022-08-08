using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "WeaponsSelection", menuName = "ScriptableObjects/WeaponsSelection", order = 1)]
public class ScriptableWeapons : ScriptableObject
{
    public GameObject crWeapon;
    public GameObject[] totalWeapons;
}
// cr == current
