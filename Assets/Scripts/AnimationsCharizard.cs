using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsCharizard : MonoBehaviour
{
//Animacion
private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
    }
   
   public void AtaqueDragon()
   {
     animator.SetTrigger("Ataque");
     Invoke("EstadoInicial" , 2.5f);
   }
    public void EfectoDragon()
   {
     animator.SetTrigger("Efecto");
     Invoke("EstadoInicial" , 2.5f);
   }
   public void EstadoInicial()
   {
    animator.SetTrigger("Volver");
   }
       void Update()
    {
      
    }
}
