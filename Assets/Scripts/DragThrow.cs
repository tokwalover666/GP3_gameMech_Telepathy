using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragThrow : MonoBehaviour
{
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform sceneCamera;

    [SerializeField] private LayerMask pickUpLM;

    private objGrabbable objectGrabbable;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            if (objectGrabbable == null)
            {
                float pickUpDistance1 = 4f;

                if (Physics.Raycast(sceneCamera.position, sceneCamera.forward, out RaycastHit rraycastHit, pickUpDistance1, pickUpLM))
                {
                    if (rraycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable);
                    }
                }
            }
            else
            {
                objectGrabbable.Fire();
                objectGrabbable = null;
            }
        }
    }

}
