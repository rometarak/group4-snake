using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private void Update(){
        
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            _direction = Vector2.down;
        }
    }

    private void FixedUpdate(){
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
}
