using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotasSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Asigna el componente SpriteRenderer del objeto en el Inspector
    public float opacidadMaxima = 100f; // Valor máximo de opacidad
    public float opacidadMinima = 0f; // Valor mínimo de opacidad
    public float valorMandar;
    public static NotasSprite notasSprite;

    // Función para cambiar la opacidad del sprite

    private void Awake()
    {
        notasSprite = this;
    }
    private void Update()
    {
        CambiarOpacidadSprite(valorMandar);

    }
    public void CambiarOpacidadSprite(float valorOpacidad)
    {
        // Asegurarse de que el valor esté dentro del rango válido
        valorOpacidad = Mathf.Clamp(valorOpacidad, opacidadMinima, opacidadMaxima);

        // Calcular el valor de opacidad en el rango [0, 1]
        float opacidadNormalizada = valorOpacidad / opacidadMaxima;


        // Obtener el material del sprite
        Material materialSprite = spriteRenderer.material;

        // Crear un nuevo color con la misma opacidad del material actual y el nuevo valor de opacidad
        Color nuevoColor = new Color(materialSprite.color.r, materialSprite.color.g, materialSprite.color.b, opacidadNormalizada);

        // Aplicar el nuevo color al material del sprite
        materialSprite.color = nuevoColor;
    }

    public void Sumar()
    {
        valorMandar++;
    }



}
