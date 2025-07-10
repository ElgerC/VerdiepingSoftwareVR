using UnityEngine;

public class FlashlightHolder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FlashlightScript script = other.GetComponent<FlashlightScript>();

        if(script != null)
        {
            script.inHolder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FlashlightScript script = other.GetComponent<FlashlightScript>();

        if (script != null)
        {
            script.inHolder = false;
        }
    }
}
