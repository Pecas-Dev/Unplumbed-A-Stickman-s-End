/*
 Credit to this code goes to Juul1a & Brackeys.

 Juul1a's YouTube: https://www.youtube.com/@juul1a
 Brackeys's YouTube: https://www.youtube.com/@Brackeys

 Thank you so much!! You saved my life and I learend a lot!!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    // [SerializeField] float colliderActivationTime = 1.0f;
    public int numLinks = 5;

    public Rigidbody2D hook;
    public GameObject[] prefabRopeSegments;

    public HingeJoint2D top;

    //public TempMove player;

    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<TempMove>();
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;

        for (int i = 0; i < numLinks; i++)
        {
            //int index = Random.Range(0, prefabRopeSegments.Length);

            GameObject newSegment = Instantiate(prefabRopeSegments[i % prefabRopeSegments.Length]);
            newSegment.transform.parent = transform;
            newSegment.transform.position = transform.position;

            HingeJoint2D hingeJoint = newSegment.GetComponent<HingeJoint2D>();
            hingeJoint.connectedBody = prevBod;

            prevBod = newSegment.GetComponent<Rigidbody2D>();

            if(i == 0)
            {
                top = hingeJoint;
            }

            //BoxCollider2D segmentCollider = newSegment.GetComponent<BoxCollider2D>();
            //segmentCollider.isTrigger = true;
            //StartCoroutine(ActivateCollider(segmentCollider));
        }
    }
}
