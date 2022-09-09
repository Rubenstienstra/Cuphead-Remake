using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "WeaponsSelection", menuName = "ScriptableObject/WeaponsSelection")]
public class ScriptableWeapons : ScriptableObject
{
    public GameObject currentWeapon;
    public GameObject[] totalWeapons;

    public float currentWeaponStats;
}
// cr == current
