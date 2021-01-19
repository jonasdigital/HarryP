using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using System.Linq;
using UnityEngine.UI;


public class LightColorPicker : MonoBehaviour
{


    public MeshRenderer lightBulb;
    public Slider red;
    public Slider green;
    public Slider blue;





    public void OnEdit()
    {
        Color color = lightBulb.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        lightBulb.material.color = color;
        lightBulb.material.SetColor("_EmissionColor", color);





    }

}
