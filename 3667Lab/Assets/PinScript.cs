using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    [SerializeField] Vector2 curPoint;
    [SerializeField] Vector2 destinationPoint;
    [SerializeField] int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        curPoint = transform.position;
        if (transform.rotation.y == 0){
            destinationPoint = new Vector2(transform.position.x+10, transform.position.y);
        }else{
            destinationPoint = new Vector2(transform.position.x-10, transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,destinationPoint) < 0.02f){
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(curPoint, destinationPoint, speed*Time.deltaTime);
        curPoint = transform.position;
    }
}
