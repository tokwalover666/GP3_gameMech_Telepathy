using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objGrabbable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;
    [SerializeField] private float dragForce = 500;

    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }


    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false;
    }

    public void Fire()
    {
        objectGrabPointTransform = null;
        objectRB.useGravity = true;
        objectRB.velocity = Vector3.zero; // Reset velocity before applying force
        objectRB.AddForce(dragForce * Time.deltaTime * Camera.main.transform.forward, ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 8f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRB.MovePosition(newPosition);
        }
    }

}
