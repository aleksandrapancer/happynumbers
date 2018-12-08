using Assets.Scripts.MainMenu;
using UnityEngine;

public class Wyjscie : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnQuitButtonClick();
    }
}
