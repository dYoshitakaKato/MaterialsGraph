using Grabacr07.KanColleViewer.Composition;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using MaterialsGraph.Csv;
using System.Collections.ObjectModel;
using MaterialsGraph.Materials;
using Grabacr07.KanColleWrapper;
using StatefulModel;
using System;
using MetroTrilithon.Mvvm;
using MetroTrilithon.Lifetime;

namespace MaterialsGraph
{
    [Export(typeof(IPlugin))]
    [ExportMetadata("Title", "Materials Graph")]
    [ExportMetadata("Description", "KanColle Materials Graph Plugin")]
    [ExportMetadata("Version", "1.0")]
    [ExportMetadata("Author", "@hiyori")]
    [ExportMetadata("Guid", "BFBAD457-37B7-4C59-AD0D-9435D50D06D3")]
    [Export(typeof(ITool))]
    class KanColleMaterialsGraph : IPlugin, ITool, IDisposableHolder
    {
        private static Dictionary<string, Materials.Materials> _MaterialsCache = CsvUtil.loadCSVile();
        private bool initialized;

        private readonly MultipleDisposable compositDisposable = new MultipleDisposable();
        private readonly List<IDisposable> fleetHandlers = new List<IDisposable>();

        public static Dictionary<string, Materials.Materials> MaterialsCache
        {
            get
            {
                return _MaterialsCache;
            }
        }

        private MaterialsGraphViewModel viewModel = new MaterialsGraphViewModel();

        string ITool.Name => "Materials Graph";

        object ITool.View => new MaterialGraphView { DataContext = viewModel };

        public void Dispose() => this.compositDisposable.Dispose();
        ICollection<IDisposable> IDisposableHolder.CompositeDisposable => compositDisposable;

        public void Initialize() {
            KanColleClient.Current.Subscribe(nameof(KanColleClient.IsStarted), () => this.InitializeCore(), false).AddTo(this);
        }

        private void InitializeCore()
        {
            var homeport = KanColleClient.Current.Homeport;
            if (homeport == null) return;
            this.initialized = true;
            homeport.Organization
                .Subscribe(nameof(Organization.Fleets), this.test)
                .AddTo(this);
        }

        private void test()
        {
            if (!this.initialized) return;

            /*

            foreach (var handler in this.fleetHandlers)
            {
                handler.Dispose();
            }
            this.fleetHandlers.Clear();
            */
            this.fleetHandlers.Add(KanColleClient.Current.Homeport.Materials.Subscribe(nameof(Homeport.Materials), MaterialUpdateUtil.update));
        }
    }
}
