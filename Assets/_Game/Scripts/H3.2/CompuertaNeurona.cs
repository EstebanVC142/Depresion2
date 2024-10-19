using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompuertaNeurona : MonoBehaviour
{
    public bool abierta = false; // Control de estado
    public SkinnedMeshRenderer malla; // Cambia a SkinnedMeshRenderer para usar blend shapes
    float t = 0; // Valor interpolado
    public float velocidadLerp = 5f; // Velocidad de interpolaci�n

    void Update()
    {
        // Si est� abierta, t se aproxima a 1, si no, se aproxima a 0
        t = Mathf.Lerp(t, abierta ? 0 : 1, Time.deltaTime * velocidadLerp);

        // Asigna el valor de t al BlendShape de la malla (posici�n 0)
        if (malla != null)
        {
            malla.SetBlendShapeWeight(0, t * 100f); // Convertimos t a un rango de 0 a 100 para el BlendShape
        }
    }
}
