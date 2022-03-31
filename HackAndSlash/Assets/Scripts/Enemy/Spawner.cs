using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private EnemyManager em;
    [SerializeField] private float spawnSpread;
    [SerializeField] private float spawnTime;
    private float currentSpawnTime;
    private int enemySpawned = 0;
    [SerializeField] private int enemiesToSpawn;
    [Range(1, 25)] private int level;
    [SerializeField] private GameObject wallToDisable;
    [Range(0, 100)] [SerializeField] private int spitterRarity;

    private void Awake() {
        em = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        currentSpawnTime = spawnTime;
    }

    private void Update() {
        if(enemySpawned < enemiesToSpawn) {
            Spawn();
        }
        if(DataManagement.enemyKilled >= enemiesToSpawn) {
            DataManagement.enemyKilled = 0;
            wallToDisable.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, spawnSpread);
    }

    private void Spawn() {
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0) {
            currentSpawnTime = spawnTime;
            GameObject currentEnemy;
            if (Random.Range(0, 100) > spitterRarity) {
                currentEnemy = em.GetEnemy(Enemy.spitter);
            }
            else {
                currentEnemy = em.GetEnemy(Enemy.chomper);
            }
            currentEnemy.transform.position = new Vector3(transform.position.x + Random.insideUnitCircle.x * spawnSpread, 0, transform.position.z + Random.insideUnitCircle.y * spawnSpread);
            currentEnemy.SetActive(true);
            enemySpawned++;
        }
    }
}
