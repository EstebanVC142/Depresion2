using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarFisura : MonoBehaviour
{
    // Lista de objetos del tipo Pastilla
    public List<Pastilla> pastillas;

    // Tiempo entre activaciones aleatorias (en segundos)
    public float tiempoEntreActivaciones = 3.0f;

    void Start()
    {
        // Comienza a activar pastillas aleatoriamente cada cierto tiempo
        StartCoroutine(ActivarPastillaAleatoria());
    }

    // Corrutina que activa una pastilla aleatoria en intervalos de tiempo
    IEnumerator ActivarPastillaAleatoria()
    {
        // Bucle infinito
        while (true)
        {
            // Esperar el tiempo especificado antes de activar la próxima pastilla
            yield return new WaitForSeconds(tiempoEntreActivaciones);

            // Asegurarse de que la lista de pastillas no esté vacía
            if (pastillas.Count > 0)
            {
                // Seleccionar un índice aleatorio de la lista de pastillas
                int indiceAleatorio = Random.Range(0, pastillas.Count);

                // Activar la pastilla seleccionada aleatoriamente
                pastillas[indiceAleatorio].Activar();
            }
        }
    }
}
