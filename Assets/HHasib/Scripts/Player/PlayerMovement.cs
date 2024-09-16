using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;

   
    private RaycastHit rayCastHit;
    public NavMeshAgent agent;
    private string groundTag = "Ground";

    CharacterController controller;


    //Player

    public float walkSpeed=4;
    public float RunSpeed=8;


    public GameObject movePoint;
    GameObject tempMove;
    Vector3 pointToMove;


    //Animation

   


    [SerializeField] Animator animator;
    
    private int animIDSpeed;
    private int animIDMotionSpeed;

    //Audio

    public AudioClip[] FootStepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        AssignAnimationID();

        //if (SaveMechanics.instance.GetPlayerPostion()!=null)
        //{

        //    transform.position = SaveMechanics.instance.GetPlayerPostion();

        //}
    }

    private void Update()
    {


        SetMoveAnimation(agent.velocity.magnitude,2);

        if (Vector3.Distance(pointToMove, this.transform.position) < 1f)
        {
            if (tempMove != null)
            {
                Destroy(tempMove);
            }

        }

    }


    public void Movement(Vector3 mousePosition,bool isWalking)
    {
        agent.speed = isWalking ? walkSpeed : RunSpeed;



        Ray ray = camera.ScreenPointToRay(mousePosition);

        if(Physics.Raycast(ray,out rayCastHit, Mathf.Infinity))
        {
            if (rayCastHit.collider.CompareTag(groundTag)){


                if (tempMove != null)
                {
                    Destroy(tempMove);
                }

                tempMove= Instantiate(movePoint,rayCastHit.point+ new Vector3(0,0.2f,0f),Quaternion.Euler(90,0,0));

                pointToMove = rayCastHit.point;
                agent.SetDestination(rayCastHit.point);

                StartCoroutine(  SavePlayerLocation());

            }
        }





    }


    private void AssignAnimationID()
    {
        animIDSpeed = Animator.StringToHash("Speed");
        animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    void SetMoveAnimation(float animVlaue,int animMotionVlaue)
    {
        animator.SetFloat(animIDSpeed, animVlaue);
        animator.SetFloat(animIDMotionSpeed, animMotionVlaue);
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootStepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootStepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootStepAudioClips[index], transform.TransformPoint(controller.center), FootstepAudioVolume);
            }
        }
    }

    public void LookTowards(GameObject NPC)
    {
        Vector3 direction = (NPC.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = lookRotation;
    }



    IEnumerator SavePlayerLocation()
    {
        while (agent.pathPending || agent.remainingDistance > 0.1f)
        {
            yield return null;
           
            
        }

        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);


      //  SaveMechanics.instance.SavePlayerPosition(playerPosition);
        Debug.Log("saving");


    }








}
