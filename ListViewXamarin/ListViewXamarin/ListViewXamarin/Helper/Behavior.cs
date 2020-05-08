using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<SfListView>
    {
        SfListView listView;
        protected override void OnAttachedTo(SfListView bindable)
        {
            listView = bindable;
            listView.SizeChanged += ListView_SizeChanged;
            base.OnAttachedTo(bindable);
        }

        private void ListView_SizeChanged(object sender, EventArgs e)
        {
            GridLayout gridLayout = new GridLayout();
            gridLayout.SpanCount = (int)listView.Width / (int)listView.ItemSize;
            listView.LayoutManager = gridLayout; 
        }
        
        protected override void OnDetachingFrom(SfListView bindable)
        {
            listView.SizeChanged -= ListView_SizeChanged;
            listView = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
