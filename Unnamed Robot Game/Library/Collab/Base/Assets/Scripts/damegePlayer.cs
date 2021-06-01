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
    public GameObject Explosion;
    public float damageDist =.25f;
    // Start is called before the first frame update
    void Start()
    {
        ps = player.GetComponent<PlayerStats>();
        tower = GameObject.Find("Tower").GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
      applyDamage();
    }

    void applyDamage(){
      if(Vector3.Distance(player.transform.position, this.transform.position)<damageDist){
        Vector2 spawnScarpPos = me.transform.position;
        Vector3 spawnExpPos = me.transform.position;
        ps.damage(damageAmount);
        Destroy(me);
        Vector3 os = new Vector3(0,0,.5f);
        Instantiate(Explosion, spawnExpPos+os, Quaternion.identity);
        Instantiate(Scrap, spawnScarpPos+Random.insideUnitCircle, Quaternion.identity);

      }
      if(Vector3.Distance(new Vector3 (1,3,1),this.transform.position)<2){
        tower.TakeDamage(5);
        Destroy(me);
      }
      GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
      for(int i = 0; i < bullets.Length; i++){
        if(Vector3.Distance(bullets[i].transform.position, this.transform.position)<damageDist*4){
          Vector2 spawnScarpPos = me.transform.position;
          Vector3 spawnExpPos = me.transform.position;
          Destroy(me);
          Vector3 os = new Vector3(0,0,-.5f);
          Instantiate(Explosion, spawnExpPos+os, Quaternion.identity);
          Instantiate(Scrap, spawnScarpPos+Random.insideUnitCircle, Quaternion.identity);
          Destroy(bullets[i]);
        }
      }
    }
}
