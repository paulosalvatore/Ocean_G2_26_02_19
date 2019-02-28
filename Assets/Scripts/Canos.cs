using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canos : MonoBehaviour {

	public float velocidade = 2f;
	public float delayDestruir = 2f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, delayDestruir);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * velocidade * Time.deltaTime);
	}
}
