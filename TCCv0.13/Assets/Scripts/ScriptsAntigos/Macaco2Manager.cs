using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Macaco2Manager : MonoBehaviour
{
    public Dialogue dialogueMissao21;
	public Dialogue dialogueMissao24;
	public Dialogue dialogueFimMissao21;
	public Dialogue dialogueFimMissao24;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao21 = false;
	//private bool pegouItem = false;
	private bool completouMissao24 = false;
	
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
		if (completouMissao21 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao21);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao21 = true;
		}
		else if (completouMissao24 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao24);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao24 = arvore.Completou();
		}
	}
	
}