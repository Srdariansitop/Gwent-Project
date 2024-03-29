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
private int RondasRival;
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
public void GanadorRonda()
{
  if(Turnos % 2 == 0)
  {
    
    int contador = CardUnidad.Contador;
    int ContadorRival = CardUnidad.ContadorRival;
    if(contador > ContadorRival)
    {
       Rondas++;
       if(Rondas == 3)
       {
        Debug.Log("El ganador ha sido el equipo de Red");
       }
        mainCameraa.SetActive(true);
        cameranew.SetActive(false);
        Turnos = 1;
        CardUnidad.ReiniciarPuntaje(0);
        CardUnidad.ReiniciarPuntajeRival(0);
    }
    else if(contador == ContadorRival)
    {

      Debug.Log("Sigan jugando");
    }
    else
    {
      RondasRival++;
      if(RondasRival == 3)
      {
        Debug.Log("El ganador ha sido el equipo de los legendarios");
      }
       mainCameraa.SetActive(false);
       cameranew.SetActive(true);
       Turnos = 1;
       CardUnidad.ReiniciarPuntaje(0);
       CardUnidad.ReiniciarPuntajeRival(0);
    }
  } 
  else
  {
    Debug.Log("Tiene q jugar el rival");
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
