using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
	public bool compararTag = false;
	public string etiqueta;
	private void OnTriggerEnter(Collider other)
	{
		if (compararTag)
		{
			if (other.CompareTag(etiqueta))
			{
				Destroy(other.gameObject);
			}
		}
		else
		{
			Destroy(other.gameObject);
		}
	}
}
