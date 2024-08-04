using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionHablando : MonoBehaviour
{
    public Animator animaciones;
    public AudioSource audioSource;
    public bool activo = true;

    void Start()
    {
        InvokeRepeating("Update2", 1f, 1f);
    }

    // Update is called once per frame
    void Update2()
    {
		if (activo)
		{
            animaciones.SetBool("hablando", audioSource.isPlaying);
        }
    }
}
