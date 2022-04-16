using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    //an interaction handler class, as referenced by Antarsoft 'Unity 2D Platformer Tutorial 12' 
    //This class is to detects objects by creating a detection point that is looking for items colliders 
    [Header("Detection Fields")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.3f;
    public LayerMask detectionLayer;

    [Header("Examine Fields")]
    public GameObject examineWindow;
    public Image itemImage;
    public Text itemDescription;
    public bool isExamining;


    [Header("others")]
    public List<GameObject> pickedItems = new List<GameObject>();


    public GameObject detectedObject;

    private void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
              
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }


    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if(obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
       
    }


    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }

    public void ExamineItem(Item item)
    {
        if(isExamining )
        {
            examineWindow.SetActive(false);
            FindObjectOfType<PlayerMovement>().UnFreezePlayer();
            isExamining = false;

        }
        else
        {
            itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;//give option to choose either the original game image or an image of our choosing 
            itemDescription.text = item.descriptionText;
            examineWindow.SetActive(true);
            FindObjectOfType<PlayerMovement>().FreezePlayer();
           
            isExamining =true;
        }
      
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
