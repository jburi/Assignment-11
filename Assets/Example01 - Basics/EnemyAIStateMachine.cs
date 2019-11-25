//--- Enemy chases the player and then stops after reaching the player
//--- It uses a state machine with two states: chase and idle

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIStateMachine : MonoBehaviour
{
    private NavMeshAgent ThisAgent = null;
    public Transform Player = null;
    public float ChaseDistance = 1f;
    public enum STATES { CHASE = 0, IDLE = 1 };
    [SerializeField]
    private STATES _MyStates = STATES.CHASE;

    public STATES MyStates
    {
        get { return _MyStates; }
        set
        {
            StopAllCoroutines();

            _MyStates = value;

            switch (_MyStates)
            {
                case STATES.CHASE:
                    StartCoroutine(StateChase());
                    break;

                case STATES.IDLE:
                    StartCoroutine(StateIdle());
                    break;
            }

        }
    }

    private void Start()
    {
        MyStates = _MyStates;
    }

    // Use this for initialization
    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    }

    public IEnumerator StateChase()
    {
        while (MyStates == STATES.CHASE)
        {
            ThisAgent.SetDestination(Player.position);

            if (Vector3.Distance(Player.position, transform.position) <= ChaseDistance)
            {
                MyStates = STATES.IDLE;
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator StateIdle()
    {
        while (MyStates == STATES.IDLE)
        {
            yield return null;
        }
    }
}
