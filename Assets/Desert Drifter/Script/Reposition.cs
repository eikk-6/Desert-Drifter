using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>(); 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) 
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position; 
        Vector3 myPos = transform.position; 
        float diffX = Mathf.Abs(playerPos.x - myPos.x); 
        float diffY = Mathf.Abs(playerPos.y - myPos.y); 

        float dirX = playerPos.x - myPos.x; 
        float dirY = playerPos.y - myPos.y; 

        float diffx = Mathf.Abs(dirX); 
        float diffy = Mathf.Abs(dirY); 

        dirX = dirX > 0 ? 1 : -1; 
        dirY = dirY > 0 ? 1 : -1; 

        switch (transform.tag)
        {
            case "Ground":
                if (Mathf.Abs(diffX - diffY) <= 0.1f)
                { 
                    transform.Translate(Vector3.up * dirY * 40); 
                    transform.Translate(Vector3.right * dirX * 40); 
                }
                else if (diffX > diffY) 
                {
                    transform.Translate(Vector3.right * dirX * 40); 
                }
                else if (diffX < diffY) 
                {
                    transform.Translate(Vector3.up * dirY * 40); 
                }
                break;
            case "Enemy":

                break;
        }
    }
}