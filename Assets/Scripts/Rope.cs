using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private Vector3[] _path;

    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    public void SetPath(Vector3[] path)
    {
        _path = path;
    }

    private IEnumerator Move()
    {
        for (var i = 0; i < _path.Length; i++)
        {
           yield return StartCoroutine(MoveToTarget(_path[i]));
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while(transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
            yield return null;
        }
    }
}
