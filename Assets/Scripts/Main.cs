using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    public State currentState;

    public enum State
    {
        Little,
        Fat,
        Tall,
        Crane
    }
    
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        SwitchPhase(State.Little);
    }

    public void SwitchPhase(State newState)
    {
        currentState = newState;
    }
}
