using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Deck : MonoBehaviour
{
public  List<GameObject> deck = new List<GameObject>();
public  List<GameObject> hand = new List<GameObject>();
private int cantidad = 1;
private int cantidadRival = 1;

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
        Debug.Log(card);
        Debug.Log(nuevainstancia);
        float scale = 0.02590f;
        nuevainstancia.transform.localScale = new Vector3(scale,scale,scale);       
    }  
    }
    
    #region Barajear
    ///<summary>
///Este metodo se utiliza para el inicio del juego para devolver dos cartas de la mano al deck y tomar otras dos
///</summary>

    public void Barajear ()
    {
        
        Debug.Log(BotonesSettings.Turnos);
        if(BotonesSettings.Turnos == 1 && cantidad == 1 || BotonesSettings.Turnos == 2 && cantidadRival == 1)
        {
            if(BotonesSettings.Turnos == 1)
            {
                cantidad++;
            }
            if(BotonesSettings.Turnos == 2)
            {
                cantidadRival++;
            }
            int Random1 = Random.Range(0,10);
        int Random2 = Random.Range(0,10);
        if(Random1 != Random2)
        {
            hand.RemoveAt(Random1);
            hand.RemoveAt(Random2);
            for(int i = 0 ; i < 2 ; i++)
            {
                GameObject temp = deck[Random.Range(0,deck.Count)];
                hand.Add(temp);
                deck.Remove(temp);
            }
        Transform handposi = transform.Find("HandPosition");
        GameObject card = hand[8];
        Transform pos = handposi.GetChild(Random1);
        GameObject nuevainstancia = Instantiate(card,pos.position,Quaternion.identity);
        Debug.Log(card);
        Debug.Log(nuevainstancia);
        float scale = 0.02590f;
        nuevainstancia.transform.localScale = new Vector3(scale,scale,scale);  
        //Segunda Carta
        GameObject card2 = hand[9];
        Transform pos1 = handposi.GetChild(Random2);
        GameObject nuevainstancia2 = Instantiate(card2,pos1.position,Quaternion.identity);
        Debug.Log(card2);
        Debug.Log(nuevainstancia2);
        nuevainstancia2.transform.localScale = new Vector3(scale,scale,scale);   
            
        }
        }
          else
        {
            Debug.Log("Solo se puede barajear una sola vez y en el primer turno del juego");
        }
      
    }
 #endregion
    #region Robar Dos Cartas
    public void Robar()
    {
       if(CardUnidad.Invocadas.Count >= 2) 
       {
        int carta1 = CardUnidad.Invocadas[0];
        int carta2 = CardUnidad.Invocadas[1];
        hand.RemoveAt(carta1);
        hand.RemoveAt(carta2);
        //Primera Carta
        GameObject temp = deck[Random.Range(0,deck.Count)];
        hand.Add(temp);
        deck.Remove(temp);
        //Segunda Carta
        GameObject temp2 = deck[Random.Range(0,deck.Count)];
        hand.Add(temp2);
        deck.Remove(temp2);
         Transform handposi = transform.Find("HandPosition");
        GameObject card = hand[hand.Count -1];
        Transform pos = handposi.GetChild(carta1);
        GameObject nuevainstancia = Instantiate(card,pos.position,Quaternion.identity);
        Debug.Log(card);
        Debug.Log(nuevainstancia);
        float scale = 0.02590f;
        nuevainstancia.transform.localScale = new Vector3(scale,scale,scale);  
        //Carta2
        GameObject card2 = hand[hand.Count -2];
        Transform pos2 = handposi.GetChild(carta2);
        GameObject nuevainstancia2 = Instantiate(card2,pos2.position,Quaternion.identity);
        Debug.Log(card2);
        Debug.Log(nuevainstancia2);
        nuevainstancia2.transform.localScale = new Vector3(scale,scale,scale);  
       }
       

    }
    #endregion
    // Update is called once per frame
    void Update()
    {
       
    }
}
