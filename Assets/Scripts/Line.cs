using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Line : MonoBehaviour
{
   [SerializeField] private LineRenderer _renderer;
   [SerializeField] private UnityEvent<Vector3[]> _onStopDraw;
   [SerializeField] private double _step;
   
   private Camera _camera;
   private float _depth = 12.88f;

   private void Awake()
   {
      _camera = Camera.main;
      GameManager.Instance.SetLineDrawer(this);
   }

   private void Update()
   {
      if (Input.GetMouseButton(0))
      {
         SetNewPoint();
      }

      if (Input.GetMouseButtonUp(0))
      {
         _onStopDraw.Invoke(GetPath());
         Destroy(this);
      }
   }

   private Vector3[] GetPath()
   {
      var positions = new Vector3[_renderer.positionCount];
      _renderer.GetPositions(positions);
      return positions;
   }

   private void SetNewPoint()
   {
      var previousPosition = _renderer.GetPosition(_renderer.positionCount - 1);
      
      var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _depth);
      var nextPosition = _camera.ScreenToWorldPoint(mousePosition);
      
      if (Vector3.Distance(nextPosition, previousPosition) > _step)
      {
         _renderer.positionCount++;
         var index = _renderer.positionCount - 1;
         
         _renderer.SetPosition(index, nextPosition);  
      }
   }
}
