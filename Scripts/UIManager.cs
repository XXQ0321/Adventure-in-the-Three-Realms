using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText; // 显示金币的文本
    public TextMeshProUGUI timerText; // 显示计时器的文本
    public GameObject overPanel; // 游戏结束面板
    public GameObject winPanel; // 游戏胜利面板
    public TextMeshProUGUI winBtnText; // 胜利按钮文本
    // 设置金币文本
    public void SetCoinsNumberText(int coinsNumber, int coinAllNum)
    {
        coinText.text = $"{coinsNumber} / {coinAllNum}";
    }
    // 设置计时器文本
    public void SetTimerText(float time)
    {
        timerText.text = $"{time:F1} S";
    }

    // 游戏结束
    public void GameOver(bool isWin, bool isEndLevel)
    {
        // 如果胜利 激活胜利面板 并设置按钮文本
        if (isWin)
        {
            winPanel.SetActive(true);
            winBtnText.text = isEndLevel ? "OK" : "Next";
        }
        else // 失败 激活失败面板
        {
            overPanel.SetActive(true);
        }
    }
}
