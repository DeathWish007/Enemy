using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float time;
    //public LayerMask Walls;
   // public LayerMask player;

    public float damage;
    public string _tag;
    private void OnEnable()
    {
        _tag = null;
    }

    void Start()
    {
        Destroy(gameObject, time);
    }

    private void FixedUpdate()
    {
        /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.position, .1f, Walls);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Walls"))
            {
                Destroy(gameObject);
            }
        }

        

        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.position, .1f, player);

        if (hitInfo2.collider != null)
        {
            if (hitInfo2.collider.CompareTag("Player"))
            {
                hitInfo2.collider.GetComponent<PlayerHealth>().ModifyHealth(-damage);

                Destroy(gameObject);
            }
        }
        */

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
                hitenemy.collider.GetComponent<PlayerHealth>().ModifyHealth(-damage);
                Stats.damagedealt += damage;
                Stats.Tdamagedealt += damage;
                Destroy(gameObject);
            }
           if(hitenemy.collider.tag != _tag && _tag!=null)
            {
                Destroy(gameObject);
            }

            /*if ((string)hitenemy.collider.gameObject.tag == (string)_tag || _tag==null)
            {
                Debug.Log(hitenemy.collider.tag);
            }
            else
            {
                Destroy(gameObject);
            }*/
        }

        
    }

}
