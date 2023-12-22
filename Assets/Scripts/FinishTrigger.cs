using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 _finishPoint;
    [SerializeField] private UnityEvent<Vector3> _onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.BOX_TAG))
        {
            _onTriggerEnter.Invoke(_finishPoint);
        }
    }
}
