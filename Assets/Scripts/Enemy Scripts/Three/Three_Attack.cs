using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Three_Attack : MonoBehaviour {


    Vector3 dirtolook;
    Transform player;
    float time;
    public float shootcircle;


    [Header("Primary Attack")]
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;


    [Header("Secondary Attack")]
    public GameObject bullet;
    public Transform origin;
    public float speed;
    public float secondaryfirerate;
    private float timebtwsecondary;


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        time = Time.time;
    }

    void Update ()
    {
        dirtolook = (player.position - transform.position).normalized;
        LookPlayer();

        if (Time.time - time > 20f)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);


            SecondaryAttack();
            
        }
    }

    void LookPlayer()
    {
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, -dirtolook);
        rot.x = rot.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 8f * Time.deltaTime);

    }

    void SecondaryAttack()
    {
        if (Vector2.Distance(transform.position, player.position) < shootcircle)
        {
            if (timebtwsecondary <= 0)
            {
                GameObject temp = Instantiate(bullet, origin.position, Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().velocity = new Vector3(dirtolook.x, dirtolook.y, 0f) * speed;
                timebtwsecondary = secondaryfirerate;
            }
            else
            {
                timebtwsecondary -= Time.deltaTime;
            }
        }

       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootcircle);
    }
}
