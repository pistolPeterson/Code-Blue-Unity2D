using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectColorChanger : MonoBehaviour
{

    public Color startColor;
    public Color mouseOverColor;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        if (image == null)
            image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OriginalColor()
    {
       
        image.color = startColor;
    }

    public void MouseColor()
    {
      
        image.color = mouseOverColor;
    }
   

    public void GoToBeginningScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
