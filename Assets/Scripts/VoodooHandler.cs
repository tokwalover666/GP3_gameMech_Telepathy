using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VoodooHandler : MonoBehaviour
{
    public NavMeshAgent voodoo;
    public Transform TargetPlayer;
    public GameObject gameOver;

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
            gameObject.SetActive(false);


        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("enemy hit player");
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }



    }
}
