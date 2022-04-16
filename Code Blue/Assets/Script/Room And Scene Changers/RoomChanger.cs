using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{

    public Transform whereAmIGoing;
    private bool isNearDoor = false;
    public GameObject player;

    private void Awake()
    {
        if(player == null)
            player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.Z))
        {
            player.gameObject.transform.position = whereAmIGoing.transform.position;
        }
    }

     


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNearDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNearDoor = false;
        }
    }

}
