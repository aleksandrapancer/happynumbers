using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Zegar2 : MonoBehaviour
{
  void OnMouseDown()
    {
        //wczytanie sceny
        SceneManager.LoadScene("ClockLearning");
    }
}

