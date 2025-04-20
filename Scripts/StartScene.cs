using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public Slider slider;//定义slider 滑动条组件
    public AudioSource audio;//定义音频组件

    private void Start()
    {
        slider.onValueChanged.AddListener((value) =>//监听滑动条事件，控制音量得大小
        {
            audio.volume = value;
        });
    }

    // 开始游戏
    public void StartGame(string levelName)//点击开始游戏按钮时  Game1
    {
        Time.timeScale = 1;//时间缩放为1时候 游戏正常开始
        SceneManager.LoadScene(levelName);//跳转Game1场景 
    }
    
    // 退出游戏
    public void ExitGame()//退出游戏  绑定退出游戏按钮
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // 编辑器下退出
#else
        Application.Quit(); // 打包后退出
#endif
    }
}
