using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour {

    Transform player;
    [Range(-1f,1f)]
    public float right;
    [Range(-1f,1f)]
    public float left;
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
    {
        if (transform.position.x < player.position.x)
        {
            Vector2 change = transform.localScale;
            change.x = right;
            transform.localScale = change;
        }
        else if (transform.position.x > player.position.x)
        {
            Vector2 change = transform.localScale;
            change.x =left;
            transform.localScale = change;
        }
	}
}
