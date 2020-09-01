using System.Collections;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    [SerializeField] private Transform _blockParent;
    private bool _isMagnetic = true;
    private float _coolDownTime = 0.5f;
    private GameObject _pickedUpBlock = null;
    private InputManager _inputManager;

    private void Start()
    {
        _inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(_inputManager.DropButton) && _pickedUpBlock != null)
        {
            DropBlock();
        }
    }

    private void DropBlock()
    {
        _isMagnetic = false;
        _pickedUpBlock.GetComponent<Rigidbody>().isKinematic = false;
        _pickedUpBlock.transform.parent = _blockParent;
        _pickedUpBlock = null;
        StartCoroutine(Cooldown());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Block" && _isMagnetic && _pickedUpBlock == null)
        {
            _pickedUpBlock = other.gameObject;
            _pickedUpBlock.GetComponent<Rigidbody>().isKinematic = true;
            _pickedUpBlock.transform.parent = gameObject.transform.parent;
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_coolDownTime);
        _isMagnetic = true;
    }
}
