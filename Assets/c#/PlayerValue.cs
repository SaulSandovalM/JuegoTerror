using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValue : MonoBehaviour {
	
	public Slider Vida;
	public int maxVida;
	public int vidaFallRate;

	public Slider Alimento;
	public int maxAlimento;
	public int alimentoFallRate;

	public Slider Energia;
	public int maxEnergia;
	public int energiaFallRate;

	void Start(){
		Vida.maxValue = maxVida;
		Vida.value = maxVida;

		Alimento.maxValue = maxAlimento;
		Alimento.value = maxAlimento;

		Energia.maxValue = maxEnergia;
		Energia.value = maxEnergia;
	}

	void Update(){
		if (Energia.value <= 0 && (Alimento.value <= 0)) {
			Vida.value -= Time.deltaTime / vidaFallRate * 2;
		}
		else if(Energia.value <= 0 || Alimento.value <= 0){
			Vida.value -= Time.deltaTime / vidaFallRate;
		}
		if(Vida.value <= 0){
			CharacterDeath ();
		}

		//Acaba 

		if (Vida.value >= 0) {
			Vida.value -= Time.deltaTime / alimentoFallRate;
		} 
		else if(Vida.value <= 0){
			Vida.value = 0;
		} 
		else if(Vida.value >= maxAlimento){
			Vida.value = maxAlimento;
		}
	}

	void CharacterDeath(){
	
	}
}
