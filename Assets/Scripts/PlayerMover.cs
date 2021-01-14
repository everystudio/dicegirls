using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMover : PlayerProperty
{
	public void Request(int _iMovableCount , Action _onFinished)
	{
		m_masuCurrent = MasuManager.Instance.GetMasu(m_playerData.masu_id);
		m_iMovableCount = _iMovableCount;
		m_iMoveCount = 0;
		m_evMovableCount.Invoke(m_iMovableCount);

		OnMoveEnd = _onFinished;
		m_iMoveHistory = new int[m_iMovableCount + 1];
		for (int i = 0; i < m_iMoveHistory.Length; i++)
		{
			m_iMoveHistory[i] = 0;
		}
		m_iMoveHistory[0] = m_masuCurrent.masu_id;

		if (m_playerPosition == null)
		{
			m_playerPosition = GetComponent<PlayerPosition>();
		}
	}

	private Masu m_masuCurrent;
	public int m_iMovableCount;
	public int m_iMoveCount;
	private Action OnMoveEnd;
	public int m_iPrevMasuId;
	public int[] m_iMoveHistory;
	private PlayerPosition m_playerPosition;
	public EventInt m_evMovableCount;

	private void Update()
	{
		if( m_iMovableCount <= 0)
		{
			return;
		}

		if (true == m_playerPosition?.IsMoving)
		{
			return;
		}


		Masu.DIR dir = GetMoveDir();

		GameObject target_masu_object = m_masuCurrent.GetConnectedMasuObject(dir);

		if(target_masu_object != null)
		{
			Masu temp = target_masu_object.GetComponent<Masu>();
			int target_masu_id = temp.masu_id;
			if( 0 < m_iMoveCount)
			{
				// 戻る
				if (target_masu_id == m_iMoveHistory[m_iMoveCount-1])
				{
					m_iMoveHistory[m_iMoveCount] = 0;
					m_iMoveCount -= 1;
					m_iMovableCount += 1;
				}
				else
				{
					m_iMoveCount += 1;
					m_iMovableCount -= 1;
					m_iMoveHistory[m_iMoveCount] = target_masu_id;
				}
			}
			else
			{
				m_iMoveCount += 1;
				m_iMovableCount -= 1;
				m_iMoveHistory[m_iMoveCount] = target_masu_id;
			}

			m_playerData.masu_id = target_masu_id;
			m_masuCurrent = MasuManager.Instance.GetMasu(m_playerData.masu_id);
			m_evMovableCount.Invoke(m_iMovableCount);

			if ( m_iMovableCount <= 0)
			{
				m_evMovableCount.Invoke(-1);
				OnMoveEnd.Invoke();
				OnMoveEnd = null;
			}
		}
	}

	private Masu.DIR GetMoveDir()
	{
		Masu.DIR ret = Masu.DIR.MAX;

		float move_v = Input.GetAxis("Vertical");
		float move_h = Input.GetAxis("Horizontal");

		if( 0.0f < move_v )
		{
			ret = Masu.DIR.UP;
		}
		else if( move_v < 0.0f)
		{
			ret = Masu.DIR.DOWN;
		}
		else if( 0.0f < move_h)
		{
			ret = Masu.DIR.RIGHT;
		}
		else if( move_h < 0.0f)
		{
			ret = Masu.DIR.LEFT;
		}
		else
		{
			ret = Masu.DIR.MAX;
		}
		return ret;
	}
}

