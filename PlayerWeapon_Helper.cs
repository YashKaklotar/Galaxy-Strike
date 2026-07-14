using UnityEngine;

public class PlayerWeapon_Helper : MonoBehaviour
{  
    bool isFiring = true;

    [SerializeField] GameObject[] Laser;
    [SerializeField] Transform TargetPoint;
    [SerializeField] float TargetDistance = 100f;

    void Update()
    {
        processFiring();
        AimLasers();
    }

    void processFiring()
    {
        foreach(GameObject i in Laser)
        {
            ParticleSystem.EmissionModule emissionModule = i.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }        
    }

    void AimLasers()
    {
        foreach(GameObject i in Laser)
        {
            Vector3 FireDirection = TargetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(FireDirection);
            i.transform.rotation = rotationToTarget;
        }
    }
}
