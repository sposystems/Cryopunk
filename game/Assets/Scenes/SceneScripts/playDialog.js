var showText : boolean;
var style: GUIStyle;
public var text : String;
var textNotShown : boolean;

function Update()
{
	if(Input.GetKeyDown (KeyCode.Return))
	{
		Time.timeScale = 1;
		showText = false;
		textNotShown = false;
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
		GUI.Label(Rect(500,300,200,20), text, style);
	}
}