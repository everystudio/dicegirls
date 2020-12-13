using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MasuManager))]
public class MasuManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		MasuManager script = target as MasuManager;
		base.OnInspectorGUI();
		if( GUILayout.Button("Set MasuId"))
		{
			int masu_id = 1;
			foreach( Masu masu in script.gameObject.GetComponentsInChildren<Masu>())
			{
				masu.masu_id = masu_id;
				masu_id += 1;
			}
		}
		if (GUILayout.Button("Grid to Position"))
		{
			foreach (Masu masu in script.gameObject.GetComponentsInChildren<Masu>())
			{
				masu.transform.localPosition = new Vector3(
					masu.grid.x * MasuManager.MasuPitch ,
					masu.grid.y * MasuManager.MasuPitch ,
					masu.grid.z * MasuManager.MasuPitch
					);
			}
		}
		if (GUILayout.Button("Position to Grid"))
		{
			foreach (Masu masu in script.gameObject.GetComponentsInChildren<Masu>())
			{
				masu.grid = MasuManager.Instance.GetGrid(masu.transform.localPosition);
			}
		}
		if (GUILayout.Button("Clear Line"))
		{
			foreach (Masu masu in script.gameObject.GetComponentsInChildren<Masu>())
			{
				masu.ClearLine();
			}
		}

		if (GUILayout.Button("Connect Masu"))
		{
			List<Masu> masu_list = new List<Masu>();
			foreach( Masu masu in script.gameObject.GetComponentsInChildren<Masu>())
			{
				masu.ClearConnectAll();
				masu_list.Add(masu);
			}

			foreach (Masu masu in masu_list)
			{
				List<Masu> search_x = masu_list.FindAll(p => p.grid.x == masu.grid.x && masu.grid.y < p.grid.y);
				search_x.Sort((a, b) => a.grid.y - b.grid.y);

				foreach ( Masu masu_x in search_x)
				{
					if( masu_x.m_bBlockDown == false)
					{
						masu.Connect(Masu.DIR.UP, masu_x);
						break;
					}
					else
					{
						break;
					}
				}

				List<Masu> search_z = masu_list.FindAll(p => p.grid.y == masu.grid.y && masu.grid.x < p.grid.x);
				search_z.Sort((a, b) => a.grid.x - b.grid.x);

				foreach (Masu masu_z in search_z)
				{
					if (masu_z.m_bBlockLeft == false)
					{
						masu.Connect(Masu.DIR.RIGHT, masu_z);
						break;
					}
					else
					{
						break;
					}
				}
			}
			foreach (Masu masu in masu_list)
			{
				masu.DrawLine(script.m_matLine);
			}

		}

	}
}
