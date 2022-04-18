using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    //a item class, as referenced by Antarsoft 'Unity 2D Platformer Tutorial 13 - Interaction System Item Script Setup' 
    //This dynamic class forces some components to be placed on a object and also gives it functionality depending on what type of item it is 

   
    public enum InteractionType { NONE, PickUp, Examine}
    public enum ItemType { staticType, Consumables}

    [Header("Attributes ")]
    public InteractionType interactType;
    public ItemType type;



    [Header("Examine ")]
    public string descriptionText;
    public Sprite image;

    [Header("Unity events")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 11;
        //get component spriterenderer, and make it foreground? 
    }

    public void Interact()
    {
        switch (interactType)
        {
            case InteractionType.NONE:
             
                break;
            case InteractionType.PickUp:
                //Add the object to the picked up items list 
                FindObjectOfType<InventorySystem>().PickUp(gameObject);
                //disable object 
               gameObject.SetActive(false);
              
                break;
            case InteractionType.Examine:
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            default:
                Debug.Log("null item");
                break;
        }

        //Invoke the custom events 
        customEvent.Invoke();
    }

}
