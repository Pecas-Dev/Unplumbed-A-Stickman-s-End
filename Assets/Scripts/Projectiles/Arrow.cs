using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float zRotation;

    public float speed = 10f;
    public float lifetime = 60f;

    float waitTime = 0.1f;

    private float timer = 0f;

    Rigidbody2D projectileRigidbody;
    CapsuleCollider2D capsuleCollider;

    CharacterMovementComplete playerMovement;
    void Start()
    {
        zRotation = 0;

        projectileRigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.isTrigger = true;
        StartCoroutine(EnableCollision());
    }

    public void Shoot(Vector2 direction)
    {
        projectileRigidbody = GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * speed;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EnableCollision()
    {
        yield return new WaitForSeconds(waitTime);

        capsuleCollider.isTrigger = false;
    }
}