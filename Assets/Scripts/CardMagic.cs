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

    
    void Start()
    {
       spriteGigante = GameObject.FindGameObjectWithTag(nametag);
        spriteRenderer = spriteGigante.GetComponent<SpriteRenderer>();
        spriteGigante.transform.localScale = Vector3.zero;

             panel = GameObject.FindGameObjectWithTag("Invocar");
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
  }
   
}



}
