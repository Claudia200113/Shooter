using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public float fallingSpeed = 3;
    public static int playerScore = 0;

    void Update()
    {
        transform.Translate(0, -fallingSpeed * Time.deltaTime, 0, Space.World);
    }

    IEnumerator Deshabilitar()
    {
        yield return new WaitForSeconds(6);
        EnemyPool.Instance.LeaveEnemy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.tag == "bala")
        {          
            ProjectilePool.Instance.LeaveProjectile(gameObject);
            playerScore += 100;
            Debug.Log("Enemy defeated. Score = " + playerScore.ToString());

        }
        else
        {
            playerScore -= 100;
            ProjectilePool.Instance.LeaveProjectile(gameObject);
            Debug.Log("Hit recieved. Score = " + playerScore.ToString());
        }
    }
}
