using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float range; // 上下浮动范围
    public float rotateSpeed; // 自转速度
    
    private void Update()
    {
        if (Time.timeScale == 0)//当游戏结束时 金币停止转动
        {
            return;
        }
        
        // 自转
        transform.Rotate(0 ,0, rotateSpeed * Time.deltaTime);//金币自身围绕y轴旋转
        // 浮动
        transform.position += Mathf.Sin(Time.time) * Vector3.up * range * Time.deltaTime;//金币位置随机变化
    }

    private void OnTriggerEnter(Collider other)//碰撞检测
    {
        if (other.transform.tag.Equals("Player"))//当金币触碰玩家时候
        {
            Destroy(gameObject);//销毁金币
            
            // 增加金币
            FindObjectOfType<GameManager>().AddGoin();//ui数量增加1
        }
    }
}
