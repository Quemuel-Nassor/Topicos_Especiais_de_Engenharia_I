using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    float linearSpeed = 5f;
    [SerializeField]
    float angularSpeed = 2f;
    Rigidbody2D rb2d;
    SpriteRenderer spr;

    // Start is called before the first frame update (one per instance)
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddRelativeForce(Vector2.up * linearSpeed);
            // rb2d.AddForce(transform.up * linearSpeed);
        }

        rb2d.AddTorque(-angularSpeed * Input.GetAxisRaw("Horizontal"));
    }

    void OnColisionEnter2D(Collision2D collision)
    {
        print("começou a colidir");
    }

    void OnColisionStay2D(Collision2D collision)
    {

    }

    void OnColisionExit2D(Collision2D collision)
    {

    }
}
