using System.Collections.Generic;
using UnityEngine;

public class GenerateNumbers : MonoBehaviour
{

    public Sprite sprite12;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;
    public Sprite sprite11;


    int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    List<int> list = new List<int>();
    List<int> listClock = new List<int>();

    Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();
    Dictionary<int, string> dictionary = new Dictionary<int, string>();

    void Start()
    {

        dictionary.Add(1, "img1");
        dictionary.Add(2, "img2");
        dictionary.Add(3, "img3");
        dictionary.Add(4, "img4");
        dictionary.Add(5, "img5");
        dictionary.Add(6, "img6");
        dictionary.Add(7, "img7");
        dictionary.Add(8, "img8");
        dictionary.Add(9, "img9");
        dictionary.Add(10, "img10");
        dictionary.Add(11, "img11");
        dictionary.Add(12, "img12");


        spriteDictionary.Add("sprite1", sprite1);
        spriteDictionary.Add("sprite2", sprite2);
        spriteDictionary.Add("sprite3", sprite3);
        spriteDictionary.Add("sprite4", sprite4);
        spriteDictionary.Add("sprite5", sprite5);
        spriteDictionary.Add("sprite6", sprite6);
        spriteDictionary.Add("sprite7", sprite7);
        spriteDictionary.Add("sprite8", sprite8);
        spriteDictionary.Add("sprite9", sprite9);
        spriteDictionary.Add("sprite10", sprite10);
        spriteDictionary.Add("sprite11", sprite11);
        spriteDictionary.Add("sprite12", sprite12);

        list.AddRange(numbers);

        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, list.Count);

            string name = "sprite" + list[rand];
            listClock.Add(list[rand]);
            list.RemoveAt(rand);
        }
    }


    public List<int> GetList() {
        return list;
    }

    public List<int> GetListClock() {
        return listClock;
    }

    public Dictionary<string, Sprite> GetSpriteDic() {
        return spriteDictionary;
    }


    public Dictionary<int, string> GetDic()
    {
        return dictionary;
    }

}
