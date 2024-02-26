using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public GameObject John;

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = transform.position;
        vector3.x = John.transform.position.x;
        transform.position = vector3;
    }
}
