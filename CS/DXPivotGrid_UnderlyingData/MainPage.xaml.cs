using System.Windows.Controls;
using System.Windows;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_UnderlyingData {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_UnderlyingData.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;
        }
        private void pivotGridControl1_CellDoubleClick(object sender, PivotCellEventArgs e) {
            GridControl grid = new GridControl();
            ThemeManager.SetThemeName(grid, ThemeManager.ApplicationThemeName);
            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.VerticalAlignment = VerticalAlignment.Stretch;
            PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
            grid.ItemsSource = ds;
            grid.PopulateColumns();
            FloatingWindowContainer.ShowDialogContent(grid, this, new Size(520, 300),
                new FloatingContainerParameters() {
                    AllowSizing = true,
                    CloseOnEscape = true,
                    Title = "Drill Down Form",
                    ClosedDelegate = null
                });
        }
    }
}