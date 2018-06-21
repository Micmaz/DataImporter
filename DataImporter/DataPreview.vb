Public Class DataPreview
	Public dt As DataTable

	Private Sub DataPreview_Load(sender As Object, e As EventArgs) Handles Me.Load
		If dt IsNot Nothing Then
			DataGridView1.DataSource = dt
			DataGridView1.Columns("Row Count").DefaultCellStyle.ForeColor = Color.Gray
			DataGridView1.Columns("Row State").DefaultCellStyle.ForeColor = Color.Gray
			lblRowCount.Text = "Rows in batch: " & dt.Rows.Count
		End If

	End Sub

	Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

	End Sub
End Class