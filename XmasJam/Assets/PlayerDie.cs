using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.Sleep();
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            LawineMovement.Moving = false;
            collision.gameObject.GetComponent<OpenGameOverScreen>().OpenPanel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            rigidbody.Sleep();
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            LawineMovement.Moving = false;
            other.gameObject.GetComponent<OpenGameOverScreen>().OpenPanel();
        }
    }
}
