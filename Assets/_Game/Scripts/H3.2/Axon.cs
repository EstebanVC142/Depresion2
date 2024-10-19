using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axon : MonoBehaviour
{
    public bool activo;
    public GameObject compuertaBase;
    public Transform[] posiciones;
    public List<CompuertaNeurona> compuertas = new List<CompuertaNeurona>();
    public Vector2 frecuenciaAperturas;
    public Vector2 frecuenciaAbsorcion;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < posiciones.Length; i++)
		{
            GameObject g = Instantiate(compuertaBase, posiciones[i].position, posiciones[i].rotation, posiciones[i]);
            compuertas.Add(g.GetComponent<CompuertaNeurona>());
		}
        StartCoroutine(AbreCompuertas());
        StartCoroutine(Absorve());
    }

    IEnumerator AbreCompuertas()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(frecuenciaAperturas.x, frecuenciaAperturas.y));
            if (activo)
            {
                compuertas[Random.Range(0, compuertas.Count)].abierta = true;
            }
        }
    }

    IEnumerator Absorve()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(frecuenciaAperturas.x, frecuenciaAperturas.y));
            if (activo)
            {
                compuertas[Random.Range(0, compuertas.Count)].Absorver();
            }
        }
    }
}
