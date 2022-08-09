using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public ScriptableWeapons StotalWeapons;
    public int hp;

    public GameObject crWeapon;
    public Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        crWeapon = StotalWeapons.currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(InputAction.CallbackContext context)
    {
        SpawnProjectile();
    }
    public void SpawnProjectile()
    {
        Instantiate(crWeapon, spawnLocation, Quaternion.identity);
    }
}
