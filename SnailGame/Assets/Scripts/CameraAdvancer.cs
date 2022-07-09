using UnityEngine;
using System.Collections.Generic;

public class CameraAdvancer : MonoBehaviour 
{
    public Transform newCameraLocation;
    private bool mActivated = false;

    public List<Lane> LanesToEnable = new List<Lane>();
    public List<Lane> LanesToDisable = new List<Lane>();
    public TankTurret TankToEnable;
    public TankTurret TankToDisable;

    void OnTriggerEnter(Collider other)
    {
        Snail snail = other.gameObject.GetComponent<Snail>();

        if (snail != null && !mActivated)
        {
            mActivated = true;
            CameraController.SetTarget(newCameraLocation.position);

            foreach (Lane lane in LanesToEnable)
            {
                lane.enabled = true;
            }

            foreach (Lane lane in LanesToDisable)
            {
                lane.enabled = false;
            }

            if (TankToDisable != null)
            {
                TankToDisable.enabled = false;
            }

            if (TankToEnable != null)
            {
                TankToEnable.enabled = true;
            }
        }
    }
}
