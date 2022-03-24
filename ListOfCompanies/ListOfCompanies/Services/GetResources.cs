using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ListOfCompanies.Services
{
    public class GetResources
    {
        private static readonly Type _type = typeof(GetResources);

        public static string[] Get(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
             
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(fileName));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return EnumerateLines(reader).ToArray();
            }
        }

        static IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
    