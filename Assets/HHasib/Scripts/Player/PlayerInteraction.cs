using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] float interactRange;
    public bool IsInteractable;
    PlayerMovement playerMovement;

    public NavMeshAgent agent;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        PlayerInputSystem.OnInteractionPressed += Interect;
    }

    private void OnDisable()
    {
        PlayerInputSystem.OnInteractionPressed -= Interect;
    }


    public void Interect()
    {
        
       Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach(Collider collider in colliderArray)
        {

            if (collider.CompareTag("NPC") && collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.NPCAction();
                if (collider.GetComponent<NPC>())
                {
                   
                    GameObject childObject = collider.gameObject.transform.Find("PlayerPosition").gameObject;

                   // this.gameObject.transform.position = childObject.transform.position;

                    agent.SetDestination(childObject.transform.position);
                    StartCoroutine(LookAt(collider));

                

                }

                
            }

            
           // Debug.Log(collider);
        }

    }

    public bool InterectDetection()
    {
       
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {

            if (collider.CompareTag("NPC"))
            {
                return true;
            }

            
            
        }
        return false;
    }



    

        IEnumerator LookAt(Collider collider)
        {
            while (agent.pathPending || agent.remainingDistance > 0.1f)
            {
                yield return null;
            }

            playerMovement.LookTowards(collider.gameObject);


        }


    


}
