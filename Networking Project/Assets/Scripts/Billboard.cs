using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//Face the main camera
		transform.LookAt(Camera.main.transform);
	}
}
