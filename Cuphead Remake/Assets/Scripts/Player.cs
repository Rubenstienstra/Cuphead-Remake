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

    public Vector3 moving;
    public bool allowMoving;

    // Start is called before the first frame update
    void Start()
    {
        crWeapon = StotalWeapons.currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMoving(InputValue value)
    {
        moving.z = value.Get<float>();
        if (moving.z == 1)
        {
            allowMoving = true;
        }
        else
        {
            allowMoving = false;
        }
    }
    public void SpawnProjectile()
    {
        Instantiate(crWeapon, spawnLocation, Quaternion.identity);
    }
}
