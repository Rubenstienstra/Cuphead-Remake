using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureEnemy : MonoBehaviour
{
    public int hp;
    public float creatureSpeed;

    public GameObject LeftLight;
    public GameObject RightLight;
    void Start()
    {
        StartCoroutine(LightSwitch());
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
            Destroy(trig.gameObject);
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag == "Background")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator LightSwitch()
    {
        yield return new WaitForSeconds(0.5f);
        LeftLight.SetActive(false);
        RightLight.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        LeftLight.SetActive(true);
        RightLight.SetActive(false);
    }
    



}
