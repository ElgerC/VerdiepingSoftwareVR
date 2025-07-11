using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DragableObject : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable interactable;

    [SerializeField] private Rigidbody body;
    [SerializeField] private Transform playerTrans;

    [SerializeField] private Vector3 offset;
    private Vector3 middlePos;

    private Vector3 goalPos;
    //[SerializeField] private float moveSpeed;
    [SerializeField] private float whileDraggingSpeed;
    [SerializeField] private float objectDistance;

    [SerializeField] private PlayerMovementSlower playerMovementSlower;

    public void StartDrag()
    {
        if (interactable.interactorsSelecting.Count > 1)
        {
            Debug.Log("Grabbed");
            playerMovementSlower.SlowPlayer(whileDraggingSpeed);

            GenerateMiddlePoint();

            offset = middlePos - transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (interactable.isSelected && interactable.interactorsSelecting.Count > 1)
        {
            Debug.Log("Test");
            GenerateMiddlePoint();

            goalPos = middlePos - offset;

            if (Vector2.Distance(goalPos , playerTrans.position) > objectDistance)
                body.MovePosition(goalPos);

            

            //body.linearVelocity = (transform.position + goalPos).normalized * moveSpeed;
        }

    }

    private void GenerateMiddlePoint()
    {
        Vector3 leftControl = interactable.interactorsSelecting[0].transform.parent.position;
        Vector3 rightControl = interactable.interactorsSelecting[1].transform.parent.position;

        middlePos = (leftControl + rightControl) / 2;
    }

    public void EndDrag()
    {
        playerMovementSlower.EndSlow();
    }
}