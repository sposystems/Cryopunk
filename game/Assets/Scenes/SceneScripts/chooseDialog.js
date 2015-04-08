var showTalk : boolean;
var style: GUIStyle;
public var text : String;
var inBox : boolean;

function Update()
{
	if(Input.GetKeyDown (KeyCode.Return))
	{
		if(inBox && Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showTalk = true;
			inBox = false;
		}
		else
		{
			Time.timeScale = 1;
			showTalk = false;
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
	if(showTalk)
	{
		GUI.Label(Rect(300,300,500,80), text, style);
	}
}