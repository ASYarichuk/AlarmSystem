using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _cameOut;

    private bool isEnabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<StarterAssets.ThirdPersonController>(out StarterAssets.ThirdPersonController player))
        {
            if (isEnabled == false)
            {
                isEnabled = true;
                _entered?.Invoke();
            }
            else
            {
                isEnabled = false;
                _cameOut?.Invoke();
            }
        }
    }
}
