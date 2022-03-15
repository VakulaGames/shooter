using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _decal;
    [SerializeField] private float _speed;

    private Vector3 _lastPos;

    private void Start()
    {
        _lastPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Linecast(_lastPos, transform.position, out hit))
        {
            GameObject decal = Instantiate<GameObject>(_decal);
            decal.transform.position = hit.point + hit.normal * 0.001f;
            decal.transform.rotation = Quaternion.LookRotation(-hit.normal);
            Destroy(decal, 10);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2);
        }
        _lastPos = transform.position;
    }
}
