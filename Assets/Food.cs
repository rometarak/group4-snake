using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D grid;  //Määrame ära gridi kuhu toit spawnib

    //Start funktsioon käivitatakse mängu käima pannes 1 korra
    private void Start(){
        RandomizePosition();
    }
    //Funktsioon, mis spawnib toidu randomilt gridi sisse
    private void RandomizePosition(){

        Bounds bounds = this.grid.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    //Funktsioon määrab mis juhtub, kui player(uss) toidule pihta läheb
    private void OnTriggerEnter2D(Collider2D snake){
        if(snake.tag == "Player"){
            RandomizePosition();
        }
        
    }
}
