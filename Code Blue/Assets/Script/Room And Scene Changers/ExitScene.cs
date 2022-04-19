using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScene : MonoBehaviour
{
    [SerializeField]private string SceneName;
    private bool isNearArea = false;

   [SerializeField] private Image blackImage;
   [SerializeField] private Animator anim;


    private void Awake()
    {
        StartCoroutine(FadeIn());
    }
    private void Update()
    {
        if (isNearArea && Input.GetKeyDown(KeyCode.Z))
        {
            // SceneManager.LoadSceneAsync(SceneName);
            StartCoroutine(FadeInScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNearArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNearArea = false;
        }
    }


    public IEnumerator FadeInScene()
    {
        anim.SetBool("Fade", true);
        Debug.Log("waitign");
        yield return new WaitUntil(() => blackImage.color.a == 1);
        SceneManager.LoadSceneAsync(SceneName);
    }
    IEnumerator FadeIn()
    {
        anim.Play("FadeIn");
        yield return new WaitUntil(() => blackImage.color.a == 1);
       // blackImage.gameObject.SetActive(false);
    }
}
