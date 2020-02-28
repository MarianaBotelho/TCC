using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacacoManager : MonoBehaviour
{
    public Dialogue dialogueMissao7;
	//public Dialogue dialogueMissao10;
	public Dialogue dialogueFimMissao7;
	//public Dialogue dialogueFimMissao10;
	public ItemMissaoManager item1;
	//public ItemMissaoManager item2;
	
	Animator anim;
	bool dentro = false;
	private bool completouMissao7 = false;
	private bool pegouItem1 = false;
	//private bool completouMissao10 = false;
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
			if (completouMissao7 == true)
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
		if (completouMissao7 != true)
		{
			pegouItem1 = item1.Completou();
			if (pegouItem1 != true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao7);
				//item1.gameObject.setActive(true);
			}
			else if (pegouItem1 == true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueFimMissao7);
				completouMissao7 = true;
			}
		}
		/*else if (completouMissao10 != true)
		{
			pegouItem2 = item2.Completou();
			if (pegouItem2 != true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao10);
				//item2.gameObject.setActive(true);
			}
			else if (pegouItem2 == true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueFimMissao10);
				completouMissao10 = true;
			}
		}*/
	}
}