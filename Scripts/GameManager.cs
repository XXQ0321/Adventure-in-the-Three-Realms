using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class GameManager : MonoBehaviour
{
    public float timer = 180; // 游戏倒计时

    public AudioSource addCoinSound; // 获得金币音效
    
    private int _coinCount; // 获得金币数量
    public int _coinAllCount; // 总金币数量

    public Text score,timerText;

    public GameObject pausePanel, winPanle,losePanel;
    private void Start()
    {
   
    }

    private void Update()
    {
       
        if (Time.timeScale == 0 || timer <= 0)
        {
            return;
        }
        
        timer -= Time.deltaTime; // 倒计时
        timerText.text ="Time:" +timer.ToString("F0")+"s";
        // 如果按下Esc键，返回主菜单
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            PauseGame();
           // BackMeunBtnClick();
        }
        
        // 如果倒计时结束，游戏结束
        if (timer <= 0)
        {
            GameOver(false);
            losePanel.SetActive(true);
        }
        else
        {
            // 设置倒计时UI显示
            
        }
    }

    // 获得金币
    public void AddGoin()
    {
        _coinCount++;
        score.text = "Score："+_coinCount.ToString();
        addCoinSound.Play();
        if (_coinCount == _coinAllCount)
        {
            GameOver(true);
            winPanle.SetActive(true);
        }
    }

    public void SubGoin()
    {
        if (_coinCount == 0)
            return;
        _coinCount--;
       
        score.text = "Score：" + _coinCount.ToString();
        //addCoinSound.Play();
        //if (_coinCount == _coinAllCount)
        //{
        //    GameOver(true);
        //    winPanle.SetActive(true);
        //}
    }

    // 游戏结束 isWin 是否胜利
    public void GameOver(bool isWin)
    {
        Time.timeScale = 0; // 暂停游戏
    }


    public void PauseGame()
    {
        Time.timeScale = 0; // 暂停游戏
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1; // 继续游戏
    }

    // 返回按钮点击
    public void BackMeunBtnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    // 重新开始按钮点击
    public void RetryBtnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
