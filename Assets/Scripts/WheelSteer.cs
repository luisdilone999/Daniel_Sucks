using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSteer : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private float rotationSpeed;

    public float inertia = 1;

    public int rotateDir = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.X)) {
            rotationSpeed += 1;

        }
        if (Input.GetKey(KeyCode.Z)) {
            rotationSpeed -= 1;
        } 

        transform.eulerAngles += rotateDir * Vector3.forward * (-rotationSpeed * inertia) * Time.deltaTime;


    }
}
