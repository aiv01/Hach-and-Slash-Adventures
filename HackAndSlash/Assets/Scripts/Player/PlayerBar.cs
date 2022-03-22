using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    private Image content;

    [SerializeField] private float lerpSpeed;

    private float currentFill;

    public float MaxValue { get; set; }

    private float currentValue;

    public float CurrentValue
    {
        get { return currentValue; }
        set 
        {
            if(value > MaxValue)
            {
                currentValue = MaxValue;
            }
            else if(value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MaxValue;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    public void Initialize(float currentValue,float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
    }

    void HandleBar()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.MoveTowards(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }
}
