using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public int[] bossHPStages;
    public int currentHP;
    void Start()
    {
        for (int i = 0; i < bossHPStages.Length;)
        {
            if (bossHPStages[i] <= 0)
            {
                i++;
            }
            else
            {
                currentHP = bossHPStages[i];
            }
        }
    }
    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "Weapon Projectile")
        {
            currentHP--;
            Destroy(trig.gameObject);
            if(currentHP <= 0)
            {
                for (int i = 0; i < bossHPStages.Length;)
                {
                    if(bossHPStages[i] <= 0)
                    {
                        i++;
                    }
                    else
                    {
                        currentHP = bossHPStages[i];
                    }
                }
                KnockOut();
            }
        }
    }
    public void KnockOut()
    {
        Destroy(this.gameObject);
    }

}
