using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUFO : MonoBehaviour
{
    Rigidbody2D kon;

    void Start()
    {
        kon = GetComponent<Rigidbody2D>();
        kon.AddForce(Vector3.right * 50, ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update()
    {
    }
    void onCollisionEnter2D(Collision collision)
    {
        //hoge
        // kon.angularVelocity = Vector3.up * Mathf.PI;
    }
}