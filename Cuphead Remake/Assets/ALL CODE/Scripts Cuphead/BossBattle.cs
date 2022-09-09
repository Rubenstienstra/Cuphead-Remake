using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public GamentBattle gamentBattle;

    public int[] bossHPphase;
    public int currentHP;
    public int currentPhase;

    void Start()
    {
        currentHP = bossHPphase[0];
    }
    private void OnTriggerEnter(Collider trig)
    {
        //if (trig.gameObject.tag == "Weapon Projectile")
        //{
        //    currentHP--;
        //    Destroy(trig.gameObject);
        //    if (currentHP <= 0)
        //    {
        //        NextPhase();
        //    }
        //}
    }
    public void NextPhase()
    {
        if(bossHPphase.Length > currentPhase)
        {
            currentPhase++;
            currentHP = bossHPphase[currentPhase];
           
        }
        else
        {
            KnockOut();
        }
    }
    public void KnockOut()
    {
        gamentBattle.KnockDown();
    }

}
