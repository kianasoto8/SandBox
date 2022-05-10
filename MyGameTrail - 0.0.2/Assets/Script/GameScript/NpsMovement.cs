using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpsMovement : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed =1f;
	
	private Rigidbody myRb;
	
	
	void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		myRb.velocity = new Vector3(moveSpeed, 0f, 0f);
	}
}
