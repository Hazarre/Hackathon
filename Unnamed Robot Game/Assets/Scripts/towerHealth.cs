using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerHealth : MonoBehaviour
{

    public int hitpoints = 100;
    public int maxHealth = 100;
    public bool isBroken = false;

    public int maxSegments = 20;
    public int numSegments = 0;



    public void healTower(int healamount){
      if(hitpoints+healamount < maxHealth){
        hitpoints += healamount;
      }else{
        hitpoints = maxHealth;
      }
    }

    public void buildTower(){
      numSegments++;
    }

    public void damageTower(int damage){
      hitpoints-=damage;
      if(hitpoints < 0){
        isBroken = true;
      }
    }

    public int getTowerHealth(){
      return hitpoints;
    }

    public void addSegment(){

    }
}
