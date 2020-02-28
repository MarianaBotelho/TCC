using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PorcoManager : MonoBehaviour
{
	public Dialogue dialogueMissao2;
	public Dialogue dialogueMissao5;
	public Dialogue dialogueFimMissao2;
	public Dialogue dialogueFimMissao5;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao2 = false;
	//private bool pegouItem = false;
	private bool completouMissao5 = false;
	
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
		if (completouMissao2 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao2);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao1 = true;
		}
		else if (completouMissao5 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao5);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao4 = arvore.Completou();
		}
	}
	
}