using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovableCount : MonoBehaviour
{
	public GameObject m_goRoot;
	public TextMeshProUGUI m_txtAto;

	private void Start()
	{
		Set(-1);
	}

	public void Set(int _iNum)
	{
		m_goRoot.SetActive(0 <= _iNum);
		m_txtAto.text = _iNum.ToString();
	}
}
