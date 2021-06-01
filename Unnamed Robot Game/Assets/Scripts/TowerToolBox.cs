using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerToolBox : MonoBehaviour
{

    public GameObject tower;
    public GameObject player;
    private PlayerStats ps;
    private Tower ts;
    public float repairDist = 1f;
    public int repairVal = 500;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
      ps = player.GetComponent<PlayerStats>();
      ts = tower.GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
      applyRepair();
    }

    public void applyRepair(){
        if(Vector3.Distance(tower.transform.position, player.transform.position)<repairDist && ps.numScraps>0){
          if(Input.GetKeyDown(KeyCode.E)){
          ts.Build(1);
          ps.numScraps--;
        }
      }
    }

    public void applyBuild(){
      if(Vector3.Distance(tower.transform.position, player.transform.position)<repairDist && ps.numScraps>0){
        if(Input.GetKeyDown(KeyCode.Space)){
        ts.Repair(1);
        ps.numScraps--;
      }
    }

    }
}
