using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EpisodeManager : MonoBehaviour
{
    [SerializeField] private EnemyAI[] enemy;
    [SerializeField] private GameObject player;

    private WayPoint wayPoint;
    private int countOfDie = 0;
    private EpisodeManager episodeManager;

    private void Start()
    {
        wayPoint = GetComponent<WayPoint>();
        episodeManager = GetComponent<EpisodeManager>();

        foreach (EnemyAI en in enemy)
        {
            en.SetTarget(player, episodeManager);
        }
        if (wayPoint.StatusWayPoint() == statusWayPoint.start)
        {
            player.GetComponent<NavMeshAgent>().enabled = false ;
            player.transform.position = wayPoint.transform.position;
            player.transform.rotation = wayPoint.transform.rotation;
            player.GetComponent<NavMeshAgent>().enabled = true;
            StartEnemyMove();
        }

    }
    public void StartEnemyMove()
    {
        foreach(EnemyAI en in enemy )
        {
            en.StartMove();
        }
    }

    public void EndEpisode()
    {
        wayPoint.GetendPanel().SetActive(true);
    }

    public void die()
    {
        countOfDie++;
        if(countOfDie >= enemy.Length)
        {
            if(wayPoint.StatusWayPoint() != statusWayPoint.finish)
            {
                player.GetComponent<PlayerControler>().MoveTo(wayPoint.GetNextPoint());
            }
            else
            {
                EndEpisode();
                
            }
            
        }
    }

}
