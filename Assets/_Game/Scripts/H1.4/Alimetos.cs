using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alimetos : MonoBehaviour
{
    public TipoAlimento tipo;
    public Vector3 posicion;
    public bool restaurarPosicion;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicion = transform.position;
        InvokeRepeating("RevisarPosicion", 1, 1);
    }

    public void ReiniciarPosicion()
    {
        if (restaurarPosicion)
        {
            transform.position = posicion;
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    void RevisarPosicion()
    {
        if (transform.position.y < 0.3f)
        {
            ReiniciarPosicion();
        }
    }
}

public enum TipoAlimento
{
    tomate = 0,
    pepino = 1,
    aceitunas = 2,
    cuchara = 3
}
