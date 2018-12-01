using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddImageButton : MonoBehaviour
{
    public Sprite Image1;


    public void ChangeImg(Transform transform, Sprite Image1) {
        transform.GetComponent<Image>().sprite = Image1;
    }
}


