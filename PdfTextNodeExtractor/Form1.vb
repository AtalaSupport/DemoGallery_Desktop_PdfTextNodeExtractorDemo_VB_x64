Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports Atalasoft.Annotate.UI
Imports Atalasoft.Annotate.UI.Importers

Namespace PdfTextNoteExtractor
	''' <summary>
	''' Main Window
	''' </summary>
	Public Class Form1 : Inherits System.Windows.Forms.Form
		Private _ignoreColorChecks As Boolean
		Private _notes As ArrayList

		Private mainMenu1 As System.Windows.Forms.MainMenu
		Private menuFile As System.Windows.Forms.MenuItem
		Private WithEvents menuOpen As System.Windows.Forms.MenuItem
		Private menuItem3 As System.Windows.Forms.MenuItem
		Private WithEvents menuExit As System.Windows.Forms.MenuItem
		Private menuHelp As System.Windows.Forms.MenuItem
		Private WithEvents menuAbout As System.Windows.Forms.MenuItem
		Private lblPdfFile As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private WithEvents chkAllAuthors As System.Windows.Forms.CheckBox
		Private WithEvents listAuthors As System.Windows.Forms.ListView
		Private WithEvents btnGenerateReport As System.Windows.Forms.Button
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()
			EnableControls()
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.mainMenu1 = New System.Windows.Forms.MainMenu()
			Me.menuFile = New System.Windows.Forms.MenuItem()
			Me.menuOpen = New System.Windows.Forms.MenuItem()
			Me.menuItem3 = New System.Windows.Forms.MenuItem()
			Me.menuExit = New System.Windows.Forms.MenuItem()
			Me.menuHelp = New System.Windows.Forms.MenuItem()
			Me.menuAbout = New System.Windows.Forms.MenuItem()
			Me.lblPdfFile = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.btnGenerateReport = New System.Windows.Forms.Button()
			Me.chkAllAuthors = New System.Windows.Forms.CheckBox()
			Me.listAuthors = New System.Windows.Forms.ListView()
			Me.SuspendLayout()
			' 
			' mainMenu1
			' 
			Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { Me.menuFile, Me.menuHelp})
			' 
			' menuFile
			' 
			Me.menuFile.Index = 0
			Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { Me.menuOpen, Me.menuItem3, Me.menuExit})
			Me.menuFile.Text = "&File"
			' 
			' menuOpen
			' 
			Me.menuOpen.Index = 0
			Me.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
			Me.menuOpen.Text = "&Open"
'			Me.menuOpen.Click += New System.EventHandler(Me.menuOpen_Click);
			' 
			' menuItem3
			' 
			Me.menuItem3.Index = 1
			Me.menuItem3.Text = "-"
			' 
			' menuExit
			' 
			Me.menuExit.Index = 2
			Me.menuExit.Text = "E&xit"
'			Me.menuExit.Click += New System.EventHandler(Me.menuExit_Click);
			' 
			' menuHelp
			' 
			Me.menuHelp.Index = 1
			Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { Me.menuAbout})
			Me.menuHelp.Text = "&Help"
			' 
			' menuAbout
			' 
			Me.menuAbout.Index = 0
			Me.menuAbout.Text = "&About..."
'			Me.menuAbout.Click += New System.EventHandler(Me.menuAbout_Click);
			' 
			' lblPdfFile
			' 
			Me.lblPdfFile.AutoSize = True
			Me.lblPdfFile.Location = New System.Drawing.Point(20, 18)
			Me.lblPdfFile.Name = "lblPdfFile"
			Me.lblPdfFile.Size = New System.Drawing.Size(124, 16)
			Me.lblPdfFile.TabIndex = 0
			Me.lblPdfFile.Text = "PDF Document:  [None]"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(20, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 16)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Authors to extract:"
			' 
			' btnGenerateReport
			' 
			Me.btnGenerateReport.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnGenerateReport.Location = New System.Drawing.Point(84, 175)
			Me.btnGenerateReport.Name = "btnGenerateReport"
			Me.btnGenerateReport.Size = New System.Drawing.Size(97, 25)
			Me.btnGenerateReport.TabIndex = 3
			Me.btnGenerateReport.Text = "Generate Report"
'			Me.btnGenerateReport.Click += New System.EventHandler(Me.btnGenerateReport_Click);
			' 
			' chkAllAuthors
			' 
			Me.chkAllAuthors.Checked = True
			Me.chkAllAuthors.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkAllAuthors.Location = New System.Drawing.Point(25, 63)
			Me.chkAllAuthors.Name = "chkAllAuthors"
			Me.chkAllAuthors.Size = New System.Drawing.Size(42, 15)
			Me.chkAllAuthors.TabIndex = 4
			Me.chkAllAuthors.Text = "All"
'			Me.chkAllAuthors.CheckedChanged += New System.EventHandler(Me.chkAllAuthors_CheckedChanged);
			' 
			' listAuthors
			' 
			Me.listAuthors.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.listAuthors.CheckBoxes = True
			Me.listAuthors.Location = New System.Drawing.Point(25, 81)
			Me.listAuthors.Name = "listAuthors"
			Me.listAuthors.Size = New System.Drawing.Size(216, 79)
			Me.listAuthors.Sorting = System.Windows.Forms.SortOrder.Ascending
			Me.listAuthors.TabIndex = 5
			Me.listAuthors.View = System.Windows.Forms.View.List
'			Me.listAuthors.ItemCheck += New System.Windows.Forms.ItemCheckEventHandler(Me.listAuthors_ItemCheck);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(269, 215)
			Me.Controls.Add(Me.listAuthors)
			Me.Controls.Add(Me.chkAllAuthors)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.lblPdfFile)
			Me.Controls.Add(Me.btnGenerateReport)
			Me.Menu = Me.mainMenu1
			Me.MinimumSize = New System.Drawing.Size(177, 170)
			Me.Name = "Form1"
			Me.Text = "PDF Text Note Extractor"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub menuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAbout.Click
			Dim frm As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About...", "PDF Text Note Extractor")
			frm.Description = "This project demonstrates how to extract PDF text annotations and use them to generate an edit history of the PDF document."
			frm.ShowDialog(Me)
			frm.Dispose()
		End Sub

		Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExit.Click
			Me.Close()
		End Sub

		Private Sub menuOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuOpen.Click
			Dim dlg As OpenFileDialog = New OpenFileDialog()
			dlg.Filter = "PDF Documents|*.pdf"
			If dlg.ShowDialog(Me) = DialogResult.OK Then
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.lblPdfFile.Text = "PDF Document:  " & System.IO.Path.GetFileName(dlg.FileName)

					ExtractTextNodes(dlg.FileName)
				Finally
					Me.Cursor = Cursors.Default
				End Try
			End If
			dlg.Dispose()

			EnableControls()
		End Sub

		Private Sub listAuthors_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles listAuthors.ItemCheck
			If _ignoreColorChecks Then
			Return
			End If
			Me.chkAllAuthors.Checked = False
		End Sub

		Private Sub chkAllAuthors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllAuthors.CheckedChanged
			If Me.chkAllAuthors.Checked Then
				SelectAllAuthors()
			End If
		End Sub

		Private Sub SelectAllAuthors()
			_ignoreColorChecks = True

			Dim count As Integer = Me.listAuthors.Items.Count
			Dim i As Integer = 0
'ORIGINAL LINE: for (int i = 0; i < count; i += 1)
'INSTANT VB NOTE: This 'for' loop was translated to a VB 'Do While' loop:
			Do While i < count
				Me.listAuthors.Items(i).Checked = True
				i += 1
			Loop

			_ignoreColorChecks = False
		End Sub

		Private Sub btnGenerateReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateReport.Click
			If _notes Is Nothing OrElse _notes.Count = 0 Then
				MessageBox.Show("Please use the 'File -> Open' menu item to load a PDF document with text annotations.", "Nothing To Generate", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Return
			End If

			If Me.listAuthors.CheckedItems.Count = 0 Then
				MessageBox.Show("You must have at least one item checked in the list.", "Nothing To Generate", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Return
			End If

			Dim dlg As SaveFileDialog = New SaveFileDialog()
			dlg.Filter = "HTML Files (*.html)|*.html"
			If dlg.ShowDialog(Me) = DialogResult.OK Then
				GenerateReport(dlg.FileName)
			End If
			dlg.Dispose()
		End Sub

		''' <summary>
		''' This method extracts the text annotations from the PDF file and
		''' fills an array with TextNote information that will be used to
		''' generate the HTML report.
		''' </summary>
		''' <param name="fileName">The filename of the PDF.</param>
		Private Sub ExtractTextNodes(ByVal fileName As String)
			If (Not File.Exists(fileName)) Then
				MessageBox.Show("The input file could not be found.", "File Not Found")
				Return
			End If

			_notes = New ArrayList()
			Me.listAuthors.Items.Clear()

			Dim layers As LayerCollection = Nothing
'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
'			using (FileStream fs = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
			Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
			Try
				Try
                    Dim importer As PdfAnnotationImporter = New PdfAnnotationImporter(fs)
					layers = importer.Import()
				Catch ex As Exception
					MessageBox.Show(ex.GetType().Name & ":" & Constants.vbCrLf & ex.Message, "Annotation Import Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				End Try
			Finally
				Dim disp As IDisposable = fs
				disp.Dispose()
			End Try
'INSTANT VB NOTE: End of the original C# 'using' block

			If layers Is Nothing OrElse layers.Count = 0 Then
				MessageBox.Show("There are no pages in this PDF file.", "No Pages", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Return
			End If

			Dim layerCount As Integer = layers.Count
			Dim lc As Integer = 0
'ORIGINAL LINE: for (int lc = 0; lc < layerCount; lc += 1)
'INSTANT VB NOTE: This 'for' loop was translated to a VB 'Do While' loop:
			Do While lc < layerCount
				Dim layer As LayerAnnotation = layers(lc)
				For Each ann As AnnotationUI In layer.Items
					Dim txt As TextAnnotation = CType(IIf(TypeOf ann Is TextAnnotation, ann, Nothing), TextAnnotation)
					If txt Is Nothing Then
					GoTo Continue1
                    End If

                    ' FB 12753 - Ensure that a TextAnnotation with no fill brush doesn't cause a null reference exception
                    If txt.Fill Is Nothing Then
                        txt.Fill = New Atalasoft.Annotate.AnnotationBrush(Color.White)
                    End If

					_notes.Add(New TextNote(txt.UserName, txt.Text, txt.Fill.Color, txt.CreationTime, lc + 1))

					Dim found As Boolean = False
					For Each li As ListViewItem In Me.listAuthors.Items
						If li.Text = txt.UserName Then
							found = True
							Exit For
						End If
					Next li

					If (Not found) Then
						Dim item As ListViewItem = New ListViewItem(txt.UserName)
						item.BackColor = txt.Fill.Color
						Me.listAuthors.Items.Add(item)
					End If
					Continue1:
				Next ann
				lc += 1
			Loop

			If Me.chkAllAuthors.Checked Then
				SelectAllAuthors()
			End If

			_notes.Sort(New TextNoteComparer())

			If _notes.Count = 0 Then
				MessageBox.Show("There were no text annotations found in the PDF.", "No Notes", MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Sub

		''' <summary>
		''' Creates an HTML page with the annotation information.
		''' </summary>
		''' <param name="fileName">The filename of the HTML file to create.</param>
		Private Sub GenerateReport(ByVal fileName As String)
			Dim generator As TextNoteReportGenerator = New TextNoteReportGenerator(fileName)
			Try
				For Each note As TextNote In _notes
					For Each item As ListViewItem In Me.listAuthors.CheckedItems
						If item.Text = note.Author Then
							generator.WriteTextNote(note)
						End If
					Next item
				Next note
			Catch ex As Exception
				MessageBox.Show(ex.GetType().Name & ":" & Constants.vbCrLf & ex.Message, "Generate Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			Finally
				generator.Close()
			End Try

			System.Diagnostics.Process.Start(fileName)
		End Sub

		Private Sub EnableControls()
			Dim enabled As Boolean = (Not _notes Is Nothing AndAlso _notes.Count > 0)
			Me.btnGenerateReport.Enabled = enabled
			Me.listAuthors.Enabled = enabled
			Me.chkAllAuthors.Enabled = enabled
			Me.label1.Enabled = enabled
		End Sub

	End Class
End Namespace
