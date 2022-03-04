Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class rank
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        DataGridView1.DataSource = Nothing
        'Dim kec As String
        Dim Table, tablefinal As New DataTable()
        Dim kec, tanggal1, tanggal2 As String
        Dim tan1, tan2 As Date

        tan1 = Tgl1.Value
        tanggal1 = Format(tan1, "yyyy-MM-dd")

        tan2 = Tgl2.Value
        tanggal2 = Format(tan2, "yyyy-MM-dd")

        If (KotaCB.Text = "Depok") Then
            kec = "'Beji', 'Bojongsari', 'Cilodong', 'Cimanggis', 'Cinere', 'Cipayung', 'Limo', 'PancoranMas', 'Sawangan', 'Sukmajaya', 'Tapos'"
        End If
        If (KotaCB.Text = "Tangerang Selatan") Then
            kec = "'Ciputat', 'CiputatTimur', 'Pamulang', 'Pondokaren', 'Serpong', 'SerpongUtara', 'Setu_TangerangSelatan'"
        End If
        If (KotaCB.Text = "Bogor") Then
            kec = "'BabakanMadang', 'Bojonggede', 'Caringin', 'Cariu', 'Ciampea', 'Ciawi', 'Cibinong', 'Cibungbulang', 'Cigombong', 'Cigudeg', 'Cijeruk', 'Cileungsi', 'Ciomas', 'Cisarua', 'Ciseeng', 'Citeureup', 'Dramaga', 'Gunungputri', 'GunungSindur', 'Jasinga', 'Jonggol', 'Kemang', 'Klapanunggal', 'Leuwiliang', 'Leuwisadeng', 'Megamendung', 'Nanggung', 'Pamijahan', 'Parung', 'ParungPanjang', 'Rancaungur', 'Rumpin', 'Sukajaya', 'Sukamakmur', 'Sukaraja', 'Tajurhalang', 'Tamansari', 'Tanjungsari', 'Tenjo', 'Tenjolaya', 'KotaBogor'"
        End If
        Dim adapter As New SqlDataAdapter("SELECT kecamatan, hijau_hijausbg AS 'Hijau - Hijau Sebagian', hijau_impervious AS 'Hijau - Impervious' FROM perubahan WHERE ((Kecamatan IN (" & kec & ") AND tanggal1='" & tanggal1 & "') AND tanggal2='" & tanggal2 & "')", con)

        adapter.Fill(Table)

        tablefinal.Columns.Add(Table.Columns(0).ColumnName, GetType(String))
        Dim i As Integer
        For i = 1 To 2
            tablefinal.Columns.Add(Table.Columns(i).ColumnName, GetType(Integer))
        Next
        Dim newrow As DataRow

        For Each r As DataRow In Table.Rows
            newrow = tablefinal.NewRow
            newrow(0) = r.ItemArray(0)
            For i = 1 To 2
                newrow(i) = Integer.Parse(r.ItemArray(i))
            Next i
            tablefinal.Rows.Add(newrow)
        Next r

        DataGridView1.DataSource = tablefinal

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Perubahan.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Home.Show()

    End Sub
End Class