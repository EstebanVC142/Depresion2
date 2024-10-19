using System.Collections;
using UnityEngine;

public class Serotonina : MonoBehaviour
{
    public Vector3 frecuencias;           // Frecuencias base
    public float frecuenciaGeneral;       // Frecuencia general para todo
    public Vector3 amplitud;              // Amplitud del movimiento
    public Transform referenciaFuera;     // Referencia de la posición "fuera"
    public Transform referenciaDentro;    // Referencia de la posición "dentro"
    public bool dentro;                   // Si está dentro o fuera
    public float velocidad;               // Velocidad de interpolación
    public Vector2 desface;               // Variable de desface (offset)

    public Vector3 posicionFuera;
    [Range(0f, 1f)]
    public float t;                       // Factor de interpolación

    public Vector3 variacionFrecuencia;   // Variación individual en las frecuencias para cada instancia

    void Start()
    {
        // Asignamos un desface aleatorio para cada objeto instanciado
        desface = new Vector2(Random.Range(0f, 2f * Mathf.PI), Random.Range(0f, 2f * Mathf.PI));

        // Asignamos una variación de frecuencia aleatoria para cada instancia
        variacionFrecuencia = new Vector3(
            Random.Range(0.8f, 1.2f),   // Variación en el eje X
            Random.Range(0.8f, 1.2f),   // Variación en el eje Y
            Random.Range(0.8f, 1.2f)    // Variación en el eje Z
        );
    }

    void Update()
    {
        // Aplicamos tanto el desface como la variación en las frecuencias
        posicionFuera = referenciaFuera.position + new Vector3
        (
            amplitud.x * Mathf.Sin(Time.time * frecuencias.x * variacionFrecuencia.x * frecuenciaGeneral + desface.x),
            amplitud.y * Mathf.Cos(Time.time * frecuencias.y * variacionFrecuencia.y * frecuenciaGeneral + desface.y),
            amplitud.z * Mathf.Sin(Time.time * frecuencias.z * variacionFrecuencia.z * frecuenciaGeneral + desface.x)
        );

        // Interpolación entre la posición dentro y fuera
        transform.position = Vector3.Lerp(referenciaDentro.position, posicionFuera, t);

        // Ajuste del valor de 't' para interpolar suavemente entre dentro y fuera
        if (dentro)
        {
            t = Mathf.Lerp(t, 0, Time.deltaTime * velocidad);
        }
        else
        {
            t = Mathf.Lerp(t, 1, Time.deltaTime * velocidad);
        }
    }
}
