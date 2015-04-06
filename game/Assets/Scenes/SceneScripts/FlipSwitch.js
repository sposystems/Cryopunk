#pragma strict
var anim : String;
var inBox : boolean = false;
var flipped : boolean = false;
var boulder : GameObject;
var showText : boolean;
var style: GUIStyle;
public var text : String;

function Start () {
	boulder = GameObject.Find("BlockingBoulder");
}

function Update () {
	if(Input.GetKeyDown (KeyCode.Return))
	{
		if(inBox)
		{
			if(!showText)
			{
				if(!flipped)
				{
					animation.Play(anim);
					flipped = true;
					boulder.transform.position = Vector3(200,0,150);
					Time.timeScale = 0;
					showText = true;
				}
			}
			
			else if(showText)
			{
				Time.timeScale = 1;
				showText = false;
			}
		}
		
	}
}

function OnTriggerEnter()
{
	inBox = true;
}

function OnTriggerExit()
{
	inBox = false;
}

function OnGUI()
{
	if(showText)
	{
		GUI.TextArea(Rect(300,300,400,80), text, style);
	}
}