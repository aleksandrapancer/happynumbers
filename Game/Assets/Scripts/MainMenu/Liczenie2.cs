using Assets.Scripts.MainMenu;
using UnityEngine;

public class Liczenie2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnCalculation2ButtonClick();
    }
}
