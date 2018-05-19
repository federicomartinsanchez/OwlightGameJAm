using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardController : MonoBehaviour {

	public static WizardController Instance;
	public Camera cam;
	public int _health = 10;

    public GameObject fireball;
    public GameObject enemy;
    public GameObject owl;
    public GameObject spawnProjectile;

	private NavMeshAgent _agent;
	private float _fireballSpeed = 15f;

	private void Awake() 
	{
		Instance = this;
	}
	private void Start()
	{
		UIManager.Instance.modifyLifeText("10");
		_agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () 
	{
		// -- Wizard Point and click movement -- 

		// if (Input.GetMouseButtonDown(0)){
		// 	Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		// 	RaycastHit hit;
		// 	if (Physics.Raycast(ray,out hit))
		// 	{
		// 		_agent.SetDestination(hit.point);
		// 	};
		// }
		if (Input.GetKeyDown(KeyCode.A))
		{
			//UIManager.Instance
		}
		    Vector3 belowOwl = new Vector3(owl.transform.position.x, spawnProjectile.transform.position.y, owl.transform.position.z);
        if (Input.GetMouseButtonDown(1))
        {
            this.transform.LookAt(belowOwl);
            //spawnProjectile.transform.LookAt(belowOwl);
            Attack(1, belowOwl);
        }
        // else if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     this.transform.LookAt(enemy.transform.position);
        //     MoveTo(enemy.transform.position);
        // }
	}

	//-- Movimiento del mago -- 
	public void MoveTo(Vector3 target)
	{
		_agent.SetDestination(target);
			
	}
	public int takeDamage(int Damage)
	{
		_health-= Damage;

		return _health;
	}
	
    //-- Método genérico de habilidades --
    public void Attack (int attack, Vector3 destiny)
    {
        switch (attack)
        {
            case 1: FireProjectile(destiny); break;
            //case 2: ForceWave(); break;
            default: Debug.Log("No se ha enviado una habilidad"); break;
        }
    }

    //-- Proyectil de bola de fuego --
    private void FireProjectile(Vector3 destiny)
    {
        fireball.GetComponent<FireBallController>().InstantiateProjectile(spawnProjectile, destiny, _fireballSpeed);
    }

}
