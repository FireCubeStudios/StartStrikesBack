using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StartStrikesBack.Core.Interfaces.Classes;
using StartStrikesBack.Core.Interfaces.Services;
using StartStrikesBack.Core.Messages;
using StartStrikesBack.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Classes
{
    public partial class Group : ObservableObject, IStartPanelItem
    {

        public Guid Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 0)
                    SetProperty(ref name, value);
            }
        }

        public ObservableCollection<IStartItem> Items = new ObservableCollection<IStartItem>();

        [JsonConstructor]
        public Group(string name, Guid id)
        {
            this.Name = name;
            this.Id = id;
        }

        public Group(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();
        }

        /* [OnSerializing]
         internal void OnSerializingMethod(StreamingContext context)
         {
             // Populate AppIds before serialization.
             AppIds = Apps?.Select(app => app.Id).ToList();
         }

         [OnDeserialized]
         internal void OnDeserializedMethod(StreamingContext context)
         {
             if (AppService is not null)
                 foreach (string Id in AppIds.ToList())
                     Items.Add(AppService.GetAppFromID(Id));
         }*/
    }
}
