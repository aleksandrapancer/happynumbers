using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cyferki : MonoBehaviour
{
    void OnMouseDown()
      {
        //wczytanie sceny
        SceneManager.LoadScene("LearnNumbers");
    }
}
