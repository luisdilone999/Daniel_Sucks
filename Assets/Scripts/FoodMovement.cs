using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    public int MovementSpeed = 5;
    public Vector3 dir;
    public float dir_timeout;
    // Start is called before the first frame update
    void Start()
    {
        dir = RandomVector(-1, 1);
        dir_timeout = Random.Range(5,15);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * MovementSpeed;

        if (dir_timeout > 0)
        {
            dir_timeout -= Time.deltaTime;
        } else {
            dir = RandomVector(-1, 1);
            dir_timeout = Random.Range(5, 15);
        }
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        
        return new Vector3(x, y,0);
    }

}
