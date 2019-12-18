using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickUp : MonoBehaviour
{
    [SerializeField] private int cash = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScore>().AddCash(cash);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerScore>().AddCash(cash);
            Destroy(this.gameObject);
        }
    }
}
