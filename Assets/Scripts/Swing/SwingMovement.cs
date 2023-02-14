/*
 Credit to this code goes to Juul1a.
 YouTube: https://www.youtube.com/@juul1a

 Thank you so much!! You saved my life and I learend a lot!!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    private HingeJoint2D playerHingeJoint;

    public float pushForce = 10f;

    public bool attached = false;
    public Transform attachedTo;
    private GameObject disregard;

    void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerHingeJoint = gameObject.GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        CheckKeyboardInputs();
    }

    void CheckKeyboardInputs()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (attached)
            {
                playerRigidbody.AddRelativeForce(new Vector3(-1, 0, 0) * pushForce);
            }
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (attached)
            {
                playerRigidbody.AddRelativeForce(new Vector3(1, 0, 0) * pushForce);
            }
        }

        /*if (Input.GetKey("w") || Input.GetKey("up") && attached)
        {
            Slide(1);
        }*/

        if (Input.GetKey("s") || Input.GetKey("down") && attached)
        {
            Slide(-1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Detach();
        }
    }

    public void Attach(Rigidbody2D ropeBone)
    {
        if (ropeBone == null)
        {
            return;
        }

        //ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        playerHingeJoint.connectedBody = ropeBone;
        playerHingeJoint.enabled = true;
        attached = true;
        attachedTo = ropeBone.gameObject.transform.parent;


    }

    void Detach()
    {
        playerHingeJoint.enabled = false;
        playerHingeJoint.connectedBody = null;

        attached = false;
    }



    public void Slide(int direction)
    {
        RopeSegment myConnection = playerHingeJoint.connectedBody.gameObject.GetComponent<RopeSegment>();
        GameObject newSegment = null;

        if (direction == 1)
        {
            if (myConnection.connectedAbove != null)
            {
                if (myConnection.connectedAbove.gameObject.GetComponent<RopeSegment>() != null)
                {
                    newSegment = myConnection.connectedAbove;
                }
            }
        }

        else
        {
            if (direction == -1)
            {
                if (myConnection.connectedBelow != null)
                {
                    newSegment = myConnection.connectedBelow;
                }
            }
        }

        if (newSegment != null)
        {
            transform.position = newSegment.transform.position;
            myConnection.isPlayerAttached = false;
            newSegment.GetComponent<RopeSegment>().isPlayerAttached = true;
            playerHingeJoint.connectedBody = newSegment.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!attached)
        {
            if (collision.gameObject.tag == "Rope")
            {
                if (attachedTo != collision.gameObject.transform.parent)
                {
                    if (disregard == null || collision.gameObject.transform.parent.gameObject != disregard)
                    {
                        Attach(collision.gameObject.GetComponent<Rigidbody2D>());
                    }
                }
            }
        }
    }

}

