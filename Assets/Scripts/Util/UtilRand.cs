using UnityEngine;
using System.Collections;

public class UtilRand : MonoBehaviour {

	public static int GetIndex( int [] _intParamArr ){

		int intRet = 0;

		int intParam = 0;
		for( int i = 0 ; i < _intParamArr.Length ; i++ ){
			intParam += _intParamArr[i];
		}
		int intRand = UnityEngine.Random.Range(0, intParam);

		for( intRet = 0 ; intRet < _intParamArr.Length ; intRet++ ){
			int intProb = _intParamArr[intRet];
			if( intRand < intProb ){
				break;
			}
			else {
				intRand -= intProb;
			}
		}
		return intRet;
	}

	public static int GetRand( int _iMax , int _iMin = 0 ){

		if (_iMax < _iMin) {
			return 0;
		}

		int iRet = UnityEngine.Random.Range(_iMin,_iMax);

		return iRet;
	}

	public static float GetRange( float _fMax , float _fMin = 0.0f ){

		float fSeido = 1000.0f;

		int iMax = (int)(_fMax * fSeido);
		int iMin = (int)(_fMin * fSeido);

		int iRand = GetRand ( iMax, iMin);

		float fRet = (float)iRand / fSeido;

		return fRet;

	}

}
