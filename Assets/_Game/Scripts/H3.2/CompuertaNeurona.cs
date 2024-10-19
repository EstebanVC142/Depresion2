using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompuertaNeurona : MonoBehaviour
{
    public bool bloqueada;
    public bool abierta = false; // Control de estado
    public SkinnedMeshRenderer malla; // Cambia a SkinnedMeshRenderer para usar blend shapes
    float t = 0; // Valor interpolado
    public float velocidadLerp = 5f; // Velocidad de interpolación
    public Serotonina[] serotoninas;

    void Update()
    {
        // Si está abierta, t se aproxima a 1, si no, se aproxima a 0
        t = Mathf.Lerp(t, abierta ? 0 : 1, Time.deltaTime * velocidadLerp);

        // Asigna el valor de t al BlendShape de la malla (posición 0)
        if (malla != null)
        {
            malla.SetBlendShapeWeight(0, t * 100f); // Convertimos t a un rango de 0 a 100 para el BlendShape
        }
    }

    public void Abrir()
	{
        if(!bloqueada)
		{
            abierta = true;
			for (int i = 0; i < serotoninas.Length; i++)
			{
				if (serotoninas[i].dentro != false)
				{
                    serotoninas[i].dentro = false;
                    break;
                }
			}
		}
    }

    public void Cerrar()
    {
        if (abierta)
        {
            abierta = false;
        }
    }
    public void Bloquear(bool que)
    {
        bloqueada = que;
		if (que)
		{
            Cerrar();
		}
    }

    public void Absorver()
	{
		if (bloqueada)
		{
            return;
		}
        for (int i = 0; i < serotoninas.Length; i++)
        {
            if (serotoninas[i].dentro == false)
            {
                serotoninas[i].dentro = true;
                break;
            }
        }
    }
}
