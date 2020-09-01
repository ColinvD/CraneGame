using System.Collections;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    private bool _isMagnetic = true;
    private float _coolDownTime = 0.5f;
    private GameObject _pickedUpBlock = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _pickedUpBlock != null)
        {
            DropBlock();
        }
    }

    private void DropBlock()
    {
        _isMagnetic = false;
        _pickedUpBlock.GetComponent<Rigidbody>().isKinematic = false;
        _pickedUpBlock.transform.parent = null;
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
