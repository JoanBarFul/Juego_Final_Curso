using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_IA : MonoBehaviour
{
   public NavMeshAgent nMa;
    private GameObject wayPoint;
    private Vector3 wayPointPos;


    public Transform target;

    void Start()
    {
        nMa = GetComponent<NavMeshAgent>();
        wayPoint = GameObject.Find("Player");
    }

    void Update()
    {
        nMa.SetDestination(wayPoint.transform.position);

        transform.LookAt(target);
    }
}
