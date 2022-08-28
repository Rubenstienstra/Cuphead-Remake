using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public ScriptableGameInfo gameInfo;
    public ScriptableWeapons totalWeapons;

    public int hp;

    public GameObject crWeapon;
    public Vector3 spawnLocation;

    public Vector3 movingLR;
    public bool movingRight;
    public bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        crWeapon = totalWeapons.currentWeapon;
    }
    public void OnMovingRight(InputValue value)
    {
        movingLR.z = value.Get<float>();
        if (movingLR.z > 0.9)
        {
            movingRight = true;
            gameInfo.playerRight = true;
        }
        else
        {
            movingRight = false;
            gameInfo.playerRight = false;
        }
    }
    public void OnMovingLeft(InputValue value)
    {
        movingLR.x = value.Get<float>();

        if (movingLR.x > 0.9)
        {
            movingLeft = true;
            gameInfo.playerLeft = true;
        }
        else
        {
            movingLeft = false;
            gameInfo.playerLeft = false;
        }
    }
    public void OnShooting(InputValue value)
    {
        SpawnProjectile();
    }
    public void SpawnProjectile()
    {
        spawnLocation = this.gameObject.transform.position;
        //crWeapon = GameObject.Instantiate(crWeapon as GameObject);
        if(movingRight || movingLeft == false)
        {

        }
        Instantiate(crWeapon, spawnLocation, Quaternion.identity);
    }
}
