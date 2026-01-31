Public Class Form1
    Private currentValue As Double = 0
    Private previousValue As Double = 0
    Private operation As String = ""
    Private isNewEntry As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form Başlığı
        Me.Text = "Hesap Makinesi"
        txtSonuc.Text = "0"
    End Sub
    Private Sub btnSayi_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim btn As Button = CType(sender, Button)
        If isNewEntry Then
            txtSonuc.Text = btn.Text
            isNewEntry = False
        Else
            If txtSonuc.Text = "0" Then
                txtSonuc.Text = btn.Text
            Else
                txtSonuc.Text &= btn.Text
            End If
        End If
    End Sub
    ' İşlem butonları - Tüm işlemler için tek event
    Private Sub OperationButton_Click(sender As Object, e As EventArgs) Handles btnToplama.Click, btnCikarma.Click, btnCarpma.Click, btnBolme.Click
        Dim btn As Button = CType(sender, Button)

        previousValue = Double.Parse(txtSonuc.Text)
        operation = btn.Text
        isNewEntry = True
    End Sub

    ' Eşittir butonu - Hesaplama yapar
    Private Sub btnEsittir_Click(sender As Object, e As EventArgs) Handles btnEsittir.Click
        If operation = "" Then Return

        currentValue = Double.Parse(txtSonuc.Text)
        Dim result As Double = 0

        Select Case operation
            Case "+"
                result = previousValue + currentValue
            Case "-"
                result = previousValue - currentValue
            Case "*"
                result = previousValue * currentValue
            Case "/"
                If currentValue <> 0 Then
                    result = previousValue / currentValue
                Else
                    txtSonuc.Text = "Hata!"
                    MessageBox.Show("Sıfıra bölme hatası!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
        End Select

        txtSonuc.Text = result.ToString()
        isNewEntry = True
        operation = ""
    End Sub

    ' Temizle butonu - Hesap makinesini sıfırlar
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtSonuc.Text = "0"
        currentValue = 0
        previousValue = 0
        operation = ""
        isNewEntry = True
    End Sub
End Class