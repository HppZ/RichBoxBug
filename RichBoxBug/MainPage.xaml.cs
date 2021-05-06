using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RichBoxBug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var range = RichEditBox.Document.GetRange(0, 0);
                var rss = RandomAccessStreamReference.CreateFromUri(new Uri("http://i0.hdslb.com/bfs/emote/89516218158dbea18ab78e8873060bf95d33bbbe.png"));
                var stream = await rss.OpenReadAsync();
                range.InsertImage(24, 24, 0, VerticalCharacterAlignment.Baseline, "emojiText", stream);
                range.Expand(TextRangeUnit.Character);
            }
            catch (Exception ex)
            {
                // sometimes RandomAccessStreamReference.CreateFromUri fails, I don't know why.
            }

        }
    }
}
