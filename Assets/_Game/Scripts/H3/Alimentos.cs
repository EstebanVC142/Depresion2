using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Alimentos : MonoBehaviour
{
    
    public TipoAlimentos alimento;
    public bool enMano;

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTRANDO");
        Debug.Log(enMano );

        if (enMano == true && other.CompareTag("Canasta"))
        {
            Debug.Log("DENTRO");
            Canasta.canasta.ContadorAlimento(alimento);
            Destroy(gameObject);

        }
        else
        {
            enMano = false;
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
