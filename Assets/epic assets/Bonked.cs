using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonked : MonoBehaviour
{
    [SerializeField] private Animator animationController;
    void OnTriggerEnter(Collider thing){
        if(thing.gameObject.tag == "can" || thing.gameObject.tag == "ball" || thing.gameObject.tag == "Player"){
            animationController.SetBool("bonked", true);
        }
    }
    void OnTriggerExit(Collider thing){
        if(thing.CompareTag("can")||thing.CompareTag("ball")||thing.CompareTag("Player")){
            animationController.SetBool("bonked", false);
        }
    }
}
