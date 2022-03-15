using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newClass", menuName = "Data/Class")]
public class ClassData : StatData
{
    public string className;
    public int incrementVigor;
    public int incrementStrength;
    public int incrementDexterity;
    public int incrementIntelligence;
}
