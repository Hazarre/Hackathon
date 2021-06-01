using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f; 
    public Rigidbody2D rb; 
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Vector3 pos = GameObject.Find("Player").transform.position;
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,3));
        Vector3 direction = mouseInWorld - pos;
        direction.Normalize();
        rb.velocity = direction * speed;
    }
    void Update(){

    }

    // void OnTriggerEnter2D(Collider2D hitInfo){
    //     Debug.Log(hitInfo.name);
    //     Destroy(gameObject);
    // }

   
}
