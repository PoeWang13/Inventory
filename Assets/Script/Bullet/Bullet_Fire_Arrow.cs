using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Bullet_Fire_Arrow : MonoBehaviour
{
    [Header("Script Atamaları")]
    public int speed = 10;
    public Vector3 direction;

    public void SetBullet(Vector3 direction)
    {
        this.direction = direction;
        Destroy(gameObject, 10);
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}