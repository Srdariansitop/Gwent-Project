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
  private bool[,] posicionescartasmagicas;
 private bool [,] posicionescartasmagicasrival;
 private static bool LeaderPos;
 private static bool LeaderRivalPos;
 //Mascara Boleeanas para verificar activacion del efecto
 private static bool [,] ActiveEfects;
 private static bool [,] ActiveEfectsRival;

//Cartas clima
 public int doubleStat ;

 //Contadores
 private static int Contador;
private static int ContadorRival;

public Text ContadorFisicoP;
public Text ContadorFisicoR;


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
  Debug.Log(objectoInvocado.tag);
 
  #region AsedioRed
  if(objectoInvocado.tag == "AsedioR")
  {

     if(posicionescampo[2,0] == false)
         {
            GameObject posx = GameObject.Find("Asedio1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
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
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
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
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
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
