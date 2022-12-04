using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] bool isMoving = false;
    [SerializeField] Vector2 pointA = new Vector2(0,0);
    [SerializeField] Vector2 pointB = new Vector2(0,0);
    [SerializeField] Vector2 curPoint;
    [SerializeField] Vector2 destinationPoint;
    [SerializeField] int speed = 3;
    [SerializeField] new AudioSource audio;
    [SerializeField] ScoreTracker trackerScript;

    [SerializeField] int worth = -1;

    // Start is called before the first frame update
    void Start()
    {
        curPoint = pointA;
        destinationPoint = pointB;

        if (audio == null){
            audio = GetComponent<AudioSource>();
        }

        trackerScript = GameObject.Find("PlayerCharacter").GetComponent<ScoreTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving){
            if(Vector2.Distance(transform.position,destinationPoint) < 0.02f){
                if(destinationPoint == pointA){
                    destinationPoint = pointB;
                }else{
                    destinationPoint = pointA;
                }
            }
            transform.position = Vector2.MoveTowards(curPoint, destinationPoint, speed*Time.deltaTime);
            curPoint = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Projectile"){
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            trackerScript.addScore(worth);
            Destroy(gameObject);
        }
    }
}
