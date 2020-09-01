using UnityEngine;

public class BeamMover : MonoBehaviour
{
    [SerializeField] private GameObject WidthBeam;
    [SerializeField] private GameObject DepthBeam;

    public void MoveBeams(Vector3 direction)
    {
        WidthBeam.transform.position += new Vector3(direction.x, direction.y, WidthBeam.transform.position.z);
        DepthBeam.transform.position += new Vector3(DepthBeam.transform.position.x, direction.y, direction.z);
    }
}
