using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BotonActivar : MonoBehaviour
{
    public UnityEvent evento;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            evento.Invoke();
        }

    }
}
