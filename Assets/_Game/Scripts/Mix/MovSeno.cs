using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSeno : MonoBehaviour
{
    public float amplitud;
    public float frecuencia;

	public void Update()
	{
		transform.localPosition = Vector3.up * Mathf.Sin(Time.time * frecuencia) * amplitud;
	}
}
