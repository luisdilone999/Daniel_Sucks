using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMovement : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.up * Time.deltaTime * MovementSpeed;
    }

    void OnTriggerEnter2D(Collider2D col){
        player.HandleTrigger(col);
    }
}
