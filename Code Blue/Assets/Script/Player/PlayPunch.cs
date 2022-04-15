using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPunch : MonoBehaviour
{
    public GameObject player; 


    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.GetComponent<Animator>().Play("Punch");
        }
    }
}
