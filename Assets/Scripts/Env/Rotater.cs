using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public GameObject[] objectsToRotate;
    public float rotationSpeed = 2f; // Скорость вращения в оборотах в секунду

    void Update()
    {
        foreach (GameObject obj in objectsToRotate)
        {
            // Вращаем объект вокруг его локальной оси Z
            obj.transform.Rotate(0, 0, rotationSpeed * 360 * Time.deltaTime);
        }
    }
}
