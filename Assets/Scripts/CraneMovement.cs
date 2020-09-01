using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    [SerializeField] private float _craneSpeed = 0.1f;
    private BeamMover _beamMover;
    
    void Start()
    {
        _beamMover = GetComponent<BeamMover>();
    }

    void Update()
    {
        MoveCrane();
    }

    private void MoveCrane()
    {
        Vector3 direction = GetDirection() * _craneSpeed;
        transform.position += direction;
        _beamMover.MoveBeams(direction);
    }
    
    private Vector3 GetDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.down;
        }

        return direction;
    }
}
