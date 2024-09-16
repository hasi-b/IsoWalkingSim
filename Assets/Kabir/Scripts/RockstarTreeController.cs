using System.Collections;
using UnityEngine;

public class RockstarTreeController : MonoBehaviour
{
    public Animator animator;
    string floatParameterName = "Blend";
    float floatIncrement = 0.1f;

    private void Start()
    {
        //PlayAnimationWithFloat(animator, floatParameterName, 1f);
    }

    public void PlayAnimationWithFloat(Animator animator, string floatParameterName, float floatIncrement)
    {
        animator.SetFloat(floatParameterName, 0);
        StartCoroutine(UpdateFloatValue(animator, floatParameterName, floatIncrement));
    }

    private IEnumerator UpdateFloatValue(Animator animator, string floatParameterName, float floatIncrement)
    {
        float currentValue = 0f;
        while (currentValue <= 1f)
        {
            animator.SetFloat(floatParameterName, currentValue);
            currentValue += floatIncrement;

            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before incrementing again
        }
    }
}
