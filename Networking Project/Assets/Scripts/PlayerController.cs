//https://unity3d.com/learn/tutorials/topics/multiplayer-networking/shooting-single-player?playlist=29690

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {	//MUST inherit from NetworkBehivour, not MonoBehaviour!

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
	}

	//Do something for THIS local player on creation
	//Useful for setting local camera angles or colors
	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
