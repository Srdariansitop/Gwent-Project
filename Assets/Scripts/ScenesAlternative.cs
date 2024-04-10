using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesAlternative : MonoBehaviour
{
   
    public void Exit()
    {
        Application.Quit();
    }
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Update()
    {
       
    }
}
