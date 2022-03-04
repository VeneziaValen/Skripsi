Imports System
Imports System.Globalization
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class Hasil
    Private Sub Hasil_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HomeBtn_Click(sender As Object, e As EventArgs) Handles HomeBtn.Click
        Home.Show()
        Me.Hide()

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

    Private Sub HijauSeb_Click(sender As Object, e As EventArgs) Handles HijauSeb.Click

    End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        Dim exist As Integer
        Dim id As Integer
        Dim kec, citra As String
        Dim tgl As Date
        Dim ci As CultureInfo = New CultureInfo("id-ID")

        tgl = DateTimePicker1.Value()
        kec = KecamatanCB.SelectedItem.ToString()
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "SELECT COUNT(*)AS Row_Count FROM hasil WHERE tanggal='" & tgl & "' AND kecamatan='" & kec & "'"
        cmd.Connection = con
        con.Open()
        exist = cmd.ExecuteScalar()
        con.Close()

        If exist = 0 Then
            MsgBox("Data belum diklasifikasi! Lakukan klasifikasi data terlebih dahulu di modul Testing!", MsgBoxStyle.Information, "Hasil Klasifikasi Data")
        Else

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT citra FROM hasil WHERE tanggal='" & tgl & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            citra = cmd.ExecuteScalar()
            con.Close()

            hasilPB.Image = Image.FromFile(citra)
            hasilPB.SizeMode = PictureBoxSizeMode.Zoom

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijau FROM hasil WHERE tanggal='" & tgl & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            Hijau.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijausebagian FROM hasil WHERE tanggal='" & tgl & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            HijauSeb.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT impervious FROM hasil WHERE tanggal='" & tgl & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            Imper.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()
        End If

    End Sub

    Private Sub PerubahanBtn_Click(sender As Object, e As EventArgs) Handles PerubahanBtn.Click
        Perubahan.Show()
        Me.Hide()

    End Sub

    Private Sub KecamatanCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KecamatanCB.SelectedIndexChanged

    End Sub
End Class