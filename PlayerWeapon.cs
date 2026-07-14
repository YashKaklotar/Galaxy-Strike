using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{  
    bool isFiring = false; //we want to fire laser while holding the lmb. If we won't do this then our player will shoot laser only once even if we're holding the LMB.
    [SerializeField] GameObject[] Laser;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform TargetPoint; //A reference gameobj on which our laser will shoot which will be attached(follow) to ore crosshair;
    [SerializeField] float TargetDistance = 100f;
    void Start()
    {
        Cursor.visible = false; //to disable default windows mouse cursor else both will be there in the scene;
    }
    void Update()
    {
        processFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue Value)
    {
        isFiring = Value.isPressed;
    }

    void processFiring()
    {
        foreach(GameObject i in Laser)   //we can also write 'var' instead of GameObject.
        {
            ParticleSystem.EmissionModule emissionModule = i.GetComponent<ParticleSystem>().emission;  //we can just write 'var' instead of ParticleSystem.EmissionModule. C# is smart enough to find the actual component by itself like what we're trying to access.
            emissionModule.enabled = isFiring; //we could have just declared it as true or false as needed but we've already got the isFiring variable which stores the same info so we just gave that value to it.
        }        
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;  //to make our crosshair follow the mouse
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, TargetDistance); //A vector3 with the position of our mouse;
        TargetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition); //This converts screenposition(2D) into worldposition(3D) and moves an object there.
    }

    void AimLasers()
    {
        foreach(GameObject i in Laser)
        {
            Vector3 FireDirection = TargetPoint.position - this.transform.position;  //this gives the direction in which our laser should be fired. TargetPoint(invisible gameobj on crosshair) - i(laser). this will help us to shoot the laser in the direction of mouse pointer. This lines gives us the vector between laser and targetpoint. this refers to current gameobject which means the gameobj on which our script is attached here it is our playership.
            Quaternion rotationToTarget = Quaternion.LookRotation(FireDirection); //built in unity method to rotate our laser direction to the crosshair. Quaternion.LookRotation calculates the rotation we need to give to our laser so that it can shoot on the calculated(Subtracted) vector in the previous step.
            i.transform.rotation = rotationToTarget;  //here we move the lasers on the calculated quaternion.
        }
    }
}

