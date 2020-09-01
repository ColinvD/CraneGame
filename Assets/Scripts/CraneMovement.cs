using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private float _craneSpeed = 0.1f;
    [SerializeField] private Transform _minBoundary;
    [SerializeField] private Transform _maxBoundary;
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
        direction = CheckForOutOfBounce(direction);
        _magnet.transform.position += direction;
        _beamMover.MoveBeams(direction);
    }

    private Vector3 CheckForOutOfBounce(Vector3 direction)
    {
        Vector3 newdir = new Vector3();

        if (_magnet.transform.position.x + direction.x <= _maxBoundary.transform.position.x && _magnet.transform.position.x + direction.x >= _minBoundary.transform.position.x)
        {
            newdir.x = direction.x;
        }
        
        if (_magnet.transform.position.y + direction.y <= _maxBoundary.transform.position.y && _magnet.transform.position.y + direction.y >= _minBoundary.transform.position.y)
        {
            newdir.y = direction.y;
        }
        
        if (_magnet.transform.position.z + direction.z <= _maxBoundary.transform.position.z && _magnet.transform.position.z + direction.z >= _minBoundary.transform.position.z)
        {
            newdir.z = direction.z;
        }

        return newdir;
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
