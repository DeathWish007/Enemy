using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStamina : MonoBehaviour {

    StaminaBar st;
    [Range(0.02f, 0.1f)]
    public float StaminaIncreaseBySecond;
    public float maxStamina;
    public float currentStamina;
    public Image Stamina;
    public float staminalerp;

    private void OnEnable()
    {
        currentStamina = maxStamina;

    }
    private void Awake()
    {
        st = GameObject.FindGameObjectWithTag("Stamina").GetComponent<StaminaBar>();
    }
 
   public void StaminaDecrease()
    {
        if (currentStamina >= 12)
        {
            currentStamina -= 12f;
            float staminaperc = currentStamina / maxStamina;
            st.HandleStaminaChange(staminaperc);
        }


    }

    public void StaminaIncrease()
    {
        if (currentStamina <= maxStamina - StaminaIncreaseBySecond)
        {
            currentStamina += StaminaIncreaseBySecond;

            float staminaperc = currentStamina / maxStamina;

            st.HandleStaminaChange(staminaperc);
        }



    }
}
