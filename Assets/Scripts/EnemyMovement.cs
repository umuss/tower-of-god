using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    [SerializeField]
    private Animator Animator;
    public float UpdateRate = 0.1f;
    private NavMeshAgent Agent;
    private float Distance = 0.0f;
    private float lookAtDistance = 7.0f;


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
       
    }

    private void Start()
    {
        Animator.SetFloat("Speed",0.5f);
        StartCoroutine(FollowTarget());
    }

    

    private void Update()
    {
        Distance = Vector3.Distance(Player.position, transform.position);
        if (Distance < lookAtDistance)
        {
            Animator.SetFloat("Speed",0.0f);
            Agent.Stop();
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
        
        while(enabled)
        {
            Agent.SetDestination(Player.transform.position - (Player.transform.position - transform.position).normalized * 0.5f);
            yield return Wait;
        }
    }
}