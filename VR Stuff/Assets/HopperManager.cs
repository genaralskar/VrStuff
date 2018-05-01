using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HopperManager : MonoBehaviour {


	public Inventory inventory;
	public string hopperItemTag;

	public Text amountText;
	private int amount = 0;


	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == hopperItemTag)
		{
		//	inventory.Add(other.gameObject);
		//	other.gameObject.SetActive(false);
			IncrementScore();
			AddItem(other.gameObject);
		}
	}

	void IncrementScore()
	{
		amount++;
		amountText.text = "Cubes: " + amount.ToString();
	}

	void AddItem(GameObject _gameObj)
	{
		print(_gameObj);
		inventory.AddItem(_gameObj);
	}

}