using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float rengToAtack = 5;
    [SerializeField] private Rigidbody[] rigidbody;

    private Animator animator;
    private NavMeshAgent nawMeshAgent;
    private GameObject targetPoint;
    private bool active = false;
    private bool live = true;
    private EpisodeManager episodeManager;
    // Start is called before the first frame update
    void Start()
    {
        nawMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        foreach (Rigidbody rb in rigidbody)
        {
            rb.isKinematic = true;
        }
    }

    void Update()
    {
        if (!live) return;
        if(active)
        {
            if(rengToAtack > Vector3.Distance(this.transform.position, targetPoint.transform.position))
            {
                animator.SetTrigger("atack");
                nawMeshAgent.Stop();
                targetPoint.GetComponent<PlayerControler>().Die();
                episodeManager.EndEpisode();
            }
        }
    }


    public void SetTarget(GameObject _targetPoint, EpisodeManager _episodeManager)
    {
        targetPoint = _targetPoint;
        episodeManager = _episodeManager;
        GetComponent<EnemyHeals>().SetEpisodeManager(_episodeManager);
    }

    public void StartMove()
    {
        nawMeshAgent.SetDestination(targetPoint.transform.position);
        animator.SetTrigger("wolk");
        active = true;
    }

    public void OnRegdoll()
    {
        live = false;
        GetComponent<Animator>().enabled = false;
        nawMeshAgent.Stop();
        foreach (Rigidbody rb in rigidbody)
        {
            rb.isKinematic = false;
        }
    }

}
