using UnityEngine;
using UnityEngine.InputSystem;
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xClampRange = 30f;   
    [SerializeField] float yClampRange = 20f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float rotationSpeed = 10f;
    void Update()
    {
        ProcessTranslation(); //actual logic behind movement through WASD
        ProcessRotation();    //Logic behind our ship's rotations while moving
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;
        float ClampedXpos = Mathf.Clamp(rawXpos , -xClampRange , xClampRange); //To prevent our ship to go beyond our screen in x direction
        float ClampedYpos = Mathf.Clamp(rawYpos , -yClampRange , yClampRange); //To prevent our ship to go beyond our screen in y direction
        transform.localPosition = new Vector3(ClampedXpos,ClampedYpos, 0f);
    }

    void ProcessRotation()
    {
        float roll = -controlRollFactor*movement.x;
        float pitch = -controlPitchFactor*movement.y;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll); //-controlRollFactor to make our ship visually look leaning in whatever direction.
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime); //This will make smooth transition while rotating and prevent the instant change in the angle. 
    }
         

    Vector2 movement;
    public void OnMove(InputValue value)   //this will send the value to the inputsystem created in unity. On and the the name of action, here : Move
    {
        movement = value.Get<Vector2>();
    }
}

