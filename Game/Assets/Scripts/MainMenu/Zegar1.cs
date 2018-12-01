using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Zegar1 : MonoBehaviour
{
  void OnMouseDown()
    {
        //wczytanie sceny
        SceneManager.LoadScene("BuildClock");
    }
}
