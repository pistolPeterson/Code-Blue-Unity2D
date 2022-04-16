using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    //an interaction handler class, as referenced by Antarsoft 'Unity 2D Platformer Tutorial 12' 
    //This class is to detects objects by creating a detection point that is looking for items colliders 
    [Header("Detection Parameters")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.3f;
    public LayerMask detectionLayer;


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


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
