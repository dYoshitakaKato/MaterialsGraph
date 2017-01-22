using Grabacr07.KanColleWrapper.Models.Raw;
using System;

namespace MaterialsGraph.Materials
{
    class Materials
    {
        private DateTime _Date;
        public DateTime Date
        {
            get
            {
                return _Date;
            }

            private set
            {
                _Date = value;
            }
        }

        private int _Fuel;
        public int Fuel
        {
            get
            {
                return _Fuel;
            }

            private set
            {
                _Fuel = value;
            }
        }

        private int _Ammunition;
        public int Ammunition
        {
            get
            {
                return _Ammunition;
            }

            private set
            {
                _Ammunition = value;
            }
        }

        private int _Steel;
        public int Steel
        {
            get
            {
                return _Steel;
            }

            private set
            {
                _Steel = value;
            }
        }

        private int _Bauxite;
        public int Bauxite
        {
            get
            {
                return _Bauxite;
            }

            private set
            {
                _Bauxite = value;
            }
        }

        private int _DevelopmentMaterials;
        public int DevelopmentMaterials
        {
            get
            {
                return _DevelopmentMaterials;
            }

            private set
            {
                _DevelopmentMaterials = value;
            }
        }

        private int _InstantRepairMaterials;
        public int InstantRepairMaterials
        {
            get
            {
                return _InstantRepairMaterials;
            }

            private set
            {
                _InstantRepairMaterials = value;
            }
        }

        private int _InstantBuildMaterials;
        public int InstantBuildMaterials
        {
            get
            {
                return _InstantBuildMaterials;
            }

            private set
            {
                _InstantBuildMaterials = value;
            }
        }

        private int _ImprovementMaterials;
        public int ImprovementMaterials
        {
            get
            {
                return _ImprovementMaterials;
            }

            private set
            {
                _ImprovementMaterials = value;
            }
        }

        public Materials(String date, int fuel, int ammunition, int steel, int bauxite,
            int developmentMaterials, int repairMaterials, int buildMaterials, int improvementMaterials)
        {
            Date = DateTime.Parse(date);
            Fuel = fuel;
            Ammunition = ammunition;
            Steel = steel;
            Bauxite = bauxite;
            DevelopmentMaterials = developmentMaterials;
            InstantRepairMaterials = repairMaterials;
            InstantBuildMaterials = buildMaterials;
            ImprovementMaterials = improvementMaterials;
        }

        public Materials(kcsapi_material[] api_material)
        {
            if (api_material != null && 8 <= api_material.Length)
            {
                Date = DateTime.Now;
                Fuel = api_material[0].api_value;
                Ammunition = api_material[1].api_value;
                Steel = api_material[2].api_value;
                Bauxite = api_material[3].api_value;
                DevelopmentMaterials = api_material[6].api_value;
                InstantRepairMaterials = api_material[5].api_value;
                InstantBuildMaterials = api_material[4].api_value;
                ImprovementMaterials = api_material[7].api_value;
            }
        }

        public string getDictionaryKey()
        {
            return Date.ToString("yyyyMMdd");
        }

        public void update(int fuel, int ammunition, int steel, int bauxite,
            int developmentMaterials, int repairMaterials, int buildMaterials, int improvementMaterials)
        {
            Fuel = fuel;
            Ammunition = ammunition;
            Steel = steel;
            Bauxite = bauxite;
            DevelopmentMaterials = developmentMaterials;
            InstantRepairMaterials = repairMaterials;
            InstantBuildMaterials = buildMaterials;
            ImprovementMaterials = improvementMaterials;
        }
    }
}
