using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FurnitureScript : MonoBehaviour
{
    [SerializeField] private GameObject furnitureObject;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private DragableObject dragObject;

    [SerializeField] private Material mat;
    [SerializeField] private Material mat2;
    [SerializeField] private MeshRenderer meshRenderer;

    public Vector3 goalPosition;
    public float minDist;

    private bool onGoal;

    private void Awake()
    {
        mat2 = meshRenderer.material;
    }

    private void Update()
    {
        if (Vector3.Distance(furnitureObject.transform.position, goalPosition) <= minDist)
        {
            if (!onGoal)
            {
                rb.MovePosition(goalPosition);
                FurnitureManager.Instance.RemoveAndCheck(this);

                ReasignMats(true);
                onGoal = true;
            }
        } else if (onGoal) 
        {
            FurnitureManager.Instance.furnitureList.Add(this);
            ReasignMats(false);
            onGoal = false;
        }
    }

    private void ReasignMats(bool withExtraMat)
    {
        if(withExtraMat)
        {
            meshRenderer.material = mat;
        }
        else
        {
             meshRenderer.material = mat2;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(goalPosition, Vector3.one);
    }
}
