using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStarColor : MonoBehaviour {

    int rand = 0;
    int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
    List<int> list = new List<int>();

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;

    Dictionary<int, Sprite> stars = new Dictionary<int, Sprite>();

    void Start () {

        list.AddRange(numbers);

        stars.Add(1, sprite1);
        stars.Add(2, sprite2);
        stars.Add(3, sprite3);
        stars.Add(4, sprite4);
        stars.Add(5, sprite5);
        stars.Add(6, sprite6);

        randStars(); 
    }


    public void randStars() {
        foreach (Transform child in transform)
        {
            rand = Random.Range(1, list.Count);
            if (list.Contains(rand))
            {
                string name = "sprite" + list[rand];

                AddImageButton addImgBut = child.GetComponent<AddImageButton>();
                addImgBut.ChangeImg(child, stars[rand]);
            }
        }
    }

}
