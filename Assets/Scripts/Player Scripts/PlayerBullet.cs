using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float time;
    public LayerMask Walls;
    public LayerMask enemies;

    public GameObject destroyBullet;
    PlayerHealth ph;

    void Start()
    {
        Destroy(gameObject, time);
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.position, .1f, Walls);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Walls"))
            {
                Instantiate(destroyBullet, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }


        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.position, .01f, enemies);

        if (hitInfo2.collider != null)
        {
            if (hitInfo2.collider.CompareTag("One"))
            {
                ph.ModifyHealth(3f);
                hitInfo2.collider.GetComponent<EnemyHealth>().HealthPercentage(20f);
                Stats.healthRegained += 3f;
                Stats.ThealthRegained += 3f;
                Stats.damagedone += 20f;
                Stats.Tdamagedone += 20f;
                Stats.hitbullets++;
                Stats.Thitbullets++;

                Instantiate(destroyBullet, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (hitInfo2.collider.CompareTag("Two"))
            {
                ph.ModifyHealth(2.3f);
                hitInfo2.collider.GetComponent<EnemyHealth>().HealthPercentage(17f);
                Stats.healthRegained += 2.3f;
                Stats.hitbullets++;

                Stats.damagedone += 17f;

                Stats.ThealthRegained += 2.3f;
                Stats.Thitbullets++;

                Stats.Tdamagedone += 17f;
                Instantiate(destroyBullet, transform.position, transform.rotation);

                Destroy(gameObject);
            }
            if (hitInfo2.collider.CompareTag("Four"))
            {
                ph.ModifyHealth(1.8f);
                hitInfo2.collider.GetComponent<EnemyHealth>().HealthPercentage(14f);
                Stats.damagedone += 14f;
                Stats.healthRegained += 1.8f;
                Stats.hitbullets++;

                Stats.Tdamagedone += 14f;
                Stats.ThealthRegained += 1.8f;
                Stats.Thitbullets++;
                Instantiate(destroyBullet, transform.position, transform.rotation);

                Destroy(gameObject);
            }
            if (hitInfo2.collider.CompareTag("Five"))
            {
                ph.ModifyHealth(1.1f);
                hitInfo2.collider.GetComponent<EnemyHealth>().HealthPercentage(10f);
                Stats.damagedone += 10f;
                Stats.healthRegained += 1.1f; Stats.hitbullets++;

                Stats.Tdamagedone += 10f;
                Stats.ThealthRegained += 1.1f; Stats.Thitbullets++;
                Instantiate(destroyBullet, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }
}
