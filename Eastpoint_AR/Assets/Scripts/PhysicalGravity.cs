using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalGravity : MonoBehaviour {

    public float x, y, z;

	void Update () {
        transform.LookAt(Input.acceleration + transform.position);
    }
}
