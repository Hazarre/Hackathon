using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 Tower;
    GameObject arrow;
    Vector3 Mypos;
    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("Tower Arrow");
        Tower = new Vector3(0,3,0);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;
        DisplayArrow();
    }

    public void DisplayArrow(){
        float dist;
        Vector3 tooTower;
        tooTower = Tower - playerPos;
        float angle = Mathf.Atan2(tooTower.y, tooTower.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        dist = Vector3.Distance(Tower,playerPos);
        if (dist> 7){
             arrow.transform.position = playerPos - new Vector3(0,.5f,+.01f);
        }
        else{
             arrow.transform.position = Tower + new Vector3(0,2 ,-.01f);
             q = Quaternion.AngleAxis(-90, Vector3.forward);
        }
        arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, q , Time.deltaTime* 1000);
    }
}
