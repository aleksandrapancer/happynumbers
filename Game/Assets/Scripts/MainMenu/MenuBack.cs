using Assets.Scripts.MainMenu;
using UnityEngine;

public class MenuBack : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnBackButtonClick();
    }
}
