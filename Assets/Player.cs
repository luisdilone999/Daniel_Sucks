using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int size;
    public bool can_land;
    public GameObject squid;
    public Transform land;
    public Camera mini_cam;
    public Camera spec_cam;

        //     points += 1;
        // Debug.Log(points);
        // Destroy(col.gameObject);
        // this.transform.localScale += new Vector3(.3f, .3f, .3f);
    // Start is called before the first frame update
    void Start()
    {
        size = 1;
        can_land = false;
        squid = this.transform.Find("Squid").gameObject;
        mini_cam = this.transform.Find("MiniCam").GetComponent<Camera>();
        spec_cam = this.transform.Find("SpecCam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleTrigger(Collider2D col){
        if (col.gameObject.tag == "land"){
            if (!can_land){
                // squid.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
        }
        else if (col.gameObject.tag == "food"){
            size += 1;
            Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0);
            squid.transform.localScale += scaleChange;
            mini_cam.orthographicSize += 1;
            spec_cam.orthographicSize += 1;
            Destroy(col.gameObject);

            if(size > 1){
                can_land = true;
                foreach (Transform child in land){
                    PolygonCollider2D child_col = child.gameObject.GetComponent<PolygonCollider2D>();
                    child_col.isTrigger = true;
                }
            }
        }
    }

    public void push(){
        float speed = 10f * (size/2 + 1);
        squid.GetComponent<Rigidbody2D>().AddForce(squid.transform.up * speed);
    }
}
