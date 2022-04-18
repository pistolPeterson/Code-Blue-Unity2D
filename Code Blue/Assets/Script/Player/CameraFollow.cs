using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float lookAhead;
    private void FixedUpdate()
    {
        DetermineOffset();
        CameraFollowMethod();
    }

   void CameraFollowMethod()
    {
       
       
       Vector3 targetPosition = cameraTarget.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition,smoothFactor * Time.fixedDeltaTime );
        transform.position = smoothPosition;    
    }


    void DetermineOffset()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
           
            float multiplier; 
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                multiplier = 1;
            }
            else
            {
                multiplier = -1;
            }
         
            offset = new Vector3(lookAhead * multiplier,offset.y,offset.z);
            Debug.Log(lookAhead + " " + multiplier + " " + offset.x);
        }
        else
        {
            
        }
    }
}
