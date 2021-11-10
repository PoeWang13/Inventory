using UnityEngine;

public class Bullet_Fire_Arrow : MonoBehaviour
{
    [Header("Script Atamaları")]
    [SerializeField] private int speed = 10;
    private Vector3 direction = Vector3.forward;

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