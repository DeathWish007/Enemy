using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;
    [Range(0.0f, 1.0f)]
    public float smooth;

    public float boundX;
    public float boundY;

    Vector3 offsetPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 delta = Vector3.zero;

        float dx = player.position.x - transform.position.x;

        if (dx > boundX || dx < -boundX)
        {
            if (transform.position.x < player.position.x)
            {
                delta.x = dx - boundX;
            }
            else
            {
                delta.x = dx + boundX;
            }
        }

        float dy = player.position.y - transform.position.y;

        if (dy > boundY || dy < -boundY)
        {
            if (transform.position.y < player.position.y)
            {
                delta.y = dy - boundY;
            }
            else
            {
                delta.y = dy + boundY;
            }
        }


        offsetPosition = transform.position + delta;
        transform.position = Vector3.Lerp(transform.position, offsetPosition, smooth);
    }
}
