using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    public Transform pos;
    public float rotatespeed;

	
	void Update () {
        transform.RotateAround(pos.position, Vector3.forward, rotatespeed * Time.deltaTime);

    }
}
