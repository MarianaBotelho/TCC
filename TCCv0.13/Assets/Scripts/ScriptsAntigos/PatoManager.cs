using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatoManager : MonoBehaviour
{
    public Dialogue dialogueMissao15;
	public Dialogue dialogueMissao19;
	public Dialogue dialogueFimMissao15;
	public Dialogue dialogueFimMissao19;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao15 = false;
	//private bool pegouItem = false;
	private bool completouMissao19 = false;
	
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
		if (completouMissao15 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao15);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao15 = true;
		}
		else if (completouMissao19 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao19);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao19 = arvore.Completou();
		}
	}
	
}