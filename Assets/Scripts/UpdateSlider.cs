using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateSlider : MonoBehaviour
{
    private float updater;
    public Slider thisSlider;
    public StartGame playerPrefs;

    void Start()
    {
        thisSlider = gameObject.GetComponent<Slider>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSlider(float difficulty)
    {  
        thisSlider.value = difficulty;
    }

    public float getValue()
    {
        return thisSlider.value;
    }
}
