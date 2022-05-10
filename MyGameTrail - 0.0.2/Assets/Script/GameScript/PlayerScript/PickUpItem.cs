using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
	public int logCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       	gameOver();
    }
	
	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Log")
		{
			if(Input.GetKey("e"))
			{
				Destroy(other.gameObject);
				logCount++;
			}
		}
		else if(other.tag == "Enemy")
		{
			logCount--;
		}
	}
	
	public void gameOver()
	{
		if(logCount == 5)
		{
			SceneManager.LoadScene("Town");
		}
		else if(logCount <= -1)
		{
			SceneManager.LoadScene("Menu");
		}
		
	}
}