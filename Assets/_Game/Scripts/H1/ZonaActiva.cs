using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaActiva : MonoBehaviour
{
    public BotonNota[] botones;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Nota"))
		{
			Nota nota = other.gameObject.GetComponent<Nota>();
			botones[(int) nota.figura].Activar();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Nota"))
		{
			Nota nota = other.gameObject.GetComponent<Nota>();
			botones[(int)nota.figura].Desactivar();
		}
	}
}
