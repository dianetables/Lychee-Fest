using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiesFromCringe : MonoBehaviour
{
    [SerializeField] private Animator animationController;
    void OnTriggerEnter(Collider thing){
        // if(thing.gameObject.tag == "Player"||thing.CompareTag("Player")){
        //     animationController.SetBool("diesFromCringe", true);
        // }
        if(thing.gameObject.tag == "can" || thing.gameObject.tag == "ball" || thing.CompareTag("Player")){
            animationController.SetBool("diesFromCringe", true);
        }
    }
    void OnTriggerExit(Collider thing){
        if(thing.CompareTag("Player")){
            animationController.SetBool("diesFromCringe", false);
        }
    }
}
