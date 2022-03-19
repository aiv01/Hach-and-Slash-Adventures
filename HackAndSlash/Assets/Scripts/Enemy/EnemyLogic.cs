using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class EnemyLogic : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int level = 1;
    
    [Header("References")]
    private CharacterStats enemyStats;
    // Start is called before the first frame update
    private void Awake() {
        enemyStats = GetComponent<CharacterStats>();
    }

    private void OnEnable() {
        enemyStats.InitializeCharacter();
        BalanceToLevel();
    }

    private void BalanceToLevel() {
        EnemyData currentEnemy = (EnemyData)enemyStats.stats;
        enemyStats.vigor += level - 1;
        enemyStats.strength += level - 1;
        enemyStats.dexterity += level - 1;
        enemyStats.intelligence += level - 1;
        enemyStats.CalculateStats();
        enemyStats.exp = currentEnemy.exp;
    }

    private void Update() {
        if (enemyStats.hp <= 0) {
            Die();
        }   
    }

    private void Die() {
        PlayerLogic.Instance.GetExp(enemyStats.exp);
        gameObject.SetActive(false);
    }
}
