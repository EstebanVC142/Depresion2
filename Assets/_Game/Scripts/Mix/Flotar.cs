using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotar : MonoBehaviour
{
    public Vector3 posicionInicial;
    public float amplitud;
    public int frecuencia;

    private void Start()
    {
        posicionInicial = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = posicionInicial + Vector3.up * Mathf.Sin(Time.time * frecuencia) * amplitud;
    }
}
