using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expControler : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.Play("explosion");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
