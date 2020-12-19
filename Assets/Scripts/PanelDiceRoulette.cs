using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDiceRoulette : MonoBehaviour
{
    private PanelDice m_panelDice;
    public int m_iIndex = 0;
    private float m_fTime;
    [SerializeField]
    private float m_fInterval = 0.06f;
    void Start()
    {
        m_panelDice = GetComponent<PanelDice>();
        m_iIndex = 0;
        m_fTime = 0.0f;
    }

    private void Update()
    {
        m_fTime += Time.deltaTime;
        if( m_fInterval < m_fTime)
        {
            m_fTime -= m_fInterval;
            m_iIndex += 1;
            m_iIndex %= m_panelDice.m_goDiceCoverList.Count;
            m_panelDice.Show(m_iIndex);
        }
    }


}
