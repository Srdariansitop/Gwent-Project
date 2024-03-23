using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardMagic : MonoBehaviour  
{
 public string Nombre;
 public string Tipo;
 private GameObject spriteGigante;
 private SpriteRenderer spriteRenderer;
 private string nametag = "Show Card";
 private GameObject panel;
 private bool[,] posicionescartasmagicas;
 private bool [,] posicionescartasmagicasrival;
 private bool leader;
 private bool leaderrival ;
  private static GameObject objectoInvocado;
    
    void Start()
    {
       posicionescartasmagicas = new bool[3,2];
       posicionescartasmagicasrival = new bool[3,2];
       spriteGigante = GameObject.FindGameObjectWithTag(nametag);
        spriteRenderer = spriteGigante.GetComponent<SpriteRenderer>();
        spriteGigante.transform.localScale = Vector3.zero;

             panel = GameObject.FindGameObjectWithTag("Invocar2");
            if(panel != null)
            {
              panel.transform.localScale = Vector3.zero;
            }     
         
    
    }
    //Mostrar la carta en grande en la pantalla
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

  //Mi Lider
 if(objectoInvocado.tag == "Lider" && leader == false)
 {
    GameObject posx = GameObject.Find("CartaLider1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    leader = true;
 }
 //Lider Rival
 else if(objectoInvocado.tag == "Lider2" && leaderrival == false)
 {
   GameObject posx = GameObject.Find("CartaLider2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    leaderrival = true;
 }
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
 else if(objectoInvocado.tag == "ClimaR")
 {
   if(posicionescartasmagicas[0,1] == false)
   {
     GameObject posx = GameObject.Find("Clima1");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[0,1] = true;
   }
   else if(posicionescartasmagicas[1,1] == false)
   {
       GameObject posx = GameObject.Find("Clima2");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[1,1] = true;
   }
   else if(posicionescartasmagicas[2,1] == false)
   {
      GameObject posx = GameObject.Find("Clima3");
    Vector3 posy = posx.transform.position;
    objectoInvocado.transform.position = new Vector3(posy.x , posy.y , 2f);
    posicionescartasmagicasrival[2,1] = true;
   }
   else
   {
    Debug.Log("Todos los espacios de cartas estan ocupadas");
   }
 }
 else
 {
  Debug.Log("Las cartas despeje no es invocable");
 }
}


}
