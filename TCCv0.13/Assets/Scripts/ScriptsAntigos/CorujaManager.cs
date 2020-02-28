using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorujaManager : MonoBehaviour
{
    public Dialogue dialogueMissao14;
	public Dialogue dialogueMissao18;
	public Dialogue dialogueFimMissao14;
	public Dialogue dialogueFimMissao18;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao14 = false;
	//private bool pegouItem = false;
	private bool completouMissao18 = false;
	
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
		if (completouMissao14 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao14);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao14 = true;
		}
		else if (completouMissao18 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao18);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao18 = arvore.Completou();
		}
	}
	
}