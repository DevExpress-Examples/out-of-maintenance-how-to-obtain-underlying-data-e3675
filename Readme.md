<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DXPivotGrid_UnderlyingData/MainPage.xaml) (VB: [MainPage.xaml.vb](./VB/DXPivotGrid_UnderlyingData/MainPage.xaml.vb))
* [MainPage.xaml.cs](./CS/DXPivotGrid_UnderlyingData/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/DXPivotGrid_UnderlyingData/MainPage.xaml.vb))
<!-- default file list end -->
# How to: Obtain Underlying Data


<p>The DXPivotGrid includes the drill-down capability, which enables you to retrieve a list of records that were used to calculate a particular summary. <br />
To obtain drill-down data, use the PivotGridControl's CreateDrillDownDataSource method. Its parameters completely identify a summary cell.<br />
In this example, an end-user can view records from the control's underlying data source, associated with a summary cell, by double-clicking on it. The obtained data is displayed by the DXGrid within a popup window.</p><br />


<br/>


