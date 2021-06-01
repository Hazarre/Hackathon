using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public Cord cord;
    public GameObject player;
    public int MaxEnegry = 180;
    public int enegryLevel = 180;
    public int rechargeRate = 2;
    public GameObject[] scrapPiles;
    public float pickupDist = 0.2f;
    public int numScraps = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      updateEnegry();
      pickUpScrap();


      // Game Over 
      if(enegryLevel <= 0) {
        SceneManager.LoadScene("GameOver");
      }
      
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
