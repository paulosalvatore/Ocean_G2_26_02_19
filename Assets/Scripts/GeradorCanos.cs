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
		GameObject cano = Instantiate(canosPrefab);

		Vector3 posicaoCano = cano.transform.position;
		posicaoCano.y = Random.Range(-0.34f, 0.24f);
		cano.transform.position = posicaoCano;

		Transform moeda = cano.transform.Find("Moeda");

		Vector3 posicaoMoeda = moeda.localPosition;
		posicaoMoeda.y = Random.Range(-0.5f, 0.5f);
		moeda.localPosition = posicaoMoeda;
	}
}
