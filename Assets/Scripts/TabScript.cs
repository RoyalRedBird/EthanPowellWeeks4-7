using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabScript : MonoBehaviour
{

    [SerializeField] GameObject tab1;
    [SerializeField] GameObject tab2;
    [SerializeField] GameObject tab3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTab1() { 
    
        tab1.SetActive(true);
        tab2.SetActive(false);
        tab3.SetActive(false);
    
    }

    public void ToggleTab2()
    {

        tab1.SetActive(false);
        tab2.SetActive(true);
        tab3.SetActive(false);

    }

    public void ToggleTab3()
    {

        tab1.SetActive(false);
        tab2.SetActive(false);
        tab3.SetActive(true);

    }

}
