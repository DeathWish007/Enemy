using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeButtonSelect : MonoBehaviour
{
    public EscapeButton escape;
    public Animator anim;
    public int index;

    public PauseScreen pause;
    void Update()
    {
        if (escape.index == index)
        {
            anim.SetBool("Pressed", true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (escape.index == 0 && pause.canPress==true)
                {
                    SceneManager.LoadScene("Menu");
                    PlayerMovement.canMove = true;
                    PlayerGun.canShoot = true;
                }
                else if (escape.index == 1 && pause.canPress==true)
                {
                    Application.Quit();
                }
            }

        }
        else
        {
            anim.SetBool("Pressed", false);


        }
    }
}
