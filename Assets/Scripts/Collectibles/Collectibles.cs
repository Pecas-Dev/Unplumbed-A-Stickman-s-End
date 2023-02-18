using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    CollectibleManager collectibleManager;

    void Start()
    {
        collectibleManager = FindAnyObjectByType<CollectibleManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collection")
        {
            Destroy(collision.gameObject);

           
            if (collectibleManager != null)
            {
                collectibleManager.CollectItem();
            }
        }
    }

}
