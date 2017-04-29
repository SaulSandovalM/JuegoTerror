var ghost :GameObject; 
function Start(){
  ghost = GameObject.Find("pylon"); 
}
 
function OnTriggerEnter (other : Collider) {   

  if(other.gameObject.tag == "Player")

  Destroy(ghost);  
}