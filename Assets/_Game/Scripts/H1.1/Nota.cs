using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour
{
    public FigurasPosibles figura;
    public Vector3 velocidad;

    public GameObject[] notasGraficas;  

    public void Inicializar(FigurasPosibles fig)
	{
        figura = fig;

        for (int i = 0; i < notasGraficas.Length; i++)
        {
            notasGraficas[i].SetActive((int)fig == i);
        }
	}
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime);
    }
}
