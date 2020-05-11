# How to customize the layout in Xamarin.Forms ListView (SflistView)

You can customize the [GridLayout](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.GridLayout.html?)’s [SpanCount](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.GridLayout~SpanCount.html?) based on [SfListView](https://help.syncfusion.com/xamarin/listview/overview?) ItemSize using [SizeChanged](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.visualelement.sizechanged?view=xamarin-forms) event in Xamarin.Forms.

You can also refer the following items.

https://www.syncfusion.com/kb/11501/how-to-customize-the-layout-in-xamarin-forms-listview-sflistview

**XAML**

Defined **SfListView** and added [Behavior](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/creating) to it.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:sync="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage" Padding="{OnPlatform iOS='0,40,0,0'}">
 
    <ContentPage.BindingContext>
        <local:GalleryViewModel/>
    </ContentPage.BindingContext>
 
    <ContentPage.Content>
        <sync:SfListView x:Name="listView" ItemsSource="{Binding Items}" ItemSpacing="1" SelectionMode="None" BackgroundColor="#F0F0F0" ItemSize="100">
                <sync:SfListView.Behaviors>
                    <local:Behavior/>
                </sync:SfListView.Behaviors>
                <sync:SfListView.ItemTemplate>
                    <DataTemplate x:Name="ItemTemplate">
                    <Frame OutlineColor="#b3b3b3" Padding="2" HeightRequest="100" WidthRequest="100">
                        <Image Source="{Binding Image}" HeightRequest="100" WidthRequest="100" Aspect="AspectFit"/>
                    </Frame>
                    </DataTemplate>
                </sync:SfListView.ItemTemplate>
            </sync:SfListView>
    </ContentPage.Content>
</ContentPage>
```
**C#**

Customizing GridLayout **SpanCount** based on ListView **ItemSize**.
```
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
```
**Output**

![LandscapeListView](https://github.com/SyncfusionExamples/customize-the-layout-in-xamarin/blob/master/ScreenShots/LandscapeListView.png)

![PortraitListView](https://github.com/SyncfusionExamples/customize-the-layout-in-xamarin/blob/master/ScreenShots/PortraitListView.png)
