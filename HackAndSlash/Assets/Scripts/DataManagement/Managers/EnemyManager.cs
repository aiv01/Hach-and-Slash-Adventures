using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy {
    chomper,
    spitter,
    last
}
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int enemyNumber;
    private GameObject[,] enemies;
    [SerializeField] private GameObject originalChomper;
    [SerializeField] private GameObject originalSpitter;

    void Awake()
    {
        enemies = new GameObject[(int)Enemy.last, enemyNumber * (int)Enemy.last];
        CreateEnemies();
    }

    private void CreateEnemies() {
        for (int j = 0; j < (int)Enemy.last; j++) {
            for (int i = 0; i < enemies.GetLength(1)/(int)Enemy.last; i++) {
                switch ((Enemy)j) {
                    case Enemy.chomper:
                        enemies[j, i] = Instantiate(originalChomper);
                        enemies[j, i].name = "Chomper_" + i;
                        enemies[j, i].transform.parent = gameObject.transform;
                        enemies[j, i].gameObject.SetActive(false);
                        break;
                    case Enemy.spitter:
                        enemies[j, i] = Instantiate(originalSpitter);
                        enemies[j, i].name = "Spitter_" + i;
                        enemies[j, i].transform.parent = gameObject.transform;
                        enemies[j, i].gameObject.SetActive(false);
                        break;
                    case Enemy.last:
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public GameObject GetEnemy(Enemy type) {
        for (int i = 0; i < enemies.Length; i++) {
            if (!enemies[(int)type, i].gameObject.activeSelf) {
                Debug.Log("Preso: " + enemies[(int)type, i].name);
                return enemies[(int)type, i];
            }
        }
        Debug.Log("Non esistono proiettili");
        return null;
    }
}
