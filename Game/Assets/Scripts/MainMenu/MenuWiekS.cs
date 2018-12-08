using Assets.Scripts.MainMenu;
using UnityEngine;

public class MenuWiekS : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnOlderButtonClick();
    }
}
