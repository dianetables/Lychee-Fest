using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFoodVideos : MonoBehaviour
{
    public GameObject videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
    void OnTriggerEnter(Collider player){
        if(player.gameObject.tag == "Player")
        {
            videoPlayer.SetActive(true);
        }
    }
    
}
