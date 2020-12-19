using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "DataItem", menuName = "ScriptableObject/DataItem")]
public class DataItem : ScriptableObject
{
	public string item_name;
	public string item_key;

	public Sprite sprite;
}
