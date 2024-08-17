using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlistadorCesta : MonoBehaviour
{
    public GameObject prItem;
    public Transform padre;

    public void Inicializar(List<string> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            GameObject it = Instantiate(prItem, padre);
            AlimentosEnLista ael = it.GetComponent<AlimentosEnLista>();
            ael.Inicializar(lista[i]);
        }
    }
}
