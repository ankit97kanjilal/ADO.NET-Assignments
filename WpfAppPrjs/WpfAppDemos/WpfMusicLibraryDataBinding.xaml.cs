using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppDemos
{
    /// <summary>
    /// Interaction logic for WpfMusicLibraryDataBinding.xaml
    /// </summary>
    public partial class WpfMusicLibraryDataBinding : Window
    {
        //List<MusicEntity> lstMusics = null;
        public WpfMusicLibraryDataBinding()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddAlbum_Click(object sender, RoutedEventArgs e)
        {
            MusicEntity m = new MusicEntity();
            m.AlbumName = txtAlbumName.Text;
            m.NoOfTracks = int.Parse(txtNoOfTracks.Text);
            m.Price = int.Parse(txtPrice.Text);            
            lstAlbums.Items.Add(m);
        }

        private void lstAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MusicEntity music = (MusicEntity)lstAlbums.SelectedItems[0];
            txt_AlbumName.Text = music.AlbumName;
            txt_NoOfTracks.Text = music.NoOfTracks.ToString();
            txt_Price.Text = music.Price.ToString();
        }
    }
}
