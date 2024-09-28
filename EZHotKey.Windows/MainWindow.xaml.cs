using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Resources;
using Windows.System;
using EZHotKey.Core;
using EZHotKey.Core.Resources;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace EZHotKey.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        //private readonly string resxFile = @"..\..\..\..\..\..\EZHotKey.Core\Resources\KeyNames.resx";
        public MainWindow()
        {
            this.InitializeComponent();

        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }

        private void UIElement_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            //int vkey = e.Key
            string key = TryGetTranslate(e) == null ? e.Key.ToString() : TryGetTranslate(e);
            TextBlockItem.Text = $"Key: {key}";
            TextBlockItemKeyCode.Text = $"KeyCode: {(int)e.Key}";
            TextBlockItemKeyByteCode.Text = $"Key ByteCode: 0x{(int)e.Key:X2}";
            //throw new NotImplementedException();
        }

        private static string TryGetTranslate(KeyRoutedEventArgs key)
        {
            string response = string.Empty;
            try
            {
                response = KeyNames.ResourceManager.GetString(key.Key.ToString());
            }
            catch (InvalidOperationException e)
            {
                // TODO: Fill this
            }

            return response;
        }
    }
}
