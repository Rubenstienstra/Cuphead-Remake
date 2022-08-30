using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamentBattle : MonoBehaviour
{
    public BossBattle bossScript;

    public Vector3 hospitalEnemySpawn;
    public GameObject[] hospitalWagon;
    public int randomNumber;
    public int maxSpawnHospital;
    

    void Start()
    {
        StartCoroutine(Attack1());
    }
    public IEnumerator Attack1()
    {
        yield return new WaitForSeconds(1.8f);
        SpawnHospitalWagon();
        maxSpawnHospital++;
        if(maxSpawnHospital < 5)
        {
            StartCoroutine(Attack1());
        }
        else
        {
            maxSpawnHospital = 0;
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
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.name == "CarAmbulance")
        {
            bossScript.currentHP += 10;
        }
    }
    public void KnockDown()
    {
        Destroy(this.gameObject);
    }
}
