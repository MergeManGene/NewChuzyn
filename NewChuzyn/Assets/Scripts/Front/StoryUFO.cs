using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryUFO : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.005f, 0, 0);
	}
}
