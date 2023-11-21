using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    //Detecicon para anotacion, se llama a la funcion Ontrigger para detectar la colision con alguna de las porterias
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Ball")){
            Debug.Log("Gooooooaaaaallll");
            onTriggerEnter.Invoke();
        }
    }
}
