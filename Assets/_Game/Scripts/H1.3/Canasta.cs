using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Canasta : MonoBehaviour
{
    public static Canasta canasta;
    public int cantidadBuenos;
    public int cantidadMalos;
    public Text cantidadMalosTexto;
    public Text cantidadBuenosTexto;
    public int cantidadTotales;
    public List<string> ultraprocesados = new List<string>();
    public List<string> mediterraneos = new List<string>();
    public EnlistadorCesta listaBuenos;
    public EnlistadorCesta listaMalos;

    bool terminado = false;

    private void Awake()
    {
        canasta = this;
    }
    private void Start()
    {
        cantidadTotales = 0;
    }

    public void ContadorAlimento(TipoAlimentos tipo, string n)
    {
        if (terminado)
        {
            return;
        }
        switch (tipo)
        {
            case TipoAlimentos.ultraprocesado:
                cantidadMalos++;
                cantidadMalosTexto.text = cantidadMalos.ToString();
                ultraprocesados.Add(n);
                break;
            case TipoAlimentos.mediterraneo:
                cantidadBuenos++;
                mediterraneos.Add(n);
                cantidadBuenosTexto.text = cantidadBuenos.ToString();
                break;
            default:
                break;
        }

        if (cantidadMalos + cantidadBuenos > 14)
        {
            listaBuenos.Inicializar(mediterraneos);
            listaMalos.Inicializar(ultraprocesados);
            terminado = true;
        }

    }

}
