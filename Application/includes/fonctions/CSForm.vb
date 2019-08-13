Module CSForm

#Region " ComboBox populate "

    ' Type de structure pour les objets nourrissant les combobox
    Public Class objComboItem
        Private _Id As String
        Private _Libelle As String
        Sub New(ByVal Id As String, ByVal Libelle As String)
            _Id = Id
            _Libelle = Libelle
        End Sub
        Public Property Id() As String
            Get
                Return _Id
            End Get
            Set(ByVal Value As String)
                _Id = Value
            End Set
        End Property
        Public Property Libelle() As String
            Get
                Return _Libelle
            End Get
            Set(ByVal Value As String)
                _Libelle = Value
            End Set
        End Property
        Overrides Function ToString() As String
            Return (_Libelle)
        End Function
    End Class

#End Region

#Region "List controls"

    Public Sub getListRadioButtons(ByVal controlObj As Control, ByRef listRadioButtons() As RadioButton)
        Dim i As Integer
        If listRadioButtons(listRadioButtons.Length - 1) Is Nothing Then
            i = listRadioButtons.Length - 1
        Else
            i = listRadioButtons.Length
        End If
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is RadioButton Then
                'MsgBox(Ctr.Name.ToString & " - " & listRadioButtons.Length & ":" & i)
                listRadioButtons(i) = Ctr
                i = i + 1
                ReDim Preserve listRadioButtons(i)
            Else
                getListRadioButtons(Ctr, listRadioButtons)
            End If
        Next
    End Sub

    Public Function getControlByName(ByVal controlName As String, ByVal controlObj As Control) As Control
        Dim tmpReturn As Control
        Dim tabControl As Control()
        tabControl = controlObj.Controls.Find(controlName, True) 'la recherche est Recursive
        tmpReturn = Nothing
        If tabControl.Length > 0 Then
            tmpReturn = tabControl(0)
        End If

        'For Each Ctr As Control In controlObj.Controls
        '    If Not Ctr Is Nothing Then
        '        If Not Ctr.Name Is Nothing Then
        '            If Ctr.Name = controlName Then
        '                Return Ctr
        '            Else
        '                If Ctr.Controls.Count > 0 Then
        '                    tmpReturn = getControlByName(controlName, Ctr)
        '                End If
        '                If Not tmpReturn Is Nothing Then
        '                    Return tmpReturn
        '                End If
        '            End If
        '        End If
        '    End If
        'Next
        Return tmpReturn
    End Function

    Public Function getControlByNameFromPanel(ByVal controlName As String, ByVal panel As Panel) As Control
        Dim tmpReturn As Control = Nothing
        For Each Obj As Object In panel.Controls
            If Not Obj Is Nothing Then
                If TypeOf Obj Is Panel Then
                    tmpReturn = getControlByNameFromPanel(controlName, Obj.Controls)
                Else
                    tmpReturn = getControlByName(controlName, Obj.Controls)
                End If
            End If
        Next
        Return tmpReturn
    End Function

    Public Sub disableAllRadioButtons(ByVal controlObj As Control)
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is RadioButton Then
                Ctr.Enabled = False
            Else
                disableAllRadioButtons(Ctr)
            End If
        Next
    End Sub
    Public Sub enableAllRadioButtons(ByVal controlObj As Control)
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is RadioButton Then
                Ctr.Enabled = True
            Else
                disableAllRadioButtons(Ctr)
            End If
        Next
    End Sub

    Public Sub disableAllCheckBox(ByVal controlObj As Control)
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is CheckBox Or TypeOf Ctr Is CRODIP_ControlLibrary.CtrlDiag2 Then
                Ctr.Enabled = False
            Else
                disableAllCheckBox(Ctr)
            End If
        Next
    End Sub
    Public Sub disableAllTextBox(ByVal controlObj As Control)
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is TextBox Then
                Ctr.Enabled = False
            Else
                disableAllTextBox(Ctr)
            End If
        Next
    End Sub
    Public Sub disableAllComboBox(ByVal controlObj As Control)
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is ComboBox Then
                Ctr.Enabled = False
            Else
                disableAllComboBox(Ctr)
            End If
        Next
    End Sub
    Public Sub enableAllCheckBox(ByVal controlObj As Control)
        For Each Ctr As Control In controlObj.Controls
            If TypeOf Ctr Is CheckBox Or TypeOf Ctr Is CRODIP_ControlLibrary.CtrlDiag2 Then
                Ctr.Enabled = True
            Else
                enableAllCheckBox(Ctr)
            End If
        Next
    End Sub

#End Region

#Region " Controls de saisie "

    Public Sub typeAllowed(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal typeAllow As String)

        Select Case typeAllow.ToUpper()

            Case "numerique".ToUpper()
                If Asc(e.KeyChar) < 32 Then
                    'ASCII < 32 = Tout ce qui est commandes
                    e.Handled = False
                ElseIf (Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Then
                    'ASCII compris entre 48 et 57 inclu représente les chiffres de 0 à 9.
                    e.Handled = False
                ElseIf (Asc(e.KeyChar) = 44 Or Asc(e.KeyChar) = 46) Then
                    'On autoriste la virgule et le point
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            Case "integer".ToUpper()
                If Asc(e.KeyChar) < 32 Then
                    'ASCII < 32 = Tout ce qui est commandes
                    e.Handled = False
                ElseIf (Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58) Then
                    'ASCII compris entre 48 et 57 inclu représente les chiffres de 0 à 9.
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            Case "Alphanumerique".ToUpper()
                e.Handled = True
                If Asc(e.KeyChar) < 32 Then
                    'ASCII < 32 = Tout ce qui est commandes
                    e.Handled = False
                End If
                If Asc(e.KeyChar) >= Asc("A") And Asc(e.KeyChar) <= Asc("Z") Then
                    e.Handled = False
                End If
                If Asc(e.KeyChar) >= Asc("a") And Asc(e.KeyChar) <= Asc("z") Then
                    e.Handled = False
                End If
                If Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9") Then
                    e.Handled = False
                End If
                If Asc(e.KeyChar) = Asc(" ") Or Asc(e.KeyChar) = Asc("_") Or Asc(e.KeyChar) = Asc("-") Then
                    e.Handled = False
                End If
        End Select

    End Sub

    Public Sub maxSize(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal sender As Object, ByVal myMaxSize As Integer)

        If Asc(e.KeyChar) < 32 Then
            ' On autorise les commandes
        Else
            If sender.text.length >= myMaxSize Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If

    End Sub

    ' Remplace le point par une virgule dans les champs numérique
    Public Sub forceDot(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal sender As Object)
        'si c'est une virgule et qu'il y en a déja une dans le textbox, ou qu'elle est tapée en premier caractère, on annule la saisie
        Dim str As String = ""
        If TypeOf (sender) Is TextBox Then
            str = CType(sender, TextBox).Text
        End If
        If TypeOf (sender) Is DataGridView Then
            str = CType(sender, DataGridView).CurrentCell.Value
        End If
        If (Asc(e.KeyChar) = 44 Or Asc(e.KeyChar) = 46) And (str.IndexOf(",") > 0 Or str = "") Then
            e.Handled = True
        Else
            ' Remplace la virgule par un point dans les champs numérique
            If Asc(e.KeyChar) = 46 Then
                sender.Text += Chr(44)
                sender.SelectionStart = sender.TextLength
                e.Handled = True
            End If
        End If
    End Sub
    ' Remplace la virgule par un point dans les champs numérique
    Public Sub forceComma(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal sender As Object)
        'si c'est une virgule et qu'il y en a déja une dans le textbox, ou qu'elle est tappé en premier caractère, on annule la saisie
        If (Asc(e.KeyChar) = 44 Or Asc(e.KeyChar) = 46) And (CType(sender, TextBox).Text.IndexOf(".") > 0 Or CType(sender, TextBox).Text = "") Then
            e.Handled = True
        Else
            ' Remplace la virgule par un point dans les champs numérique
            If Asc(e.KeyChar) = 44 Then
                sender.Text += Chr(46)
                sender.SelectionStart = sender.TextLength
                e.Handled = True
            End If
        End If
    End Sub

#End Region

#Region "listes"

    'A couple of overloads to allow for the hidden fields and a file name
    Public Function ListviewToCSV(ByVal oLV As ListView) As String
        'Dim sFile As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ListviewData.csv"
        Dim sFile As String = "\ListviewData.csv"
        Return ListviewToCSV(oLV, sFile)
    End Function

    Public Function ListviewToCSV(ByVal oLV As ListView, ByVal sFile As String) As String
        Return ListviewToCSV(oLV, sFile, False)
    End Function

    'The function that writes out the data to a CSV file
    Public Function ListviewToCSV(ByVal oLV As ListView, ByVal sFile As String, ByVal bIncludeHidden As Boolean) As String
        Try
            Dim i As Integer
            Dim oItem As ListViewItem
            Dim sData As String = ""
            Dim sLine As String
            Dim Q As String = Chr(34)
            Dim QC As String = Chr(34) + ","

            'Create the header using the column headers
            sLine = Q + "ID" + QC
            For i = 0 To oLV.Columns.Count - 1
                'test for the hidden flag
                If bIncludeHidden Or oLV.Columns(i).Width > 0 Then
                    'remove any spaces from the header data
                    sLine += Q + Replace(oLV.Columns(i).Text, " ", "") + QC
                End If
            Next
            'Drop the trailing comma
            sData += DropChar(sLine, 1) + vbNewLine

            For Each oItem In oLV.Items
                sLine = IIf(IsNumeric(oItem.Tag), oItem.Tag + ",", Q + oItem.Tag + QC)
                For i = 0 To oItem.SubItems.Count - 1
                    If bIncludeHidden Or oLV.Columns(i).Width > 0 Then
                        'wrap the nonnumeric fields in quotes
                        sLine += IIf(IsNumeric(oItem.SubItems(i).Text), oItem.SubItems(i).Text + ",", Q + oItem.SubItems(i).Text + QC)
                    End If
                Next
                sData += DropChar(sLine, 1) + vbNewLine
            Next

            'Delete any existing file of the same name
            Dim oFI As New IO.FileInfo(sFile)
            If oFI.Exists Then
                oFI.Delete()
            End If
            Dim oFS As New IO.FileStream(sFile, IO.FileMode.CreateNew, IO.FileAccess.Write)
            Dim oSW As New IO.StreamWriter(oFS)
            oSW.Write(sData)
            oSW.Flush()
            oSW.Close()
            oFS.Close()
            Return "Listview exported to: " + sFile
        Catch Exc As Exception
            Return Exc.Message
        End Try
    End Function

    'Oh and the DropChar thing
    Public Function DropChar(ByVal sText As String, Optional ByVal iCharToDrop As Integer = 1) As String
        Try
            Dim sTemp As String
            sTemp = Trim(LTrim(sText))
            'sTemp = Str.Left(sTemp, sTemp.Length - iCharToDrop)
            Return sTemp
        Catch Exc As Exception
            Throw Exc
        End Try
    End Function

#End Region

End Module
