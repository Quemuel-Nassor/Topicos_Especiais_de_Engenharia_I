using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    float linearSpeed = 5f;
    [SerializeField]
    float angularSpeed = 2f;
    Rigidbody2D rb2d;
    SpriteRenderer spr;
    
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform fireSpotTrans;

    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    Camera cam;

    // Start is called before the first frame update (one per instance)
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        //Get reference of first cam on screen
        cam = Camera.main;

        //Get screen limits
        bottomLeftLimit = cam.ScreenToWorldPoint(new Vector3(0,0,0));
        topRightLimit = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {

        CheckCamLimits();

        //create new bullet instance on specific position and orientation
        //Instantiate("Object to copy", "position", "orientation");
        if(Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletPrefab, fireSpotTrans.position, fireSpotTrans.rotation);

        //Update color
        if (Input.GetKeyDown(KeyCode.R))
            spr.color = new Color(1f, 0f, 0f);
        else if (Input.GetKeyDown(KeyCode.G))
            spr.color = new Color(0, 1f, 0f);
        else if (Input.GetKeyDown(KeyCode.B))
            spr.color = new Color(0f, 0f, 1f);

        // if (Input.GetKeyDown(KeyCode.Space))
        //     // rb2d.AddForce(new Vector2(0f, 1f) * 100f);
        //     rb2d.AddForce(Vector2.up * 300f);


    }

    // Function called one time in all update of physical engine (synchronized with physical engine)
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb2d.AddRelativeForce(Vector2.up * linearSpeed);
            //rb2d.AddForce(transform.up * linearSpeed);
        }

        rb2d.AddTorque(-angularSpeed * Input.GetAxisRaw("Horizontal"));
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

    // Object Colision events 
    /* void OnColisionEnter2D(Collision2D collision)
    {
        print("começou a colidir");
        Destroy(collision.collider.gameObject);
    }

    void OnColisionStay2D(Collision2D collision)
    {

    }

    void OnColisionExit2D(Collision2D collision)
    {

    } */
    
    // Trigger events
    void OnTriggerEnter2D(Collider2D collider)
    {
        print("começou a colidir");
        //Destroy(collider.gameObject);
    }
}
