/*
 Credit to this code goes to Juul1a.
 YouTube: https://www.youtube.com/@juul1a

 Thank you so much!! You saved my life and I learend a lot!!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    public GameObject connectedAbove;
    public GameObject connectedBelow;

    public bool isPlayerAttached;

    void Start()
    {
        ResetAnchor();
    }

    public void ResetAnchor()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        RopeSegment aboveSegment = connectedAbove.GetComponent<RopeSegment>();

        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
