using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseScreen : MonoBehaviour
{
   public static bool ispaused = false;
    public GameObject PauseImage;
    public Text _Menu;
    public Text _Exit;

    Color mencol;
    Color exicol;
    public Animator menu;
    public Animator exit;

    public bool canPress;
    void Start()
    {
        mencol = _Menu.color;
        exicol = _Exit.color;

        _Menu.color = new Color(135f,135f,135f,0f);
        _Exit.color = new Color(135f,135f,135f,0f);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused == false)
            {
                PauseImage.SetActive(true);
                _Menu.color = mencol;
                _Exit.color = exicol;

                canPress = true;
                menu.SetBool("Pressed", false);
                exit.SetBool("Pressed", false);
                PlayerGun.canShoot = false;
                PlayerMovement.canMove = false;
                EnemyMovement.canMove = false;
                ispaused = true;
            }
            else if (ispaused == true)
            {
                PauseImage.SetActive(false);
                //pauseMenu.SetActive(false);
                _Menu.color = new Color(135f, 135f, 135f, 0f);
                _Exit.color = new Color(135f, 135f, 135f, 0f);
                canPress = false;
                menu.SetBool("Pressed", true);
                exit.SetBool("Pressed", true);
                PlayerGun.canShoot = true;
                PlayerMovement.canMove = true;
                EnemyMovement.canMove = true;
                ispaused = false;
            }
        }
    }


}
