using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody;
    private float _limitedVerticalRotation;
    
    private float GetMouseDegreesOfHorizontalRotation()
    {
        return Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
    }
    private float GetMouseDegreesOfVerticalRotation()
    {
        return Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LockRotationMoreThan180Degrees(GetMouseDegreesOfVerticalRotation());
        transform.localRotation = Quaternion.Euler(_limitedVerticalRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * GetMouseDegreesOfHorizontalRotation());
    }

    private void LockRotationMoreThan180Degrees(float degreesOfVerticalRotation)
    {
        _limitedVerticalRotation -= degreesOfVerticalRotation;
        _limitedVerticalRotation = Mathf.Clamp(_limitedVerticalRotation, -90f, 90f);
    }
}
