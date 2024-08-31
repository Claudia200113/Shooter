using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject originalEnemy;
    [SerializeField] private int poolSize;

    private Queue<GameObject> queue; 

    public static EnemyPool Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        } 

        queue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject nuevo = Instantiate<GameObject>(originalEnemy);
            nuevo.SetActive(false);
            queue.Enqueue(nuevo);
        }
    }
    public GameObject GetEnemy(Vector3 position)
    {
        if (queue.Count == 0)
            return null;

        GameObject next = queue.Dequeue();

        if (next == null)
        {
            return null;
        }
        next.SetActive(true);
        next.transform.position = position;
        next.transform.rotation = originalEnemy.transform.rotation;
        return next;
    }
    public void LeaveEnemy(GameObject projectile)
    {
        projectile.SetActive(false);
        queue.Enqueue(projectile);
    }
}