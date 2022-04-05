using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveStatue : MonoBehaviour
{
    [SerializeField] private float playerDistanceToSave;
    [SerializeField] private TextMeshPro popup;

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerInteracting();
    }

    private void CheckIfPlayerInteracting() {
        float playerDistance = (transform.position - PlayerLogic.Instance.transform.position).magnitude;
        if (playerDistance < playerDistanceToSave) {
            if (PlayerLogic.Instance.isInteracting) {
                DataManagement.Save();
                TextMeshPro instance = Instantiate<TextMeshPro>(popup);
                instance.transform.position = transform.position;
                instance.text = "Game saved";
            }
        }
    }
}
