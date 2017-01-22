using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialsGraph.Materials
{
    class MaterialUpdateUtil
    {
        public static Dictionary<string, Materials> updateMaterialsDictionary(Dictionary<string, Materials> dictionary, Materials materials)
        {
            if (!dictionary.ContainsKey(materials.getDictionaryKey()))
            {
                dictionary.Add(materials.getDictionaryKey(), materials);
            }
            else
            {
                Materials materials1;
                dictionary.TryGetValue(materials.getDictionaryKey(), out materials1);
                if (0 < DateTime.Compare(materials.Date, materials1.Date))
                {
                    dictionary[materials1.getDictionaryKey()] = materials1;
                }
            }
            return dictionary;
        }
    }
}
