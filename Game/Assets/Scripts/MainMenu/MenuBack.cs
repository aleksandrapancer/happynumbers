using Assets.Scripts.MainMenu;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuBack : MonoBehaviour, IPointerDownHandler
{
    public void OnMouseDown()
    {
        GameManager.Instance?.OnBackButtonClick();
        Debug.Log("Back!");

    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        GameManager.Instance?.OnBackButtonClick();
        Debug.Log("Back!");
    }
}