using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ScriptableGameInfo gameInfo;

    public float lifeDuration;
    public float damage;
    public float speed;

    public bool startCheckLR;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifespan());
        if(gameInfo.playerLeft == true)
        {
            startCheckLR = true;
        }
    }
    public void Update()
    {
        if(startCheckLR == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
    }
    //private void OnCollisionEnter(Collision col)
    //{
    //    if (col.collider.gameObject.tag == "Background")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(lifeDuration);
        Destroy(this.gameObject);
        yield return new WaitForSeconds(0);
    }

}
