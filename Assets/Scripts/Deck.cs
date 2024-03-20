using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
public List<GameObject> deck = new List<GameObject>();
public   List<GameObject> hand = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0 ; i < 10 ;i++)
    {
        GameObject temp = deck[Random.Range(0,deck.Count)];
        hand.Add(temp);
        deck.Remove(temp);
    }
   

    Transform handposi = transform.Find("HandPosition");
    //Mostrar tablero
    for(int i = 0 ; i < hand.Count ; i++)
    {
        GameObject card = hand[i];
        Transform pos = handposi.GetChild(i);
        GameObject nuevainstancia = Instantiate(card,pos.position,Quaternion.identity);
        float scale = 0.02590f;
        nuevainstancia.transform.localScale = new Vector3(scale,scale,scale);
        
    }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
