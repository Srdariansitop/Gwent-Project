using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesSettings : MonoBehaviour
{
  //Camaras
  public GameObject cameranew;
public GameObject mainCameraa;
private  int Turnos;
private int Rondas;
public Text Turnosstring;
//Regresar
private GameObject panel;



void Start()
{
    mainCameraa.SetActive(true);
    cameranew.SetActive(false);
    Rondas = 1;
    Turnos = 1;
}

public void Activar()
{
  Debug.Log("mbappe");
    if (mainCameraa.activeSelf)
    {
        mainCameraa.SetActive(false);
        cameranew.SetActive(true);
        Turnos++;
    }
    else
    {
        mainCameraa.SetActive(true);
        cameranew.SetActive(false);
        Turnos++;
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
void Update()
{
  if(Turnosstring != null)
  {
    Turnosstring.text = Turnos.ToString();
  }
}

}
