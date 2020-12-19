using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryBanner : MonoBehaviour
{
	public TextMeshProUGUI m_txtName;
	public Image m_imgIcon;

	private DataItem m_dataItem;
	public DataItem dataItem
	{
		get { return m_dataItem; }
		set
		{
			if( m_dataItem != value)
			{
				m_dataItem = value;

				if( m_txtName != null)
				{
					m_txtName.text = m_dataItem.item_name;
				}
				if (m_imgIcon != null)
				{
					m_imgIcon.sprite = m_dataItem.sprite;
				}
			}
		}
	}





}
