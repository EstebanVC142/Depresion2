using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManosMove : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public Animator manoAnimador;
    public InputActionProperty gripAnimationAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        manoAnimador.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        manoAnimador.SetFloat("Grip", gripValue);


    }
}
