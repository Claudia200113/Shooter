using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed = 5;
    public GameObject originalBullet;
    public Coroutine coroutineWaitTime;
    void Start()
    {
      
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(-h * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, v* speed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            coroutineWaitTime = StartCoroutine(WaitingTime());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(coroutineWaitTime);
        }
    }

    IEnumerator WaitingTime()
    {
        //------------INFINITE LOOP-------------
        while (true)
        {
            ProjectilePool.Instance.GetProjectile(transform.position);
            yield return new WaitForSeconds(.75f);
        }

    }

}
