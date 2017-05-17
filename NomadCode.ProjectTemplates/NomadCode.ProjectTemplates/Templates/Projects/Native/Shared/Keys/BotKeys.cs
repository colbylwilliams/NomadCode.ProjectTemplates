namespace ${SolutionName}
{
    public static partial class Keys
	{
		public static partial class MobileCenter
		{
#if __IOS__
			public const string AppSecret = @"";
#elif __ANDROID__
			public const string AppSecret = @"";
#endif
		}

		public static partial class Bot
		{
			public const string DirectLineSecret = @"";
		}
	}
}
