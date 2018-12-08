using Assets.Scripts.MainMenu;
using UnityEngine;

public class Zegar1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnBuildClockButtonClick();
    }
}
