using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    //this class is a simple implementation of a door and key system. On interaction, door will search player's inventory for an object of type key 
    //AND a string 'keyword'  to make sure its of the same type. Made by Peterson
    //reccomend to add the Item class to this gameobject as well, since it is basically coupled with the iventory system
    //refactor to make this class abstract? 
    //possible problem: what if we want tthe key and door not to be in the same scene? what if we want multiple keys for a door 
    [SerializeField] private InventorySystem inventorySystem;
    private bool isNearDoor;
    [SerializeField] private KeyForLockedDoor key;

    //technical debt stuff, to show it works. better to remake this into a abstract class 
    [SerializeField] private JohnPlayDialogue johnPlayDialogue;


    private void Awake()
    {
        if(inventorySystem == null)
            inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNearDoor && !Textbox.On/*figure out a way to make the textbox check automatic*/)
        {
           bool found = false;
            for (int i =0; i < inventorySystem.getInventoryItems().Count; i++)
            {
                var item = inventorySystem.getInventoryItems()[i];
                var itemKey = item.GetComponent<KeyForLockedDoor>();
                if (itemKey != null)
                 if(itemKey.KeyId == key.KeyId)
                {
                    found = true;
                   
                    johnPlayDialogue.SayDoorIsUnLocked();
                        StartCoroutine(WaitThenGoBackToMainMenu());
                }
            }
            if(found == false)
            {
              
                johnPlayDialogue.SayDoorIsLocked();
            }       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { isNearDoor = true; }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { isNearDoor = false; }
    }

    IEnumerator WaitThenGoBackToMainMenu()
    {

        
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(0);
    }
}
