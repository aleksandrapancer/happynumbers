using UnityEngine;
using System.Collections;

public class MenuWiek : MonoBehaviour 
{
    void OnMouseDown()
    {
        //wczytanie sceny
        Application.LoadLevel("MenuMlodsze");
    }
}
