using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtrasButton : MonoBehaviour
{
    public int index;
    public bool isKeyDown;
    public int maxKeys;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (!isKeyDown)
            {
                //if (Input.GetAxis("Horizontal") > 0)
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (index < maxKeys)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                // else if (Input.GetAxis("Horizontal") < 0)
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxKeys;
                    }
                }
                isKeyDown = true;
            }

        }
        else
        {
            isKeyDown = false;
        }
    }
}
