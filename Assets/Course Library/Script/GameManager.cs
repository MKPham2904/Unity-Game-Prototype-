using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SocialPlatforms.Impl;
using NUnit.Framework;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    private int score;
    private float spawnRate = 1.0f;

    public Button restartButton;

    public bool isGameActive=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isGameActive)
        {
            StartCoroutine(SpawnTarget());
            score = 0;
            UpdateScore(0);
        }
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
