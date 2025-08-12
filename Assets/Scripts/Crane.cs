using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crane : MonoBehaviour
{
    public float rotateSpeed = 5;
    public Vector2 craneRotY = new(-11, 11);
    public Vector2 craneRotX = new(0, 20);
    [Header("Events")]
    public UnityEvent craneEnter;
    public UnityEvent craneExit;
    private Vector2 input;
    private bool isCrane = false;
    private float currentYRotation = 0f;
    private float currentXRotation = 0f;
    public Transform cranePivot;
    public Transform joystic;
    public Transform cran;
    public Transform Gruz;
    private Transform Player;
    
    private void OnTriggerEnter(Collider other)
    {
        Player = other.transform;
        craneEnter.Invoke();
        isCrane = true;
    }

    private void Update()
    {
        if (!isCrane) return;
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCrane = false;
            Player.transform.position += Vector3.left ; 
            craneExit.Invoke();
        }
        if (input == Vector2.zero) return;

        CraneRotator();
       
        CabinaRotater();

        JoysticRotate();
        
        Gruz.rotation = Quaternion.Euler(Gruz.transform.rotation.x, Gruz.transform.rotation.y, 90);

        
    }

    private void CraneRotator()
    {
        var deltaRotation = input.y * rotateSpeed * Time.deltaTime;

        currentXRotation =  Mathf.Clamp(currentXRotation + deltaRotation, craneRotX.x, craneRotX.y);
        
        cran.localRotation = Quaternion.Euler(0, currentXRotation, 0);
    }

    private void CabinaRotater()
    {
        var deltaRotation = input.x * rotateSpeed * Time.deltaTime;
        
        currentYRotation = Mathf.Clamp(currentYRotation + deltaRotation, craneRotY.x, craneRotY.y);
        
        cranePivot.rotation = Quaternion.Euler(0f, currentYRotation, 0f);
    }

    private void JoysticRotate()
    {
        if (joystic == null) return;
        float tiltAroundX = input.y * 15;
        float tiltAroundZ = -input.x * 15;
        joystic.eulerAngles = new Vector3(tiltAroundX, 0f, tiltAroundZ);
    }
}