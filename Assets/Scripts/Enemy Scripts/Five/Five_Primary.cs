using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five_Primary : MonoBehaviour
{


    [Range(1.0f, 20.0f)]
    public float speed;
    Transform player;
    Vector2 hitit;


    public LayerMask playerMask;

    public GameObject explosionEffect;

    public float explosionRange;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hitit = new Vector2(player.position.x, player.position.y);
    }



    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, transform.position.y, 0f), hitit, speed * Time.deltaTime);



      


        if ((Vector2)transform.position == hitit)
        {
            Collider2D[] explosionDamage = Physics2D.OverlapCircleAll(transform.position, explosionRange);
            for (int i = 0; i < explosionDamage.Length; i++)
            {
                explosionDamage[i].GetComponent<PlayerHealth>().ModifyHealth(-4f);
                Stats.damagedealt += 4f;
                Stats.Tdamagedealt += 4f;
            }

            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}