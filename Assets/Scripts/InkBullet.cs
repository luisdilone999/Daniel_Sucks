using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

}
