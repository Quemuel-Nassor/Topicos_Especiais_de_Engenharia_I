using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReloaderPrefab : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spr;
    InfoBarPrefab infobar;
    Camera cam;
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;
    float lastSpawnTime = 0f;
    [SerializeField]
    float spawnInterval = 30f;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference of first cam on screen
        cam = Camera.main;

        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        infobar = GameObject.FindGameObjectWithTag("infoBar").GetComponent<InfoBarPrefab>();

        //Get screen limits
        bottomLeftLimit = cam.ScreenToWorldPoint(new Vector3(2f, 2f, 0));
        topRightLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

    }

    // Update is called once per frame
    void Update()
    {
        //Spawn relationated with last spawn
        if ((Time.time - lastSpawnTime) >= spawnInterval)
        {
            lastSpawnTime = Time.time;
            SpawnBulletReloader();
        }
    }

    // Trigger events
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("player"))
        {
            if ((infobar.BulletCounter + 5) <= 10)
                infobar.BulletCounter += 5;
            if ((infobar.BulletCounter + 5) > 10)
                infobar.BulletCounter = 10;
            
            transform.position = new Vector3(topRightLimit.x, topRightLimit.y + 10f, 0f);
        }
    }

    void SpawnBulletReloader()
    {
        float x = Random.Range(bottomLeftLimit.x, topRightLimit.x);
        float y = Random.Range(bottomLeftLimit.y, topRightLimit.y - 2f);
        transform.position = new Vector3(x, y, 0f);
    }
}
