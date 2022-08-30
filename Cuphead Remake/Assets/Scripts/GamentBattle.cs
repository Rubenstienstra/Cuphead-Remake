using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamentBattle : MonoBehaviour
{
    public BossBattle bossScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public IEnumerator Attack1()
    {
        yield return new WaitForSeconds(0.1f);
    }
    public void KnockDown()
    {
        Destroy(this.gameObject);
    }
}
