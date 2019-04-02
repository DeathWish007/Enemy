using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalStat : MonoBehaviour
{
    public Text damagedone;
    public Text damagedealt;
    public Text healthregained;
    public Text Accuracy;
    public Text deaths;
    public Text kills;

    float _damageDone;
    float _damageRecieved;
    float _healthRegained;
    float _accuracy;
    float _deaths;
    float _kills;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
            _damageDone = PlayerPrefs.GetFloat("TotalDamageDone");
            _damageRecieved = PlayerPrefs.GetFloat("TotalDamageRecieved");
            _healthRegained = PlayerPrefs.GetFloat("TotalHealthRegained");
            _accuracy = PlayerPrefs.GetFloat("Accuracy");
            _deaths = PlayerPrefs.GetFloat("TotalDeaths");
            _kills = PlayerPrefs.GetFloat("TotalKills");



            damagedone.text = "Damage Done:" + _damageDone.ToString("0.0");

            damagedealt.text = "Damage Recieved:" + _damageRecieved.ToString("0.0");

            healthregained.text = "Health Regained:" + _healthRegained.ToString("0.0");

            Accuracy.text = "Accuracy:" + _accuracy.ToString("0.00") + "%";

            deaths.text = "Total Deaths:" + _deaths.ToString();

            kills.text = "Total kills:" + _kills.ToString();
   

          


      
    }


}
