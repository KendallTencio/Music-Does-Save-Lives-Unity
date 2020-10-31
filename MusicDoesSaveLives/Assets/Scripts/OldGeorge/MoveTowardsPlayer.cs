using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    //Variables
    public Transform player;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.Find("playerShip").transform;
    }

    // Update is called once per frame
    void Update(){
        if (!PauseMenuBehaviour.isPaused){
            if (player != null)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.Normalize();
                this.transform.position = this.transform.position + direction * speed;
            }
            else
            {
                Vector3 direction = new Vector3(0, 0, 0) - this.transform.position;
                this.transform.position = this.transform.position + direction * speed;
            }
        }
        
        
    }
}
