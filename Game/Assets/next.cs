using Assets.Scripts.MainMenu;
using UnityEngine;

public class next : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance?.OnSetTheTimeButtonClick();
    }

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
