using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawineMovement : MonoBehaviour
{
    public static bool Moving = true;

    [SerializeField] private float speed = 1;
    [SerializeField] private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        Moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            this.transform.Translate(0, 0, -speed * Time.deltaTime * Mathf.Clamp(Time.timeSinceLevelLoad / 5, 0.5f, 1000000000));
        }
    }
}
