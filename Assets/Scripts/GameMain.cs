using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : Singleton<GameMain>
{
	public PlayerCore currentPlayer;

	public void MoveRequest( int _iMove)
	{
		currentPlayer.gameObject.GetComponent<PlayerMover>().Request(_iMove, () =>
		{
			Debug.Log("移動完了");
		});
	}



}
