using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lechuga : MonoBehaviour
{
    public Transform[] hijos;

    [ContextMenu("Desarmar")]
    public void DesarmarLechuga()
    {
        for (int i = 0; i < hijos.Length; i++)
        {
            hijos[i].parent = null;
            hijos[i].gameObject.AddComponent<Rigidbody>();
        }
    }
}
