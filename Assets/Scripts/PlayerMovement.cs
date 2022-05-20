using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _player;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    private float _speed = 12f;
    private Vector3 _velocity;

    private Vector3 GetMoveInXAxis()
    {
        return transform.right * Input.GetAxis("Horizontal");
    }

    private Vector3 GetMoveInZAxis()
    {
        return transform.forward * Input.GetAxis("Vertical");
    }

    private void Update()
    {
        _player.Move((GetMoveInXAxis() + GetMoveInZAxis()) * (_speed * Time.deltaTime));
        AddGravity();
        Jump();
    }

    private bool CheckIsGrounded()
    {
        float groundDistance = 0.4f;
        return Physics.CheckSphere(_groundCheck.position, groundDistance, _groundMask);
    }

    private void AddGravity()
    {
        if (CheckIsGrounded())
        {
            if (_velocity.y < 0) 
                _velocity.y = -2;
        }
        _velocity += Physics.gravity * Time.deltaTime;
        _player.Move(_velocity * Time.deltaTime);
    }

    private void Jump()
    {
        float jumpHeight = 2f;
        if (Input.GetKeyDown(KeyCode.Space) && CheckIsGrounded())
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
    }
    
}