using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedHUD : MonoBehaviour
{
    public TextMeshProUGUI SpeedTextObject;
    public FloatVariable BlyncSensorSpeed;
    float BlyncSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BlyncSpeed = BlyncSensorSpeed.value;
        SpeedTextObject.text = "Current Speed is: " + BlyncSpeed + "m/s";
    }
}
