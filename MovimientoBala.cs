using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float speed = 5;
    
    void Start()
    {
        StartCoroutine(Disable());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(5);
        ProjectilePool.Instance.LeaveProjectile(gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
            ProjectilePool.Instance.LeaveProjectile(gameObject); 
    }
}
