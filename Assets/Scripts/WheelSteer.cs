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
    public AudioSource LeftSpin;
    public AudioSource RightSpin;
    public bool firstPressR = true;
    public bool firstPressL = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.X)) {
            firstPressL = true;
            if (firstPressR)
            {
                RightSpin.Play();
                firstPressR = false;
            }   
            rotationSpeed += 1;

        }
        if (Input.GetKey(KeyCode.Z)) {
            firstPressR = true;
            if (firstPressL)
            {
                LeftSpin.Play();
                firstPressL = false;
            }
            rotationSpeed -= 1;
        } 

        transform.eulerAngles += rotateDir * Vector3.forward * (-rotationSpeed * inertia) * Time.deltaTime;


    }
}
