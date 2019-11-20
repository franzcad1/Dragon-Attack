using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    private GameController gameControllerScript;
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
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(explosion, other.transform.position, other.transform.rotation);

        if (other.gameObject.CompareTag("Player"))
        {
            // Collided with the player object
            gameControllerScript.GameOver();
        }
        Destroy(other.gameObject);  

     
        
       
    }
  
}
