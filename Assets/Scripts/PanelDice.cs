using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDice : MonoBehaviour
{
	public GameObject m_goRoot;
	public List<GameObject> m_goDiceCoverList;
	public void Start()
	{
		m_goRoot.SetActive(false);

		PanelDiceRoulette roulette = GetComponent<PanelDiceRoulette>();
		if(roulette == null)
		{
			roulette = gameObject.AddComponent<PanelDiceRoulette>();
		}
		Debug.Log(roulette);
		roulette.enabled = true;
	}

	public void Show( int _iIndex)
	{
		for( int i = 0; i < m_goDiceCoverList.Count; i++)
		{
			m_goDiceCoverList[i].SetActive(i != _iIndex);
		}
	}
	public void Decide( int _iIndex)
	{
		Debug.Log(_iIndex);
		PanelDiceRoulette roulette = GetComponent<PanelDiceRoulette>();
		roulette.enabled = false;
		Show(_iIndex);
		StartCoroutine(RequestMove(_iIndex + 1));
	}
	private IEnumerator RequestMove(int _iMove)
	{
		yield return new WaitForSeconds(2.0f);
		m_goRoot.SetActive(false);

		GameMain.Instance.MoveRequest(_iMove);
	}
}
