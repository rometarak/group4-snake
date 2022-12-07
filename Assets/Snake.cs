using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;
    private List<Transform> snakeSegments = new List<Transform>();
    public Transform snakeSegmentPrefab;
    private int beginSize = 2;


    private void Start(){
        ResetState();
    }

    private void Update(){
        
        if (Input.GetKey(KeyCode.UpArrow)){
            if (direction != Vector2.down){
                direction = Vector2.up;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            if (direction != Vector2.right){
                direction = Vector2.left;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            if (direction != Vector2.left){
                direction = Vector2.right;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)){
            if (direction != Vector2.up){
                direction = Vector2.down;
            }
        }
    }

    private void FixedUpdate(){
        for(int i = snakeSegments.Count - 1; i > 0; i--){
            snakeSegments[i].position = snakeSegments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }

    private void Grow(){
        Transform segment = Instantiate(this.snakeSegmentPrefab);
        segment.position = snakeSegments[snakeSegments.Count - 1].position;
        snakeSegments.Add(segment);
    }

    private void ResetState(){
        for(int i = 1;i < snakeSegments.Count;i++){
            Destroy(snakeSegments[i].gameObject);
        }
        snakeSegments.Clear();
        snakeSegments.Add(this.transform);

        for(int i = 1;i < this.beginSize; i++){
            snakeSegments.Add(Instantiate(this.snakeSegmentPrefab));
        }

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D snake){
        if(snake.tag == "Food"){
            Grow();
        }else if(snake.tag == "Obstacle"){
            ResetState();
            //siia peaks tulema ka game over või siis retry menüü
        }
        
    }
}
