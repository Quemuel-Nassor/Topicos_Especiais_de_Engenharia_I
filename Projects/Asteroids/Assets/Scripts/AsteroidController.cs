using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 2.0f;
    [SerializeField]
    private float maxSpeed = 6.0f;
    
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    Camera cam;
    InfoBarPrefab infobar;
    AsteroidSpawnerController asteroidSpawner;

    // Start is called before the first frame update
    void Start()
    {
        asteroidSpawner = GameObject.FindGameObjectWithTag("asteroidSpawner").GetComponent<AsteroidSpawnerController>();
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

        //Get reference of first cam on screen
        cam = Camera.main;

        //Get screen limits
        bottomLeftLimit = cam.ScreenToWorldPoint(new Vector3(0,0,0));
        topRightLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
        infobar = GameObject.FindGameObjectWithTag("infoBar").GetComponent<InfoBarPrefab>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCamLimits();
    }
    
    // Trigger events
    void OnTriggerEnter2D(Collider2D collider)
    {
        // print("começou a colidir");
        if(collider.CompareTag("bullet"))
        {
            infobar.IncreaseAsteroidCounter();
            asteroidSpawner.asteroidsCounter--;
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

    }
    
    void CheckCamLimits()
    {
        if(transform.position.y > topRightLimit.y)
            transform.position = new Vector3(transform.position.x, bottomLeftLimit.y,0f);
        
        if(transform.position.y < bottomLeftLimit.y)
            transform.position = new Vector3(transform.position.x, topRightLimit.y,0f);
        
        if(transform.position.x > topRightLimit.x)
            transform.position = new Vector3(bottomLeftLimit.x,transform.position.y,0f);
        
        if(transform.position.x < bottomLeftLimit.x)
            transform.position = new Vector3(topRightLimit.x,transform.position.y,0f);
    }
}
