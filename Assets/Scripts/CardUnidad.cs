using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CardUnidad : MonoBehaviour 
{
   public string Name;
   public int Attack;
   public string Tipo;
private GameObject spriteGigante;
 private SpriteRenderer spriteRenderer;
 private string nametag = "Show Card";
 private GameObject panel;
 public static GameObject objectoInvocado;
 //Mascara boleana para posiciones
 private static bool [,] posicionescampo;
 private static bool [,] posicionescamporival;
  private static bool[,] posicionescartasmagicas;
 private static bool [,] posicionescartasmagicasrival;
 private static bool LeaderPos;
 private static bool LeaderRivalPos;
 //Mascara Boleeanas para verificar activacion del efecto
 private static bool [,] ActiveEfects;
 private static bool [,] ActiveEfectsRival;
 public static bool LeaderRivalEfect;

//Cartas clima
 public int doubleStat ;

 //Contadores
 public static int Contador;
public static int ContadorRival;

public Text ContadorFisicoP;
public Text ContadorFisicoR;

//Canvas
public Transform canvasTransform;

//Cementerio
public static List<GameObject> Cementary = new List<GameObject>();
//Invocaste?
public static bool Invocaste;
//Posiciones Invocadas
public static List<int> Invocadas = new List<int>();
public static List<int> InvocadasRival = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
      ActiveEfects = new bool[3,5];
      ActiveEfectsRival = new bool[3,5];
      posicionescampo = new bool[3,3];
      posicionescamporival = new bool[3,3];
      posicionescartasmagicas = new bool[3,2];
       posicionescartasmagicasrival = new bool[3,2];
        spriteGigante = GameObject.FindGameObjectWithTag(nametag);
        spriteRenderer = spriteGigante.GetComponent<SpriteRenderer>();
         spriteGigante.transform.localScale = Vector3.zero;
          panel = GameObject.FindGameObjectWithTag("Invocar");
          
            if(panel != null)
            {
              panel.transform.localScale = Vector3.zero;
             
              
            } 
    }

///<summary>
///Este metodo se utiliza para cuando pase el cursor del mouse por encima de una carta su sprite se muestre en escena
///</summary>
   void OnMouseEnter()
  {
    spriteGigante.transform.localScale = new Vector3(0.3f,0.3f,0);
    spriteRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
  }
  void OnMouseExit()
  {
     spriteGigante.transform.localScale = Vector3.zero;
  }
  
 
void OnMouseDown()
{
 if(panel != null)
  {
panel.transform.localScale = new Vector3(1f,1f,0);
 objectoInvocado = gameObject;
 Debug.Log(objectoInvocado);
  }
}
public void Invocar()
{
  Debug.Log(objectoInvocado.transform.position.x);
  Debug.Log(PositionMano());
  Debug.Log(PosicionRivalMano());
  if(Invocaste == false)
  {
    Invocaste = true;
    #region Canvas
       GameObject canvasObject = GameObject.FindGameObjectWithTag("Tablero");
        if (canvasObject != null)
        {
            Transform canvasTransform = canvasObject.transform;
             objectoInvocado.transform.SetParent(canvasTransform, false); 
            Debug.Log("Canvas encontrado");
        }
        else
        {
            Debug.LogError("Canvas no encontrado. Asigna el tag correcto al Canvas en la jerarquía.");
        } 
    objectoInvocado.transform.localScale = new Vector3(2f,2f,0);
 #endregion
Debug.Log(objectoInvocado.tag);


 #region Mi Campo
  #region AsedioRed
  if(objectoInvocado.tag == "AsedioR")
  {

     if(posicionescampo[2,0] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y  , 2f);
            posicionescampo[2,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfects[1,4] == true)
            {
             Contador += 600;
            }
            if(ActiveEfects[0,0] == true)
            {
               Contador -= 200;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador -= 500;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador += 800;
            }
            if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
            if(ActiveEfectsRival[2,1] == true)
            {
              Contador+= 100;
            }
         }
         else if(posicionescampo[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            Invocadas.Add(PositionMano());
            posicionescampo[2,1] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfects[1,4] == true)
            {
             Contador += 600;
            }
            if(ActiveEfects[0,0] == true)
            {
               Contador -= 200;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador -= 500;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador += 800;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
              if(ActiveEfectsRival[2,1] == true)
            {
              Contador+= 100;
            }
         }
         else if(posicionescampo[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            Invocadas.Add(PositionMano());
            posicionescampo[2,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfects[1,4] == true)
            {
             Contador += 600;
            }
            if(ActiveEfects[0,0] == true)
            {
               Contador -= 200;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador -= 500;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador += 800;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
              if(ActiveEfectsRival[2,1] == true)
            {
              Contador+= 100;
            }
         }
         else
         {
          Debug.Log("Todas las posiciones asedio estan ocupadas");
         }
  }
  #endregion
  #region DistanciaR
  else if(objectoInvocado.tag == "DistanciaR")
  {
    if(posicionescampo[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfects[0,4] == true)
            {
             Contador += 800;
            }
            if(ActiveEfects[0,0] == true)
            {
               Contador -= 200;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador += 300;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador -= 1000;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,1] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
              if(ActiveEfects[0,4] == true)
            {
             Contador += 800;
            }
             if(ActiveEfects[0,0] == true)
            {
               Contador -= 200;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador += 300;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador -= 1000;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
              if(ActiveEfects[0,4] == true)
            {
             Contador += 800;
            }
             if(ActiveEfects[0,0] == true)
            {
               Contador -= 200;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador += 300;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador -= 1000;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else
         {
          Debug.Log("Todas las posiciones distancia estan ocupadas");
         }
  }
  #endregion
  #region CuerpoRed
  else if(objectoInvocado.tag == "CuerpoR")
  {
         if(posicionescampo[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
              if(ActiveEfects[2,4] == true)
            {
             Contador += 300;
            }
             if(ActiveEfects[0,0] == true)
            {
               Contador += 400;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador -= 500;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador -= 1000;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,1] = true; 
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
              if(ActiveEfects[2,4] == true)
            {
             Contador += 300;
            }
              if(ActiveEfects[0,0] == true)
            {
               Contador += 400;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador -= 500;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador -= 1000;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
              if(ActiveEfects[2,4] == true)
            {
             Contador += 300;
            }
              if(ActiveEfects[0,0] == true)
            {
               Contador += 400;
            }
            if(ActiveEfects[1,0] == true)
            {
              Contador -= 500;
            }
            if(ActiveEfects[2,0] == true)
            {
               Contador -= 1000;
            }
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else
         {
          Debug.Log("Todas las posiciones cuerpo a cuerpo estan ocupadas");
         }
  }
  #endregion
  #region OroRed
  else if(objectoInvocado.tag == "OroR")
  {
    if(posicionescampo[2,0] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,1] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }


        else  if(posicionescampo[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,1] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
        else  if(posicionescampo[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,1] = true; 
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else
         {
            Debug.Log("Todas las posiciones estan ocupadas");
         }

  }
  #endregion
  #region SilverRed
  else if(objectoInvocado.tag == "SilverR")
  {
      if(posicionescampo[2,0] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,1] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }


        else  if(posicionescampo[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,1] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
        else  if(posicionescampo[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,0] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,1] = true; 
            Invocadas.Add(PositionMano());
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,2] = true;
            Invocadas.Add(PositionMano());
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
          else
         {
            Debug.Log("Todas las posiciones estan ocupadas");
         }

  }
  #endregion
  #region SenueloRed
  else if(objectoInvocado.tag == "SenueloR")
  {
    if(posicionescamporival[2,0] == false)
         {
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
       else  if(posicionescamporival[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,1] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,2] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,2] = true;
            Invocadas.Add(PositionMano());
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
             if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else
         {
            Debug.Log("No hay posiciones disponibles");
         }
  }
  #endregion
 #region Lider
else if(objectoInvocado.tag == "Lider" && LeaderPos == false)
{
   GameObject posx = GameObject.Find("CartaLider1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    LeaderPos = true;
    Invocadas.Add(PositionMano());
    Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
}
 #endregion
 #region Aumento
  else if(objectoInvocado.tag == "AumentoR")
 {
     GameObject posx = GameObject.Find("AumentoDistancia1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[0,0] = true;
    Invocadas.Add(PositionMano());
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
   
 }
 else if(objectoInvocado.tag == "AumentoRA")
 {
  GameObject posx = GameObject.Find("AumentoAsedio1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[1,0] = true;
    Invocadas.Add(PositionMano());
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
 }
 else if(objectoInvocado.tag == "AumentoRC")
 {
  GameObject posx = GameObject.Find("AumentoCuerpo1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[2,0] = true;
    Invocadas.Add(PositionMano());
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
 }
 #endregion
 #region Clima
   else if(objectoInvocado.tag == "ClimaR")
 {
   if(posicionescartasmagicas[0,1] == false)
   {
     GameObject posx = GameObject.Find("Clima1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[0,1] = true;
    Invocadas.Add(PositionMano());
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
   }
   else if(posicionescartasmagicas[1,1] == false)
   {
       GameObject posx = GameObject.Find("Clima2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[1,1] = true;
    Invocadas.Add(PositionMano());
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
   }
   else if(posicionescartasmagicas[2,1] == false)
   {
      GameObject posx = GameObject.Find("Clima3");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[2,1] = true;
    Invocadas.Add(PositionMano());
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
   }
   else
   {
    Debug.Log("Todos los espacios de cartas estan ocupadas");
   }
 }
 #endregion
  #endregion

#region Campo Rival
#region Asedio Rival
if(objectoInvocado.tag == "Asedio1")
  {

     if(posicionescamporival[2,0] == false)
         {
            InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[1,4] == true)
            {
               ContadorRival += 500;
            }
                if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival -= 700;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival -= 400;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival += 400;
            }
              if(ActiveEfectsRival[2,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[2,1] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[1,4] == true)
            {
               ContadorRival += 500;
            }
                 if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival -= 700;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival -= 400;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival += 400;
            }
               if(ActiveEfectsRival[2,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else if(posicionescamporival[2,2] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[1,4] == true)
            {
               ContadorRival += 500;
            }
                 if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival -= 700;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival -= 400;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival += 400;
            }
               if(ActiveEfectsRival[2,1] == true)
            {
              ContadorRival+= 100;
            }
         }
         else
         {
          Debug.Log("Todas las posiciones asedio estan ocupadas");
         }
  }
#endregion
#region Distancia Rival
else if(objectoInvocado.tag == "Distancia1")
  {
    if(posicionescamporival[1,0] == false)
         {
          Debug.Log(objectoInvocado.transform.position.x);
          Debug.Log(PosicionRivalMano());
          InvocadasRival.Add(PosicionRivalMano());
          
        
          
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[0,4] == true)
            {
               ContadorRival += 100;
            }
                 if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival -= 700;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival += 600;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival -= 200;
            }
         }
         else if(posicionescamporival[1,1] == false)
         {
            InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[0,4] == true)
            {
               ContadorRival += 100;
            }
                  if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival -= 700;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival += 600;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival -= 200;
            }
         }
         else if(posicionescamporival[1,2] == false)
         {
            InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[0,4] == true)
            {
               ContadorRival += 100;
            }
                  if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival -= 700;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival += 600;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival -= 200;
            }
         }
         else
         {
          Debug.Log("Todas las posiciones distancia estan ocupadas");
         }
  }
#endregion
#region Cuerpo Rival

  else if(objectoInvocado.tag == "Cuerpo1")
  {
         if(posicionescamporival[0,0] == false)
         {
            InvocadasRival.Add(PosicionRivalMano());
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[2,4] == true)
            {
               ContadorRival += 1000;
            }
                  if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival += 500;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival -= 400;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival -= 200;
            }
         }
         else if(posicionescamporival[0,1] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[2,4] == true)
            {
               ContadorRival += 1000;
            }
                  if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival += 500;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival -= 400;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival -= 200;
            }
         }
         else if(posicionescamporival[0,2] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Cuerpo2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            if(ActiveEfectsRival[2,4] == true)
            {
               ContadorRival += 1000;
            }
                  if(ActiveEfectsRival[0,0] == true)
            {
               ContadorRival += 500;
            }
            if(ActiveEfectsRival[1,0] == true)
            {
              ContadorRival -= 400;
            }
            if(ActiveEfectsRival[2,0] == true)
            {
               ContadorRival -= 200;
            }
         }
         else
         {
          Debug.Log("Todas las posiciones cuerpo a cuerpo estan ocupadas");
         }
  }
#endregion
#region  Oro Rival
else if(objectoInvocado.tag == "Oro1")
{
  if(posicionescamporival[2,0] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[2,1] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;  
         }
         else if(posicionescamporival[2,2] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
       else  if(posicionescamporival[1,0] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[1,1] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[1,2] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[0,0] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else if(posicionescamporival[0,1] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[0,2] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Cuerpo2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else
         {
            Debug.Log("No hay posiciones disponibles");
         }
   
}
#endregion
#region Silver Rival
else if(objectoInvocado.tag == "Silver1")
{
   if(posicionescamporival[2,0] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[2,1] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[2,2] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
       else  if(posicionescamporival[1,0] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[1,1] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else if(posicionescamporival[1,2] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[0,0] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else if(posicionescamporival[0,1] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else if(posicionescamporival[0,2] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Cuerpo2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else
         {
            Debug.Log("No hay posiciones disponibles");
         }
}
#endregion
#region Senuelo Rival
else if(objectoInvocado.tag == "Senuelo1")
{
  if(posicionescamporival[2,0] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[2,1] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[2,2] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
       else  if(posicionescamporival[1,0] == false)
         {
          InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            
         }
         else if(posicionescamporival[1,1] == false)
         {
           InvocadasRival.Add(PosicionRivalMano());
            GameObject posx = GameObject.Find("Distancia2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
           
         }
         else if(posicionescamporival[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            InvocadasRival.Add(PosicionRivalMano());
         }
         else if(posicionescamporival[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            InvocadasRival.Add(PosicionRivalMano());
         }
         else if(posicionescamporival[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            InvocadasRival.Add(PosicionRivalMano());
         }
         else if(posicionescamporival[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
            InvocadasRival.Add(PosicionRivalMano());
         }
         else
         {
            Debug.Log("No hay posiciones disponibles");
         }
}
#endregion
#region Lider Rival
else if(objectoInvocado.tag == "Lider2" && LeaderRivalPos == false)
{
  InvocadasRival.Add(PosicionRivalMano());
   GameObject posx = GameObject.Find("CartaLider2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    LeaderRivalPos = true;
    
}
#endregion
#region Aumento Rival
else if(objectoInvocado.tag == "AumentoR2")
 {
   InvocadasRival.Add(PosicionRivalMano());
    GameObject posx = GameObject.Find("AumentoDistancia2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[0,0] = true;
   
 }
 else if(objectoInvocado.tag == "AumentoRC2")
 {
  InvocadasRival.Add(PosicionRivalMano());
  GameObject posx = GameObject.Find("AumentoCuerpo2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[1,0] = true;
    
 }
 else if(objectoInvocado.tag == "AumentoRA2")
 {
  InvocadasRival.Add(PosicionRivalMano());
   GameObject posx = GameObject.Find("AumentoAsedio2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[2,0] = true;
    
 }
#endregion
#region Clima Rival
else if(objectoInvocado.tag == "ClimaL")
 {
   if(posicionescartasmagicasrival[0,1] == false)
   {
    InvocadasRival.Add(PosicionRivalMano());
     GameObject posx = GameObject.Find("Clima4");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[0,1] = true;
    
   }
   else if(posicionescartasmagicasrival[1,1] == false)
   {
    InvocadasRival.Add(PosicionRivalMano());
       GameObject posx = GameObject.Find("Clima5");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[1,1] = true;
    
   }
   else if(posicionescartasmagicasrival[2,1] == false)
   {
    InvocadasRival.Add(PosicionRivalMano());
      GameObject posx = GameObject.Find("Clima6");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[2,1] = true;
    
   }
   else
   {
    Debug.Log("Todos los espacios de cartas estan ocupadas");
   }
 }
#endregion
#endregion
  
  }
  else
  {
    Debug.Log("Solo se puede realizar una invocacion por turno");
  }
  
}
public void Efecto()
{
//Mi campo
#region  Aumentos Efecto Red
  if(objectoInvocado.GetComponent<CardUnidad>().Name == "Poder de Uno" && ActiveEfects[0,4] == false)
  {
   int conttemp = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         conttemp++;
      }
    }
    Debug.Log(conttemp);
    Contador += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ActiveEfects[0,4] = true;
  }
  else if(objectoInvocado.GetComponent<CardUnidad>().Name == "MegaEvolucion" && ActiveEfects[1,4] == false)
  {
   int conttemp = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         conttemp++;
      }
    }
    Debug.Log(conttemp);
    Contador += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
   ActiveEfects[1,4] = true;
  }
  else if(objectoInvocado.GetComponent<CardUnidad>().Name == "RockAlola" && ActiveEfects[2,4] == false)
  {
   int conttemp = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         conttemp++;
      }
    }
    Debug.Log(conttemp);
    
    Contador += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ActiveEfects[2,4] = true;
  }
  #endregion
#region  Clima Efecto Red
 else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Gimnasio" && ActiveEfects[0,0] == false)
 {
    int conttemp = 0;
    int contnegativo = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         conttemp++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         contnegativo++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         contnegativo++;
      }
    }
    Debug.Log(conttemp);
    Contador += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    Contador -= (objectoInvocado.GetComponent<CardUnidad>().doubleStat ) * contnegativo;
    ActiveEfects[0,0] = true;
 }

 else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Principio" && ActiveEfects[1,0] == false)
 {
    int conttemp = 0;
    int contnegativo = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         conttemp++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         contnegativo++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         contnegativo++;
      }
    }
    Debug.Log(conttemp);
    Contador += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    Contador -= (objectoInvocado.GetComponent<CardUnidad>().doubleStat ) * contnegativo;
    ActiveEfects[1,0] = true;
 }

  else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Zafiro" && ActiveEfects[2,0] == false)
 {
    int conttemp = 0;
    int contnegativo = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         conttemp++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         contnegativo++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         contnegativo++;
      }
    }
    Debug.Log(conttemp);
    Contador += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    Contador -= (objectoInvocado.GetComponent<CardUnidad>().doubleStat ) * contnegativo;
    ActiveEfects[2,0] = true;
 }

#endregion
#region Despeje 
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Amistad" ||objectoInvocado.GetComponent<CardUnidad>().Name == "Zoroak" )
{
   if(objectoInvocado.GetComponent<CardUnidad>().Name == "Amistad")
   {
    Cementary.Add(objectoInvocado);
    objectoInvocado.transform.position = new Vector3(200f,200f,200f);
   }
  
  if(posicionescartasmagicasrival[0,1] == true)
  {
    GameObject canvass = GameObject.Find("Tablero");
    
    if(canvass != null)
    {
      Transform cartaTransform = canvass.transform.Find("ColosalClima(Clone)");
      Transform cartaTransform2 = canvass.transform.Find("MundoInversoClima(Clone)");
      Transform cartaTransform3 = canvass.transform.Find("Isla Espuma(Clone)");
      if(cartaTransform != null)
      {
        GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[0,1] = false;
         if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
      
      }
      else if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,00f);
        cartaaeliminar.transform.SetParent(null);
         posicionescartasmagicasrival[0,1] = false; 
         if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
     
      }
      else if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         posicionescartasmagicasrival[0,1] = false;
             if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
        
      }
      else
      {
        Debug.Log("No hay cartas climas invocados");
      }
    }
  }
  else if(posicionescartasmagicasrival[1,1] == true)
  {
GameObject canvass = GameObject.Find("Tablero");
    if(canvass != null)
    {
      Transform cartaTransform = canvass.transform.Find("ColosalClima(Clone)");
      Transform cartaTransform2 = canvass.transform.Find("MundoInversoClima(Clone)");
      Transform cartaTransform3 = canvass.transform.Find("Isla Espuma(Clone)");
      if(cartaTransform != null)
      {
        GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[1,1] = false;
        if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
      }
      else if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[1,1] = false;
          if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
      }
      else if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[1,1] = false;
          if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
      }
      else
      {
        Debug.Log("No hay cartas climas invocados");
      }
    }
  }
  else if(posicionescartasmagicasrival[2,1] == true)
  {
    GameObject canvass = GameObject.Find("Tablero");
    if(canvass != null)
    {
      Transform cartaTransform = canvass.transform.Find("ColosalClima(Clone)");
      Transform cartaTransform2 = canvass.transform.Find("MundoInversoClima(Clone)");
      Transform cartaTransform3 = canvass.transform.Find("Isla Espuma(Clone)");
      if(cartaTransform != null)
      {
        GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[2,1] = false;
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
      }
      else if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[2,1] = false;
  if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
      }
      else if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[2,1] = false;
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
      }
      else
      {
        Debug.Log("No hay cartas climas invocados");
      }
    }
  }
  else
  {
   Debug.Log("No habia ninguna carta clima invocada");
  }
}
#endregion
#region Unidad
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Gyrados Rojo" && ActiveEfects[0,1] == false)
{
  int rondas = BotonesSettings.Rondas;
  int rondasrival = BotonesSettings.RondasRival;
  Contador+= rondas + rondasrival;
  ActiveEfects[0,1] = true;
}
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Blaziken" && ActiveEfects[1,1] == false)
{
  ActiveEfects[1,1] = true;
   int cantidadcementary = Cementary.Count;
   Contador += cantidadcementary;
}
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Pikachu" && ActiveEfects[2,1] == false)
{
  ActiveEfects[2,1] = true;
  string nombrelider = "LiderR(Clone)";
GameObject gameObject =   Cementary.Find(objecto => objecto.name == nombrelider);
Debug.Log(gameObject);
if(gameObject != null)
{
  GameObject posx = GameObject.Find("CartaLider1");
    Vector3 posy = posx.transform.position;
    gameObject.transform.position = new Vector3(posy.x , posy.y , 2f);
    LeaderPos = true;
    Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
     if(ActiveEfectsRival[0,1] == true)
            {
              ContadorRival+= 100;
            }
}
else
{
  Debug.Log("No se encontro a la carta lider en el cementerio");
}
}
#region Silver 
#endregion
#region Gold
#endregion


#endregion
//Campo Rival
#region Aumentos Efecto Legendarios
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Pajaros" && ActiveEfectsRival[0,4] == false)
  {
   int conttemp = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[1,i] == true)
      {
         conttemp++;
      }
    }
    Debug.Log(conttemp);
    ContadorRival += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ActiveEfectsRival[0,4] = true;
  }
  else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Eternal" && ActiveEfectsRival[1,4] == false)
  {
   int conttemp = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[2,i] == true)
      {
         conttemp++;
      }
    }
    Debug.Log(conttemp);
    ContadorRival += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
   ActiveEfectsRival[1,4] = true;
  }
  else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Invocacion" && ActiveEfectsRival[2,4] == false)
  {
   int conttemp = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[0,i] == true)
      {
         conttemp++;
      }
    }
    Debug.Log(conttemp);
    
    ContadorRival += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ActiveEfectsRival[2,4] = true;
  }
#endregion
#region Clima Efecto Legendarios
 else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Colosal" && ActiveEfectsRival[1,0] == false)
 {
    int conttemp = 0;
    int contnegativo = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[1,i] == true)
      {
         conttemp++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[0,i] == true)
      {
         contnegativo++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[2,i] == true)
      {
         contnegativo++;
      }
    }
    Debug.Log(conttemp);
    ContadorRival += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ContadorRival -= (objectoInvocado.GetComponent<CardUnidad>().doubleStat ) * contnegativo;
    ActiveEfectsRival[1,0] = true;
 }
 else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Isla Espuma" && ActiveEfectsRival[0,0] == false)
 {
    int conttemp = 0;
    int contnegativo = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[0,i] == true)
      {
         conttemp++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[1,i] == true)
      {
         contnegativo++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[2,i] == true)
      {
         contnegativo++;
      }
    }
    Debug.Log(conttemp);
    ContadorRival += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ContadorRival -= (objectoInvocado.GetComponent<CardUnidad>().doubleStat ) * contnegativo;
    ActiveEfectsRival[0,0] = true;
 }
  else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Mundo Inverso" && ActiveEfectsRival[2,0] == false)
 {
    int conttemp = 0;
    int contnegativo = 0;
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[2,i] == true)
      {
         conttemp++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[0,i] == true)
      {
         contnegativo++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescamporival[1,i] == true)
      {
         contnegativo++;
      }
    }
    Debug.Log(conttemp);
    ContadorRival += (objectoInvocado.GetComponent<CardUnidad>().Attack ) * conttemp;
    ContadorRival -= (objectoInvocado.GetComponent<CardUnidad>().doubleStat ) * contnegativo;
    ActiveEfectsRival[2,0] = true;
 }
#endregion
#region Despeje Rival
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Caballero")
{
   Cementary.Add(objectoInvocado);
   objectoInvocado.transform.position = new Vector3(200f,200f,200f);
   //Condiciones 
   int cantidadtemporal = 0;
   int cantidadtemporal2 = 0;
   for(int i = 0 ; i < 3 ; i++)
   {
      if(posicionescartasmagicas[i,1] == true )
      {
         cantidadtemporal++;
      }
   }
   for(int i = 0 ; i < 3 ; i++)
   {
    if(posicionescartasmagicasrival[i,1] == true)
     {
       cantidadtemporal2++;
     }
   }
   if(cantidadtemporal >= 2 && cantidadtemporal2 >= 1)
   {
     GameObject canvass = GameObject.Find("Tablero");
     if(canvass != null)
     {
            Transform cartaTransform = canvass.transform.Find("ColosalClima(Clone)");
     Transform cartaTransform2 = canvass.transform.Find("MundoInversoClima(Clone)");
     Transform cartaTransform3 = canvass.transform.Find("Isla Espuma(Clone)");
     Transform cartaTransform4 = canvass.transform.Find("ZafiroClimaR(Clone)");
     Transform cartaTransform5 = canvass.transform.Find("PrincipioClimaR (Clone)");
     Transform cartaTransform6 = canvass.transform.Find("GimnasioClimaR(Clone)");
     if(cartaTransform4 != null && cartaTransform5 != null)
     {
       GameObject cartaaeliminate = cartaTransform4.gameObject;
        Cementary.Add(cartaaeliminate);
        cartaTransform4.position = new Vector3(200f,200f,200f);
        cartaaeliminate.transform.SetParent(null);
        GameObject cartaaeliminate2 = cartaTransform5.gameObject;
        Cementary.Add(cartaaeliminate2);
        cartaTransform5.position = new Vector3(200f,200f,200f);
        cartaaeliminate2.transform.SetParent(null);
        //Zafiro
       if(ActiveEfects[2,0] == true)
       {
        int asediooocard = 0;
        int cuerpoacuerpocard = 0;
        int distanciacard = 0; 
        ActiveEfects[2,0] = false;
      for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         asediooocard++;
      }
    }
     for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         cuerpoacuerpocard++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         distanciacard++;
      }
    }
    Contador -= (asediooocard * 800);
    Contador += (cuerpoacuerpocard *1000);
    Contador += (distanciacard * 1000);
       }
       //Principio
       if(ActiveEfects[1,0] == true)
       {
           int asediooocard = 0;
        int cuerpoacuerpocard = 0;
        int distanciacard = 0; 
        ActiveEfects[2,0] = false;
      for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         asediooocard++;
      }
    }
     for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         cuerpoacuerpocard++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         distanciacard++;
      }
    }
    Contador += (asediooocard * 500);
    Contador += (cuerpoacuerpocard * 500);
    Contador -= (distanciacard * 300);
       }

       if(posicionescartasmagicas[0,1] == true && posicionescartasmagicas[1,1] == true)
       {
        posicionescartasmagicas[0,1] = false;
        posicionescartasmagicas[1,1] = false; 
         if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
       else if(posicionescartasmagicas[0,1] == true && posicionescartasmagicas[2,1] == true)
       {
        posicionescartasmagicas[0,1] = false;
        posicionescartasmagicas[2,1] = false;
             if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
       else if(posicionescartasmagicas[1,1] == true && posicionescartasmagicas[2,1] == true)
       {
         posicionescartasmagicas[1,1] = false;
         posicionescartasmagicas[2,1] = false;
              if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
     
     }
     else if(cartaTransform4 != null && cartaTransform6 != null)
     {
      GameObject cartaaeliminate = cartaTransform4.gameObject;
        Cementary.Add(cartaaeliminate);
        cartaTransform4.position = new Vector3(200f,200f,200f);
        cartaaeliminate.transform.SetParent(null);
        GameObject cartaaeliminate2 = cartaTransform6.gameObject;
        Cementary.Add(cartaaeliminate2);
        cartaTransform6.position = new Vector3(200f,200f,200f);
        cartaaeliminate2.transform.SetParent(null);
        //Zafiro
          if(ActiveEfects[2,0] == true)
       {
        int asediooocard = 0;
        int cuerpoacuerpocard = 0;
        int distanciacard = 0; 
        ActiveEfects[2,0] = false;
      for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         asediooocard++;
      }
    }
     for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         cuerpoacuerpocard++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         distanciacard++;
      }
    }
    Contador -= (asediooocard * 800);
    Contador += (cuerpoacuerpocard *1000);
    Contador += (distanciacard * 1000);
       }
       //Gimnasio
         if(ActiveEfects[0,0] == true)
         {
          int asediooocard = 0;
        int cuerpoacuerpocard = 0;
        int distanciacard = 0; 
        ActiveEfects[2,0] = false;
      for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         asediooocard++;
      }
    }
     for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         cuerpoacuerpocard++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         distanciacard++;
      }
    }
    Contador += (asediooocard * 200);
    Contador -= (cuerpoacuerpocard *400);
    Contador += (distanciacard * 200);
         }

              if(posicionescartasmagicas[0,1] == true && posicionescartasmagicas[1,1] == true)
       {
        posicionescartasmagicas[0,1] = false;
        posicionescartasmagicas[1,1] = false; 
         if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
       else if(posicionescartasmagicas[0,1] == true && posicionescartasmagicas[2,1] == true)
       {
        posicionescartasmagicas[0,1] = false;
        posicionescartasmagicas[2,1] = false;
             if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
       else if(posicionescartasmagicas[1,1] == true && posicionescartasmagicas[2,1] == true)
       {
         posicionescartasmagicas[1,1] = false;
         posicionescartasmagicas[2,1] = false;
              if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
     
     }
     else if(cartaTransform5 != null && cartaTransform6 != null)
     {
      GameObject cartaaeliminate = cartaTransform6.gameObject;
        Cementary.Add(cartaaeliminate);
        cartaTransform6.position = new Vector3(200f,200f,200f);
        cartaaeliminate.transform.SetParent(null);
        GameObject cartaaeliminate2 = cartaTransform5.gameObject;
        Cementary.Add(cartaaeliminate2);
        cartaTransform5.position = new Vector3(200f,200f,200f);
        cartaaeliminate2.transform.SetParent(null);
            //Principio
       if(ActiveEfects[1,0] == true)
       {
           int asediooocard = 0;
        int cuerpoacuerpocard = 0;
        int distanciacard = 0; 
        ActiveEfects[2,0] = false;
      for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         asediooocard++;
      }
    }
     for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         cuerpoacuerpocard++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         distanciacard++;
      }
    }
    Contador += (asediooocard * 500);
    Contador += (cuerpoacuerpocard * 500);
    Contador -= (distanciacard * 300);
       }
          //Gimnasio
         if(ActiveEfects[0,0] == true)
         {
          int asediooocard = 0;
        int cuerpoacuerpocard = 0;
        int distanciacard = 0; 
        ActiveEfects[2,0] = false;
      for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[2,i] == true)
      {
         asediooocard++;
      }
    }
     for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[0,i] == true)
      {
         cuerpoacuerpocard++;
      }
    }
    for(int i = 0 ; i < 3 ; i++)
    {
      if(posicionescampo[1,i] == true)
      {
         distanciacard++;
      }
    }
    Contador += (asediooocard * 200);
    Contador -= (cuerpoacuerpocard *400);
    Contador += (distanciacard * 200);
         }

              if(posicionescartasmagicas[0,1] == true && posicionescartasmagicas[1,1] == true)
       {
        posicionescartasmagicas[0,1] = false;
        posicionescartasmagicas[1,1] = false; 
         if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
       else if(posicionescartasmagicas[0,1] == true && posicionescartasmagicas[2,1] == true)
       {
        posicionescartasmagicas[0,1] = false;
        posicionescartasmagicas[2,1] = false;
             if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
       else if(posicionescartasmagicas[1,1] == true && posicionescartasmagicas[2,1] == true)
       {
         posicionescartasmagicas[1,1] = false;
         posicionescartasmagicas[2,1] = false;
              if(posicionescartasmagicasrival[0,1] == true)
         {
             posicionescartasmagicasrival[0,1] = false;
             if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
         else if(posicionescartasmagicasrival[1,1] == true)
         {
            posicionescartasmagicasrival[1,1] = false;
                       if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
  
         }
         else if(posicionescartasmagicasrival[2,1] == true)
         {
           posicionescamporival[2,1] = false;
                      if(cartaTransform != null)
             {
               GameObject cartaaeliminar = cartaTransform.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
       if(ActiveEfectsRival[1,0] == true)
         {
            ActiveEfectsRival[1,0] = false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival-= (contador1 * 600);
        ContadorRival+= (contador2 * 400);
        ContadorRival+= (contador3 * 400);
         }
             }
             else if(cartaTransform2 != null)
             {
         GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        if(ActiveEfectsRival[2,0] == true)
         {
            ActiveEfectsRival[2,0] =false;
             int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 200);
        ContadorRival+= (contador2 * 200);
        ContadorRival-= (contador3 * 400);
         }
             }
             else if(cartaTransform3 != null)
             {
                 GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         if(ActiveEfectsRival[0,0] == true)
             {
               ActiveEfectsRival[0,0] = false;
                int contador1 = 0;
       int contador2 = 0;
       int contador3 = 0;
        for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[1,i] == true)
         {
            contador1++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[0,i] == true)
         {
            contador2++;
         }
        }
          for(int i = 0 ; i < 3 ; i++)
        {
         if(posicionescamporival[2,i] == true)
         {
            contador3++;
         }
        }
        ContadorRival+= (contador1 * 700);
        ContadorRival-= (contador2 * 500);
        ContadorRival+= (contador3 * 700);
             }
             }
       
         }
       
       }
     
     }


     }
   }
   else
   {
      Debug.Log("No cumples las condiciones para activar el efecto");
   }
  
}
#endregion
#region Unidad Rival
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Xerneas" && ActiveEfectsRival[0,1] == false)
{
  ActiveEfectsRival[0,1] = true;
  int temp = 0;
  for(int i = 0 ; i < posicionescampo.GetLength(0) ; i++)
  {
    for(int j = 0 ; j< posicionescampo.GetLength(1) ; j++)
    {
       if(posicionescampo[i,j] == true)
       {
       temp++;
       }
    }
  }
  for(int i = 0 ; i < posicionescartasmagicas.GetLength(0) ; i++)
  {
    for(int j = 0 ; j < posicionescartasmagicas.GetLength(1) ; j++)
    {
      if(posicionescartasmagicas[i,j] == true)
      {
        temp++;
      }
    }
  }
  ContadorRival+= (temp * 100);
}
#endregion
#region  Silver Rival
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Rayquaza" && ActiveEfectsRival[2,1] == false)
{
  ActiveEfectsRival[2,1] = true;
  int temp1 = 0;
  int temp2 = 0;
  for(int i = 0 ; i < 3 ; i++)
  {
    if(posicionescampo[2,i] == true)
    {
      temp1++;
    }
  }
  for(int i = 0 ; i < 3 ; i++)
  {
    if(posicionescamporival[2,i] == true)
    {
      temp2++;
    }
  }
  Contador += (temp1 * 100);
  ContadorRival += (temp2 * 100);

}
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Hoopa" && ActiveEfectsRival[0,2] == false)
{
  ActiveEfectsRival[0,2] = true;
  string nombrelider = "LiderL(Clone)";
GameObject gameObject =   Cementary.Find(objecto => objecto.name == nombrelider);
Debug.Log(gameObject);
if(gameObject != null)
{
 GameObject posx = GameObject.Find("CartaLider2");
    Vector3 posy = posx.transform.position;
    gameObject.transform.position = new Vector3(posy.x , posy.y , 2f);
    LeaderRivalPos = true;
}
else
{
  Debug.Log("No se encontro a la carta lider en el cementerio"); 
}
}
#endregion
#region Gold Rival
#endregion
#region Leader Rival
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Arceus" && LeaderRivalEfect == false)
{
 LeaderRivalEfect = true;
}
#endregion
}


#region Cambios de Turnos
public static void ReiniciarPuntaje(int puntaje)
{
 Contador = puntaje;
}
public static void ReiniciarPuntajeRival(int puntaje)
{
   ContadorRival = puntaje;
}
#endregion


#region Vaciar Campo
///<summary>
///Este metodo se utiliza para ubicar en el cementerio despues de cada ronda todas las cartas sobre el campo
///</summary>
public static void VaciarCampo()
{
   ActiveEfects = new bool[3,5];
   ActiveEfectsRival = new bool[3,5];
   posicionescampo = new bool[3,3];
   posicionescamporival = new bool[3,3];
   posicionescartasmagicas = new bool[3,2];
   posicionescartasmagicasrival = new bool[3,2];
   LeaderPos = false;
   LeaderRivalPos = false;
   LeaderRivalEfect = false;
   GameObject canvass = GameObject.Find("Tablero");
   #region Mi campo
   Transform cartaTransform1 = canvass.transform.Find("Asedio1R(Clone)");
   Transform cartaTransform2 = canvass.transform.Find("Asedio2R(Clone)");
   Transform cartaTransform3 = canvass.transform.Find("Asedio3R(Clone)");
   Transform cartaTransform4 = canvass.transform.Find("Asedio4R(Clone)");
   Transform cartaTransform5 = canvass.transform.Find("Aumento1R(Clone)");
   Transform cartaTransform6 = canvass.transform.Find("Aumento2R(Clone)");
   Transform cartaTransform7 = canvass.transform.Find("Aumento3R(Clone)");
   Transform cartaTransform8 = canvass.transform.Find("Cuerpo1R(Clone)");
   Transform cartaTransform9 = canvass.transform.Find("Cuerpo2R(Clone)");
   Transform cartaTransform10 = canvass.transform.Find("Cuerpo3R(Clone)"); 
   Transform cartaTransform11 = canvass.transform.Find("Cuerpo4R(Clone)");                                                                            
   Transform cartaTransform12 = canvass.transform.Find("Distancia1R(Clone)");
   Transform cartaTransform13 = canvass.transform.Find("Distancia2R(Clone)");
   Transform cartaTransform14 = canvass.transform.Find("Distancia3R(Clone)");
   Transform cartaTransform15 = canvass.transform.Find("Distancia4R(Clone)");
   Transform cartaTransform16 = canvass.transform.Find("ZafiroClimaR(Clone)");
   Transform cartaTransform17 = canvass.transform.Find("PrincipioClimaR (Clone)");
   Transform cartaTransform18 = canvass.transform.Find("GimnasioClimaR(Clone)");
   Transform cartaTransform19 = canvass.transform.Find("Silver1R(Clone)");
   Transform cartaTransform20 = canvass.transform.Find("Silver2R(Clone)");
   Transform cartaTransform21 = canvass.transform.Find("Silver3R(Clone)");
   Transform cartaTransform22 = canvass.transform.Find("LiderR(Clone)");
   Transform cartaTransform23 = canvass.transform.Find("OroR(Clone)");
   Transform cartaTransform24 = canvass.transform.Find("SenueloR(Clone)");
    if(cartaTransform1 != null)
      {
        GameObject cartaaeliminar = cartaTransform1.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform1.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform4 != null)
      {
        GameObject cartaaeliminar = cartaTransform4.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform4.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform5 != null)
      {
        GameObject cartaaeliminar = cartaTransform5.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform5.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform6 != null)
      {
        GameObject cartaaeliminar = cartaTransform6.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform6.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform7 != null)
      {
        GameObject cartaaeliminar = cartaTransform7.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform7.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform8 != null)
      {
        GameObject cartaaeliminar = cartaTransform8.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform8.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform9 != null)
      {
        GameObject cartaaeliminar = cartaTransform9.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform9.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform10 != null)
      {
        GameObject cartaaeliminar = cartaTransform10.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform10.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform11 != null)
      {
        GameObject cartaaeliminar = cartaTransform11.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform11.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform12 != null)
      {
        GameObject cartaaeliminar = cartaTransform12.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform12.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform13 != null)
      {
        GameObject cartaaeliminar = cartaTransform13.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform13.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform14 != null)
      {
        GameObject cartaaeliminar = cartaTransform14.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform14.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform15 != null)
      {
        GameObject cartaaeliminar = cartaTransform15.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform15.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform16 != null)
      {
        GameObject cartaaeliminar = cartaTransform16.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform16.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform17 != null)
      {
        GameObject cartaaeliminar = cartaTransform17.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform17.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform18 != null)
      {
        GameObject cartaaeliminar = cartaTransform18.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform18.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform19 != null)
      {
        GameObject cartaaeliminar = cartaTransform19.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform19.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform20 != null)
      {
        GameObject cartaaeliminar = cartaTransform20.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform20.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform21 != null)
      {
        GameObject cartaaeliminar = cartaTransform21.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform21.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform22 != null)
      {
        GameObject cartaaeliminar = cartaTransform22.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform22.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform23 != null)
      {
        GameObject cartaaeliminar = cartaTransform23.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform23.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform24 != null)
      {
        GameObject cartaaeliminar = cartaTransform24.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform24.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
   #endregion
   #region Rival
   Transform cartaTransform25 = canvass.transform.Find("MewSenuelo(Clone)");
   Transform cartaTransform26 = canvass.transform.Find("ColosalClima(Clone)");
   Transform cartaTransform27 = canvass.transform.Find("MundoInversoClima(Clone)");
   Transform cartaTransform28 = canvass.transform.Find("Isla Espuma(Clone)");
   Transform cartaTransform29 = canvass.transform.Find("Silver1(Clone)");
   Transform cartaTransform30 = canvass.transform.Find("Silver2(Clone)");
   Transform cartaTransform31 = canvass.transform.Find("Silver3(Clone)");
   Transform cartaTransform32 = canvass.transform.Find("Aumento1L(Clone)");
   Transform cartaTransform33 = canvass.transform.Find("Aumento2L(Clone)");
   Transform cartaTransform34 = canvass.transform.Find("Aumento3L(Clone)");
   Transform cartaTransform35 = canvass.transform.Find("LiderL(Clone)");
   Transform cartaTransform36 = canvass.transform.Find("OroL(Clone)");
   Transform cartaTransform37 = canvass.transform.Find("CresseliaAsedio2L(Clone)");
   Transform cartaTransform38 = canvass.transform.Find("DarkraiAsedioL(Clone)");
   Transform cartaTransform39 = canvass.transform.Find("KyogreAsedio3L(Clone)");
   Transform cartaTransform40 = canvass.transform.Find("DeoxysAsedio4(Clone)");
   Transform cartaTransform41 = canvass.transform.Find("XerneasCuerpoL(Clone)");
   Transform cartaTransform42 = canvass.transform.Find("GroudonCuerpo 1(Clone)");
   Transform cartaTransform43 = canvass.transform.Find("ZacianCuerpo1(Clone)");
   Transform cartaTransform44 = canvass.transform.Find("SolgaleoCuerpo4(Clone)");
   Transform cartaTransform45 = canvass.transform.Find("Distancia1Lugia(Clone)");
   Transform cartaTransform46 = canvass.transform.Find("Distancia1Lunala(Clone)");
   Transform cartaTransform47 = canvass.transform.Find("Distancia1Palkia(Clone)");
   Transform cartaTransform48 = canvass.transform.Find("Distancia1Dialga(Clone)");
     if(cartaTransform25 != null)
      {
        GameObject cartaaeliminar = cartaTransform25.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform25.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform26 != null)
      {
        GameObject cartaaeliminar = cartaTransform26.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform26.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform27 != null)
      {
        GameObject cartaaeliminar = cartaTransform27.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform27.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform28 != null)
      {
        GameObject cartaaeliminar = cartaTransform28.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform28.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform29 != null)
      {
        GameObject cartaaeliminar = cartaTransform29.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform29.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform30 != null)
      {
        GameObject cartaaeliminar = cartaTransform30.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform30.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform31 != null)
      {
        GameObject cartaaeliminar = cartaTransform31.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform31.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform32 != null)
      {
        GameObject cartaaeliminar = cartaTransform32.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform32.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform33 != null)
      {
        GameObject cartaaeliminar = cartaTransform33.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform33.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
      if(cartaTransform34 != null)
      {
        GameObject cartaaeliminar = cartaTransform34.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform34.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform35 != null)
      {
        GameObject cartaaeliminar = cartaTransform35.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform35.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform36 != null)
      {
        GameObject cartaaeliminar = cartaTransform36.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform36.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform37 != null)
      {
        GameObject cartaaeliminar = cartaTransform37.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform37.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform38 != null)
      {
        GameObject cartaaeliminar = cartaTransform38.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform38.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform39 != null)
      {
        GameObject cartaaeliminar = cartaTransform39.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform39.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform40 != null)
      {
        GameObject cartaaeliminar = cartaTransform40.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform40.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform41 != null)
      {
        GameObject cartaaeliminar = cartaTransform41.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform41.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform42 != null)
      {
        GameObject cartaaeliminar = cartaTransform42.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform42.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform43 != null)
      {
        GameObject cartaaeliminar = cartaTransform43.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform43.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform44 != null)
      {
        GameObject cartaaeliminar = cartaTransform44.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform44.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform45 != null)
      {
        GameObject cartaaeliminar = cartaTransform45.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform45.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform46 != null)
      {
        GameObject cartaaeliminar = cartaTransform46.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform46.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform47 != null)
      {
        GameObject cartaaeliminar = cartaTransform47.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform47.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
        if(cartaTransform48 != null)
      {
        GameObject cartaaeliminar = cartaTransform48.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform48.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
      }
   #endregion
}
#endregion



   void Update()
   {
     
      if(ContadorFisicoP != null)
      {
         
         ContadorFisicoP.text = Contador.ToString();
      }
      if(ContadorFisicoR != null)
      {
         ContadorFisicoR.text = ContadorRival.ToString();
      }
     
   }  

  public static int PositionMano()
  {
    if(objectoInvocado.transform.position.x == -4f)
    {
     return 0;
    }
    else if(objectoInvocado.transform.position.x == -3f)
    {
     return 1;
    }
    else if(objectoInvocado.transform.position.x == -2f)
    {
      return 2;
    }
    else if(objectoInvocado.transform.position.x == -1f)
    {
      return 3;
    }
      else if(objectoInvocado.transform.position.x == 0f)
    {
      return 4;
    }
      else if(objectoInvocado.transform.position.x == 1f)
    {
      return 5;
    }
      else if(objectoInvocado.transform.position.x == 2f)
    {
      return 6;
    }
      else if(objectoInvocado.transform.position.x == 3f)
    {
      return 7;
    }
      else if(objectoInvocado.transform.position.x == 4f)
    {
      return 8;
    }
    else 
    {
      return 9;
    }
  }
  public static int PosicionRivalMano()
  {
    if(objectoInvocado.transform.position.x == 3.624875f)
    {
         return 0;
    }
    else if(objectoInvocado.transform.position.x == -0.05461908f)
    {
       return 1;
    }
     else if(objectoInvocado.transform.position.x == -0.03380742)
    {
       return 2;
    }
     else if(objectoInvocado.transform.position.x == -0.01299577f)
    {
       return 3;
    }
     else if(objectoInvocado.transform.position.x == 0.004403976f)
    {
       return 4;
    }
     else if(objectoInvocado.transform.position.x == 0.02862754)
    {
       return 5;
    }
      else if(objectoInvocado.transform.position.x == 0.0494392f)
    {
       return 6;
    }
      else if(objectoInvocado.transform.position.x == 0.07025085f)
    {
       return 7;
    }
      else if(objectoInvocado.transform.position.x == 0.0910625f)
    {
       return 8;
    }
    else
    {
      return 9;
    }
  }

}
