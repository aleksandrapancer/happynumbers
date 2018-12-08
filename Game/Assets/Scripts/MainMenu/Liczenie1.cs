using Assets.Scripts.MainMenu;
using UnityEngine;

public class Liczenie1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnCalculationButtonClick();
    }
}
