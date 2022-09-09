using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamentBattle : MonoBehaviour
{
    public BossBattle bossScript;
    public ScriptableGameInfo gameInfo;

    private int randomAttackGeneration;
    private float waitTimeAttack;
    public float waitTimeAttackDecrease;

    public Vector3 hospitalEnemySpawnL;
    public Vector3 hospitalEnemySpawnM;
    public Vector3 hospitalEnemySpawnR;

    public GameObject[] hospitalWagon;
    public int randomNumber;
    public int maxSpawnHospital;
    public int hospitalSpawned;
    public float RandomBackgroundWait;
    

    void Start()
    {
        gameInfo.increaseCarSpeed = 0;
        StartCoroutine(ChoosingAttack());
    }
    public IEnumerator ChoosingAttack()
    {
        randomAttackGeneration = Random.Range(1, 3);
        switch (randomAttackGeneration)
        {
            case 1:
                StartCoroutine(Attack1());
                waitTimeAttack = 22 - waitTimeAttackDecrease;
                break;
            case 2:
                StartCoroutine(Attack1());
                waitTimeAttack = 22 - waitTimeAttackDecrease;
                break;
            case 3:
                StartCoroutine(Attack1());
                waitTimeAttack = 22 - waitTimeAttackDecrease;
                break;
        }
        yield return new WaitForSeconds(waitTimeAttack);
        StartCoroutine(ChoosingAttack());
        
    }
    public IEnumerator Attack1()
    {
        yield return new WaitForSeconds(1.8f);
        SpawnHospitalWagon();
        hospitalSpawned++;
        if(hospitalSpawned < maxSpawnHospital)
        {
            StartCoroutine(Attack1());
        }
        else
        {
            hospitalSpawned = 0;
        }
        RandomBackgroundWait = Random.Range(1, 2);
        yield return new WaitForSeconds(RandomBackgroundWait);
        Instantiate(hospitalWagon[randomNumber], hospitalEnemySpawnL, Quaternion.Euler(90, 0, 0));
        RandomBackgroundWait = Random.Range(1, 2);
        yield return new WaitForSeconds(RandomBackgroundWait);
        Instantiate(hospitalWagon[randomNumber], hospitalEnemySpawnR, Quaternion.Euler(90, 0, 0));


    }
    public void SpawnHospitalWagon()
    {
       randomNumber = Random.Range(0, 2);
        Instantiate(hospitalWagon[randomNumber], hospitalEnemySpawnM,Quaternion.Euler(90,0,0));
    }
    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "Weapon Projectile")
        {
            bossScript.currentHP--;
            Destroy(trig.gameObject);
            CheckHP();
        }
        if (trig.gameObject.name == "CarAmbulance(Clone)")
        {
            bossScript.currentHP += 12;
            if(bossScript.currentHP > bossScript.bossHPphase[bossScript.currentPhase])
            {
                bossScript.currentHP = bossScript.bossHPphase[bossScript.currentPhase];
            }
            Destroy(trig.gameObject);
        }
        if(trig.gameObject.name == "CarPolice(Clone)")
        {
            bossScript.currentHP -= 5;
            Destroy(trig.gameObject);
            CheckHP();
            
        }
    }
    public void CheckHP()
    {
        if (bossScript.currentHP <= 0)
        {
            bossScript.NextPhase();
        }

        switch (gameInfo.increaseCarSpeed)
        {
            case 0:
                if (bossScript.currentHP > bossScript.bossHPphase[bossScript.currentPhase] / 4)
                {
                    gameInfo.increaseCarSpeed++;
                }
                break;
            case 1:
                if (bossScript.currentHP > bossScript.bossHPphase[bossScript.currentPhase] / 4 * 2)
                {
                    gameInfo.increaseCarSpeed++;
                }
                else if (bossScript.currentHP < bossScript.bossHPphase[bossScript.currentPhase] / 4 * 2)
                {
                    gameInfo.increaseCarSpeed--;
                }
                break;
            case 2:
                if (bossScript.currentHP > bossScript.bossHPphase[bossScript.currentPhase] / 4 * 3)
                {
                    gameInfo.increaseCarSpeed++;
                }
                else if (bossScript.currentHP < bossScript.bossHPphase[bossScript.currentPhase] / 4 * 3)
                {
                    gameInfo.increaseCarSpeed--;
                }
                break;
            

            
        }
        
    }
    public void KnockDown()
    {
        Destroy(this.gameObject);
    }
}
