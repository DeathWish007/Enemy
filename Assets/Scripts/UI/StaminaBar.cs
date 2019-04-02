using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour {

    public Image stamina;
    public float staminalerp;


    public void HandleStaminaChange(float _stamina)
    {
        StartCoroutine(ChangetoStamina(_stamina));
    }
  

    IEnumerator ChangetoStamina(float _stamina)
    {
        float temp = stamina.fillAmount;
        float timegone = 0f;

        while (timegone < staminalerp)
        {
            timegone += Time.deltaTime;
            stamina.fillAmount = Mathf.Lerp(temp, _stamina, timegone / staminalerp);
            yield return null;
        }
        stamina.fillAmount = _stamina;
    }

}
