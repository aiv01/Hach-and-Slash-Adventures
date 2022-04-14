using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectorPauseMenuScript : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private PauseMenuOption selection;
    [SerializeField] private PauseMenuController pauseMenuController;

    //Dagli la reference al menucontroller
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        pauseMenuController.ChangeSelection(selection);
    }
}
