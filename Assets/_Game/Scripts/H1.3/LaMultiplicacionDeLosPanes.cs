using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaMultiplicacionDeLosPanes : MonoBehaviour
{
    public GameObject[] pan;
    public Vector3 escala;
    public int densidad;
    private List<Vector3> posiciones = new List<Vector3>();

    public Rigidbody[] panes ;
    public Vector3[] posicionesFinales;

    private void Start()
    {
        StartCoroutine(GuardarPosiciones());
    }

    public void EliminarCaidos()
    {
        for (int i = 0; i < panes.Length; i++)
        {
            if (posicionesFinales[i] == Vector3.zero)
            {
                if(panes[i] != null)DestroyImmediate(panes[i].gameObject); 
            }

            else
            {
                panes[i].transform.position = posicionesFinales[i];
            }

        }
    }

    public IEnumerator GuardarPosiciones()
    {
        yield return new WaitForSeconds(5);
        posicionesFinales = new Vector3 [panes.Length];
        for (int i = 0; i < panes.Length; i++)
        {
            if (panes[i] != null)
            {
                posicionesFinales[i] = panes[i].transform.position;
            }
        }
    }

    public void CalcularPosciones()
    {
        posiciones = new List<Vector3>();
        for (int i = 0; i < densidad; i++)
        {
            Vector3 v = new Vector3(Random.Range(-escala.x,escala.x), Random.Range(-escala.y, escala.y), Random.Range(-escala.z, escala.z));
            posiciones.Add(v);
        }
    }

    public void ObtenerHijo()
    {
        panes = GetComponentsInChildren<Rigidbody>();
    }

    public void Multiplicar()
    {
        for (int i = 0; i < pan.Length; i++)
        {
            for (int j = 0; j < posiciones.Count; j++)
            {
                GameObject g = Instantiate(pan[i], posiciones[j] + pan[i].transform.position, pan[i].transform.rotation, transform);
            }
        }
    }

    public void Destruir()
    {
        panes = GetComponentsInChildren<Rigidbody>();   
        for (int i = 0; i < panes.Length; i++)
        {
            DestroyImmediate(panes[i].gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pan.Length; i++)
        {
            if (pan[i] == null) return;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(pan[i].transform.position, escala * 2);
            Gizmos.color = new Color(0, 0.7f, 0, 0.5f);
            for (int j = 0; j < posiciones.Count; j++)
            {
                Gizmos.DrawSphere(posiciones[j] + pan[i].transform.position, 0.01f);

            }
        }
    }
}

