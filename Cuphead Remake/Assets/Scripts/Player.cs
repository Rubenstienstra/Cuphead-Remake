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

    public float allowShoot;
    public float shootDelay;

    // Start is called before the first frame update
    void Start()
    {
        crWeapon = totalWeapons.currentWeapon;
        shootDelay = totalWeapons.currentWeaponStats;
    }
    public void OnMovingRight(InputValue value)
    {
        movingLR.z = value.Get<float>();
        if (movingLR.z > 0.9)
        {
            movingRight = true;
            gameInfo.playerRight = true;

            movingLeft = false;
            gameInfo.playerLeft = false;
        }
    }
    public void OnMovingLeft(InputValue value)
    {
        movingLR.x = value.Get<float>();

        if (movingLR.x > 0.9)
        {
            movingLeft = true;
            gameInfo.playerLeft = true;

            movingRight = false;
            gameInfo.playerRight = false;
        }
    }
    //public void OnShooting(InputValue value)
    //{
    //    SpawnProjectile();
    //}
    public void SpawnProjectile()
    {
        spawnLocation = this.gameObject.transform.position;
        if(movingLeft == true)
        {
            spawnLocation.z -= 0.5f;
        }
        else
        {
            spawnLocation.z += 0.5f;
        }
        Instantiate(crWeapon, spawnLocation, Quaternion.identity);
    }
    public void OnShooting(InputValue value)
    {
        allowShoot = value.Get<float>();
        if(value.Get<float>() >= 0.9)
        {
            StartCoroutine(AutoShooting());
        }
        //else if (value.Get<float>() < 0.1)
        //{
        //    StopCoroutine(AutoShooting());
        //}
    }
    IEnumerator AutoShooting()
    {
       yield return new WaitForSeconds(shootDelay);
        if(allowShoot >= 0.9)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(0);
            StartCoroutine(AutoShooting());
        }
    }
}
