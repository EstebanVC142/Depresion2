using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
public class Alimentos : MonoBehaviour
{
    
    public TipoAlimentos alimento;
    public bool enMano;
    public string nombre = "indefinido";

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTRANDO");
        Debug.Log(enMano );

        if (enMano == true && other.CompareTag("Canasta"))
        {
            Debug.Log("DENTRO");
            Canasta.canasta.ContadorAlimento(alimento, nombre);
            Destroy(gameObject);
        }
        else
        {
            enMano = false;
        }

    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        if (transform.position.y < 0.2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            enMano = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            enMano = false;
        }
    }
}

public enum TipoAlimentos
{
    ultraprocesado = 0,
    mediterraneo = 1,
}
