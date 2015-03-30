#pragma strict
var FPScamera : Camera;
var TPcamera : Camera;
private var camSwitch : boolean = false;
function Start () {
	FPScamera.camera.enabled = false;
	TPcamera.camera.enabled = true;
}

function Update () {
	if(Input.GetKeyDown("c")){
		camSwitch = !camSwitch;
		
	}
	if(camSwitch == true){
		
		FPScamera.camera.enabled = true;
		TPcamera.camera.enabled = false;
	}
	else{
		FPScamera.camera.enabled = false;
		TPcamera.camera.enabled = true;
	}
}