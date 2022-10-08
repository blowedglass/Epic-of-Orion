using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIoControl : MonoBehaviour
{

    GameObject[] goalLocations;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       
        goalLocations = GameObject.FindGameObjectsWithTag("Goal");
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        anim = this.GetComponent<Animator>();
        anim.SetFloat("wOffset", Random.Range(0f,1f));
        anim.SetTrigger("isWalking");
        float sm = Random.Range(0.75f, 1.5f);
        anim.SetFloat("speedMult", sm);
        agent.speed *= sm;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1f)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
