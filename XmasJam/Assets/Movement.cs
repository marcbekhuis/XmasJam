using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
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
    }

    private void Rotate()
    {
        rigidbody.transform.eulerAngles = new Vector3(rigidbody.transform.eulerAngles.x, Input.GetAxis("Horizontal") * 10, rigidbody.transform.eulerAngles.z);
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * -5, rigidbody.velocity.y, rigidbody.velocity.z);
    }
}
