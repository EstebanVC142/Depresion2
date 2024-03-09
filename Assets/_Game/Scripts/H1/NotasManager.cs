using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotasManager : MonoBehaviour
{
    public Notificacion[] notificaciones;
    public int indice = 0;
    public GameObject nota;
    public Transform referenciaNotas;
    public bool activo = false;
    public AudioSource audioFondo;

    float tiempoActivado;

    void Update()
    {
        if (!activo) return;

		if (indice < notificaciones.Length && Time.time-tiempoActivado > notificaciones[indice].tiempo)
		{
            GameObject n = Instantiate(nota, referenciaNotas.position, referenciaNotas.rotation);
            n.GetComponent<Nota>().Inicializar(notificaciones[indice].figura);
            indice++;
		}
    }

    public void Activar()
	{
        tiempoActivado = Time.time;
        audioFondo.Play();
        activo = true;
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