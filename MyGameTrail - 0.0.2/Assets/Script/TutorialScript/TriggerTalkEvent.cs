using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTalkEvent : MonoBehaviour
{
	[SerializeField]
    private Transform[] waypoints;
	public int speed;
	
	private int waypointIndex = 0;
	private float dist;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
		if(dist < 1f)
		{
			IncreaseIndex();
		}
		Patrol();
        
    }
	
	private void OnTriggerEnter3D(Collider other)
    {
		if(other.tag == "Trigger")
		{
			waypointIndex++;
			Debug.Log("U Suck!");
		}
        //player.destination = GetComponent<WayPointTutorial>().myQuest();
    }
	void Patrol()
	{
		transform.Translate(Vector3.forward* speed* Time.deltaTime);
	}
	
	void IncreaseIndex()
	{
		if(waypointIndex >= waypoints.Length)
		{
			waypointIndex = 0;
		}
		transform.LookAt(waypoints[waypointIndex].position);
	}
}
