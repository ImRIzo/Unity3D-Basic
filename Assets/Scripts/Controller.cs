using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject plane;
    public void ScalePlane()
    {
        float planeSize = slider.value;
        plane.transform.localScale = new Vector3 (planeSize, 1, planeSize);
    }
}
