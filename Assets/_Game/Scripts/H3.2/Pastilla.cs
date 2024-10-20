using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class Pastilla : MonoBehaviour
{
    // Estado de la pastilla
    public float tiempoDestruir = 20f;
    public bool pastilla = false;
    public CompuertaNeurona compuertaNeurona;

    // Referencias a los materiales
    public Material materialActivado;    // Material cuando está activada
    public Material materialDesactivado; // Material cuando está desactivada

    // Hacer MeshRenderer público para asignarlo manualmente en el Inspector
    public SkinnedMeshRenderer meshRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pastilla") && compuertaNeurona.abierta)
        {
            // Unir la pastilla al objeto
            other.transform.parent = this.transform;
            other.transform.localPosition = Vector3.zero;
            compuertaNeurona.Bloquear(true);

            // Destruir ciertos componentes del objeto que entra en el trigger
            Destroy(other.GetComponent<XRGrabInteractable>());
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.gameObject, tiempoDestruir);

            // Cambiar el estado de la pastilla
            //activo = false;
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
        compuertaNeurona.Bloquear(false);
    }

    // Método para activar la pastilla
    public void Activar()
    {
        if (!pastilla)
        {
            compuertaNeurona.abierta = true;
            ActualizarMaterial();  // Actualiza el material cuando se activa
        }
    }

    // Método para actualizar el material basado en el estado de la pastilla
    public void ActualizarMaterial()
    {
        if (meshRenderer != null)
        {
            if (compuertaNeurona.abierta)
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
