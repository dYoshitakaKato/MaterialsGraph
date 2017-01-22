using System;
using System.Collections.ObjectModel;
using Livet;
using System.Windows;
using Sparrow.Chart;

namespace MaterialsGraph
{
    class MaterialsGraphViewModel : ViewModel
    {
        public ObservableCollection<Point> Fuel { get; set; }
        public ObservableCollection<Point> Ammunition { get; set; }
        public ObservableCollection<Point> Steel { get; set; }
        public ObservableCollection<Point> Bauxite { get; set; }
        public ObservableCollection<Point> InstantRepairMaterials { get; set; }
        public ObservableCollection<Point> ImprovementMaterials { get; set; }

        public MaterialsGraphViewModel()
        {
            Fuel = new ObservableCollection<Point>();
            Ammunition = new ObservableCollection<Point>();
            Steel = new ObservableCollection<Point>();
            Bauxite = new ObservableCollection<Point>();
            InstantRepairMaterials = new ObservableCollection<Point>();
            ImprovementMaterials = new ObservableCollection<Point>();
            SparrowChart chart = new SparrowChart();

            DateTime date = DateTime.Now;
            setChart(date, 0, date.AddDays(-14));
        }

        private void setChart(DateTime date, int x_position, DateTime limit)
        {
            if (date.CompareTo(limit) == 0)
            {
                return;
            }
            Materials.Materials materials;
            string key = limit.ToString("yyyyMMdd");
            try
            {
                KanColleMaterialsGraph.MaterialsCache.TryGetValue(key, out materials);
            }
            catch (ArgumentNullException)
            {
                setChart(date, x_position += 1, limit.AddDays(1));
                return;
            }
            if (materials == null)
            {
                setChart(date, x_position += 1, limit.AddDays(1));
                return;
            }
            Fuel.Add(new Point { X = limit.ToOADate(), Y = materials.Fuel });
            Ammunition.Add(new Point { X = limit.ToOADate(), Y = materials.Ammunition });
            Steel.Add(new Point { X = limit.ToOADate(), Y = materials.Steel });
            Bauxite.Add(new Point { X = limit.ToOADate(), Y = materials.Bauxite });
            InstantRepairMaterials.Add(new Point { X = limit.ToOADate(), Y = materials.InstantRepairMaterials * 100 });
            ImprovementMaterials.Add(new Point { X = limit.ToOADate(), Y = materials.ImprovementMaterials * 100 });
            DateTimeXAxis xaxis = new DateTimeXAxis();
            setChart(date, x_position += 1, limit.AddDays(1));
            return;
        }
    }
}
