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
    [SerializeField] private MeshRenderer meshRenderer;

    public Vector3 goalPosition;
    public float minDist;

    private bool onGoal;

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
        } else
        {
            FurnitureManager.Instance.furnitureList.Add(this);
            ReasignMats(false);
            onGoal = false;
        }
    }

    private void ReasignMats(bool withExtraMat)
    {
        List<Material> mats = new List<Material>();

        mats.Add(meshRenderer.materials[0]);
        if (withExtraMat)
        {
            mats.Add(mat);
        }
        
        meshRenderer.materials = mats.ToArray();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(goalPosition, Vector3.one);
    }
}
