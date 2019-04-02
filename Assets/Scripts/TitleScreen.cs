using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    bool ispressed = false;
    public GameObject ZoomIn;
    public GameObject pressAnyKey;

    private void Start()
    {
        Cursor.visible = false;
    }
    void FixedUpdate()
    {


        if (Input.anyKey && ispressed==false)
        {
            ispressed = true;
            ZoomIn.SetActive(true);
            pressAnyKey.SetActive(false);
        }
    }

}
