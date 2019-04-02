using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonSelect : MonoBehaviour
{
    public OptionsButton options;
    public Animator anim;
    public int index;

    void Update()
    {
        if (options.index == index)
        {
            anim.SetBool("Pressed", true);

        }
        else
        {
            anim.SetBool("Pressed", false);


        }
    }
}
