using UnityEngine;

public class FistPersonCamera : MonoBehaviour
{
    [SerializeField]
    Transform characterBody;

    [SerializeField]
    Transform characterHead;

    float RotationX = 0f;
    float RotationY = 0f;

    float angleYmin = -90;
    float angleYmax = 90;

    float sensitivityX = 4f;
    float sensitivityY = 4f;

    float smoothRotx = 0f;
    float smoothRoty = 0f;

    float smoothCoefx = 0.009f;
    float smoothCoefy = 0.009f;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        transform.position = characterHead.position;
    }
    void Update()
    {
        MouseMovement();
    }

    void MouseMovement()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        RotationX += smoothRotx;
        RotationY += smoothRoty;

        RotationY = Mathf.Clamp(RotationY, angleYmin, angleYmax);
        
        characterBody.localEulerAngles = new Vector3(0, RotationX, 0);
        transform.localEulerAngles = new Vector3(-RotationY, RotationX, 0);
    }
}
