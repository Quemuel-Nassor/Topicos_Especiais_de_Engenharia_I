using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    float linearSpeed = 3f;
    // [SerializeField]
    // float angularSpeed = 18f;
    Rigidbody2D rb2d;
    SpriteRenderer spr;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform fireSpotTrans;
    [SerializeField]
    Transform target;

    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    [SerializeField]
    InfoBarPrefab infobar;
    [SerializeField]
    float shooterInterval = 0.2f;
    [SerializeField]
    int shooterCounter = 0;
    float lastShooterTime = 0f;
    float displayInterval = 15f;

    Camera cam;

    // Start is called before the first frame update (one per instance)
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        //Get reference of first cam on screen
        cam = Camera.main;

        //Get screen limits
        bottomLeftLimit = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        topRightLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        infobar = GameObject.FindGameObjectWithTag("infoBar").GetComponent<InfoBarPrefab>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckCamLimits();
        ShowEnemy();

        rb2d.velocity = Vector2.right * linearSpeed;
        // rb2d.AddRelativeForce(Vector2.right);
        // //create new bullet instance on specific position and orientation
        // //Instantiate("Object to copy", "position", "orientation");
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (infobar.BulletCounter > 0)
        //     {
        //         Instantiate(bulletPrefab, fireSpotTrans.position, fireSpotTrans.rotation);
        //         infobar.DecreaseBulletCounter();
        //     }
        // }

        // //Update color
        // if (Input.GetKeyDown(KeyCode.R))
        //     spr.color = new Color(1f, 0f, 0f);
        // else if (Input.GetKeyDown(KeyCode.G))
        //     spr.color = new Color(0, 1f, 0f);
        // else if (Input.GetKeyDown(KeyCode.B))
        //     spr.color = new Color(0f, 0f, 1f);

        // if (Input.GetKeyDown(KeyCode.Space))
        //     // rb2d.AddForce(new Vector2(0f, 1f) * 100f);
        //     rb2d.AddForce(Vector2.up * 300f);


    }

    // Function called one time in all update of physical engine (synchronized with physical engine)
    void FixedUpdate()
    {
        //     if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //     {
        //         rb2d.AddRelativeForce(Vector2.up * linearSpeed);
        //         //rb2d.AddForce(transform.up * linearSpeed);
        //     }

        //     rb2d.AddTorque(-angularSpeed * Input.GetAxisRaw("Horizontal"));
    }

    void CheckCamLimits()
    {
        if (transform.position.y > topRightLimit.y)
            transform.position = new Vector3(transform.position.x, bottomLeftLimit.y, 0f);

        if (transform.position.y < bottomLeftLimit.y)
            transform.position = new Vector3(transform.position.x, topRightLimit.y, 0f);

        if (transform.position.x > topRightLimit.x)
            transform.position = new Vector3(bottomLeftLimit.x, transform.position.y, 0f);

        if (transform.position.x < bottomLeftLimit.x)
            transform.position = new Vector3(topRightLimit.x, transform.position.y, 0f);
    }

    // Trigger events
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("bullet"))
        {
            Destroy(collider.gameObject);
            infobar.IncreaseEnemyCounter();
            RespawnShip();
        }
    }

    void ShowEnemy()
    {
        //Spawn relationated with last spawn
        // if ((Time.time - lastShooterTime) >= shooterInterval && shooterCounter < 5)
        if ((Time.time - lastShooterTime) >= shooterInterval)
        {
            lastShooterTime = Time.time;
            // Quaternion inverse = Quaternion.Inverse(target.rotation);
            // Quaternion targetDirection = new Quaternion(inverse.x, inverse.y, target.rotation.z, target.rotation.w);
            Quaternion targetDirection = new Quaternion();//fireSpotTrans.rotation;
            targetDirection.SetFromToRotation(fireSpotTrans.position, target.position);
            fireSpotTrans.rotation = Quaternion.FromToRotation(fireSpotTrans.position, target.position);
            // targetDirection = new Quaternion(targetDirection.x, targetDirection.y, targetDirection.z, targetDirection.w);
            print("x: "+targetDirection.x); 
            print("y: "+targetDirection.y); 
            print("z: "+targetDirection.z); 
            print("w: "+targetDirection.w);
            
            // Quaternion targetDirection = target.rotation;
            // Instantiate(bulletPrefab, fireSpotTrans.position, targetDirection);
            Instantiate(bulletPrefab, fireSpotTrans.position, fireSpotTrans.rotation);
            shooterCounter++;
        }
        if (shooterCounter >= 5)
        {
            shooterCounter = 0;
            // lastShooterTime += 5;
        }
    }

    void RespawnShip()
    {
        Vector3 respawn = new Vector3(topRightLimit.x, topRightLimit.y + 10f, 0f);
        rb2d.velocity = respawn;
        transform.position = respawn;
        transform.rotation = Quaternion.identity;
    }
}
