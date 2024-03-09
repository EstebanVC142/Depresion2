using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BotonActivar : MonoBehaviour
{
    public UnityEvent evento;

    [ContextMenu("Activar")]
    public void Activar()
    {
        evento.Invoke();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            Activar();
        }

    }
}
