using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Cord cord;
    public GameObject player, BulletSupply, Magazine;
    public int MaxEnegry = 500;
    public int enegryLevel = 500;
    public int rechargeRate = 2;
    public GameObject[] scrapPiles, magPiles, bulPiles;
    public float pickupDist = 1f;
    public int numScraps = 0;
    public Text scrapcount, bulletCount;
    public HealthBar healthBar; 
    public int maxBullet = 15; 
    public int numBullet = 15; 
    // Start is called before the first frame update
    void Start()
    {
      healthBar.SetMaxHealth(MaxEnegry);
      healthBar.SetHealth(enegryLevel);
    }

    // Update is called once per frame
    void Update()
    {
      updateEnegry();
      pickUpScrap();
      healthBar.SetHealth(enegryLevel);
      // Game Over 
      if(enegryLevel <= 0) {
        SceneManager.LoadScene("GameOver");
      }
      scrapcount.text =  "#Scrap: " + numScraps;

      numBullet = Mathf.Min(numBullet, maxBullet);
      bulletCount.text = "#Bullet: " + numBullet;
    }

    public int getEnegryLevel(){
      return enegryLevel;
    }

    public int getMaxEnegry(){
      return MaxEnegry;
    }

    public void setEnegryLevel(int newEL){
      enegryLevel = newEL;
    }

    public void addEnegry(int e){
      enegryLevel+=e;
      if(enegryLevel > MaxEnegry){
        enegryLevel = MaxEnegry;
      }
    }

    public void damage(int dam){
      MaxEnegry-=dam;
      enegryLevel-=dam;
    }

    public void subtractEnegry(int e){
      enegryLevel-=e;
    }

    public void pickUpScrap(){
      scrapPiles = GameObject.FindGameObjectsWithTag("Scrap");
      foreach (GameObject scrap in scrapPiles){
        if(Vector2.Distance(player.transform.position, scrap.transform.position)<pickupDist){
          numScraps++;
          GameObject.Find("Sound").GetComponent<Sound>().PlayItem();
          Destroy(scrap);
        }
      }

      magPiles = GameObject.FindGameObjectsWithTag("Magazine");
      foreach (GameObject scrap in magPiles){
        if(Vector2.Distance(player.transform.position, scrap.transform.position)<pickupDist){
          numBullet = maxBullet;
          Destroy(scrap);
        }
      }

      bulPiles = GameObject.FindGameObjectsWithTag("BulletSupply");
      foreach (GameObject scrap in bulPiles){
        if(Vector2.Distance(player.transform.position, scrap.transform.position)<pickupDist){
          numBullet++;
          Destroy(scrap);
        }
      }


    }

    private void updateEnegry(){
      if(!cord.plugedIn){
        enegryLevel--;
      }else{
        if(enegryLevel < MaxEnegry){
          enegryLevel += rechargeRate;
        }
      }
    }
}
