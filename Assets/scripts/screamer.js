#pragma strict

var flame : GameObject;

function Start () {

flame.SetActive(false);

}

function OnTriggerEnter () { flame.SetActive (true); }

function OnTriggerExit () { flame.SetActive(false); }
