using Grabacr07.KanColleWrapper;
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

        public static void update()
        {
            using(MaterialsLogDBContex context = new MaterialsLogDBContex())
            {
                MaterialsLog materialsLog;
                try
                {
                    DateTime date = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd"));
                    materialsLog = context.MaterialsLogs.Find(date);
                    materialsLog.Fuel = KanColleClient.Current.Homeport.Materials.Fuel;
                    materialsLog.Ammunition = KanColleClient.Current.Homeport.Materials.Ammunition;
                    materialsLog.Steel = KanColleClient.Current.Homeport.Materials.Steel;
                    materialsLog.Bauxite = KanColleClient.Current.Homeport.Materials.Bauxite;
                    materialsLog.DevelopmentMaterials = KanColleClient.Current.Homeport.Materials.DevelopmentMaterials;
                    materialsLog.InstantRepairMaterials = KanColleClient.Current.Homeport.Materials.InstantRepairMaterials;
                    materialsLog.InstantBuildMaterials = KanColleClient.Current.Homeport.Materials.InstantBuildMaterials;
                    materialsLog.ImprovementMaterials = KanColleClient.Current.Homeport.Materials.ImprovementMaterials;
                }
                catch (Exception e)
                {
                    materialsLog = new MaterialsLog();
                    materialsLog.InsertDate = DateTime.Now;
                    materialsLog.Fuel = KanColleClient.Current.Homeport.Materials.Fuel;
                    materialsLog.Ammunition = KanColleClient.Current.Homeport.Materials.Ammunition;
                    materialsLog.Steel = KanColleClient.Current.Homeport.Materials.Steel;
                    materialsLog.Bauxite = KanColleClient.Current.Homeport.Materials.Bauxite;
                    materialsLog.DevelopmentMaterials = KanColleClient.Current.Homeport.Materials.DevelopmentMaterials;
                    materialsLog.InstantRepairMaterials = KanColleClient.Current.Homeport.Materials.InstantRepairMaterials;
                    materialsLog.InstantBuildMaterials = KanColleClient.Current.Homeport.Materials.InstantBuildMaterials;
                    materialsLog.ImprovementMaterials = KanColleClient.Current.Homeport.Materials.ImprovementMaterials;
                    context.MaterialsLogs.Add(materialsLog);
                }
                context.SaveChanges();
            }
        }
    }
}
