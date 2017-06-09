#pragma strict

var enemigo : IA;

function Start () {
	
}

function Update () {
	
}

function OnTriggerEnter(other : Collider){
	if(other.gameObject.tag == ("jugador")){
		enemigo.estado = 2;
	}
}
function OnTriggerExit(other : Collider){
	if(other.gameObject.tag == ("jugador")){
		enemigo.estado = 0;
	}
}