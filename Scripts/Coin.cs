using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float range; 
    public float rotateSpeed;
    
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        transform.Rotate(0 ,0, rotateSpeed * Time.deltaTime);
        transform.position += Mathf.Sin(Time.time) * Vector3.up * range * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().AddGoin();
        }
    }
}
