using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Serotonina : MonoBehaviour
{
    public Vector3 frecuencias;
    public float frecuenciaGeneral;
    public Vector3 amplitud;
    public Transform referenciaFuera;
    public Transform referenciaDentro;
    public bool dentro;
    public float velocidad;

    public Vector3 posicionFuera;
    [Range(0f, 1f)]
    public float t;


    void Update()
    {
        posicionFuera = referenciaFuera.position + new Vector3
        (
            amplitud.x * Mathf.Sin(Time.time * frecuencias.x * frecuenciaGeneral),
            amplitud.y * Mathf.Cos(Time.time * frecuencias.y * frecuenciaGeneral),
            amplitud.z * Mathf.Sin(Time.time * frecuencias.z * frecuenciaGeneral)
        );

        transform.position = Vector3.Lerp(referenciaDentro.position, posicionFuera, t);

        if (dentro)
        {
            t = math.lerp(t, 0, Time.deltaTime * velocidad);
        }
        else
        {
            t = math.lerp(t, 1, Time.deltaTime * velocidad);
        }
           
        
    }
}
