/*
Origional Author: Jason Yang (GitHub: dci05049) April 2019

Modified by: Ansel Tessier (email: Ansel.tessier@gmail.com) April 2021

Origional code presented in youtube tutorial "Create Rope Bridge,
String in Unity - Verlet Integration Part 2" by Jason Yang, modified
for use in 2021 College Game Jam
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cord : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.15f;
    private int segmentLength = 25;
    private float lineWidth = 0.05f;
    public GameObject Player;
    public Vector3 CordOffset;
    public List<GameObject> Outletss;
    public float CordLength = 10;
    public float plugInDist = 1;
    public bool plugedIn = true;
    public GameObject current;


    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.DrawRope();
        GameObject OutletGen = GameObject.Find("OutletGenerator");
        Outletss = OutletGen.GetComponent<OutletGeneration>().outlets;
    }

    private void FixedUpdate()
    {
        this.Simulate();
    }

    private void Simulate()
    {
        // SIMULATION
        Vector2 forceGravity = new Vector2(0f, -1.5f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
        }

        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            this.ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        //Constrant to Mouse
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = Player.transform.position + CordOffset;
        this.ropeSegments[0] = firstSegment;

        foreach (GameObject outlet in Outletss)
            {
        if(plugedIn && outlet == current){


          RopeSegment endSegment = this.ropeSegments[this.segmentLength - 1];
          endSegment.posNow = outlet.transform.position;
          this.ropeSegments[this.segmentLength - 1] = endSegment;
        }

        if(current != null && Vector3.Distance(Player.transform.position, current.transform.position)>CordLength){
          plugedIn = false;
          GameObject.Find("Sound").GetComponent<Sound>(). PlayUnplug();
        }

        if(Vector3.Distance(Player.transform.position, outlet.transform.position)<plugInDist && plugedIn == false || current == null){
          plugedIn = true;
          current = outlet;
          GameObject.Find("Sound").GetComponent<Sound>().PlayPlugin();
        }

            }

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector2 changeDir = Vector2.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            } else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }
}
