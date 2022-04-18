using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForLockedDoor : MonoBehaviour
{
    public string KeyId;


    public string getKeyId()
    {
        if (string.IsNullOrEmpty(KeyId))
        {
            Debug.LogWarning("a key id is empty");
        }

        return KeyId;
    }
    



}
