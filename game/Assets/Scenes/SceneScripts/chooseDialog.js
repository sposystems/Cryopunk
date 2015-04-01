var showText : boolean;
var style: GUIStyle;
public var text : String;
var inBox : boolean;

function Update()
{
	if(Input.GetKeyDown (KeyCode.Return))
	{
		if(inBox)
		{
			Time.timeScale = 0;
			showText = true;
			inBox = false;
		}
		else
		{
			Time.timeScale = 1;
			showText = false;
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
		GUI.Label(Rect(500,300,200,20), text, style);
	}
}