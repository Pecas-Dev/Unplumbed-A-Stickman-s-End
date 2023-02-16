using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0f, 4.0f, -10f);
    }
}
