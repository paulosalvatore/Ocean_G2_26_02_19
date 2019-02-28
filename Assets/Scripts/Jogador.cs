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
	public Text pontosText2;
	public Text highscoreText;
	int pontos = 0;
	int highscore = 0;

	public GameObject telaStart;

	public GameObject telaGameOver;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		highscore = PlayerPrefs.GetInt("Highscore");
		AtualizarHighscore();

		telaStart.SetActive(true);
		telaGameOver.SetActive(false);

		Time.timeScale = 0f;

		Screen.SetResolution(
			500,
			888,
			true
		);
	}
	
	// Update is called once per frame
	void Update () {
		if (!telaGameOver.activeSelf && Input.GetMouseButtonDown(0))
		{
			Time.timeScale = 1f;
			telaStart.SetActive(false);

			Pular();
		}
	}

	public void ReiniciarJogo()
	{
		SceneManager.LoadScene(0);
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
			telaGameOver.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("ColisorPontos"))
		{
			Destroy(collision.gameObject);

			pontos++;
			pontosText.text = pontos.ToString("D7");
			pontosText2.text = pontos.ToString();

			if (pontos > highscore)
			{
				highscore = pontos;
				AtualizarHighscore();

				PlayerPrefs.SetInt("Highscore", highscore);
			}
		}
	}

	private void AtualizarHighscore()
	{
		highscoreText.text = highscore.ToString("D7");
	}
}
