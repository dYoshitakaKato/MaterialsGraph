﻿using Grabacr07.KanColleViewer.Composition;
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
    class KanColleMaterialsGraph : IPlugin, ITool
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

        public void Initialize()
        {
            new ObservableCollection<UpdateBase>
            {
                new UpdateMaterial(KanColleClient.Current.Proxy)
            };
        }
    }
}
