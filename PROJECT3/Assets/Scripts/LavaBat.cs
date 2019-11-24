using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBat : MonoBehaviour
{

    public Transform player;
    public GameObject explosion;
    
    private GameController gameControllerScript;
    public float speed = 0.3f;

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
    }

    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (transform.position != player.position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            player.position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
    
    }
  

        void OnTriggerEnter2D(Collider2D co)
        {
        if (co.name == "Sol")
        {
            Destroy(co.gameObject);

            gameControllerScript.GameOver();
            Instantiate(explosion, co.transform.position, co.transform.rotation);
        }
        

    }





}
