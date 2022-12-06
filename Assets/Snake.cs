using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    private List<Transform> snakeSegments;
    public Transform snakeSegmentPrefab;

    private void Start(){
        snakeSegments = new List<Transform>();
        snakeSegments.Add(this.transform);
    }

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
        for(int i = snakeSegments.Count - 1; i > 0; i--){
            snakeSegments[i].position = snakeSegments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow(){
        Transform segment = Instantiate(this.snakeSegmentPrefab);
        segment.position = snakeSegments[snakeSegments.Count - 1].position;
        snakeSegments.Add(segment);
    }
    
    private void OnTriggerEnter2D(Collider2D snake){
        if(snake.tag == "Food"){
            Grow();
        }
        
    }
}
