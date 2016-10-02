//https://unity3d.com/learn/tutorials/topics/multiplayer-networking/player-health-single-player?playlist=29690

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {	//MUST inherit from NetworkBehivour, not MonoBehaviour!

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Update is called once per frame
	void Update () {

		//Only move local player
		if (!isLocalPlayer) {
			return;
		}
		
		//Move forward and rotate, with input
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

		//Fire bullet
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire();
		}
	}

	//Do something for THIS local player on creation
	//Useful for setting local camera angles or colors
	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	//Fire a bullet
	[Command]	//Commands are called from client and run on server
	void CmdFire()
	{
		//Create bullet from prefab
		GameObject bullet = (GameObject)Instantiate ( bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		//Give it velocity
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;

		//Spawn the bullet on the Clients
		NetworkServer.Spawn(bullet);

		//Destroy it after 2 seconds
		Destroy(bullet, 2.0f);
	}
}
