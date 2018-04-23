Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports System.Windows
Imports System.IO
Imports System.Xml.Serialization
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_UnderlyingData
	Partial Public Class MainPage
		Inherits UserControl
        Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
            Dim assembly As System.Reflection.Assembly = _
                System.Reflection.Assembly.GetExecutingAssembly()
            Dim stream As Stream = assembly.GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource
		End Sub
        Private Sub pivotGridControl1_CellDoubleClick(ByVal sender As Object,
                                                      ByVal e As PivotCellEventArgs)
            Dim grid As New GridControl()
            ThemeManager.SetThemeName(grid, ThemeManager.ApplicationThemeName)
            grid.HorizontalAlignment = HorizontalAlignment.Stretch
            grid.VerticalAlignment = VerticalAlignment.Stretch
            Dim ds As PivotDrillDownDataSource = e.CreateDrillDownDataSource()
            grid.ItemsSource = ds
            grid.PopulateColumns()
            FloatingWindowContainer.ShowDialogContent(grid, Me, New Size(520, 300),
                                                      New FloatingContainerParameters() With {
                                                          .AllowSizing = True,
                                                          .CloseOnEscape = True,
                                                          .Title = "Drill Down Form",
                                                          .ClosedDelegate = Nothing
                                                      })
        End Sub
	End Class
End Namespace