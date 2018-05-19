using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardController1 : MonoBehaviour
{
    public GameObject fireball;
    public GameObject enemy;
    public GameObject owl;
    public GameObject spawnProjectile;
    

    private NavMeshAgent agent;
    private float fireballSpeed = 15f;
    //private float enemyStandardHeight = 0.5f;

    private void Start ()
    {
        agent = GetComponent<NavMeshAgent>();	
	}
	
	private void Update ()
    {
        Vector3 belowOwl = new Vector3(owl.transform.position.x, spawnProjectile.transform.position.y, owl.transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.LookAt(belowOwl);
            spawnProjectile.transform.LookAt(belowOwl);
            Attack(1, belowOwl);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.LookAt(enemy.transform.position);
            MoveTo(enemy.transform.position);
        }
	}

    //-- Movimiento del mago --
    public void MoveTo(Vector3 destiny)
    {
        agent.SetDestination(destiny);
    }
    
    //-- Método genérico de habilidades --
    public void Attack (int attack, Vector3 destiny)
    {
        switch (attack)
        {
            case 1: FireProjectile(destiny); break;
            case 2: ForceWave(); break;
            default: Debug.Log("No se ha enviado una habilidad"); break;
        }
    }

    //-- Proyectil de bola de fuego --
    private void FireProjectile(Vector3 destiny)
    {
        fireball.GetComponent<FireBallController>().InstantiateProjectile(spawnProjectile, destiny, fireballSpeed);
    }

    //-- Onda de empuje desde el mago --
    private void ForceWave()
    {

    }

    //-- Instaciación de un Objeto --
    /*private void InstantiateProjectile(Vector3 origin, Vector3 destiny, float speed)
    {
        //Rotación del proyectil 
        //Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, ProjectileRotation()));
        fireball = Instantiate(fireball, origin, Quaternion.identity);
        //Miramos hacia la posición donde le ha llamado
        this.transform.LookAt(destiny);
        //El proyectil también se rota hacia esa posición
        fireball.transform.LookAt(destiny);
        //Se aplica la fuerza de desplazamiento
        fireball.GetComponent<Rigidbody>().AddForce(fireball.transform.forward * 1000);
        //fireball.GetComponent<Rigidbody>().velocity = fireball.transform.right * speed;
        //Se destruye el objeto a los 6 segundos
        Destroy(fireball, 6f);
    }

    //-- Rota el proyectil que se dispara --
    private float ProjectileRotation()
    {
        //Arcotangente entre la posicion del mouse y la del origen
        float degrees = Mathf.Atan2(
                                    this.transform.position.y - enemy.transform.position.y,
                                    this.transform.position.x - enemy.transform.position.x
                        ) * Mathf.Rad2Deg - 180; //Desfase de 180 grados 

        //Casteo para 360 grados y no de -180 a 180
        if (degrees > 0) degrees = degrees - 360;

        return degrees;
    }*/
}
