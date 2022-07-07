using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum statusWayPoint
{
    start,
    next,
    finish
}

public class WayPoint : MonoBehaviour
{
    [SerializeField] private statusWayPoint statWayPoint;
    [SerializeField] private GameObject nextPoint;
    [SerializeField] private GameObject endPanel;





    public statusWayPoint StatusWayPoint()
    {
        return statWayPoint;
    }

    public GameObject GetendPanel()
    {
        return endPanel;
    }

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

  

    public Vector3 GetNextPoint()
    {
        return nextPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (statWayPoint != statusWayPoint.start)
        {
            PlayerControler player = other.GetComponent<PlayerControler>();
            if (player != null)
            {
                player.StopMove(this.transform.rotation);
                GetComponent<EpisodeManager>().StartEnemyMove();
            }
        }
    }
}
