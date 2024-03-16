using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlH1 : MonoBehaviour
{
    public static ControlH1 singleton;
	public int puntos;
	public TextMeshProUGUI puntaje;
	private void Awake()
	{
		if (singleton == null)
		{
			singleton = this;
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}
	public void SumarPuntos()
	{
		puntos+=3;
		NotasSprite.notasSprite.Sumar();
		
	}
	public void RestarPuntos()
	{
		if (puntos > 0)
		{
			puntos--;

		}
	}
	public void ActualizarPuntosTexto()
	{
		puntaje.text = "Puntos: " + puntos.ToString();
	}

}
