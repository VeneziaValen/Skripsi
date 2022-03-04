Public Class Home
    Private Sub TrainingBtn_Click(sender As Object, e As EventArgs) Handles TrainingBtn.Click
        Training.Show()
        Me.Hide()

    End Sub

    Private Sub TestingBtn_Click(sender As Object, e As EventArgs) Handles TestingBtn.Click
        Testing.Show()
        Me.Hide()

    End Sub

    Private Sub KlasifikasiBtn_Click(sender As Object, e As EventArgs) Handles KlasifikasiBtn.Click
        Hasil.Show()
        Me.Hide()

    End Sub

    Private Sub PerubahanBtn_Click(sender As Object, e As EventArgs) Handles PerubahanBtn.Click
        Perubahan.Show()
        Me.Hide()

    End Sub

    Private Sub TtgAuBtn_Click(sender As Object, e As EventArgs) Handles TtgAuBtn.Click
        pembuat.Show()
        Me.Hide()

    End Sub

    Private Sub TtgAppBtn_Click(sender As Object, e As EventArgs) Handles TtgAppBtn.Click
        aplikasi.Show()
        Me.Hide()

    End Sub
End Class
