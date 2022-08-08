using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeDuration;
    public float damage;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifespan());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(lifeDuration);
        Destroy(this.gameObject);
        yield return new WaitForSeconds(0);
    }

}
