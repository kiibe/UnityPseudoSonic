using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {

    public float velocidad = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float camera = Camera.main.gameObject.transform.position.x;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(camera * velocidad, 0);

	}
}
