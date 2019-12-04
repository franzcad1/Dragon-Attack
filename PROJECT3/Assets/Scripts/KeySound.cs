using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour
{
    public AudioSource ding;
    // Start is called before the first frame update
    void Start()
    {
        ding = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Sol")
        {

            ding.Play();
        }
    }
}
