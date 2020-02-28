using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMissaoManager : MonoBehaviour
{
	bool dentro = false;
	bool completou = false;
	
	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player")
		{
			dentro = true;
		}
	}

    void OnTriggerExit2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player")
		{
			dentro = false;
		}
	}
	
	public void TaDentro()
	{
		if (dentro == true)
		{
			this.gameObject.SetActive(false);
			completou = true;
		}
	}
	
	public bool Completou()
	{
		return completou;
	}
}
