
Public Class cPDF

#Region "constanteS"

    Private Const wsPDF As String = "1.5"
    Private Const wsPDFVersion As String = "wsPDF 4.0"

    Private ArrFontsNames() As String = {"Courier", _
                                         "CourierBold", _
                                         "CourierBoldOblique", _
                                         "CourierOblique", _
                                         "Helvetica", _
                                         "HelveticaBold", _
                                         "HelveticaBoldOblique", _
                                         "HelveticaOblique", _
                                         "Symbol", _
                                         "TimesBold", _
                                         "TimesBoldItalic", _
                                         "TimesItalic", _
                                         "TimesRoman", _
                                         "ZapfDingbats"}

#End Region

#Region "VARIABLES"

    Private aOutlines() As oOutlines
    Private iOutlines As Integer
    Private aPage() As Integer

    Private iOffset As Integer = 1
    Private iFontNum As Integer = 1
    Private iPagesNum As Integer = 1
    Private iCanvas As Integer = 1
    Private iWidthStr As Double

    Private ImgWidth As Double
    Private ImgHeight As Double

    Private sTLink As String
    Private sTyLink As String
    Private wRect As Integer

    Private PDFFontName As String
    Private PDFFontSize As Integer

    Private bPDFUnderline As Boolean = False

    Private FPageLink As Integer = 0

    Private NumberofImages As Integer = 0
    Private ContentNum As Integer
    Private ParentNum As Integer
    Private ResourceNum As Integer
    Private CatalogNum As Integer
    Private CurrentPDFSetPageObject As Integer = 0
    Private FontNumber As Integer = 0

    Private PDFCanvasOrientation() As String

    Private CurrentObjectNum As Integer = 0
    Private ObjectOffset As Integer = 0
    Private ObjectOffsetList(1) As Integer
    Private PageNumberList(1) As Integer

    Private PageLinksList(1000, 1000) As ArrayList

    Private PageCanvasWidth(1) As Double
    Private PageCanvasHeight(1) As Double
    Private FontNumberList(1) As Integer

    Private ArrIMG() As aIMG
    Private ArrFontAFM() As AFMFonts

    Private bPageLinksList(1) As Boolean
    Private NbPageLinksList(1) As Integer

    Private TempStream As String = vbNullString
    Private sTempStream As String = vbNullString

    Private StreamSize As Integer

#End Region

#Region "STRUCTURES"

    Private Structure AFMFonts
        Dim ID As String
        Dim Name As String
        Dim CharSize() As Integer
    End Structure

    Private Structure oOutlines
        Dim sText As String
        Dim iLevel As Integer
        Dim yPos As Double
        Dim iPageNb As Integer
        Dim bPrev As Boolean
        Dim bNext As Boolean
        Dim bFirst As Boolean
        Dim bLast As Boolean
        Dim iFirst As Integer
        Dim iNext As Integer
        Dim iPrev As Integer
        Dim iLast As Integer
        Dim iParent As Integer
    End Structure

    Private Structure aIMG
        Dim Width As Integer                'Image Width
        Dim Height As Integer               'Image Height
        Dim ColorSpace As String            'Gray ; RGB ; CMYK
        Dim BitsPerComponent As Integer     'Bits par pixels
        Dim DCTDecode As String             'DCTDecode
        Dim Stream As String                'Stream 
        Dim Resolution As String            'Dots ; Dots/inch ; Dots/cm
        Dim Size As Integer                 'Image size
    End Structure

#End Region

#Region "ENUM"

    Public Enum PDFStyleLgn
        pPDF_SOLID = 0
        pPDF_DASH = 1
        pPDF_DASHDOT = 2
        pPDF_DASHDOTDOT = 3
    End Enum

    Public Enum PDFFontStl
        FONT_NORMAL = 0
        FONT_ITALIC = 1
        FONT_BOLD = 2
        FONT_UNDERLINE = 4
    End Enum

    Public Enum PDFFontNme
        FONT_ARIAL = 0
        FONT_COURIER = 1
        FONT_TIMES = 2
        FONT_SYMBOL = 3
        FONT_ZAPFDINGBATS = 4
    End Enum

    Public Enum PDFZoomMd
        ZOOM_FULLPAGE = 0
        ZOOM_FULLWIDTH = 1
        ZOOM_REAL = 2
        ZOOM_DEFAULT = 3
    End Enum

    Public Enum PDFLayoutMd
        LAYOUT_SINGLE = 0
        LAYOUT_CONTINOUS = 1
        LAYOUT_TWO = 2
        LAYOUT_DEFAULT = 3
    End Enum

    Public Enum PDFUnitStr
        UNIT_PT = 0
        UNIT_MM = 1
        UNIT_CM = 2
    End Enum

    Public Enum PDFOrientationStr
        ORIENT_PAYSAGE = 0
        ORIENT_PORTRAIT = 1
    End Enum

    Public Enum PDFFormatPgStr
        FORMAT_A4 = 0
        FORMAT_A3 = 1
        FORMAT_A5 = 2
        FORMAT_LETTER = 3
        FORMAT_LEGAL = 4
    End Enum

    Public Enum PDFDrawMd
        DRAW_NORMAL = 0
        DRAW_DRAW = 1
        DRAW_DRAWBORDER = 2
    End Enum

    Public Enum PDFAlignValue
        ALIGN_CENTER = 0
        ALIGN_LEFT = 1
        ALIGN_RIGHT = 2
        ALIGN_FJUSTIFY = 3
    End Enum

    Public Enum PDFBorderValue
        BORDER_NONE = 0
        BORDER_BOTTOM = 1
        BORDER_TOP = 2
        BORDER_RIGHT = 4
        BORDER_LEFT = 8
        BORDER_ALL = 15
    End Enum

#End Region

#Region "PROPRIETES"

    Private sPathConfiguration As String
    Public Property PDFPathConfiguration() As String
        Get
            Return sPathConfiguration
        End Get
        Set(ByVal Value As String)
            sPathConfiguration = Value
        End Set
    End Property

    Private mPDFZoomMode As PDFZoomMd
    Public Property PDFZoomMode() As PDFZoomMd
        Get
            Return mPDFZoomMode
        End Get
        Set(ByVal Value As PDFZoomMd)
            mPDFZoomMode = Value
        End Set
    End Property

    Private mPDFUseThumbs As Boolean
    Public Property PDFUseThumbs() As Boolean
        Get
            Return mPDFUseThumbs
        End Get
        Set(ByVal Value As Boolean)
            mPDFUseThumbs = Value
        End Set
    End Property

    Private mPDFUseOutlines As Boolean
    Public Property PDFUseOutlines() As Boolean
        Get
            Return mPDFUseOutlines
        End Get
        Set(ByVal Value As Boolean)
            mPDFUseOutlines = Value
        End Set
    End Property

    Private mPDFLayoutMode As PDFLayoutMd
    Public Property PDFLayoutMode() As PDFLayoutMd
        Get
            Return mPDFLayoutMode
        End Get
        Set(ByVal Value As PDFLayoutMd)
            mPDFLayoutMode = Value
        End Set
    End Property

    Private mEchelle As Double = 72 / 2.54
    Private mPDFUnit As PDFUnitStr = PDFUnitStr.UNIT_CM
    Public Property PDFUnit() As PDFUnitStr
        Get
            Return mPDFUnit
        End Get
        Set(ByVal Value As PDFUnitStr)
            Select Case Value
                Case PDFUnitStr.UNIT_PT
                    mEchelle = 1
                Case PDFUnitStr.UNIT_MM
                    mEchelle = 72 / 25.4
                Case PDFUnitStr.UNIT_CM
                    mEchelle = 72 / 2.54
            End Select
            mPDFUnit = Value
        End Set
    End Property

    Private mPDFOrientation As PDFOrientationStr
    Public Property PDFOrientation() As PDFOrientationStr
        Get
            Return mPDFOrientation
        End Get
        Set(ByVal Value As PDFOrientationStr)

            mPDFOrientation = Value

            ReDim Preserve PDFCanvasWidth(iCanvas)
            ReDim Preserve PDFCanvasHeight(iCanvas)
            ReDim Preserve PDFCanvasOrientation(iCanvas)

            Dim tmp_PDFCanvasWidth As Integer = PDFCanvasWidth(iCanvas)
            Dim tmp_PDFCanvasHeight As Integer = PDFCanvasHeight(iCanvas)

            Select Case Value
                Case PDFOrientationStr.ORIENT_PORTRAIT
                    PDFCanvasWidth(iCanvas) = tmp_PDFCanvasWidth
                    PDFCanvasHeight(iCanvas) = tmp_PDFCanvasHeight
                    PDFCanvasOrientation(iCanvas) = "p"
                Case PDFOrientationStr.ORIENT_PAYSAGE
                    PDFCanvasWidth(iCanvas) = tmp_PDFCanvasHeight
                    PDFCanvasHeight(iCanvas) = tmp_PDFCanvasWidth
                    PDFCanvasOrientation(iCanvas) = "l"
            End Select

            ReDim Preserve PDFCanvasWidth(iCanvas)
            ReDim Preserve PDFCanvasHeight(iCanvas)
            ReDim Preserve PDFCanvasOrientation(iCanvas)

        End Set
    End Property

    Private mPDFFormatPage As PDFFormatPgStr
    Public Property PDFFormatPage() As PDFFormatPgStr
        Get
            Return mPDFFormatPage
        End Get
        Set(ByVal Value As PDFFormatPgStr)

            mPDFFormatPage = Value

            ReDim Preserve PDFCanvasWidth(iCanvas)
            ReDim Preserve PDFCanvasHeight(iCanvas)
            ReDim Preserve PDFCanvasOrientation(iCanvas)

            Select Case Value
                Case PDFFormatPgStr.FORMAT_A4
                    PDFCanvasWidth(iCanvas) = 595.28
                    PDFCanvasHeight(iCanvas) = 841.89
                Case PDFFormatPgStr.FORMAT_A3
                    PDFCanvasWidth(iCanvas) = 841.89
                    PDFCanvasHeight(iCanvas) = 1190.55
                Case PDFFormatPgStr.FORMAT_A5
                    PDFCanvasWidth(iCanvas) = 420.94
                    PDFCanvasHeight(iCanvas) = 595.28
                Case PDFFormatPgStr.FORMAT_LETTER
                    PDFCanvasWidth(iCanvas) = 612
                    PDFCanvasHeight(iCanvas) = 792
                Case PDFFormatPgStr.FORMAT_LEGAL
                    PDFCanvasWidth(iCanvas) = 612
                    PDFCanvasHeight(iCanvas) = 1008
            End Select

        End Set
    End Property

    Private FPageNumber As Integer = 1
    Public ReadOnly Property PDFPageNumber() As Integer
        Get
            PDFPageNumber = FPageNumber
        End Get
    End Property

    Public ReadOnly Property PDFNbPage() As Integer
        Get
            PDFNbPage = UBound(PageNumberList)
        End Get
    End Property

    Private FProducer As String = vbNullString
    Public Property PDFProducer() As String
        Get
            Return FProducer
        End Get
        Set(ByVal Value As String)
            FProducer = Value
        End Set
    End Property

    Private FSubject As String = vbNullString
    Public Property PDFSubject() As String
        Get
            Return FSubject
        End Get
        Set(ByVal Value As String)
            FSubject = Value
        End Set
    End Property

    Private FKeywords As String = vbNullString
    Public Property PDFKeywords() As String
        Get
            Return FKeywords
        End Get
        Set(ByVal Value As String)
            FKeywords = Value
        End Set
    End Property

    Private FCreator As String = vbNullString
    Public Property PDFCreator() As String
        Get
            Return FCreator
        End Get
        Set(ByVal Value As String)
            FCreator = Value
        End Set
    End Property

    Private FAuthor As String = vbNullString
    Public Property PDFAuthor() As String
        Get
            Return FAuthor
        End Get
        Set(ByVal Value As String)
            FAuthor = Value
        End Set
    End Property

    Private FTitle As String
    Public Property PDFTitle() As String
        Get
            Return FTitle
        End Get
        Set(ByVal Value As String)
            FTitle = Value
        End Set
    End Property

    Private FFileName As String
    Private iFile As Integer
    Public Property PDFFileName() As String
        Get
            Return FFileName
        End Get
        Set(ByVal Value As String)
            FFileName = Value
            iFile = FreeFile()
            FileOpen(iFile, FFileName, OpenMode.Output)
        End Set
    End Property

    Private mPDFConfirm As Boolean
    Public Property PDFConfirm() As Boolean
        Get
            Return mPDFConfirm
        End Get
        Set(ByVal Value As Boolean)
            mPDFConfirm = Value
        End Set
    End Property

    Private mPDFView As Boolean
    Public Property PDFView() As Boolean
        Get
            Return mPDFView
        End Get
        Set(ByVal Value As Boolean)
            mPDFView = Value
        End Set
    End Property

    Private mPDFWaitForExit As Boolean = False
    Public Property PDFWaitForExit() As Boolean
        Get
            Return mPDFWaitForExit
        End Get
        Set(ByVal value As Boolean)
            mPDFWaitForExit = value
        End Set
    End Property

    Private PDFCanvasHeight() As Double
    Public Property PDFPageHeight() As Double
        Get
            Return PDFCanvasHeight(iCanvas)
        End Get
        Set(ByVal Value As Double)
            PDFCanvasHeight(iCanvas) = Value
        End Set
    End Property

    Private PDFCanvasWidth() As Double
    Public Property PDFPageWidth() As Double
        Get
            Return PDFCanvasWidth(iCanvas)
        End Get
        Set(ByVal Value As Double)
            PDFCanvasWidth(iCanvas) = Value
        End Set
    End Property

    Private mPDFLeftMargin As Double ' Marge de gauche
    Public Property PDFLeftMargin() As Double
        Get
            Return mPDFLeftMargin
        End Get
        Set(ByVal Value As Double)
            mPDFLeftMargin = Value
        End Set
    End Property

    Private mPDFRightMargin As Double ' Margin de droite
    Public Property PDFRightMargin() As Double
        Get
            Return mPDFRightMargin
        End Get
        Set(ByVal Value As Double)
            mPDFRightMargin = Value
        End Set
    End Property

    Private mPDFTopMargin As Double ' Marge du haut
    Public Property PDFTopMargin() As Double
        Get
            Return mPDFTopMargin
        End Get
        Set(ByVal Value As Double)
            mPDFTopMargin = Value
        End Set
    End Property

    Private mPDFBottomMargin As Double ' Marge du bas
    Public Property PDFBottomMargin() As Double
        Get
            Return mPDFBottomMargin
        End Get
        Set(ByVal Value As Double)
            mPDFBottomMargin = Value
        End Set
    End Property

    Private mPDFCellMargin As Double ' Marge de cellule
    Public Property PDFCellMargin() As Double
        Get
            Return mPDFCellMargin
        End Get
        Set(ByVal Value As Double)
            mPDFCellMargin = Value
        End Set
    End Property

    Private dCurrentX As Double
    Public ReadOnly Property PDFGetX() As Double
        Get
            PDFGetX = dCurrentX
        End Get
    End Property

    Private dCurrentY As Double
    Public ReadOnly Property PDFGetY() As Double
        Get
            PDFGetY = dCurrentY
        End Get
    End Property

    Private sPDFLineStyle As String
    Private mPDFLineStyle As PDFStyleLgn
    Public Property PDFLineStyle() As PDFStyleLgn
        Get
            Return mPDFLineStyle
        End Get
        Set(ByVal Value As PDFStyleLgn)
            Select Case Value
                Case PDFStyleLgn.pPDF_SOLID
                    sPDFLineStyle = "[] 0 d"
                Case PDFStyleLgn.pPDF_DASH
                    sPDFLineStyle = "[" & Int(16 * mEchelle) & " " & Int(8 * mEchelle) & " ] 0 d"
                Case PDFStyleLgn.pPDF_DASHDOT
                    sPDFLineStyle = "[" & Int(8 * mEchelle) & " " & Int(7 * mEchelle) & " " & Int(2 * mEchelle) & " " & Int(7 * mEchelle) & " ] 0 d"
                Case PDFStyleLgn.pPDF_DASHDOTDOT
                    sPDFLineStyle = "[" & Int(8 * mEchelle) & " " & Int(4 * mEchelle) & " " & Int(2 * mEchelle) & " " & Int(4 * mEchelle) & " " & Int(2 * mEchelle) & " " & Int(4 * mEchelle) & " ] 0 d"
            End Select
            mPDFLineStyle = Value
        End Set
    End Property

    Private mPDFLineWidth As Double
    Public Property PDFLineWidth() As Double
        Get
            Return mPDFLineWidth
        End Get
        Set(ByVal Value As Double)
            mPDFLineWidth = Value
        End Set
    End Property

    Private mPDFDrawMode As PDFDrawMd
    Public Property PDFDrawMode() As PDFDrawMd
        Get
            Return mPDFDrawMode
        End Get
        Set(ByVal Value As PDFDrawMd)
            mPDFDrawMode = Value
        End Set
    End Property

    Private sPDFTextColor As String = "0 g"
    Private mPDFTextColor As System.Drawing.Color
    Public Property PDFTextColor() As System.Drawing.Color
        Get
            Return mPDFTextColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mPDFTextColor = Value
            sPDFTextColor = PDFStreamColor(Value, "TEXT")
        End Set
    End Property

    Private sPDFLineColor As String = "0 G"
    Private mPDFLineColor As System.Drawing.Color
    Public Property PDFLineColor() As System.Drawing.Color
        Get
            Return mPDFLineColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mPDFLineColor = Value
            sPDFLineColor = PDFStreamColor(Value, "LINE")
        End Set
    End Property

    Private sPDFDrawColor As String = "0 g"
    Private mPDFDrawColor As System.Drawing.Color
    Public Property PDFDrawColor() As System.Drawing.Color
        Get
            Return mPDFDrawColor
        End Get
        Set(ByVal Value As System.Drawing.Color)
            mPDFDrawColor = Value
            sPDFDrawColor = PDFStreamColor(Value, "BORDER")
        End Set
    End Property

    Private mPDFAlignement As PDFAlignValue = PDFAlignValue.ALIGN_LEFT
    Public Property PDFAlignement() As PDFAlignValue
        Get
            Return mPDFAlignement
        End Get
        Set(ByVal Value As PDFAlignValue)
            mPDFAlignement = Value
        End Set
    End Property

    Public ReadOnly Property PDFTextHeight() As Double
        Get
            Return PDFFontSize * mEchelle
        End Get
    End Property

    Private mPDFRotation As Double
    Public Property PDFRotation() As Double
        Get
            Return -1 * mPDFRotation
        End Get
        Set(ByVal Value As Double)
            mPDFRotation = -1 * Value
        End Set
    End Property

    Private sPDFBorder As String
    Private mPDFBorder As PDFBorderValue
    Public WriteOnly Property PDFBorder() As PDFBorderValue
        Set(ByVal Value As PDFBorderValue)
            mPDFBorder = Value
            sPDFBorder = vbNullString
            If Value >= PDFBorderValue.BORDER_LEFT Then
                sPDFBorder += "L"
                Value -= PDFBorderValue.BORDER_LEFT
            End If
            If Value >= PDFBorderValue.BORDER_RIGHT Then
                sPDFBorder += "R"
                Value -= PDFBorderValue.BORDER_RIGHT
            End If
            If Value >= PDFBorderValue.BORDER_TOP Then
                sPDFBorder += "T"
                Value -= PDFBorderValue.BORDER_TOP
            End If
            If Value >= PDFBorderValue.BORDER_BOTTOM Then
                sPDFBorder += "B"
                Value -= PDFBorderValue.BORDER_BOTTOM
            End If
        End Set
    End Property

    Private mPDFFill As Boolean
    Public Property PDFFill() As Boolean
        Get
            Return mPDFFill
        End Get
        Set(ByVal Value As Boolean)
            mPDFFill = Value
        End Set
    End Property

#End Region

#Region "DESSIN DE LIGNES, FORMES, TEXTE..."

    'Dessine une Ellipse
    Public Sub PDFDrawEllipse(ByRef x As Double, ByRef y As Double, ByRef rx As Double, Optional ByRef ry As Double = 0, Optional ByRef URLLink As String = vbNullString)

        Dim sTempDrawMode As String = vbNullString

        If ry = 0 Then
            ry = rx
        End If

        Select Case mPDFDrawMode
            Case PDFDrawMd.DRAW_NORMAL
                PDFOutStream(sTempStream, sPDFLineColor)
                sTempDrawMode = "s"
            Case PDFDrawMd.DRAW_DRAW
                PDFOutStream(sTempStream, sPDFDrawColor)
                sTempDrawMode = "h f"
            Case PDFDrawMd.DRAW_DRAWBORDER
                PDFOutStream(sTempStream, sPDFDrawColor)
                PDFOutStream(sTempStream, sPDFLineColor)
                sTempDrawMode = "B"
        End Select

        PDFOutStream(sTempStream, sPDFLineStyle)
        PDFOutStream(sTempStream, PDFFormatDouble(x * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (y + ry / 2) * mEchelle) & " m")
        PDFOutStream(sTempStream, PDFCurve(x * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry / 2 - ry / 2 * 11 / 20) * mEchelle, (x + rx / 2 - rx / 2 * 11 / 20) * mEchelle, PDFCanvasHeight(iCanvas) - y * mEchelle, (x + rx / 2) * mEchelle, PDFCanvasHeight(iCanvas) - y * mEchelle))
        PDFOutStream(sTempStream, PDFCurve((x + rx / 2 + rx / 2 * 11 / 20) * mEchelle, PDFCanvasHeight(iCanvas) - y * mEchelle, (x + rx) * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry / 2 - ry / 2 * 11 / 20) * mEchelle, (x + rx) * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry / 2) * mEchelle))
        PDFOutStream(sTempStream, PDFCurve((x + rx) * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry / 2 + ry / 2 * 11 / 20) * mEchelle, (x + rx / 2 + rx / 2 * 11 / 20) * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry) * mEchelle, (x + rx / 2) * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry) * mEchelle))
        PDFOutStream(sTempStream, PDFCurve((x + rx / 2 - rx / 2 * 11 / 20) * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry) * mEchelle, x * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry / 2 + ry / 2 * 11 / 20) * mEchelle, x * mEchelle, PDFCanvasHeight(iCanvas) - (y + ry / 2) * mEchelle))
        PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w " & sTempDrawMode)

        PDFTextColor = Color.White
        sTLink = "LINK"
        sTyLink = "ELLIPSE"
        PDFSetLink(URLLink, "ELLIPSE", Int(x - rx / 2), Int(y + ry / 2 - ry / 2 * 11 / 20))
        sTyLink = vbNullString

        dCurrentX = x
        dCurrentY = y + ry / 2

    End Sub
    Private Function PDFCurve(ByRef x1 As Object, ByRef y1 As Object, ByRef x2 As Object, ByRef y2 As Object, ByRef x3 As Object, ByRef y3 As Double) As String
        PDFCurve = PDFFormatDouble(x1) & " " & PDFFormatDouble(y1) & " " & PDFFormatDouble(x2) & " " & PDFFormatDouble(y2) & " " & PDFFormatDouble(x3) & " " & PDFFormatDouble(y3) & " c"
    End Function

    'Dessine un Polygone
    Public Sub PDFDrawPolygon(ByVal pParam() As Double)

        Dim sTempDrawMode As String = vbNullString

        Select Case mPDFDrawMode
            Case PDFDrawMd.DRAW_NORMAL
                PDFOutStream(sTempStream, sPDFLineColor)
                sTempDrawMode = "s"
            Case PDFDrawMd.DRAW_DRAW
                PDFOutStream(sTempStream, sPDFDrawColor)
                sTempDrawMode = "h f"
            Case PDFDrawMd.DRAW_DRAWBORDER
                PDFOutStream(sTempStream, sPDFDrawColor)
                PDFOutStream(sTempStream, sPDFLineColor)
                sTempDrawMode = "B"
        End Select

        PDFOutStream(sTempStream, "%DEBUT_POLY/%")
        PDFOutStream(sTempStream, sPDFLineStyle)

        'On place le premier point
        PDFPoint(pParam(0), pParam(1))
        'Puis on dessine des lignes entre chaque point
        For i As Integer = 2 To UBound(pParam) Step 2
            PDFLine(pParam(i), pParam(i + 1))
        Next i
        'Et on termine la boucle
        PDFLine(pParam(0), pParam(1))

        PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w " & sTempDrawMode)
        PDFOutStream(sTempStream, "%FIN_POLY/%")

    End Sub
    Private Sub PDFPoint(ByRef x As Double, ByRef y As Double)
        PDFOutStream(sTempStream, PDFFormatDouble(x * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - y * mEchelle) & " m")
    End Sub
    Private Sub PDFLine(ByRef x As Double, ByRef y As Double)
        PDFOutStream(sTempStream, PDFFormatDouble(x * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - y * mEchelle) & " l")
    End Sub

    'Dessine une ligne horizontale
    Public Sub PDFDrawLineHor(ByRef X As Double, ByRef Y As Double, ByRef W As Double)

        If Right(sPDFLineColor, 2) = "RG" Then
            sPDFDrawColor = Left(sPDFLineColor, Len(sPDFLineColor) - 2) & "rg"
        Else
            sPDFDrawColor = Left(sPDFLineColor, Len(sPDFLineColor) - 1) & "g"
        End If

        PDFOutStream(sTempStream, "%DEBUT_LNH/%")
        PDFOutStream(sTempStream, sPDFLineStyle)

        PDFOutStream(sTempStream, PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " m")
        PDFOutStream(sTempStream, PDFFormatDouble((X + W) * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " l")
        PDFOutStream(sTempStream, sPDFLineColor)
        PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w S")
        PDFOutStream(sTempStream, "%FIN_LNH/%")

        dCurrentX = X + W
        dCurrentY = Y

    End Sub

    'Dessine une ligne verticale
    Public Sub PDFDrawLineVer(ByRef x As Double, ByRef y As Double, ByRef h As Double)

        If Right(sPDFLineColor, 2) = "RG" Then
            sPDFDrawColor = Left(sPDFLineColor, Len(sPDFLineColor) - 2) & "rg"
        Else
            sPDFDrawColor = Left(sPDFLineColor, Len(sPDFLineColor) - 1) & "g"
        End If

        PDFOutStream(sTempStream, "%DEBUT_LNV/%")
        PDFOutStream(sTempStream, sPDFLineStyle)
        PDFOutStream(sTempStream, PDFFormatDouble(x * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - y * mEchelle) & " m")
        PDFOutStream(sTempStream, PDFFormatDouble(x * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (y + h) * mEchelle) & " l")
        PDFOutStream(sTempStream, sPDFLineColor)
        PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w S")
        PDFOutStream(sTempStream, "%FIN_LNV/%")

        dCurrentX = x
        dCurrentY = y + h

    End Sub

    'Dessine une ligne
    Public Sub PDFDrawLine(ByRef x1 As Double, ByRef y1 As Double, ByRef x2 As Double, ByRef y2 As Double)

        PDFOutStream(sTempStream, "%DEBUT_LN/%")
        PDFOutStream(sTempStream, sPDFLineStyle)
        PDFOutStream(sTempStream, PDFFormatDouble(x1 * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - y1 * mEchelle) & " m")
        PDFOutStream(sTempStream, PDFFormatDouble(x2 * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - y2 * mEchelle) & " l")
        PDFOutStream(sTempStream, sPDFLineColor)
        PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w S")
        PDFOutStream(sTempStream, "%FIN_LN/%")

        If x1 > x2 Then
            dCurrentX = x1
        Else
            dCurrentX = x2
        End If

        If y1 > y2 Then
            dCurrentY = y1
        Else
            dCurrentY = y2
        End If

    End Sub

    'Dessine un rectangle
    Public Sub PDFDrawRectangle(ByRef X As Double, ByRef Y As Double, ByRef W As Double, ByRef H As Double, Optional ByRef URLLink As String = vbNullString)

        Dim sTempDrawMode As String = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_RECT/%")

        Select Case mPDFDrawMode
            Case PDFDrawMd.DRAW_NORMAL
                PDFOutStream(sTempStream, sPDFLineColor)
                sTempDrawMode = "s"
            Case PDFDrawMd.DRAW_DRAW
                PDFOutStream(sTempStream, sPDFDrawColor)
                sTempDrawMode = "f"
            Case PDFDrawMd.DRAW_DRAWBORDER
                PDFOutStream(sTempStream, sPDFDrawColor)
                PDFOutStream(sTempStream, sPDFLineColor)
                sTempDrawMode = "B"
        End Select

        PDFOutStream(sTempStream, sPDFLineStyle)
        PDFOutStream(sTempStream, PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " " & PDFFormatDouble(W * mEchelle) & " " & PDFFormatDouble(-1 * H * mEchelle) & " re " & sTempDrawMode)
        PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w S")

        PDFTextColor = Color.White

        sTLink = "LINK"
        sTyLink = "RECTANGLE"
        wRect = W
        PDFSetLink(URLLink, "RECTANGLE", Int(X + 5), Int(Y + H / 2))
        PDFOutStream(sTempStream, "%FIN_RECT/%")

        sTyLink = vbNullString

        dCurrentX = X
        dCurrentY = Y + H

    End Sub

    'Dessine un texte 
    Public Sub PDFTextOut(ByRef sText As String, Optional ByRef X As Double = 0, Optional ByRef Y As Double = 0)

        Dim sTmpText As String = Replace(sText, "\", "\\")
        sTmpText = Replace(sTmpText, "\\", "\\\\")
        sTmpText = Replace(sTmpText, "(", "\(")
        sTmpText = Replace(sTmpText, ")", "\)")

        'On se positionne correctement
        If X = 0 Then
            X = dCurrentX
        End If
        If Y = 0 Then
            Y = dCurrentY
        End If

        'On cherche la position de la police
        Dim iPositionFont As Integer
        If PDFFontName = vbNullString Then
            iPositionFont = 1
        Else
            For i As Integer = 0 To UBound(ArrFontAFM)
                If ArrFontAFM(i).Name = PDFFontName Then
                    iPositionFont = i + 1
                    Exit For
                End If
            Next i
        End If

        'On applique le bon style à la police
        Dim sTmp As String = vbNullString
        If PDFFontSize = 0 Then
            PDFFontSize = 10
        End If
        If sPDFTextColor <> vbNullString Then
            PDFOutStream(sTempStream, "q " & sPDFTextColor & " ")
        End If
        If bPDFUnderline Then
            sTmp = PDFUnderline(False, sText, CDbl(X * mEchelle), CDbl(Y * mEchelle))
        End If

        PDFOutStream(sTempStream, "%DEBUT_TEXT/%")
        PDFOutStream(sTempStream, "BT")

        'Si besoin on fait tourner le texte
        If mPDFRotation = 0 Then
            PDFOutStream(sTempStream, PDFFormatDouble((X + mPDFLeftMargin) * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " Td")
        Else
            PDFStreamRotate(mPDFRotation, X, Y)
            mPDFRotation = 0
        End If

        PDFOutStream(sTempStream, "/F" & iPositionFont & " " & PDFFormatDouble(CDbl(PDFFontSize)) & " Tf")
        PDFOutStream(sTempStream, "(" & sTmpText & ") Tj")

        PDFOutStream(sTempStream, "ET")
        If bPDFUnderline = True Then
            PDFOutStream(sTempStream, sTmp)
        End If
        If sPDFTextColor <> vbNullString Then
            PDFOutStream(sTempStream, "Q")
        End If

        PDFOutStream(sTempStream, "%FIN_TEXT/%")

        bPDFUnderline = False

        dCurrentX = X + PDFGetStringWidth(sText, PDFFontName, PDFFontSize)
        dCurrentY = Y + PDFFontSize

    End Sub
    Private Sub PDFStreamRotate(ByRef pAngle As Double, ByRef X As Double, ByRef Y As Double)

        If pAngle <> 0 Then
            pAngle = pAngle * 3.14159265 / 180
            Dim dCos As Double = System.Math.Cos(pAngle)
            Dim dSin As Double = System.Math.Sin(pAngle)
            Dim CenterX As Double = X * mEchelle
            Dim CenterY As Double = PDFCanvasHeight(iCanvas) - Y * mEchelle
            PDFOutStream(sTempStream, PDFFormatDouble(dCos, 5) & " " & PDFFormatDouble(-1 * dSin, 5) & " " & PDFFormatDouble(dSin, 5) & " " & PDFFormatDouble(dCos, 5) & " " & PDFFormatDouble(CenterX) & " " & PDFFormatDouble(CenterY) & " Tm")
        End If

    End Sub

    'Dessine une cellule
    Public Sub PDFCell(ByRef sText As String, ByRef X As Double, ByRef Y As Double, ByRef W As Double, ByRef H As Double, Optional ByRef URLLink As String = vbNullString)

        Dim bMulti As Boolean

        Dim tWidth As Double = W
        Dim yPos As Double = Y

        Dim WidthMax As Double = (W - 2 * mPDFCellMargin) * 10 / PDFFontSize
        Dim lText As Integer = Len(sText)

        'On supprime un éventuelle dernier retour à la ligne
        If lText > 0 And Right(sText, lText - 1) = vbNewLine Then
            lText -= 1
        End If

        Dim bBorder1 As String = vbNullString
        Dim bBorder2 As String = vbNullString
        Dim tBorder As String = sPDFBorder

        If sPDFBorder = "LRTB" Or mPDFBorder = PDFBorderValue.BORDER_ALL Then
            bBorder1 = "LRT"
            bBorder2 = "LR"
        Else
            If InStr(sPDFBorder, "L") <> 0 Then
                bBorder2 += "L"
            End If
            If InStr(sPDFBorder, "R") <> 0 Then
                bBorder2 += "R"
            End If
            bBorder1 = bBorder2
            If InStr(sPDFBorder, "T") <> 0 Then
                bBorder1 += "T"
            End If
        End If

        Dim iSep As Integer = -1
        Dim i As Integer = 1
        Dim j As Integer = 1
        Dim l As Integer = 0
        Dim nl As Integer = 1

        PDFOutStream(sTempStream, "%DEBUT_CELL/%")

        While i <= lText

            Dim sCar As String = Mid(sText, i, 1)

            If sCar = vbCrLf Then
                sPDFBorder = bBorder1

                PDFCell2(Mid(sText, j, i - j), X, yPos, tWidth, H)
                yPos = dCurrentY

                bMulti = True

                i += 1
                iSep = -1
                j = i
                l = 0

                nl += 1
                If nl = 2 Then
                    bBorder1 = bBorder2
                End If

            ElseIf sCar = " " Then
                iSep = i
            End If

            l += PDFGetStringWidth(sCar, PDFFontName, PDFFontSize)

            If l > WidthMax Then

                If iSep = -1 Then
                    If i = j Then
                        i += 1
                    End If
                    sPDFBorder = bBorder1
                    PDFCell2(Mid(sText, j, i - j), X, yPos, tWidth, H)
                    yPos = dCurrentY
                    bMulti = True

                Else
                    sPDFBorder = bBorder1
                    PDFCell2(Mid(sText, j, iSep - j), X - mPDFCellMargin, yPos, tWidth, H)
                    yPos = dCurrentY
                    bMulti = True
                    i = iSep + 1

                End If

                iSep = -1
                j = i
                l = 0
                nl += 1
                If nl = 2 Then
                    bBorder1 = bBorder2
                End If

            Else
                i += 1
            End If

        End While

        If (InStr(tBorder, "B") <> 0) Then
            bBorder1 += "B"
            sPDFBorder = bBorder1
        End If

        yPos = IIf(bMulti, dCurrentY, yPos)
        PDFCell2(Mid(sText, j, i - j), X - mPDFCellMargin, yPos, tWidth, H)

        bPDFUnderline = False

        If mPDFAlignement = PDFAlignValue.ALIGN_FJUSTIFY Then
            PDFOutStream(sTempStream, "0 Tw")
            iWidthStr = 0
        End If

        PDFOutStream(sTempStream, "%FIN_CELL/%")

    End Sub
    Private Sub PDFCell2(ByRef sText As String, ByRef X As Double, ByRef Y As Double, ByRef W As Double, ByRef H As Double, Optional ByRef URLLink As String = vbNullString)

        Dim sTmpSTR As String = vbNullString

        Dim sTmpText As String = Replace(sText, "\", "\\")
        sTmpText = Replace(sTmpText, "\\", "\\\\")
        sTmpText = Replace(sTmpText, "(", "\(")
        sTmpText = Replace(sTmpText, ")", "\)")

        Dim iPositionFont As Integer = 1
        If PDFFontName <> vbNullString Then
            For i As Integer = 0 To UBound(ArrFontAFM)
                If ArrFontAFM(i).Name = PDFFontName Then
                    iPositionFont = i + 1
                    Exit For
                End If
            Next i
        End If

        If PDFFontSize = 0 Then
            PDFFontSize = 10
        End If
        If sPDFLineColor <> vbNullString Then
            PDFOutStream(sTempStream, Trim(sPDFLineColor))
        End If
        If sPDFDrawColor <> vbNullString Then
            PDFOutStream(sTempStream, sPDFDrawColor)
        End If

        If (mPDFFill = True) Or (mPDFBorder = PDFBorderValue.BORDER_ALL) Then
            Dim sTmp As String = vbNullString
            If mPDFFill = True Then
                If mPDFBorder = PDFBorderValue.BORDER_ALL Then
                    sTmp = "B"
                Else
                    sTmp = "f"
                End If
            Else
                sTmp = "S"
            End If
            sTmpSTR = PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " " & PDFFormatDouble(W * mEchelle) & " " & PDFFormatDouble(-H * mEchelle) & " re " & sTmp & vbCr
        End If

        If (mPDFBorder <> PDFBorderValue.BORDER_NONE) And (mPDFBorder <> PDFBorderValue.BORDER_ALL) Then
            PDFOutStream(sTempStream, PDFFormatDouble(mPDFLineWidth * mEchelle) & " w")

            If InStr(sPDFBorder, "L") <> 0 Then
                sTmpSTR += PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " m " & PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (Y + H) * mEchelle) & " l S" & vbCr
            End If
            If InStr(sPDFBorder, "T") <> 0 Then
                sTmpSTR += PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " m " & PDFFormatDouble(X * mEchelle + W * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " l S " & vbCr
            End If
            If InStr(sPDFBorder, "R") <> 0 Then
                sTmpSTR += PDFFormatDouble(X * mEchelle + W * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - Y * mEchelle) & " m " & PDFFormatDouble(X * mEchelle + W * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (Y + H) * mEchelle) & " l S " & vbCr
            End If
            If InStr(sPDFBorder, "B") <> 0 Then
                sTmpSTR += PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (Y + H) * mEchelle) & " m " & PDFFormatDouble(X * mEchelle + W * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (Y + H) * mEchelle) & " l S " & vbCr
            End If
        End If

        sPDFBorder = "0"

        Dim dx As Integer = 0
        Select Case mPDFAlignement
            Case PDFAlignValue.ALIGN_RIGHT
                Dim ltmp As Integer = PDFGetStringWidth(sText, PDFFontName, PDFFontSize)
                dx = W * mEchelle - mPDFCellMargin - CDbl(Format(ltmp, "###0.00"))
            Case PDFAlignValue.ALIGN_CENTER
                Dim ltmp As Integer = PDFGetStringWidth(sText, PDFFontName, PDFFontSize)
                dx = (W * mEchelle - ltmp) / 2
            Case PDFAlignValue.ALIGN_LEFT
                dx = 2 * mPDFCellMargin
            Case PDFAlignValue.ALIGN_FJUSTIFY
                Dim iWidthMax As Double = (W * mEchelle - (PDFGetNumberOfCar(sText, " ") + 1) * mPDFCellMargin)
                iWidthStr = (iWidthMax - PDFGetStringWidth(sText, PDFFontName, PDFFontSize)) / IIf(PDFGetNumberOfCar(sText, " ") <> 0, PDFGetNumberOfCar(sText, " "), 1)
                PDFOutStream(sTempStream, PDFFormatDouble(iWidthStr * mEchelle, 3) & " Tw")
                dx = 2 * mPDFCellMargin
        End Select

        If sTmpSTR <> vbNullString Then
            PDFOutStream(sTempStream, sTmpSTR)
        End If

        If URLLink <> vbNullString Then
            bPDFUnderline = True
            PDFTabLinks((X + dx), (Y + 0.5 * H - 0.5 * PDFFontSize), PDFGetStringWidth(sText, PDFFontName, PDFFontSize), CDbl(PDFFontSize), sText, URLLink)
        End If

        Dim sTmp1 As String = vbNullString
        If bPDFUnderline Then
            sTmp1 = PDFUnderline(True, sText, CDbl(X * mEchelle + dx), PDFCanvasHeight(iCanvas) - (Y * mEchelle + 0.5 * H * mEchelle + 0.3 * PDFFontSize))
        End If

        If sPDFTextColor <> vbNullString Then
            PDFOutStream(sTempStream, "q " & sPDFTextColor & " ")
            If bPDFUnderline = True Then
                PDFOutStream(sTempStream, sTmp1)
            End If
        End If

        Dim xlink As Double = X
        Dim yLink As Double = Y

        PDFOutStream(sTempStream, "BT")
        PDFOutStream(sTempStream, "/F" & iPositionFont & " " & PDFFontSize & " Tf")
        PDFOutStream(sTempStream, PDFFormatDouble(X * mEchelle + dx) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (Y * mEchelle + 0.5 * H * mEchelle + 0.3 * PDFFontSize)) & " Td")
        PDFOutStream(sTempStream, "(" & sTmpText & ") Tj")

        If sPDFTextColor <> vbNullString Then
            PDFOutStream(sTempStream, "ET")
            PDFOutStream(sTempStream, "Q")
        Else
            PDFOutStream(sTempStream, "ET")
        End If

        sTLink = sText
        sTyLink = "CELL"

        PDFSetLink(URLLink, "CELL", xlink, yLink)
        sTyLink = vbNullString

        dCurrentX = X + W
        dCurrentY = Y + H

    End Sub

#End Region

#Region "TRAITEMENT DE FICHIER JPG"

    'Ajoute une image JPG au fichier PDF
    Public Overloads Sub PDFImage(ByRef pFileName As String, ByRef X As Double, ByRef Y As Double, Optional ByRef W As Double = 0, Optional ByRef H As Double = 0, Optional ByRef URLLink As String = vbNullString)

        Dim ArrInfo As aIMG = PDFParseJPG(pFileName)
        If ArrInfo.Size = 0 Then
            Exit Sub
        End If

        PDFImageAdd(ArrInfo, X, Y, W, H, URLLink)
    End Sub
    Public Overloads Sub PDFImage(ByRef oPicture As Image, ByRef X As Double, ByRef Y As Double, Optional ByRef W As Double = 0, Optional ByRef H As Double = 0, Optional ByRef URLLink As String = vbNullString)

        Dim MyStream As System.IO.MemoryStream = New System.IO.MemoryStream
        oPicture.Save(MyStream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim bArray() As Byte = MyStream.ToArray

        Dim ArrInfo As aIMG = PDFParseJPG(bArray)
        If ArrInfo.Size = 0 Then
            Exit Sub
        End If

        PDFImageAdd(ArrInfo, X, Y, W, H, URLLink)
    End Sub
    Private Sub PDFImageAdd(ByRef ArrInfo As aIMG, ByRef X As Double, ByRef Y As Double, Optional ByRef W As Double = 0, Optional ByRef H As Double = 0, Optional ByRef URLLink As String = vbNullString)

        If W = 0 And H = 0 Then
            W = ArrInfo.Width / mEchelle
            H = ArrInfo.Height / mEchelle
        ElseIf W = 0 Then
            W = H * ArrInfo.Width / ArrInfo.Height
        ElseIf H = 0 Then
            H = W * ArrInfo.Height / ArrInfo.Width
        End If

        NumberofImages += 1

        ReDim Preserve ArrIMG(NumberofImages)
        ArrIMG(NumberofImages) = ArrInfo

        PDFOutStream(sTempStream, "q")
        PDFOutStream(sTempStream, PDFFormatDouble(W * mEchelle) & " 0 0 " & PDFFormatDouble(H * mEchelle) & " " & PDFFormatDouble(X * mEchelle) & " " & PDFFormatDouble(PDFCanvasHeight(iCanvas) - (Y + H) * mEchelle) & " cm /ImgJPEG" & NumberofImages & " Do Q")

        ImgWidth = W
        ImgHeight = H

        PDFSetLink(URLLink, "IMAGE", X, Y)

        dCurrentX = (X + W) * mEchelle
        dCurrentY = (Y + H) * mEchelle

    End Sub

    'Renvoi la largeur de l'image passée en parametre
    Public Function PDFImageWidth(ByRef pFileName As String) As Integer
        Return PDFParseJPG(pFileName).Width
    End Function

    'Renvoi la hauteur de l'image passée en parametre
    Public Function PDFImageHeight(ByRef pFileName As String) As Integer
        Return PDFParseJPG(pFileName).Height
    End Function

    'Analyse d'un fichier JPG
    Private Overloads Function PDFParseJPG(ByRef sFileName As String) As aIMG

        'On commenr par vérifier l'extension du fichier
        Dim sExt As String = System.IO.Path.GetExtension(sFileName)
        If InStr(sFileName, ".") = 0 Then
            MsgBox("Le fichier image " & sFileName & " ne possède pas d'extension." & vbNewLine & "Impossible d'inclure l'image dans le fichier PDF.", MsgBoxStyle.Critical, "Fichier Image - " & wsPDFVersion)
            Return New aIMG
        ElseIf (sExt <> ".jpg") And (sExt <> ".jpeg") Then
            MsgBox("Format d'image non supportée." & vbNewLine & "Seule les images de types JPG sont supportées." & vbNewLine & "Impossible d'inclure l'image dans le fichier PDF.", MsgBoxStyle.Critical, "Fichier Image - " & wsPDFVersion)
            Return New aIMG
        End If

        'on lit le fichier en binaire
        Dim bArray(FileLen(sFileName) - 1) As Byte
        Dim iJPGFile As Integer = FreeFile()
        FileOpen(iJPGFile, sFileName, OpenMode.Binary, OpenAccess.Read)
        FileGet(iJPGFile, CType(bArray, Byte()))
        FileClose(iJPGFile)

        'On récupère les données
        Return PDFParseJPG(bArray)

    End Function
    Private Overloads Function PDFParseJPG(ByRef ArrBFile() As Byte) As aIMG

        Dim RetVal As aIMG = New aIMG

        Dim in_PEnd As Integer = UBound(ArrBFile) - 1

        If (PDFIntAsHex(ArrBFile, 0) <> "FFD8") Or _
           (PDFIntAsHex(ArrBFile, in_PEnd) <> "FFD9") Then
            MsgBox("Marqueur de début JPEG ou marqueur de fin JPEG non valide." & vbNewLine & "Impossible d'inclure l'image dans le fichier PDF.", MsgBoxStyle.Critical, "Fichier Image - " & wsPDFVersion)
            Return New aIMG
        End If

        RetVal.Size = UBound(ArrBFile)

        Dim iIndex As Integer = 2
        Do While iIndex < in_PEnd

            Dim sSegmMk As String = PDFIntAsHex(ArrBFile, iIndex)
            Dim iSegmSize As Integer = PDFIntVal(ArrBFile, iIndex + 2)

            Select Case sSegmMk
                Case "FFFF"
                    Do While ArrBFile(iIndex + 1) = &HFF
                        iIndex += 1
                    Loop
                    iSegmSize = PDFIntVal(ArrBFile, iIndex + 2)

                Case "FFE0"
                    Dim bChar As Byte = ArrBFile(iIndex + 11)
                    Select Case bChar
                        Case 0
                            RetVal.Resolution = "Dots"
                        Case 1
                            RetVal.Resolution = "Dots/inch (DPI)"
                        Case 2
                            RetVal.Resolution = "Dots/cm"
                        Case Else
                            MsgBox("Erreur de résolution d'image , l'Opcode est " & bChar & "Les Opcodes valides sont  0, 1, 2." & vbNewLine & "Impossible d'inclure l'image dans le fichier PDF.", MsgBoxStyle.Critical, "Fichier Image - " & wsPDFVersion)
                            Return New aIMG
                    End Select

                Case "FFC0", "FFC1", "FFC2", "FFC3", "FFC5", "FFC6", "FFC7"
                    RetVal.Width = PDFIntVal(ArrBFile, iIndex + 7)
                    RetVal.Height = PDFIntVal(ArrBFile, iIndex + 5)
                    Dim in_TmpColor As Integer = ArrBFile(iIndex + 9) * 8
                    Select Case in_TmpColor
                        Case 8
                            RetVal.ColorSpace = "DeviceGray"
                        Case 24
                            RetVal.ColorSpace = "DeviceRGB"
                        Case 32
                            RetVal.ColorSpace = "DeviceCMYK"
                        Case Else
                            RetVal.BitsPerComponent = in_TmpColor
                    End Select

            End Select

            iIndex += iSegmSize + 2
        Loop

        Dim iBPC As Integer
        If RetVal.BitsPerComponent <> 0 Then
            iBPC = RetVal.BitsPerComponent
        Else
            iBPC = 8
            RetVal.BitsPerComponent = 8
        End If

        RetVal.DCTDecode = "DCTDecode"

        'Dim sTChar As String = vbNullString
        'For i As Integer = 0 To UBound(ArrBFile)
        ' sTChar += Chr(ArrBFile(i))
        ' Next i
        ' RetVal.Stream = sTChar

        RetVal.Stream = System.Text.Encoding.Default.GetString(ArrBFile)

        'MsgBox(Len(RetVal.Stream))
        Return RetVal

    End Function
    Private Function PDFIntAsHex(ByRef ArrBF() As Byte, ByRef Index As Integer) As String
        Return Right("00" & Hex(ArrBF(Index)), 2) & Right("00" & Hex(ArrBF(Index + 1)), 2)
    End Function
    Private Function PDFIntVal(ByRef ArrBF() As Byte, ByRef Index As Integer) As Integer
        PDFIntVal = CInt(ArrBF(Index)) * 256 + CInt(ArrBF(Index + 1))
    End Function

#End Region

#Region "GESTION DES POLICES"

    'Charge les polices une fois pour toute
    Public Sub PDFLoadAFM()
        ReDim ArrFontAFM(UBound(ArrFontsNames))
        For i As Integer = 0 To UBound(ArrFontsNames)
            With ArrFontAFM(i)
                .ID = ArrFontsNames(i)
                .Name = GetFontName(i)
                .CharSize = GetCharSize(i)
            End With
        Next i
    End Sub
    Private Function GetFontName(ByVal ID As Integer) As String
        'Dim sFont As String = My.Resources.LoadResString(ArrFontAFM(ID).ID)
        Dim sFont As String = ArrFontAFM(ID).ID
        Return sFont
        Dim iStart As Integer = InStr(1, sFont, "FontName ", CompareMethod.Text) + Len("FontName ")
        Dim iLen As Integer = InStr(iStart, sFont, "FullName", CompareMethod.Text) - iStart - 2
        Return Mid(sFont, iStart, iLen)
    End Function
    Private Function GetCharSize(ByVal ID As Integer) As Integer()

        Dim iAscMin As Integer = 0
        Dim iAscMax As Integer = 0

        Dim ArrFNT(255) As Integer
        Dim bWX As Boolean = False
        Dim aAsc() As String = {}

        'On découpe les lignes
        'Dim sLines() As String = Split(My.Resources.LoadResString(ArrFontAFM(ID).ID), vbCrLf)
        Dim sLines() As String = Split(ArrFontAFM(ID).ID, vbCrLf)

        'On parcour toutes les lignes
        For i As Integer = 0 To UBound(sLines)
            Dim sLine As String = sLines(i)

            If InStr(sLine, "StartCharMetrics") <> 0 Then
                bWX = True
                i += 1
                sLine = sLines(i)
            End If

            If InStr(sLine, "-1 ;") <> 0 Or _
               InStr(sLine, "EndCharMetrics") <> 0 Then
                iAscMax = aAsc(1)
                Exit For
            End If

            If bWX = True Then
                Dim aTempFNT() As String = Split(sLine, ";")
                aAsc = Split(Trim(aTempFNT(0)), " ")
                If iAscMin = 0 Then
                    iAscMin = aAsc(1)
                End If

                Dim aWX() As String = Split(Trim(aTempFNT(1)), " ")
                ArrFNT(aAsc(1)) = Int(CDbl(aWX(1)))
            End If

        Next i

        For i As Integer = 1 To 255
            If (i < iAscMin) Or (i > iAscMax) Then
                ArrFNT(i) = 0
            End If
        Next i

        Return ArrFNT

    End Function

    'Renvoi la largeur d'un text en fonction de sa police
    Public Function PDFGetStringWidth(ByRef sText As String, Optional ByRef sFontName As String = vbNullString, Optional ByRef iFSize As Integer = 0) As Double

        If sFontName = vbNullString Then
            sFontName = PDFFontName
        End If

        'On recherche le numéro de la police
        Dim iFont As Integer = 0
        For i As Integer = 0 To UBound(ArrFontAFM)
            If ArrFontAFM(i).Name = sFontName Then
                iFont = i
                Exit For
            End If
        Next

        'On calcul la longueur de la chaine
        Dim iTempSize As Integer = 0
        For i As Integer = 1 To Len(sText)
            Dim iAsc As Integer = Asc(Mid(sText, i, 1))
            iTempSize += Int(ArrFontAFM(iFont).CharSize(iAsc))
        Next i

        PDFGetStringWidth = (iTempSize * iFSize) / 1000

    End Function

    'Définition de la police à utiliser
    Public Sub PDFSetFont(ByRef FontName As PDFFontNme, ByRef FontSize As Integer, Optional ByRef Style As PDFFontStl = 0)

        'On mémorise s'il faut souligné le texte
        If Style >= PDFFontStl.FONT_UNDERLINE Then
            bPDFUnderline = True
            Style -= PDFFontStl.FONT_UNDERLINE
        Else
            bPDFUnderline = False
        End If

        'Puis s'il doit être gras
        Dim bBold As Boolean = False
        If Style >= PDFFontStl.FONT_BOLD Then
            bBold = True
            Style -= PDFFontStl.FONT_BOLD
        End If

        'Et/ou en italique
        Dim bItalic As Boolean = False
        If Style >= PDFFontStl.FONT_ITALIC Then
            bItalic = True
            Style -= PDFFontStl.FONT_ITALIC
        End If

        'On récupère le nom de base de la police
        Dim sTmpFontName As String = vbNullString
        Select Case FontName
            Case PDFFontNme.FONT_ARIAL
                sTmpFontName = "Helvetica"
            Case PDFFontNme.FONT_COURIER
                sTmpFontName = "Courier"
            Case PDFFontNme.FONT_TIMES
                sTmpFontName = "Times"
            Case PDFFontNme.FONT_SYMBOL
                sTmpFontName = "Symbol"
            Case PDFFontNme.FONT_ZAPFDINGBATS
                sTmpFontName = "ZapfDingbats"
        End Select

        'Puis on récupère le nom complet
        If bItalic And bBold Then                   'GRAS + ITALIQUE

            Select Case sTmpFontName
                Case "Courier", "Helvetica"
                    sTmpFontName += "-BoldOblique"
                Case "Times"
                    sTmpFontName += "-BoldItalic"
            End Select

        ElseIf bItalic Then                         'JUSTE ITALIQUE

            Select Case sTmpFontName
                Case "Courier", "Helvetica"
                    sTmpFontName += "-Oblique"
                Case "Times"
                    sTmpFontName += "-Italic"
            End Select

        ElseIf bBold Then                           'JUSTE GRAS

            Select Case sTmpFontName
                Case "Courier", "Helvetica", "Times"
                    sTmpFontName += "-Bold"
            End Select

        ElseIf sTmpFontName = "Times" Then          'TIMES NORMAL

            sTmpFontName += "-Roman"

        End If

        'On transmet le résultat
        PDFFontName = sTmpFontName
        PDFFontSize = FontSize

    End Sub

#End Region

#Region "FONCTIONS ET PROCEDURES DIVERSES"

    'Initialisation de la class
    Public Sub New()
        MyBase.New()
        PDFInit()
    End Sub
    Public Sub PDFInit()

        Dim PDFMargin As Integer = mEchelle / 28.35

        'On charge les différentes polices
        If sPathConfiguration = vbNullString Then
            sPathConfiguration = Application.StartupPath
        End If
        PDFLoadAFM()

        ' Marges de la page (1 cm)
        PDFSetMargins(PDFMargin, PDFMargin)
        ' Marge interieure des cellules (1 mm)
        PDFCellMargin = mEchelle * (PDFMargin / 10)
        ' Largeur de ligne (0.2 mm)
        PDFLineWidth = 0.567

        dCurrentX = mPDFLeftMargin
        dCurrentY = mPDFTopMargin

        ' Format d'orientation de page par défaut : A4
        ReDim Preserve PDFCanvasWidth(iCanvas)
        ReDim Preserve PDFCanvasHeight(iCanvas)
        ReDim Preserve PDFCanvasOrientation(iCanvas)

        PDFCanvasWidth(iCanvas) = 595.28
        PDFCanvasHeight(iCanvas) = 841.89
        PDFCanvasOrientation(iCanvas) = "p"

    End Sub

    'Definition des marges
    Public Sub PDFSetMargins(ByRef iLeft As Integer, ByRef iTop As Integer, Optional ByRef iRight As Integer = -1, Optional ByRef iBottom As Integer = -1)
        mPDFLeftMargin = iLeft
        mPDFTopMargin = iTop
        If iRight = -1 Then
            mPDFRightMargin = iLeft
        Else
            mPDFRightMargin = iRight
        End If
        If iBottom = -1 Then
            mPDFBottomMargin = iTop
        Else
            mPDFBottomMargin = iBottom
        End If
    End Sub

    'Renvoi un code couleur compatible PDF à partir d'un RGB
    Private Function PDFStreamColor(ByRef PDFColor As System.Drawing.Color, ByRef sType As String) As String

        Dim sPDFStreamColor As String = Replace(Format(PDFColor.R / 255, "0.000"), ",", ".") & " " & _
                                        Replace(Format(PDFColor.G / 255, "0.000"), ",", ".") & " " & _
                                        Replace(Format(PDFColor.B / 255, "0.000"), ",", ".") & " "
        Select Case sType
            Case "TEXT", "BORDER"
                sPDFStreamColor += "rg"
            Case "LINE"
                sPDFStreamColor += "RG"
        End Select
        Return sPDFStreamColor
    End Function

    'Créé un lien HyperLink
    Private bPDFImage As Boolean = False
    Private Sub PDFSetLink(ByRef URLLink As String, ByRef OType As String, ByRef X As Double, ByRef Y As Double)

        If OType = "IMAGE" Then
            bPDFImage = True
        Else
            bPDFImage = False
        End If

        If URLLink <> vbNullString Then
            PDFLink(X, Y, URLLink)
        End If
        sTLink = vbNullString
        bPDFImage = False

    End Sub
    Public Sub PDFLink(ByRef X As Double, ByRef Y As Double, ByRef sText As String, Optional ByRef sLink As String = vbNullString)

        Dim W, H As Double

        PDFOutStream(sTempStream, "%DEBUT_LINK/%")

        bPDFUnderline = True

        If bPDFImage = True Then
            PDFTextColor = Color.Blue
            W = Int(ImgWidth)
            H = Int(ImgHeight)
            PDFTextOut(vbNullString, X, Y)
        Else
            Select Case sTyLink
                Case "ELLIPSE"
                    W = Int(PDFGetStringWidth(sTLink, PDFFontName, PDFFontSize))
                    H = Int(PDFFontSize)
                    PDFTextOut(vbNullString, X, Y)
                Case "RECTANGLE"
                    W = wRect
                    H = Int(PDFFontSize)
                    PDFTextOut(vbNullString, X, Y)
                Case "CELL"
                    W = Int(PDFGetStringWidth(sTLink, PDFFontName, PDFFontSize))
                    H = Int(PDFFontSize)
                    PDFTextOut(vbNullString, X, Y)
                Case Else
                    W = Int(PDFGetStringWidth(sText, PDFFontName, PDFFontSize))
                    H = Int(PDFFontSize)
                    PDFTextOut(sText, X, Y)
            End Select
        End If

        bPDFImage = False
        bPDFUnderline = False

        sTyLink = vbNullString
        If sLink = vbNullString Then
            sLink = sText
        End If

        PDFTabLinks(X, Y, W, H, sText, sLink)

        PDFOutStream(sTempStream, "%FIN_LINK/%")

    End Sub

    'Memorise les parametres d'un lien
    Private Sub PDFTabLinks(ByRef X As Double, ByRef Y As Double, ByRef W As Integer, ByRef H As Integer, ByRef sText As String, Optional ByRef sLink As String = "Null")

        FPageLink += 1

        PageLinksList(FPageNumber, FPageLink) = New ArrayList

        With PageLinksList(FPageNumber, FPageLink)
            .Add(X * mEchelle)
            .Add(PDFCanvasHeight(iCanvas) - Y * mEchelle)
            .Add(W * mEchelle)
            .Add(H * mEchelle)
            If sLink <> "Null" Then
                .Add(sLink)
            Else
                .Add(sText)
            End If
        End With

        ReDim Preserve bPageLinksList(FPageNumber)
        ReDim Preserve NbPageLinksList(FPageNumber)

        bPageLinksList(FPageNumber) = True
        NbPageLinksList(FPageNumber) = FPageLink

    End Sub

    'Compte le nombre de fois où l'on rencontre un caractere
    Private Function PDFGetNumberOfCar(ByRef sText As String, ByRef sCar As String) As Integer
        Dim iCount As Integer = 0
        Dim i As Integer = InStr(sText, sCar)
        If i <> 0 Then
            iCount = 1
        End If
        Do While i <> 0
            i = InStr(i + 1, sText, sCar)
            If i <> 0 Then
                iCount = iCount + 1
            End If
        Loop
        Return iCount
    End Function

    'Debut du document
    Public Sub PDFBeginDoc()
        PDFSetHeader()
        PDFSetDocInfo()
        PDFStartStream()
    End Sub
    Private Sub PDFSetHeader()
        CurrentObjectNum = 0
        PrintLine(iFile, "%PDF-" & wsPDF)
        PDFAddToOffset(Len("%PDF-" & wsPDF))
    End Sub
    Private Sub PDFSetDocInfo()

        CurrentObjectNum = CurrentObjectNum + 1
        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<<")
        PDFOutStream(TempStream, "/Producer (" & FProducer & ")")
        PDFOutStream(TempStream, "/Author (" & FAuthor & ")")
        PDFOutStream(TempStream, "/CreationDate (D:" & Format(Now, "YYYYMMDDHHmmSS") & ")")
        PDFOutStream(TempStream, "/Creator (" & FCreator & ")")
        PDFOutStream(TempStream, "/Keywords (" & FKeywords & ")")
        PDFOutStream(TempStream, "/Subject (" & FSubject & ")")
        PDFOutStream(TempStream, "/Title (" & FTitle & ")")
        PDFOutStream(TempStream, "/ModDate ()")
        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFStartStream()

        ContentNum = CurrentObjectNum
        CurrentObjectNum += 1

        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<< /Length " & (CurrentObjectNum + 1) & " 0 R")
        PDFOutStream(TempStream, " >>")

        StreamSize = Len(TempStream)

        PDFOutStream(TempStream, "stream")
        sTempStream = vbNullString

    End Sub

    'Finalise le document
    Public Sub PDFEndDoc()

        PDFEndStream()
        PDFSetFontType()
        PDFSetPages()
        PDFSetArray()

        For i As Integer = 1 To NumberofImages
            PDFWriteImage((i))
        Next i

        For i As Integer = 1 To FPageNumber
            PDFSetPageObject((i))
        Next i

        PDFSetBookmarks()

        PDFSetCatalog()
        PDFSetXref()

        PrintLine(iFile, "%%EOF")
        FileClose(iFile)

        If mPDFConfirm Then
            MsgBox("Fichier PDF généré.", MsgBoxStyle.OKOnly, "Génération du Fichier PDF - " & wsPDFVersion)
        End If

        If mPDFView Then
            Dim MyProcess As System.Diagnostics.Process = System.Diagnostics.Process.Start(FFileName)
            If mPDFWaitForExit Then
                MyProcess.WaitForExit()
            End If
            MyProcess.Close()
        End If

    End Sub
    Private Sub PDFSetPageObject(ByRef iPage As Integer)

        ContentNum += 1
        CurrentObjectNum += 1
        TempStream = vbNullString

        ReDim Preserve aPage(iPage)
        aPage(iPage) = CurrentObjectNum

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<< /Type /Page")

        PDFOutStream(TempStream, "/Parent " & ParentNum & " 0 R")
        PDFOutStream(TempStream, "/MediaBox [ 0 0 " & PageCanvasWidth(CurrentPDFSetPageObject + 1) & " " & PageCanvasHeight(CurrentPDFSetPageObject + 1) & "]")
        PDFOutStream(TempStream, "/Resources " & ResourceNum & " 0 R")


        If bPageLinksList(iPage) = True Then

            Dim sAnnots As String = "/Annots ["

            For i As Integer = 1 To NbPageLinksList(iPage)

                With PageLinksList(iPage, i)

                    Dim str_Rect As String = CStr(.Item(0)) & " " & _
                               CStr(.Item(1)) & " " & _
                               CStr(.Item(0) + .Item(2)) & " " & _
                               CStr(.Item(1) - .Item(3))

                    sAnnots += "<</Type /Annot /Subtype /Link /Rect [" & str_Rect & "] /Border [0 0 0] "

                    If .Item(4) <> vbNullString Then
                        Dim sTmpAnnots As String = .Item(4)
                        sTmpAnnots = Replace(sTmpAnnots, "\", "\\")
                        sTmpAnnots = Replace(sTmpAnnots, "\\", "\\\\")
                        sTmpAnnots = Replace(sTmpAnnots, "(", "\(")
                        sTmpAnnots = Replace(sTmpAnnots, ")", "\)")

                        sAnnots += "/A <</S /URI /URI (" & sTmpAnnots & ")>>>>" & vbCr & vbLf
                    End If

                End With

            Next i

            PDFOutStream(TempStream, sAnnots & "]")

        End If


        PDFOutStream(TempStream, "/Contents " & PageNumberList(CurrentPDFSetPageObject + 1) & " 0 R")
        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))

        PrintLine(iFile, TempStream)

        CurrentPDFSetPageObject += 1

    End Sub
    Private Sub PDFWriteImage(ByRef in_Img As Integer)

        CurrentObjectNum = CurrentObjectNum + 1
        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")

        Dim ImageStream As String = vbNullString

        PDFOutStream(ImageStream, "<</Type /XObject")
        PDFOutStream(ImageStream, "/Subtype /Image")
        PDFOutStream(ImageStream, "/Filter [/DCTDecode ]")
        PDFOutStream(ImageStream, "/Width " & ArrIMG(in_Img).Width)
        PDFOutStream(ImageStream, "/Height " & ArrIMG(in_Img).Height)
        PDFOutStream(ImageStream, "/ColorSpace /" & ArrIMG(in_Img).ColorSpace)
        PDFOutStream(ImageStream, "/BitsPerComponent " & ArrIMG(in_Img).BitsPerComponent)
        PDFOutStream(ImageStream, "/Length " & Len(ArrIMG(in_Img).Stream))
        PDFOutStream(ImageStream, "/Name /ImgJPEG" & in_Img & ">>")
        PDFOutStream(ImageStream, "stream")
        PDFOutStream(ImageStream, ArrIMG(in_Img).Stream)
        PDFOutStream(ImageStream, "endstream")
        PDFOutStream(ImageStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        TempStream += ImageStream

        PDFAddToOffset(Len(TempStream))

        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFSetArray()

        CurrentObjectNum += 1
        ResourceNum = CurrentObjectNum

        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<< /ProcSet [ /PDF /Text /ImageC]")
        PDFOutStream(TempStream, "/XObject << ")

        For i As Integer = 1 To NumberofImages
            PDFOutStream(TempStream, "/ImgJPEG" & i & " " & (CurrentObjectNum + i) & " 0 R")
        Next i

        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "/Font << ")

        For i As Integer = 1 To FontNumber
            PDFOutStream(TempStream, "/F" & i & " " & FontNumberList(i) & " 0 R ")
        Next i

        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFSetFontType()
        'On inscrit chaque police
        For i As Integer = 0 To UBound(ArrFontAFM)
            PDFCreateFont("Type1", ArrFontAFM(i).Name, "WinAnsiEncoding")
        Next
    End Sub
    Private Sub PDFCreateFont(ByRef SubType As String, ByRef BaseFont As String, ByRef Encoding As String)

        FontNumber += 1
        CurrentObjectNum += 1

        ReDim Preserve FontNumberList(iFontNum)
        FontNumberList(iFontNum) = CurrentObjectNum
        iFontNum += 1

        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<< /Type /Font")
        PDFOutStream(TempStream, "/Subtype /" & SubType)
        PDFOutStream(TempStream, "/Name /F" & FontNumber)
        PDFOutStream(TempStream, "/BaseFont /" & BaseFont)
        PDFOutStream(TempStream, "/Encoding /" & Encoding)
        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))

        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFSetPages()

        CurrentObjectNum = CurrentObjectNum + 1
        ParentNum = CurrentObjectNum
        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<< /Type /Pages")
        PDFOutStream(TempStream, "/Kids [")

        Dim PageObjNum As Integer = 2
        For i As Integer = 1 To FPageNumber
            PDFOutStream(TempStream, (CurrentObjectNum + i + 1 + NumberofImages) & " 0 R")

            ReDim Preserve PageNumberList(iPagesNum)
            ReDim Preserve PageCanvasHeight(iPagesNum)
            ReDim Preserve PageCanvasWidth(iPagesNum)

            ReDim Preserve bPageLinksList(FPageNumber)
            ReDim Preserve NbPageLinksList(FPageNumber)

            PageCanvasHeight(iPagesNum) = PDFCanvasHeight(iPagesNum)
            PageCanvasWidth(iPagesNum) = PDFCanvasWidth(iPagesNum)

            PageNumberList(iPagesNum) = PageObjNum
            iPagesNum += 1

            PageObjNum += 2
        Next i

        PDFOutStream(TempStream, "]")
        PDFOutStream(TempStream, "/Count " & FPageNumber)
        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFSetCatalog()

        CurrentObjectNum = CurrentObjectNum + 1
        CatalogNum = CurrentObjectNum
        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<<")
        PDFOutStream(TempStream, "/Type /Catalog")
        PDFOutStream(TempStream, "/Pages " & ParentNum & " 0 R")

        Select Case mPDFZoomMode
            Case PDFZoomMd.ZOOM_FULLPAGE
                PDFOutStream(TempStream, "/OpenAction [3 0 R /Fit]")
            Case PDFZoomMd.ZOOM_FULLWIDTH
                PDFOutStream(TempStream, "/OpenAction [3 0 R /FitH null]")
            Case PDFZoomMd.ZOOM_REAL
                PDFOutStream(TempStream, "/OpenAction [3 0 R /XYZ null null 1]")
            Case PDFZoomMd.ZOOM_DEFAULT
                PDFOutStream(TempStream, "/OpenAction [3 0 R /XYZ null null " & PDFFormatDouble(100 / 100) & "]")
        End Select

        Select Case mPDFLayoutMode
            Case PDFLayoutMd.LAYOUT_SINGLE
                PDFOutStream(TempStream, "/PageLayout /SinglePage")
            Case PDFLayoutMd.LAYOUT_CONTINOUS
                PDFOutStream(TempStream, "/PageLayout /OneColumn")
            Case PDFLayoutMd.LAYOUT_TWO
                PDFOutStream(TempStream, "/PageLayout /TwoColumnLeft")
        End Select

        If mPDFUseThumbs = True Then
            PDFOutStream(TempStream, "/PageMode /UseThumbs")
        End If

        If mPDFUseOutlines = True Then
            PDFOutStream(TempStream, "/Outlines " & iOutlines & " 0 R")
            PDFOutStream(TempStream, "/PageMode /UseOutlines")
        End If

        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFEndStream()

        TempStream += sTempStream
        sTempStream = vbNullString

        PDFOutStream(TempStream, "endstream")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        Dim StreamSize2 As Integer = 6

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

        Dim TempSize As Integer = Len(TempStream) - StreamSize - StreamSize2 - Len("Stream") - Len("endstream") - 6
        ContentNum = CurrentObjectNum
        CurrentObjectNum = CurrentObjectNum + 1
        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, CStr(TempSize))
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

    End Sub
    Private Sub PDFSetXref()

        CurrentObjectNum = CurrentObjectNum + 1
        TempStream = vbNullString

        PDFOutStream(TempStream, "xref")
        PDFOutStream(TempStream, "0 " & CurrentObjectNum)
        PDFOutStream(TempStream, "0000000000 65535 f")

        For i As Integer = 1 To CurrentObjectNum - 1
            PDFOutStream(TempStream, PDFGetOffsetNumber(Trim(ObjectOffsetList(i))) & " 00000 n")
        Next i

        PDFOutStream(TempStream, "trailer")
        PDFOutStream(TempStream, "<< /Size " & CurrentObjectNum)
        PDFOutStream(TempStream, "/Root " & CatalogNum & " 0 R")
        PDFOutStream(TempStream, "/Info 1 0 R")
        PDFOutStream(TempStream, ">>")
        PDFOutStream(TempStream, "startxref")
        PDFOutStream(TempStream, Trim(ObjectOffsetList(CurrentObjectNum)))

        PrintLine(iFile, TempStream)

    End Sub
    Private Function PDFGetOffsetNumber(ByRef OffSet As String) As String
        Dim sReturn As String = vbNullString
        Dim X As Integer = Len(OffSet)
        For Y As Integer = 1 To 10 - X
            sReturn += "0"
        Next Y
        Return sReturn & OffSet
    End Function

    'Cloture une page
    Public Sub PDFEndPage()

        iCanvas = iCanvas + 1

        ReDim Preserve PDFCanvasWidth(iCanvas)
        ReDim Preserve PDFCanvasHeight(iCanvas)
        ReDim Preserve PDFCanvasOrientation(iCanvas)

        If PDFCanvasWidth(iCanvas) = vbNullString Then
            PDFCanvasWidth(iCanvas) = PDFCanvasWidth(iCanvas - 1)
            PDFCanvasHeight(iCanvas) = PDFCanvasHeight(iCanvas - 1)
            PDFCanvasOrientation(iCanvas) = PDFCanvasOrientation(iCanvas - 1)
        End If

    End Sub

    'Créé une nouvelle page
    Public Sub PDFNewPage()

        dCurrentX = mPDFLeftMargin
        dCurrentY = mPDFTopMargin

        FPageNumber += 1
        FPageLink = 0

        TempStream += sTempStream
        sTempStream = vbNullString

        PDFOutStream(TempStream, "endstream")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        Dim StreamSize2 As Integer = 6

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

        Dim TempSize As Integer = Len(TempStream) - StreamSize - StreamSize2 - Len("Stream") - Len("endstream") - 6

        ContentNum = CurrentObjectNum
        CurrentObjectNum += 1

        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, CStr(TempSize))
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

        ContentNum = CurrentObjectNum
        CurrentObjectNum = CurrentObjectNum + 1

        TempStream = vbNullString

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
        PDFOutStream(TempStream, "<< /Length " & (CurrentObjectNum + 1) & " 0 R")

        PDFOutStream(TempStream, " >>")

        StreamSize = Len(TempStream)

        PDFOutStream(TempStream, "stream")

    End Sub

    'Créé un soulignement
    Private Function PDFUnderline(ByRef bCell As Boolean, ByRef sText As String, ByRef X As Double, ByRef Y As Double) As String

        Dim iWidhtUp As Double = PDFGetStringWidth("up", PDFFontName, PDFFontSize)
        Dim iWidhtUt As Double = 2

        Dim iNbSpace As Integer = PDFGetNumberOfCar(sText, " ")

        Dim iTextWidth As Double = PDFGetStringWidth(sText, PDFFontName, PDFFontSize) + iNbSpace * PDFGetStringWidth(" ", PDFFontName, PDFFontSize) + iWidthStr * iNbSpace - IIf(iWidthStr <> 0, (iNbSpace + 1) * mPDFCellMargin, 0)

        Dim iPx As Double = X + mPDFLeftMargin * mEchelle
        Dim iPw As Double = (PDFCanvasHeight(iCanvas) - (Y - iWidhtUp / 1000 * PDFFontSize) - 2)
        Dim iPy As Double = -iWidhtUt / 1000 * iTextWidth

        Dim sHLine As String = PDFFormatDouble(iPy)

        Dim sLeftX, sTopY, sWidthT As String
        If bCell = False Then
            sWidthT = PDFFormatDouble(iTextWidth)
            sLeftX = PDFFormatDouble(iPx)
            sTopY = PDFFormatDouble(iPw)
        Else
            sWidthT = PDFFormatDouble(CDbl(iTextWidth) - mPDFCellMargin)
            sLeftX = PDFFormatDouble(X)
            sTopY = PDFFormatDouble(Y - 3)
        End If

        Dim sTmpUnderL As String = sLeftX & " " & sTopY & " " & sWidthT & " " & sHLine & " re f"

        Return sTmpUnderL

    End Function

    'Ajoute une ligne au stream
    Private Sub PDFOutStream(ByRef MS As String, ByRef S As String)
        MS += S & vbCrLf
    End Sub

    '???
    Private Sub PDFAddToOffset(ByRef OffSet As Integer)
        ReDim Preserve ObjectOffsetList(iOffset)
        ObjectOffset += OffSet
        ObjectOffsetList(iOffset) = ObjectOffset
        iOffset += 1
    End Sub


    'Pour formater un valeur avec un certain nombre de 0 en décimal
    Private Function PDFFormatDouble(ByRef Value As Double, Optional ByRef nZero As Integer = 2) As String
        Dim sZero As String = New String("0", nZero)
        Return Replace(Format(Value, "###0." & sZero), ",", ".")
    End Function

    'Permet la création de signets
    Public Sub PDFSetBookmark(ByRef sText As String, Optional ByRef iLevel As Integer = 0, Optional ByRef Y As Double = -1)

        If Y = -1 Then
            Y = dCurrentY
        End If

        ReDim Preserve aOutlines(iOutlines)

        aOutlines(iOutlines).sText = sText
        aOutlines(iOutlines).iLevel = iLevel
        aOutlines(iOutlines).yPos = Y
        aOutlines(iOutlines).iPageNb = PDFPageNumber

        iOutlines = iOutlines + 1

    End Sub
    Private Sub PDFSetBookmarks()

        Dim iNbBookMrk As Integer
        Dim aTemp() As Integer = {}
        Dim iLevel As Integer
        Dim iParent As Integer
        Dim iPrev As Integer
        Dim iNb As Integer
        Dim iPageOut As Integer

        Try
            iNbBookMrk = UBound(aOutlines)
        Catch ex As Exception
            Exit Sub
        End Try

        If iNbBookMrk = 0 Then
            Exit Sub
        End If

        iLevel = 0
        For i As Integer = 0 To iNbBookMrk
            If aOutlines(i).iLevel > 0 Then
                iParent = aTemp(aOutlines(i).iLevel - 1)

                aOutlines(i).iParent = iParent
                aOutlines(iParent).iLast = i
                aOutlines(i).bLast = True

                If aOutlines(i).iLevel > iLevel Then
                    aOutlines(iParent).iFirst = i
                    aOutlines(iParent).bFirst = True
                End If
            Else
                aOutlines(i).iParent = iNbBookMrk + 1
            End If

            If aOutlines(i).iLevel <= iLevel And i > 1 Then
                iPrev = aTemp(aOutlines(i).iLevel)
                aOutlines(iPrev).iNext = i
                aOutlines(iPrev).bNext = True
                aOutlines(i).iPrev = iPrev
                aOutlines(i).bPrev = True
            End If

            ReDim Preserve aTemp(aOutlines(i).iLevel)
            aTemp(aOutlines(i).iLevel) = i
            iLevel = aOutlines(i).iLevel
        Next i

        iNb = CurrentObjectNum + 1
        For i As Integer = 0 To iNbBookMrk
            CurrentObjectNum = CurrentObjectNum + 1
            TempStream = vbNullString

            PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
            PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")
            PDFOutStream(TempStream, "<</Title (" & aOutlines(i).sText & ")")
            PDFOutStream(TempStream, "/Parent " & (iNb + aOutlines(i).iParent) & " 0 R")

            If aOutlines(i).bPrev Then
                PDFOutStream(TempStream, "/Prev " & (iNb + aOutlines(i).iPrev) & " 0 R")
            End If
            If aOutlines(i).bNext Then
                PDFOutStream(TempStream, "/Next " & (iNb + aOutlines(i).iNext) & " 0 R")
            End If
            If aOutlines(i).bFirst Then
                PDFOutStream(TempStream, "/First " & (iNb + aOutlines(i).iFirst) & " 0 R")
            End If
            If aOutlines(i).bLast Then
                PDFOutStream(TempStream, "/Last " & (iNb + aOutlines(i).iLast) & " 0 R")
            End If

            iPageOut = aPage(aOutlines(i).iPageNb)

            PDFOutStream(TempStream, "/Dest [" & iPageOut & " 0 R /XYZ 0 " & PDFFormatDouble(PDFCanvasHeight(aOutlines(i).iPageNb) - aOutlines(i).yPos * mEchelle) & " null]")
            PDFOutStream(TempStream, "/Count 0>>")
            PDFOutStream(TempStream, "endobj")
            PDFOutStream(sTempStream, "%FIN_OBJ/%")

            PDFAddToOffset(Len(TempStream))
            PrintLine(iFile, TempStream)
        Next i

        CurrentObjectNum = CurrentObjectNum + 1
        TempStream = vbNullString
        iOutlines = CurrentObjectNum

        PDFOutStream(sTempStream, "%DEBUT_OBJ/%")
        PDFOutStream(TempStream, CurrentObjectNum & " 0 obj")

        PDFOutStream(TempStream, "<</Type /Outlines /First " & iNb & " 0 R")
        PDFOutStream(TempStream, "/Last " & (iNb + aTemp(1)) & " 0 R>>")
        PDFOutStream(TempStream, "endobj")
        PDFOutStream(sTempStream, "%FIN_OBJ/%")

        PDFAddToOffset(Len(TempStream))
        PrintLine(iFile, TempStream)

    End Sub

#End Region

End Class
