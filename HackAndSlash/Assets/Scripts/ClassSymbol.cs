using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSymbol : MonoBehaviour
{
    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        ClassData data = (ClassData)PlayerLogic.Instance.playerStats.stats;
        image.sprite = data.classToken;
    }
}
