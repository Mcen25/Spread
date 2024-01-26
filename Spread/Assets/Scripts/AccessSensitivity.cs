using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessSensitivity : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        MouseLook sens = player.GetComponent<MouseLook>();
        slider.onValueChanged.AddListener(sens.AdjustSpeed);
    }
}
