using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public enum grabState
{
    waiting,
    released,
    grabbed,
    held
}
public class FlashlightScript : MonoBehaviour
{
    public grabState state = grabState.waiting;
    public bool inHolder;

    [SerializeField] private XRGrabInteractable interactable;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider col;
    [SerializeField] private Animator animator;

    [SerializeField] private Vector3 grabbedRot;
    [SerializeField] private Vector3 grabbedpos;

    [SerializeField] private Vector3 heldRot;
    [SerializeField] private Vector3 heldpos;
    [SerializeField] private Vector3 heldColSize;
    [SerializeField] private Transform heldPoint;

    [SerializeField] private Vector3 norColSize;

    public void Grab()
    {
        if(state == grabState.waiting)
        {
            animator.SetTrigger("Open");
        }
        state = grabState.grabbed;
        transform.parent = interactable.interactorsSelecting[0].transform;
        rb.isKinematic = true;
    }

    public void Release()
    {
        if (inHolder)
        {
            state = grabState.held;
            rb.isKinematic = true;
            transform.parent = heldPoint;
            col.size = heldColSize;
        }
        else
        {
            state = grabState.released;
            transform.parent = null;
            rb.isKinematic = false;
            col.size = norColSize;
        }
    }

    private void Update()
    {
        switch (state)
        {
            case grabState.released:
                break;
            case grabState.grabbed:
                transform.localRotation = Quaternion.Euler(grabbedRot);
                transform.localPosition = grabbedpos;
                break;
            case grabState.held:
                transform.localRotation = Quaternion.Euler(heldRot);
                transform.localPosition = heldpos;
                break;
            default: break;
        }
    }
}
