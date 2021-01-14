using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCore : MonoBehaviour
{
	[SerializeField]
	private PlayerData m_playerData;
	public PlayerData playerData { get { return m_playerData; } }

	public CinemachineVirtualCamera m_virtualCamera;
}
