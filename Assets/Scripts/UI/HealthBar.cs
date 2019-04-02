using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour {

    public Image health;
    public float healthlerp;

    private void Awake()
    {
        
    }
  
   

   public void HandleHealthChange(float _health)
    {
        StartCoroutine(ChangetoHealth(_health));
    }

    IEnumerator ChangetoHealth(float _health)
    {
        float temp = health.fillAmount;
        float timegone = 0f;

        while (timegone < healthlerp)
        {
            timegone += Time.deltaTime;
            health.fillAmount = Mathf.Lerp(temp, _health, timegone / healthlerp);
            yield return null;
        }
        health.fillAmount = _health;
    }
}
