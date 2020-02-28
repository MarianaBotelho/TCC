using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	//public Text nameText;
	public Text dialogueText;
	public Animator animator;
	
	private Queue<string> sentences;
	public Canvas Gameui;
	
    void Start()
    {
        sentences = new Queue<string>();
    }
	
	public void StartDialogue(Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true);
		Gameui.GetComponent<Canvas>().enabled = false;
		//nameText.text = dialogue.name;
		
		sentences.Clear();
		foreach(string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	
	public void DisplayNextSentence()
	{
        if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}
	
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	
	public void EndDialogue()
	{
		Gameui.GetComponent<Canvas>().enabled = true;
		animator.SetBool("IsOpen", false);
		//Debug.Log("Fim da conversa");
	}
}
