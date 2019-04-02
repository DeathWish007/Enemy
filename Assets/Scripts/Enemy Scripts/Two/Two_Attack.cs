using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two_Attack : MonoBehaviour {

    Vector3 dirtolook;
    Transform player;
    //float time;
    public bool isSecondary;
    [Range(1.0f, 15.0f)]
    public float speed;
    public float shootcircle;


    [Header("Primary Attack")]
    public float primaryfirerate;
    private float timebtwprimary;
    public GameObject bullet;


    [Header("Secondary Attack")]
    //public float angle;
    public float secondaryfirerate;
    private float timebtwsecondary;
    //public float frequency;
    //public float amplitude;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;

    public EnemyHealth eh;

    void Start ()
    {

        isSecondary = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timebtwsecondary = 0;
        //time = Time.time;
    }


    void FixedUpdate()
    {
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
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector3(dirtolook.x + Random.Range(-0.05f, 0.02f), dirtolook.y + Random.Range(-0.02f, 0.05f), 0f) * speed;
            temp.GetComponent<EnemyBullet>().damage = 3f;
            temp.GetComponent<EnemyBullet>()._tag = "Two";

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
            temp1.GetComponent<Rigidbody2D>().velocity = -first.transform.up * speed;
            temp1.GetComponent<EnemyBullet>().damage = 3f;
            temp1.GetComponent<EnemyBullet>()._tag = "Two";

            GameObject temp2 = Instantiate(bullet, second.transform.position, second.transform.rotation);
            temp2.GetComponent<Rigidbody2D>().velocity = -second.transform.up * speed;
            temp2.GetComponent<EnemyBullet>().damage = 3f;
            temp2.GetComponent<EnemyBullet>()._tag = "Two";

            GameObject temp3 = Instantiate(bullet, third.transform.position, third.transform.rotation);
            temp3.GetComponent<Rigidbody2D>().velocity = -third.transform.up * speed;
            temp3.GetComponent<EnemyBullet>().damage = 3f;
            temp3.GetComponent<EnemyBullet>()._tag = "Two";

            GameObject temp4 = Instantiate(bullet, fourth.transform.position, fourth.transform.rotation);
            temp4.GetComponent<Rigidbody2D>().velocity = -fourth.transform.up * speed;
            temp4.GetComponent<EnemyBullet>().damage = 3f;
            temp4.GetComponent<EnemyBullet>()._tag = "Two";

            GameObject temp5 = Instantiate(bullet, fifth.transform.position, fifth.transform.rotation);
            temp5.GetComponent<Rigidbody2D>().velocity = -fifth.transform.up * speed;
            temp5.GetComponent<EnemyBullet>().damage = 3f;
            temp5.GetComponent<EnemyBullet>()._tag = "Two";

            timebtwsecondary = secondaryfirerate;
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
