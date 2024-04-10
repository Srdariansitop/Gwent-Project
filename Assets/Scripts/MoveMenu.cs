using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour
{
     private float mousex;
    private float mousey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         mousex = Input.mousePosition.x;
        mousey = Input.mousePosition.y;
        this.GetComponent<RectTransform>().position = new Vector2((mousex/Screen.width) * 20 + (Screen.width /2) , (mousey/Screen.height) * 20 + (Screen.height/2));
    }
}
