using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlMano : MonoBehaviour
{
    public InputActionProperty botonTrigger; 
    public InputActionProperty botonGrab;
    public Animator animator;

    public float trigger;
    public float grab;

    private void Start()
    {
        botonTrigger.action.Enable();
        botonGrab.action.Enable();
    }

    void Update()
    {
        trigger = botonTrigger.action.ReadValue<float>();  
        grab = botonGrab.action.ReadValue<float>();
        animator.SetFloat("Trigger", trigger);
        animator.SetFloat("Grab", grab);
    }
}
