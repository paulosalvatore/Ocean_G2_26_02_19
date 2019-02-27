using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCanos : MonoBehaviour {

	public GameObject canosPrefab;
	public float delayGerar = 2f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("GerarCano", delayGerar, delayGerar);
	}
	
	void GerarCano () {
		Instantiate(canosPrefab);
	}
}
