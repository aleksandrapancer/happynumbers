using Assets.Scripts.MainMenu;
using UnityEngine;

public class Zegar2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnClockLearningButtonClick();
    }
}

