using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Liczenie1 : MonoBehaviour
{
  void OnMouseDown()
    {
        //wczytanie sceny
        SceneManager.LoadScene("Calculation");
    }
}
