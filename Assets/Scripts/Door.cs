using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _cameOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<StarterAssets.ThirdPersonController>(out StarterAssets.ThirdPersonController player))
        {
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<StarterAssets.ThirdPersonController>(out StarterAssets.ThirdPersonController player))
        {
            _cameOut?.Invoke();
        }
    }
}
