
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour
{

    AddImage addImg = new AddImage();
    int item = 1;
    private List<int> listNumber;
    private List<int> listObject;
    private GenerateValues generateValues;
    private Dictionary<string, Sprite> spriteDictionary;
    float newTime;
    float timeInMinutes = 4f;

    void Start()
    {
        GameObject go = GameObject.Find("Canvas");
        generateValues = (GenerateValues)go.GetComponentInChildren<GenerateValues>();
        generateValues.Startt();
        listNumber = generateValues.GetNumberList();
        listObject = generateValues.GetObjectList();
        spriteDictionary = generateValues.GetSpriteDic();

        PutImages(item);
    }

    void Update()
    {
        newTime += Time.deltaTime;
        if (newTime >= timeInMinutes)
        {
            if (item == 11) {
                SceneManager.LoadScene("NumberGame");
            }
           
            newTime = 0f;
            PutImages(item);
        }
    }

    public void PutImages(int itemNumber)
    {
        generateValues.AddImagesToObjectsList(itemNumber);

        int index = 0;
        foreach (Transform item in transform.parent.Find("Panel_right"))
        {
            if (index == itemNumber)
                break;

            string name = "sprite" + listObject[0];
            addImg.ChangeImg(item.GetComponent<Image>(), spriteDictionary[name]);

            index++;
        }

        string numberName = "sprite" + listNumber[itemNumber - 1];
        Transform number = transform.parent.Find("Panel_left").GetChild(0);
        addImg.ChangeImg(number.GetComponent<Image>(), spriteDictionary[numberName]);

        item++;
    }

}
