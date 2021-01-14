using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuItem : MonoBehaviour
{
	public List<DataItem> m_getItemList;
	public int[] m_iProbList;

	[System.Serializable]
	public class ItemResult
	{
		public int result_index;
		public List<string> keys;
	}

	public string GetItemRouletteResult(int _iNum)
	{
		string ret = "";

		ItemResult result = new ItemResult();
		result.keys = new List<string>();

		for ( int i = 0; i < _iNum; i++)
		{
			int iTempIndex = UtilRand.GetIndex(m_iProbList);
			result.keys.Add(m_getItemList[iTempIndex].item_key);
		}
		result.result_index = UtilRand.GetRand(m_getItemList.Count);
		ret = JsonUtility.ToJson(result);
		//Debug.Log(ret);

		return ret;
	}



}
