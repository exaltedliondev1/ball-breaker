using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectSlider : MonoBehaviour
{
    public Slider slider;
    void Update()
    {
        float rotationValue = slider.value;
        BallManager.Instance.ArrowRotateOnSlider(rotationValue);
    }
    
}
