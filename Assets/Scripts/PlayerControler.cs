using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private GameObject bulPrefab;
    [SerializeField] private GameObject bulPoint;
    [SerializeField] private int bulSpeed = 100;


    private Camera camera;
    private NavMeshAgent nawMeshAgent;
    private Animator animator;

    private bool isMove = false;
    private bool isAlive = true;
    void Start()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
        nawMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!isAlive) return;

        if(Input.GetMouseButtonDown(0))
        {
            if (isMove) return;
            animator.SetTrigger("fire");

            
            RaycastHit hit;
            if(Physics.Raycast( camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                

                GameObject bul = Instantiate(bulPrefab, bulPoint.transform.position, bulPoint.transform.rotation);
                Vector3 vec = hit.point - bulPoint.transform.position; 
                bul.GetComponent<Rigidbody>().AddForce(vec * bulSpeed);
            }
        }
    }

    public void MoveTo(Vector3 point)
    {
        nawMeshAgent.SetDestination(point);
        animator.SetTrigger("walk");
        isMove = true;
    }

    public void StopMove(Quaternion rot)
    {
        nawMeshAgent.updateRotation = false;
        this.transform.rotation = rot;
        nawMeshAgent.updateRotation = true;
        animator.SetTrigger("stand");
        animator.ResetTrigger("fire");
        isMove = false;
    }

    public void Die()
    {
        animator.SetTrigger("die");
        isAlive = false;
    }
}
