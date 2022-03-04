Public Class Perubahan
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

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        Dim exist1, exist2 As Integer
        Dim id, hij_imper, imper_hij, hs_hij, hs_imper, hij_hs, imper_hs, ttp, h1, hs1, i1 As Integer
        Dim kec, tanggal1, tanggal2, citra As String
        Dim tan1, tan2 As Date

        tan1 = Tgl1.Value
        tanggal1 = Format(tan1, "yyyy-MM-dd")

        tan2 = Tgl2.Value
        tanggal2 = Format(tan2, "yyyy-MM-dd")

        kec = KecamatanCB.SelectedItem.ToString()

        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "SELECT COUNT(*)AS Row_Count FROM hasil WHERE tanggal='" & tanggal1 & "' AND kecamatan='" & kec & "'"
        cmd.Connection = con
        con.Open()
        exist1 = cmd.ExecuteScalar()
        con.Close()

        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "SELECT COUNT(*)AS Row_Count FROM hasil WHERE tanggal='" & tanggal2 & "' AND kecamatan='" & kec & "'"
        cmd.Connection = con
        con.Open()
        exist2 = cmd.ExecuteScalar()
        con.Close()

        If (exist1 * exist2) = 0 Then
            MsgBox("Data belum diklasifikasi! Lakukan klasifikasi data terlebih dahulu di modul Testing!", MsgBoxStyle.Information, "Hasil Klasifikasi Data")
        Else

            Dim py As New Process()
            py.StartInfo.FileName = "C:\Users\Valen\AppData\Local\Programs\Python\Python39\python.exe"
            py.StartInfo.WorkingDirectory = ("E:\Skripsi\Program\Python")
            py.StartInfo.Arguments = ("Perubahan.py " & kec & "," & tanggal1 & "," & tanggal2)
            py.Start()
            py.WaitForExit()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT citra FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            citra = cmd.ExecuteScalar()
            con.Close()

            cit.Image = Image.FromFile(citra)
            cit.SizeMode = PictureBoxSizeMode.Zoom

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijau_hijausbg FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            hij_hs = Integer.Parse(cmd.ExecuteScalar())
            hhs.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijau_impervious FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            hij_imper = Integer.Parse(cmd.ExecuteScalar())
            hi.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()


            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijausbg_hijau FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            hs_hij = Integer.Parse(cmd.ExecuteScalar())
            hsh.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijausbg_imper FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            hs_imper = Integer.Parse(cmd.ExecuteScalar())
            hsi.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()


            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT imper_hijau FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            imper_hij = Integer.Parse(cmd.ExecuteScalar())
            ih.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT imper_hijausbg FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            imper_hs = Integer.Parse(cmd.ExecuteScalar())
            ihs.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()


            'cmd.CommandType = System.Data.CommandType.Text
            'cmd.CommandText = "SELECT berubah FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            'cmd.Connection = con
            'con.Open()
            'berubah.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            'con.Close()


            hijau.Text() = (imper_hij + hs_hij).ToString("#,#")
            impervious.Text() = (hij_imper + hs_imper).ToString("#,#")

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT tetap FROM perubahan WHERE tanggal1='" & tanggal1 & "' AND (kecamatan='" & kec & "' AND tanggal2='" & tanggal2 & "')"
            cmd.Connection = con
            con.Open()
            ttp = Integer.Parse(cmd.ExecuteScalar())
            Tetap.Text() = Integer.Parse(cmd.ExecuteScalar()).ToString("#,#")
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijau FROM hasil WHERE tanggal='" & tanggal1 & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            h1 = Integer.Parse(cmd.ExecuteScalar())
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT hijausebagian FROM hasil WHERE tanggal='" & tanggal1 & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            hs1 = Integer.Parse(cmd.ExecuteScalar())
            con.Close()

            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT impervious FROM hasil WHERE tanggal='" & tanggal1 & "' AND kecamatan='" & kec & "'"
            cmd.Connection = con
            con.Open()
            i1 = Integer.Parse(cmd.ExecuteScalar())
            con.Close()

            ttpprs.Text() = "(" & (Math.Round(((ttp / (h1 + hs1 + i1))) * 100, 2)).ToString() & "%" & ")"
            hhsprs.Text() = "(" & (Math.Round(((hij_hs / (h1))) * 100, 2)).ToString() & "%" & ")"
            hiprs.Text() = "(" & (Math.Round(((hij_imper / (h1))) * 100, 2)).ToString() & "%" & ")"
            hshprs.Text() = "(" & (Math.Round(((hs_hij / (hs1))) * 100, 2)).ToString() & "%" & ")"
            hsiprs.Text() = "(" & (Math.Round(((hs_imper / (hs1))) * 100, 2)).ToString() & "%" & ")"
            ihprs.Text() = "(" & (Math.Round(((imper_hij / (i1))) * 100, 2)).ToString() & "%" & ")"
            ihsprs.Text() = "(" & (Math.Round(((imper_hs / (i1))) * 100, 2)).ToString() & "%" & ")"
            mhprs.Text() = "(" & (Math.Round((((imper_hij + hs_hij) / (hs1 + i1))) * 100, 2)).ToString() & "%" & ")"
            miprs.Text() = "(" & (Math.Round((((hij_imper + hs_imper) / (hs1 + h1))) * 100, 2)).ToString() & "%" & ")"

        End If

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles ttpprs.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        rank.Show()

    End Sub
End Class