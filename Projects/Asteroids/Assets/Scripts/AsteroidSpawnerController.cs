using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;
    [SerializeField]
    float spawnInterval = 5f;

    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;
    Camera cam;


    float lastSpawnTime = 0f;
    //float timeCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference of first cam on screen
        cam = Camera.main;

        //Get screen limits
        bottomLeftLimit = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        topRightLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

    }

    // Update is called once per frame
    void Update()
    {
        //Spawn relationated with last spawn
        if ((Time.time - lastSpawnTime) >= spawnInterval)
        {
            lastSpawnTime = Time.time;
            SpawnAsteroid();
        }

        //Spawn reationated with timeCounter
        /* timeCounter += Time.deltaTime;
        if(timeCounter >= spawnInterval)
        {
            timeCounter = 0f;
            Instantiate(asteroidPrefab,Vector3.zero, Quaternion.identity);
        } */
    }

    void SpawnAsteroid()
    {
        //sort position between screen limits to spawn
        float posX = Random.Range(bottomLeftLimit.x, topRightLimit.x);
        float posY = Random.Range(bottomLeftLimit.y, topRightLimit.y);

        float size = Random.Range(0.3f, 1f);

        asteroidPrefab.transform.localScale = new Vector3(size, size, 0);
        Instantiate(asteroidPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
    }
}
