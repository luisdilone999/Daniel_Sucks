using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float screenwidth;
    public float centerscreen;
    public float slowness;
    public float laneLength;
    public GameObject theSpawner;
    public GameObject thePlayer;
    public GameObject theInk1;
    public GameObject theInk2;
    public GameObject theInk3;

    private Rigidbody2D rb;
    private bool hasCollided = false;
    private float colliding = 0f;
    private int collidingItems = 0;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (hasCollided) {
            colliding += Time.deltaTime;
        }
        if (colliding > 0.5f) {
            colliding = 0f;
            hasCollided = false;
            collidingItems = 0;
        }
        Vector2 newPosition = transform.position;

        if(Input.GetKeyDown(KeyCode.Comma)){
            newPosition.x -= laneLength;
        }
        if(Input.GetKeyDown(KeyCode.Slash)){
            newPosition.x += laneLength;
        }

        newPosition.x = Mathf.Max(Mathf.Min(newPosition.x, centerscreen + screenwidth), centerscreen - screenwidth);

        transform.position = newPosition;
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision) {     
        hasCollided = true;

        BlockSpawner spawner = theSpawner.GetComponent<BlockSpawner>();
        var cubeRenderer = thePlayer.GetComponent<Renderer>();

        if (collision.gameObject.tag == "ink") {
            Destroy(collision.gameObject);

            if (spawner.items != 3 && collidingItems == 0) {
                spawner.items += 1;
                collidingItems += 1;
            }

            if (spawner.items == 1) {
                theInk1.SetActive(true);
            }

            if (spawner.items == 2) {
                theInk2.SetActive(true);
            }

            if (spawner.items == 3) {
                theInk3.SetActive(true);
            }

            cubeRenderer.material.SetColor("_Color", Color.blue);
            yield return new WaitForSeconds(0.25f);
            cubeRenderer.material.SetColor("_Color", Color.white);
        }

        else {
            spawner.score = -1;
            if (spawner.items != 0 && collidingItems == 0) {
                spawner.items -= 1;
                collidingItems += 1;
            }

            if (spawner.items == 0) {
                theInk1.SetActive(false);
            }

            if (spawner.items == 1) {
                theInk2.SetActive(false);
            }

            if (spawner.items == 2) {
                theInk3.SetActive(false);
            }

            spawner.timeWaves = 2f;


            cubeRenderer.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(0.5f);
            cubeRenderer.material.SetColor("_Color", Color.white);

            Destroy(collision.gameObject);
        }
        
    }

}
