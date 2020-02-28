using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SapoManager : MonoBehaviour
{
    public Dialogue dialogueMissao9;
	public Dialogue dialogueMissao12;
	public Dialogue dialogueFimMissao9;
	public Dialogue dialogueFimMissao12;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao9 = false;
	//private bool pegouItem = false;
	private bool completouMissao12 = false;
	
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
		if (completouMissao9 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao9);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao9 = true;
		}
		else if (completouMissao12 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao12);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao12 = arvore.Completou();
		}
	}
	
}
