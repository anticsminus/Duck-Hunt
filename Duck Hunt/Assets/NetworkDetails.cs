using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class NetworkDetails : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isServer)
		{
			foreach (NetworkConnection c in NetworkServer.connections)
			{
				Debug.Log(c.address);
			}
		}
	}
}
