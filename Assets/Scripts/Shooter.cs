using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject  projectile;
    [SerializeField]
    GameObject gun;

    /***
    *       Fire() is used by a defender to shoot the bad guys.
    ***/
    public void Fire()
	{
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
	}   // Fire()
}   // class Shooter
