using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomResults : MonoBehaviour {

    AddImage addImg = new AddImage();
    private List<int> listObject;
    private List<int> listButton;
    private GenerateValues generateValues;
    private Dictionary<string, Sprite> spriteDictionary;
    int correctNumber, number1, number2;

    public Sprite empty;

    public AudioSource correctSound, incorrectSound;

    void Start()
    {
        GameObject go = GameObject.Find("Canvas");
        generateValues = (GenerateValues)go.GetComponentInChildren<GenerateValues>();
        generateValues.Startt();
        listObject = generateValues.GetObjectList();
        listButton = generateValues.GetButtonList();
        spriteDictionary = generateValues.GetSpriteDic();

        PutImagesToScene();
    }

    public void PutImagesToScene()
    {

 
        correctNumber = Random.Range(1, 11);
        do
        {
            number1 = Random.Range(1, 11);
        } while (correctNumber == number1);

        do
        {
            number2 = Random.Range(1, 11);
        } while (number2 == correctNumber || number2 == number1);

        generateValues.AddImagesToButtonList(correctNumber-1, number1-1, number2-1);

        int index = 0;
        foreach (Transform item in transform.parent.Find("Panel_left"))
        {
            string name = "sprite" + listButton[index];
            addImg.ChangeImg(item.GetComponent<Image>(), spriteDictionary[name]);
            index++;
        }

        index = 0;
        generateValues.AddImagesToObjectsList(correctNumber);
        foreach (Transform item in transform.parent.Find("Panel_right"))
        {
            if (index==correctNumber)
                break;

            string name = "sprite" + listObject[0];
            addImg.ChangeImg(item.GetComponent<Image>(), spriteDictionary[name]);
            index++;
        }
    }

    public void CheckCorrectResult(int buttonNumber)
    {
        Transform child = transform.parent.Find("Panel_left").GetChild(buttonNumber);
        var name = child.GetComponent<Image>().sprite.name;

        if (correctNumber.ToString().Equals(name))
        {
            correctSound.Play();
            foreach (Transform transform in transform.parent.Find("Panel_right")) {
                addImg.ChangeImg(transform.GetComponent<Image>(), empty);
            }
            PutImagesToScene();
        }
        else
        {
            incorrectSound.Play();
        }
        
    }

}
