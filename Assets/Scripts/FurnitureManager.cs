using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    [SerializeField] private Animator bookcaseAnimator;

    public List<FurnitureScript> furnitureList = new List<FurnitureScript>();

    private bool isFinished;

    public static FurnitureManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(this);
        }
    }
    public void RemoveAndCheck(FurnitureScript curFurniture)
    {
        furnitureList.Remove(curFurniture);

        if(furnitureList.Count <= 0)
        {
            bookcaseAnimator.SetTrigger("Open");
        }
    }
}

