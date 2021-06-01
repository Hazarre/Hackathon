using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Tower : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxBuild = 100;
    public int health;
    public int complete = 0;
    // Start is called before the first frame update
    public HealthBar healthBar;
    public HealthBar buildBar;
    void Start()
    {
        health = maxHealth;
        complete = 0;
        healthBar.SetMaxHealth(maxHealth);
        buildBar.SetMaxHealth(maxBuild);
        buildBar.SetHealth(complete);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) Repair(5);
        //Game Over 
        if (health <= 0) SceneManager.LoadScene("GameOver");
    }

    public void Repair(int scrap){
        health += scrap;
        healthBar.SetHealth(health);
    }

    public void Build(int scrap){
        complete += scrap;
        buildBar.SetHealth(complete);
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthBar.SetHealth(health);
    }
}
