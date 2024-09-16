using UnityEngine;
using DG.Tweening;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Transform[] targetPositions;
    [SerializeField] private float flySpeed = 1f;
    [SerializeField] private float rotationSpeed = 0f;

    private int currentPositionIndex = 0;


    private void Start()
    {
        currentPositionIndex = 0;
        transform.position = targetPositions[currentPositionIndex].position;

        Vector3 nextPosition = targetPositions[(currentPositionIndex + 1) % targetPositions.Length].position;
        Vector3 nextDirection = nextPosition - transform.position;
        transform.DOLookAt(transform.position + nextDirection, rotationSpeed, AxisConstraint.Y).OnComplete(() =>
        {
            MoveToNextPosition();
        });
    }

    private void MoveToNextPosition()
    {
        currentPositionIndex++;
        if (currentPositionIndex >= targetPositions.Length)
        {
            currentPositionIndex = 0;
        }

        Vector3 nextPosition = targetPositions[currentPositionIndex].position;
        Vector3 nextDirection = nextPosition - transform.position;
        transform.DOLookAt(transform.position + nextDirection, rotationSpeed, AxisConstraint.Y);
        transform.DOMove(nextPosition, flySpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveToNextPosition();
        });
    }


}
