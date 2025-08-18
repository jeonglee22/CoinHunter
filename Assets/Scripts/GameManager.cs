using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI score;
	public TextMeshProUGUI time;
	public TextMeshProUGUI coin;

	private int currentCoin;
	private float surviveTime;

	public GameObject gameOver;
	public TextMeshProUGUI bestScore;
	private float currentScore;

	private bool isGameOver = false;

	private void Start()
	{
		gameOver.SetActive(false);

		currentCoin = 0;
		surviveTime = 0f;
	}

	private void Update()
	{
		if (!isGameOver)
		{
			surviveTime += Time.deltaTime;
			time.text = $"Time : {Mathf.FloorToInt(surviveTime)}";
			currentScore = Mathf.FloorToInt(surviveTime) + currentCoin * 10;
			score.text = $"Score : {currentScore}";
		}
		else
		{ 
			float best = PlayerPrefs.GetFloat("BestScore", 0f);
			if(currentScore > best)
			{
				best = currentScore;
			}

			bestScore.text = $"Best Score : {best}";
			if(Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				PlayerPrefs.SetFloat("BestScore", best);
			}

			
		}
	}

	public void AddCoin()
	{
		currentCoin++;
		coin.text = $"Coin : {currentCoin}";
	}

	public void GameOver()
	{
		isGameOver = true;
		gameOver.SetActive(true);
	}

	public bool IsGameOver()
	{
		return isGameOver;
	}
}
