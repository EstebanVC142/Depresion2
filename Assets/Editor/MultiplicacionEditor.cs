using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LaMultiplicacionDeLosPanes))]
public class MultiplicacionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Calcular Posiciones"))
        {
            LaMultiplicacionDeLosPanes lp = (LaMultiplicacionDeLosPanes)target;
            lp.CalcularPosciones();
            SceneView.RepaintAll();
        }

        if (GUILayout.Button("Crear"))
        {
            LaMultiplicacionDeLosPanes lp = (LaMultiplicacionDeLosPanes)target;
            lp.Multiplicar();
            SceneView.RepaintAll();
        }

        if (GUILayout.Button("Hijos"))
        {
            LaMultiplicacionDeLosPanes lp = (LaMultiplicacionDeLosPanes)target;
            lp.ObtenerHijo();
        }
        var estilo = new GUIStyle(GUI.skin.button);
        estilo.normal.textColor = Color.red;
        if (GUILayout.Button("Eiminar", estilo))
        {
            LaMultiplicacionDeLosPanes lp = (LaMultiplicacionDeLosPanes)target;
            lp.Destruir();
            SceneView.RepaintAll();
        }
        estilo.normal.textColor = Color.red;
        if (GUILayout.Button("Eliminar caidos y posicionar", estilo))
        {
            LaMultiplicacionDeLosPanes lp = (LaMultiplicacionDeLosPanes)target;
            lp.EliminarCaidos();
            SceneView.RepaintAll();
        }
    }
}
