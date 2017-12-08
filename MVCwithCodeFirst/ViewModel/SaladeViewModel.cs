using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithCodeFirst.ViewModel
{
    public class SaladeViewModel    
    {
        public Salade Salade { get; set; }
        public IEnumerable<SelectListItem> AllAliments { get; set; }

        private List<int> _selectedAlimentTags;
        public List<int> SelectedAlimentTags
        {
            get
            {
                if (_selectedAlimentTags == null)
                {
                    _selectedAlimentTags = Salade.Aliments.Select(m => m.ID).ToList();
                }
                return _selectedAlimentTags;
            }
            set { _selectedAlimentTags = value; }
        }
    }
}