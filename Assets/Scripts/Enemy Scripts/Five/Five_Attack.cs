using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five_Attack : MonoBehaviour {

    Vector3 dirtolook;
    Transform player;
   // float time;
    public GameObject bullet;
    public bool isSecondary;
    private Vector3 startpoint;
    public float shootcircle;


    [Header("Primary Attack")]
    public float primaryfirerate;
    private float timebtwprimary;


    [Header("Secondary Attack")]
    public float secondaryfirerate;
    private float timebtwsecondary;
    public float speed;
    public GameObject secbullet;
    public float numberofBullets;

    public EnemyHealth eh;
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // time = Time.time;
        isSecondary = false;

    }



    void Update ()
    {
        startpoint = transform.position;
        dirtolook = (player.position - transform.position).normalized;
        LookPlayer();

        if (Vector2.Distance(transform.position, player.position) < shootcircle)
        {
            if (isSecondary == false)
            {
                PrimaryAttack();
            }

            if (eh.healthperc<=0.5f)
            {
                isSecondary = true;
                if (isSecondary)
                {
                    SecondaryAttack();
                }
            }
        }

        
    }
    void LookPlayer()
    {
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, -dirtolook);
        rot.x = rot.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 8f * Time.deltaTime);

    }

    void PrimaryAttack()
    {
        if (timebtwprimary <= 0)
        {
           Instantiate(bullet, transform.position, transform.rotation);
           timebtwprimary = primaryfirerate;
        }
        else
        {
            timebtwprimary -= Time.deltaTime;
        }
    }

    void SecondaryAttack()
    {
        if (timebtwsecondary <= 0)
        {
            float bulpos = 360f / numberofBullets;
            float angle = 0f;

            for (int i = 0; i <= numberofBullets-1; i++)
            {
                float xdir = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180 );
                float ydir = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180 );

                Vector3 direction = new Vector3(xdir, ydir, 0f);
                Vector3 move = (direction - startpoint).normalized * speed;
                GameObject temp = Instantiate(secbullet, startpoint, transform.rotation);
                temp.GetComponent<Rigidbody2D>().AddRelativeForce((new Vector3(move.x, move.y, 0f)) * 90f, ForceMode2D.Force);
                temp.GetComponent<EnemyBullet>().damage = 3f;
                temp.GetComponent<EnemyBullet>()._tag = "Five";

                angle += bulpos;

                timebtwsecondary = secondaryfirerate;
            }
        }
        else
        {
            timebtwsecondary -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootcircle);
    }
}
