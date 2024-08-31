using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    void Start()
    {
        StartCoroutine (enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds (Random.Range(1f, 3f));
            
            EnemyPool.Instance.GetEnemy(transform.position);
        }
            

    }
}
