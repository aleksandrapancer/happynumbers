using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddImage : MonoBehaviour {

    public Sprite Image1;
  
    public void ChangeImg(Image img, Sprite Image1){
        img.sprite = Image1;
    }
}
