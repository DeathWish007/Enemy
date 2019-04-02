using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Four_Attack : MonoBehaviour {

    Vector3 dirtolook;
    Transform player;
   // float time;
    public GameObject homingMissile;
    public GameObject bullet;

    public bool isSecondary;
    public float shootcircle;

    [Range(1.0f, 40f)]
    public float speed;

    [Header("Primary Attack")]
    public float primaryfirerate;
    private float timebtwprimary;

    [Header("Secondary Attack")]
    public float secondaryfirerate;
    private float timebtwsecondary;
    public Transform first;
    public Transform second;

    public EnemyHealth eh;
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // time = Time.time;
        isSecondary = false;

    }

    void Update ()
    {
        dirtolook = (player.position - transform.position).normalized;
        LookPlayer();

        if (Vector2.Distance(transform.position, player.position )< shootcircle)
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
             Instantiate(homingMissile,first.position , transform.rotation);
             Instantiate(homingMissile, second.position, transform.rotation);

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
            GameObject temp1 = Instantiate(bullet, first.position, first.rotation);
            temp1.GetComponent<Rigidbody2D>().AddRelativeForce(first.transform.up * speed * 20f, ForceMode2D.Force);
            temp1.GetComponent<EnemyBullet>().damage = 4f;
            temp1.GetComponent<EnemyBullet>()._tag = "Four";


            GameObject temp2 = Instantiate(bullet, second.position, first.rotation);
            temp2.GetComponent<Rigidbody2D>().AddRelativeForce(second.transform.up * speed * 20f, ForceMode2D.Force);
            temp2.GetComponent<EnemyBullet>().damage = 4f;
            temp2.GetComponent<EnemyBullet>()._tag = "Four";


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
