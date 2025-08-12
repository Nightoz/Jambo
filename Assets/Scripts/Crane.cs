using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crane : MonoBehaviour
{
    public UnityEvent craneEnter;
    public UnityEvent craneExit;

    private void OnTriggerEnter(Collider other)
    {
        craneEnter.Invoke();
    }
}
