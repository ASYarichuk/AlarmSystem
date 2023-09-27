using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private bool isEnabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<StarterAssets.ThirdPersonController>(out StarterAssets.ThirdPersonController player))
        {
            if (isEnabled == false)
            {
                isEnabled = true;
                _alarmSystem.Play();
            }
            else
            {
                isEnabled = false;
                _alarmSystem.Stop();
            }
        }
    }
}
