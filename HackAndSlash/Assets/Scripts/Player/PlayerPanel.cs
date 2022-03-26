using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    public void OpenClose()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
