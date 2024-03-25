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
	public SpriteRenderer partitura;
	public Sprite[] partituras;
	public int indice;
	public int salto;
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
		puntos++;
		NotasSprite.notasSprite.Sumar();		
		ActualizarImagen();
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

	public void ActualizarImagen()
	{
		indice = Mathf.FloorToInt(Mathf.Clamp(puntos / salto, 0, partituras.Length - 1));
		partitura.sprite = partituras[indice];
	}
}
