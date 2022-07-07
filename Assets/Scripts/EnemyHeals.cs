using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeals : MonoBehaviour
{
    [SerializeField] private GameObject hpOnhead;

    [SerializeField] private int heals = 100;
    private int maxHeals;
    private EpisodeManager episodeManager;
    private bool alive = true;

    private void Start()
    {
        maxHeals = heals;
    }
    public void SetEpisodeManager(EpisodeManager _episodeManager)
    {
        episodeManager = _episodeManager;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;
        heals -= damage;
        if(hpOnhead != null) hpOnhead.transform.localScale = new Vector3( (float)heals/ (float)maxHeals, hpOnhead.transform.localScale.y, hpOnhead.transform.localScale.z);
        if (heals <=0 && alive)
        {
            alive = false;
            episodeManager.die();
            GetComponent<EnemyAI>().OnRegdoll();
            Destroy(hpOnhead);
        }
    }

}
