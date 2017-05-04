using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models.Raw;
using Livet;
using MaterialsGraph.Csv;
using System.ComponentModel;

namespace MaterialsGraph.Materials
{
    public abstract class UpdateBase : NotificationObject
    {
        public event PropertyChangedEventHandler mPropertyChanged;

        public void update(kcsapi_material[] api_material)
        {
            //Materials materials = new Materials(api_material);
            //CsvUtil.writeCSVFile(materials);
            //MaterialUpdateUtil.updateMaterialsDictionary(KanColleMaterialsGraph.MaterialsCache, materials);

            this.RaisePropertyChanged();
        }
    }

    public class UpdateMaterial : UpdateBase
    {
        public UpdateMaterial(KanColleProxy proxy)
        {
            proxy.api_port.TryParse<kcsapi_port>().Subscribe(x =>
            {
                //update(x.);
            });
            proxy.api_get_member_material.TryParse<kcsapi_material[]>().Subscribe(x => update(x.Data));
        }
    }
}