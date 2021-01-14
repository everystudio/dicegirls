using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHalo : MonoBehaviour
{
    public GameObject m_goHaloObject;
    void Start()
    {
        string strParam = "1234";
        if( int.TryParse(strParam, out int buffer))
        {

        }


        try
        {
            // データベースの書き込み処理
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }

    void Update()
    {
        
    }
}
