using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AraraManager : MonoBehaviour
{
    public Dialogue dialogueMissao13;
	public Dialogue dialogueMissao17;
	public Dialogue dialogueFimMissao13;
	public Dialogue dialogueFimMissao17;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao13 = false;
	//private bool pegouItem = false;
	private bool completouMissao17 = false;
	
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
		if (completouMissao13 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao13);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao13 = true;
		}
		else if (completouMissao17 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao17);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao17 = arvore.Completou();
		}
	}
	
}