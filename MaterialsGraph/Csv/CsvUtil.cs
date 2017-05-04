using System;
using System.Collections.Generic;
using Grabacr07.KanColleWrapper;

namespace MaterialsGraph.Csv
{
    class CsvUtil
    {
        public static Dictionary<string, Materials.Materials> loadCSVile()
        {
            Dictionary<string, Materials.Materials> materialsDictionary = new Dictionary<string, Materials.Materials>();
            try
            {
                using (var sr = new System.IO.StreamReader(@"Material.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(',');
                        Materials.Materials materials = new Materials.Materials(
                            values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2]),
                            Convert.ToInt32(values[3]), Convert.ToInt32(values[4]), Convert.ToInt32(values[5]),
                            Convert.ToInt32(values[6]), Convert.ToInt32(values[7]), Convert.ToInt32(values[8]));
                        materialsDictionary = Materials.MaterialUpdateUtil.updateMaterialsDictionary(materialsDictionary, materials);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.ToString());
            }
            /*
            using (MaterialsLogDBContex context = new MaterialsLogDBContex())
            {
                Models.MaterialsLog materialsLog;
                foreach(Materials.Materials materials in materialsDictionary.Values)
                {
                    materialsLog = new Models.MaterialsLog();
                    materialsLog.InsertDate = materials.Date;
                    materialsLog.Fuel = materials.Fuel;
                    materialsLog.Ammunition = materials.Ammunition;
                    materialsLog.Steel = materials.Steel;
                    materialsLog.Bauxite = materials.Bauxite;
                    materialsLog.DevelopmentMaterials = materials.DevelopmentMaterials;
                    materialsLog.InstantRepairMaterials = materials.InstantRepairMaterials;
                    materialsLog.InstantBuildMaterials = materials.InstantBuildMaterials;
                    materialsLog.ImprovementMaterials = materials.ImprovementMaterials;
                    context.MaterialsLogs.Add(materialsLog);
                }
                context.SaveChanges();
            }
            */
            return materialsDictionary;
        }

        public static void writeCSVFile(Materials.Materials materials)
        {
            string date = materials.getDictionaryKey();
            try
            {
                using (var sw = new System.IO.StreamWriter(@"Material.csv", true))
                {
                    sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", materials.Date.ToString()
                        , materials.Fuel
                        , materials.Ammunition, materials.Steel, materials.Bauxite,
                        materials.DevelopmentMaterials, materials.InstantRepairMaterials,
                        materials.InstantBuildMaterials, materials.ImprovementMaterials);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public static Materials.Materials writeCSVFile()
        {
            String date = DateTime.Now.ToString();
            int fuel = KanColleClient.Current.Homeport.Materials.Fuel;
            int ammunition = KanColleClient.Current.Homeport.Materials.Ammunition;
            int steel = KanColleClient.Current.Homeport.Materials.Steel;
            int bauxite = KanColleClient.Current.Homeport.Materials.Bauxite;
            int developmentMaterials = KanColleClient.Current.Homeport.Materials.DevelopmentMaterials;
            int repairMaterials = KanColleClient.Current.Homeport.Materials.InstantRepairMaterials;
            int buildMaterials = KanColleClient.Current.Homeport.Materials.InstantBuildMaterials;
            int improvementMaterials = KanColleClient.Current.Homeport.Materials.ImprovementMaterials;
            try
            {
                using (var sw = new System.IO.StreamWriter(@"Material.csv", true))
                {
                    sw.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", date, fuel, ammunition, steel, bauxite,
                        developmentMaterials, repairMaterials, buildMaterials, improvementMaterials);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return new Materials.Materials(date, fuel, ammunition, steel, bauxite, developmentMaterials, repairMaterials, buildMaterials, improvementMaterials);
        }
    }
}
