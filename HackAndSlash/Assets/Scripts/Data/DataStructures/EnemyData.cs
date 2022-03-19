using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    horde,
    elite,
    boss
}
[CreateAssetMenu(fileName = "newEnemy", menuName = "Data/Enemy")]
public class EnemyData : StatData
{
    public string enemyName;
    public EnemyType type;
    public int exp;
}
