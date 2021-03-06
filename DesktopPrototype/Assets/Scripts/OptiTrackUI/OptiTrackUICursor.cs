﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptiTrackUICursor : AbstractOptiTrackUICursor
{
    public Color normalColor = new Color(1f, 1f, 1f, 0.5f);
    public Color hoverColor = new Color(1f, 1f, 1f, 1f);
    public Color clickColor = Color.red;
    public Vector3 clickScale = new Vector3(.8f, .8f, .8f);

    private Vector3 _initScale;

    public override void Start()
    {
        base.Start();
        //_initScale = transform.localScale;
        //_image.color = new Color(1f, 1f, 1f, 0f);
    }

    public override void ProcessData()
    {
        // update pos
		transform.position = _data.CursorPoint;
		if (_data.ClickGesture)
        {
			Debug.Log("click");
            //_image.color = clickColor;
            //_image.transform.localScale = clickScale;
           // return;
        }
        //_image.transform.localScale = _initScale;
    }
}
