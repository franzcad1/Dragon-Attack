using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public AudioSource ding;
    private GameController gameControllerScript;
    private Timer timerScript;
    private bool hasKey;
    public GameObject ClosedPortal;
    public Text needKeyText;

    // Start is called before the first frame update
    void Start()
    {
        ding = GetComponent<AudioSource>();
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
            if (hasKey == true)
            {
                Destroy(co.gameObject);
                timerScript.Finish();
                gameControllerScript.Win();
            }

            else
            {
                ding.Play();
                needKeyText.gameObject.SetActive(true);
            }

        }
    }

    void OnTriggerExit2D(Collider2D co)
    {
       
                needKeyText.gameObject.SetActive(false);
            

        
    }

    public void KeyGrab()
    {
        ClosedPortal.gameObject.SetActive(false);
        hasKey = true;
    }
}

