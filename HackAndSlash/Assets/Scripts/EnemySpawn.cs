using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private ObjectPool objectPool;
    public GameObject prefab;

    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timeToSpawn)
        {
            GameObject newObject = objectPool.GetObject(prefab);
            newObject.transform.position = this.transform.position;
            timeSinceSpawn = 0f;
        }
    }
}
