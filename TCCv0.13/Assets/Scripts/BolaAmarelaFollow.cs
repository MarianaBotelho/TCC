using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaAmarelaFollow : MonoBehaviour
{
    public Transform objetivo;
	public float velocidade = 0.05f;
	public Vector3 offset;
	
	private void FixedUpdate()
	{
		Vector3 posicaoDesejada = objetivo.position + offset;
		Vector3 posicaoSmoothed = Vector3.Lerp(transform.position, posicaoDesejada, velocidade);
		transform.position = posicaoSmoothed;
	}
}