Imports System.Net.Mail
Public Class MailServicio

    Public Shared Function EnviarMail(ByVal para As String, ByVal asunto As String, ByVal contenido As String) As Boolean
        Try
            Dim Mail As New MailMessage
            Mail.Subject = asunto
            Mail.To.Add(para)
            Mail.From = New MailAddress("danotrampus@gmail.com")
            Mail.Body = contenido
            Mail.IsBodyHtml = True

            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.UseDefaultCredentials = False
            SMTP.Credentials = New System.Net.NetworkCredential("danotrampus@gmail.com", "danlea90")
            SMTP.Port = "587"
            SMTP.Timeout = 10000
            SMTP.Send(Mail)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
