using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public ScriptableGameInfo gameInfo;
    public ScriptableWeapons totalWeapons;

    public int hp;
    public bool invincabilityMode;
    public Material invincabilityColor;
    public Material invincabilityColorOff;
    public Text hpText;

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
        hpText.text = hp.ToString();
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
        if(col.collider.gameObject.tag == "Enemy")
        {
            if(invincabilityMode == false)
            {
                hp--;
                //materials veranderen niet
                this.gameObject.GetComponent<MeshRenderer>().materials[0] = invincabilityColor;
                hpText.text = hp.ToString();
                StartCoroutine(InvincabilityFrames());
            }
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
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
        spawnLocationWeapon.y -= 0.1f;
        Instantiate(crWeapon, spawnLocationWeapon, Quaternion.identity);
    }
    IEnumerator InvincabilityFrames()
    {
        invincabilityMode = true;
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<MeshRenderer>().materials[0] = invincabilityColorOff;
        invincabilityMode = false;

    }


}
