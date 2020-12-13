using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class Masu : MonoBehaviour
{
	public enum TYPE{
		NORMAL	= 0,
		ITEM	,
		MAGIC	,
		SHOP	,
		INN		,
		RARE	,
		VILLAGE	,
		MAX		
	};
	public TYPE m_eType;
	public enum DIR
	{
		UP,
		DOWN,
		RIGHT,
		LEFT,
		MAX,
	}
	public Vector3Int grid;

	public GameObject up;
	public GameObject down;
	public GameObject left;
	public GameObject right;

	public GameObject[] connect_masu_arr
	{
		get
		{
			return new GameObject[4]
			{
				up,
				down,
				left,
				right
			};
		}
	}

	public int masu_id;
	public bool m_bBlockLeft;
	public bool m_bBlockDown;

	private SpriteRenderer m_spriteRenderer;

	private List<LineRenderer> line_list = new List<LineRenderer>();

	public void Start()
	{
		gameObject.tag = "Masu";
	}

#if UNITY_EDITOR
	private void OnEnable()
	{
		UnityEditor.SceneView.duringSceneGui += OnSceneView;
	}

	private void OnDestroy()
	{
		UnityEditor.SceneView.duringSceneGui -= OnSceneView;
	}

	void OnSceneView(SceneView sceneView)
	{
		if (Selection.activeGameObject != gameObject)
		{
			return;
		}
		//Debug.Log(Event.current.type);

		var sceneCamera = SceneView.currentDrawingSceneView.camera; ;
		var pos = sceneCamera.WorldToScreenPoint(transform.position);

		float width = 120.0f;
		Handles.BeginGUI();

		var buttonRect = new Rect(pos.x, SceneView.currentDrawingSceneView.position.height - pos.y, 100, 30);

		GUILayout.TextField(string.Format("Block(L:{0})(D:{1})",
			m_bBlockLeft ? "■" : "○",
			m_bBlockDown ? "■" : "○"
			), GUILayout.Width(width));


		if (GUILayout.Button("LeftLock", GUILayout.Width(width)))
		{
			//<--- ボタンが押されるとここが実行されます。--->//
			m_bBlockLeft = !m_bBlockLeft;
		}
		if (GUILayout.Button("DownLock", GUILayout.Width(width)))
		{
			//<--- ボタンが押されるとここが実行されます。--->//
			m_bBlockDown = !m_bBlockDown;
		}
		if( GUILayout.Button("Change MasuType", GUILayout.Width(width)))
		{
			m_eType += 1;
			if( m_eType == TYPE.MAX)
			{
				m_eType = (TYPE)0;
			}
			
			if(m_spriteRenderer == null)
			{
				m_spriteRenderer = GetComponent<SpriteRenderer>();
			}

			foreach (string s in AssetDatabase.FindAssets("t:ScriptableObject", new string[] { "Assets/ScriptableObjects" }))
			{
				var path = AssetDatabase.GUIDToAssetPath(s);
				if (path.Contains("Masu"))
				{
					m_spriteRenderer.material = AssetDatabase.LoadAssetAtPath<MasuRefarences>(path).masu_materials[(int)m_eType];
				}
			}


		}
		
		Handles.EndGUI();
	}

#endif


	public void Connect(DIR _dir , Masu _masu)
	{
		if( _dir == DIR.UP)
		{
			up = _masu.gameObject;
			_masu.down = gameObject;
		}
		else if( _dir == DIR.RIGHT)
		{
			right = _masu.gameObject;
			_masu.left = gameObject;
		}
	}
	public void ClearConnectAll()
	{
		up = null;
		down = null;
		right = null;
		left = null;
		ClearLine();
	}

	public void ClearLine()
	{
		if(line_list == null)
		{
			line_list = new List<LineRenderer>();
		}
		List<GameObject> delete_list = new List<GameObject>();
		foreach( LineRenderer l in gameObject.GetComponentsInChildren<LineRenderer>())
		{
			delete_list.Add(l.gameObject);
		}
		foreach( GameObject go in delete_list)
		{
			DestroyImmediate(go);
		}
		line_list.Clear();
	}

	public void DrawLine(Material _line_material)
	{
		foreach(LineRenderer line in line_list)
		{
			if (line != null)
			{
				DestroyImmediate(line.gameObject);
			}
		}
		line_list.Clear();

		if (up != null)
		{
			show_line(up, _line_material);
		}
		if (down != null)
		{
			show_line(down, _line_material);
		}
		if (right != null)
		{
			show_line(right, _line_material);
		}
		if (left != null)
		{
			show_line(left, _line_material);
		}

	}

	private void show_line(GameObject _target , Material _material)
	{
		GameObject gameobject_line = new GameObject();
		gameobject_line.transform.parent = gameObject.transform;

		LineRenderer line = gameobject_line.AddComponent<LineRenderer>();
		//Debug.Log(line);
		line.positionCount =2;
		line.startWidth = 0.2f;
		line.endWidth = 0.2f;

		line.SetPosition(0, gameObject.transform.position);
		line.SetPosition(1, _target.transform.position);

		line.material = _material;

		line.startColor = Color.white;
		line.endColor = Color.white;

		line_list.Add(line);
	}
	public GameObject GetConnectedMasuObject(DIR _dir)
	{
		GameObject ret = null;

		switch (_dir)
		{
			case DIR.UP:
				ret = up;
				break;
			case DIR.DOWN:
				ret = down;
				break;
			case DIR.LEFT:
				ret = left;
				break;
			case DIR.RIGHT:
				ret = right;
				break;
			default:
				break;
		}
		return ret;
	}

}
