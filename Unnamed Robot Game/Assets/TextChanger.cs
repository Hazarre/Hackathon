using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{

    public GameObject player;
    public GameObject tower;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        tower = GameObject.Find("Tower");
    }

    // Update is called once per frame
    void Update()
    {
        Repairtext();
    }

    public void Repairtext(){
        if(Vector3.Distance(player.transform.position,tower.transform.position) < 3){
            this.text.text = "Press 'Space' to repair";
        }
        else{
            this.text.text = " ";
        }
    }
}
