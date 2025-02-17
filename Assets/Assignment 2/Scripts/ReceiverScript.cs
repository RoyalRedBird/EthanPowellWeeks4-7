using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverScript : MonoBehaviour
{

    //GOD I FUCKING LOVE THE MILITARY INDUSTRIAL COMPLEX.

    [SerializeField] GameObject stalkerReceiver;
    [SerializeField] GameObject autoReceiver;
    [SerializeField] GameObject rifleReceiver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapReceiver(int select)
    {

        if (select == 0)
        {

            stalkerReceiver.SetActive(false);
            autoReceiver.SetActive(false);
            rifleReceiver.SetActive(true);

        }

        if (select == 1)
        {

            stalkerReceiver.SetActive(true);
            autoReceiver.SetActive(false);
            rifleReceiver.SetActive(false);

        }

        if (select == 2)
        {

            stalkerReceiver.SetActive(false);
            autoReceiver.SetActive(true);
            rifleReceiver.SetActive(false);

        }

    }

}
