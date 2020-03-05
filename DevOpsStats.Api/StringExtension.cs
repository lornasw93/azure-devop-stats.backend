namespace DevOpsStats.Api
{
    public static class StringExtension
    { 
        /// <summary>
        /// Extension that accepts Lorna.Watson and Lorna Watson and outputs forename only i.e. Lorna
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Forename(this string val)
        {
            if (val.Contains("."))
                return val.Split(".")[0];

            if (val.Contains(" "))
                return val.Split(" ")[0];

            return val;
        } 
    } 
}