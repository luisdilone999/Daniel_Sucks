using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmGame : MonoBehaviour
{
    public Vector3 center;
    public Transform cursor;
    public Transform target;
    public KeyCode key1 = KeyCode.P;
    public KeyCode key2 = KeyCode.W;
    public KeyCode key3 = KeyCode.E;

    public float distance = 0;
    public int score = 0;
    private Rigidbody2D cursor_vel;
    private Rigidbody2D target_vel;
    private int dir = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        center = this.transform.position;
        cursor = this.transform.Find("Cursor");
        target = this.transform.Find("Target");
        cursor_vel = cursor.gameObject.GetComponent<Rigidbody2D>();
        target_vel = target.gameObject.GetComponent<Rigidbody2D>();
        cursor_vel.velocity = new Vector2(1f,0);
        target_vel.velocity = new Vector2(-1f,0);
    }

    // Update is called once per frame
    void Update()
    {


        distance =  cursor.position.x - target.position.x;
        if(Input.GetKey(KeyCode.P)){
            float speed = cursor_vel.velocity.x;
            if (Mathf.Abs(distance) < 1f){
                if (Mathf.Abs(speed * 1.1f) <16f){
                    ChangeSpeed(1.1f);
                    Debug.Log("HIT");
                }
                score += 1; 
            }else{
                if(Mathf.Abs(speed * 0.6f) > 0.1f){
                    ChangeSpeed(0.6f); 
                    score -= 1;
                }
            }
            // Debug.Log(score);
        }
    }

    public void ChangeSpeed(float dv){
        float vx = cursor_vel.velocity.x;
        cursor_vel.velocity = new Vector2(vx * dv ,0);
    }
    public void ChangeDir(string obj){
        if (obj == "Cursor"){
            float speed = cursor_vel.velocity.x;
            dir *= -1;
            cursor_vel.velocity = new Vector2(speed*-1,0);
        }
        else if (obj == "Target"){
            float speed = target_vel.velocity.x;
            target_vel.velocity = new Vector2(speed*-1,0);
        }
    }
     
}
