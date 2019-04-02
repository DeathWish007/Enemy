using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private static List<Rigidbody2D> Enemies; 

    private Transform player;
    public float stopdistance;
    public float backdistance;
    Vector2 newpos;

    Vector2 direction;

    public float speed;
    public float movecircle;
    Rigidbody2D rb;

    public static bool canMove = true;

    //public LayerMask playerMask;
    private void Awake()
    {
       // Physics2D.queriesStartInColliders = false;
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Enemies == null)
        {
            Enemies= new List<Rigidbody2D>();
        }

        Enemies.Add(rb);


    }

    void FixedUpdate ()
    {
        // direction = (transform.position - player.position);
        if (canMove == true)
        {
            if (Vector2.Distance(transform.position, player.position) < movecircle)
            {
                if (Vector2.Distance(transform.position, player.position) > stopdistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, player.position) > stopdistance && Vector2.Distance(transform.position, player.position) < backdistance)
                {
                    transform.position = this.transform.position;

                }
                else if (Vector2.Distance(transform.position, player.position) < backdistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

                }

            }
        }
        

        /* RaycastHit2D raycast = Physics2D.Raycast(transform.position, -direction, 50f);
         if (raycast.collider != null)
         {
             Debug.Log(raycast.collider);
         }
        float distance = Vector2.Distance(transform.position, player.position);

        if (!Physics2D.Raycast(transform.position, -direction, distance, playerMask))
        {
            Debug.Log("DoNotShoot");
        }
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, movecircle);
    }

    void CheckCollision()
    {

        foreach (Rigidbody2D enemy in Enemies)
        {
            if (enemy == rb)
                continue;

        }
        

    }


}
