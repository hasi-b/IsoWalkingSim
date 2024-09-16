using System.Collections;
using UnityEngine;

public class GuardTreeController : MonoBehaviour
{
    public Animator animator;
    string floatParameterName = "Blend";
    float floatIncrement = 0.1f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AnimationController.instance.PlayAnimation(animator, "Blend", 0.5f);
            if (Vector3.Distance(this.gameObject.transform.position, other.gameObject.transform.position) < 6f)
            {
                AnimationController.instance.PlayAnimation(animator, "Blend", 1f);
            }
        }

       
   

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            AnimationController.instance.PlayAnimation(animator, "Blend", 0f);

        }
    }







}
