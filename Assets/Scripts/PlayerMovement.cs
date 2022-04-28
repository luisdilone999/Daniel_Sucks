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
    // public Text scoreText;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 newPosition = transform.position;

        if(Input.GetKeyDown(KeyCode.Comma)){
            newPosition.x -= laneLength;
        }
        if(Input.GetKeyDown(KeyCode.Slash)){
            newPosition.x += laneLength;
        }

        newPosition.x = Mathf.Max(Mathf.Min(newPosition.x, centerscreen + screenwidth), centerscreen - screenwidth);

        transform.position = newPosition;
        // rb.MovePosition(newPosition);
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision) {
        // scoreText.text = "0";
        BlockSpawner spawner = theSpawner.GetComponent<BlockSpawner>();
        var cubeRenderer = thePlayer.GetComponent<Renderer>();

        if (collision.gameObject.tag == "ink") {
            spawner.items += 1;

            cubeRenderer.material.SetColor("_Color", Color.blue);
            yield return new WaitForSeconds(0.05f);
            cubeRenderer.material.SetColor("_Color", Color.white);
        }

        else {
            spawner.score = -1;
            spawner.items -= 1;
            spawner.timeWaves = 2f;


            cubeRenderer.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(0.5f);
            cubeRenderer.material.SetColor("_Color", Color.white);
        }

        Destroy(collision.gameObject);
    }

/*
    IEnumerator RestartLevel() {
        Time.timeScale = 1f/slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime/slowness;

        yield return new WaitForSeconds(1f/slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime*slowness;

        BlockSpawner spawner = theSpawner.GetComponent<BlockSpawner>();
        spawner.score = -1;
        spawner.items -= 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
*/
}
