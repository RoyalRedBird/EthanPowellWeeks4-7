using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    Slider testSlider;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
        testSlider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        testSlider.value = time % testSlider.maxValue;
        
    }
}
