using System.Collections.Generic;

namespace SportsPro.Models
{
    public class DropDownOptionsViewModel
    {
        public Dictionary<string, string> Items { get; set; }
        public string SelectedValue { get; set; }
        public string DefaultValue { get; set; }
        public string DefaultText { get; set; }  
        public bool HasDefault => !string.IsNullOrEmpty(DefaultText);

    }
}

