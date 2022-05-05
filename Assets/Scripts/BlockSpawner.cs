using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public GameObject itemPrefab;
    public GameObject theInk1;
    public GameObject theInk2;
    public GameObject theInk3;
    public GameObject theSquid;
    public float timeSpawn = 2f;
    public float timeWaves = 2f;

    public int itemWave = 5;
    public int score = -1;
    public int items = 0;

    
    void Update() {
        if(Input.GetKeyDown(KeyCode.Period) && items != 0) { 
            if (items != 0) {
                items -= 1;

                SquidInk squid = theSquid.GetComponent<SquidInk>();

                squid.Shoot();
            }

            if (items == 0) {
                theInk1.SetActive(false);
            }

            if (items == 1) {
                theInk2.SetActive(false);
            }

            if (items == 2) {
                theInk3.SetActive(false);
            }
        }

        if (Time.time >= timeSpawn) {
            timeSpawn = Time.time + timeWaves;

            timeWaves -= 0.05f;
            timeWaves = Mathf.Max(1.25f, timeWaves);

            score += 1;

            Spawner();
        }
    }

    void Spawner() {
        int randomNumber1 = Random.Range(0, spawnPoints.Length);
        int randomNumber2 = Random.Range(0, spawnPoints.Length);
        if(Mathf.Abs(randomNumber1 - randomNumber2) == 1) {
            if(randomNumber1 > randomNumber2) {
                if(randomNumber1 != 5) {
                    randomNumber1 += 1;
                }
                else {
                    randomNumber2 -= 1;
                }
            } 
            else {
                if(randomNumber2 != 5) {
                    randomNumber2 += 1;
                }
                else {
                    randomNumber1 -= 1;
                }
            }
        }

        float choice = Random.value;
        for(int i = 0; i < spawnPoints.Length; i++) {
            if(randomNumber1 != i && randomNumber2 != i) {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }

            else if(score % itemWave == 0 && score != 0) {
                if(choice < 0.5f) {
                    Instantiate(itemPrefab, spawnPoints[randomNumber1].position, Quaternion.identity);
                }
                else {
                    Instantiate(itemPrefab, spawnPoints[randomNumber2].position, Quaternion.identity);
                }
            }
        }
    }
}
