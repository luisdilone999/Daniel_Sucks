using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * MovementSpeed;
    }

    void OnTriggerEnter2D(Collider2D col){
        points += 1;
        Debug.Log(points);
        Destroy(col.gameObject);
        this.transform.localScale += new Vector3(.3f, .3f, .3f);
    }
}
