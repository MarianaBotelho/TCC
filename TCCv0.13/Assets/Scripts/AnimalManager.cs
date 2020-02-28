using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
	public Dialogue dialogueMissao;
	public Dialogue dialogueFimMissao;
	public ItemMissaoManager item;
    public int numeroMissao;
	
	Animator anim;
	bool dentro = false;
	private bool completouMissao = false;
	private bool pegouItem = false;

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
			if (completouMissao == true)
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
        if (completouMissao != true)
		{
			pegouItem = item.Completou();
			if (pegouItem != true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao);
				item.gameObject.SetActive(true);
			}
			else if (pegouItem == true)
			{
				FindObjectOfType<DialogueManager>().StartDialogue(dialogueFimMissao);
				completouMissao = true;
                GameManager.instance.registraMissao(numeroMissao);
			}
		}
	}
	
}