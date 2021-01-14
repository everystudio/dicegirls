using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelItemRoulette : MonoBehaviour
{
	public GameObject m_goRoot;
	public Button m_btnDecide;
	public List<BannerGetItem> m_bannerList;
	public MasuItem m_currentMasuItem;

	public MasuItem debug_masu;

	public void debugRouletteStart()
	{
		if(debug_masu == null)
		{
			Debug.Log("null");
		}
		RouletteStart(debug_masu, (value) =>
		{
		});
	}

	public void RouletteStart(MasuItem _masuItem , Action<DataItem> _onFinished)
	{
		m_goRoot.SetActive(true);
		m_currentMasuItem = _masuItem;

		string result_json = _masuItem.GetItemRouletteResult(m_bannerList.Count);
		MasuItem.ItemResult result_data = JsonUtility.FromJson<MasuItem.ItemResult>(result_json);

		List<DataItem> buf = new List<DataItem>();
		for( int i = 0; i < m_bannerList.Count; i++)
		{
			buf.Add(_masuItem.m_getItemList.Find(p => p.item_key == result_data.keys[i]));
		}

		RouletteStart(buf, result_data.result_index, (value) =>
		{
			_onFinished.Invoke(value);
		});
	}

	public void RouletteStart(List<DataItem> _listDataItem, int _iResultIndex , Action<DataItem> _onFinished)
	{
		for( int i = 0; i < m_bannerList.Count; i++)
		{
			m_bannerList[i].SetData(_listDataItem[i], false);
		}
		StartCoroutine(Roulette(_listDataItem, _iResultIndex, _onFinished));
	}

	private IEnumerator Roulette(List<DataItem> _listDataItem, int _iResultIndex, Action<DataItem> _onFinished)
	{
		yield return StartCoroutine(spin());
		ShowBanner(_iResultIndex);
		yield return new WaitForSeconds(0.5f);
		m_goRoot.SetActive(false);
		_onFinished.Invoke(_listDataItem[_iResultIndex]);
	}

	private IEnumerator spin()
	{
		bool bPushed = false;

		m_btnDecide.onClick.AddListener(() =>
		{
			bPushed = true;
		});

		while(bPushed == false)
		{
			yield return new WaitForSeconds(0.1f);

			int show_index = UtilRand.GetRand(m_bannerList.Count);
			ShowBanner(show_index);
		}
		m_btnDecide.onClick.RemoveAllListeners();
	}

	private void ShowBanner(int _iIndex)
	{
		for( int i = 0; i < m_bannerList.Count; i++)
		{
			m_bannerList[i].Show(_iIndex == i);
		}
	}


}
