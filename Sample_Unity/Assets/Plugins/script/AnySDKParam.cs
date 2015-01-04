using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;
using System.Runtime.InteropServices;


namespace anysdk {
	[StructLayoutAttribute(LayoutKind.Sequential)]
	public struct AnySDKParam {
		
		private ParamType _type;
		private int _intValue;
		private float _floatValue;
		private bool _boolValue;
		private string _strValue;
		private string _strMapValue;
		
		enum ParamType {
			kParamTypeNull=0,
			kParamTypeInt,
			kParamTypeFloat,
			kParamTypeBool,
			kParamTypeString,
			kParamTypeStringMap,
			kParamTypeMap			
		};
		
		public AnySDKParam(int nValue) {
			_intValue = nValue;
			_floatValue = 0;
			_boolValue = false;
			_strValue = null;
			_strMapValue = null;
			_type = ParamType.kParamTypeInt;

		}
		
		public AnySDKParam(float nValue) {
			_intValue = 0;
			_floatValue = nValue;
			_boolValue = false;
			_strValue = null;
			_strMapValue = null;
			_type = ParamType.kParamTypeFloat;
		}

		public AnySDKParam(bool nValue) {
			_intValue = 0;
			_floatValue = 0;
			_boolValue = nValue;
			_strValue = null;
			_strMapValue = null;
			_type = ParamType.kParamTypeBool;
		}
		public AnySDKParam(string nValue) {
			_intValue = 0;
			_floatValue = 0;
			_boolValue = false;
			_strValue = nValue;
			_strMapValue = null;
			_type = ParamType.kParamTypeString;
		}

		public AnySDKParam(Dictionary<string,string> nValue) {
			_intValue = 0;
			_floatValue = 0;
			_boolValue = false;
			_strValue = null;
			_strMapValue = AnySDKUtil.dictionaryToString( nValue);
			_type = ParamType.kParamTypeStringMap;
		}
		
		public int getCurrentType() {
			return (int)_type;
		}
		
		public int getIntValue() {
			return _intValue;
		}
		
		public float getFloatValue() {
			return _floatValue;
		}
		
		public bool getBoolValue() {
			return _boolValue;
		}
		public string getStringValue() {
			return _strValue;
		}
		
		public string getStrMapValue() {
			return _strMapValue;
		}
		
	}
}


