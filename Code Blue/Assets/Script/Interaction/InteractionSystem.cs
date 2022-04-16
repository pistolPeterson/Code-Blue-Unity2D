using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;



    private void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                Debug.Log("INTERACT");
            }
        }
    }


    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        bool isDectected = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        return isDectected;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
