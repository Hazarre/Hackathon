using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTint : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer sp;
    private PlayerStats ps;
    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        ps = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
      float el = ps.getEnegryLevel();
      float maxe = ps.getMaxEnegry();
      float percentFull = el/maxe;
      if(el < 0) percentFull = 0;
      float cval = Mathf.Pow(percentFull, 2f);
      //print(cval);
      sp.color = Color.Lerp(Color.red, Color.green, cval);

    }
}
