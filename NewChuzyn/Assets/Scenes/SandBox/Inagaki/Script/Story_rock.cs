using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_rock : MonoBehaviour {

    Rigidbody2D kon;

    void Start()
    {
        kon = GetComponent<Rigidbody2D>();
        kon.AddForce(Vector3.left * 600, ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update()
    {
        //kon.velocity = new Vector3(0,5f,0);
    }
    void onCollisionEnter2D(Collision collision)
    {
        // kon.angularVelocity = Vector3.up * Mathf.PI;
    }
}
