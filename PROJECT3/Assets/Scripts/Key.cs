using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{ private End endScript;
    public float tumble = 200;

    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.angularVelocity = Random.value * tumble;

        GameObject endPortal = GameObject.FindWithTag("EndPortal");

        if (endPortal != null)
        {
            // I got the game controller object!
           endScript = endPortal.GetComponent<End>();

            if (endScript == null)
            {
                // There is no GameController script on my game controller object
                Debug.Log("Cannot find End script on GameController object");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Sol")
        {
            Destroy(this.gameObject);
            endScript.KeyGrab();
        }
    }

}
