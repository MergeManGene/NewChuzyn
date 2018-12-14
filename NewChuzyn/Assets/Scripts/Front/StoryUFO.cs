using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUFO : MonoBehaviour
{
    private Rigidbody2D kon;

    [SerializeField]
    private int speed = 100;

    private void Start()
    {
        kon = GetComponent<Rigidbody2D>();
        kon.AddForce(Vector3.right * speed, ForceMode2D.Force);

    }

}