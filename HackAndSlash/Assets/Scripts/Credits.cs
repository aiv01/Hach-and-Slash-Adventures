using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(rectTransform.anchoredPosition.y >= rectTransform.rect.height) {
            SceneManager.LoadScene("MenuMainScene");
        }
        rectTransform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
