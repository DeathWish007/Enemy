using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    public float firerate;
    private float timebtwfire;
    public float movespeed;
    public GameObject PlayerBullet;

    public Animator cursorIn;
    public Animator cursorOut;

    public static bool canShoot=true;
	void Start ()
    {
        timebtwfire = 0f;
	}
	
	void Update ()
    {
        LookAtCursor();
 

        if (Input.GetMouseButtonDown(0))
        {
            PlayerShoot();
            cursorIn.SetBool("Shot", true);
            cursorOut.SetBool("Shot", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorIn.SetBool("Shot", false);
            cursorOut.SetBool("Shot", false);
        }

    }
    void LookAtCursor()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dirtolook = (mousepos - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, dirtolook);
        rot.x = rot.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 100f * Time.deltaTime);
    }

    void PlayerShoot()
    {
        if (canShoot == true)
        {
            if (timebtwfire <= 0)
            {
                GameObject temp = Instantiate(PlayerBullet, transform.position, transform.rotation);
                Stats.totalbullets++;
                Stats.Ttotalbullets++;
                temp.GetComponent<Rigidbody2D>().velocity = temp.transform.up * movespeed;


                timebtwfire = firerate;
            }
            else
            {
                timebtwfire -= firerate;

            }
        }
        
    }
}
