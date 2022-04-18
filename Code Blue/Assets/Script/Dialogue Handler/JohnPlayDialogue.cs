using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnPlayDialogue : MonoBehaviour
{
    //the main class for handling the dialogue of john, might have to use editor functions to group sets of dialogue together for better organization
    //also assume that Faith will also learn this, so do it in a intutive way
    public Dialogue_Set john_intro;
    public Dialogue_Set john_DoorIsLocked;
    public Dialogue_Set john_DoorIsUnlocked;


    // Start is called before the first frame update
    void Start()
    {
        john_intro?.sendDialogue();
    }


    public void SayDoorIsLocked()
    {
        john_DoorIsLocked?.sendDialogue();
    }

    public void SayDoorIsUnLocked()
    {
        john_DoorIsUnlocked?.sendDialogue();
    }



}
