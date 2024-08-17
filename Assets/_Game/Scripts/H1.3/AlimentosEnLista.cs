using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentosEnLista : MonoBehaviour
{
    public Text nombre;

    public void Inicializar(string _nombre)
    {
        nombre.text = _nombre;
    }


}
