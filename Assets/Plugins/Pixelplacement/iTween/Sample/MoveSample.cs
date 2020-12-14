using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{
	public float m_fSafeTime;
	public void MapStart()
	{
		if( 0 < m_fSafeTime)
		{
			// ���G�����ĊJ
			StartCoroutine(SafeAction(m_fSafeTime));
		}
	}
	public IEnumerator SafeAction(float _fTime)
	{
		// ���G�����J�n
		while(0 < m_fSafeTime)
		{
			m_fSafeTime -= Time.deltaTime;
			yield return null;
		}
		//���G����
	}

	public void Damage()
	{
		if (0 < m_fSafeTime)
		{
			// ���G���ԂȂ̂Ń_���[�W���󂯂Ȃ�
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

