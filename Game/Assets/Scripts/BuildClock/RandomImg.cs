
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImg : MonoBehaviour { 
    AddImage addImg = new AddImage();
    Dictionary<string, int> dic = new Dictionary<string, int>();
    int rand = 0;

    void Start()
    {
        GameObject go = GameObject.Find("Canvas");
        GenerateNumbers generateNumbers = (GenerateNumbers)go.GetComponentInChildren<GenerateNumbers>();
        List<int> list = generateNumbers.GetList();
        Dictionary<string, Sprite> spriteDictionary = generateNumbers.GetSpriteDic();

        foreach (Transform child in transform)
        {
            rand = Random.Range(0, list.Count);
            if (list.Contains(list[rand])) {
                string name = "sprite" + list[rand];

                addImg.ChangeImg(child.GetComponent<Image>(), spriteDictionary[name]);
                dic.Add(child.name, list[rand]);

                list.RemoveAt(rand);
            }

        }


    }

    public Dictionary<string,int> getDic()
    {
        return dic; 
    }



}
