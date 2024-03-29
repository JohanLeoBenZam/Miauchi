using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesMovement : MonoBehaviour
{
    float mousePosX;
    float mousePosY;

    public float movementQuantity;

    void Start()
    {
        
    }

    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2 (
            (mousePosX / Screen.width) * movementQuantity + (Screen.width / 2),
            (mousePosY / Screen.height) * movementQuantity + (Screen.height / 2));
    }
}
