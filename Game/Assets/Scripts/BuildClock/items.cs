using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour {

    public bool dragging = false;
    public bool collision = false;
    Vector3 position;
     Vector3 startPosition;



     public void onTouch()
     {
	     position = gameObject.transform.position;

     }

     public void beginDrag() {
	    startPosition = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
	    Debug.Log(startPosition.x);
        position = gameObject.transform.position;
        dragging = true;
    }

    public void drag() {
        transform.position = Input.mousePosition;
    }

    public void drop() {
        if (!collision)
        {
            gameObject.transform.position = position;
            Debug.Log(position);
        }
        else
        {
	        dragging = false;

	        Debug.Log(":Good!");
	        AudioSource goodMove;
	        GetComponent<AudioSource>().Play();
        }
    }

}
