﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maxTurnAngle = 10;
    [SerializeField] private float straveSpeed = 5;
    [SerializeField] private Text speedText;

    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        speedText.text = "Speed: " + -rigidbody.velocity.z;
    }

    private void Rotate()
    {
        rigidbody.transform.eulerAngles = new Vector3(rigidbody.transform.eulerAngles.x, Input.GetAxis("Horizontal") * maxTurnAngle, rigidbody.transform.eulerAngles.z);
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * -straveSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
    }
}
