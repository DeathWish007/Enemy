using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtonMover : MonoBehaviour
{
    public Transform MenuCircle;
    public GameObject Game;
    public GameObject Options;
    public GameObject Extras;
    public GameObject Exit;
    public float speed;
     public Camera cam;

    public Color color1;
    public Color color2 ;

    public GameObject fadeoutImage;
    public GameObject fadeInImage;
    public GameObject loadingImage;

    void Start()
    {
    }

    void FixedUpdate()
    {
        Cursor.visible = false;




        float input = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(MenuCircle.position, -Vector3.forward, input * speed * Time.fixedDeltaTime);

        float t = Mathf.PingPong(Time.time, 3f) / 3f;
        cam.backgroundColor = Color.Lerp(color1, color2, t);
#pragma warning disable
        if (Game.active)
        {
          
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //string level=RandomLevelSelector.ReturnLevel();
                int level = Random.Range(6, 9);
                StartCoroutine(FadeOut(level));
            }
        }
#pragma warning disable
        if (Exit.active)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Application.Quit();
            }
        }

        if (Options.active)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Options");
            }
        }
        if (Extras.active)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Extras");
            }
        }
    }

    IEnumerator FadeOut(int level)
    {
        fadeoutImage.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        loadingImage.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        fadeInImage.SetActive(true);
        loadingImage.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(level);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Game"))
        {
            Game.SetActive(true);
            
        }
        else
        {
            Game.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Options"))
        {
            Options.SetActive(true);
        }
        else
        {
            Options.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Extras"))
        {
            Extras.SetActive(true);
        }
        else
        {
            Extras.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            Exit.SetActive(true);
        }
        else
        {
            Exit.SetActive(false);
        }
    }

}
