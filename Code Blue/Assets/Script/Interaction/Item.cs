using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    //a item class, as referenced by Antarsoft 'Unity 2D Platformer Tutorial 13 - Interaction System Item Script Setup' 
    //This dynamic class forces some components to be placed on a object and also gives it functionality depending on what type of item it is 

   
    public enum InteractionType { NONE, PickUp, Examine}
    public InteractionType type;

   
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 11;
        //get component spriterenderer, and make it foreground? 
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.NONE:
                Debug.Log("NONE");
                break;
            case InteractionType.PickUp:
                //Add the object to the picked up items list 
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                //disable object 
               gameObject.SetActive(false);
                Debug.Log("Pickup item");
                break;
            case InteractionType.Examine:
                Debug.Log("examine item");
                break;
            default:
                Debug.Log("null item");
                break;
        }
    }

}
