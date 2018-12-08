using Assets.Scripts.MainMenu;
using UnityEngine;

public class Cyferki : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnNumbersLearningButtonClick();
    }
}
