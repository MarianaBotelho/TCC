using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BufaloManager : MonoBehaviour
{
    public Dialogue dialogueMissao22;
	public Dialogue dialogueMissao26;
	public Dialogue dialogueFimMissao22;
	public Dialogue dialogueFimMissao26;
	
	//public ArvorePreguicaManager arvore; algum item que va precisar pegar
	
	Animator anim;
	bool dentro = false;
	
	private bool completouMissao22 = false;
	//private bool pegouItem = false;
	private bool completouMissao26 = false;
	
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
		if (completouMissao22 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao22);
			Debug.Log("vai ter alguma coisa aqui");
			//completouMissao22 = true;
		}
		else if (completouMissao26 != true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogueMissao26);
			Debug.Log("vai ter alguma coisa aqui tbm");
			//completouMissao26 = arvore.Completou();
		}
	}
	
}