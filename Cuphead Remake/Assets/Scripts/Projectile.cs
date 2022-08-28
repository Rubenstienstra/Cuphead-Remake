using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ScriptableGameInfo gameInfo;

    public float lifeDuration;
    public float damage;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifespan());
        if(gameInfo.playerLeft == true)
        {

        }
        else
        {

        }
    }

    IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(lifeDuration);
        Destroy(this.gameObject);
        yield return new WaitForSeconds(0);
    }

}
