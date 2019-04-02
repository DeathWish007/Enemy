using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTopRotate : MonoBehaviour
{
    public Transform pos;
    public float rotatespeed;
    float input;
    private void Awake()
    {
        input = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            input = 1f;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            input = -1f;
        }
    }

    void FixedUpdate()
    {
        transform.RotateAround(pos.position, -input*Vector3.forward, rotatespeed * Time.deltaTime);

    }
}
