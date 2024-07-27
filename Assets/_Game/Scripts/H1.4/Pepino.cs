using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepino : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cuchillo"))
        {
            ControlH14.singleton.pepinoCortado = true;
        }
    }
}
