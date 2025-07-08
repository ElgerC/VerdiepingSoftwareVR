using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerMovementSlower : MonoBehaviour
{
    [SerializeField] private float normSpeed;

    [SerializeField] private DynamicMoveProvider dynamicMoveProvider;

    public void SlowPlayer(float newMoveSpeed)
    {
        dynamicMoveProvider.moveSpeed = newMoveSpeed;
    }

    public void EndSlow()
    {
        dynamicMoveProvider.moveSpeed = normSpeed;
    }
}
