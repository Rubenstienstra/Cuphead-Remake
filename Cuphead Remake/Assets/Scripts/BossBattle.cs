using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag == "Weapon Projectile")
        {
            hp--;
            Destroy(col.collider.gameObject);
        }
    }
    
}
