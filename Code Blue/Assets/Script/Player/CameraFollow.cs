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
    private float lookAhead;
    private void FixedUpdate()
    {
        CameraFollowMethod();
    }

   void CameraFollowMethod()
    {
       Vector3 targetPosition = cameraTarget.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition,smoothFactor * Time.fixedDeltaTime );
        transform.position = smoothPosition;    
    }
}
