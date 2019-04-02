using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenZoomIn : MonoBehaviour
{
    public Camera cam;
    public float smooth;
    float temp;

    public Animator camAnim;
    public Animator fadeAnim;
    void FixedUpdate()
    {

       
        cam.orthographicSize -= (1f / smooth) * Time.fixedDeltaTime;

        if (cam.orthographicSize <=0.01f)
        {
            SceneManager.LoadScene("Menu");

        }
        camAnim.SetTrigger("CameraRotate");
        fadeAnim.SetTrigger("TitleScreenFade");
    }
}
