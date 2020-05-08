using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    [Preserve(AllMembers = true)]
    public class GalleryModel : INotifyPropertyChanged
    {
        #region Fields

        private ImageSource image;

        #endregion

        #region Properties

        public ImageSource Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                this.RaisePropertyChanged("Image");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
