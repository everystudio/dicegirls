using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BannerGetItem : MonoBehaviour
{
	public DataItem m_dataItem;

	public TextMeshProUGUI m_txtName;
	public Image m_imgIcon;
	public GameObject m_goCover;

	public void SetData(DataItem _data , bool _bIsShow)
	{
		m_dataItem = _data;
		m_txtName.text = m_dataItem.item_name;
		m_imgIcon.sprite = m_dataItem.sprite;
		Show(_bIsShow);
	}

	public void Show( bool _bIsShow)
	{
		m_goCover.SetActive(!_bIsShow);
	}


}
