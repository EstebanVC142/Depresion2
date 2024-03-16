using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using Unity.VisualScripting;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer video;
    public UnityEvent acciones;

    private void Start()
    {
        StartCoroutine(Verificar());
    }
    IEnumerator Verificar()
    {
        yield return new WaitUntil(() => video.isPlaying);
        while (video.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }

        acciones.Invoke();
    }
}

