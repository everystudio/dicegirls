using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
	protected PlayerData m_playerData;
	private void Start()
	{
		m_playerData = GetComponent<PlayerCore>().playerData;
	}
}
