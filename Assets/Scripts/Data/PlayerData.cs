using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable,CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData")]
public class PlayerData : ScriptableObject
{
	// 通信用
	public int ActorNumber;

	public int state;
	public int masu_id;
}
