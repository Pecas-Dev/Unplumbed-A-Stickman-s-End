using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 60f;

    private float timer = 0f;

    Rigidbody2D projectileRigidbody;

    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = new Vector2(speed * -1f, 0f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
