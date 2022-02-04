using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	public GameObject player;
	public Vector3 offset;

	//Lay vi tri phia sau Player
	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
	}
	
	//Theo vi tri Player
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;		
	}
}
