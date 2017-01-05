namespace hudao.Utils
{
    public static class StringUtils
    {
        public static bool IsEmpty(string val)
        {
            if (val == null)
            {
                return true;
            }

            if (val == "")
            {
                return true;
            }

            return false;
        }
    }
}
