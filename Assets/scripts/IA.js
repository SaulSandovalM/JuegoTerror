#pragma strict

//estado
var estado : int = 0;

//animaciones
var nada : AnimationClip;
var caminar : AnimationClip;
var correr : AnimationClip;
var morir : AnimationClip;
var atacar : AnimationClip;

//valores
var pat : float= 0;
var patu : boolean= true;
var direccion : float = 1;

//player
var player : Transform;

//Moviemiento
var vel_seguir : float = 3;

function Start () {

}

function Update () {
	if (pat <= 0) {
		patu = false;
		estado = 0;
		direccion= direccion *( -1);
	}	

	if (pat >= 10) {
		patu = true;
		estado = 1;
	}

	if (patu == true && estado == 1){
		pat -= 1 *Time.deltaTime;
	}

	if (patu == false && estado == 0) {
		pat += 1 *Time.deltaTime;
	}

	if (estado == 0){//nada
		Nada ();
	}

	if (estado == 1){//patrullar
		Patrullar ();
		transform.rotation.x = 0;
		transform.rotation.z = 0;
	}

	if (estado == 2){//perseguir
		Perseguir ();
	}

	if (estado == 3){//atacar
		Atacar ();
	}

	if (estado == 4){//morir
		Morir ();
	}

	if (estado == 5){//esquivar
		Esquibar ();
	}
}

function Nada () {
	GetComponent.<Animation>().Play (nada.name);
}

function Patrullar () {
	transform.Rotate (Vector3 (0,25*direccion,0)*Time.deltaTime);
	transform.Translate (Vector3(0,0,1)*Time.deltaTime);
	GetComponent.<Animation>().Play (caminar.name);
	transform.rotation.x = 0;
	transform.rotation.z = 0;
}

function Perseguir () {
	GetComponent.<Animation>().Play (correr.name);
	transform.LookAt(player);
	transform.Translate(Vector3(0,0,1*vel_seguir*Time.deltaTime));
	transform.rotation.x = 0;
	transform.rotation.z = 0;
}

function Atacar () {
	GetComponent.<Animation>().Play (atacar.name);
}

function Morir () {
	GetComponent.<Animation>().Play (morir.name);
}

function Esquibar () {
	GetComponent.<Animation>().Play (caminar.name);
}