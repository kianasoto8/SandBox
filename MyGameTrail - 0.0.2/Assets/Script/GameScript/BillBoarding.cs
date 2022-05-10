using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
	Vector3 cameraDir;
	
    void Start()
    {
	
    }

    void Update()
    {
		cameraDir = Camera.main.transform.forward;
		cameraDir.y = 0;
		
		transform.rotation = Quaternion.LookRotation(cameraDir);
    }
}
