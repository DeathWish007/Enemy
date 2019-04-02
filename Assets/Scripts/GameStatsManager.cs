using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameStatsManager : MonoBehaviour
{
    float damagedone;
   float damagedealt;
    float healthregained;
     float Accuracy;
    float deaths;
   float kills;

    public Text tdamagedone;
    public Text tdamagedealt;
    public Text thealthregained;
    public Text tAccuracy;
    public Text tdeaths;
    public Text tkills;

    private void Start()
    {
       


        damagedone = PlayerPrefs.GetFloat("TotalDamageDone");
        damagedealt = PlayerPrefs.GetFloat("TotalDamageRecieved");
        healthregained = PlayerPrefs.GetFloat("TotalHealthRegained");
        Accuracy = PlayerPrefs.GetFloat("Accuracy");
        deaths = PlayerPrefs.GetFloat("TotalDeaths");
        kills = PlayerPrefs.GetFloat("TotalKills");

        tdamagedone.text = "Damage Done:" + damagedone.ToString("0.0");

        tdamagedealt.text = "Damage Recieved:" + damagedealt.ToString("0.0");

        thealthregained.text = "Health Regained:" + healthregained.ToString("0.0");

        tAccuracy.text = "Accuracy:" + Accuracy.ToString("0.00") + "%";

        tdeaths.text = "Total Deaths:" + deaths.ToString();

        tkills.text = "Total kills:" + kills.ToString();


        damagedone = Stats.Tdamagedone;

        damagedealt = Stats.Tdamagedealt;

        healthregained = Stats.ThealthRegained;

        Accuracy = (Stats.Thitbullets * 100f / Stats.Ttotalbullets);

        deaths = Stats.Tdeaths;

        kills = Stats.Tkills;


        PlayerPrefs.SetFloat("TotalDamageDone", damagedone);
        PlayerPrefs.SetFloat("TotalDamageRecieved", damagedealt);
        PlayerPrefs.SetFloat("TotalHealthRegained", healthregained);
        PlayerPrefs.SetFloat("Accuracy", Accuracy);
        PlayerPrefs.SetFloat("TotalDeaths", deaths);
        PlayerPrefs.SetFloat("TotalKills", kills);

   

    
        Debug.Log(" " + damagedone + " " + damagedealt + " " + Accuracy);



    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Extras");
        }

    }

    /*private void OnApplicationQuit()
    {
       // PlayerPrefs.SetFloat("TotalDamageDone", Stats.Tdamagedone);
       // PlayerPrefs.SetFloat("TotalDamageRecieved", Stats.Tdamagedealt);
        //PlayerPrefs.SetFloat("TotalHealthRegained", Stats.ThealthRegained);
        //PlayerPrefs.SetFloat("Accuracy", (Stats.Thitbullets * 100f / Stats.Ttotalbullets));
       // PlayerPrefs.SetFloat("TotalDeaths", Stats.Tdeaths);
       // PlayerPrefs.SetFloat("TotalKills", Stats.Tkills);


        PlayerPrefs.SetFloat("TotalDamageDone", damagedone);
        PlayerPrefs.SetFloat("TotalDamageRecieved", damagedealt);
        PlayerPrefs.SetFloat("TotalHealthRegained",healthregained);
        PlayerPrefs.SetFloat("Accuracy", Accuracy);
        PlayerPrefs.SetFloat("TotalDeaths", deaths);
        PlayerPrefs.SetFloat("TotalKills", kills);

        PlayerPrefs.Save();
    }*/
}
