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
private int cantidadRobar = 0;
private int cantidadRivalRobar = 0;

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
        if(BotonesSettings.Rondas == 0 && BotonesSettings.RondasRival == 0)
        {
                  Debug.Log(BotonesSettings.Turnos);
        if(BotonesSettings.Turnos == 1 && cantidad == 1 )
        {
            cantidad++;
            EliminarInstancias();
            int Random1 = 0;
            int Random2 = 0;
            while(Random1 == Random2)
            {
             Random1 = Random.Range(0,9);
             Random2 = Random.Range(0,9);
            }
            hand.RemoveAt(Random1);
            hand.RemoveAt(Random2);
    for(int i = 0 ; i < 2 ;i++)
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
         else if(BotonesSettings.Turnos == 2 && cantidadRival == 1)
         {
               cantidadRival++;
               EliminarInstanciasRival();
                int Random1 = 0;
            int Random2 = 0;
            while(Random1 == Random2)
            {
             Random1 = Random.Range(0,9);
             Random2 = Random.Range(0,9);
            }
            hand.RemoveAt(Random1);
            hand.RemoveAt(Random2);
    for(int i = 0 ; i < 2 ;i++)
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
         
         else 
         {
            Debug.Log("Solo se puede barajear una sola vez , en la primera ronda , y primeros turnos de ambos  ");
         }
        }
 
      
    }
 #endregion
    #region Robar Dos Cartas
    public void Robar()
    {
      if(cantidadRobar == 0)
      {
        if(CardUnidad.Invocadas.Count >= 2)
      {
        cantidadRobar++;
       int carta1 = CardUnidad.Invocadas[0];
       int carta2 = CardUnidad.Invocadas[1];
       hand.RemoveAt(carta1);
       hand.RemoveAt(carta2);
        for(int i = 0 ; i < 2 ;i++)
    {
        GameObject temp = deck[Random.Range(0,deck.Count)];
        hand.Add(temp);
        deck.Remove(temp);
    }
    EliminarInstancias();
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
      else
      {
         Debug.Log("No hay espacio en la mano");
      }
      }
      else 
      {
        Debug.Log("Solo se puede robar dos cartas , una sola vez");
      }
     
    }

     public void RobarRival()
    {
      if(cantidadRivalRobar == 0)
      {
       if(CardUnidad.InvocadasRival.Count >= 2)
      {
        cantidadRivalRobar++;
       int carta1 = CardUnidad.InvocadasRival[0];
       int carta2 = CardUnidad.InvocadasRival[1];
       hand.RemoveAt(carta1);
       hand.RemoveAt(carta2);
        for(int i = 0 ; i < 2 ;i++)
    {
        GameObject temp = deck[Random.Range(0,deck.Count)];
        hand.Add(temp);
        deck.Remove(temp);
    }
    EliminarInstanciasRival();
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
      else
      {
         Debug.Log("No hay espacio en la mano");
      }
      }
     else 
     {
      Debug.Log("Solo se puede robar dos cartas , una sola vez");
     }
     
    }
    #endregion
    
    #region Eliminar Instancias
    public static void EliminarInstancias()
    {
      #region Campo Red
      GameObject card1 = GameObject.Find("Asedio1R(Clone)");
      GameObject card2 = GameObject.Find("Asedio2R(Clone)");
      GameObject card3 = GameObject.Find("Asedio3R(Clone)");
      GameObject card4 = GameObject.Find("Asedio4R(Clone)");
      GameObject card5 = GameObject.Find("Aumento1R(Clone)");
      GameObject card6 = GameObject.Find("Aumento2R(Clone)");
      GameObject card7 = GameObject.Find("Aumento3R(Clone)");
      GameObject card8 = GameObject.Find("Cuerpo1R(Clone)");
      GameObject card9 = GameObject.Find("Cuerpo2R(Clone)");
      GameObject card10 = GameObject.Find("Cuerpo3R(Clone)"); 
      GameObject card11 = GameObject.Find("Cuerpo4R(Clone)"); 
      GameObject card12 = GameObject.Find("Distancia1R(Clone)");
      GameObject card13 = GameObject.Find("Distancia2R(Clone)");
      GameObject card14 = GameObject.Find("Distancia3R(Clone)");
      GameObject card15 = GameObject.Find("Distancia4R(Clone)");
      GameObject card16 = GameObject.Find("ZafiroClimaR(Clone)");
      GameObject card17 = GameObject.Find("PrincipioClimaR (Clone)");
      GameObject card18 = GameObject.Find("GimnasioClimaR(Clone)");
      GameObject card19 = GameObject.Find("Silver1R(Clone)");
      GameObject card20 = GameObject.Find("Silver2R(Clone)");
      GameObject card21 = GameObject.Find("Silver3R(Clone)");
      GameObject card22 = GameObject.Find("LiderR(Clone)");
      GameObject card23 = GameObject.Find("OroR(Clone)");
      GameObject card24 = GameObject.Find("SenueloR(Clone)");
      GameObject card25 = GameObject.Find("DespejeR(Clone)");      
      if(card1 != null)
      {
        Destroy(card1);
      }
         if(card2 != null)
      {
        Destroy(card2);
      }
         if(card3 != null)
      {
        Destroy(card3);
      }
         if(card4 != null)
      {
        Destroy(card4);
      }
         if(card5 != null)
      {
        Destroy(card5);
      }
         if(card6 != null)
      {
        Destroy(card6);
      }
         if(card7 != null)
      {
        Destroy(card7);
      }
         if(card8 != null)
      {
        Destroy(card8);
      }
         if(card9 != null)
      {
        Destroy(card9);
      }
         if(card10 != null)
      {
        Destroy(card10);
      }
         if(card11 != null)
      {
        Destroy(card11);
      }
         if(card12 != null)
      {
        Destroy(card12);
      }
         if(card13 != null)
      {
        Destroy(card13);
      }
         if(card14 != null)
      {
        Destroy(card14);
      }
         if(card15 != null)
      {
        Destroy(card15);
      }
         if(card16 != null)
      {
        Destroy(card16);
      }
         if(card17 != null)
      {
        Destroy(card17);
      }
         if(card18 != null)
      {
        Destroy(card18);
      }
         if(card19 != null)
      {
        Destroy(card19);
      }
         if(card20 != null)
      {
        Destroy(card20);
      }
         if(card21 != null)
      {
        Destroy(card21);
      }
         if(card22 != null)
      {
        Destroy(card22);
      }
         if(card23 != null)
      {
        Destroy(card23);
      }
         if(card24 != null)
      {
        Destroy(card24);
      }
         if(card25 != null)
      {
        Destroy(card25);
      }
      #endregion
    }
    #endregion
    #region Eliminar Instancias Rival
    public void EliminarInstanciasRival()
    {
   GameObject card1 = GameObject.Find("MewSenuelo(Clone)");
   GameObject card2 = GameObject.Find("ColosalClima(Clone)");
   GameObject card3 = GameObject.Find("MundoInversoClima(Clone)");
   GameObject card4 = GameObject.Find("Isla Espuma(Clone)");
   GameObject card5 = GameObject.Find("Silver1(Clone)");
   GameObject card6 = GameObject.Find("Silver2(Clone)");
   GameObject card7 = GameObject.Find("Silver3(Clone)");
   GameObject card8 = GameObject.Find("Aumento1L(Clone)");
   GameObject card9 = GameObject.Find("Aumento2L(Clone)");
   GameObject card10 = GameObject.Find("Aumento3L(Clone)");
   GameObject card11 = GameObject.Find("LiderL(Clone)");
   GameObject card12 = GameObject.Find("OroL(Clone)");
   GameObject card13 = GameObject.Find("CresseliaAsedio2L(Clone)");
   GameObject card14 = GameObject.Find("DarkraiAsedioL(Clone)");
   GameObject card15 = GameObject.Find("KyogreAsedio3L(Clone)");
   GameObject card16 = GameObject.Find("DeoxysAsedio4(Clone)");
   GameObject card17 = GameObject.Find("XerneasCuerpoL(Clone)");
   GameObject card18 = GameObject.Find("GroudonCuerpo 1(Clone)");
   GameObject card19 = GameObject.Find("ZacianCuerpo1(Clone)");
   GameObject card20 = GameObject.Find("SolgaleoCuerpo4(Clone)");
   GameObject card21 = GameObject.Find("Distancia1Lugia(Clone)");
   GameObject card22 = GameObject.Find("Distancia1Lunala(Clone)");
   GameObject card23 = GameObject.Find("Distancia1Palkia(Clone)");
   GameObject card24 = GameObject.Find("Distancia1Dialga(Clone)");
   GameObject card25 = GameObject.Find("CaballeroDespeje(Clone)");
         if(card1 != null)
      {
        Destroy(card1);
      }
         if(card2 != null)
      {
        Destroy(card2);
      }
         if(card3 != null)
      {
        Destroy(card3);
      }
         if(card4 != null)
      {
        Destroy(card4);
      }
         if(card5 != null)
      {
        Destroy(card5);
      }
         if(card6 != null)
      {
        Destroy(card6);
      }
         if(card7 != null)
      {
        Destroy(card7);
      }
         if(card8 != null)
      {
        Destroy(card8);
      }
         if(card9 != null)
      {
        Destroy(card9);
      }
         if(card10 != null)
      {
        Destroy(card10);
      }
         if(card11 != null)
      {
        Destroy(card11);
      }
         if(card12 != null)
      {
        Destroy(card12);
      }
         if(card13 != null)
      {
        Destroy(card13);
      }
         if(card14 != null)
      {
        Destroy(card14);
      }
         if(card15 != null)
      {
        Destroy(card15);
      }
         if(card16 != null)
      {
        Destroy(card16);
      }
         if(card17 != null)
      {
        Destroy(card17);
      }
         if(card18 != null)
      {
        Destroy(card18);
      }
         if(card19 != null)
      {
        Destroy(card19);
      }
         if(card20 != null)
      {
        Destroy(card20);
      }
         if(card21 != null)
      {
        Destroy(card21);
      }
         if(card22 != null)
      {
        Destroy(card22);
      }
         if(card23 != null)
      {
        Destroy(card23);
      }
         if(card24 != null)
      {
        Destroy(card24);
      }
         if(card25 != null)
      {
        Destroy(card25);
      }
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
       
    }
}
