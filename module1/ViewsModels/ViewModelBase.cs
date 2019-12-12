using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace module1.ViewModels
{
    public class ViewModelBase<T> where T : new()
    {
        public string Title { get; set; }
        public T Data { get; set; }
        public List<T> Datas { get; set; }
        public Boolean ShowActionLinks { get; set; }
    }
}