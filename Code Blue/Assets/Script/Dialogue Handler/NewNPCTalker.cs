using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNPCTalker : MonoBehaviour
{
    public bool nearPlayer = false;
    public Dialogue_Set NPCTestDolaouge;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nearPlayer);
        if(Input.GetKeyDown(KeyCode.Z) && nearPlayer && !Textbox.On)
        {
            NPCTestDolaouge.sendDialogue();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            nearPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            nearPlayer = false;
    }

}
