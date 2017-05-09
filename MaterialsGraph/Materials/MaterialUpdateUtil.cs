using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models.Raw;
using MaterialsGraph.Models;
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

        public static void update(kcsapi_material[] api_material)
        {
            using(MaterialsLogDBContex context = new MaterialsLogDBContex())
            {
                MaterialsLog materialsLog;
                try
                {
                    DateTime date = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
                    materialsLog = context.MaterialsLogs.Find(date);
                    materialsLog.Fuel = api_material[0].api_value;
                    materialsLog.Ammunition = api_material[1].api_value;
                    materialsLog.Steel = api_material[2].api_value;
                    materialsLog.Bauxite = api_material[3].api_value;
                    materialsLog.InstantBuildMaterials = api_material[4].api_value;
                    materialsLog.InstantRepairMaterials = api_material[5].api_value;
                    materialsLog.DevelopmentMaterials = api_material[6].api_value;
                    materialsLog.ImprovementMaterials = api_material[7].api_value;
                }
                catch (Exception e)
                {
                    materialsLog = new MaterialsLog();
                    materialsLog.InsertDate = DateTime.Now;
                    materialsLog.Fuel = api_material[0].api_value;
                    materialsLog.Ammunition = api_material[1].api_value;
                    materialsLog.Steel = api_material[2].api_value;
                    materialsLog.Bauxite = api_material[3].api_value;
                    materialsLog.InstantBuildMaterials = api_material[4].api_value;
                    materialsLog.InstantRepairMaterials = api_material[5].api_value;
                    materialsLog.DevelopmentMaterials = api_material[6].api_value;
                    materialsLog.ImprovementMaterials = api_material[7].api_value;
                    context.MaterialsLogs.Add(materialsLog);
                }
                context.SaveChanges();
            }
        }
    }
}
