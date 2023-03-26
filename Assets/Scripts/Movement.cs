using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _reverseMove = -1;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * _reverseMove, 0, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, _speed * Time.deltaTime * _reverseMove, 0);
        }
    }
}
