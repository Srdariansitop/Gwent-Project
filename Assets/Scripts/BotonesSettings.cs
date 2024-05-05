using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class BotonesSettings : MonoBehaviour
{
  
public GameObject mainCameraa;
public static int Turnos;
public static int Rondas;
public static int RondasRival;
public TextMeshProUGUI Turnosstring;
//Contadores
public Text Contador;
public Text ContadoresRival;
//Regresar
private GameObject panel;
private bool Condition;
//Rondas
public Text RondasFisico;
public Text RondasRivalFisico;
public Button buttonBarajear;
public Button buttonBarajearRival;
public Button buttonRobarRival;
public Button buttonRobar;

void Start()
{
    
    Rondas = 0;
    Turnos = 1;
    buttonBarajear.transform.localScale = new Vector3(1f,1f,1f);
    buttonBarajearRival.transform.localScale = Vector3.zero;
    buttonRobar.transform.localScale = Vector3.zero;
    buttonRobarRival.transform.localScale = Vector3.zero;
}

public void Activar()
{
  
    if (Condition == false)
    {
        Turnos++;
        mainCameraa.transform.rotation = Quaternion.Euler(180,180,0);
        Condition = true;
        CardUnidad.Invocaste = false;
        CardUnidad.Activaste = false;
        buttonBarajear.transform.localScale = Vector3.zero;
        buttonBarajearRival.transform.localScale = new Vector3(1f,1f,1f);
        if(CardUnidad.ActiveEfects[0,2] == true)
        {
          CardUnidad.Contador += 100;
        }
        if(CardUnidad.ActiveEfectsRival[1,2] == true)
        {
          CardUnidad.Contador -=100;
        }
        if(Rondas == 1 && RondasRival == 1)
        {
          buttonRobar.transform.localScale = Vector3.zero;
          buttonRobarRival.transform.localScale = new Vector3(1f,1f,1f);
        }
    }
    else
    {
        
        Turnos++;
        mainCameraa.transform.rotation = Quaternion.Euler(0,0,0);
        Condition = false;
        CardUnidad.Invocaste = false;
         CardUnidad.Activaste = false;
        buttonBarajear.transform.localScale = new Vector3(1f,1f,1f);
         buttonBarajearRival.transform.localScale = Vector3.zero;
           if(CardUnidad.ActiveEfects[0,2] == true)
        {
          CardUnidad.Contador += 100;
        }
        if(CardUnidad.ActiveEfectsRival[1,2] == true)
        {
          CardUnidad.Contador -=100;
        }
         if(Rondas == 1 && RondasRival == 1)
        {
          buttonRobar.transform.localScale =  new Vector3(1f,1f,1f);
          buttonRobarRival.transform.localScale = Vector3.zero;
        }
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
  if(Turnos % 2 == 0 && Turnos > 2)
  {
    
    int contador = CardUnidad.Contador;
    int ContadorRival = CardUnidad.ContadorRival;
    if(contador > ContadorRival)
    {
       Rondas++;
       if(Rondas == 2)
       {
        Debug.Log("El ganador ha sido el equipo de Red");
        SceneManager.LoadScene("GanadorRed");
       }
       mainCameraa.transform.rotation = Quaternion.Euler(0,0,0);
        buttonBarajear.transform.localScale = new Vector3(1f,1f,1f);
         buttonBarajearRival.transform.localScale = Vector3.zero;
        Turnos = 1;
        CardUnidad.ReiniciarPuntaje(0);
        CardUnidad.ReiniciarPuntajeRival(0);
        Condition = false;
        CardUnidad.VaciarCampo();
        CardUnidad.Invocaste = false;
         CardUnidad.Activaste = false;
        buttonBarajear.transform.localScale = Vector3.zero;
        buttonBarajearRival.transform.localScale = Vector3.zero;
        if(Rondas == RondasRival)
        {
          buttonRobar.transform.localScale = new Vector3(1f,1f,1f);
        }
    }
    else if(contador == ContadorRival)
    {
        if(CardUnidad.LeaderRivalEfect == true)
       {
        RondasRival++;
      if(RondasRival == 2)
      {
        Debug.Log("El ganador ha sido el equipo de los legendarios");
        SceneManager.LoadScene("GanadorL");
      }
      mainCameraa.transform.rotation = Quaternion.Euler(180,180,0);
       buttonBarajear.transform.localScale = Vector3.zero;
        buttonBarajearRival.transform.localScale = new Vector3(1f,1f,1f);
       Turnos = 1;
       CardUnidad.ReiniciarPuntaje(0);
       CardUnidad.ReiniciarPuntajeRival(0);
       Condition = true;
       CardUnidad.VaciarCampo();
       CardUnidad.Invocaste = false;
        CardUnidad.Activaste = false;
        buttonBarajear.transform.localScale = Vector3.zero;
        buttonBarajearRival.transform.localScale = Vector3.zero;
        if(Rondas == RondasRival)
        {
           buttonRobarRival.transform.localScale = new Vector3(1f,1f,1f);
        }
       }
       
      Debug.Log("Sigan jugando");
    }
    else
    {
      RondasRival++;
      if(RondasRival == 2)
      {
        Debug.Log("El ganador ha sido el equipo de los legendarios");
         SceneManager.LoadScene("GanadorL");
      }
      mainCameraa.transform.rotation = Quaternion.Euler(180,180,0);
       buttonBarajear.transform.localScale = Vector3.zero;
        buttonBarajearRival.transform.localScale = new Vector3(1f,1f,1f);
       Turnos = 1;
       CardUnidad.ReiniciarPuntaje(0);
       CardUnidad.ReiniciarPuntajeRival(0);
       Condition = true;
       CardUnidad.VaciarCampo();
       CardUnidad.Invocaste = false;
        CardUnidad.Activaste = false;
        buttonBarajear.transform.localScale = Vector3.zero;
        buttonBarajearRival.transform.localScale = Vector3.zero;
        if(Rondas == RondasRival)
        {
           buttonRobarRival.transform.localScale = new Vector3(1f,1f,1f);
        }
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
  if(RondasRivalFisico != null)
  {
     
      RondasRivalFisico.text = "Legendarios :" + RondasRival.ToString(); 
  }
  if(RondasFisico != null)
  {
    RondasFisico.text = "Red :" + Rondas.ToString();
  }
}

}
