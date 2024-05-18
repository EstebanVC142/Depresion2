using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarroAceituna : MonoBehaviour
{
    public Transform puntaArrribaAceituna;
    public Transform puntaAbajoAceituna;
    public Transform referenciaHueco;
    public float distanciaAceituna;
    public float distanciaActivar;
    public bool activo;
    public GameObject aceituna;

	private void Start()
	{
        StartCoroutine(EsperarInstanciaAceituna());
	}
	private void FixedUpdate()
    {
        distanciaAceituna = puntaArrribaAceituna.position.y - puntaAbajoAceituna.position.y;
        if (!activo&&distanciaAceituna<distanciaActivar)
        {
            activo = true;
        }
        if (activo&&distanciaAceituna>distanciaActivar)
        {
            activo = false;
        }

    }
    IEnumerator EsperarInstanciaAceituna()
    {
		while (true)
		{
            yield return new WaitForSeconds(0.8f);
            if (activo == true)
            {
                Instantiate(aceituna, referenciaHueco.transform.position, referenciaHueco.transform.rotation);
            }
        }
    }

   
}
