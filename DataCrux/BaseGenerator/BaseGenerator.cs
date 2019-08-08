using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DataCrux.BaseGenerator
{
    public abstract class BaseDataGenerator
    {
        private const string ResourcePathPrefix = "DataCrux.ResourceFiles.Resources.";

        protected readonly Random RandGen;

        protected BaseDataGenerator()
        {
            RandGen = new Random();
        }

        protected BaseDataGenerator(Random randGen)
        {
            RandGen = randGen;
        }

        private static Stream ReadResourceStreamForFileName(string resourceFileName)
        {
#if NET40
            return Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);
#else
            var res = typeof(BaseDataGenerator).GetTypeInfo().Assembly
                .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);
            return res;
#endif
        }

        protected ICollection<string> ReadResourceByLine(string resourceFileName)
        {
            var stream = ReadResourceStreamForFileName(resourceFileName);

            var list = new List<string>();

            var streamReader = new StreamReader(stream);
            string str;

            while ((str = streamReader.ReadLine()) != null)
            {
                if (str != string.Empty)
                    list.Add(str);
            }


            return list;
        }
    }
}
   