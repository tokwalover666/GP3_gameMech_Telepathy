using UnityEngine;

public class objGrabbable : MonoBehaviour
{
    private Rigidbody objectRB;
    private Transform objectGrabPointTransform;
    [SerializeField] private float dragForce = 500;
    public Camera camTransform;

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

        this.objectGrabPointTransform = null;
        objectRB.useGravity = true;
        Vector3 throwDirection = camTransform.transform.forward;
        objectRB.AddForce(throwDirection * dragForce);

    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 8f;
            // Move the object towards the grab point using Lerp
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRB.MovePosition(newPosition);
        }
    }
}
