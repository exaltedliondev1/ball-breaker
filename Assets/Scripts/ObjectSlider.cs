using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSlider : MonoBehaviour
{
    public Slider slider;
    public bool SliderActive;

    


    void Update()
    {
        

        if (SliderActive)
        {
            if (Input.GetMouseButton(0))
            {
                float rotationValue = slider.value;
                BallManager.Instance.ArrowRotateOnSlider(rotationValue);
            }

            if (Input.GetMouseButtonUp(0))
                OnReleasedSlider();

        }



    }
    

    public void OnReleasedSlider()
    {
        slider.value = 0;
        BallManager.Instance.SetLineOff();
        BallManager.Instance.SliderBallMovement();
    }

}
