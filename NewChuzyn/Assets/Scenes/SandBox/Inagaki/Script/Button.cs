using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public GameObject doa;
    private AudioSource se01;
    SpriteRenderer MainSpriteRenderer;
    public Sprite hi;
    public Sprite hy;
    private bool Playing;

    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        se01 = GetComponent<AudioSource>();
    }
	


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Playing){
            se01.Play();
            Destroy(doa);
            MainSpriteRenderer.sprite = hy;
            Playing = true;
        }
    }
}
