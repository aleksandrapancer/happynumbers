using Assets.Scripts.MainMenu;
using UnityEngine;

public class MenuWiek : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnYoungerButtonClick();
    }
}
