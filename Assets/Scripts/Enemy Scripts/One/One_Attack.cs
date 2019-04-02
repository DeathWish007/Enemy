using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Attack : MonoBehaviour {

    Vector3 dirtolook;
    Transform player;
   // float time;

    public GameObject bullet;
    public bool isSecondary;
    public float shootcircle;

    [Range(1.0f, 20.0f)]
     public float speed;

    [Header("Primary Attack")]
     public float primaryfirerate;
     private float timebtwprimary;

    [Header("Secondary Attack")]
    public float secondaryfirerate;
    private float timebtwsecondary;
    public GameObject first;
    public GameObject second;
    public GameObject third;

    public EnemyHealth eh;
    void Start ()
    {

        isSecondary = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timebtwsecondary = 0;
        //time = Time.time;
    }


    void Update ()
    {
        dirtolook = (player.position - transform.position).normalized;
        LookPlayer();
        if (Vector2.Distance(transform.position, player.position) < shootcircle)
        {

            if (isSecondary == false)
            {
                PrimaryAttack();
            }

            if (eh.healthperc<0.5f)
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
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector3(dirtolook.x + Random.Range(-0.1f, 0.1f), dirtolook.y + Random.Range(-0.1f, 0.1f), 0f) * speed;
            temp.GetComponent<EnemyBullet>().damage = 2f;
            temp.GetComponent<EnemyBullet>()._tag = "One";
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
           
            GameObject temp1 = Instantiate(bullet, first.transform.position, first.transform.rotation);
            temp1.GetComponent<Rigidbody2D>().velocity = -first.transform.up * speed ;
            temp1.GetComponent<EnemyBullet>().damage = 2f;
            temp1.GetComponent<EnemyBullet>()._tag = "One";

            GameObject temp2 = Instantiate(bullet, second.transform.position, second.transform.rotation);
            temp2.GetComponent<Rigidbody2D>().velocity=-second.transform.up * speed ;
            temp2.GetComponent<EnemyBullet>().damage = 2f;
            temp2.GetComponent<EnemyBullet>()._tag = "One";

            GameObject temp3 = Instantiate(bullet, third.transform.position, third.transform.rotation);
            temp3.GetComponent<Rigidbody2D>().velocity=-third.transform.up * speed ;
            temp3.GetComponent<EnemyBullet>().damage = 2f;
            temp3.GetComponent<EnemyBullet>()._tag = "One";



            timebtwsecondary = secondaryfirerate;


        }
        else if(timebtwsecondary>0)
        {
            timebtwsecondary -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootcircle);
    }
}
