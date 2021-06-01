using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damegePlayer : MonoBehaviour
{
    public GameObject player;
    public int damageAmount = 200;
    PlayerStats ps;
    public GameObject me;
    Tower tower;
    public GameObject Scrap;
    public GameObject Magazine;
    public GameObject BulletSupply;
    public GameObject Explosion;
    private GameObject toDrop;
    private Vector3 origin;
    public float damageDist =.25f;
    private float randNum;
    // Start is called before the first frame update
    void Start(){
        ps = player.GetComponent<PlayerStats>();
        tower = GameObject.Find("Tower").GetComponent<Tower>();
        origin = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
      applyDamage();
    }


    void dropScrap (){
        Vector3 os = new Vector3(0,0,.7f);
        Vector2 spawnScarpPos = me.transform.position;
        Vector3 spawnExpPos = me.transform.position;
        randNum = Random.Range(0.0f, 100.0f);
        Instantiate(Explosion, spawnExpPos+os, Quaternion.identity);
        if (randNum < 30.0){
          Instantiate(Scrap, spawnScarpPos+Random.insideUnitCircle, Quaternion.identity);
        }
        else if (randNum < 75.0) {
          Instantiate(BulletSupply, spawnScarpPos+Random.insideUnitCircle*2.0f, Quaternion.identity);
        }
        else if (randNum < 80.0) {
          Instantiate(Magazine, spawnScarpPos+Random.insideUnitCircle*3.0f, Quaternion.identity);
        }

    }

    void applyDamage(){
      if(Vector3.Distance(player.transform.position, this.transform.position)<damageDist){
        ps.damage(damageAmount);
        dropScrap();
        Destroy(me);
      }
      if(Vector3.Distance(new Vector3 (1,6,1),this.transform.position)<2){
        tower.TakeDamage(5);
        dropScrap();
        Destroy(me);
      }
      GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
      for(int i = 0; i < bullets.Length; i++){
        if(Vector3.Distance(bullets[i].transform.position, this.transform.position)<damageDist*4){
          dropScrap();
          Destroy(me);
        }
        if(Vector3.Distance(bullets[i].transform.position, origin)> 1000){
           Destroy(bullets[i]);
        }
      }
    }
}
