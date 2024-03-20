using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesSettings : MonoBehaviour
{
  public GameObject cameranew;
public GameObject mainCameraa;

private GameObject panel;

private bool isMainCameraActive = true;

void Start()
{
    cameranew.SetActive(false);
    mainCameraa.SetActive(true);
}

public void Activar()
{
    isMainCameraActive = !isMainCameraActive; // Alternar el estado

    cameranew.SetActive(!isMainCameraActive);
    mainCameraa.SetActive(isMainCameraActive);
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
