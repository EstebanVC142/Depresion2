using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenerador : MonoBehaviour
{
    public bool enMano;
    public void ActivarXR()
    {
        enMano = true;
    }
    public void DesactivarXR()
    {
        enMano = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enMano = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
