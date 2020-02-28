using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
	public int vidaJogador;
	public int vidaInimigo;
	
	public Button botaoMorder;
	public Button botaoArranhar;
	public Button botaoDefender;
	public Button botaoFugir;
	
	private bool mordeu = false;
	private bool arranhou = false;
	private bool defendeu = false;
	private bool fugiu = false;
	
	private bool queroloop = false;
	private int turnos = 5;
	
    void Start()
    {
		Batalha();
	}
	
	private void Batalha()
	{
		Button morder = botaoMorder.GetComponent<Button>();
		Button arranhar = botaoArranhar.GetComponent<Button>();
		Button defender = botaoDefender.GetComponent<Button>();
		Button fugir = botaoFugir.GetComponent<Button>();
		
		//morder.onClick.AddListener(VaiMorder);
		arranhar.onClick.AddListener(VaiArranhar);
		defender.onClick.AddListener(VaiDefender);
		fugir.onClick.AddListener(VaiFugir);
			
		for (int i = 0; i < turnos; i++)
		{
			Debug.Log("dentro do for " + i);
			if (mordeu == true)
			{
				Debug.Log("Dano de 10 no inimigo");
				Debug.Log("Tira 15 de stamina");
			}
			if (arranhou == true)
			{
				Debug.Log("Dano de 5 no inimigo");
				Debug.Log("Tira 5 de stamina");
			}
			if (defendeu == true)
			{
				Debug.Log("Defesa do jogador aumenta +5");
			}
			if (fugiu == true)
			{
				Debug.Log("finaliza o jogo e volta pro mapa principal");
			}
		}
		if(queroloop == true){
			
		while (vidaJogador >= 1 || vidaInimigo >= 1)
		{
			//morder.onClick.AddListener(VaiMorder);
			//arranhar.onClick.AddListener(VaiArranhar);
			//defender.onClick.AddListener(VaiDefender);
			//fugir.onClick.AddListener(VaiFugir);
			
			//jogador escolhe o que fazer
			//jogo faz
			//inimigo randomiza entre ataque e defesa.
			//inimigo randomiza o valor
			//aplica
			
			mordeu = false;
			arranhou = false;
			defendeu = false;
			vidaInimigo = 0;
		}
		}
		Debug.Log("oi");
	}
	
	void VaiMorder(){
		Debug.Log("mordeu");
		mordeu = true;
	}
	void VaiArranhar(){
		Debug.Log("arranhou");
		arranhou = true;
	}
	void VaiDefender(){
		Debug.Log("defendeu");
		defendeu = true;
	}
	void VaiFugir(){
		Debug.Log("fugiu");
		fugiu = true;
	}
}
