using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  


    private bool isMouseButtonHeld;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isMouseButtonHeld = true;
            Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BallManager.Instance.clickEnable = true;
            BallManager.Instance.ArrowRotation(heldPosition);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Left mouse button is released
            //isMouseButtonHeld = false;
        }
    }

    void Update()
    {
        if (isMouseButtonHeld)
        {
            
        }
    }
}


// On pointer down per isMouseButtonHeld true hoga ball manager ka;
// Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); we get pointer direction and send it to ball manager;
// Phir us direction me arrow roate kry ga hamara or object rotate kry ga or movement hogi hamari.


