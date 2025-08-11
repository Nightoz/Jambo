using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform rayTransform;
    public GameObject panel;
    public bool take, activ;
    public UnityEvent<string> finding;
    public GameObject currObj,currentRayTarget;
    

    private void Update()
    {
        Raycasting();
        TakeObject();
        ActiveteObject();

    }

    
    
    private void Raycasting()
    {
        if (Physics.Raycast(rayTransform.position, rayTransform.forward, out var hit,1f))
        { 
            finding.Invoke(hit.transform.name);
            if(currentRayTarget == null)
                currentRayTarget = hit.transform.gameObject;
        }
        else
        {
            panel.SetActive(false);
            currentRayTarget = null;
        }
    }

    private void TakeObject()
    {
        if (!Input.GetKeyDown(KeyCode.F)) return;
        
            if (currObj == null)
            {
                currObj = currentRayTarget;
                currentRayTarget = null;
                currObj.transform.SetParent(rayTransform.transform);
            }
            else
            {
                if(currObj)
                currObj.transform.SetParent(null);
                currObj = null;
            }
        
    
        
    }

    private void ActiveteObject()
    {
        if (!currentRayTarget || !Input.GetKeyDown(KeyCode.E))
            return;
        if (currentRayTarget.TryGetComponent<Animator>(out var anim))
        {
            anim.SetTrigger("active");
        }

        if (currentRayTarget.TryGetComponent<Animation>(out var a))
        {
            a.Play();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            Tween.LocalPositionZ(cameraTarget,-2f,2f);
        }
        
    }
    

    private void OnDrawGizmosSelected()
    {
        if (rayTransform == null) return;

        Gizmos.color = Color.red;
        Vector3 direction = rayTransform.forward * 2f; // длина луча
        Gizmos.DrawRay(rayTransform.position, direction);
    }
}
