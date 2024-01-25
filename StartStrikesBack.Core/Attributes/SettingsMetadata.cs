using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Attributes
{
    public class SettingsMetadata : Attribute
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public object Icon { get; set; }

        public SettingsMetadata(string title, string description, object icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
        }

        public SettingsMetadata(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
