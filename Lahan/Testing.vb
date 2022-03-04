Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Public Class Testing
    Dim opf As New OpenFileDialog
    Dim spf As New SaveFileDialog
    Dim kecamatan As String
    Dim b2 As Bitmap
    Dim b3 As Bitmap
    Dim b4 As Bitmap
    Dim b5 As Bitmap
    Dim b6 As Bitmap
    Dim b7 As Bitmap
    Dim tanggal As Date
    Dim path_b2, path_b3, path_b4, path_b5, path_b6, path_b7 As String
    Dim Value As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles b2Btn.Click
        opf.Filter = "Choose Image(*.tif;)|*.tif;"
        If opf.ShowDialog = DialogResult.OK Then
            b2 = CType(Image.FromFile(opf.FileName), Bitmap)
            band2.Image = b2
            band2.SizeMode = PictureBoxSizeMode.Zoom
            band2.ImageLocation = opf.FileName
            path_b2 = band2.ImageLocation
            TabControl1.SelectedIndex = 0
        End If
    End Sub

    Private Sub HomeBtn_Click(sender As Object, e As EventArgs) Handles HomeBtn.Click
        Home.Show()
        Me.Hide()

    End Sub

    Private Sub HslKlsBtn_Click(sender As Object, e As EventArgs) Handles HslKlsBtn.Click
        Hasil.Show()
        Me.Hide()

    End Sub
    Private Sub b3Btn_Click(sender As Object, e As EventArgs) Handles b3Btn.Click
        opf.Filter = "Choose Image(*.tif;)|*.tif;"
        If opf.ShowDialog = DialogResult.OK Then
            b3 = CType(Image.FromFile(opf.FileName), Bitmap)
            band3.Image = b3
            band3.SizeMode = PictureBoxSizeMode.Zoom
            band3.ImageLocation = opf.FileName
            path_b3 = band3.ImageLocation
            TabControl1.SelectedIndex = 1
        End If
    End Sub
    Private Sub b4Btn_Click(sender As Object, e As EventArgs) Handles b4Btn.Click
        opf.Filter = "Choose Image(*.tif;)|*.tif;"
        If opf.ShowDialog = DialogResult.OK Then
            b4 = CType(Image.FromFile(opf.FileName), Bitmap)
            band4.Image = b4
            band4.SizeMode = PictureBoxSizeMode.Zoom
            band4.ImageLocation = opf.FileName
            path_b4 = band4.ImageLocation
            TabControl1.SelectedIndex = 2
        End If
    End Sub

    Private Sub b5Btn_Click(sender As Object, e As EventArgs) Handles b5Btn.Click
        opf.Filter = "Choose Image(*.tif;)|*.tif;"
        If opf.ShowDialog = DialogResult.OK Then
            b5 = CType(Image.FromFile(opf.FileName), Bitmap)
            band5.Image = b5
            band5.SizeMode = PictureBoxSizeMode.Zoom
            band5.ImageLocation = opf.FileName
            path_b5 = band5.ImageLocation
            TabControl1.SelectedIndex = 3
        End If
    End Sub

    Private Sub b6Btn_Click(sender As Object, e As EventArgs) Handles b6Btn.Click
        opf.Filter = "Choose Image(*.tif;)|*.tif;"
        If opf.ShowDialog = DialogResult.OK Then
            b6 = CType(Image.FromFile(opf.FileName), Bitmap)
            band6.Image = b6
            band6.SizeMode = PictureBoxSizeMode.Zoom
            band6.ImageLocation = opf.FileName
            path_b6 = band6.ImageLocation
            TabControl1.SelectedIndex = 4
        End If
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim exist As Integer

        If path_b2 = "" Then
            MsgBox("Citra Band 2 belum diinput", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        ElseIf path_b3 = "" Then
            MsgBox("Citra Band 3 belum diinput", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        ElseIf path_b4 = "" Then
            MsgBox("Citra Band 4 belum diinput", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        ElseIf path_b5 = "" Then
            MsgBox("Citra Band 5 belum diinput", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        ElseIf path_b6 = "" Then
            MsgBox("Citra Band 6 belum diinput", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        ElseIf path_b7 = "" Then
            MsgBox("Citra Band 7 belum diinput", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        ElseIf KecamatanCB.SelectedItem = "" Then
            MsgBox("Kecamatan belum dipilih", MsgBoxStyle.Exclamation, "Input Data")
            Exit Sub
        End If

        Dim h2, h3, h4, h5, h6, h7 As Integer
        Dim w2, w3, w4, w5, w6, w7 As Integer

        h2 = band2.Image.Height
        h3 = band3.Image.Height
        h4 = band4.Image.Height
        h5 = band5.Image.Height
        h6 = band6.Image.Height
        h7 = band7.Image.Height

        w2 = band2.Image.Width
        w3 = band3.Image.Width
        w4 = band4.Image.Width
        w5 = band5.Image.Width
        w6 = band6.Image.Width
        w7 = band7.Image.Width


        If (h2 = h3) And (h2 = h4) And (h2 = h5) And (h2 = h6) And (h2 = h7) And (w2 = w3) And (w2 = w4) And (w2 = w5) And (w2 = w6) And (w2 = w7) Then
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT COUNT(*)AS Row_Count FROM pengujian WHERE tanggal='" & DateTimePicker1.Value & "' AND kecamatan='" & KecamatanCB.SelectedItem.ToString() & "'"
            cmd.Connection = con
            con.Open()
            exist = cmd.ExecuteScalar()
            con.Close()

            If exist = 0 Then
                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "INSERT INTO pengujian (kecamatan,tanggal,b2,b3,b4,b5,b6,b7)" & "VALUES('" & KecamatanCB.SelectedItem.ToString() & "', '" & DateTimePicker1.Value & "','" & path_b2 & "','" & path_b3 & "','" & path_b4 & "','" & path_b5 & "','" & path_b6 & "','" & path_b7 & "')"
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Input data sukses!", MsgBoxStyle.Information, "Input Data")
                con.Close()


            Else
                MsgBox("Data sudah ada di database", MsgBoxStyle.Information, "Input Data")
            End If
        Else
            MsgBox("Ukuran citra input berbeda", MsgBoxStyle.Exclamation, "Input Data")
        End If




        Dim adapter As New SqlDataAdapter("SELECT * FROM pengujian", con)
        Dim Table As New DataTable()
        adapter.Fill(Table)
        DataGridView1.DataSource = Table

        path_b2 = ""
        path_b3 = ""
        path_b4 = ""
        path_b5 = ""
        path_b6 = ""
        path_b7 = ""
        band2.Image = Nothing
        band3.Image = Nothing
        band4.Image = Nothing
        band5.Image = Nothing
        band6.Image = Nothing
        band7.Image = Nothing

    End Sub

    Private Sub Testing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim adapter As New SqlDataAdapter("SELECT * FROM pengujian", con)
        Dim Table As New DataTable()
        adapter.Fill(Table)
        DataGridView1.DataSource = Table
    End Sub

    Private Sub RefBtn_Click(sender As Object, e As EventArgs) Handles RefBtn.Click
        DataGridView1.DataSource = Nothing
        Dim adapter As New SqlDataAdapter("SELECT * FROM pengujian", con)
        Dim Table As New DataTable()
        adapter.Fill(Table)
        DataGridView1.DataSource = Table
    End Sub

    Private Sub DelBtn_Click(sender As Object, e As EventArgs) Handles DelBtn.Click
        Dim id As Integer
        Dim alert As DialogResult

        If DataGridView1.RowCount = 1 Then
            MsgBox("Data kosong!", MsgBoxStyle.Information, "Hapus Data")
        Else
            If DataGridView1.SelectedCells.Count < 2 Then
                MsgBox("Pilih data yang ingin dihapus!", MsgBoxStyle.Information, "Hapus Data")
            Else
                id = DataGridView1.SelectedCells(0).Value

                alert = MessageBox.Show("Yakin ingin menghapus?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                If alert = DialogResult.OK Then
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "DELETE FROM pengujian WHERE id_test='" & id & "'"
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Data berhasil dihapus!", MsgBoxStyle.Exclamation, "Hapus Data")
                    DataGridView1.DataSource = Nothing
                    Dim adapter As New SqlDataAdapter("SELECT * FROM pengujian", con)
                    Dim Table As New DataTable()
                    adapter.Fill(Table)
                    DataGridView1.DataSource = Table
                End If
            End If
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TestBtn_Click(sender As Object, e As EventArgs) Handles TestBtn.Click
        Dim exist As Integer
        Dim id As Integer
        Dim kec, tgl As String
        Dim tgl1 As Date
        If DataGridView1.RowCount = 1 Then
            MsgBox("Data kosong!", MsgBoxStyle.Information, "Klasifikasi Data")
        Else
            If DataGridView1.SelectedCells.Count < 2 Then
                MsgBox("Pilih data yang ingin diklasifikasikan!", MsgBoxStyle.Information, "Klasifikasi Data")
            Else
                id = DataGridView1.SelectedCells(0).Value
                kec = DataGridView1.SelectedCells(1).Value
                tgl1 = DataGridView1.SelectedCells(2).Value

                tgl = Format(tgl1, "yyyy-MM-dd")



                cmd.CommandType = System.Data.CommandType.Text
                cmd.CommandText = "SELECT COUNT(*)AS Row_Count FROM pengujian WHERE tanggal='" & tgl & "' AND kecamatan='" & kec & "'"
                cmd.Connection = con
                con.Open()
                exist = cmd.ExecuteScalar()
                con.Close()
                'MsgBox(exist.ToString(), MsgBoxStyle.Information, "Klasifikasi Data")
                Dim py As New Process()
                py.StartInfo.FileName = "C:\Users\Valen\AppData\Local\Programs\Python\Python39\python.exe"
                py.StartInfo.WorkingDirectory = ("E:\Skripsi\Program\Python")
                py.StartInfo.Arguments = ("Testing.py " & kec & "," & tgl)
                py.Start()
                py.WaitForExit()

                MsgBox("Data berhasil diklasifikasi!", MsgBoxStyle.Exclamation, "Klasifikasi Data")
            End If
        End If
    End Sub

    Private Sub KecamatanCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KecamatanCB.SelectedIndexChanged

    End Sub

    Private Sub b7Btn_Click(sender As Object, e As EventArgs) Handles b7Btn.Click
        opf.Filter = "Choose Image(*.tif;)|*.tif;"
        If opf.ShowDialog = DialogResult.OK Then
            b7 = CType(Image.FromFile(opf.FileName), Bitmap)
            band7.Image = b7
            band7.SizeMode = PictureBoxSizeMode.Zoom
            band7.ImageLocation = opf.FileName
            path_b7 = band7.ImageLocation
            TabControl1.SelectedIndex = 5
        End If
    End Sub

    Public Sub AddKecamatanDepok(KecamatanCB)
        KecamatanCB.Items.Add("Beji")
        KecamatanCB.Items.Add("Bojongsari")
        KecamatanCB.Items.Add("Cilodong")
        KecamatanCB.Items.Add("Cimanggis")
        KecamatanCB.Items.Add("Cinere")
        KecamatanCB.Items.Add("Cipayung")
        KecamatanCB.Items.Add("Limo")
        KecamatanCB.Items.Add("PancoranMas")
        KecamatanCB.Items.Add("Sawangan")
        KecamatanCB.Items.Add("Sukmajaya")
        KecamatanCB.Items.Add("Tapos")
    End Sub
    Public Sub AddKecamatanTangsel(KecamatanCB)
        KecamatanCB.Items.Add("Ciputat")
        KecamatanCB.Items.Add("CiputatTimur")
        KecamatanCB.Items.Add("Pamulang")
        KecamatanCB.Items.Add("Pondokaren")
        KecamatanCB.Items.Add("Serpong")
        KecamatanCB.Items.Add("SerpongUtara")
        KecamatanCB.Items.Add("Setu_TangerangSelatan")
    End Sub
    Public Sub AddKecamatanBogor(KecamatanCB)
        KecamatanCB.Items.Add("KotaBogor")
        KecamatanCB.Items.Add("Nanggung")
        KecamatanCB.Items.Add("Leuwiliang")
        KecamatanCB.Items.Add("Leuwisadeng")
        KecamatanCB.Items.Add("Pamijahan")
        KecamatanCB.Items.Add("Cibungbulang")
        KecamatanCB.Items.Add("Ciampea")
        KecamatanCB.Items.Add("Tenjolaya")
        KecamatanCB.Items.Add("Dramaga")
        KecamatanCB.Items.Add("Ciomas")
        KecamatanCB.Items.Add("Tamansari")
        KecamatanCB.Items.Add("Cijeruk")
        KecamatanCB.Items.Add("Cigombong")
        KecamatanCB.Items.Add("Caringin")
        KecamatanCB.Items.Add("Ciawi")
        KecamatanCB.Items.Add("Cisarua")
        KecamatanCB.Items.Add("Megamendung")
        KecamatanCB.Items.Add("Sukaraja")
        KecamatanCB.Items.Add("BabakanMadang")
        KecamatanCB.Items.Add("Sukamakmur")
        KecamatanCB.Items.Add("Cariu")
        KecamatanCB.Items.Add("Tanjungsari")
        KecamatanCB.Items.Add("Jonggol")
        KecamatanCB.Items.Add("Cileungsi")
        KecamatanCB.Items.Add("Klapanunggal")
        KecamatanCB.Items.Add("Gunungputri")
        KecamatanCB.Items.Add("Citeureup")
        KecamatanCB.Items.Add("Cibinong")
        KecamatanCB.Items.Add("Bojonggede")
        KecamatanCB.Items.Add("Tajurhalang")
        KecamatanCB.Items.Add("Kemang")
        KecamatanCB.Items.Add("Rancaungur")
        KecamatanCB.Items.Add("Parung")
        KecamatanCB.Items.Add("Ciseeng")
        KecamatanCB.Items.Add("GunungSindur")
        KecamatanCB.Items.Add("Rumpin")
        KecamatanCB.Items.Add("Cigudeg")
        KecamatanCB.Items.Add("Sukajaya")
        KecamatanCB.Items.Add("Jasinga")
        KecamatanCB.Items.Add("Tenjo")
        KecamatanCB.Items.Add("ParungPanjang")
    End Sub

    Private Sub KotaCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KotaCB.SelectedIndexChanged
        KecamatanCB.Text = ""
        KecamatanCB.Items.Clear()
        If (KotaCB.Text = "Depok") Then
            AddKecamatanDepok(KecamatanCB)
        End If
        If (KotaCB.Text = "Tangerang Selatan") Then
            AddKecamatanTangsel(KecamatanCB)
        End If
        If (KotaCB.Text = "Bogor") Then
            AddKecamatanBogor(KecamatanCB)
        End If
    End Sub


End Class