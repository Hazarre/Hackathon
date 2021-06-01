using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxBuild = 10;
    public int health;
    public int build = 0;
    // Start is called before the first frame update
    public HealthBar healthBar;
    public HealthBar buildBar;
    public Sprite tower1;
    public Sprite tower2;
    public Sprite tower3;
    public Sprite mySprite;
    void Start()
    {
        health = maxHealth;
        build = 0;
        healthBar.SetMaxHealth(maxHealth);
        buildBar.SetMaxHealth(maxBuild);
        buildBar.SetHealth(build);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Build(4);
        //Game Over
        if (build <= -5) {
            GameObject.Find("Sound").GetComponent<Sound>().PlayDeath();
            SceneManager.LoadScene("GameOver");
        }
        // Win
        if (build >= maxBuild) {
            GameObject.Find("Sound").GetComponent<Sound>().PlayWin();
            health = 9999999;
            GameObject.Find("Player").GetComponent<PlayerStats>().enegryLevel = 99999;
            SceneManager.LoadScene("Win");
        }
        if(build < 5){
            mySprite = tower1;
        }
        else if(build>=5 && build<15){
            mySprite = tower2;
            GameObject.Find("Sound").GetComponent<Sound>().PlayCheckpoint();
        }
        else if(build > 15) {
            mySprite = tower3;
        }
        this.GetComponent<SpriteRenderer>().sprite = mySprite;
    }

    public void Repair(int scrap){
        health += scrap;
        // health = Mathf.Min(maxHealth, health);
        healthBar.SetHealth(health);
    }

    public void Build(int scrap){
        build += scrap;
        // build = Mathf.Min(maxBuild, build);
        buildBar.SetHealth(build);
    }

    public void TakeDamage(int damage){
        build -= damage;
        // health = Mathf.Max(0, health);
        healthBar.SetHealth(health);
    }
}
