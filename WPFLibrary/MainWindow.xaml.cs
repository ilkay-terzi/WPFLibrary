using System.Windows;

namespace WPFLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ikkoClass ikkoClass = new ikkoClass();
        public MainWindow()
        {
            InitializeComponent();
            ikkoClass = new ikkoClass();
            KeywordClass k = ikkoClass.AddNewKeyword("Select");
            k.Pattern = "Select * from [tablename] into table @data([inlineitab]) where [where].";
        }

        private void btn_Read_Click(object sender, RoutedEventArgs e)
        {
            ikkoClass.ReadFile();
        }

        private void btn_Write_Click(object sender, RoutedEventArgs e)
        {
            ikkoClass.WriteToFile();
        }
    }
}
