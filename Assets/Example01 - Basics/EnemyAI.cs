//CIS/IM 456 Example Code - Enemy AI
//Author: Owen Schaffer
//Adapted from code by Alan Thorn

//Enemy chases player constantly

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent ThisAgent = null;
    public Transform Player = null;

    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ThisAgent.SetDestination(Player.position);
    }

}