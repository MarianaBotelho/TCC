using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrocodiloManager : MonoBehaviour
{
    public Dialogue dialogueMissao23;
	public Dialogue dialogueMissao25;
	public Dialogue dialogueFimMissao23;
	public Dialogue dialogueFimMissao25;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao23 = false;
	//private bool pegouItem = false;
	private bool completouMissao25 = false;
	
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
		if (completouMissao23 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao23);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao23 = true;
		}
		else if (completouMissao25 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao25);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao25 = arvore.Completou();
		}
	}
	
}