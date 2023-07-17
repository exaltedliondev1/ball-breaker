using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameArea : MonoBehaviour
{
    public bool isOnArea;
    public ObjectSlider objectSlider;



    void OnMouseExit()
    {
        isOnArea = false;
        objectSlider.SliderActive = true;
        BallManager.Instance.SetLineOff();
    }
    void OnMouseEnter()
    {
        objectSlider.SliderActive = false;
        isOnArea = true;
    }


    void Update()
    {

        

        if(Input.GetMouseButton(0)&& isOnArea == true)
        {

            Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BallManager.Instance.ArrowRotation(heldPosition);
        }
     
        if(Input.GetMouseButtonUp(0)&& isOnArea == true)
        {
            
            BallManager.Instance.BallMovement();
        }

       

    }
}



// On pointer down per isMouseButtonHeld true hoga ball manager ka;
// Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); we get pointer direction and send it to ball manager;
// Phir us direction me arrow roate kry ga hamara or object rotate kry ga or movement hogi hamari.


