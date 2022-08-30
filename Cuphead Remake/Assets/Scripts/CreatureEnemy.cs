using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureEnemy : MonoBehaviour
{
    public int hp;
    public float creatureSpeed;
    void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * creatureSpeed);
    }
    private void OnTriggerEnter(Collider trig)
    {
        if(trig.gameObject.tag == "Weapon Projectile")
        {
            hp--;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    



}
