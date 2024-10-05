using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class Pastilla : MonoBehaviour
{
    // Estado de la pastilla
    public bool activo = true;
    public float tiempoDestruir = 20f;
    public bool pastilla = false;

    // Referencias a los materiales
    public Material materialActivado;    // Material cuando está activada
    public Material materialDesactivado; // Material cuando está desactivada

    // Hacer MeshRenderer público para asignarlo manualmente en el Inspector
    public MeshRenderer meshRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pastilla") && activo)
        {
            // Unir la pastilla al objeto
            other.transform.parent = this.transform;
            other.transform.localPosition = Vector3.zero;

            // Destruir ciertos componentes del objeto que entra en el trigger
            Destroy(other.GetComponent<XRGrabInteractable>());
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.gameObject, tiempoDestruir);

            // Cambiar el estado de la pastilla
            activo = false;
            pastilla = true;

            // Actualizar el material al activar
            ActualizarMaterial();

            // Programar la desactivación después de 'tiempoDestruir'
            Invoke("DesactivarPastilla", tiempoDestruir);
        }
    }

    // Método que desactiva la pastilla
    void DesactivarPastilla()
    {
        pastilla = false;
        ActualizarMaterial();  // Actualiza el material cuando se desactiva
    }

    // Método para activar la pastilla
    public void Activar()
    {
        if (!pastilla)
        {
            activo = true;
            ActualizarMaterial();  // Actualiza el material cuando se activa
        }
    }

    // Método para actualizar el material basado en el estado de la pastilla
    void ActualizarMaterial()
    {
        if (meshRenderer != null)
        {
            if (activo)
            {
                // Cambiar al material de activado
                meshRenderer.material = materialActivado;
            }
            else
            {
                // Cambiar al material de desactivado
                meshRenderer.material = materialDesactivado;
            }
        }
    }
}
