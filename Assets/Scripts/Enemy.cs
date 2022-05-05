using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform squid;
    public float health = 100;
    public float maxHealth = 100;
    public float detectionDist;

    public float MovementSpeed = 0.5f;
    public Vector3 dir;
    public float dir_timeout;
    // Start is called before the first frame update
    void Start()
    {
        dir = RandomVector(-1, 1);
        var angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        dir_timeout = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, squid.position);

        if (dist < detectionDist) //If close to player CHASE!
        {
            this.transform.right = -(squid.position - this.transform.position);
            this.transform.position = Vector3.MoveTowards(this.transform.position, squid.transform.position, Time.deltaTime * MovementSpeed);


        }
        else
        {
            transform.position += dir * Time.deltaTime * MovementSpeed;

            if (dir_timeout > 0)
            {
                dir_timeout -= Time.deltaTime;
            }
            else
            {
                dir = RandomVector(-1, 1);
                var angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                dir_timeout = Random.Range(5, 15);
            }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);

        return new Vector3(x, y, 0);
    }

}

