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
    public Vector3 spawnLocationWeapon;

    public Vector3 movingLR;
    public bool movingRight;
    public bool movingLeft;
    public float moveSpeed;

    public float jumpSpeed;
    public bool enableJumpTime;
    public bool isOnFloor;

    private float allowShootCheck;

    // Use Scriptable weapon to change shootDelay
    private float shootDelay;

    void Start()
    {
        crWeapon = totalWeapons.currentWeapon;
        shootDelay = totalWeapons.currentWeaponStats;
    }
    private void Update()
    {
        if(enableJumpTime == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
        }
        if(movingLR.z == 1)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if(movingLR.x == 1)
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        
    }
    public void OnMovingRight(InputValue value)
    {
        movingLR.z = value.Get<float>();
        if (movingLR.z == 1)
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

        if (movingLR.x == 1)
        {
            movingLeft = true;
            gameInfo.playerLeft = true;

            movingRight = false;
            gameInfo.playerRight = false;
        }
    }
    IEnumerator OnJump(InputValue value)
    {
        if(isOnFloor == true)
        {
            enableJumpTime = true;
            isOnFloor = false;
            yield return new WaitForSeconds(0.5f);
            enableJumpTime = false;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag == "Ground")
        {
            isOnFloor = true;
        }
    }
    public void OnShooting(InputValue value)
    {
        allowShootCheck = value.Get<float>();
        if (value.Get<float>() == 1)
        {
            StartCoroutine(AutoShooting());
        }
    }
    IEnumerator AutoShooting()
    {
        yield return new WaitForSeconds(shootDelay);
        if (allowShootCheck == 1)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(0);
            StartCoroutine(AutoShooting());
        }
    }
    public void SpawnProjectile()
    {
        spawnLocationWeapon = this.gameObject.transform.position;
        if(movingLeft == true)
        {
            spawnLocationWeapon.z -= 0.5f;
        }
        else
        {
            spawnLocationWeapon.z += 0.5f;
        }
        Instantiate(crWeapon, spawnLocationWeapon, Quaternion.identity);
    }


}
