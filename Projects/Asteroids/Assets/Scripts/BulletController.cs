using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float forceIntensity = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d;
        rb2d = GetComponent<Rigidbody2D>(); 

        //Add force to front of reference object
        rb2d.AddForce(transform.up * forceIntensity);  

        //Destroy component after 5 secs
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
