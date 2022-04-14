using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectorScript : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private MenuOption selection;
    [SerializeField] private MenuController menuController;

  //Dagli la reference al menucontroller
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        menuController.ChangeSelection(selection);
    }
}
