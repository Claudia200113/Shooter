using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private GameObject originalProjectile;
    [SerializeField] private int poolSize;

    private Queue<GameObject> queue;
    
    public static ProjectilePool Instance
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

        queue= new Queue<GameObject>();


        for (int i = 0; i < poolSize; i++)
        {
           GameObject nuevo = Instantiate<GameObject>(originalProjectile);

            nuevo.SetActive(false);

            queue.Enqueue(nuevo);

        }
    }
    public GameObject GetProjectile(Vector3 position)
    {
        if (queue.Count == 0)
            return null;

        GameObject next = queue.Dequeue();
    
        if(next == null)
        {
            return null;
        }

        next.SetActive(true);
        next.transform.position = position;
        next.transform.rotation = originalProjectile.transform.rotation;
        return next;
    }
    public void LeaveProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        queue.Enqueue(projectile);
    }


}

