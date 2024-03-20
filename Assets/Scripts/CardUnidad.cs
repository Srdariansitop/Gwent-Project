using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    
    // Start is called before the first frame update
    void Start()
    {
      posicionescampo = new bool[3,3];
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
  //Mi campo
  Debug.Log(objectoInvocado.tag);
  if(objectoInvocado.tag == "AsedioR")
  {
     if(posicionescampo[2,0] == false)
         {

         }
         else if(posicionescampo[2,1] == false)
         {

         }
         else if(posicionescampo[2,2] == false)
         {

         }
         else
         {
          Debug.Log("Todas las posiciones asedio estan ocupadas");
         }
  }
  else if(objectoInvocado.tag == "DistanciaR")
  {
    if(posicionescampo[1,0] == false)
         {
            
         }
         else if(posicionescampo[1,1] == false)
         {

         }
         else if(posicionescampo[1,2] == false)
         {

         }
         else
         {
          Debug.Log("Todas las posiciones distancia estan ocupadas");
         }
  }
  else if(objectoInvocado.tag == "CuerpoR")
  {
         if(posicionescampo[0,0] == false)
         {
             GameObject posx = GameObject.Find("Cuerpo1Espacio3");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
         }
         else if(posicionescampo[0,1] == false)
         {
           GameObject posx = GameObject.Find("Cuerpo1Espacio1");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
         }
         else if(posicionescampo[0,2] == false)
         {
            GameObject posx = GameObject.Find("Cuerpo1Espacio2");
            Vector3 posy = posx.transform.position;
            objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
         }
         else
         {
          Debug.Log("Todas las posiciones cuerpo a cuerpo estan ocupadas");
         }
  }
  else if(objectoInvocado.tag == "OroR")
  {

  }
  else if(objectoInvocado.tag == "SilverR")
  {

  }
  else if(objectoInvocado.tag == "SenueloR")
  {

  }

  //Rival
 // GameObject posx = GameObject.Find("Asedio2Espacio3");
 // Vector3 posy = posx.transform.position;
 //  objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
   
}

     



}
