using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControllerTransform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    // Start is called before the first frame update (one per instance)
    void Start()
    {
        print("Start was called!");
        print("GameObject name: " + gameObject.name);

        // Destroy(gameObject, 5f); //delay 5 secs to destroy gameobject

        // transform.position = new Vector3(5f, 4f, 0f);
        // transform.Translate(3f, 3f, 0f); //move gameObject in x,y,z
    }

    // Update is called once per frame
    void Update()
    {
        print("Update was called!");
        // //deltaS = Speed * deltaT
        float deltaS = speed * Time.deltaTime;
        // transform.Translate(deltaS, 0f, 0f);

        // print(Input.GetKey(KeyCode.RightArrow));
        // print(Input.GetKeyDown(KeyCode.RightArrow)); //on press key
        // print(Input.GetKeyUp(KeyCode.RightArrow)); //on release key

        /*if (Input.GetKey(KeyCode.RightArrow))
           transform.Translate(deltaS, 0f, 0f);

       if (Input.GetKey(KeyCode.LeftArrow))
           transform.Translate(-deltaS, 0f, 0f);

       if (Input.GetKey(KeyCode.DownArrow))
           transform.Translate(0f, -deltaS, 0f);

       if (Input.GetKey(KeyCode.UpArrow))
           transform.Translate(0f, deltaS, 0f);*/

        // diagonal movement
        // float diagonal = deltaS * sin(45);

        //Get data in -1 to 1 into X and Y axis
        float deltaX = Input.GetAxisRaw("Horizontal") * deltaS;
        float deltaY = Input.GetAxisRaw("Vertical") * deltaS;
        
        bool diagonal = deltaX != 0  && deltaY != 0;// && deltaX == deltaY ? (float)(deltaX * (deltaS * Math.Sin(45))) : 0;
        deltaX = diagonal ? (float)(deltaX * Math.Sin(45)) : deltaX;
        deltaY = diagonal ? (float)(deltaY * Math.Sin(45)) : deltaY;

        transform.Translate(deltaX, deltaY, 0f);





    }
}
