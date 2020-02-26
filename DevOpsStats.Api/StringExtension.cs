using DevOpsStats.Api.Models.Project;
using Newtonsoft.Json;

namespace DevOpsStats.Api
{
    public static class StringExtension
    {
        //Lorna.Watson
        //Lorna Watson

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
