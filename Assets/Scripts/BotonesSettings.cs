using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesSettings : MonoBehaviour
{
  //Camaras
  public GameObject cameranew;
public GameObject mainCameraa;


//Regresar
private GameObject panel;



void Start()
{
    mainCameraa.SetActive(true);
    cameranew.SetActive(false);
}

public void Activar()
{
  Debug.Log("mbappe");
    if (mainCameraa.activeSelf)
    {
        mainCameraa.SetActive(false);
        cameranew.SetActive(true);
    }
    else
    {
        mainCameraa.SetActive(true);
        cameranew.SetActive(false);
    }
}

public void Regresar()
{
  panel = GameObject.FindGameObjectWithTag("Invocar");
  if(panel != null)
  {
   panel.transform.localScale = Vector3.zero;
  }     
}


}
