using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BotonNota : MonoBehaviour
{
	private Vector3 posFinal;
	private Vector3 posInicial;
    public bool accionable;
	public Material material;
	public Transform boton;
	public AnimationCurve curva;
	public float offset;
	public AudioSource sonidoFalla;

	private void Start()
	{
		material = boton.gameObject.GetComponent<Renderer>().material;
		Desactivar();
		posFinal = transform.position;
		posInicial = transform.position - Vector3.up*2;
		transform.position = posInicial;
	}

    IEnumerator Animar()
    {
        yield return new WaitForSeconds(offset);
        for (int i = 0; i < 30; i++)
        {
            float t = i / 29f;
            transform.position = Vector3.LerpUnclamped(posInicial, posFinal, curva.Evaluate(t));
            yield return new WaitForSeconds(1 / 30f);
        }
    }
    IEnumerator Desanimar()
    {
        yield return new WaitForSeconds(offset);
        for (int i = 0; i < 30; i++)
        {
            float t = i / 29f;
            transform.position = Vector3.LerpUnclamped(posInicial, posFinal, curva.Evaluate(1 - t));
            yield return new WaitForSeconds(1 / 30f);
        }
    }

    public void Ocultar()
    {
		StartCoroutine(Desanimar());
    }

    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("mano"))
		{
			
			if (accionable)
			{
				ControlH1.singleton.SumarPuntos();
				material.color = Color.white;
				ControlH1.singleton.ActualizarPuntosTexto();
			}
			else
			{
				ControlH1.singleton.RestarPuntos();
				material.color = Color.red;
				ControlH1.singleton.ActualizarPuntosTexto();
				sonidoFalla.Play();
			}
			accionable = false;
			boton.transform.localPosition = new Vector3(0, 0, 0);

		}

	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("mano"))
		{
			material.color = Color.black;
		}

        boton.transform.localPosition = new Vector3(0, 0.2f, 0);
    }

	public void Activar()
	{
		accionable = true;
		material.color = Color.green;
	}

	public void Desactivar()
	{
		accionable = false;
		material.color = Color.black;
	}

	public void IniciarAnimacion()
	{
		StartCoroutine(Animar());
	}
}
