using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacaManager : MonoBehaviour
{
	Animator anim;
	public Dialogue dialogueMissao8;
	public Dialogue dialogueMissao11;
	bool dentro = false;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
    void OnTriggerEnter2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player")
		{
			anim.SetBool("PlayerClose", true);
			dentro = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D player)
	{
		if (player.gameObject.tag == "Player")
		{
			anim.SetBool("PlayerClose", false);
			dentro = false;
		}
	}
	
	public void TaDentro()
	{
		if (dentro == true)
		{
			TriggerDialogue();
		}
	}
	
	private void TriggerDialogue()
	{
		//ver qual Dialogue chamar
		FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao8);
	}
	
	
}
