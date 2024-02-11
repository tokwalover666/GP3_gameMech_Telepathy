using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VoodooHandler : MonoBehaviour
{
    private NavMeshAgent voodoo;
    public Transform TargetPlayer;

    public GameObject GameOver;
    void Start()
    {
        voodoo = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        voodoo.SetDestination(TargetPlayer.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {

            Debug.Log("item hit enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.SetActive(true);
        }



    }
}
