namespace hudao.Views.Common.KeyBoards
{
    public enum KeyCode
    {
        [KeyAttribute(StringValue = "0", IntValue = 0)]
        Zero = 0,

        [KeyAttribute(StringValue = "1", IntValue = 1)]
        One = 1,

        [KeyAttribute(StringValue = "2", IntValue = 2)]
        Two = 2,

        [KeyAttribute(StringValue = "3", IntValue = 3)]
        Three = 3,

        [KeyAttribute(StringValue = "4", IntValue = 4)]
        Four = 4,

        [KeyAttribute(StringValue = "5", IntValue = 5)]
        Five = 5,

        [KeyAttribute(StringValue = "6", IntValue = 6)]
        Six = 6,

        [KeyAttribute(StringValue = "7", IntValue = 7)]
        Seven = 7,

        [KeyAttribute(StringValue = "8", IntValue = 8)]
        Eight = 8,

        [KeyAttribute(StringValue = "9", IntValue = 9)]
        Nine = 9
    }

    public static class KeyCodeExtension
    {
        public static string StringValue(this KeyCode keyCode)
        {
            var attr = getAttr(keyCode);
            return attr != null ? attr.StringValue : null;
        }

        public static int IntValue(this KeyCode keyCode)
        {
            var attr = getAttr(keyCode);
            return attr != null ? attr.IntValue : int.MinValue;
        }

        private static KeyAttribute getAttr(KeyCode keyCode)
        {
            var memberInfo = typeof(KeyCode).GetMember(keyCode.ToString());
            if (memberInfo.Length == 0)
            {
                return null;
            }
            var attrs = memberInfo[0].GetCustomAttributes(typeof(KeyAttribute), true);
            if (attrs.Length > 0)
            {
                return (KeyAttribute)attrs[0];
            }
            return null;
        }
    }
}
