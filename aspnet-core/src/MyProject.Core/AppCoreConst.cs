namespace MyProject
{

    /// <summary>
    ///  52ABP代码生成器默认生成的一些常量类 ，不影响业务逻辑点
    /// </summary>
    public class AppLtmConsts
	{
		public const int DefaultPageSize = 10;
		public const int MaxPageSize = 1000;
	}

    public class AppCoreConst
    {
        public static class SchemaNames
        {
            /// <summary>
            /// 生成到数据库中的表名称前缀
            /// </summary>
            public const string TABLE_PREFIX = "";

            public const string Basic = "Basic";

            public const string ABP = "ABP";

            public const string CMS = "CMS";
        }

        /// <summary>
        /// 实体长度单位
        /// </summary>
        public static class EntityLength
        {
            public const int Length8 = 8;
            public const int Length16 = 16;
            public const int Length32 = 32;
            public const int Length64 = 65;
            public const int Length128 = 128;
            public const int Length256 = 256;
            public const int Length512 = 512;
            public const int Length1024 = 1024;

        }
    }
}