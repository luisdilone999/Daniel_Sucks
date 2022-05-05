using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMovement : MonoBehaviour
{
    public Player player;
    public float health = 100;
    public float maxHealth = 100;
    public float MovementSpeed = 5f;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.up * Time.deltaTime * MovementSpeed;
    }

    void OnTriggerEnter2D(Collider2D col){
        player.HandleTrigger(col);
    }
}
