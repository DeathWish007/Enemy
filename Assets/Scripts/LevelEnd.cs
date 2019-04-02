using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {
    public LayerMask player;
    public Text damagedone;
    public Text damagedealt;
    public Text healthregained;
    public Text Accuracy;
    public Text deaths;
    public Text kills;
    public Text Timetaken;
    public GameObject statbar;

    private void Update()
    {

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, transform.position, 1f, player);
        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.CompareTag("Player"))
            {
                StartCoroutine(EndLevel());

               
            }
        }
    }

   
    IEnumerator EndLevel()
    {
        statbar.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        damagedone.text = "Damage Done:" + Stats.damagedone.ToString();
        yield return new WaitForSeconds(1.0f);

        damagedealt.text = "Damage Recieved:" + Stats.damagedealt.ToString();
        yield return new WaitForSeconds(1.0f);

        healthregained.text = "Health Regained:" + Stats.healthRegained.ToString("0.0");
        yield return new WaitForSeconds(1.0f);

        Accuracy.text = "Accuracy:" + (Stats.hitbullets * 100f / Stats.totalbullets).ToString("0.00") + "%";
        yield return new WaitForSeconds(1.0f);

        deaths.text = "Total Deaths:" + Stats.deaths.ToString();
        yield return new WaitForSeconds(1.0f);

        kills.text = "Total kills:" + Stats.kills.ToString();
        yield return new WaitForSeconds(1.0f);

        Timetaken.text = "Completion Time:" + Time.timeSinceLevelLoad.ToString("0");

        yield return new WaitForSeconds(5.0f);

        reset();
        Stats.deaths = 0;

        int rand = Random.Range(6, 9);
        if (rand != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(rand);
        }
        else
        {
            if (rand == 6)
            {
                SceneManager.LoadScene(rand + 1);
            }
            else if (rand == 7)
            {
                SceneManager.LoadScene(rand - 1);
            }
            else if (rand == 8)
            {
                SceneManager.LoadScene(rand - 1);
            }
        }
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void reset()
    {
        Stats.damagedealt = 0;
        Stats.damagedone = 0;
        Stats.healthRegained = 0;
        Stats.totalbullets = 0;
        Stats.hitbullets = 0;
        Stats.kills = 0;
    }

}
