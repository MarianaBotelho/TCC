using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CobraManager : MonoBehaviour
{
    public Dialogue dialogueMissao16;
	public Dialogue dialogueMissao20;
	public Dialogue dialogueFimMissao16;
	public Dialogue dialogueFimMissao20;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao16 = false;
	//private bool pegouItem = false;
	private bool completouMissao20 = false;
	
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
		if (completouMissao16 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao16);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao16 = true;
		}
		else if (completouMissao20 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao20);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao20 = arvore.Completou();
		}
	}
	
}