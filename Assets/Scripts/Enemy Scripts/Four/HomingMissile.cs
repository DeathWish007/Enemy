using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float angle;
    Transform player;
    float random;

    string _tag;

    private void OnEnable()
    {
        _tag = "Four";
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        random = Random.Range(1.3f, 2.6f);
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        Vector3 direction = (Vector2)player.position - rb.position;


        float rotate = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotate * angle;

        rb.velocity = transform.up * speed * random;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitenemy = Physics2D.Raycast(transform.position, transform.position, .01f);
        if (hitenemy.collider != null)
        {
            if (hitenemy.collider != null)
            {
                if (hitenemy.collider.CompareTag("Walls"))
                {
                    Destroy(gameObject);
                }
            }

            if (hitenemy.collider.CompareTag("Player"))
            {
                hitenemy.collider.GetComponent<PlayerHealth>().ModifyHealth(-10f);
                Stats.damagedealt += 10f;
                Stats.Tdamagedealt += 10f;
                Destroy(gameObject);
            }
            if (hitenemy.collider.tag != _tag && _tag != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
