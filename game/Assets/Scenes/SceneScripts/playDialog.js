﻿var showText : boolean;
var style: GUIStyle;
public var text : String;
var textNotShown : boolean = true;

function Update()
{
	if(Input.GetKeyDown (KeyCode.Return))
	{
		if(showText)
		{
			Time.timeScale = 1;
			showText = false;
			textNotShown = false;
		}
	}
}

function OnTriggerEnter()
{
	if (textNotShown)
	{
		Time.timeScale = 0;
		showText = true;
	}
}

function OnGUI()
{
	if(showText)
	{
		GUI.TextArea(Rect(300,300,600,80), text, style);
	}
}