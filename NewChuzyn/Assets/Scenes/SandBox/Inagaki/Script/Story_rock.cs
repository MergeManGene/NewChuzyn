using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_rock : MonoBehaviour {

    private Rigidbody2D kon;

    [SerializeField]
    private int speed = 600;

    private void Start()
    {
        kon = GetComponent<Rigidbody2D>();
        kon.AddForce(Vector3.left * speed, ForceMode2D.Force);

    }

}
