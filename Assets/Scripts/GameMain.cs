using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : Singleton<GameMain>
{
	public PlayerCore currentPlayer;

	public int m_iPlayerIndex;
	public List<PlayerCore> m_playerList;

	public FieldMenu m_fieldMenu;

	public PanelItemRoulette m_panelItemRoulette;

	public void MoveRequest( int _iMove)
	{
		m_fieldMenu.gameObject.SetActive(false);
		currentPlayer.gameObject.GetComponent<PlayerMover>().Request(_iMove, () =>
		{
			Debug.Log("移動完了");

			Masu masu = MasuManager.Instance.GetMasu(currentPlayer.playerData.masu_id);
			if( masu.m_eType == Masu.TYPE.ITEM)
			{
				MasuItem masu_item = masu.gameObject.GetComponent<MasuItem>();
				m_panelItemRoulette.RouletteStart(masu_item, (value) =>
				{
					Debug.Log(value.item_name);
					ChangeNextPlayer();
				});
			}
			else
			{
				ChangeNextPlayer();
			}

		});
	}

	private void ChangeNextPlayer()
	{
		m_iPlayerIndex += 1;
		m_iPlayerIndex %= m_playerList.Count;

		currentPlayer.m_virtualCamera.Priority = 0;
		currentPlayer = m_playerList[m_iPlayerIndex];
		currentPlayer.m_virtualCamera.Priority = 10;

		m_fieldMenu.gameObject.SetActive(true);

	}



}
