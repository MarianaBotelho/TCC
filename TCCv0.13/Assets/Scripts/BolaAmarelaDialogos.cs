using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaAmarelaDialogos : MonoBehaviour
{
	public Dialogue dialogoInicial;
	public Dialogue dialogoFinal;
	
	private bool primeiroDialogo = true;
	private bool ultimoDialogo = false;

    private float tempo = 0.2f;
    private float ultimaTimestampDialogo;

    // Update is called once per frame
    void Update()
    {
        if (primeiroDialogo == true)
        {
            if (Time.time - ultimaTimestampDialogo >= tempo)
            {
                TriggerDialogue(dialogoInicial);
                primeiroDialogo = false;
            }
        }
    }

    void Awake()
    {
        ultimaTimestampDialogo = Time.time;
    }


	private void dialogoAtual()
	{
        Debug.Log("dialogoAtual");
		if (primeiroDialogo == true)
		{
			TriggerDialogue(dialogoInicial);
			primeiroDialogo = false;
		}
		if (ultimoDialogo == true)
		{
			TriggerDialogue(dialogoFinal);
			ultimoDialogo = false;
		}
	}
    
    private void TriggerDialogue(Dialogue dialogo)
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogo);
	}
}
