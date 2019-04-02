using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeButton : MonoBehaviour
{
    public int index;
    public bool isKeyDown;
    public int maxKeys;

    private void Update()
    {




        if (Input.GetAxis("Vertical") != 0)
        {
            if (!isKeyDown)
            {
                //if (Input.GetAxis("Horizontal") > 0)
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
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
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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
