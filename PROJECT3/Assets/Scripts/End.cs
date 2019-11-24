using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private GameController gameControllerScript;
    private Timer timerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            // I got the game controller object!
            gameControllerScript = gameControllerObject.GetComponent<GameController>();

            if (gameControllerScript == null)
            {
                // There is no GameController script on my game controller object
                Debug.Log("Cannot find GameController script on GameController object");
            }
        }

        if (gameControllerObject != null)
        {
            // I got the game controller object!
            timerScript = gameControllerObject.GetComponent<Timer>();

            if (timerScript == null)
            {
                // There is no GameController script on my game controller object
                Debug.Log("Cannot find Timer script on GameController object");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Sol")
        {
            Destroy(co.gameObject);
            timerScript.Finish();
            gameControllerScript.Win();
            

        }


    }
}

