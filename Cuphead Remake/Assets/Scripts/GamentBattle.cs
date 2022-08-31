using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamentBattle : MonoBehaviour
{
    public BossBattle bossScript;

    public int randomAttackGeneration;
    public float waitTimeAttack;

    public Vector3 hospitalEnemySpawn;
    public GameObject[] hospitalWagon;
    public int randomNumber;
    public int maxSpawnHospital;
    public int hospitalSpawned;
    

    void Start()
    {
        StartCoroutine(ChoosingAttack());
    }
    public IEnumerator ChoosingAttack()
    {
        randomAttackGeneration = Random.Range(1, 3);
        switch (randomAttackGeneration)
        {
            case 1:
                StartCoroutine(Attack1());
                waitTimeAttack = 20;
                break;
            case 2:
                StartCoroutine(Attack1());
                waitTimeAttack = 20;
                break;
            case 3:
                StartCoroutine(Attack1());
                waitTimeAttack = 20;
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
        
    }
    public void SpawnHospitalWagon()
    {
       randomNumber = Random.Range(0, 2);
        Instantiate(hospitalWagon[randomNumber], hospitalEnemySpawn,Quaternion.Euler(90,0,0));
    }
    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "Weapon Projectile")
        {
            bossScript.currentHP--;
            Destroy(trig.gameObject);
            if (bossScript.currentHP <= 0)
            {
               bossScript.NextPhase();
            }
        }
        if (trig.gameObject.name == "CarAmbulance(Clone)")
        {
            bossScript.currentHP += 15;
            Destroy(trig.gameObject);
        }
        if(trig.gameObject.name == "CarPolice(Clone)" || trig.gameObject.name == "")
        {
            bossScript.currentHP += 5;
            Destroy(trig.gameObject);
        }
    }
    public void KnockDown()
    {
        Destroy(this.gameObject);
    }
}
