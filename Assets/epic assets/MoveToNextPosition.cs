using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for button use

public class MoveToNextPosition : MonoBehaviour
{
     public GameObject player; // gain access to the player's position

    public void Teleport(GameObject NextLocation)
    {
          Transform pos = NextLocation.transform; // get the position of the next location
          player.transform.position = pos.position; // change the position of the player to the next location
          player.transform.rotation = pos.rotation; // change rotation of the player to the rotation of the next location
    }

    // hard code teleport position template
    // must create a different method/script
    // if you want to teleport to different positions
    public void Teleport()
    {
          // i just put 100, 100, 100
          float x_pos = 100f;
          float y_pos = 100f;
          float z_pos = 100f;
          player.transform.position = new Vector3(x_pos, y_pos, z_pos);
    }

}