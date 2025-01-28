using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForIntro : MonoBehaviour
{
    public GameObject canvas;
    public float introTime;
    public bool isMainGameIntro;

    public bool canPlay;

    private void Start()
    {
        if(canvas != null)
            canvas.SetActive(false);

        StartCoroutine(IntroHandler(introTime));
    }
    IEnumerator IntroHandler(float time)
    {
        yield return new WaitForSeconds(time);
        if (isMainGameIntro)
        {
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            if (canvas != null)
                canvas.SetActive(true);

            canPlay = true;
        }
    }
}
