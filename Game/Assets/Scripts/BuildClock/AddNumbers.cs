using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNumbers : MonoBehaviour {

    AddImage addImg = new AddImage();
    Dictionary<int, string> dic;
    int rand = 0;

    void Start () {
        GameObject go = GameObject.Find("Canvas");
        GenerateNumbers generateNumbers = (GenerateNumbers)go.GetComponentInChildren<GenerateNumbers>();
        List<int> list = generateNumbers.GetListClock();
        Dictionary<string, Sprite> spriteDictionary = generateNumbers.GetSpriteDic();
        dic = generateNumbers.GetDic();

        foreach (Transform child in transform)
        {
            for(int i=0; i < list.Count; i++)
            {
                if (child.name == dic[list[i]])
                {
                    addImg.ChangeImg(child.GetComponent<Image>(), spriteDictionary[("sprite" + list[i])]);
                }
            }

        }
    }
}
