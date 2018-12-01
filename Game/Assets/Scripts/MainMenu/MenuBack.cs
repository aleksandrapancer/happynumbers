using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBack : MonoBehaviour
{
    void OnMouseDown()
    {
        //wczytanie sceny
        SceneManager.LoadScene("MenuWiek");
    }
}
