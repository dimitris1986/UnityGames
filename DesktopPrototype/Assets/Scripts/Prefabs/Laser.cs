﻿using UnityEngine;
using System.Collections;
using OptitrackManagement;
using System;

//TODO: Check shoothit and make it null when needded
public class Laser : MonoBehaviour {

    public float range = 200f;

    Ray shootRay;
    RaycastHit shoothit;
    LineRenderer lasserLine;
    //private Vector3 _moveVector;
    int shootableMask;
    //public float speed = 1500f;
    public Transform laserOrigin;

    //public Transform mouseCursorSprite;

    private OptitrackManager manager;
    private StreemData networkData;

    //public event Action<String> OnObjectSelected;

    private String selectedObject;
    public String SelectedObject
    {
        get { return selectedObject;}
        set { selectedObject = value; }
    }

    private Vector3 targetPosition;
    public Vector3 TargetPosition
    {
        get { return targetPosition; }
        set 
		{ 
			targetPosition = value; 
			manager.CursorPoint = targetPosition;
		}
    }

    void Awake()
    {
        shootableMask = LayerMask.GetMask("wallDisplay");
        lasserLine = this.GetComponent<LineRenderer>();

        this.manager = GetComponentInParent<OptitrackManager>();
        this.manager.OnPointGesture += OnPointGesture;
        //this.manager.OnPointGestureStop += OnPointGestureStop;
        //this.manager.OnSelectGesture += OnSelectGesture;
    }

	void Update()
	{
		Vector3 from =  this.manager.point2.transform.position + laserOrigin.position;
		Vector3 to = this.manager.laserpoint.transform.position + laserOrigin.position;
		
		lasserLine.SetPosition(0, from);
		
		shootRay.origin = from;
		shootRay.direction =(to - from).normalized; // as the direction.
		
		if (Physics.Raycast(shootRay, out shoothit, range, shootableMask))
		{
			TargetPosition = shoothit.point;
			lasserLine.enabled = true;
			lasserLine.SetPosition(1, shoothit.point);
			// mouseCursorSprite.position = Vector3.MoveTowards(mouseCursorSprite.position, shoothit.point, speed * Time.deltaTime);
		}
	}

    private void OnPointGesture(Vector3 _from, Vector3 _to)
    {

		Vector3 from =  this.manager.point2.transform.position + laserOrigin.position;
		Vector3 to = this.manager.laserpoint.transform.position + laserOrigin.position;

		lasserLine.SetPosition(0, from);

        shootRay.origin = from;
        shootRay.direction =(to - from).normalized; // as the direction.

        if (Physics.Raycast(shootRay, out shoothit, range, shootableMask))
        {
            TargetPosition = shoothit.point;
			lasserLine.enabled = true;
			lasserLine.SetPosition(1, shoothit.point);
           // mouseCursorSprite.position = Vector3.MoveTowards(mouseCursorSprite.position, shoothit.point, speed * Time.deltaTime);
        }
    }
	/*
    private void OnSelectGesture(string  wrist)
    {
        if (shoothit.collider != null && shoothit.collider.name == "CALIBRATION")
        {
            SelectedObject = shoothit.collider.name;
            TargetPosition = shoothit.point;
            //Debug.Log(shoothit.collider.name);
            OnObjectSelected(shoothit.collider.name);
        }
        else
            SelectedObject = null;
//        shoothit.transform.position = Vector3.MoveTowards(shoothit.transform.position, wrist.transform.position, speed * Time.deltaTime);
    }
    */
}
