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
        
    }
    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "Weapon Projectile")
        {
            currentHP--;
            Destroy(trig.gameObject);
            NextPhase();
            if (currentHP <= 0)
            {
                
            }
        }
    }
    public void NextPhase()
    {
        if(bossHPphase.Length > currentPhase)
        {
            currentHP = bossHPphase[currentPhase];
           currentPhase++;
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
