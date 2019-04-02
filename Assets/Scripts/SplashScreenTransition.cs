using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplashScreenTransition : MonoBehaviour
{
    public GameObject fadeOutImage;
  
    IEnumerator Start()
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(5.0f);
        SplashScreenFadeOut();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Title Screen");

    }

    void SplashScreenFadeOut()
    {
        fadeOutImage.SetActive(true);
    }

}
