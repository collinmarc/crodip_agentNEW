Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports wgssSTU

Class MyEncryptionHandler2
    Implements wgssSTU.ITabletEncryptionHandler2

    Private rsaProvider As RSACryptoServiceProvider
    Private rsaParameters As RSAParameters
    Private aes As RijndaelManaged

    Public Sub reset()
        If rsaProvider IsNot Nothing Then rsaProvider.Clear()
        rsaProvider = Nothing
        If aes IsNot Nothing Then aes.Clear()
        aes = Nothing
    End Sub

    Public Sub clearKeys()
        If aes IsNot Nothing Then aes.Clear()
        aes = Nothing
    End Sub

    Public Function getAsymmetricKeyType() As Byte
        Return CByte(wgssSTU.asymmetricKeyType.AsymmetricKeyType_RSA2048)
    End Function

    Public Function getAsymmetricPaddingType() As Byte
        Return CByte(wgssSTU.asymmetricPaddingType.AsymmetricPaddingType_OAEP)
    End Function

    Public Function getSymmetricKeyType() As Byte
        Return CByte(wgssSTU.symmetricKeyType.SymmetricKeyType_AES256)
    End Function

    Private Sub create()
        rsaProvider = New RSACryptoServiceProvider(2048, New CspParameters())
        rsaParameters = rsaProvider.ExportParameters(False)
    End Sub

    Public Function generatePublicKey() As Array
        If rsaProvider Is Nothing Then create()
        Return rsaParameters.Modulus
    End Function

    Public Function getPublicExponent() As Array
        If rsaProvider Is Nothing Then create()
        Return rsaParameters.Exponent
    End Function

    Public Sub computeSessionKey(ByVal data As Array)
        Dim arr As Byte() = rsaProvider.Decrypt(CType(data, Byte()), True)
        Dim key As Byte() = New Byte(31) {}
        Array.Copy(arr, arr.Length - 32, key, 0, 32)
        aes = New RijndaelManaged()
        aes.Key = key
        aes.IV = New Byte(15) {}
        aes.Mode = CipherMode.CBC
        aes.Padding = PaddingMode.None
    End Sub

    Public Function decrypt(ByVal data As Array) As Array
        Dim dec = aes.CreateDecryptor()
        Dim arr As Byte() = New Byte(data.Length - 1) {}
        dec.TransformBlock(CType(data, Byte()), 0, data.Length, arr, 0)
        Return arr
    End Function

    Private Sub ITabletEncryptionHandler2_reset() Implements ITabletEncryptionHandler2.reset
        Throw New NotImplementedException()
    End Sub

    Private Sub ITabletEncryptionHandler2_clearKeys() Implements ITabletEncryptionHandler2.clearKeys
        Throw New NotImplementedException()
    End Sub

    Private Function ITabletEncryptionHandler2_getSymmetricKeyType() As Byte Implements ITabletEncryptionHandler2.getSymmetricKeyType
        Throw New NotImplementedException()
    End Function

    Private Function ITabletEncryptionHandler2_getAsymmetricPaddingType() As Byte Implements ITabletEncryptionHandler2.getAsymmetricPaddingType
        Throw New NotImplementedException()
    End Function

    Private Function ITabletEncryptionHandler2_getAsymmetricKeyType() As Byte Implements ITabletEncryptionHandler2.getAsymmetricKeyType
        Throw New NotImplementedException()
    End Function

    Private Function ITabletEncryptionHandler2_getPublicExponent() As Array Implements ITabletEncryptionHandler2.getPublicExponent
        Throw New NotImplementedException()
    End Function

    Private Function ITabletEncryptionHandler2_generatePublicKey() As Array Implements ITabletEncryptionHandler2.generatePublicKey
        Throw New NotImplementedException()
    End Function

    Private Sub ITabletEncryptionHandler2_computeSessionKey(data As Array) Implements ITabletEncryptionHandler2.computeSessionKey
        Throw New NotImplementedException()
    End Sub

    Private Function ITabletEncryptionHandler2_decrypt(data As Array) As Array Implements ITabletEncryptionHandler2.decrypt
        Throw New NotImplementedException()
    End Function
End Class

Partial Public Class SignatureForm
        Inherits Form

        Public penDataType As Integer
        Private m_tablet As wgssSTU.Tablet
        Private m_capability As wgssSTU.ICapability
        Private m_information As wgssSTU.IInformation
        Private Delegate Sub ButtonClick()

        Private Structure Button
        Public Bounds As Drawing.Rectangle
        Public Text As String
            Public Click As EventHandler

            Public Sub PerformClick()
                Click(Me, Nothing)
            End Sub
        End Structure

        Private m_penInk As Pen
        Private m_isDown As Integer
        Private m_penData As List(Of wgssSTU.IPenData)
        Private m_penTimeData As List(Of wgssSTU.IPenDataTimeCountSequence)
        Private m_btns As Button()
        Private m_bitmap As Bitmap
        Private m_encodingMode As wgssSTU.encodingMode
        Private m_bitmapData As Byte()
        Private m_penDataOptionMode As Integer
        Private m_useEncryption As Boolean

        Private Function tabletToClient(ByVal penData As wgssSTU.IPenData) As PointF
            Return New PointF(CSng(penData.x) * Me.ClientSize.Width / m_capability.tabletMaxX, CSng(penData.y) * Me.ClientSize.Height / m_capability.tabletMaxY)
        End Function

        Private Function tabletToClientTimed(ByVal penData As wgssSTU.IPenDataTimeCountSequence) As PointF
            Return New PointF(CSng(penData.x) * Me.ClientSize.Width / m_capability.tabletMaxX, CSng(penData.y) * Me.ClientSize.Height / m_capability.tabletMaxY)
        End Function

        Private Function tabletToScreen(ByVal penData As wgssSTU.IPenData) As Point
            Return Point.Round(New PointF(CSng(penData.x) * m_capability.screenWidth / m_capability.tabletMaxX, CSng(penData.y) * m_capability.screenHeight / m_capability.tabletMaxY))
        End Function

        Private Function clientToScreen(ByVal pt As Point) As Point
            Return Point.Round(New PointF(CSng(pt.X) * m_capability.screenWidth / Me.ClientSize.Width, CSng(pt.Y) * m_capability.screenHeight / Me.ClientSize.Height))
        End Function

        Private Sub clearScreen()
            If m_useEncryption Then m_tablet.endCapture()
            m_tablet.writeImage(CByte(m_encodingMode), m_bitmapData)

            If m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence) Then
                m_penTimeData.Clear()
            Else
                m_penData.Clear()
            End If

            If m_useEncryption Then m_tablet.startCapture(&HC0FFEE)
            m_isDown = 0
            Me.Invalidate()
        End Sub

        Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs)
            SaveImage()
            penDataType = m_penDataOptionMode
            Me.Close()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
            If m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence) Then
                Me.m_penTimeData = Nothing
            Else
                Me.m_penData = Nothing
            End If

            Me.Close()
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
            If m_penData.Count <> 0 OrElse m_penTimeData.Count <> 0 Then
                clearScreen()
            End If
        End Sub

        Private Function setQualityGraphics(ByVal thisForm As Form) As Graphics
            Dim gfx As Graphics = thisForm.CreateGraphics()
            gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
            gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            Return gfx
        End Function

        Public Sub New(ByVal usbDevice As wgssSTU.IUsbDevice, ByVal encryptionWanted As Boolean)
            Dim currentPenDataOptionMode As Integer
            m_penDataOptionMode = -1
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            InitializeComponent()
            m_penData = New List(Of wgssSTU.IPenData)()
            m_tablet = New wgssSTU.Tablet()
            Dim protocolHelper As wgssSTU.ProtocolHelper = New wgssSTU.ProtocolHelper()
            Dim ec As wgssSTU.IErrorCode = m_tablet.usbConnect(usbDevice, True)

        If ec.value = 0 Then
            m_capability = m_tablet.getCapability()
            m_information = m_tablet.getInformation()
            currentPenDataOptionMode = getPenDataOptionMode()
            setPenDataOptionMode(currentPenDataOptionMode)
        Else
            Throw New Exception(ec.message)
            End If

            Me.SuspendLayout()
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Dim clientSize As Size = New Size(CInt((m_capability.tabletMaxX / 2540.0F * 96.0F)), CInt((m_capability.tabletMaxY / 2540.0F * 96.0F)))
            Me.ClientSize = clientSize
            Me.ResumeLayout()
            m_btns = New Button(2) {}

            If usbDevice.idProduct <> &HA2 Then
                Dim w2 As Integer = m_capability.screenWidth / 3
                Dim w3 As Integer = m_capability.screenWidth / 3
                Dim w1 As Integer = m_capability.screenWidth - w2 - w3
                Dim y As Integer = m_capability.screenHeight * 6 / 7
                Dim h As Integer = m_capability.screenHeight - y
            m_btns(0).Bounds = New Drawing.Rectangle(0, y, w1, h)
            m_btns(1).Bounds = New Drawing.Rectangle(w1, y, w2, h)
            m_btns(2).Bounds = New Drawing.Rectangle(w1 + w2, y, w3, h)
        Else
                Dim x As Integer = m_capability.screenWidth * 3 / 4
                Dim w As Integer = m_capability.screenWidth - x
                Dim h2 As Integer = m_capability.screenHeight / 3
                Dim h3 As Integer = m_capability.screenHeight / 3
                Dim h1 As Integer = m_capability.screenHeight - h2 - h3
            m_btns(0).Bounds = New Drawing.Rectangle(x, 0, w, h1)
            m_btns(1).Bounds = New Drawing.Rectangle(x, h1, w, h2)
            m_btns(2).Bounds = New Drawing.Rectangle(x, h1 + h2, w, h3)
        End If

            m_btns(0).Text = "OK"
            m_btns(1).Text = "Clear"
            m_btns(2).Text = "Cancel"
            m_btns(0).Click = New EventHandler(AddressOf btnOk_Click)
            m_btns(1).Click = New EventHandler(AddressOf btnClear_Click)
            m_btns(2).Click = New EventHandler(AddressOf btnCancel_Click)
            Dim idP As UShort = m_tablet.getProductId()
            Dim encodingFlag As wgssSTU.encodingFlag = CType(protocolHelper.simulateEncodingFlag(idP, 0), wgssSTU.encodingFlag)
            Dim useColor As Boolean = False

            If (encodingFlag And (wgssSTU.encodingFlag.EncodingFlag_16bit Or wgssSTU.encodingFlag.EncodingFlag_24bit)) <> 0 Then
                If m_tablet.supportsWrite() Then useColor = True
            End If

            If (encodingFlag And wgssSTU.encodingFlag.EncodingFlag_24bit) <> 0 Then
                m_encodingMode = If(m_tablet.supportsWrite(), wgssSTU.encodingMode.EncodingMode_24bit_Bulk, wgssSTU.encodingMode.EncodingMode_24bit)
            ElseIf (encodingFlag And wgssSTU.encodingFlag.EncodingFlag_16bit) <> 0 Then
                m_encodingMode = If(m_tablet.supportsWrite(), wgssSTU.encodingMode.EncodingMode_16bit_Bulk, wgssSTU.encodingMode.EncodingMode_16bit)
            Else
                m_encodingMode = wgssSTU.encodingMode.EncodingMode_1bit
            End If

            m_bitmap = New Bitmap(m_capability.screenWidth, m_capability.screenHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb)

            If True Then
                Dim gfx As Graphics = Graphics.FromImage(m_bitmap)
                gfx.Clear(Color.White)
                Dim font As Font = New Font(FontFamily.GenericSansSerif, m_btns(0).Bounds.Height / 2.0F, GraphicsUnit.Pixel)
                Dim sf As StringFormat = New StringFormat()
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center

                If useColor Then
                    gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
                Else
                    gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel
                End If

                For i As Integer = 0 To m_btns.Length - 1

                    If useColor Then
                        gfx.FillRectangle(Brushes.LightGray, m_btns(i).Bounds)
                    End If

                    gfx.DrawRectangle(Pens.Black, m_btns(i).Bounds)
                    gfx.DrawString(m_btns(i).Text, font, Brushes.Black, m_btns(i).Bounds, sf)
                Next

                gfx.Dispose()
                font.Dispose()
                Me.BackgroundImage = m_bitmap
                Me.BackgroundImageLayout = ImageLayout.Stretch
            End If

            If True Then
                Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream()
                m_bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png)
                m_bitmapData = CType(protocolHelper.resizeAndFlatten(stream.ToArray(), 0, 0, CUInt(m_bitmap.Width), CUInt(m_bitmap.Height), m_capability.screenWidth, m_capability.screenHeight, CByte(m_encodingMode), wgssSTU.Scale.Scale_Fit, 0, 0), Byte())
                protocolHelper = Nothing
                stream.Dispose()
            End If

            Dim useZlibCompression As Boolean = False

            If Not useColor AndAlso useZlibCompression Then
                m_encodingMode = m_encodingMode Or wgssSTU.encodingMode.EncodingMode_Zlib
            End If

            Dim s As SizeF = Me.AutoScaleDimensions
            Dim inkWidthMM As Single = 0.7F
            m_penInk = New Pen(Color.DarkBlue, inkWidthMM / 25.4F * ((s.Width + s.Height) / 2.0F))
            m_penInk.StartCap = CSharpImpl.__Assign(m_penInk.EndCap, System.Drawing.Drawing2D.LineCap.Round)
            m_penInk.LineJoin = System.Drawing.Drawing2D.LineJoin.Round
            addDelegates()
            clearScreen()

            If encryptionWanted Then

                If m_tablet.isSupported(CByte(wgssSTU.ReportId.ReportId_EncryptionStatus)) Then
                    Dim e As MyEncryptionHandler2 = New MyEncryptionHandler2()
                    m_tablet.encryptionHandler2 = e
                    m_useEncryption = True
                End If

                If m_useEncryption Then m_tablet.startCapture(&HC0FFEE)
            End If

            m_tablet.setInkingMode(&H1)
        End Sub

        Private Function getPenDataOptionMode() As Integer
            Dim penDataOptionMode As Integer

            Try
                penDataOptionMode = m_tablet.getPenDataOptionMode()
            Catch optionModeException As Exception
                penDataOptionMode = -1
            End Try

            Return penDataOptionMode
        End Function

        Private Sub setPenDataOptionMode(ByVal currentPenDataOptionMode As Integer)
            Select Case currentPenDataOptionMode
                Case -1
                    m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_None)
                Case CInt(PenDataOptionMode.PenDataOptionMode_None)

                    Try
                        m_tablet.setPenDataOptionMode(CByte(wgssSTU.penDataOptionMode.PenDataOptionMode_TimeCountSequence))
                        m_penDataOptionMode = m_tablet.getPenDataOptionMode()

                        If m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCount) Then
                            m_tablet.setPenDataOptionMode(CByte(wgssSTU.penDataOptionMode.PenDataOptionMode_None))
                            m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_None)
                        Else
                            m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
                        End If

                    Catch ex As Exception
                        m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_None)
                    End Try

                Case CInt(PenDataOptionMode.PenDataOptionMode_TimeCount)
                    m_tablet.setPenDataOptionMode(CByte(wgssSTU.penDataOptionMode.PenDataOptionMode_None))
                    m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_None)
                Case CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
                    m_penDataOptionMode = currentPenDataOptionMode
            End Select

            Select Case CInt(m_penDataOptionMode)
                Case CInt(PenDataOptionMode.PenDataOptionMode_None)
                    m_penData = New List(Of wgssSTU.IPenData)()
                Case CInt(PenDataOptionMode.PenDataOptionMode_TimeCount)
                    m_penData = New List(Of wgssSTU.IPenData)()
                Case CInt(PenDataOptionMode.PenDataOptionMode_SequenceNumber)
                    m_penData = New List(Of wgssSTU.IPenData)()
                Case CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
                    m_penTimeData = New List(Of wgssSTU.IPenDataTimeCountSequence)()
                Case Else
                    m_penData = New List(Of wgssSTU.IPenData)()
            End Select
        End Sub

        Private Sub addDelegates()
        AddHandler m_tablet.onGetReportException, AddressOf onGetReportException
        AddHandler m_tablet.onPenData, AddressOf onPenData
        AddHandler m_tablet.onPenDataEncrypted, AddressOf onPenDataEncrypted
        AddHandler m_tablet.onPenDataTimeCountSequence, AddressOf onPenDataTimeCountSequence
        AddHandler m_tablet.onPenDataTimeCountSequenceEncrypted, AddressOf onPenDataTimeCountSequenceEncrypted
    End Sub

        Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            If m_tablet IsNot Nothing Then
            RemoveHandler m_tablet.onGetReportException, AddressOf onGetReportException
            RemoveHandler m_tablet.onPenData, AddressOf onPenData
            RemoveHandler m_tablet.onPenDataEncrypted, AddressOf onPenDataEncrypted
            RemoveHandler m_tablet.onPenDataTimeCountSequence, AddressOf onPenDataTimeCountSequence
            RemoveHandler m_tablet.onPenDataTimeCountSequenceEncrypted, AddressOf onPenDataTimeCountSequenceEncrypted
            m_tablet.setInkingMode(&H0)
            If m_useEncryption Then m_tablet.endCapture()
                m_tablet.setClearScreen()
                m_tablet.disconnect()
            End If

            m_penInk.Dispose()
        End Sub

        Private Sub onGetReportException(ByVal tabletEventsException As wgssSTU.ITabletEventsException)
            Try
                tabletEventsException.getException()
            Catch e As Exception
                MessageBox.Show("Error: " & e.Message)
                m_tablet.disconnect()
                m_tablet = Nothing
                m_penData = Nothing
                m_penTimeData = Nothing
                Me.Close()
            End Try
        End Sub

        Private Sub onPenDataTimeCountSequenceEncrypted(ByVal penTimeCountSequenceDataEncrypted As wgssSTU.IPenDataTimeCountSequenceEncrypted)
            onPenDataTimeCountSequence(penTimeCountSequenceDataEncrypted)
        End Sub

        Private Sub onPenDataTimeCountSequence(ByVal penTimeData As wgssSTU.IPenDataTimeCountSequence)
            Dim penSequence As UInt16
            Dim penTimeStamp As UInt16
            Dim penPressure As UInt16
            Dim x As UInt16
            Dim y As UInt16
            penPressure = penTimeData.pressure
            penTimeStamp = penTimeData.timeCount
            penSequence = penTimeData.sequence
            x = penTimeData.x
            y = penTimeData.y
            Dim pt As Point = tabletToScreen(penTimeData)
            Dim btn As Integer = buttonClicked(pt)
            Dim isDown As Boolean = (penTimeData.sw <> 0)

            If isDown Then

                If m_isDown = 0 Then

                    If btn > 0 Then
                        m_isDown = btn
                    Else
                        m_isDown = -1
                    End If
                Else
                End If

                If m_penTimeData.Count <> 0 AndAlso m_isDown = -1 Then
                    Dim gfx As Graphics = setQualityGraphics(Me)
                    Dim prevPenData As wgssSTU.IPenDataTimeCountSequence = m_penTimeData(m_penTimeData.Count - 1)
                    Dim prev As PointF = tabletToClient(prevPenData)
                    gfx.DrawLine(m_penInk, prev, tabletToClientTimed(penTimeData))
                    gfx.Dispose()
                End If

                If m_isDown = -1 Then m_penTimeData.Add(penTimeData)
            Else

                If m_isDown <> 0 Then

                    If btn > 0 Then

                        If btn = m_isDown Then
                            m_btns(btn - 1).PerformClick()
                        End If
                    End If

                    m_isDown = 0
                Else
                End If

                If m_penTimeData IsNot Nothing Then
                    If m_penTimeData.Count <> 0 Then m_penTimeData.Add(penTimeData)
                End If
            End If
        End Sub

        Private Sub onPenDataEncrypted(ByVal penData As wgssSTU.IPenDataEncrypted)
            onPenData(penData.penData1)
            onPenData(penData.penData2)
        End Sub

        Private Sub onPenData(ByVal penData As wgssSTU.IPenData)
            Dim pt As Point = tabletToScreen(penData)
            Dim btn As Integer = 0

            If True Then

                For i As Integer = 0 To m_btns.Length - 1

                    If m_btns(i).Bounds.Contains(pt) Then
                        btn = i + 1
                        Exit For
                    End If
                Next
            End If

            Dim isDown As Boolean = (penData.sw <> 0)

            If isDown Then

                If m_isDown = 0 Then

                    If btn > 0 Then
                        m_isDown = btn
                    Else
                        m_isDown = -1
                    End If
                Else
                End If

                If m_penData.Count <> 0 AndAlso m_isDown = -1 Then
                    Dim gfx As Graphics = Me.CreateGraphics()
                    gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                    gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
                    gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
                    gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                    Dim prevPenData As wgssSTU.IPenData = m_penData(m_penData.Count - 1)
                    Dim prev As PointF = tabletToClient(prevPenData)
                    gfx.DrawLine(m_penInk, prev, tabletToClient(penData))
                    gfx.Dispose()
                End If

                If m_isDown = -1 Then m_penData.Add(penData)
            Else

                If m_isDown <> 0 Then

                    If btn > 0 Then

                        If btn = m_isDown Then
                            m_btns(btn - 1).PerformClick()
                        End If
                    End If

                    m_isDown = 0
                Else
                End If

                If m_penData IsNot Nothing Then
                    If m_penData.Count <> 0 Then m_penData.Add(penData)
                End If
            End If
        End Sub

        Private Function buttonClicked(ByVal pt As Point) As Integer
            Dim btn As Integer = 0

            If True Then

                For i As Integer = 0 To m_btns.Length - 1

                    If m_btns(i).Bounds.Contains(pt) Then
                        btn = i + 1
                        Exit For
                    End If
                Next
            End If

            Return btn
        End Function

        Private Sub Form2_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            If m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence) Then
                renderPenTimeData(e)
            Else
                renderPenData(e)
            End If
        End Sub

        Private Sub renderPenData(ByVal e As PaintEventArgs)
            If m_penData.Count <> 0 Then
                Dim gfx As Graphics = e.Graphics
                gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                Dim isDown As Boolean = False
                Dim prev As PointF = New PointF()

                For i As Integer = 0 To m_penData.Count - 1

                    If m_penData(i).sw <> 0 Then

                        If Not isDown Then
                            isDown = True
                            prev = tabletToClient(m_penData(i))
                        Else
                            Dim curr As PointF = tabletToClient(m_penData(i))
                            gfx.DrawLine(m_penInk, prev, curr)
                            prev = curr
                        End If
                    Else

                        If isDown Then
                            isDown = False
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub renderPenTimeData(ByVal e As PaintEventArgs)
            If m_penTimeData.Count <> 0 Then
                Dim gfx As Graphics = e.Graphics
                gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                Dim isDown As Boolean = False
                Dim prev As PointF = New PointF()

                For i As Integer = 0 To m_penTimeData.Count - 1

                    If m_penTimeData(i).sw <> 0 Then

                        If Not isDown Then
                            isDown = True
                            prev = tabletToClientTimed(m_penTimeData(i))
                        Else
                            Dim curr As PointF = tabletToClientTimed(m_penTimeData(i))
                            gfx.DrawLine(m_penInk, prev, curr)
                            prev = curr
                        End If
                    Else

                        If isDown Then
                            isDown = False
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub Form2_Paint_old(ByVal sender As Object, ByVal e As PaintEventArgs)
            If m_penData.Count <> 0 Then
                Dim gfx As Graphics = e.Graphics
                gfx.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                Dim isDown As Boolean = False
                Dim prev As PointF = New PointF()

                For i As Integer = 0 To m_penData.Count - 1

                    If m_penData(i).sw <> 0 Then

                        If Not isDown Then
                            isDown = True
                            prev = tabletToClient(m_penData(i))
                        Else
                            Dim curr As PointF = tabletToClient(m_penData(i))
                            gfx.DrawLine(m_penInk, prev, curr)
                            prev = curr
                        End If
                    Else

                        If isDown Then
                            isDown = False
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub Form2_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim pt As Point = clientToScreen(e.Location)

            For Each btn As Button In m_btns

                If btn.Bounds.Contains(pt) Then
                    btn.PerformClick()
                    Exit For
                End If
            Next
        End Sub

        Public Function getPenData() As List(Of wgssSTU.IPenData)
            Return m_penData
        End Function

        Public Function getPenTimeData() As List(Of wgssSTU.IPenDataTimeCountSequence)
            Return m_penTimeData
        End Function

        Public Function getCapability() As wgssSTU.ICapability
            If m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence) Then
                Return If(m_penTimeData IsNot Nothing, m_capability, Nothing)
            Else
                Return If(m_penData IsNot Nothing, m_capability, Nothing)
            End If
        End Function

        Public Function getInformation() As wgssSTU.IInformation
            If m_penDataOptionMode = CInt(PenDataOptionMode.PenDataOptionMode_TimeCountSequence) Then
                Return If(m_penTimeData IsNot Nothing, m_information, Nothing)
            Else
                Return If(m_penData IsNot Nothing, m_information, Nothing)
            End If
        End Function

        Private Sub SaveImage()
            Try
            Dim bitmap As Bitmap = GetImage(New Drawing.Rectangle(0, 0, m_capability.screenWidth, m_capability.screenHeight))
            Dim saveLocation As String = System.Environment.CurrentDirectory & "\" & "signature_output.jpg"
                bitmap.Save(saveLocation, ImageFormat.Jpeg)
            Catch ex As Exception
                MessageBox.Show("Exception: " & ex.Message)
            End Try
        End Sub

    Public Function GetImage(ByVal rect As Drawing.Rectangle) As Bitmap
        Dim retVal As Bitmap = Nothing
        Dim bitmap As Bitmap = Nothing
        Dim brush As SolidBrush = Nothing

        Try
            bitmap = New Bitmap(rect.Width, rect.Height)
            Dim graphics As Graphics = Graphics.FromImage(bitmap)
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            brush = New SolidBrush(Color.White)
            graphics.FillRectangle(brush, 0, 0, rect.Width, rect.Height)

            If m_penDataOptionMode = CInt(penDataOptionMode.PenDataOptionMode_TimeCountSequence) Then

                For i As Integer = 1 To m_penTimeData.Count - 1
                    Dim p1 As PointF = tabletToScreen(m_penTimeData(i - 1))
                    Dim p2 As PointF = tabletToScreen(m_penTimeData(i))

                    If m_penTimeData(i - 1).sw > 0 OrElse m_penTimeData(i).sw > 0 Then
                        graphics.DrawLine(m_penInk, p1, p2)
                    End If
                Next
            Else

                For i As Integer = 1 To m_penData.Count - 1
                    Dim p1 As PointF = tabletToScreen(m_penData(i - 1))
                    Dim p2 As PointF = tabletToScreen(m_penData(i))

                    If m_penData(i - 1).sw > 0 OrElse m_penData(i).sw > 0 Then
                        graphics.DrawLine(m_penInk, p1, p2)
                    End If
                Next
            End If

            retVal = bitmap
            bitmap = Nothing
        Finally
            If brush IsNot Nothing Then brush.Dispose()
            If bitmap IsNot Nothing Then bitmap.Dispose()
        End Try

        Return retVal
    End Function

    Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
