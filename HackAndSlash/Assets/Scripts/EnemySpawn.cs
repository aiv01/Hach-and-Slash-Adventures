using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] enemySpawn;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 31);
            for(int i = 0; i < enemySpawn.Length; i++)
            {
                Instantiate(enemySpawn[i], new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
