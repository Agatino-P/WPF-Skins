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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlendTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public bool IsLight
        {
            get { return (bool)GetValue(IsLightProperty); }
            set { SetValue(IsLightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLightProperty =
            DependencyProperty.Register("IsLight", typeof(bool), typeof(MainWindow), new PropertyMetadata(true));


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            IsLight = !IsLight;
            loadSkin();
        }

        private void loadSkin()
        {
            string skin = IsLight ? "LightSkin.xaml": "DarkSkin.xaml";
            string skinFile = "Skins/" + skin;
            ResourceDictionary resDict = Application.Current.Resources;
            resDict.MergedDictionaries.RemoveAt(0);
            resDict.MergedDictionaries.Insert(0, new ResourceDictionary { Source = new Uri(skinFile, UriKind.Relative) });
        }
    }
}
