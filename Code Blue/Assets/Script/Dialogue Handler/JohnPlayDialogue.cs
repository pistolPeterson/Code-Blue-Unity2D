using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnPlayDialogue : MonoBehaviour
{
    public Dialogue_Set john_intro;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.FreezePlayer();
        john_intro.sendDialogue();
    }

   
}
