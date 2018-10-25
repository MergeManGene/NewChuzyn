using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public GameObject doa;
    private AudioSource se01;
    void Start () {
        se01 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        se01.Play();
        Destroy(doa);
        Debug.Log("へい");

    }
}
