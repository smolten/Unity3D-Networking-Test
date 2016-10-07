using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour {

	//HP display
	public RectTransform healthBar;

	//HP amount
	public const int maxHealth = 100;
	[SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;    //Sync player health across network, hook to function

	public void OnChangeHealth(int currentHealth)
	{
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	public void TakeDamage(int amount)
	{
		if (!isServer) { return; }	//Only compute damage on server

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}
	}

	
}
