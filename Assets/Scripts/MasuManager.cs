using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasuManager : Singleton<MasuManager>
{
	[SerializeField]
	public const float MasuPitch = 1.0f;
	public const float MasuOffsetX = -0.5f;
	public const float MasuOffsetY = -0.5f;

	public Material m_matLine;

	public Masu GetMasu( int _iMasuId)
	{
		foreach (Masu masu in FindObjectsOfType<Masu>())
		{
			if( masu.masu_id == _iMasuId)
			{
				return masu;
			}
		}
		return null;
	}

	public Vector3Int GetGrid(Vector3 _pos)
	{
		return new Vector3Int(
			Mathf.RoundToInt( (_pos.x )/ MasuManager.MasuPitch),
			Mathf.RoundToInt( (_pos.y ) / MasuManager.MasuPitch),
			Mathf.RoundToInt( _pos.z / MasuManager.MasuPitch)
			);
	}

}
