Namespace Converter
	Partial Class TableSelectionDialog
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.grdTables = New System.Windows.Forms.DataGridView()
			Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.colTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnSelectAll = New System.Windows.Forms.Button()
			Me.btnDeselectAll = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOK = New System.Windows.Forms.Button()
            '(CType((Me.grdTables), System.ComponentModel.ISupportInitialize)).BeginInit()
            Me.SuspendLayout()
			' 
			' grdTables
			' 
			Me.grdTables.AllowUserToAddRows = False
			Me.grdTables.AllowUserToDeleteRows = False
			Me.grdTables.AllowUserToResizeColumns = False
			Me.grdTables.AllowUserToResizeRows = False
			Me.grdTables.Anchor = (CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
			Me.grdTables.BackgroundColor = System.Drawing.Color.White
			Me.grdTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdTables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colTableName})
			Me.grdTables.Location = New System.Drawing.Point(12, 12)
			Me.grdTables.Name = "grdTables"
			Me.grdTables.RowHeadersVisible = False
			Me.grdTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
			Me.grdTables.Size = New System.Drawing.Size(407, 328)
			Me.grdTables.TabIndex = 0
			' 
			' colInclude
			' 
			Me.colInclude.HeaderText = ""
			Me.colInclude.Name = "colInclude"
			Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
			Me.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.colInclude.Width = 30
			' 
			' colTableName
			' 
			Me.colTableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
			Me.colTableName.HeaderText = "Table Name"
			Me.colTableName.Name = "colTableName"
			Me.colTableName.[ReadOnly] = True
			Me.colTableName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
			' 
			' btnSelectAll
			' 
			Me.btnSelectAll.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles))
			Me.btnSelectAll.Location = New System.Drawing.Point(12, 346)
			Me.btnSelectAll.Name = "btnSelectAll"
			Me.btnSelectAll.Size = New System.Drawing.Size(75, 23)
			Me.btnSelectAll.TabIndex = 1
			Me.btnSelectAll.Text = "Select All"
			Me.btnSelectAll.UseVisualStyleBackColor = True
			AddHandler Me.btnSelectAll.Click, New System.EventHandler(AddressOf Me.btnSelectAll_Click)
			' 
			' btnDeselectAll
			' 
			Me.btnDeselectAll.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles))
			Me.btnDeselectAll.Location = New System.Drawing.Point(93, 346)
			Me.btnDeselectAll.Name = "btnDeselectAll"
			Me.btnDeselectAll.Size = New System.Drawing.Size(89, 23)
			Me.btnDeselectAll.TabIndex = 2
			Me.btnDeselectAll.Text = "Deselect All"
			Me.btnDeselectAll.UseVisualStyleBackColor = True
			AddHandler Me.btnDeselectAll.Click, New System.EventHandler(AddressOf Me.btnDeselectAll_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(343, 346)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(76, 23)
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
			AddHandler Me.btnCancel.Click, New System.EventHandler(AddressOf Me.btnCancel_Click)
			' 
			' btnOK
			' 
			Me.btnOK.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles))
			Me.btnOK.Location = New System.Drawing.Point(261, 346)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(76, 23)
			Me.btnOK.TabIndex = 4
			Me.btnOK.Text = "OK"
			Me.btnOK.UseVisualStyleBackColor = True
			AddHandler Me.btnOK.Click, New System.EventHandler(AddressOf Me.btnOK_Click)
			' 
			' TableSelectionDialog
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(433, 377)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnDeselectAll)
			Me.Controls.Add(Me.btnSelectAll)
			Me.Controls.Add(Me.grdTables)
			Me.Name = "TableSelectionDialog"
			Me.ShowIcon = False
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            'Me.Text = "Select Tables To Convert"
            '(CType((Me.grdTables), System.ComponentModel.ISupportInitialize)).EndInit()
            Me.ResumeLayout(False)

		End Sub

		#End Region

		Private grdTables As System.Windows.Forms.DataGridView
		Private colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
		Private colTableName As System.Windows.Forms.DataGridViewTextBoxColumn
		Private btnSelectAll As System.Windows.Forms.Button
		Private btnDeselectAll As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private btnOK As System.Windows.Forms.Button
	End Class
End Namespace