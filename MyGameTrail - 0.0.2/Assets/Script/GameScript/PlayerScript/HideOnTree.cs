using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnTree : MonoBehaviour
{
    public KeyCode keyToHide;

    public float offSetHide;

    public bool hiding;

    public Rigidbody rb;

    private GameObject treeHiding;

    public float timeToStopHiding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (hiding && Input.GetKeyDown(keyToHide)) // IF IM HIDING AND I WANT TO STOP HIDING
        {
            //I CHECK THE POSITION OF MY PARENT AND I SAVE IT IN ANOTHER VARIABLE
            Vector3 treePosition = treeHiding.GetComponentInParent<Transform>().position;

            //I PUT THE PLAYER BACK TO THE NORMAL POSITION AND I PUT THE TREE BEHAVIOURS BACK
            transform.position = new Vector3(treePosition.x + 0.5f, 0f, treePosition.z);
            treeHiding.GetComponentInParent<BillBoarding>().enabled = true;
            rb.useGravity = true; //TURN ON AGAIN GRAVITY


            hiding = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hide"))
            if (Input.GetKeyDown(keyToHide) && !hiding)
            // IF YOU PRESS THE KEY YOU SELECT ON INSPECTOR AND THE CHARACTER IS NOT HIDING
            {
                treeHiding = other.gameObject; //I SAVE THE TREE WHERE IM HIDING SO I CAN ENABLE EVERYTHING BACK WHEN I STOP HIDDING 
                transform.position = new Vector3(other.transform.position.x - 0.5f, other.transform.position.y + offSetHide, other.transform.position.z);
                other.GetComponentInParent<BoxCollider>().isTrigger = true; // I ADDED THIS SO I DONT GET MOVED BY THE TREE WHEN IM ABOVE IT
                other.GetComponentInParent<BillBoarding>().enabled = false; // AND I'VE TO DISABLE THIS SCRIPT SO IT DOESNT LOOK BAD
                StartCoroutine(WaitToStopHiding()); // I MADE THIS COROUTINE SO I CAN WAIT SOME SECONDS BEFORE I CAN STOP HIDING
                rb.velocity = Vector3.zero; // I DO THIS SO HE CANT MOVE WHILE ITS HIDING BUT HE CAN USE THE CAMERA
                rb.useGravity = false; //AND THIS SO IT DOESNT FALL
            }
    }

    IEnumerator WaitToStopHiding()
    {
        yield return new WaitForSeconds(timeToStopHiding);
        hiding = true;
    }
}
