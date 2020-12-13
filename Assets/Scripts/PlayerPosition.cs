using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : PlayerProperty
{
	private int m_iMasuId;
	private Masu m_targetMasu;
	private bool m_bMoving = false;
	public bool IsMoving { get { return m_bMoving; } }

	private void Update()
	{

		if (m_iMasuId != m_playerData.masu_id && m_bMoving == false)
		{
			m_bMoving = true;
			m_iMasuId = m_playerData.masu_id;
			m_targetMasu = MasuManager.Instance.GetMasu(m_iMasuId);
			iTween.MoveTo(
				gameObject,
				iTween.Hash(
					"x", m_targetMasu.transform.position.x,
					"y", m_targetMasu.transform.position.y,
					"islocal", false,
					"time", 0.5f,
					"oncomplete", "OnComplete",
					"easeType", iTween.EaseType.linear,
					"oncompletetarget", gameObject));
		}
	}
	private void OnComplete()
	{
		m_bMoving = false;
	}

}
