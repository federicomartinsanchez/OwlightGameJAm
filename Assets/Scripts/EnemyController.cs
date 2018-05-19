using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {

	public NavMeshAgent agent;
	public Transform Wizard;

	void Update () {
		agent.SetDestination(Wizard.position);	
	}
	
	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Wizard" )
		{
			int wizardHealth = WizardController.Instance.takeDamage(1);
			UIManager.Instance.modifyLifeText(wizardHealth.ToString());

		}
	}
	private void Attack(){
		
	}
}
