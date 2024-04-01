using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesSettings : MonoBehaviour
{
  
public GameObject mainCameraa;
private  int Turnos;
public static int Rondas;
public static int RondasRival;
public Text Turnosstring;
//Contadores
public Text Contador;
public Text ContadoresRival;
//Regresar
private GameObject panel;
private bool Condition;


void Start()
{
    
    Rondas = 1;
    Turnos = 1;
}

public void Activar()
{
  
    if (Condition == false)
    {
        Turnos++;
        Contador.transform.rotation = Quaternion.Euler(180,180,0);
        ContadoresRival.transform.rotation =  Quaternion.Euler(0,0,0);
        mainCameraa.transform.rotation = Quaternion.Euler(180,180,0);
        Condition = true;
    }
    else
    {
        
        Turnos++;
       ContadoresRival.transform.rotation = Quaternion.Euler(180,180,0);
        Contador.transform.rotation =  Quaternion.Euler(0,0,0);
        mainCameraa.transform.rotation = Quaternion.Euler(0,0,0);
        Condition = false;
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
       mainCameraa.transform.rotation = Quaternion.Euler(0,0,0);
        Turnos = 1;
        CardUnidad.ReiniciarPuntaje(0);
        CardUnidad.ReiniciarPuntajeRival(0);
        Condition = false;
        CardUnidad.VaciarCampo();
    }
    else if(contador == ContadorRival)
    {
        if(CardUnidad.LeaderRivalEfect == true)
       {
        RondasRival++;
      if(RondasRival == 3)
      {
        Debug.Log("El ganador ha sido el equipo de los legendarios");
      }
      mainCameraa.transform.rotation = Quaternion.Euler(180,180,0);
       Turnos = 1;
       CardUnidad.ReiniciarPuntaje(0);
       CardUnidad.ReiniciarPuntajeRival(0);
       Condition = true;
       CardUnidad.VaciarCampo();
       }
       
      Debug.Log("Sigan jugando");
    }
    else
    {
      RondasRival++;
      if(RondasRival == 3)
      {
        Debug.Log("El ganador ha sido el equipo de los legendarios");
      }
      mainCameraa.transform.rotation = Quaternion.Euler(180,180,0);
       Turnos = 1;
       CardUnidad.ReiniciarPuntaje(0);
       CardUnidad.ReiniciarPuntajeRival(0);
       Condition = true;
       CardUnidad.VaciarCampo();
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
