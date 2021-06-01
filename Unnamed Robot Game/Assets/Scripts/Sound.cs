using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
   public AudioSource bullet;
   public AudioSource checkpoint_towerbuild;
   public AudioSource death; 
   public AudioSource endcredits; 
   public AudioSource item_pickup;
   public AudioSource main_theme;
   public AudioSource plugin1; 
   public AudioSource unplug1;
   public AudioSource mainmenu;
   public AudioSource winning;
   public AudioSource robot_death;

   public void PlayBullet(){
       bullet.Play ();
   }

    public void PlayCheckpoint(){
       checkpoint_towerbuild.Play ();
   }

    public void PlayDeath(){
       death.Play ();
   }

    public void EndCredits(){
       endcredits.Play ();
   }

    public void PlayItem(){
       item_pickup.Play ();
   }

    public void MainTheme(){
       main_theme.Play ();
   }

    public void PlayPlugin(){
       plugin1.Play ();
   }

    public void PlayUnplug(){
       unplug1.Play ();
   }

    public void PlayMenu(){
       mainmenu.Play ();
   }

    public void PlayWin(){
       winning.Play ();
   }

    public void PlayRobot(){
       robot_death.Play ();
   }

}
