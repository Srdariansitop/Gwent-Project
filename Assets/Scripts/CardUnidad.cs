using System.Collections;
using System.Collections.Generic;
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
 private static bool [,] posicionescampo;
 private static bool [,] posicionescamporival;
 private static int Contador;
private static int ContadorRival;
public Text ContadorFisicoP;
public Text ContadorFisicoR;

    // Start is called before the first frame update
    void Start()
    {
      posicionescampo = new bool[3,3];
      posicionescamporival = new bool[3,3];
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
