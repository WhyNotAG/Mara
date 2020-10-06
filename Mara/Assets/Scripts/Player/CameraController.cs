using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraController : MonoBehaviour {
     
    public int dumping = 15; //слгаживание при перемещении
    public Vector2 offset = new Vector2(3f, 1f); //смещение камеры относительно персонаж
    private Transform player;
    // Start is called before the first frame update 

    void Start() {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(PlayerController.facingRight);
    }

    // Update is called once per frame
    void Update() {
        if (player) {

            Vector3 target;
            if (!PlayerController.facingRight) {
                target = new Vector3(player.position.x - offset.x * 3, player.position.y + offset.y, transform.position.z);
            }
            else {
                target = new Vector3(player.position.x + offset.x * 3, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }

    }

    public void FindPlayer(bool isRight) {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    
        if (!PlayerController.facingRight) {
            transform.position = new Vector3(player.position.x - offset.x * 3, player.position.y + offset.y, transform.position.z);
        }
        else {
            transform.position = new Vector3(player.position.x + offset.x * 3, player.position.y + offset.y, transform.position.z);
        }
    }
}
