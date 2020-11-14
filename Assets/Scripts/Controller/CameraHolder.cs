using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    public Transform cameraTarget;

    Vector3 cameraDistance;

    void Awake()
    {
        cameraDistance = cameraTarget.position - transform.position;
    }

    void LateUpdate()
    {
        CameraUpdate();
    }

    void CameraUpdate()
    {
        transform.position = cameraTarget.position - cameraDistance;
    }
}
