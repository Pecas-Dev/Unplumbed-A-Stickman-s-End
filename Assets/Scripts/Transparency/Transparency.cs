using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    Material material; 

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        Color color = material.color;
        color.a = 0f;
        material.color = color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Color color = material.color;
            color.a = 1f;
            material.color = color;
        }
    }
}
