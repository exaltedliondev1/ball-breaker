using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameArea : MonoBehaviour
{
    public bool isHeldDown;

   

    void OnMouseExit()
    {
        isHeldDown = false;
        BallManager.Instance.SetLineOff();
    }
    void OnMouseEnter()
    {

        isHeldDown = true;
    }


    void Update()
    {

        

        if(Input.GetMouseButton(0)&& isHeldDown == true)
        {

            Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BallManager.Instance.ArrowRotation(heldPosition);
        }
     
        if(Input.GetMouseButtonUp(0)&& isHeldDown == true)
        {
            
            BallManager.Instance.BallMovement();
        }

    }
}





// On pointer down per isMouseButtonHeld true hoga ball manager ka;
// Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); we get pointer direction and send it to ball manager;
// Phir us direction me arrow roate kry ga hamara or object rotate kry ga or movement hogi hamari.


