﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
    [SerializeField]
    float speed = 25.0F;
    [SerializeField]
    float rotationSpeed = 50.0F;

    void Start(){
        rb = this.GetComponent<Rigidbody>();
    }
	
    // Update is called once per frame
	void Update () {
	
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f,rotation,0f);
        rb.MovePosition(rb.position + this.transform.forward * translation);
        rb.MoveRotation(rb.rotation * turn);
	}
}