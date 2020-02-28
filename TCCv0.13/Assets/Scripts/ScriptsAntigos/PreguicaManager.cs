using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreguicaManager : MonoBehaviour
{
	public Dialogue dialogueMissao1;
	//public Dialogue dialogueMissao4;
	public Dialogue dialogueFimMissao1;
	//public Dialogue dialogueFimMissao4;
	public ItemMissaoManager arvore;
	//public ItemMissaoManager arvore2;
	
	Animator anim;
	bool dentro = false;
	private bool completouMissao1 = false;
	private bool pegouItem1 = false;
	//private bool completouMissao4 = false;
	//private bool pegouItem2 = false;
	
    // Start is called before the first frame update
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
			if (completouMissao1 == true)
			{
				this.gameObject.SetActive(false);
			}
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
		if (completouMissao1 != true)
		{
			pegouItem1 = arvore.Completou();
			if (pegouItem1 != true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao1);
				arvore.gameObject.SetActive(true);
			}
			else if (pegouItem1 == true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueFimMissao1);
				completouMissao1 = true;
			}
		}
		/*else if (completouMissao4 != true)
		{
			pegouItem2 = arvore2.Completou();
			if (pegouItem2 != true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao4);
				arvore2.gameObject.SetActive(true);
			}
			else if (pegouItem2 == true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueFimMissao4);
				completouMissao4 = true;
			}
		}*/
	}
	
}