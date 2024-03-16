using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
	public string escena;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("mano"))
		{
			ControlEscena.singleton.GoToScene(escena);
			this.enabled = false;
		}
	}

	public void Activar()
	{
		ControlEscena.singleton.GoToScene(escena);
		this.enabled = false;
	}
}
