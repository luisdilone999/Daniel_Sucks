using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPulse : MonoBehaviour
{
    public Transform pfRadarPing;
    public Transform pulseTransform;
    public Transform squid;
    public float range;
    public float rangeMax = 300f;
    public AudioSource Pong;

    public List<Collider2D> alreadyPingedColliderList;

    private bool radarActive = false;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Q) && !radarActive)
        {
            Pong.Play();
            radarActive = true;
        }

       if (radarActive)
        {
            Ping();
        }
    }

    void Ping()
    {
        float rangeSpeed = 50f;
        range += rangeSpeed * Time.deltaTime;
        if (range > rangeMax)
        {
            range = 0f;
            alreadyPingedColliderList.Clear();
            radarActive = false;
        }

        pulseTransform.localScale = new Vector3(range, range);

        RaycastHit2D[] raycastHit2DArray = Physics2D.CircleCastAll(transform.position, range / 2f, Vector2.zero);
        foreach (RaycastHit2D raycastHit2D in raycastHit2DArray)
        {
            if (raycastHit2D.collider != null)
            {
                if (!alreadyPingedColliderList.Contains(raycastHit2D.collider) && raycastHit2D.transform != squid)
                {
                    alreadyPingedColliderList.Add(raycastHit2D.collider);

                    var radarPing = Instantiate(pfRadarPing, raycastHit2D.point, Quaternion.identity);

                    if (raycastHit2D.collider.gameObject.layer == 10)
                    {
                        radarPing.GetComponent<Renderer>().material.color = Color.green;
                    }
                    if (raycastHit2D.collider.gameObject.layer == 11)
                    {
                        radarPing.GetComponent<Renderer>().material.color = Color.red;
                    }
               
                }
            }
        }
    }
}
