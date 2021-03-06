using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour
{
	public Transform agentGoal;
    private UnityEngine.AI.NavMeshAgent nmAgent;

    void Start()
    {
        nmAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter3D(Collider other)
    {
        Debug.Log("Game Over");
    }

    private void FollowPlayer()
    {
        if (!agentGoal.GetComponent<HideOnTree>().hiding) //IF PLAYER IS NOT HIDING
        {
            nmAgent.enabled = true;
            nmAgent.destination = agentGoal.position;
        }
        else //IF PLAYER IS HIDING NAV MESH STOPS WORKING 
		{
			//nmAgent.enabled = false;
			nmAgent.destination = GetComponent<RedWaypoints>().currWay();
		}
    }
}