using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
	public float m_fSafeTime;
	public void MapStart()
	{
		if( 0 < m_fSafeTime)
		{
			// 無敵処理再開
			StartCoroutine(SafeAction(m_fSafeTime));
		}
	}
	public IEnumerator SafeAction(float _fTime)
	{
		// 無敵処理開始
		while(0 < m_fSafeTime)
		{
			m_fSafeTime -= Time.deltaTime;
			yield return null;
		}
		//無敵解除
	}

	public void Damage()
	{
		if (0 < m_fSafeTime)
		{
			// 無敵時間なのでダメージを受けない
		}
		else
		{
			m_fSafeTime += 3.0f;
		}
	}
	private void Update()
	{
		if (0 < m_fSafeTime)
		{
			m_fSafeTime -= Time.deltaTime;
		}
	}


	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}




}

