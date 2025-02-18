using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiverScript : MonoBehaviour
{

    //The GameObjects for each of the receiver types.
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

    //Takes the input from the Receiver drop down and changes which receiver/optic is being displayed to the user.
    public void SwapReceiver(int select) 
    {

        if (select == 0) //Displays the standard Rifle receiver and scope.
        {

            stalkerReceiver.SetActive(false);
            autoReceiver.SetActive(false);
            rifleReceiver.SetActive(true);

        }

        if (select == 1) //Displays the Stalker receiver and sniper scope.
        {

            stalkerReceiver.SetActive(true);
            autoReceiver.SetActive(false);
            rifleReceiver.SetActive(false);

        }

        if (select == 2) //Displays the auto receiver without an optic.
        {

            stalkerReceiver.SetActive(false);
            autoReceiver.SetActive(true);
            rifleReceiver.SetActive(false);

        }

    }

}
