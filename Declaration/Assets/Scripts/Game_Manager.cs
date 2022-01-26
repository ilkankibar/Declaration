using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Game_Manager : MonoBehaviour
{
    public float timer = 50;
    public TextMeshProUGUI timerText;
    public Image health;
    private bool isGameStarted = false;

    public GameObject mainMenuPanel;
    public GameObject inGamePanel;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
    private void Update()
    {
        if (!isGameStarted)
        {
            timer -= Time.deltaTime;
        }
        
        timerText.text = timer.ToString("0");
        if (health.GetComponent<Slider>().value <= 0 || timer <= 0)
        {
            mainMenuPanel.SetActive(true);
            inGamePanel.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealthDown();
        }
    }
    public void PlayerHealthDown()
    {
        health.GetComponent<Slider>().value -= 0.1f;
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
        /*mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        health.GetComponent<Slider>().value = 1;
        spawner1.GetComponent<Enemy_Spawner>().isGameStarted = true;
        spawner2.GetComponent<Enemy_Spawner>().isGameStarted = true;
        spawner3.GetComponent<Enemy_Spawner>().isGameStarted = true;
        spawner4.GetComponent<Enemy_Spawner>().isGameStarted = true;
        spawner5.GetComponent<Enemy_Spawner>().isGameStarted = true;
        isGameStarted = true;
        Time.timeScale = 1;*/
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        mainMenuPanel.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        mainMenuPanel.SetActive(false);
    }
}
