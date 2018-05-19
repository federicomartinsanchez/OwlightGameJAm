using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{

    //-- Instaciación de un Objeto --
    public void InstantiateProjectile(GameObject origin, Vector3 destiny, float speed)
    {
        //Instanciación de objeto
        GameObject fireball = Instantiate(this.gameObject, origin.transform.position, Quaternion.identity);
        //El proyectil también se rota hacia esa posición
        fireball.transform.LookAt(destiny);
        //Se aplica la fuerza de desplazamiento
        fireball.GetComponent<Rigidbody>().AddForce(origin.transform.forward * 1000);
        //Se destruye el objeto a los 5 segundos
        Destroy(fireball, 5f);
    }
}
