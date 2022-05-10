using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
     public int ID;
	public string type;
	public string description;
	public Sprite icon;
	public bool pickedUp;
	
	[HideInInspector]
	public bool equipped;
	
	[HideInInspector]
	public GameObject weapon;
	
	[HideInInspector]
	public GameObject weaponManger;
	
	public bool playerWeapon;
	
	public void Start()
	{
		weaponManger = GameObject.FindWithTag("WeaponManager");
		if(!playerWeapon)
		{
			int allWeapons = weaponManger.transform.childCount;
			for(int i = 0; i < allWeapons; i++)
			{
				if(weaponManger.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
				{
					weapon = weaponManger.transform.GetChild(i).gameObject;
				}
			}
		}
	}
	public void Update()
	{
		if(equipped)
		{
			if(Input.GetKeyDown(KeyCode.G))
				equipped = false;
			
			if(equipped ==false)
				this.gameObject.SetActive(false);
		}
	}
	
	public void ItemUsage()
	{
		if(type == "Weapon")
		{
			weapon.SetActive(true);
			weapon.GetComponent<Item>().equipped = true;
		}
	}
}
