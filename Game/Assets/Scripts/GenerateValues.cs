using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateValues : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>();
    int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33 };
    List<int> list = new List<int>();
    List<int> listButton = new List<int>();
    List<int> listNumber = new List<int>();
    List<int> listObject = new List<int>();
    List<int> listHelp = new List<int>();
    
    Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();
    Dictionary<int, string> dictionary = new Dictionary<int, string>();

    public void Startt()
    {
        for (int i = 1; i < 33; i++)
        {
         
              string name = "img" + i;
           
            string spriteName = "sprite" + i;
            dictionary.Add(i, name);
           
            spriteDictionary.Add(spriteName, spriteList[i-1]);
        }

     

        list.AddRange(numbers);

        for (int i = 0; i < 33; i++)
        {
            Debug.Log(i);
            listNumber.Add(list[i]);
        }
    }

    public void AddImagesToButtonList(int image1, int image2, int image3)
    {
        listButton.Clear();
        listHelp.Add(image1);
        listHelp.Add(image2);
        listHelp.Add(image3);
        int helpValue = 0, random1 = 0, random2 = 0, random3 = 0;

        for (int i = 0; i < 3; i++)
        {
            random1 = Random.Range(0, listHelp.Count);
            listButton.Add(list[listHelp[random1]]);
            listHelp.RemoveAt(random1);
        }
    }

    public void AddImagesToObjectsList(int objectCount)
    {
        listObject.Clear();
        var randomObject = Random.Range(10, spriteList.Count);
       // Debug.Log(randomObject);
        for (int i = 0; i < objectCount; i++)
        {
            listObject.Add(list[randomObject]);
        }
    }

    public List<int> GetNumberList()
    {
        return listNumber;
    }

    public List<int> GetObjectList()
    {
        return listObject;
    }

    public List<int> GetButtonList()
    {
        return listButton;
    }

    public Dictionary<string, Sprite> GetSpriteDic()
    {
        return spriteDictionary;
    }

}
