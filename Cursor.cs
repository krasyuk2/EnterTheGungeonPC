using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
   private Camera _camera;
   private GameObject _player;
   public Vector3 posCursor;
   
   private void Awake()
   { 
      if(Camera.main != null) _camera = Camera.main;
      _player = GameObject.FindWithTag("Player");
   }

   private void Update()
   {
      MoveCursor();
   }

   void MoveCursor()
   {
      Vector2 posMouse = _camera.ScreenToWorldPoint(Input.mousePosition);
      Vector3 min = _camera.ViewportToWorldPoint(new Vector3(0, 0));   
      Vector3 max = _camera.ViewportToWorldPoint(new Vector3(1f, 1f));
      posCursor = new Vector3(Math.Clamp(posMouse.x, min.x, max.x), Math.Clamp(posMouse.y, min.y, max.y));
      transform.position = posCursor;
   }

   
   
 
  
}
