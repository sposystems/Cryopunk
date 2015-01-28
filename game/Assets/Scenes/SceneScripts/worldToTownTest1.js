var myLevel : String;
 
function OnCollisionEnter (myCollision : Collision) {
 if(myCollision.gameObject.name == "Player"){
  Application.LoadLevel(myLevel);
 }
}