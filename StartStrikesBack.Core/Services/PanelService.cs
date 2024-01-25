using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StartStrikesBack.Core.Classes;
using StartStrikesBack.Core.Files;
using StartStrikesBack.Core.Interfaces.Classes;
using StartStrikesBack.Core.Interfaces.Services;
using StartStrikesBack.Core.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StartStrikesBack.Core.Services
{
    public partial class PanelService : ObservableObject, IPanelService
    {
        [ObservableProperty]
        private ObservableCollection<IStartPanelItem> panels = new();

        private ISerialiserService Serialiser;
        private ILocalFileService LocalFileService;
        private IFile PanelsFile;

        public PanelService(ISerialiserService serialiser, ILocalFolderService folderService, ILocalFileService fileService)
        {
            Serialiser = serialiser;
            LocalFileService = fileService;
            Initialize();
            WeakReferenceMessenger.Default.Register<PanelSaveRequestMessage>(this, OnPanelSaveRequestMessageReceived);
        }

        private async void Initialize()
        {
            try
            {
                PanelsFile = await LocalFileService.GetLocalFileAsync("Panels.json");
                using (var stream = await PanelsFile.OpenFileStreamAsync())
                using (var streamReader = new StreamReader(stream))
                {
                    var json = await streamReader.ReadToEndAsync();
                    Panels = await Serialiser.DeserialiseAsync<ObservableCollection<IStartPanelItem>>(json) ?? new ObservableCollection<IStartPanelItem>();
                }
            }
            catch
            {
                PanelsFile = await LocalFileService.CreateLocalFileAsync("Panels.json");
            }
        }

        private async void OnPanelSaveRequestMessageReceived(object recipient, PanelSaveRequestMessage message)
            => await SaveAsync();

        public ObservableCollection<T> GetItems<T>() where T : IStartPanelItem
        {
            ObservableCollection<T> items = new ObservableCollection<T>();
            if(Panels.Count > 0)
                foreach (IStartPanelItem panel in Panels)
                    if (panel is T panelOfType)
                        items.Add(panelOfType);

            return items;
        }

        public async Task SaveAsync()
        {
            string json = await Serialiser.SerialiseAsync(Panels);
            if (json == "[]")
                json = "";
            // Get a stream to the Panels.json file
            using (var stream = await PanelsFile.OpenFileStreamAsync())
            using (var streamWriter = new StreamWriter(stream))
            {
                // Write the JSON to the Panels.json file
                await streamWriter.WriteAsync(json);
            }
        }
    }
}
