using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private EnemyManager em;
    [SerializeField] private float spawnSpread;
    [SerializeField] private float spawnTime;
    private float currentSpawnTime;
    [Range(0, 100)] [SerializeField] private int spitterRarity;

    private void Awake() {
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        currentSpawnTime = spawnTime;
    }

    private void Update() 
    {
        Spawn();
    }

    public void Spawn()
    {
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            currentSpawnTime = spawnTime;
            GameObject currentEnemy;
            if (Random.Range(0, 100) > spitterRarity)
            {
                currentEnemy = em.GetEnemy(Enemy.spitter);
            }
            else
            {
                currentEnemy = em.GetEnemy(Enemy.chomper);
            }
            currentEnemy.transform.position = new Vector3(transform.position.x + Random.insideUnitCircle.x * spawnSpread, 0, transform.position.z + Random.insideUnitCircle.y * spawnSpread);
            currentEnemy.SetActive(true);
        }

    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, spawnSpread);
    }
}
