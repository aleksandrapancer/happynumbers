using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocket : MonoBehaviour {

    Dictionary<int, string> dictionary;

    void Start() {

        GameObject go = GameObject.Find("Canvas");
        GenerateNumbers generateNumbers = (GenerateNumbers)go.GetComponentInChildren<GenerateNumbers>();
         dictionary = generateNumbers.GetDic(); 
    }


    void OnCollisionStay2D(Collision2D col){
        GameObject go = GameObject.Find("Panel_left");
        RandomImg script = (RandomImg)go.GetComponentInChildren<RandomImg>();
        Dictionary<string,int> dic = script.getDic(); 

        string imgName = col.collider.gameObject.name;
        string placeName = gameObject.name; 

        if (placeName == dictionary[dic[imgName]])
        {
	        //imgName = "";

	        Debug.Log("CorrectPlace "+placeName);
            col.collider.GetComponent<items> ().collision = true;
            if (!col.collider.GetComponent<items>().dragging) {
	            // Debug.Log("Not draggig");
                 col.collider.gameObject.transform.position = transform.position;
            }
        }

    }

    void OnCollisionExit2D(Collision2D col) {
        col.collider.GetComponent<items>().collision = false;
    }


}
