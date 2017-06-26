using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour 
{
	private const int RIGHT_ANGLE = 90; 
	
	//Esta variable nos ayuda a saber si esta caminando o no ^_^ 
	private bool isWalking = false;
	
	CardboardHead head = null;
	
	//Esta variable nos ayudara a saber si el jugador esta moviendose
	[Tooltip("With this speed the player will move.")]
	public float speed;
	
	[Tooltip("Activate this checkbox if the player shall move when the Cardboard trigger is pulled.")]
	public bool walkWhenTriggered;
	
	[Tooltip("Activate this checkbox if the player shall move when he looks below the threshold.")]
	public bool walkWhenLookDown;
	
	[Tooltip("This has to be an angle from 0° to 90°")]
	public double thresholdAngle;
	
	[Tooltip("Activate this Checkbox if you want to freeze the y-coordiante for the player. " +
	         "For example in the case of you have no collider attached to your CardboardMain-GameObject" +
	         "and you want to stay in a fixed level.")]
	public bool freezeYPosition; 
	
	[Tooltip("This is the fixed y-coordinate.")]
	public float yOffset;
	

	void Start () 
	{
		head = Camera.main.GetComponent<StereoController>().Head;
	}	

	void Update () 
	{
		// Camina cuando el trigger este en uso
		if (walkWhenTriggered && !walkWhenLookDown && !isWalking && Cardboard.SDK.Triggered) 
		{
			isWalking = true;
		} 
		else if (walkWhenTriggered && !walkWhenLookDown && isWalking && Cardboard.SDK.Triggered) 
		{
			isWalking = false;
		}
		
		// Camina cuando el jugador mira hacia abajo de el angulo
		if (walkWhenLookDown && !walkWhenTriggered && !isWalking &&  
		    head.transform.eulerAngles.x >= thresholdAngle && 
		    head.transform.eulerAngles.x <= RIGHT_ANGLE) 
		{
			isWalking = true;
		} 
		else if (walkWhenLookDown && !walkWhenTriggered && isWalking && 
		         (head.transform.eulerAngles.x <= thresholdAngle ||
		         head.transform.eulerAngles.x >= RIGHT_ANGLE)) 
		{
			isWalking = false;
		}
		
		// Camina cuando el jugador mira arriba del angulo
		if (walkWhenLookDown && walkWhenTriggered && !isWalking &&  
		    head.transform.eulerAngles.x >= thresholdAngle && 
		    Cardboard.SDK.Triggered &&
		    head.transform.eulerAngles.x <= RIGHT_ANGLE) 
		{
			isWalking = true;
		} 
		else if (walkWhenLookDown && walkWhenTriggered && isWalking && 
		         head.transform.eulerAngles.x >= thresholdAngle &&
		         (Cardboard.SDK.Triggered || 
		         head.transform.eulerAngles.x >= RIGHT_ANGLE)) 
		{
			isWalking = false;
		}
		
		if (isWalking) 
		{
			Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate(rotation * direction);
		}
		
		if(freezeYPosition)
		{
			transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
		}
	}
}