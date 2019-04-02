using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExtrasButtonSelect : MonoBehaviour
{
    public ExtrasButton extras;
    public Animator anim;
    public int index;

    void Update()
    {
        if (extras.index == index)
        {
            anim.SetBool("Pressed", true);

            if(Input.GetKeyDown(KeyCode.Return)&& extras.index == 0)
            {
                SceneManager.LoadScene("GameStats");
            }
        }
        else
        {
            anim.SetBool("Pressed", false);


        }
    }
}
