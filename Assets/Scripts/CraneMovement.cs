using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private float _craneSpeed = 0.1f;
    [SerializeField] private GameObject _magnet;
    private BeamMover _beamMover;
    private InputManager _inputManager;
    
    void Start()
    {
        _beamMover = GetComponent<BeamMover>();
        _inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        MoveCrane();
    }

    private void MoveCrane()
    {
        Vector3 direction = GetDirection() * _craneSpeed;
        _magnet.transform.position += direction;
        _beamMover.MoveBeams(direction);
    }
    
    private Vector3 GetDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(_inputManager.ForwardButton))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(_inputManager.RightButton))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(_inputManager.BackwardButton))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(_inputManager.LeftButton))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(_inputManager.UpButton))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(_inputManager.DownButton))
        {
            direction += Vector3.down;
        }

        return direction;
    }
}
