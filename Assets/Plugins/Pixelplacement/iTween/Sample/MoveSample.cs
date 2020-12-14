using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
	public float m_fSafeTime;
	public void MapStart()
	{
		if( 0 < m_fSafeTime)
		{
			// –³“Gˆ—ÄŠJ
			StartCoroutine(SafeAction(m_fSafeTime));
		}
	}
	public IEnumerator SafeAction(float _fTime)
	{
		// –³“Gˆ—ŠJŽn
		while(0 < m_fSafeTime)
		{
			m_fSafeTime -= Time.deltaTime;
			yield return null;
		}
		//–³“G‰ðœ
	}

	public void Damage()
	{
		if (0 < m_fSafeTime)
		{
			// –³“GŽžŠÔ‚È‚Ì‚Åƒ_ƒ[ƒW‚ðŽó‚¯‚È‚¢
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

