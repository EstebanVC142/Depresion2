using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Manager : MonoBehaviour
{
    public float tiempoEscena = 150f;

    IEnumerator TiempoEjecucion()
    {
        yield return new WaitForSeconds(tiempoEscena);
        ControlEscena.singleton.GoToScene("Lobby3");
    }

    public void IniciarTiempo()
    {
        StartCoroutine(TiempoEjecucion());
    }
}
