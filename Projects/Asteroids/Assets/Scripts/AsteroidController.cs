using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 2.0f;
    [SerializeField]
    private float maxSpeed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();

        //Generate random speed
        float speed = Random.Range(minSpeed,maxSpeed);

        //Calculate random direction between [-1,1]
        float dirX = Random.Range(-1.1f,1.1f);
        float dirY = Random.Range(-1.1f,1.1f);
        Vector2 direction = new Vector2(dirX,dirY);

        //Normalize vector direction to control velocity
        direction.Normalize();
        rb2D.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Trigger events
    void OnTriggerEnter2D(Collider2D collider)
    {
        print("começou a colidir");
        if(collider.CompareTag("bullet"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

    }
}
