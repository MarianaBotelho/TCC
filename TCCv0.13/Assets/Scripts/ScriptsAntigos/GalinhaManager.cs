using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalinhaManager : MonoBehaviour
{
	public Dialogue dialogueMissao3;
	public Dialogue dialogueMissao6;
	public Dialogue dialogueFimMissao3;
	public Dialogue dialogueFimMissao6;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao3 = false;
	//private bool pegouItem = false;
	private bool completouMissao6 = false;
	
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
		if (completouMissao3 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao3);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao3 = true;
		}
		else if (completouMissao6 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao6);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao6 = arvore.Completou();
		}
	}
	
}