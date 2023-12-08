using UnityEngine;
using System.Collections;
using System;

public class BulletScript : MonoBehaviour {
	//public Animator animator;
	//public AiLocation P =new AiLocation();
	public bool x;

    [Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

	/*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/


	//void Start() { animator = GetComponent<Animator>(); }
	void Update () {

		if(Physics.Raycast(transform.position, transform.forward,out hit, maxDistance, ~ignoreLayer)){
			if(decalHitWall){
				if(hit.transform.tag == "LevelPart"){
					Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
					Destroy(gameObject);
					
				}
				if (hit.transform.tag == "Dummie")
				{
					Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));


					setHit(true);
                    Debug.Log("hhhhhhhhhhhh");
                    //animator.SetBool(0, true);

                    //Destroy(gameObject);

                }else setHit(false);
			}		
			Destroy(gameObject);
		}
		Destroy(gameObject, 0.1f);
	}

	public bool gitHit()
	{
		//if (hit.transform.tag == "Dummie")
		//{
		//	Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
		//	Debug.Log("hhhhhhhhhhhh");
		//}
            return x;
	}

	public void setHit(bool y)
	{
		x = y;
	}

	


		

}
