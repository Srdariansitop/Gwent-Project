using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsCharizard : MonoBehaviour
{
//Animacion
private static Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
    }
   
   public  void AtaqueDragon(string nomnbreanimacion )
   {
     animator.SetTrigger("Ataque"); 
   }
       void Update()
    {
        // Detectar algún evento para iniciar la transición, por ejemplo, presionar una tecla
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activar la transición mediante CrossFade
            animator.CrossFade("Ataque", 1f); // Reemplaza "NombreDeTuAnimacion" con el nombre de tu animación
        }
    }
}
