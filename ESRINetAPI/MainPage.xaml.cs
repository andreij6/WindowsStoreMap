using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ESRINetAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            var sel = combo.SelectedItem as ComboBoxItem;
            if (sel.Tag == null) { return; }

            // Find and remove the current basemap layer from the map
            if (MyMap == null) { return; }
            var oldBasemap = MyMap.Layers["BaseMap"];
            MyMap.Layers.Remove(oldBasemap);

            // Create a new basemap layer
            var newBasemap = new Esri.ArcGISRuntime.Layers.ArcGISTiledMapServiceLayer();

            // Set the ServiceUri with the url defined for the ComboBoxItem's Tag
            newBasemap.ServiceUri = sel.Tag.ToString();

            // Give the layer the same ID so it can still be found with the code above
            newBasemap.ID = "BaseMap";

            // Insert the new basemap layer as the first (bottom) layer in the map
            MyMap.Layers.Insert(0, newBasemap);
        }

        
    }
}
