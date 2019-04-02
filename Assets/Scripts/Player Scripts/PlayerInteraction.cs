using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour {

    public Image HoldInteract;
    public float holdtime;
    private float temp;
    public GameObject enddoor;

    void Start ()
    {
        temp = 0f;
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.X))
        {
            temp += Time.deltaTime;
            if (temp >=holdtime)
            {
                enddoor.SetActive(false);
                HoldInteract.gameObject.SetActive(false);
            }
            HoldInteract.fillAmount = temp / holdtime;

        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            ResetHold();
       }

	}

   

    void ResetHold()
    {
        temp = 0f;
        HoldInteract.fillAmount = temp / holdtime;
    }
}
