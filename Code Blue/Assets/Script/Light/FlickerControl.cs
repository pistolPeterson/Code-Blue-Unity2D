using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickerControl : MonoBehaviour
{
   [SerializeField] private bool isFlickering = false;
   [SerializeField] public float timeDelay; 
   
    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
        
    }


    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        // this.gameObject.GetComponent<Light2D>().enabled = false;
          this.gameObject.GetComponent<Light2D>().intensity = Random.Range(0.66f, 0.75f);
        
        timeDelay = Random.Range(0.08f, 1.6f);
        yield return new WaitForSeconds(timeDelay);


        //this.gameObject.GetComponent<Light2D>().enabled = true;
        this.gameObject.GetComponent<Light2D>().intensity = 1f;
        timeDelay = Random.Range(0.16f, 3.2f);
        yield return new WaitForSeconds(timeDelay);
        
        isFlickering = false;

    }
    

    
    


}
