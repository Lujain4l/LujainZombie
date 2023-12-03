using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiLocation : MonoBehaviour


{   private BulletScript hi = new BulletScript();    
    private bool x;
    public Transform playerTransForm;
    public float maxTime = 1.0f;
    public float maxDis = 1.0f;
    NavMeshAgent agent;
    Animator animator;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float sqdistance = (playerTransForm.position - agent.destination).sqrMagnitude;
            if (sqdistance > maxDis * maxDis)
            {
                agent.destination = playerTransForm.position;
            }
            timer = maxDis;
        }
        //animator.SetFloat("speed", agent.velocity.magnitude);
        x = hi.gitHit();
      


    }
    private void LateUpdate()
    {
        if (x)
        {
            Debug.Log("doneeeeeeee");

            anim();
        }
    }

    void anim ()
    {
        animator.SetBool(0, true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="bu")
        {
            Debug.Log("jjjj");
        }
    }
}
