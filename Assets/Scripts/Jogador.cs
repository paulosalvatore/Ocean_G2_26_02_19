using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {

	Rigidbody2D rb;
	public float forcaPulo = 100f;

	public Text pontosText;
	int pontos = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Pular();
		}
	}

	private void Pular()
	{
		rb.velocity = Vector2.zero;
		rb.AddForce(Vector2.up * forcaPulo);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Inimigo"))
		{
			SceneManager.LoadScene(0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("ColisorPontos"))
		{
			pontos++;
			pontosText.text = "Pontos: " + pontos;
		}
	}
}
