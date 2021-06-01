using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletGeneration : MonoBehaviour
{
    public List<GameObject> outlets;
    public GameObject Player;
    private Transform playerPos;
    public Cord cord;
    public GameObject Outlet;
    public float outs;
    // Start is called before the first frame update
    void Start()
    {
        outs = 0;
        outlets = new List<GameObject>();
        playerPos = Player.GetComponent<Transform>();
        GameObject newOutlet = Instantiate(Outlet, new Vector3(.8f, 0, 0), Quaternion.identity);
        outlets.Add(newOutlet);
        newOutlet = Instantiate(Outlet, new Vector3(.8f, 10,0), Quaternion.identity);
        outlets.Add(newOutlet);
        newOutlet = Instantiate(Outlet, new Vector3(8, 5,0), Quaternion.identity);
        outlets.Add(newOutlet);
        newOutlet = Instantiate(Outlet, new Vector3(-8, 5,0), Quaternion.identity);
        outlets.Add(newOutlet);
    }

    // Update is called once per frame
    void Update()
    {
      addOutlet();
      playerPos = Player.GetComponent<Transform>();
    }

    public void addOutlet(){
      float dist;
      outs = 0;
      foreach(GameObject outlet in outlets){
        dist = Vector3.Distance(outlet.transform.position,playerPos.position);
        if(dist < 15){
           outs ++;
        } 
      }
      if(outs < 1){
      Vector3 offset = Random.insideUnitCircle * (10);
      GameObject newOutlet = Instantiate(Outlet, playerPos.position+offset, Quaternion.identity);
      outlets.Add(newOutlet);
      }
    }


}
