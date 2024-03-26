using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotasManager : MonoBehaviour
{
    public Notificacion[] notificaciones;
    public GameObject nota;
    public Transform referenciaNotas;
    public bool activo = false;
    public AudioSource audioFondo;
    public Vector2 intervalo;
    public UnityEvent eventoFinal;

    float tiempoActivado;

  //  void Update()
  //  {
  //      if (!activo) return;

		//if (indice < notificaciones.Length && Time.time-tiempoActivado > notificaciones[indice].tiempo)
		//{
  //          GameObject n = Instantiate(nota, referenciaNotas.position, referenciaNotas.rotation);
  //          n.GetComponent<Nota>().Inicializar(notificaciones[indice].figura);
  //          indice++;
		//}
  //  }

    IEnumerator CrearNotas()
    {
        while (activo)
        {
            yield return new WaitForSeconds(Random.Range(intervalo.x, intervalo.y));
            if (!audioFondo.isPlaying)
            {
                Desactivar();
            }
            if ((audioFondo.clip.length - audioFondo.time) > 5 && activo)
            {
                GameObject n = Instantiate(nota, referenciaNotas.position, referenciaNotas.rotation);
                n.GetComponent<Nota>().Inicializar((FigurasPosibles)Random.Range(0, 5));
            }
        }
    }

    public void Desactivar()
    {
        activo = false;
        eventoFinal.Invoke();
    }

    public void Activar()
	{
        tiempoActivado = Time.time;
        audioFondo.Play();
        activo = true;
        StartCoroutine(CrearNotas());
	}
}

public enum FigurasPosibles
{
    semiCorchea     = 0,
    corchea         = 1,
    negra           = 2,
    blanca          = 3,
    redonda         = 4
}

[System.Serializable]
public class Notificacion
{
    public float tiempo;
    public FigurasPosibles figura;
}