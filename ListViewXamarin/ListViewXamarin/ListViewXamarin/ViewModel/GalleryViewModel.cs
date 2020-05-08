
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    [Preserve(AllMembers = true)]
    public class GalleryViewModel
    {
        #region Properties

        public ObservableCollection<GalleryModel> Items { get; set; }

        #endregion

        #region Constructor
        public GalleryViewModel()
        {
            GenerateItemsSource();
        }

        #endregion

        #region Methods

        private void GenerateItemsSource()
        {
            Items = new ObservableCollection<GalleryModel>();
            for (int i = 0; i < 29; i++)
            {
                GalleryModel gallery = new GalleryModel();
                gallery.Image = ImageSource.FromResource("ListViewXamarin.Images.Image"+i+".png", typeof(MainPage));
                Items.Add(gallery);
            }
        }
        #endregion

    }
}
