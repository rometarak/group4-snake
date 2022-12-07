using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    private Vector2 direction = Vector2.zero;                               //Määrame ära alguses liikumise suuna
    private List<Transform> snakeSegments = new List<Transform>();          //List positsioonidest, kus ussi sabad asuvad
    public Transform snakeSegmentPrefab;                                    //Ussi saba üksik prefab
    private int beginSize = 1;                                              //Määrame ussi saba pikkuse alguses

    //Start funktsioon käivitatakse mängu käima pannes 1 korra
    private void Start(){
        ResetState();
    }
    //Update funktsioon jookseb, kui mäng korra iga frame jooksul
    private void Update(){
        //Määrame ära ussi liikumise jaoks nupud
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
    //Ussi kasvamise funktsioon
    private void Grow(){
        Transform segment = Instantiate(this.snakeSegmentPrefab);
        segment.position = snakeSegments[snakeSegments.Count - 1].position;
        snakeSegments.Add(segment);
    }
    //Funktsioon määrab ära mis juhtub, kui mäng resetib(uss sureb)
    private void ResetState(){
        ScoreManager.instance.ResetPoint();
        direction = Vector2.zero;
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
    //Funktsioon määrab ära mis juhtub, kui tekib collision toidu või seinaga
    private void OnTriggerEnter2D(Collider2D snake){
        if(snake.tag == "Food"){
            Grow();
            ScoreManager.instance.AddPoint();
        }else if(snake.tag == "Obstacle"){
            SceneManager.LoadScene("DeathMenu");
            ResetState();
            //siia peaks tulema ka game over või siis retry menüü
        }
        
    }
}