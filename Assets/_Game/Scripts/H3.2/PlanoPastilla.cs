using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlanoPastilla : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pastilla"))
        {
            Destroy(other.gameObject);
            Pastillero.singleton.CrearPastilla();
        }
    }


}
