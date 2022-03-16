using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStat", menuName = "Data/Stat")]
public class StatData : ScriptableObject
{
    public int baseVigor;
    public int baseStrength;
    public int baseDexterity;
    public int baseIntelligence;
}
