using System;

namespace anysdk {

	public class AnySDKAnalyticsEnum
	{
		public enum AccountType
		{	
			ANONYMOUS,
			REGISTED,
			SINA_WEIBO,
			TENCENT_WEIBO,
			QQ,
			QQ_WEIBO,
			ND91,
		}

		public enum AccountOperate
		{	
			LOGIN,
			LOGOUT,
			REGISTER,
		}

		public enum AccountGender
		{	
			MALE,
			FEMALE,
			UNKNOWN,
		}

		public enum TaskType
		{	
			GUIDE_LINE,
			MAIN_LINE,
			BRANCH_LINE,
			DAILY,
			ACTIVITY,
			OTHER,
		}
	}
	
}
