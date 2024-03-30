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
 private static GameObject objectoInvocado;
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
List<GameObject> Cementary = new List<GameObject>();


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

            //Canvas
        
  

    }
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
  
#region Mi Campo
//Canvas
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
 
  Debug.Log(objectoInvocado.tag);
 
  #region AsedioRed
  if(objectoInvocado.tag == "AsedioR")
  {

     if(posicionescampo[2,0] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y  , posy.z);
            posicionescampo[2,0] = true;
             
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
         }
         else if(posicionescampo[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , posy.z);
            
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
         }
         else if(posicionescampo[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , posy.z);
            
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
         }
         else if(posicionescampo[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,1] = true;
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
         }
         else if(posicionescampo[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,2] = true;
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
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,1] = true; 
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
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,2] = true;
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
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,1] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }


        else  if(posicionescampo[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,0] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,1] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
        else  if(posicionescampo[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,0] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,1] = true; 
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
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
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,1] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[2,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }


        else  if(posicionescampo[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,0] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[1,1] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,1] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[1,2] == false)
         {
            GameObject posx = GameObject.Find("Distancia1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[1,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
        else  if(posicionescampo[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,0] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,1] = true; 
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescampo[0,2] = true;
            Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
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
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
       else  if(posicionescamporival[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[1,1] == false)
         {
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
         }
         else if(posicionescamporival[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,2] == false)
         {
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
 #region Lider
else if(objectoInvocado.tag == "Lider" && LeaderPos == false)
{
   GameObject posx = GameObject.Find("CartaLider1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    LeaderPos = true;
    Contador += objectoInvocado.GetComponent<CardUnidad>().Attack;
}
 #endregion
 #region Aumento
  else if(objectoInvocado.tag == "AumentoR")
 {
     GameObject posx = GameObject.Find("AumentoDistancia1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[0,0] = true;
   
 }
 else if(objectoInvocado.tag == "AumentoRA")
 {
  GameObject posx = GameObject.Find("AumentoAsedio1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[1,0] = true;
 }
 else if(objectoInvocado.tag == "AumentoRC")
 {
  GameObject posx = GameObject.Find("AumentoCuerpo1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[2,0] = true;
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
   }
   else if(posicionescartasmagicas[1,1] == false)
   {
       GameObject posx = GameObject.Find("Clima2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[1,1] = true;
   }
   else if(posicionescartasmagicas[2,1] == false)
   {
      GameObject posx = GameObject.Find("Clima3");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicas[2,1] = true;
   }
   else
   {
    Debug.Log("Todos los espacios de cartas estan ocupadas");
   }
 }
 #endregion
  #endregion

//Rival
#region Campo Rival
#region Asedio Rival
if(objectoInvocado.tag == "Asedio1")
  {

     if(posicionescamporival[2,0] == false)
         {
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
         }
         else if(posicionescamporival[2,1] == false)
         {
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
         }
         else if(posicionescamporival[2,2] == false)
         {
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
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
       else  if(posicionescamporival[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[1,1] == false)
         {
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
         }
         else if(posicionescamporival[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,2] == false)
         {
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
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
       else  if(posicionescamporival[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[1,1] == false)
         {
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
         }
         else if(posicionescamporival[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,2] == false)
         {
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
            GameObject posx = GameObject.Find("Asedio2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,1] == false)
         {
           GameObject posx = GameObject.Find("Asedio2Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,1] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[2,2] == false)
         {
            GameObject posx = GameObject.Find("Asedio2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[2,2] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
       else  if(posicionescamporival[1,0] == false)
         {
            GameObject posx = GameObject.Find("Distancia2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[1,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[1,1] == false)
         {
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
         }
         else if(posicionescamporival[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo2Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,0] = true;
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo2Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
            posicionescamporival[0,1] = true; 
            ContadorRival += objectoInvocado.GetComponent<CardUnidad>().Attack;
         }
         else if(posicionescamporival[0,2] == false)
         {
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
#region Lider Rival
else if(objectoInvocado.tag == "Lider2" && LeaderRivalPos == false)
{
   GameObject posx = GameObject.Find("CartaLider2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    LeaderRivalPos = true;
}
#endregion
#region Aumento Rival
else if(objectoInvocado.tag == "AumentoR2")
 {
    GameObject posx = GameObject.Find("AumentoDistancia2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[0,0] = true;
 }
 else if(objectoInvocado.tag == "AumentoRC2")
 {
  GameObject posx = GameObject.Find("AumentoCuerpo2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[1,0] = true;
 }
 else if(objectoInvocado.tag == "AumentoRA2")
 {
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
     GameObject posx = GameObject.Find("Clima4");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[0,1] = true;
   }
   else if(posicionescartasmagicasrival[1,1] == false)
   {
       GameObject posx = GameObject.Find("Clima5");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[1,1] = true;
   }
   else if(posicionescartasmagicasrival[2,1] == false)
   {
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
else if(objectoInvocado.GetComponent<CardUnidad>().Name == "Amistad")
{
   Cementary.Add(objectoInvocado);
   objectoInvocado.transform.position = new Vector3(200f,200f,200f);
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
      }
      else if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,00f);
        cartaaeliminar.transform.SetParent(null);
         posicionescartasmagicasrival[0,1] = false;
      }
      else if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
         posicionescartasmagicasrival[0,1] = false;
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
      }
      else if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[1,1] = false;
      }
      else if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[1,1] = false;
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
      }
      else if(cartaTransform2 != null)
      {
        GameObject cartaaeliminar = cartaTransform2.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform2.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[2,1] = false;
      }
      else if(cartaTransform3 != null)
      {
        GameObject cartaaeliminar = cartaTransform3.gameObject;
        Cementary.Add(cartaaeliminar);
        cartaTransform3.position = new Vector3(200f,200f,200f);
        cartaaeliminar.transform.SetParent(null);
        posicionescartasmagicasrival[2,1] = false;
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
    if(posicionescamporival[i,1] == true)
     {
       cantidadtemporal2++;
     }
   }
   if(cantidadtemporal >= 2 && cantidadtemporal2 >= 1)
   {
     GameObject canvass = GameObject.Find("Tablero");
     Transform cartaTransform = canvass.transform.Find("ColosalClima(Clone)");
     Transform cartaTransform2 = canvass.transform.Find("MundoInversoClima(Clone)");
     Transform cartaTransform3 = canvass.transform.Find("Isla Espuma(Clone)");
     Transform cartaTransform4 = canvass.transform.Find("ZafiroClimaR(Clone)");
     Transform cartaTransform5 = canvass.transform.Find("PrincipioClimaR (Clone)");
     Transform cartaTransform6 = canvass.transform.Find("GimnasioClimaR(Clone)");
     if(cartaTransform4 != null && cartaTransform5 != null)
     {
       
     }
     else if(cartaTransform4 != null && cartaTransform6 != null)
     {

     }
     else 
     {

     }


   }
   else
   {
      Debug.Log("No cumples las condiciones para activar el efecto");
   }
  
}
#endregion
}

//Cambios de Turnos
public static void ReiniciarPuntaje(int puntaje)
{
 Contador = puntaje;
}
public static void ReiniciarPuntajeRival(int puntaje)
{
   ContadorRival = puntaje;
}
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



}
