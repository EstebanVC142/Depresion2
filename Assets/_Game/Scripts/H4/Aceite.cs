using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceite : MonoBehaviour
{
    public Transform puntaArrriba;
    public Transform puntaAbajo;
    public float distancia;
    public float distanciaActivar;
    public bool activo;
    public ParticleSystem particulas;
    private void FixedUpdate()
    {
        distancia = puntaArrriba.position.y - puntaAbajo.position.y;
        if (!activo && distancia<distanciaActivar)
        {
            activo = true;
            particulas.Play();
        }
        if (activo && distancia>distanciaActivar)
        {
            activo = false;
            particulas.Stop();
        }

    }

}
