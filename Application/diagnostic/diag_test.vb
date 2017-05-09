Public Class diag_test
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel27 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel28 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel30 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Panel31 As System.Windows.Forms.Panel
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Panel32 As System.Windows.Forms.Panel
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Panel33 As System.Windows.Forms.Panel
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Panel34 As System.Windows.Forms.Panel
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Panel35 As System.Windows.Forms.Panel
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Panel36 As System.Windows.Forms.Panel
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Panel37 As System.Windows.Forms.Panel
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Panel38 As System.Windows.Forms.Panel
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Panel39 As System.Windows.Forms.Panel
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Panel40 As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Panel41 As System.Windows.Forms.Panel
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Panel42 As System.Windows.Forms.Panel
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Panel43 As System.Windows.Forms.Panel
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Panel44 As System.Windows.Forms.Panel
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents Panel45 As System.Windows.Forms.Panel
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents Panel46 As System.Windows.Forms.Panel
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents Panel47 As System.Windows.Forms.Panel
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents Panel48 As System.Windows.Forms.Panel
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents Panel49 As System.Windows.Forms.Panel
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents Panel52 As System.Windows.Forms.Panel
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents Panel53 As System.Windows.Forms.Panel
    Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents Panel54 As System.Windows.Forms.Panel
    Friend WithEvents TextBox31 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox32 As System.Windows.Forms.TextBox
    Friend WithEvents Panel55 As System.Windows.Forms.Panel
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox34 As System.Windows.Forms.TextBox
    Friend WithEvents Panel56 As System.Windows.Forms.Panel
    Friend WithEvents TextBox35 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox36 As System.Windows.Forms.TextBox
    Friend WithEvents Panel57 As System.Windows.Forms.Panel
    Friend WithEvents TextBox37 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox38 As System.Windows.Forms.TextBox
    Friend WithEvents Panel58 As System.Windows.Forms.Panel
    Friend WithEvents TextBox39 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox40 As System.Windows.Forms.TextBox
    Friend WithEvents Panel59 As System.Windows.Forms.Panel
    Friend WithEvents TextBox41 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox42 As System.Windows.Forms.TextBox
    Friend WithEvents Panel63 As System.Windows.Forms.Panel
    Friend WithEvents TextBox43 As System.Windows.Forms.TextBox
    Friend WithEvents Panel64 As System.Windows.Forms.Panel
    Friend WithEvents TextBox45 As System.Windows.Forms.TextBox
    Friend WithEvents Panel83 As System.Windows.Forms.Panel
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Panel84 As System.Windows.Forms.Panel
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TextBox44 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox46 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TextBox47 As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox49 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox50 As System.Windows.Forms.TextBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents TextBox51 As System.Windows.Forms.TextBox
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents TextBox53 As System.Windows.Forms.TextBox
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents TextBox55 As System.Windows.Forms.TextBox
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Panel50 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Panel51 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel60 As System.Windows.Forms.Panel
    Friend WithEvents TextBox57 As System.Windows.Forms.TextBox
    Friend WithEvents Panel61 As System.Windows.Forms.Panel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Panel62 As System.Windows.Forms.Panel
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Panel65 As System.Windows.Forms.Panel
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Panel66 As System.Windows.Forms.Panel
    Friend WithEvents TextBox59 As System.Windows.Forms.TextBox
    Friend WithEvents Panel67 As System.Windows.Forms.Panel
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Panel68 As System.Windows.Forms.Panel
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Panel70 As System.Windows.Forms.Panel
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Panel71 As System.Windows.Forms.Panel
    Friend WithEvents TextBox61 As System.Windows.Forms.TextBox
    Friend WithEvents Panel73 As System.Windows.Forms.Panel
    Friend WithEvents TextBox63 As System.Windows.Forms.TextBox
    Friend WithEvents Panel75 As System.Windows.Forms.Panel
    Friend WithEvents TextBox65 As System.Windows.Forms.TextBox
    Friend WithEvents Panel76 As System.Windows.Forms.Panel
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Panel78 As System.Windows.Forms.Panel
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Panel79 As System.Windows.Forms.Panel
    Friend WithEvents TextBox67 As System.Windows.Forms.TextBox
    Friend WithEvents Panel93 As System.Windows.Forms.Panel
    Friend WithEvents TextBox69 As System.Windows.Forms.TextBox
    Friend WithEvents Panel94 As System.Windows.Forms.Panel
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Panel95 As System.Windows.Forms.Panel
    Friend WithEvents TextBox71 As System.Windows.Forms.TextBox
    Friend WithEvents Panel96 As System.Windows.Forms.Panel
    Friend WithEvents TextBox73 As System.Windows.Forms.TextBox
    Friend WithEvents Panel97 As System.Windows.Forms.Panel
    Friend WithEvents TextBox75 As System.Windows.Forms.TextBox
    Friend WithEvents Panel98 As System.Windows.Forms.Panel
    Friend WithEvents TextBox77 As System.Windows.Forms.TextBox
    Friend WithEvents Panel99 As System.Windows.Forms.Panel
    Friend WithEvents TextBox79 As System.Windows.Forms.TextBox
    Friend WithEvents Panel100 As System.Windows.Forms.Panel
    Friend WithEvents TextBox121 As System.Windows.Forms.TextBox
    Friend WithEvents Panel101 As System.Windows.Forms.Panel
    Friend WithEvents TextBox123 As System.Windows.Forms.TextBox
    Friend WithEvents Panel102 As System.Windows.Forms.Panel
    Friend WithEvents TextBox125 As System.Windows.Forms.TextBox
    Friend WithEvents Panel103 As System.Windows.Forms.Panel
    Friend WithEvents TextBox127 As System.Windows.Forms.TextBox
    Friend WithEvents Panel104 As System.Windows.Forms.Panel
    Friend WithEvents TextBox129 As System.Windows.Forms.TextBox
    Friend WithEvents Panel105 As System.Windows.Forms.Panel
    Friend WithEvents TextBox131 As System.Windows.Forms.TextBox
    Friend WithEvents Panel106 As System.Windows.Forms.Panel
    Friend WithEvents TextBox133 As System.Windows.Forms.TextBox
    Friend WithEvents Panel107 As System.Windows.Forms.Panel
    Friend WithEvents TextBox135 As System.Windows.Forms.TextBox
    Friend WithEvents Panel108 As System.Windows.Forms.Panel
    Friend WithEvents TextBox137 As System.Windows.Forms.TextBox
    Friend WithEvents Panel110 As System.Windows.Forms.Panel
    Friend WithEvents TextBox139 As System.Windows.Forms.TextBox
    Friend WithEvents Panel111 As System.Windows.Forms.Panel
    Friend WithEvents TextBox141 As System.Windows.Forms.TextBox
    Friend WithEvents Panel112 As System.Windows.Forms.Panel
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Panel113 As System.Windows.Forms.Panel
    Friend WithEvents TextBox143 As System.Windows.Forms.TextBox
    Friend WithEvents Panel114 As System.Windows.Forms.Panel
    Friend WithEvents TextBox145 As System.Windows.Forms.TextBox
    Friend WithEvents Panel115 As System.Windows.Forms.Panel
    Friend WithEvents TextBox147 As System.Windows.Forms.TextBox
    Friend WithEvents Panel116 As System.Windows.Forms.Panel
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Panel117 As System.Windows.Forms.Panel
    Friend WithEvents TextBox149 As System.Windows.Forms.TextBox
    Friend WithEvents Panel118 As System.Windows.Forms.Panel
    Friend WithEvents TextBox151 As System.Windows.Forms.TextBox
    Friend WithEvents Panel119 As System.Windows.Forms.Panel
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Panel120 As System.Windows.Forms.Panel
    Friend WithEvents TextBox153 As System.Windows.Forms.TextBox
    Friend WithEvents Panel122 As System.Windows.Forms.Panel
    Friend WithEvents TextBox155 As System.Windows.Forms.TextBox
    Friend WithEvents diagBuses_tab_pressionTroncons As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents TextBox48 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox52 As System.Windows.Forms.TextBox
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents TextBox54 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox56 As System.Windows.Forms.TextBox
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents TextBox58 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox60 As System.Windows.Forms.TextBox
    Friend WithEvents Panel69 As System.Windows.Forms.Panel
    Friend WithEvents TextBox62 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox64 As System.Windows.Forms.TextBox
    Friend WithEvents Panel72 As System.Windows.Forms.Panel
    Friend WithEvents TextBox66 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox68 As System.Windows.Forms.TextBox
    Friend WithEvents Panel74 As System.Windows.Forms.Panel
    Friend WithEvents TextBox70 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox72 As System.Windows.Forms.TextBox
    Friend WithEvents Panel77 As System.Windows.Forms.Panel
    Friend WithEvents TextBox74 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox76 As System.Windows.Forms.TextBox
    Friend WithEvents Panel80 As System.Windows.Forms.Panel
    Friend WithEvents TextBox78 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox80 As System.Windows.Forms.TextBox
    Friend WithEvents Panel81 As System.Windows.Forms.Panel
    Friend WithEvents TextBox122 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox124 As System.Windows.Forms.TextBox
    Friend WithEvents Panel82 As System.Windows.Forms.Panel
    Friend WithEvents TextBox126 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox128 As System.Windows.Forms.TextBox
    Friend WithEvents Panel109 As System.Windows.Forms.Panel
    Friend WithEvents TextBox130 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox132 As System.Windows.Forms.TextBox
    Friend WithEvents Panel121 As System.Windows.Forms.Panel
    Friend WithEvents TextBox134 As System.Windows.Forms.TextBox
    Friend WithEvents Panel123 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel124 As System.Windows.Forms.Panel
    Friend WithEvents TextBox136 As System.Windows.Forms.TextBox
    Friend WithEvents Panel125 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel127 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox138 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox140 As System.Windows.Forms.TextBox
    Friend WithEvents Panel128 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel129 As System.Windows.Forms.Panel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Panel130 As System.Windows.Forms.Panel
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Panel132 As System.Windows.Forms.Panel
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Panel133 As System.Windows.Forms.Panel
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Panel166 As System.Windows.Forms.Panel
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Panel167 As System.Windows.Forms.Panel
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Panel168 As System.Windows.Forms.Panel
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Panel169 As System.Windows.Forms.Panel
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Panel170 As System.Windows.Forms.Panel
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Panel171 As System.Windows.Forms.Panel
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Panel172 As System.Windows.Forms.Panel
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Panel173 As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Panel174 As System.Windows.Forms.Panel
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Panel175 As System.Windows.Forms.Panel
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Panel176 As System.Windows.Forms.Panel
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Panel177 As System.Windows.Forms.Panel
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Panel178 As System.Windows.Forms.Panel
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Panel179 As System.Windows.Forms.Panel
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Panel180 As System.Windows.Forms.Panel
    Friend WithEvents TextBox142 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox144 As System.Windows.Forms.TextBox
    Friend WithEvents Panel181 As System.Windows.Forms.Panel
    Friend WithEvents TextBox146 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox148 As System.Windows.Forms.TextBox
    Friend WithEvents Panel182 As System.Windows.Forms.Panel
    Friend WithEvents TextBox150 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox152 As System.Windows.Forms.TextBox
    Friend WithEvents Panel183 As System.Windows.Forms.Panel
    Friend WithEvents TextBox154 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox156 As System.Windows.Forms.TextBox
    Friend WithEvents Panel184 As System.Windows.Forms.Panel
    Friend WithEvents TextBox157 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox158 As System.Windows.Forms.TextBox
    Friend WithEvents Panel185 As System.Windows.Forms.Panel
    Friend WithEvents TextBox159 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox160 As System.Windows.Forms.TextBox
    Friend WithEvents Panel186 As System.Windows.Forms.Panel
    Friend WithEvents TextBox161 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox162 As System.Windows.Forms.TextBox
    Friend WithEvents Panel187 As System.Windows.Forms.Panel
    Friend WithEvents TextBox163 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox164 As System.Windows.Forms.TextBox
    Friend WithEvents Panel188 As System.Windows.Forms.Panel
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Panel189 As System.Windows.Forms.Panel
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Panel190 As System.Windows.Forms.Panel
    Friend WithEvents TextBox165 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox166 As System.Windows.Forms.TextBox
    Friend WithEvents Panel191 As System.Windows.Forms.Panel
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents Panel192 As System.Windows.Forms.Panel
    Friend WithEvents TextBox167 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox168 As System.Windows.Forms.TextBox
    Friend WithEvents Panel193 As System.Windows.Forms.Panel
    Friend WithEvents TextBox169 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox170 As System.Windows.Forms.TextBox
    Friend WithEvents Panel194 As System.Windows.Forms.Panel
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Panel195 As System.Windows.Forms.Panel
    Friend WithEvents TextBox171 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox172 As System.Windows.Forms.TextBox
    Friend WithEvents Panel196 As System.Windows.Forms.Panel
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents Panel197 As System.Windows.Forms.Panel
    Friend WithEvents TextBox173 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox174 As System.Windows.Forms.TextBox
    Friend WithEvents Panel198 As System.Windows.Forms.Panel
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Panel199 As System.Windows.Forms.Panel
    Friend WithEvents TextBox175 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox176 As System.Windows.Forms.TextBox
    Friend WithEvents Panel200 As System.Windows.Forms.Panel
    Friend WithEvents TextBox177 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox178 As System.Windows.Forms.TextBox
    Friend WithEvents Panel201 As System.Windows.Forms.Panel
    Friend WithEvents TextBox179 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox180 As System.Windows.Forms.TextBox
    Friend WithEvents Panel202 As System.Windows.Forms.Panel
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents Panel203 As System.Windows.Forms.Panel
    Friend WithEvents TextBox181 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox182 As System.Windows.Forms.TextBox
    Friend WithEvents Panel204 As System.Windows.Forms.Panel
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents Panel205 As System.Windows.Forms.Panel
    Friend WithEvents TextBox183 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox184 As System.Windows.Forms.TextBox
    Friend WithEvents Panel206 As System.Windows.Forms.Panel
    Friend WithEvents TextBox185 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox186 As System.Windows.Forms.TextBox
    Friend WithEvents Panel207 As System.Windows.Forms.Panel
    Friend WithEvents TextBox187 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox188 As System.Windows.Forms.TextBox
    Friend WithEvents Panel208 As System.Windows.Forms.Panel
    Friend WithEvents TextBox189 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox190 As System.Windows.Forms.TextBox
    Friend WithEvents Panel209 As System.Windows.Forms.Panel
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents Panel210 As System.Windows.Forms.Panel
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Panel211 As System.Windows.Forms.Panel
    Friend WithEvents TextBox191 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox192 As System.Windows.Forms.TextBox
    Friend WithEvents Panel212 As System.Windows.Forms.Panel
    Friend WithEvents TextBox193 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox194 As System.Windows.Forms.TextBox
    Friend WithEvents Panel213 As System.Windows.Forms.Panel
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Panel214 As System.Windows.Forms.Panel
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Panel215 As System.Windows.Forms.Panel
    Friend WithEvents TextBox195 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox196 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel216 As System.Windows.Forms.Panel
    Friend WithEvents TextBox233 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox234 As System.Windows.Forms.TextBox
    Friend WithEvents Panel217 As System.Windows.Forms.Panel
    Friend WithEvents TextBox235 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox236 As System.Windows.Forms.TextBox
    Friend WithEvents Panel218 As System.Windows.Forms.Panel
    Friend WithEvents TextBox237 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox238 As System.Windows.Forms.TextBox
    Friend WithEvents Panel219 As System.Windows.Forms.Panel
    Friend WithEvents TextBox239 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox240 As System.Windows.Forms.TextBox
    Friend WithEvents Panel220 As System.Windows.Forms.Panel
    Friend WithEvents TextBox241 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox242 As System.Windows.Forms.TextBox
    Friend WithEvents Panel221 As System.Windows.Forms.Panel
    Friend WithEvents TextBox243 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox244 As System.Windows.Forms.TextBox
    Friend WithEvents Panel222 As System.Windows.Forms.Panel
    Friend WithEvents TextBox245 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox246 As System.Windows.Forms.TextBox
    Friend WithEvents Panel223 As System.Windows.Forms.Panel
    Friend WithEvents TextBox247 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox248 As System.Windows.Forms.TextBox
    Friend WithEvents Panel224 As System.Windows.Forms.Panel
    Friend WithEvents TextBox249 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox250 As System.Windows.Forms.TextBox
    Friend WithEvents Panel225 As System.Windows.Forms.Panel
    Friend WithEvents TextBox251 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox252 As System.Windows.Forms.TextBox
    Friend WithEvents Panel226 As System.Windows.Forms.Panel
    Friend WithEvents TextBox253 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox254 As System.Windows.Forms.TextBox
    Friend WithEvents Panel227 As System.Windows.Forms.Panel
    Friend WithEvents TextBox255 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox256 As System.Windows.Forms.TextBox
    Friend WithEvents Panel228 As System.Windows.Forms.Panel
    Friend WithEvents TextBox257 As System.Windows.Forms.TextBox
    Friend WithEvents Panel229 As System.Windows.Forms.Panel
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Panel230 As System.Windows.Forms.Panel
    Friend WithEvents TextBox258 As System.Windows.Forms.TextBox
    Friend WithEvents Panel231 As System.Windows.Forms.Panel
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents Panel232 As System.Windows.Forms.Panel
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents TextBox259 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox260 As System.Windows.Forms.TextBox
    Friend WithEvents Panel233 As System.Windows.Forms.Panel
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Panel234 As System.Windows.Forms.Panel
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents Panel235 As System.Windows.Forms.Panel
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents Panel236 As System.Windows.Forms.Panel
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents Panel237 As System.Windows.Forms.Panel
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents Panel238 As System.Windows.Forms.Panel
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents Panel239 As System.Windows.Forms.Panel
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents Panel240 As System.Windows.Forms.Panel
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents Panel241 As System.Windows.Forms.Panel
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents Panel242 As System.Windows.Forms.Panel
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents Panel243 As System.Windows.Forms.Panel
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents Panel244 As System.Windows.Forms.Panel
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents Panel245 As System.Windows.Forms.Panel
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents Label153 As System.Windows.Forms.Label
    Friend WithEvents Panel246 As System.Windows.Forms.Panel
    Friend WithEvents Label154 As System.Windows.Forms.Label
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents Panel247 As System.Windows.Forms.Panel
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents Panel248 As System.Windows.Forms.Panel
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents Panel249 As System.Windows.Forms.Panel
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents Panel250 As System.Windows.Forms.Panel
    Friend WithEvents Label160 As System.Windows.Forms.Label
    Friend WithEvents Label161 As System.Windows.Forms.Label
    Friend WithEvents Panel251 As System.Windows.Forms.Panel
    Friend WithEvents Label162 As System.Windows.Forms.Label
    Friend WithEvents Panel252 As System.Windows.Forms.Panel
    Friend WithEvents TextBox261 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox262 As System.Windows.Forms.TextBox
    Friend WithEvents Panel253 As System.Windows.Forms.Panel
    Friend WithEvents TextBox263 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox264 As System.Windows.Forms.TextBox
    Friend WithEvents Panel254 As System.Windows.Forms.Panel
    Friend WithEvents TextBox265 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox266 As System.Windows.Forms.TextBox
    Friend WithEvents Panel255 As System.Windows.Forms.Panel
    Friend WithEvents TextBox267 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox268 As System.Windows.Forms.TextBox
    Friend WithEvents Panel256 As System.Windows.Forms.Panel
    Friend WithEvents TextBox269 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox270 As System.Windows.Forms.TextBox
    Friend WithEvents Panel257 As System.Windows.Forms.Panel
    Friend WithEvents TextBox271 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox272 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents Panel258 As System.Windows.Forms.Panel
    Friend WithEvents TextBox273 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox274 As System.Windows.Forms.TextBox
    Friend WithEvents Panel259 As System.Windows.Forms.Panel
    Friend WithEvents TextBox275 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox276 As System.Windows.Forms.TextBox
    Friend WithEvents Panel260 As System.Windows.Forms.Panel
    Friend WithEvents TextBox277 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox278 As System.Windows.Forms.TextBox
    Friend WithEvents Panel261 As System.Windows.Forms.Panel
    Friend WithEvents TextBox279 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox280 As System.Windows.Forms.TextBox
    Friend WithEvents Panel262 As System.Windows.Forms.Panel
    Friend WithEvents TextBox281 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox282 As System.Windows.Forms.TextBox
    Friend WithEvents Panel263 As System.Windows.Forms.Panel
    Friend WithEvents TextBox283 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox284 As System.Windows.Forms.TextBox
    Friend WithEvents Panel264 As System.Windows.Forms.Panel
    Friend WithEvents TextBox285 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox286 As System.Windows.Forms.TextBox
    Friend WithEvents Panel265 As System.Windows.Forms.Panel
    Friend WithEvents TextBox287 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox288 As System.Windows.Forms.TextBox
    Friend WithEvents Panel266 As System.Windows.Forms.Panel
    Friend WithEvents TextBox289 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox290 As System.Windows.Forms.TextBox
    Friend WithEvents Panel267 As System.Windows.Forms.Panel
    Friend WithEvents TextBox291 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox292 As System.Windows.Forms.TextBox
    Friend WithEvents Panel268 As System.Windows.Forms.Panel
    Friend WithEvents TextBox293 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox294 As System.Windows.Forms.TextBox
    Friend WithEvents Panel269 As System.Windows.Forms.Panel
    Friend WithEvents TextBox295 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox296 As System.Windows.Forms.TextBox
    Friend WithEvents Panel270 As System.Windows.Forms.Panel
    Friend WithEvents TextBox297 As System.Windows.Forms.TextBox
    Friend WithEvents Panel271 As System.Windows.Forms.Panel
    Friend WithEvents Label163 As System.Windows.Forms.Label
    Friend WithEvents Panel272 As System.Windows.Forms.Panel
    Friend WithEvents TextBox298 As System.Windows.Forms.TextBox
    Friend WithEvents Panel273 As System.Windows.Forms.Panel
    Friend WithEvents Label164 As System.Windows.Forms.Label
    Friend WithEvents Panel274 As System.Windows.Forms.Panel
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents TextBox299 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox300 As System.Windows.Forms.TextBox
    Friend WithEvents Panel275 As System.Windows.Forms.Panel
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents Panel276 As System.Windows.Forms.Panel
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents Label170 As System.Windows.Forms.Label
    Friend WithEvents Panel277 As System.Windows.Forms.Panel
    Friend WithEvents Label171 As System.Windows.Forms.Label
    Friend WithEvents Label172 As System.Windows.Forms.Label
    Friend WithEvents Panel278 As System.Windows.Forms.Panel
    Friend WithEvents Label173 As System.Windows.Forms.Label
    Friend WithEvents Panel279 As System.Windows.Forms.Panel
    Friend WithEvents Label174 As System.Windows.Forms.Label
    Friend WithEvents Panel280 As System.Windows.Forms.Panel
    Friend WithEvents Label175 As System.Windows.Forms.Label
    Friend WithEvents Panel281 As System.Windows.Forms.Panel
    Friend WithEvents Label176 As System.Windows.Forms.Label
    Friend WithEvents Panel282 As System.Windows.Forms.Panel
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents Panel283 As System.Windows.Forms.Panel
    Friend WithEvents Label178 As System.Windows.Forms.Label
    Friend WithEvents Panel284 As System.Windows.Forms.Panel
    Friend WithEvents Label179 As System.Windows.Forms.Label
    Friend WithEvents Panel285 As System.Windows.Forms.Panel
    Friend WithEvents Label180 As System.Windows.Forms.Label
    Friend WithEvents Panel286 As System.Windows.Forms.Panel
    Friend WithEvents Label181 As System.Windows.Forms.Label
    Friend WithEvents Panel287 As System.Windows.Forms.Panel
    Friend WithEvents Label182 As System.Windows.Forms.Label
    Friend WithEvents Label183 As System.Windows.Forms.Label
    Friend WithEvents Panel288 As System.Windows.Forms.Panel
    Friend WithEvents Label184 As System.Windows.Forms.Label
    Friend WithEvents Label185 As System.Windows.Forms.Label
    Friend WithEvents Panel289 As System.Windows.Forms.Panel
    Friend WithEvents Label186 As System.Windows.Forms.Label
    Friend WithEvents Panel290 As System.Windows.Forms.Panel
    Friend WithEvents Label187 As System.Windows.Forms.Label
    Friend WithEvents Panel291 As System.Windows.Forms.Panel
    Friend WithEvents Label188 As System.Windows.Forms.Label
    Friend WithEvents Label189 As System.Windows.Forms.Label
    Friend WithEvents Panel292 As System.Windows.Forms.Panel
    Friend WithEvents Label190 As System.Windows.Forms.Label
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Panel323 As System.Windows.Forms.Panel
    Friend WithEvents Label192 As System.Windows.Forms.Label
    Friend WithEvents Panel324 As System.Windows.Forms.Panel
    Friend WithEvents TextBox301 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox302 As System.Windows.Forms.TextBox
    Friend WithEvents Panel325 As System.Windows.Forms.Panel
    Friend WithEvents TextBox303 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox304 As System.Windows.Forms.TextBox
    Friend WithEvents Panel326 As System.Windows.Forms.Panel
    Friend WithEvents TextBox305 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox306 As System.Windows.Forms.TextBox
    Friend WithEvents Panel327 As System.Windows.Forms.Panel
    Friend WithEvents TextBox307 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox308 As System.Windows.Forms.TextBox
    Friend WithEvents Panel328 As System.Windows.Forms.Panel
    Friend WithEvents TextBox309 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox310 As System.Windows.Forms.TextBox
    Friend WithEvents Panel329 As System.Windows.Forms.Panel
    Friend WithEvents TextBox311 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox312 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents Panel330 As System.Windows.Forms.Panel
    Friend WithEvents TextBox313 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox314 As System.Windows.Forms.TextBox
    Friend WithEvents Panel331 As System.Windows.Forms.Panel
    Friend WithEvents TextBox315 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox316 As System.Windows.Forms.TextBox
    Friend WithEvents Panel332 As System.Windows.Forms.Panel
    Friend WithEvents TextBox317 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox318 As System.Windows.Forms.TextBox
    Friend WithEvents Panel333 As System.Windows.Forms.Panel
    Friend WithEvents TextBox319 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox320 As System.Windows.Forms.TextBox
    Friend WithEvents Panel334 As System.Windows.Forms.Panel
    Friend WithEvents TextBox321 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox322 As System.Windows.Forms.TextBox
    Friend WithEvents Panel335 As System.Windows.Forms.Panel
    Friend WithEvents TextBox323 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox324 As System.Windows.Forms.TextBox
    Friend WithEvents Panel336 As System.Windows.Forms.Panel
    Friend WithEvents TextBox325 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox326 As System.Windows.Forms.TextBox
    Friend WithEvents Panel337 As System.Windows.Forms.Panel
    Friend WithEvents TextBox327 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox328 As System.Windows.Forms.TextBox
    Friend WithEvents Panel338 As System.Windows.Forms.Panel
    Friend WithEvents TextBox329 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox330 As System.Windows.Forms.TextBox
    Friend WithEvents Panel339 As System.Windows.Forms.Panel
    Friend WithEvents TextBox331 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox332 As System.Windows.Forms.TextBox
    Friend WithEvents Panel340 As System.Windows.Forms.Panel
    Friend WithEvents TextBox333 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox334 As System.Windows.Forms.TextBox
    Friend WithEvents Panel341 As System.Windows.Forms.Panel
    Friend WithEvents TextBox335 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox336 As System.Windows.Forms.TextBox
    Friend WithEvents Panel342 As System.Windows.Forms.Panel
    Friend WithEvents TextBox337 As System.Windows.Forms.TextBox
    Friend WithEvents Panel343 As System.Windows.Forms.Panel
    Friend WithEvents Label193 As System.Windows.Forms.Label
    Friend WithEvents Panel344 As System.Windows.Forms.Panel
    Friend WithEvents TextBox338 As System.Windows.Forms.TextBox
    Friend WithEvents Panel345 As System.Windows.Forms.Panel
    Friend WithEvents Label194 As System.Windows.Forms.Label
    Friend WithEvents Panel346 As System.Windows.Forms.Panel
    Friend WithEvents Label195 As System.Windows.Forms.Label
    Friend WithEvents Label196 As System.Windows.Forms.Label
    Friend WithEvents TextBox339 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox340 As System.Windows.Forms.TextBox
    Friend WithEvents Panel347 As System.Windows.Forms.Panel
    Friend WithEvents Label197 As System.Windows.Forms.Label
    Friend WithEvents Label198 As System.Windows.Forms.Label
    Friend WithEvents Panel348 As System.Windows.Forms.Panel
    Friend WithEvents Label199 As System.Windows.Forms.Label
    Friend WithEvents Label200 As System.Windows.Forms.Label
    Friend WithEvents Panel349 As System.Windows.Forms.Panel
    Friend WithEvents Label201 As System.Windows.Forms.Label
    Friend WithEvents Label202 As System.Windows.Forms.Label
    Friend WithEvents Panel350 As System.Windows.Forms.Panel
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents Panel351 As System.Windows.Forms.Panel
    Friend WithEvents Label204 As System.Windows.Forms.Label
    Friend WithEvents Panel352 As System.Windows.Forms.Panel
    Friend WithEvents Label205 As System.Windows.Forms.Label
    Friend WithEvents Panel353 As System.Windows.Forms.Panel
    Friend WithEvents Label206 As System.Windows.Forms.Label
    Friend WithEvents Panel354 As System.Windows.Forms.Panel
    Friend WithEvents Label207 As System.Windows.Forms.Label
    Friend WithEvents Panel355 As System.Windows.Forms.Panel
    Friend WithEvents Label208 As System.Windows.Forms.Label
    Friend WithEvents Panel356 As System.Windows.Forms.Panel
    Friend WithEvents Label209 As System.Windows.Forms.Label
    Friend WithEvents Panel357 As System.Windows.Forms.Panel
    Friend WithEvents Label210 As System.Windows.Forms.Label
    Friend WithEvents Panel358 As System.Windows.Forms.Panel
    Friend WithEvents Label211 As System.Windows.Forms.Label
    Friend WithEvents Panel359 As System.Windows.Forms.Panel
    Friend WithEvents Label212 As System.Windows.Forms.Label
    Friend WithEvents Label213 As System.Windows.Forms.Label
    Friend WithEvents Panel360 As System.Windows.Forms.Panel
    Friend WithEvents Label214 As System.Windows.Forms.Label
    Friend WithEvents Label215 As System.Windows.Forms.Label
    Friend WithEvents Panel361 As System.Windows.Forms.Panel
    Friend WithEvents Label216 As System.Windows.Forms.Label
    Friend WithEvents Panel362 As System.Windows.Forms.Panel
    Friend WithEvents Label217 As System.Windows.Forms.Label
    Friend WithEvents Panel363 As System.Windows.Forms.Panel
    Friend WithEvents Label218 As System.Windows.Forms.Label
    Friend WithEvents Label219 As System.Windows.Forms.Label
    Friend WithEvents Panel364 As System.Windows.Forms.Panel
    Friend WithEvents Label220 As System.Windows.Forms.Label
    Friend WithEvents Label221 As System.Windows.Forms.Label
    Friend WithEvents Panel365 As System.Windows.Forms.Panel
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents Panel366 As System.Windows.Forms.Panel
    Friend WithEvents TextBox341 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox342 As System.Windows.Forms.TextBox
    Friend WithEvents Panel367 As System.Windows.Forms.Panel
    Friend WithEvents TextBox343 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox344 As System.Windows.Forms.TextBox
    Friend WithEvents Panel368 As System.Windows.Forms.Panel
    Friend WithEvents TextBox345 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox346 As System.Windows.Forms.TextBox
    Friend WithEvents Panel369 As System.Windows.Forms.Panel
    Friend WithEvents TextBox347 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox348 As System.Windows.Forms.TextBox
    Friend WithEvents Panel370 As System.Windows.Forms.Panel
    Friend WithEvents TextBox349 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox350 As System.Windows.Forms.TextBox
    Friend WithEvents Panel371 As System.Windows.Forms.Panel
    Friend WithEvents TextBox351 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox352 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Panel85 As System.Windows.Forms.Panel
    Friend WithEvents TextBox81 As System.Windows.Forms.TextBox
    Friend WithEvents Panel86 As System.Windows.Forms.Panel
    Friend WithEvents TextBox82 As System.Windows.Forms.TextBox
    Friend WithEvents Panel87 As System.Windows.Forms.Panel
    Friend WithEvents TextBox83 As System.Windows.Forms.TextBox
    Friend WithEvents Panel88 As System.Windows.Forms.Panel
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Panel89 As System.Windows.Forms.Panel
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Panel90 As System.Windows.Forms.Panel
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Panel91 As System.Windows.Forms.Panel
    Friend WithEvents TextBox84 As System.Windows.Forms.TextBox
    Friend WithEvents Panel92 As System.Windows.Forms.Panel
    Friend WithEvents TextBox85 As System.Windows.Forms.TextBox
    Friend WithEvents Panel126 As System.Windows.Forms.Panel
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Panel131 As System.Windows.Forms.Panel
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents TextBox86 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox87 As System.Windows.Forms.TextBox
    Friend WithEvents Panel134 As System.Windows.Forms.Panel
    Friend WithEvents TextBox88 As System.Windows.Forms.TextBox
    Friend WithEvents Panel135 As System.Windows.Forms.Panel
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Panel136 As System.Windows.Forms.Panel
    Friend WithEvents TextBox89 As System.Windows.Forms.TextBox
    Friend WithEvents Panel137 As System.Windows.Forms.Panel
    Friend WithEvents TextBox90 As System.Windows.Forms.TextBox
    Friend WithEvents Panel138 As System.Windows.Forms.Panel
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Panel139 As System.Windows.Forms.Panel
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Panel140 As System.Windows.Forms.Panel
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Panel141 As System.Windows.Forms.Panel
    Friend WithEvents TextBox91 As System.Windows.Forms.TextBox
    Friend WithEvents Panel142 As System.Windows.Forms.Panel
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Panel143 As System.Windows.Forms.Panel
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Panel144 As System.Windows.Forms.Panel
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Panel145 As System.Windows.Forms.Panel
    Friend WithEvents TextBox92 As System.Windows.Forms.TextBox
    Friend WithEvents Panel146 As System.Windows.Forms.Panel
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Panel147 As System.Windows.Forms.Panel
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Panel148 As System.Windows.Forms.Panel
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Panel149 As System.Windows.Forms.Panel
    Friend WithEvents TextBox93 As System.Windows.Forms.TextBox
    Friend WithEvents Panel150 As System.Windows.Forms.Panel
    Friend WithEvents TextBox94 As System.Windows.Forms.TextBox
    Friend WithEvents Panel151 As System.Windows.Forms.Panel
    Friend WithEvents TextBox95 As System.Windows.Forms.TextBox
    Friend WithEvents Panel152 As System.Windows.Forms.Panel
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Panel153 As System.Windows.Forms.Panel
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Panel154 As System.Windows.Forms.Panel
    Friend WithEvents TextBox96 As System.Windows.Forms.TextBox
    Friend WithEvents Panel155 As System.Windows.Forms.Panel
    Friend WithEvents TextBox97 As System.Windows.Forms.TextBox
    Friend WithEvents Panel156 As System.Windows.Forms.Panel
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Panel157 As System.Windows.Forms.Panel
    Friend WithEvents TextBox98 As System.Windows.Forms.TextBox
    Friend WithEvents Panel158 As System.Windows.Forms.Panel
    Friend WithEvents TextBox99 As System.Windows.Forms.TextBox
    Friend WithEvents Panel159 As System.Windows.Forms.Panel
    Friend WithEvents TextBox100 As System.Windows.Forms.TextBox
    Friend WithEvents Panel160 As System.Windows.Forms.Panel
    Friend WithEvents TextBox101 As System.Windows.Forms.TextBox
    Friend WithEvents Panel161 As System.Windows.Forms.Panel
    Friend WithEvents TextBox102 As System.Windows.Forms.TextBox
    Friend WithEvents Panel162 As System.Windows.Forms.Panel
    Friend WithEvents TextBox103 As System.Windows.Forms.TextBox
    Friend WithEvents Panel163 As System.Windows.Forms.Panel
    Friend WithEvents TextBox104 As System.Windows.Forms.TextBox
    Friend WithEvents Panel164 As System.Windows.Forms.Panel
    Friend WithEvents TextBox105 As System.Windows.Forms.TextBox
    Friend WithEvents Panel165 As System.Windows.Forms.Panel
    Friend WithEvents TextBox106 As System.Windows.Forms.TextBox
    Friend WithEvents Panel293 As System.Windows.Forms.Panel
    Friend WithEvents TextBox107 As System.Windows.Forms.TextBox
    Friend WithEvents Panel294 As System.Windows.Forms.Panel
    Friend WithEvents TextBox108 As System.Windows.Forms.TextBox
    Friend WithEvents Panel295 As System.Windows.Forms.Panel
    Friend WithEvents TextBox109 As System.Windows.Forms.TextBox
    Friend WithEvents Panel296 As System.Windows.Forms.Panel
    Friend WithEvents TextBox110 As System.Windows.Forms.TextBox
    Friend WithEvents Panel297 As System.Windows.Forms.Panel
    Friend WithEvents TextBox111 As System.Windows.Forms.TextBox
    Friend WithEvents Panel298 As System.Windows.Forms.Panel
    Friend WithEvents TextBox112 As System.Windows.Forms.TextBox
    Friend WithEvents Panel299 As System.Windows.Forms.Panel
    Friend WithEvents TextBox113 As System.Windows.Forms.TextBox
    Friend WithEvents Panel300 As System.Windows.Forms.Panel
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Panel301 As System.Windows.Forms.Panel
    Friend WithEvents TextBox114 As System.Windows.Forms.TextBox
    Friend WithEvents Panel302 As System.Windows.Forms.Panel
    Friend WithEvents TextBox115 As System.Windows.Forms.TextBox
    Friend WithEvents Panel303 As System.Windows.Forms.Panel
    Friend WithEvents TextBox116 As System.Windows.Forms.TextBox
    Friend WithEvents Panel304 As System.Windows.Forms.Panel
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Panel305 As System.Windows.Forms.Panel
    Friend WithEvents TextBox117 As System.Windows.Forms.TextBox
    Friend WithEvents Panel306 As System.Windows.Forms.Panel
    Friend WithEvents TextBox118 As System.Windows.Forms.TextBox
    Friend WithEvents Panel307 As System.Windows.Forms.Panel
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Panel308 As System.Windows.Forms.Panel
    Friend WithEvents TextBox119 As System.Windows.Forms.TextBox
    Friend WithEvents Panel309 As System.Windows.Forms.Panel
    Friend WithEvents TextBox120 As System.Windows.Forms.TextBox
    Friend WithEvents Panel310 As System.Windows.Forms.Panel
    Friend WithEvents TextBox197 As System.Windows.Forms.TextBox
    Friend WithEvents Panel311 As System.Windows.Forms.Panel
    Friend WithEvents TextBox198 As System.Windows.Forms.TextBox
    Friend WithEvents Panel312 As System.Windows.Forms.Panel
    Friend WithEvents TextBox199 As System.Windows.Forms.TextBox
    Friend WithEvents Panel313 As System.Windows.Forms.Panel
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Panel314 As System.Windows.Forms.Panel
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents Panel315 As System.Windows.Forms.Panel
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents Panel316 As System.Windows.Forms.Panel
    Friend WithEvents TextBox200 As System.Windows.Forms.TextBox
    Friend WithEvents Panel317 As System.Windows.Forms.Panel
    Friend WithEvents TextBox201 As System.Windows.Forms.TextBox
    Friend WithEvents Panel318 As System.Windows.Forms.Panel
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Panel319 As System.Windows.Forms.Panel
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents TextBox202 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox203 As System.Windows.Forms.TextBox
    Friend WithEvents Panel320 As System.Windows.Forms.Panel
    Friend WithEvents TextBox204 As System.Windows.Forms.TextBox
    Friend WithEvents Panel321 As System.Windows.Forms.Panel
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Panel322 As System.Windows.Forms.Panel
    Friend WithEvents TextBox205 As System.Windows.Forms.TextBox
    Friend WithEvents Panel372 As System.Windows.Forms.Panel
    Friend WithEvents TextBox206 As System.Windows.Forms.TextBox
    Friend WithEvents Panel373 As System.Windows.Forms.Panel
    Friend WithEvents Label223 As System.Windows.Forms.Label
    Friend WithEvents Panel374 As System.Windows.Forms.Panel
    Friend WithEvents Label224 As System.Windows.Forms.Label
    Friend WithEvents Panel375 As System.Windows.Forms.Panel
    Friend WithEvents Label225 As System.Windows.Forms.Label
    Friend WithEvents Panel376 As System.Windows.Forms.Panel
    Friend WithEvents TextBox207 As System.Windows.Forms.TextBox
    Friend WithEvents Panel377 As System.Windows.Forms.Panel
    Friend WithEvents Label226 As System.Windows.Forms.Label
    Friend WithEvents Panel378 As System.Windows.Forms.Panel
    Friend WithEvents Label227 As System.Windows.Forms.Label
    Friend WithEvents Panel379 As System.Windows.Forms.Panel
    Friend WithEvents Label228 As System.Windows.Forms.Label
    Friend WithEvents Panel380 As System.Windows.Forms.Panel
    Friend WithEvents TextBox208 As System.Windows.Forms.TextBox
    Friend WithEvents Panel381 As System.Windows.Forms.Panel
    Friend WithEvents Label229 As System.Windows.Forms.Label
    Friend WithEvents Panel382 As System.Windows.Forms.Panel
    Friend WithEvents Label230 As System.Windows.Forms.Label
    Friend WithEvents Panel383 As System.Windows.Forms.Panel
    Friend WithEvents Label231 As System.Windows.Forms.Label
    Friend WithEvents Panel384 As System.Windows.Forms.Panel
    Friend WithEvents TextBox209 As System.Windows.Forms.TextBox
    Friend WithEvents Panel385 As System.Windows.Forms.Panel
    Friend WithEvents TextBox210 As System.Windows.Forms.TextBox
    Friend WithEvents Panel386 As System.Windows.Forms.Panel
    Friend WithEvents TextBox211 As System.Windows.Forms.TextBox
    Friend WithEvents Panel387 As System.Windows.Forms.Panel
    Friend WithEvents Label232 As System.Windows.Forms.Label
    Friend WithEvents Panel388 As System.Windows.Forms.Panel
    Friend WithEvents Label233 As System.Windows.Forms.Label
    Friend WithEvents Panel389 As System.Windows.Forms.Panel
    Friend WithEvents TextBox212 As System.Windows.Forms.TextBox
    Friend WithEvents Panel390 As System.Windows.Forms.Panel
    Friend WithEvents TextBox213 As System.Windows.Forms.TextBox
    Friend WithEvents Panel391 As System.Windows.Forms.Panel
    Friend WithEvents Label234 As System.Windows.Forms.Label
    Friend WithEvents Panel392 As System.Windows.Forms.Panel
    Friend WithEvents TextBox214 As System.Windows.Forms.TextBox
    Friend WithEvents Panel393 As System.Windows.Forms.Panel
    Friend WithEvents TextBox215 As System.Windows.Forms.TextBox
    Friend WithEvents Panel394 As System.Windows.Forms.Panel
    Friend WithEvents TextBox216 As System.Windows.Forms.TextBox
    Friend WithEvents Panel395 As System.Windows.Forms.Panel
    Friend WithEvents TextBox217 As System.Windows.Forms.TextBox
    Friend WithEvents Panel396 As System.Windows.Forms.Panel
    Friend WithEvents TextBox218 As System.Windows.Forms.TextBox
    Friend WithEvents Panel397 As System.Windows.Forms.Panel
    Friend WithEvents TextBox219 As System.Windows.Forms.TextBox
    Friend WithEvents Panel398 As System.Windows.Forms.Panel
    Friend WithEvents TextBox220 As System.Windows.Forms.TextBox
    Friend WithEvents Panel399 As System.Windows.Forms.Panel
    Friend WithEvents TextBox221 As System.Windows.Forms.TextBox
    Friend WithEvents Panel400 As System.Windows.Forms.Panel
    Friend WithEvents TextBox222 As System.Windows.Forms.TextBox
    Friend WithEvents Panel401 As System.Windows.Forms.Panel
    Friend WithEvents TextBox223 As System.Windows.Forms.TextBox
    Friend WithEvents Panel402 As System.Windows.Forms.Panel
    Friend WithEvents TextBox224 As System.Windows.Forms.TextBox
    Friend WithEvents Panel403 As System.Windows.Forms.Panel
    Friend WithEvents TextBox225 As System.Windows.Forms.TextBox
    Friend WithEvents Panel404 As System.Windows.Forms.Panel
    Friend WithEvents TextBox226 As System.Windows.Forms.TextBox
    Friend WithEvents Panel405 As System.Windows.Forms.Panel
    Friend WithEvents TextBox227 As System.Windows.Forms.TextBox
    Friend WithEvents Panel406 As System.Windows.Forms.Panel
    Friend WithEvents TextBox228 As System.Windows.Forms.TextBox
    Friend WithEvents Panel407 As System.Windows.Forms.Panel
    Friend WithEvents TextBox229 As System.Windows.Forms.TextBox
    Friend WithEvents Panel408 As System.Windows.Forms.Panel
    Friend WithEvents Label235 As System.Windows.Forms.Label
    Friend WithEvents Panel409 As System.Windows.Forms.Panel
    Friend WithEvents TextBox230 As System.Windows.Forms.TextBox
    Friend WithEvents Panel410 As System.Windows.Forms.Panel
    Friend WithEvents TextBox231 As System.Windows.Forms.TextBox
    Friend WithEvents Panel411 As System.Windows.Forms.Panel
    Friend WithEvents TextBox232 As System.Windows.Forms.TextBox
    Friend WithEvents Panel412 As System.Windows.Forms.Panel
    Friend WithEvents Label236 As System.Windows.Forms.Label
    Friend WithEvents Panel413 As System.Windows.Forms.Panel
    Friend WithEvents TextBox353 As System.Windows.Forms.TextBox
    Friend WithEvents Panel498 As System.Windows.Forms.Panel
    Friend WithEvents TextBox354 As System.Windows.Forms.TextBox
    Friend WithEvents Panel499 As System.Windows.Forms.Panel
    Friend WithEvents Label237 As System.Windows.Forms.Label
    Friend WithEvents Panel500 As System.Windows.Forms.Panel
    Friend WithEvents TextBox355 As System.Windows.Forms.TextBox
    Friend WithEvents Panel501 As System.Windows.Forms.Panel
    Friend WithEvents TextBox356 As System.Windows.Forms.TextBox
    Friend WithEvents Panel414 As System.Windows.Forms.Panel
    Friend WithEvents TextBox357 As System.Windows.Forms.TextBox
    Friend WithEvents Panel415 As System.Windows.Forms.Panel
    Friend WithEvents TextBox358 As System.Windows.Forms.TextBox
    Friend WithEvents Panel416 As System.Windows.Forms.Panel
    Friend WithEvents TextBox359 As System.Windows.Forms.TextBox
    Friend WithEvents Panel417 As System.Windows.Forms.Panel
    Friend WithEvents Label238 As System.Windows.Forms.Label
    Friend WithEvents Panel418 As System.Windows.Forms.Panel
    Friend WithEvents Label239 As System.Windows.Forms.Label
    Friend WithEvents Panel419 As System.Windows.Forms.Panel
    Friend WithEvents Label240 As System.Windows.Forms.Label
    Friend WithEvents Panel420 As System.Windows.Forms.Panel
    Friend WithEvents TextBox360 As System.Windows.Forms.TextBox
    Friend WithEvents Panel421 As System.Windows.Forms.Panel
    Friend WithEvents TextBox361 As System.Windows.Forms.TextBox
    Friend WithEvents Panel422 As System.Windows.Forms.Panel
    Friend WithEvents Label241 As System.Windows.Forms.Label
    Friend WithEvents Panel423 As System.Windows.Forms.Panel
    Friend WithEvents Label242 As System.Windows.Forms.Label
    Friend WithEvents Label243 As System.Windows.Forms.Label
    Friend WithEvents TextBox362 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox363 As System.Windows.Forms.TextBox
    Friend WithEvents Panel424 As System.Windows.Forms.Panel
    Friend WithEvents TextBox364 As System.Windows.Forms.TextBox
    Friend WithEvents Panel425 As System.Windows.Forms.Panel
    Friend WithEvents Label244 As System.Windows.Forms.Label
    Friend WithEvents Label245 As System.Windows.Forms.Label
    Friend WithEvents Panel426 As System.Windows.Forms.Panel
    Friend WithEvents TextBox365 As System.Windows.Forms.TextBox
    Friend WithEvents Panel427 As System.Windows.Forms.Panel
    Friend WithEvents TextBox366 As System.Windows.Forms.TextBox
    Friend WithEvents Panel428 As System.Windows.Forms.Panel
    Friend WithEvents Label246 As System.Windows.Forms.Label
    Friend WithEvents Panel429 As System.Windows.Forms.Panel
    Friend WithEvents Label247 As System.Windows.Forms.Label
    Friend WithEvents Panel430 As System.Windows.Forms.Panel
    Friend WithEvents Label248 As System.Windows.Forms.Label
    Friend WithEvents Panel431 As System.Windows.Forms.Panel
    Friend WithEvents TextBox367 As System.Windows.Forms.TextBox
    Friend WithEvents Panel432 As System.Windows.Forms.Panel
    Friend WithEvents Label249 As System.Windows.Forms.Label
    Friend WithEvents Panel433 As System.Windows.Forms.Panel
    Friend WithEvents Label250 As System.Windows.Forms.Label
    Friend WithEvents Panel434 As System.Windows.Forms.Panel
    Friend WithEvents Label251 As System.Windows.Forms.Label
    Friend WithEvents Panel435 As System.Windows.Forms.Panel
    Friend WithEvents TextBox368 As System.Windows.Forms.TextBox
    Friend WithEvents Panel436 As System.Windows.Forms.Panel
    Friend WithEvents Label252 As System.Windows.Forms.Label
    Friend WithEvents Panel437 As System.Windows.Forms.Panel
    Friend WithEvents Label253 As System.Windows.Forms.Label
    Friend WithEvents Panel438 As System.Windows.Forms.Panel
    Friend WithEvents Label254 As System.Windows.Forms.Label
    Friend WithEvents Panel439 As System.Windows.Forms.Panel
    Friend WithEvents TextBox369 As System.Windows.Forms.TextBox
    Friend WithEvents Panel440 As System.Windows.Forms.Panel
    Friend WithEvents TextBox370 As System.Windows.Forms.TextBox
    Friend WithEvents Panel441 As System.Windows.Forms.Panel
    Friend WithEvents TextBox371 As System.Windows.Forms.TextBox
    Friend WithEvents Panel442 As System.Windows.Forms.Panel
    Friend WithEvents Label255 As System.Windows.Forms.Label
    Friend WithEvents Panel443 As System.Windows.Forms.Panel
    Friend WithEvents Label256 As System.Windows.Forms.Label
    Friend WithEvents Panel444 As System.Windows.Forms.Panel
    Friend WithEvents TextBox372 As System.Windows.Forms.TextBox
    Friend WithEvents Panel445 As System.Windows.Forms.Panel
    Friend WithEvents TextBox373 As System.Windows.Forms.TextBox
    Friend WithEvents Panel446 As System.Windows.Forms.Panel
    Friend WithEvents Label257 As System.Windows.Forms.Label
    Friend WithEvents Panel447 As System.Windows.Forms.Panel
    Friend WithEvents TextBox374 As System.Windows.Forms.TextBox
    Friend WithEvents Panel448 As System.Windows.Forms.Panel
    Friend WithEvents TextBox375 As System.Windows.Forms.TextBox
    Friend WithEvents Panel449 As System.Windows.Forms.Panel
    Friend WithEvents TextBox376 As System.Windows.Forms.TextBox
    Friend WithEvents Panel450 As System.Windows.Forms.Panel
    Friend WithEvents TextBox377 As System.Windows.Forms.TextBox
    Friend WithEvents Panel451 As System.Windows.Forms.Panel
    Friend WithEvents TextBox378 As System.Windows.Forms.TextBox
    Friend WithEvents Panel452 As System.Windows.Forms.Panel
    Friend WithEvents TextBox379 As System.Windows.Forms.TextBox
    Friend WithEvents Panel453 As System.Windows.Forms.Panel
    Friend WithEvents TextBox380 As System.Windows.Forms.TextBox
    Friend WithEvents Panel454 As System.Windows.Forms.Panel
    Friend WithEvents TextBox381 As System.Windows.Forms.TextBox
    Friend WithEvents Panel455 As System.Windows.Forms.Panel
    Friend WithEvents TextBox382 As System.Windows.Forms.TextBox
    Friend WithEvents Panel502 As System.Windows.Forms.Panel
    Friend WithEvents TextBox383 As System.Windows.Forms.TextBox
    Friend WithEvents Panel503 As System.Windows.Forms.Panel
    Friend WithEvents TextBox384 As System.Windows.Forms.TextBox
    Friend WithEvents Panel504 As System.Windows.Forms.Panel
    Friend WithEvents TextBox385 As System.Windows.Forms.TextBox
    Friend WithEvents Panel505 As System.Windows.Forms.Panel
    Friend WithEvents TextBox386 As System.Windows.Forms.TextBox
    Friend WithEvents Panel506 As System.Windows.Forms.Panel
    Friend WithEvents TextBox387 As System.Windows.Forms.TextBox
    Friend WithEvents Panel507 As System.Windows.Forms.Panel
    Friend WithEvents TextBox388 As System.Windows.Forms.TextBox
    Friend WithEvents Panel508 As System.Windows.Forms.Panel
    Friend WithEvents TextBox389 As System.Windows.Forms.TextBox
    Friend WithEvents Panel509 As System.Windows.Forms.Panel
    Friend WithEvents Label258 As System.Windows.Forms.Label
    Friend WithEvents Panel510 As System.Windows.Forms.Panel
    Friend WithEvents TextBox390 As System.Windows.Forms.TextBox
    Friend WithEvents Panel511 As System.Windows.Forms.Panel
    Friend WithEvents TextBox391 As System.Windows.Forms.TextBox
    Friend WithEvents Panel512 As System.Windows.Forms.Panel
    Friend WithEvents TextBox392 As System.Windows.Forms.TextBox
    Friend WithEvents Panel513 As System.Windows.Forms.Panel
    Friend WithEvents Label259 As System.Windows.Forms.Label
    Friend WithEvents Panel514 As System.Windows.Forms.Panel
    Friend WithEvents TextBox393 As System.Windows.Forms.TextBox
    Friend WithEvents Panel515 As System.Windows.Forms.Panel
    Friend WithEvents TextBox394 As System.Windows.Forms.TextBox
    Friend WithEvents Panel516 As System.Windows.Forms.Panel
    Friend WithEvents Label260 As System.Windows.Forms.Label
    Friend WithEvents Panel517 As System.Windows.Forms.Panel
    Friend WithEvents TextBox395 As System.Windows.Forms.TextBox
    Friend WithEvents Panel518 As System.Windows.Forms.Panel
    Friend WithEvents TextBox396 As System.Windows.Forms.TextBox
    Friend WithEvents Panel456 As System.Windows.Forms.Panel
    Friend WithEvents TextBox397 As System.Windows.Forms.TextBox
    Friend WithEvents Panel457 As System.Windows.Forms.Panel
    Friend WithEvents TextBox398 As System.Windows.Forms.TextBox
    Friend WithEvents Panel458 As System.Windows.Forms.Panel
    Friend WithEvents TextBox399 As System.Windows.Forms.TextBox
    Friend WithEvents Panel459 As System.Windows.Forms.Panel
    Friend WithEvents Label261 As System.Windows.Forms.Label
    Friend WithEvents Panel460 As System.Windows.Forms.Panel
    Friend WithEvents Label262 As System.Windows.Forms.Label
    Friend WithEvents Panel461 As System.Windows.Forms.Panel
    Friend WithEvents Label263 As System.Windows.Forms.Label
    Friend WithEvents Panel462 As System.Windows.Forms.Panel
    Friend WithEvents TextBox400 As System.Windows.Forms.TextBox
    Friend WithEvents Panel463 As System.Windows.Forms.Panel
    Friend WithEvents TextBox401 As System.Windows.Forms.TextBox
    Friend WithEvents Panel464 As System.Windows.Forms.Panel
    Friend WithEvents Label264 As System.Windows.Forms.Label
    Friend WithEvents Panel465 As System.Windows.Forms.Panel
    Friend WithEvents Label265 As System.Windows.Forms.Label
    Friend WithEvents Label266 As System.Windows.Forms.Label
    Friend WithEvents TextBox402 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox403 As System.Windows.Forms.TextBox
    Friend WithEvents Panel466 As System.Windows.Forms.Panel
    Friend WithEvents TextBox404 As System.Windows.Forms.TextBox
    Friend WithEvents Panel467 As System.Windows.Forms.Panel
    Friend WithEvents Label267 As System.Windows.Forms.Label
    Friend WithEvents Label268 As System.Windows.Forms.Label
    Friend WithEvents Panel468 As System.Windows.Forms.Panel
    Friend WithEvents TextBox405 As System.Windows.Forms.TextBox
    Friend WithEvents Panel469 As System.Windows.Forms.Panel
    Friend WithEvents TextBox406 As System.Windows.Forms.TextBox
    Friend WithEvents Panel470 As System.Windows.Forms.Panel
    Friend WithEvents Label269 As System.Windows.Forms.Label
    Friend WithEvents Panel471 As System.Windows.Forms.Panel
    Friend WithEvents Label270 As System.Windows.Forms.Label
    Friend WithEvents Panel472 As System.Windows.Forms.Panel
    Friend WithEvents Label271 As System.Windows.Forms.Label
    Friend WithEvents Panel473 As System.Windows.Forms.Panel
    Friend WithEvents TextBox407 As System.Windows.Forms.TextBox
    Friend WithEvents Panel474 As System.Windows.Forms.Panel
    Friend WithEvents Label272 As System.Windows.Forms.Label
    Friend WithEvents Panel475 As System.Windows.Forms.Panel
    Friend WithEvents Label273 As System.Windows.Forms.Label
    Friend WithEvents Panel476 As System.Windows.Forms.Panel
    Friend WithEvents Label274 As System.Windows.Forms.Label
    Friend WithEvents Panel477 As System.Windows.Forms.Panel
    Friend WithEvents TextBox408 As System.Windows.Forms.TextBox
    Friend WithEvents Panel478 As System.Windows.Forms.Panel
    Friend WithEvents Label275 As System.Windows.Forms.Label
    Friend WithEvents Panel479 As System.Windows.Forms.Panel
    Friend WithEvents Label276 As System.Windows.Forms.Label
    Friend WithEvents Panel480 As System.Windows.Forms.Panel
    Friend WithEvents Label277 As System.Windows.Forms.Label
    Friend WithEvents Panel481 As System.Windows.Forms.Panel
    Friend WithEvents TextBox409 As System.Windows.Forms.TextBox
    Friend WithEvents Panel482 As System.Windows.Forms.Panel
    Friend WithEvents TextBox410 As System.Windows.Forms.TextBox
    Friend WithEvents Panel483 As System.Windows.Forms.Panel
    Friend WithEvents TextBox411 As System.Windows.Forms.TextBox
    Friend WithEvents Panel484 As System.Windows.Forms.Panel
    Friend WithEvents Label278 As System.Windows.Forms.Label
    Friend WithEvents Panel485 As System.Windows.Forms.Panel
    Friend WithEvents Label279 As System.Windows.Forms.Label
    Friend WithEvents Panel486 As System.Windows.Forms.Panel
    Friend WithEvents TextBox412 As System.Windows.Forms.TextBox
    Friend WithEvents Panel487 As System.Windows.Forms.Panel
    Friend WithEvents TextBox413 As System.Windows.Forms.TextBox
    Friend WithEvents Panel488 As System.Windows.Forms.Panel
    Friend WithEvents Label280 As System.Windows.Forms.Label
    Friend WithEvents Panel489 As System.Windows.Forms.Panel
    Friend WithEvents TextBox414 As System.Windows.Forms.TextBox
    Friend WithEvents Panel490 As System.Windows.Forms.Panel
    Friend WithEvents TextBox415 As System.Windows.Forms.TextBox
    Friend WithEvents Panel491 As System.Windows.Forms.Panel
    Friend WithEvents TextBox416 As System.Windows.Forms.TextBox
    Friend WithEvents Panel492 As System.Windows.Forms.Panel
    Friend WithEvents TextBox417 As System.Windows.Forms.TextBox
    Friend WithEvents Panel493 As System.Windows.Forms.Panel
    Friend WithEvents TextBox418 As System.Windows.Forms.TextBox
    Friend WithEvents Panel494 As System.Windows.Forms.Panel
    Friend WithEvents TextBox419 As System.Windows.Forms.TextBox
    Friend WithEvents Panel495 As System.Windows.Forms.Panel
    Friend WithEvents TextBox420 As System.Windows.Forms.TextBox
    Friend WithEvents Panel496 As System.Windows.Forms.Panel
    Friend WithEvents TextBox421 As System.Windows.Forms.TextBox
    Friend WithEvents Panel497 As System.Windows.Forms.Panel
    Friend WithEvents TextBox422 As System.Windows.Forms.TextBox
    Friend WithEvents Panel519 As System.Windows.Forms.Panel
    Friend WithEvents TextBox423 As System.Windows.Forms.TextBox
    Friend WithEvents Panel520 As System.Windows.Forms.Panel
    Friend WithEvents TextBox424 As System.Windows.Forms.TextBox
    Friend WithEvents Panel521 As System.Windows.Forms.Panel
    Friend WithEvents TextBox425 As System.Windows.Forms.TextBox
    Friend WithEvents Panel522 As System.Windows.Forms.Panel
    Friend WithEvents TextBox426 As System.Windows.Forms.TextBox
    Friend WithEvents Panel523 As System.Windows.Forms.Panel
    Friend WithEvents TextBox427 As System.Windows.Forms.TextBox
    Friend WithEvents Panel524 As System.Windows.Forms.Panel
    Friend WithEvents TextBox428 As System.Windows.Forms.TextBox
    Friend WithEvents Panel525 As System.Windows.Forms.Panel
    Friend WithEvents TextBox429 As System.Windows.Forms.TextBox
    Friend WithEvents Panel526 As System.Windows.Forms.Panel
    Friend WithEvents Label281 As System.Windows.Forms.Label
    Friend WithEvents Panel527 As System.Windows.Forms.Panel
    Friend WithEvents TextBox430 As System.Windows.Forms.TextBox
    Friend WithEvents Panel528 As System.Windows.Forms.Panel
    Friend WithEvents TextBox431 As System.Windows.Forms.TextBox
    Friend WithEvents Panel529 As System.Windows.Forms.Panel
    Friend WithEvents TextBox432 As System.Windows.Forms.TextBox
    Friend WithEvents Panel530 As System.Windows.Forms.Panel
    Friend WithEvents Label282 As System.Windows.Forms.Label
    Friend WithEvents Panel531 As System.Windows.Forms.Panel
    Friend WithEvents TextBox433 As System.Windows.Forms.TextBox
    Friend WithEvents Panel532 As System.Windows.Forms.Panel
    Friend WithEvents TextBox434 As System.Windows.Forms.TextBox
    Friend WithEvents Panel533 As System.Windows.Forms.Panel
    Friend WithEvents Label283 As System.Windows.Forms.Label
    Friend WithEvents Panel534 As System.Windows.Forms.Panel
    Friend WithEvents TextBox435 As System.Windows.Forms.TextBox
    Friend WithEvents Panel535 As System.Windows.Forms.Panel
    Friend WithEvents TextBox436 As System.Windows.Forms.TextBox
    Friend WithEvents diagBuses_tab_pressionTroncons_rampe As System.Windows.Forms.TabControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.Panel14 = New System.Windows.Forms.Panel
Me.Label10 = New System.Windows.Forms.Label
Me.Label22 = New System.Windows.Forms.Label
Me.TextBox43 = New System.Windows.Forms.TextBox
Me.TextBox44 = New System.Windows.Forms.TextBox
Me.Panel21 = New System.Windows.Forms.Panel
Me.Label11 = New System.Windows.Forms.Label
Me.Panel22 = New System.Windows.Forms.Panel
Me.Label12 = New System.Windows.Forms.Label
Me.Panel23 = New System.Windows.Forms.Panel
Me.Label17 = New System.Windows.Forms.Label
Me.Panel24 = New System.Windows.Forms.Panel
Me.Label18 = New System.Windows.Forms.Label
Me.Panel25 = New System.Windows.Forms.Panel
Me.Label19 = New System.Windows.Forms.Label
Me.Panel26 = New System.Windows.Forms.Panel
Me.Label20 = New System.Windows.Forms.Label
Me.Panel27 = New System.Windows.Forms.Panel
Me.Label21 = New System.Windows.Forms.Label
Me.Panel28 = New System.Windows.Forms.Panel
Me.Label23 = New System.Windows.Forms.Label
Me.Panel29 = New System.Windows.Forms.Panel
Me.Label24 = New System.Windows.Forms.Label
Me.Label25 = New System.Windows.Forms.Label
Me.Panel30 = New System.Windows.Forms.Panel
Me.Label26 = New System.Windows.Forms.Label
Me.Label34 = New System.Windows.Forms.Label
Me.Panel31 = New System.Windows.Forms.Panel
Me.Label35 = New System.Windows.Forms.Label
Me.Panel32 = New System.Windows.Forms.Panel
Me.Label36 = New System.Windows.Forms.Label
Me.Panel33 = New System.Windows.Forms.Panel
Me.Label37 = New System.Windows.Forms.Label
Me.Label38 = New System.Windows.Forms.Label
Me.Panel34 = New System.Windows.Forms.Panel
Me.Label39 = New System.Windows.Forms.Label
Me.Label40 = New System.Windows.Forms.Label
Me.Panel35 = New System.Windows.Forms.Panel
Me.Label41 = New System.Windows.Forms.Label
Me.Panel36 = New System.Windows.Forms.Panel
Me.Label42 = New System.Windows.Forms.Label
Me.Panel37 = New System.Windows.Forms.Panel
Me.Label43 = New System.Windows.Forms.Label
Me.Label44 = New System.Windows.Forms.Label
Me.Panel38 = New System.Windows.Forms.Panel
Me.Label45 = New System.Windows.Forms.Label
Me.Label46 = New System.Windows.Forms.Label
Me.Panel39 = New System.Windows.Forms.Panel
Me.Label47 = New System.Windows.Forms.Label
Me.Panel40 = New System.Windows.Forms.Panel
Me.TextBox4 = New System.Windows.Forms.TextBox
Me.TextBox3 = New System.Windows.Forms.TextBox
Me.Panel41 = New System.Windows.Forms.Panel
Me.TextBox5 = New System.Windows.Forms.TextBox
Me.TextBox6 = New System.Windows.Forms.TextBox
Me.Panel42 = New System.Windows.Forms.Panel
Me.TextBox11 = New System.Windows.Forms.TextBox
Me.TextBox12 = New System.Windows.Forms.TextBox
Me.Panel43 = New System.Windows.Forms.Panel
Me.TextBox13 = New System.Windows.Forms.TextBox
Me.TextBox14 = New System.Windows.Forms.TextBox
Me.Panel44 = New System.Windows.Forms.Panel
Me.TextBox15 = New System.Windows.Forms.TextBox
Me.TextBox16 = New System.Windows.Forms.TextBox
Me.Panel45 = New System.Windows.Forms.Panel
Me.TextBox17 = New System.Windows.Forms.TextBox
Me.TextBox18 = New System.Windows.Forms.TextBox
Me.Panel46 = New System.Windows.Forms.Panel
Me.TextBox19 = New System.Windows.Forms.TextBox
Me.TextBox20 = New System.Windows.Forms.TextBox
Me.Panel47 = New System.Windows.Forms.Panel
Me.TextBox21 = New System.Windows.Forms.TextBox
Me.TextBox22 = New System.Windows.Forms.TextBox
Me.Panel48 = New System.Windows.Forms.Panel
Me.TextBox23 = New System.Windows.Forms.TextBox
Me.TextBox24 = New System.Windows.Forms.TextBox
Me.Panel49 = New System.Windows.Forms.Panel
Me.TextBox25 = New System.Windows.Forms.TextBox
Me.TextBox26 = New System.Windows.Forms.TextBox
Me.Panel52 = New System.Windows.Forms.Panel
Me.TextBox27 = New System.Windows.Forms.TextBox
Me.TextBox28 = New System.Windows.Forms.TextBox
Me.Panel53 = New System.Windows.Forms.Panel
Me.TextBox29 = New System.Windows.Forms.TextBox
Me.TextBox30 = New System.Windows.Forms.TextBox
Me.Panel54 = New System.Windows.Forms.Panel
Me.TextBox31 = New System.Windows.Forms.TextBox
Me.TextBox32 = New System.Windows.Forms.TextBox
Me.Panel55 = New System.Windows.Forms.Panel
Me.TextBox33 = New System.Windows.Forms.TextBox
Me.TextBox34 = New System.Windows.Forms.TextBox
Me.Panel56 = New System.Windows.Forms.Panel
Me.TextBox35 = New System.Windows.Forms.TextBox
Me.TextBox36 = New System.Windows.Forms.TextBox
Me.Panel57 = New System.Windows.Forms.Panel
Me.TextBox37 = New System.Windows.Forms.TextBox
Me.TextBox38 = New System.Windows.Forms.TextBox
Me.Panel58 = New System.Windows.Forms.Panel
Me.TextBox39 = New System.Windows.Forms.TextBox
Me.TextBox40 = New System.Windows.Forms.TextBox
Me.Panel59 = New System.Windows.Forms.Panel
Me.TextBox41 = New System.Windows.Forms.TextBox
Me.TextBox42 = New System.Windows.Forms.TextBox
Me.Panel63 = New System.Windows.Forms.Panel
Me.TextBox46 = New System.Windows.Forms.TextBox
Me.Panel64 = New System.Windows.Forms.Panel
Me.TextBox45 = New System.Windows.Forms.TextBox
Me.Panel83 = New System.Windows.Forms.Panel
Me.Label48 = New System.Windows.Forms.Label
Me.Panel84 = New System.Windows.Forms.Panel
Me.Label49 = New System.Windows.Forms.Label
Me.Label54 = New System.Windows.Forms.Label
Me.Panel1 = New System.Windows.Forms.Panel
Me.TextBox1 = New System.Windows.Forms.TextBox
Me.Panel2 = New System.Windows.Forms.Panel
Me.TextBox7 = New System.Windows.Forms.TextBox
Me.Panel3 = New System.Windows.Forms.Panel
Me.TextBox9 = New System.Windows.Forms.TextBox
Me.Panel4 = New System.Windows.Forms.Panel
Me.Label1 = New System.Windows.Forms.Label
Me.Panel5 = New System.Windows.Forms.Panel
Me.Label2 = New System.Windows.Forms.Label
Me.Panel6 = New System.Windows.Forms.Panel
Me.Label3 = New System.Windows.Forms.Label
Me.Panel7 = New System.Windows.Forms.Panel
Me.TextBox10 = New System.Windows.Forms.TextBox
Me.Panel8 = New System.Windows.Forms.Panel
Me.TextBox47 = New System.Windows.Forms.TextBox
Me.Panel9 = New System.Windows.Forms.Panel
Me.Label4 = New System.Windows.Forms.Label
Me.Panel10 = New System.Windows.Forms.Panel
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.TextBox49 = New System.Windows.Forms.TextBox
Me.TextBox50 = New System.Windows.Forms.TextBox
Me.Panel11 = New System.Windows.Forms.Panel
Me.TextBox51 = New System.Windows.Forms.TextBox
Me.Panel13 = New System.Windows.Forms.Panel
Me.Label9 = New System.Windows.Forms.Label
Me.Label13 = New System.Windows.Forms.Label
Me.Panel16 = New System.Windows.Forms.Panel
Me.TextBox53 = New System.Windows.Forms.TextBox
Me.Panel18 = New System.Windows.Forms.Panel
Me.TextBox55 = New System.Windows.Forms.TextBox
Me.Panel20 = New System.Windows.Forms.Panel
Me.Label30 = New System.Windows.Forms.Label
Me.Panel50 = New System.Windows.Forms.Panel
Me.Label31 = New System.Windows.Forms.Label
Me.Panel51 = New System.Windows.Forms.Panel
Me.Label32 = New System.Windows.Forms.Label
Me.Panel60 = New System.Windows.Forms.Panel
Me.TextBox57 = New System.Windows.Forms.TextBox
Me.Panel61 = New System.Windows.Forms.Panel
Me.Label33 = New System.Windows.Forms.Label
Me.Panel62 = New System.Windows.Forms.Panel
Me.Label50 = New System.Windows.Forms.Label
Me.Panel65 = New System.Windows.Forms.Panel
Me.Label51 = New System.Windows.Forms.Label
Me.Panel66 = New System.Windows.Forms.Panel
Me.TextBox59 = New System.Windows.Forms.TextBox
Me.Panel67 = New System.Windows.Forms.Panel
Me.Label52 = New System.Windows.Forms.Label
Me.Panel68 = New System.Windows.Forms.Panel
Me.Label53 = New System.Windows.Forms.Label
Me.Panel70 = New System.Windows.Forms.Panel
Me.Label56 = New System.Windows.Forms.Label
Me.Panel71 = New System.Windows.Forms.Panel
Me.TextBox61 = New System.Windows.Forms.TextBox
Me.Panel73 = New System.Windows.Forms.Panel
Me.TextBox63 = New System.Windows.Forms.TextBox
Me.Panel75 = New System.Windows.Forms.Panel
Me.TextBox65 = New System.Windows.Forms.TextBox
Me.Panel76 = New System.Windows.Forms.Panel
Me.Label69 = New System.Windows.Forms.Label
Me.Panel78 = New System.Windows.Forms.Panel
Me.Label75 = New System.Windows.Forms.Label
Me.Panel79 = New System.Windows.Forms.Panel
Me.TextBox67 = New System.Windows.Forms.TextBox
Me.Panel93 = New System.Windows.Forms.Panel
Me.TextBox69 = New System.Windows.Forms.TextBox
Me.Panel94 = New System.Windows.Forms.Panel
Me.Label82 = New System.Windows.Forms.Label
Me.Panel95 = New System.Windows.Forms.Panel
Me.TextBox71 = New System.Windows.Forms.TextBox
Me.Panel96 = New System.Windows.Forms.Panel
Me.TextBox73 = New System.Windows.Forms.TextBox
Me.Panel97 = New System.Windows.Forms.Panel
Me.TextBox75 = New System.Windows.Forms.TextBox
Me.Panel98 = New System.Windows.Forms.Panel
Me.TextBox77 = New System.Windows.Forms.TextBox
Me.Panel99 = New System.Windows.Forms.Panel
Me.TextBox79 = New System.Windows.Forms.TextBox
Me.Panel100 = New System.Windows.Forms.Panel
Me.TextBox121 = New System.Windows.Forms.TextBox
Me.Panel101 = New System.Windows.Forms.Panel
Me.TextBox123 = New System.Windows.Forms.TextBox
Me.Panel102 = New System.Windows.Forms.Panel
Me.TextBox125 = New System.Windows.Forms.TextBox
Me.Panel103 = New System.Windows.Forms.Panel
Me.TextBox127 = New System.Windows.Forms.TextBox
Me.Panel104 = New System.Windows.Forms.Panel
Me.TextBox129 = New System.Windows.Forms.TextBox
Me.Panel105 = New System.Windows.Forms.Panel
Me.TextBox131 = New System.Windows.Forms.TextBox
Me.Panel106 = New System.Windows.Forms.Panel
Me.TextBox133 = New System.Windows.Forms.TextBox
Me.Panel107 = New System.Windows.Forms.Panel
Me.TextBox135 = New System.Windows.Forms.TextBox
Me.Panel108 = New System.Windows.Forms.Panel
Me.TextBox137 = New System.Windows.Forms.TextBox
Me.Panel110 = New System.Windows.Forms.Panel
Me.TextBox139 = New System.Windows.Forms.TextBox
Me.Panel111 = New System.Windows.Forms.Panel
Me.TextBox141 = New System.Windows.Forms.TextBox
Me.Panel112 = New System.Windows.Forms.Panel
Me.Label85 = New System.Windows.Forms.Label
Me.Panel113 = New System.Windows.Forms.Panel
Me.TextBox143 = New System.Windows.Forms.TextBox
Me.Panel114 = New System.Windows.Forms.Panel
Me.TextBox145 = New System.Windows.Forms.TextBox
Me.Panel115 = New System.Windows.Forms.Panel
Me.TextBox147 = New System.Windows.Forms.TextBox
Me.Panel116 = New System.Windows.Forms.Panel
Me.Label86 = New System.Windows.Forms.Label
Me.Panel117 = New System.Windows.Forms.Panel
Me.TextBox149 = New System.Windows.Forms.TextBox
Me.Panel118 = New System.Windows.Forms.Panel
Me.TextBox151 = New System.Windows.Forms.TextBox
Me.Panel119 = New System.Windows.Forms.Panel
Me.Label87 = New System.Windows.Forms.Label
Me.Panel120 = New System.Windows.Forms.Panel
Me.TextBox153 = New System.Windows.Forms.TextBox
Me.Panel122 = New System.Windows.Forms.Panel
Me.TextBox155 = New System.Windows.Forms.TextBox
Me.diagBuses_tab_pressionTroncons = New System.Windows.Forms.TabControl
Me.TabPage1 = New System.Windows.Forms.TabPage
Me.Panel12 = New System.Windows.Forms.Panel
Me.TextBox2 = New System.Windows.Forms.TextBox
Me.TextBox8 = New System.Windows.Forms.TextBox
Me.Panel15 = New System.Windows.Forms.Panel
Me.TextBox48 = New System.Windows.Forms.TextBox
Me.TextBox52 = New System.Windows.Forms.TextBox
Me.Panel17 = New System.Windows.Forms.Panel
Me.TextBox54 = New System.Windows.Forms.TextBox
Me.TextBox56 = New System.Windows.Forms.TextBox
Me.Panel19 = New System.Windows.Forms.Panel
Me.TextBox58 = New System.Windows.Forms.TextBox
Me.TextBox60 = New System.Windows.Forms.TextBox
Me.Panel69 = New System.Windows.Forms.Panel
Me.TextBox62 = New System.Windows.Forms.TextBox
Me.TextBox64 = New System.Windows.Forms.TextBox
Me.Panel72 = New System.Windows.Forms.Panel
Me.TextBox66 = New System.Windows.Forms.TextBox
Me.TextBox68 = New System.Windows.Forms.TextBox
Me.Panel74 = New System.Windows.Forms.Panel
Me.TextBox70 = New System.Windows.Forms.TextBox
Me.TextBox72 = New System.Windows.Forms.TextBox
Me.Panel77 = New System.Windows.Forms.Panel
Me.TextBox74 = New System.Windows.Forms.TextBox
Me.TextBox76 = New System.Windows.Forms.TextBox
Me.Panel80 = New System.Windows.Forms.Panel
Me.TextBox78 = New System.Windows.Forms.TextBox
Me.TextBox80 = New System.Windows.Forms.TextBox
Me.Panel81 = New System.Windows.Forms.Panel
Me.TextBox122 = New System.Windows.Forms.TextBox
Me.TextBox124 = New System.Windows.Forms.TextBox
Me.Panel82 = New System.Windows.Forms.Panel
Me.TextBox126 = New System.Windows.Forms.TextBox
Me.TextBox128 = New System.Windows.Forms.TextBox
Me.Panel109 = New System.Windows.Forms.Panel
Me.TextBox130 = New System.Windows.Forms.TextBox
Me.TextBox132 = New System.Windows.Forms.TextBox
Me.Panel121 = New System.Windows.Forms.Panel
Me.TextBox134 = New System.Windows.Forms.TextBox
Me.Panel123 = New System.Windows.Forms.Panel
Me.Label7 = New System.Windows.Forms.Label
Me.Panel124 = New System.Windows.Forms.Panel
Me.TextBox136 = New System.Windows.Forms.TextBox
Me.Panel125 = New System.Windows.Forms.Panel
Me.Label8 = New System.Windows.Forms.Label
Me.Panel127 = New System.Windows.Forms.Panel
Me.Label14 = New System.Windows.Forms.Label
Me.Label15 = New System.Windows.Forms.Label
Me.TextBox138 = New System.Windows.Forms.TextBox
Me.TextBox140 = New System.Windows.Forms.TextBox
Me.Panel128 = New System.Windows.Forms.Panel
Me.Label16 = New System.Windows.Forms.Label
Me.Label27 = New System.Windows.Forms.Label
Me.Panel129 = New System.Windows.Forms.Panel
Me.Label28 = New System.Windows.Forms.Label
Me.Label29 = New System.Windows.Forms.Label
Me.Panel130 = New System.Windows.Forms.Panel
Me.Label55 = New System.Windows.Forms.Label
Me.Label57 = New System.Windows.Forms.Label
Me.Panel132 = New System.Windows.Forms.Panel
Me.Label58 = New System.Windows.Forms.Label
Me.Panel133 = New System.Windows.Forms.Panel
Me.Label59 = New System.Windows.Forms.Label
Me.Panel166 = New System.Windows.Forms.Panel
Me.Label60 = New System.Windows.Forms.Label
Me.Panel167 = New System.Windows.Forms.Panel
Me.Label70 = New System.Windows.Forms.Label
Me.Panel168 = New System.Windows.Forms.Panel
Me.Label74 = New System.Windows.Forms.Label
Me.Panel169 = New System.Windows.Forms.Panel
Me.Label76 = New System.Windows.Forms.Label
Me.Panel170 = New System.Windows.Forms.Panel
Me.Label77 = New System.Windows.Forms.Label
Me.Panel171 = New System.Windows.Forms.Panel
Me.Label78 = New System.Windows.Forms.Label
Me.Panel172 = New System.Windows.Forms.Panel
Me.Label79 = New System.Windows.Forms.Label
Me.Panel173 = New System.Windows.Forms.Panel
Me.Label80 = New System.Windows.Forms.Label
Me.Label81 = New System.Windows.Forms.Label
Me.Panel174 = New System.Windows.Forms.Panel
Me.Label83 = New System.Windows.Forms.Label
Me.Label84 = New System.Windows.Forms.Label
Me.Panel175 = New System.Windows.Forms.Panel
Me.Label88 = New System.Windows.Forms.Label
Me.Panel176 = New System.Windows.Forms.Panel
Me.Label89 = New System.Windows.Forms.Label
Me.Panel177 = New System.Windows.Forms.Panel
Me.Label91 = New System.Windows.Forms.Label
Me.Label92 = New System.Windows.Forms.Label
Me.Panel178 = New System.Windows.Forms.Panel
Me.Label93 = New System.Windows.Forms.Label
Me.Label94 = New System.Windows.Forms.Label
Me.Panel179 = New System.Windows.Forms.Panel
Me.Label95 = New System.Windows.Forms.Label
Me.Panel180 = New System.Windows.Forms.Panel
Me.TextBox142 = New System.Windows.Forms.TextBox
Me.TextBox144 = New System.Windows.Forms.TextBox
Me.Panel181 = New System.Windows.Forms.Panel
Me.TextBox146 = New System.Windows.Forms.TextBox
Me.TextBox148 = New System.Windows.Forms.TextBox
Me.Panel182 = New System.Windows.Forms.Panel
Me.TextBox150 = New System.Windows.Forms.TextBox
Me.TextBox152 = New System.Windows.Forms.TextBox
Me.Panel183 = New System.Windows.Forms.Panel
Me.TextBox154 = New System.Windows.Forms.TextBox
Me.TextBox156 = New System.Windows.Forms.TextBox
Me.Panel184 = New System.Windows.Forms.Panel
Me.TextBox157 = New System.Windows.Forms.TextBox
Me.TextBox158 = New System.Windows.Forms.TextBox
Me.Panel185 = New System.Windows.Forms.Panel
Me.TextBox159 = New System.Windows.Forms.TextBox
Me.TextBox160 = New System.Windows.Forms.TextBox
Me.Panel186 = New System.Windows.Forms.Panel
Me.TextBox161 = New System.Windows.Forms.TextBox
Me.TextBox162 = New System.Windows.Forms.TextBox
Me.Panel187 = New System.Windows.Forms.Panel
Me.TextBox163 = New System.Windows.Forms.TextBox
Me.TextBox164 = New System.Windows.Forms.TextBox
Me.Panel188 = New System.Windows.Forms.Panel
Me.Label96 = New System.Windows.Forms.Label
Me.Label97 = New System.Windows.Forms.Label
Me.Panel189 = New System.Windows.Forms.Panel
Me.Label98 = New System.Windows.Forms.Label
Me.Panel190 = New System.Windows.Forms.Panel
Me.TextBox165 = New System.Windows.Forms.TextBox
Me.TextBox166 = New System.Windows.Forms.TextBox
Me.Panel191 = New System.Windows.Forms.Panel
Me.Label99 = New System.Windows.Forms.Label
Me.Panel192 = New System.Windows.Forms.Panel
Me.TextBox167 = New System.Windows.Forms.TextBox
Me.TextBox168 = New System.Windows.Forms.TextBox
Me.Panel193 = New System.Windows.Forms.Panel
Me.TextBox169 = New System.Windows.Forms.TextBox
Me.TextBox170 = New System.Windows.Forms.TextBox
Me.Panel194 = New System.Windows.Forms.Panel
Me.Label100 = New System.Windows.Forms.Label
Me.Label101 = New System.Windows.Forms.Label
Me.Panel195 = New System.Windows.Forms.Panel
Me.TextBox171 = New System.Windows.Forms.TextBox
Me.TextBox172 = New System.Windows.Forms.TextBox
Me.Panel196 = New System.Windows.Forms.Panel
Me.Label102 = New System.Windows.Forms.Label
Me.Label122 = New System.Windows.Forms.Label
Me.Panel197 = New System.Windows.Forms.Panel
Me.TextBox173 = New System.Windows.Forms.TextBox
Me.TextBox174 = New System.Windows.Forms.TextBox
Me.Panel198 = New System.Windows.Forms.Panel
Me.Label123 = New System.Windows.Forms.Label
Me.Panel199 = New System.Windows.Forms.Panel
Me.TextBox175 = New System.Windows.Forms.TextBox
Me.TextBox176 = New System.Windows.Forms.TextBox
Me.Panel200 = New System.Windows.Forms.Panel
Me.TextBox177 = New System.Windows.Forms.TextBox
Me.TextBox178 = New System.Windows.Forms.TextBox
Me.Panel201 = New System.Windows.Forms.Panel
Me.TextBox179 = New System.Windows.Forms.TextBox
Me.TextBox180 = New System.Windows.Forms.TextBox
Me.Panel202 = New System.Windows.Forms.Panel
Me.Label124 = New System.Windows.Forms.Label
Me.Label125 = New System.Windows.Forms.Label
Me.Panel203 = New System.Windows.Forms.Panel
Me.TextBox181 = New System.Windows.Forms.TextBox
Me.TextBox182 = New System.Windows.Forms.TextBox
Me.Panel204 = New System.Windows.Forms.Panel
Me.Label126 = New System.Windows.Forms.Label
Me.Panel205 = New System.Windows.Forms.Panel
Me.TextBox183 = New System.Windows.Forms.TextBox
Me.TextBox184 = New System.Windows.Forms.TextBox
Me.Panel206 = New System.Windows.Forms.Panel
Me.TextBox185 = New System.Windows.Forms.TextBox
Me.TextBox186 = New System.Windows.Forms.TextBox
Me.Panel207 = New System.Windows.Forms.Panel
Me.TextBox187 = New System.Windows.Forms.TextBox
Me.TextBox188 = New System.Windows.Forms.TextBox
Me.Panel208 = New System.Windows.Forms.Panel
Me.TextBox189 = New System.Windows.Forms.TextBox
Me.TextBox190 = New System.Windows.Forms.TextBox
Me.Panel209 = New System.Windows.Forms.Panel
Me.Label127 = New System.Windows.Forms.Label
Me.Panel210 = New System.Windows.Forms.Panel
Me.Label128 = New System.Windows.Forms.Label
Me.Label129 = New System.Windows.Forms.Label
Me.Panel211 = New System.Windows.Forms.Panel
Me.TextBox191 = New System.Windows.Forms.TextBox
Me.TextBox192 = New System.Windows.Forms.TextBox
Me.Panel212 = New System.Windows.Forms.Panel
Me.TextBox193 = New System.Windows.Forms.TextBox
Me.TextBox194 = New System.Windows.Forms.TextBox
Me.Panel213 = New System.Windows.Forms.Panel
Me.Label130 = New System.Windows.Forms.Label
Me.Panel214 = New System.Windows.Forms.Panel
Me.Label131 = New System.Windows.Forms.Label
Me.Label132 = New System.Windows.Forms.Label
Me.Panel215 = New System.Windows.Forms.Panel
Me.TextBox195 = New System.Windows.Forms.TextBox
Me.TextBox196 = New System.Windows.Forms.TextBox
Me.TabPage2 = New System.Windows.Forms.TabPage
Me.Panel216 = New System.Windows.Forms.Panel
Me.TextBox233 = New System.Windows.Forms.TextBox
Me.TextBox234 = New System.Windows.Forms.TextBox
Me.Panel217 = New System.Windows.Forms.Panel
Me.TextBox235 = New System.Windows.Forms.TextBox
Me.TextBox236 = New System.Windows.Forms.TextBox
Me.Panel218 = New System.Windows.Forms.Panel
Me.TextBox237 = New System.Windows.Forms.TextBox
Me.TextBox238 = New System.Windows.Forms.TextBox
Me.Panel219 = New System.Windows.Forms.Panel
Me.TextBox239 = New System.Windows.Forms.TextBox
Me.TextBox240 = New System.Windows.Forms.TextBox
Me.Panel220 = New System.Windows.Forms.Panel
Me.TextBox241 = New System.Windows.Forms.TextBox
Me.TextBox242 = New System.Windows.Forms.TextBox
Me.Panel221 = New System.Windows.Forms.Panel
Me.TextBox243 = New System.Windows.Forms.TextBox
Me.TextBox244 = New System.Windows.Forms.TextBox
Me.Panel222 = New System.Windows.Forms.Panel
Me.TextBox245 = New System.Windows.Forms.TextBox
Me.TextBox246 = New System.Windows.Forms.TextBox
Me.Panel223 = New System.Windows.Forms.Panel
Me.TextBox247 = New System.Windows.Forms.TextBox
Me.TextBox248 = New System.Windows.Forms.TextBox
Me.Panel224 = New System.Windows.Forms.Panel
Me.TextBox249 = New System.Windows.Forms.TextBox
Me.TextBox250 = New System.Windows.Forms.TextBox
Me.Panel225 = New System.Windows.Forms.Panel
Me.TextBox251 = New System.Windows.Forms.TextBox
Me.TextBox252 = New System.Windows.Forms.TextBox
Me.Panel226 = New System.Windows.Forms.Panel
Me.TextBox253 = New System.Windows.Forms.TextBox
Me.TextBox254 = New System.Windows.Forms.TextBox
Me.Panel227 = New System.Windows.Forms.Panel
Me.TextBox255 = New System.Windows.Forms.TextBox
Me.TextBox256 = New System.Windows.Forms.TextBox
Me.Panel228 = New System.Windows.Forms.Panel
Me.TextBox257 = New System.Windows.Forms.TextBox
Me.Panel229 = New System.Windows.Forms.Panel
Me.Label133 = New System.Windows.Forms.Label
Me.Panel230 = New System.Windows.Forms.Panel
Me.TextBox258 = New System.Windows.Forms.TextBox
Me.Panel231 = New System.Windows.Forms.Panel
Me.Label134 = New System.Windows.Forms.Label
Me.Panel232 = New System.Windows.Forms.Panel
Me.Label135 = New System.Windows.Forms.Label
Me.Label136 = New System.Windows.Forms.Label
Me.TextBox259 = New System.Windows.Forms.TextBox
Me.TextBox260 = New System.Windows.Forms.TextBox
Me.Panel233 = New System.Windows.Forms.Panel
Me.Label137 = New System.Windows.Forms.Label
Me.Label138 = New System.Windows.Forms.Label
Me.Panel234 = New System.Windows.Forms.Panel
Me.Label139 = New System.Windows.Forms.Label
Me.Label140 = New System.Windows.Forms.Label
Me.Panel235 = New System.Windows.Forms.Panel
Me.Label141 = New System.Windows.Forms.Label
Me.Label142 = New System.Windows.Forms.Label
Me.Panel236 = New System.Windows.Forms.Panel
Me.Label143 = New System.Windows.Forms.Label
Me.Panel237 = New System.Windows.Forms.Panel
Me.Label144 = New System.Windows.Forms.Label
Me.Panel238 = New System.Windows.Forms.Panel
Me.Label145 = New System.Windows.Forms.Label
Me.Panel239 = New System.Windows.Forms.Panel
Me.Label146 = New System.Windows.Forms.Label
Me.Panel240 = New System.Windows.Forms.Panel
Me.Label147 = New System.Windows.Forms.Label
Me.Panel241 = New System.Windows.Forms.Panel
Me.Label148 = New System.Windows.Forms.Label
Me.Panel242 = New System.Windows.Forms.Panel
Me.Label149 = New System.Windows.Forms.Label
Me.Panel243 = New System.Windows.Forms.Panel
Me.Label150 = New System.Windows.Forms.Label
Me.Panel244 = New System.Windows.Forms.Panel
Me.Label151 = New System.Windows.Forms.Label
Me.Panel245 = New System.Windows.Forms.Panel
Me.Label152 = New System.Windows.Forms.Label
Me.Label153 = New System.Windows.Forms.Label
Me.Panel246 = New System.Windows.Forms.Panel
Me.Label154 = New System.Windows.Forms.Label
Me.Label155 = New System.Windows.Forms.Label
Me.Panel247 = New System.Windows.Forms.Panel
Me.Label156 = New System.Windows.Forms.Label
Me.Panel248 = New System.Windows.Forms.Panel
Me.Label157 = New System.Windows.Forms.Label
Me.Panel249 = New System.Windows.Forms.Panel
Me.Label158 = New System.Windows.Forms.Label
Me.Label159 = New System.Windows.Forms.Label
Me.Panel250 = New System.Windows.Forms.Panel
Me.Label160 = New System.Windows.Forms.Label
Me.Label161 = New System.Windows.Forms.Label
Me.Panel251 = New System.Windows.Forms.Panel
Me.Label162 = New System.Windows.Forms.Label
Me.Panel252 = New System.Windows.Forms.Panel
Me.TextBox261 = New System.Windows.Forms.TextBox
Me.TextBox262 = New System.Windows.Forms.TextBox
Me.Panel253 = New System.Windows.Forms.Panel
Me.TextBox263 = New System.Windows.Forms.TextBox
Me.TextBox264 = New System.Windows.Forms.TextBox
Me.Panel254 = New System.Windows.Forms.Panel
Me.TextBox265 = New System.Windows.Forms.TextBox
Me.TextBox266 = New System.Windows.Forms.TextBox
Me.Panel255 = New System.Windows.Forms.Panel
Me.TextBox267 = New System.Windows.Forms.TextBox
Me.TextBox268 = New System.Windows.Forms.TextBox
Me.Panel256 = New System.Windows.Forms.Panel
Me.TextBox269 = New System.Windows.Forms.TextBox
Me.TextBox270 = New System.Windows.Forms.TextBox
Me.Panel257 = New System.Windows.Forms.Panel
Me.TextBox271 = New System.Windows.Forms.TextBox
Me.TextBox272 = New System.Windows.Forms.TextBox
Me.TabPage8 = New System.Windows.Forms.TabPage
Me.Panel258 = New System.Windows.Forms.Panel
Me.TextBox273 = New System.Windows.Forms.TextBox
Me.TextBox274 = New System.Windows.Forms.TextBox
Me.Panel259 = New System.Windows.Forms.Panel
Me.TextBox275 = New System.Windows.Forms.TextBox
Me.TextBox276 = New System.Windows.Forms.TextBox
Me.Panel260 = New System.Windows.Forms.Panel
Me.TextBox277 = New System.Windows.Forms.TextBox
Me.TextBox278 = New System.Windows.Forms.TextBox
Me.Panel261 = New System.Windows.Forms.Panel
Me.TextBox279 = New System.Windows.Forms.TextBox
Me.TextBox280 = New System.Windows.Forms.TextBox
Me.Panel262 = New System.Windows.Forms.Panel
Me.TextBox281 = New System.Windows.Forms.TextBox
Me.TextBox282 = New System.Windows.Forms.TextBox
Me.Panel263 = New System.Windows.Forms.Panel
Me.TextBox283 = New System.Windows.Forms.TextBox
Me.TextBox284 = New System.Windows.Forms.TextBox
Me.Panel264 = New System.Windows.Forms.Panel
Me.TextBox285 = New System.Windows.Forms.TextBox
Me.TextBox286 = New System.Windows.Forms.TextBox
Me.Panel265 = New System.Windows.Forms.Panel
Me.TextBox287 = New System.Windows.Forms.TextBox
Me.TextBox288 = New System.Windows.Forms.TextBox
Me.Panel266 = New System.Windows.Forms.Panel
Me.TextBox289 = New System.Windows.Forms.TextBox
Me.TextBox290 = New System.Windows.Forms.TextBox
Me.Panel267 = New System.Windows.Forms.Panel
Me.TextBox291 = New System.Windows.Forms.TextBox
Me.TextBox292 = New System.Windows.Forms.TextBox
Me.Panel268 = New System.Windows.Forms.Panel
Me.TextBox293 = New System.Windows.Forms.TextBox
Me.TextBox294 = New System.Windows.Forms.TextBox
Me.Panel269 = New System.Windows.Forms.Panel
Me.TextBox295 = New System.Windows.Forms.TextBox
Me.TextBox296 = New System.Windows.Forms.TextBox
Me.Panel270 = New System.Windows.Forms.Panel
Me.TextBox297 = New System.Windows.Forms.TextBox
Me.Panel271 = New System.Windows.Forms.Panel
Me.Label163 = New System.Windows.Forms.Label
Me.Panel272 = New System.Windows.Forms.Panel
Me.TextBox298 = New System.Windows.Forms.TextBox
Me.Panel273 = New System.Windows.Forms.Panel
Me.Label164 = New System.Windows.Forms.Label
Me.Panel274 = New System.Windows.Forms.Panel
Me.Label165 = New System.Windows.Forms.Label
Me.Label166 = New System.Windows.Forms.Label
Me.TextBox299 = New System.Windows.Forms.TextBox
Me.TextBox300 = New System.Windows.Forms.TextBox
Me.Panel275 = New System.Windows.Forms.Panel
Me.Label167 = New System.Windows.Forms.Label
Me.Label168 = New System.Windows.Forms.Label
Me.Panel276 = New System.Windows.Forms.Panel
Me.Label169 = New System.Windows.Forms.Label
Me.Label170 = New System.Windows.Forms.Label
Me.Panel277 = New System.Windows.Forms.Panel
Me.Label171 = New System.Windows.Forms.Label
Me.Label172 = New System.Windows.Forms.Label
Me.Panel278 = New System.Windows.Forms.Panel
Me.Label173 = New System.Windows.Forms.Label
Me.Panel279 = New System.Windows.Forms.Panel
Me.Label174 = New System.Windows.Forms.Label
Me.Panel280 = New System.Windows.Forms.Panel
Me.Label175 = New System.Windows.Forms.Label
Me.Panel281 = New System.Windows.Forms.Panel
Me.Label176 = New System.Windows.Forms.Label
Me.Panel282 = New System.Windows.Forms.Panel
Me.Label177 = New System.Windows.Forms.Label
Me.Panel283 = New System.Windows.Forms.Panel
Me.Label178 = New System.Windows.Forms.Label
Me.Panel284 = New System.Windows.Forms.Panel
Me.Label179 = New System.Windows.Forms.Label
Me.Panel285 = New System.Windows.Forms.Panel
Me.Label180 = New System.Windows.Forms.Label
Me.Panel286 = New System.Windows.Forms.Panel
Me.Label181 = New System.Windows.Forms.Label
Me.Panel287 = New System.Windows.Forms.Panel
Me.Label182 = New System.Windows.Forms.Label
Me.Label183 = New System.Windows.Forms.Label
Me.Panel288 = New System.Windows.Forms.Panel
Me.Label184 = New System.Windows.Forms.Label
Me.Label185 = New System.Windows.Forms.Label
Me.Panel289 = New System.Windows.Forms.Panel
Me.Label186 = New System.Windows.Forms.Label
Me.Panel290 = New System.Windows.Forms.Panel
Me.Label187 = New System.Windows.Forms.Label
Me.Panel291 = New System.Windows.Forms.Panel
Me.Label188 = New System.Windows.Forms.Label
Me.Label189 = New System.Windows.Forms.Label
Me.Panel292 = New System.Windows.Forms.Panel
Me.Label190 = New System.Windows.Forms.Label
Me.Label191 = New System.Windows.Forms.Label
Me.Panel323 = New System.Windows.Forms.Panel
Me.Label192 = New System.Windows.Forms.Label
Me.Panel324 = New System.Windows.Forms.Panel
Me.TextBox301 = New System.Windows.Forms.TextBox
Me.TextBox302 = New System.Windows.Forms.TextBox
Me.Panel325 = New System.Windows.Forms.Panel
Me.TextBox303 = New System.Windows.Forms.TextBox
Me.TextBox304 = New System.Windows.Forms.TextBox
Me.Panel326 = New System.Windows.Forms.Panel
Me.TextBox305 = New System.Windows.Forms.TextBox
Me.TextBox306 = New System.Windows.Forms.TextBox
Me.Panel327 = New System.Windows.Forms.Panel
Me.TextBox307 = New System.Windows.Forms.TextBox
Me.TextBox308 = New System.Windows.Forms.TextBox
Me.Panel328 = New System.Windows.Forms.Panel
Me.TextBox309 = New System.Windows.Forms.TextBox
Me.TextBox310 = New System.Windows.Forms.TextBox
Me.Panel329 = New System.Windows.Forms.Panel
Me.TextBox311 = New System.Windows.Forms.TextBox
Me.TextBox312 = New System.Windows.Forms.TextBox
Me.TabPage9 = New System.Windows.Forms.TabPage
Me.Panel330 = New System.Windows.Forms.Panel
Me.TextBox313 = New System.Windows.Forms.TextBox
Me.TextBox314 = New System.Windows.Forms.TextBox
Me.Panel331 = New System.Windows.Forms.Panel
Me.TextBox315 = New System.Windows.Forms.TextBox
Me.TextBox316 = New System.Windows.Forms.TextBox
Me.Panel332 = New System.Windows.Forms.Panel
Me.TextBox317 = New System.Windows.Forms.TextBox
Me.TextBox318 = New System.Windows.Forms.TextBox
Me.Panel333 = New System.Windows.Forms.Panel
Me.TextBox319 = New System.Windows.Forms.TextBox
Me.TextBox320 = New System.Windows.Forms.TextBox
Me.Panel334 = New System.Windows.Forms.Panel
Me.TextBox321 = New System.Windows.Forms.TextBox
Me.TextBox322 = New System.Windows.Forms.TextBox
Me.Panel335 = New System.Windows.Forms.Panel
Me.TextBox323 = New System.Windows.Forms.TextBox
Me.TextBox324 = New System.Windows.Forms.TextBox
Me.Panel336 = New System.Windows.Forms.Panel
Me.TextBox325 = New System.Windows.Forms.TextBox
Me.TextBox326 = New System.Windows.Forms.TextBox
Me.Panel337 = New System.Windows.Forms.Panel
Me.TextBox327 = New System.Windows.Forms.TextBox
Me.TextBox328 = New System.Windows.Forms.TextBox
Me.Panel338 = New System.Windows.Forms.Panel
Me.TextBox329 = New System.Windows.Forms.TextBox
Me.TextBox330 = New System.Windows.Forms.TextBox
Me.Panel339 = New System.Windows.Forms.Panel
Me.TextBox331 = New System.Windows.Forms.TextBox
Me.TextBox332 = New System.Windows.Forms.TextBox
Me.Panel340 = New System.Windows.Forms.Panel
Me.TextBox333 = New System.Windows.Forms.TextBox
Me.TextBox334 = New System.Windows.Forms.TextBox
Me.Panel341 = New System.Windows.Forms.Panel
Me.TextBox335 = New System.Windows.Forms.TextBox
Me.TextBox336 = New System.Windows.Forms.TextBox
Me.Panel342 = New System.Windows.Forms.Panel
Me.TextBox337 = New System.Windows.Forms.TextBox
Me.Panel343 = New System.Windows.Forms.Panel
Me.Label193 = New System.Windows.Forms.Label
Me.Panel344 = New System.Windows.Forms.Panel
Me.TextBox338 = New System.Windows.Forms.TextBox
Me.Panel345 = New System.Windows.Forms.Panel
Me.Label194 = New System.Windows.Forms.Label
Me.Panel346 = New System.Windows.Forms.Panel
Me.Label195 = New System.Windows.Forms.Label
Me.Label196 = New System.Windows.Forms.Label
Me.TextBox339 = New System.Windows.Forms.TextBox
Me.TextBox340 = New System.Windows.Forms.TextBox
Me.Panel347 = New System.Windows.Forms.Panel
Me.Label197 = New System.Windows.Forms.Label
Me.Label198 = New System.Windows.Forms.Label
Me.Panel348 = New System.Windows.Forms.Panel
Me.Label199 = New System.Windows.Forms.Label
Me.Label200 = New System.Windows.Forms.Label
Me.Panel349 = New System.Windows.Forms.Panel
Me.Label201 = New System.Windows.Forms.Label
Me.Label202 = New System.Windows.Forms.Label
Me.Panel350 = New System.Windows.Forms.Panel
Me.Label203 = New System.Windows.Forms.Label
Me.Panel351 = New System.Windows.Forms.Panel
Me.Label204 = New System.Windows.Forms.Label
Me.Panel352 = New System.Windows.Forms.Panel
Me.Label205 = New System.Windows.Forms.Label
Me.Panel353 = New System.Windows.Forms.Panel
Me.Label206 = New System.Windows.Forms.Label
Me.Panel354 = New System.Windows.Forms.Panel
Me.Label207 = New System.Windows.Forms.Label
Me.Panel355 = New System.Windows.Forms.Panel
Me.Label208 = New System.Windows.Forms.Label
Me.Panel356 = New System.Windows.Forms.Panel
Me.Label209 = New System.Windows.Forms.Label
Me.Panel357 = New System.Windows.Forms.Panel
Me.Label210 = New System.Windows.Forms.Label
Me.Panel358 = New System.Windows.Forms.Panel
Me.Label211 = New System.Windows.Forms.Label
Me.Panel359 = New System.Windows.Forms.Panel
Me.Label212 = New System.Windows.Forms.Label
Me.Label213 = New System.Windows.Forms.Label
Me.Panel360 = New System.Windows.Forms.Panel
Me.Label214 = New System.Windows.Forms.Label
Me.Label215 = New System.Windows.Forms.Label
Me.Panel361 = New System.Windows.Forms.Panel
Me.Label216 = New System.Windows.Forms.Label
Me.Panel362 = New System.Windows.Forms.Panel
Me.Label217 = New System.Windows.Forms.Label
Me.Panel363 = New System.Windows.Forms.Panel
Me.Label218 = New System.Windows.Forms.Label
Me.Label219 = New System.Windows.Forms.Label
Me.Panel364 = New System.Windows.Forms.Panel
Me.Label220 = New System.Windows.Forms.Label
Me.Label221 = New System.Windows.Forms.Label
Me.Panel365 = New System.Windows.Forms.Panel
Me.Label222 = New System.Windows.Forms.Label
Me.Panel366 = New System.Windows.Forms.Panel
Me.TextBox341 = New System.Windows.Forms.TextBox
Me.TextBox342 = New System.Windows.Forms.TextBox
Me.Panel367 = New System.Windows.Forms.Panel
Me.TextBox343 = New System.Windows.Forms.TextBox
Me.TextBox344 = New System.Windows.Forms.TextBox
Me.Panel368 = New System.Windows.Forms.Panel
Me.TextBox345 = New System.Windows.Forms.TextBox
Me.TextBox346 = New System.Windows.Forms.TextBox
Me.Panel369 = New System.Windows.Forms.Panel
Me.TextBox347 = New System.Windows.Forms.TextBox
Me.TextBox348 = New System.Windows.Forms.TextBox
Me.Panel370 = New System.Windows.Forms.Panel
Me.TextBox349 = New System.Windows.Forms.TextBox
Me.TextBox350 = New System.Windows.Forms.TextBox
Me.Panel371 = New System.Windows.Forms.Panel
Me.TextBox351 = New System.Windows.Forms.TextBox
Me.TextBox352 = New System.Windows.Forms.TextBox
Me.diagBuses_tab_pressionTroncons_rampe = New System.Windows.Forms.TabControl
Me.TabPage3 = New System.Windows.Forms.TabPage
Me.TabPage4 = New System.Windows.Forms.TabPage
Me.TabPage5 = New System.Windows.Forms.TabPage
Me.TabPage6 = New System.Windows.Forms.TabPage
Me.Panel85 = New System.Windows.Forms.Panel
Me.TextBox81 = New System.Windows.Forms.TextBox
Me.Panel86 = New System.Windows.Forms.Panel
Me.TextBox82 = New System.Windows.Forms.TextBox
Me.Panel87 = New System.Windows.Forms.Panel
Me.TextBox83 = New System.Windows.Forms.TextBox
Me.Panel88 = New System.Windows.Forms.Panel
Me.Label61 = New System.Windows.Forms.Label
Me.Panel89 = New System.Windows.Forms.Panel
Me.Label62 = New System.Windows.Forms.Label
Me.Panel90 = New System.Windows.Forms.Panel
Me.Label63 = New System.Windows.Forms.Label
Me.Panel91 = New System.Windows.Forms.Panel
Me.TextBox84 = New System.Windows.Forms.TextBox
Me.Panel92 = New System.Windows.Forms.Panel
Me.TextBox85 = New System.Windows.Forms.TextBox
Me.Panel126 = New System.Windows.Forms.Panel
Me.Label64 = New System.Windows.Forms.Label
Me.Panel131 = New System.Windows.Forms.Panel
Me.Label65 = New System.Windows.Forms.Label
Me.Label66 = New System.Windows.Forms.Label
Me.TextBox86 = New System.Windows.Forms.TextBox
Me.TextBox87 = New System.Windows.Forms.TextBox
Me.Panel134 = New System.Windows.Forms.Panel
Me.TextBox88 = New System.Windows.Forms.TextBox
Me.Panel135 = New System.Windows.Forms.Panel
Me.Label67 = New System.Windows.Forms.Label
Me.Label68 = New System.Windows.Forms.Label
Me.Panel136 = New System.Windows.Forms.Panel
Me.TextBox89 = New System.Windows.Forms.TextBox
Me.Panel137 = New System.Windows.Forms.Panel
Me.TextBox90 = New System.Windows.Forms.TextBox
Me.Panel138 = New System.Windows.Forms.Panel
Me.Label71 = New System.Windows.Forms.Label
Me.Panel139 = New System.Windows.Forms.Panel
Me.Label72 = New System.Windows.Forms.Label
Me.Panel140 = New System.Windows.Forms.Panel
Me.Label73 = New System.Windows.Forms.Label
Me.Panel141 = New System.Windows.Forms.Panel
Me.TextBox91 = New System.Windows.Forms.TextBox
Me.Panel142 = New System.Windows.Forms.Panel
Me.Label90 = New System.Windows.Forms.Label
Me.Panel143 = New System.Windows.Forms.Panel
Me.Label103 = New System.Windows.Forms.Label
Me.Panel144 = New System.Windows.Forms.Panel
Me.Label104 = New System.Windows.Forms.Label
Me.Panel145 = New System.Windows.Forms.Panel
Me.TextBox92 = New System.Windows.Forms.TextBox
Me.Panel146 = New System.Windows.Forms.Panel
Me.Label105 = New System.Windows.Forms.Label
Me.Panel147 = New System.Windows.Forms.Panel
Me.Label106 = New System.Windows.Forms.Label
Me.Panel148 = New System.Windows.Forms.Panel
Me.Label107 = New System.Windows.Forms.Label
Me.Panel149 = New System.Windows.Forms.Panel
Me.TextBox93 = New System.Windows.Forms.TextBox
Me.Panel150 = New System.Windows.Forms.Panel
Me.TextBox94 = New System.Windows.Forms.TextBox
Me.Panel151 = New System.Windows.Forms.Panel
Me.TextBox95 = New System.Windows.Forms.TextBox
Me.Panel152 = New System.Windows.Forms.Panel
Me.Label108 = New System.Windows.Forms.Label
Me.Panel153 = New System.Windows.Forms.Panel
Me.Label109 = New System.Windows.Forms.Label
Me.Panel154 = New System.Windows.Forms.Panel
Me.TextBox96 = New System.Windows.Forms.TextBox
Me.Panel155 = New System.Windows.Forms.Panel
Me.TextBox97 = New System.Windows.Forms.TextBox
Me.Panel156 = New System.Windows.Forms.Panel
Me.Label110 = New System.Windows.Forms.Label
Me.Panel157 = New System.Windows.Forms.Panel
Me.TextBox98 = New System.Windows.Forms.TextBox
Me.Panel158 = New System.Windows.Forms.Panel
Me.TextBox99 = New System.Windows.Forms.TextBox
Me.Panel159 = New System.Windows.Forms.Panel
Me.TextBox100 = New System.Windows.Forms.TextBox
Me.Panel160 = New System.Windows.Forms.Panel
Me.TextBox101 = New System.Windows.Forms.TextBox
Me.Panel161 = New System.Windows.Forms.Panel
Me.TextBox102 = New System.Windows.Forms.TextBox
Me.Panel162 = New System.Windows.Forms.Panel
Me.TextBox103 = New System.Windows.Forms.TextBox
Me.Panel163 = New System.Windows.Forms.Panel
Me.TextBox104 = New System.Windows.Forms.TextBox
Me.Panel164 = New System.Windows.Forms.Panel
Me.TextBox105 = New System.Windows.Forms.TextBox
Me.Panel165 = New System.Windows.Forms.Panel
Me.TextBox106 = New System.Windows.Forms.TextBox
Me.Panel293 = New System.Windows.Forms.Panel
Me.TextBox107 = New System.Windows.Forms.TextBox
Me.Panel294 = New System.Windows.Forms.Panel
Me.TextBox108 = New System.Windows.Forms.TextBox
Me.Panel295 = New System.Windows.Forms.Panel
Me.TextBox109 = New System.Windows.Forms.TextBox
Me.Panel296 = New System.Windows.Forms.Panel
Me.TextBox110 = New System.Windows.Forms.TextBox
Me.Panel297 = New System.Windows.Forms.Panel
Me.TextBox111 = New System.Windows.Forms.TextBox
Me.Panel298 = New System.Windows.Forms.Panel
Me.TextBox112 = New System.Windows.Forms.TextBox
Me.Panel299 = New System.Windows.Forms.Panel
Me.TextBox113 = New System.Windows.Forms.TextBox
Me.Panel300 = New System.Windows.Forms.Panel
Me.Label111 = New System.Windows.Forms.Label
Me.Panel301 = New System.Windows.Forms.Panel
Me.TextBox114 = New System.Windows.Forms.TextBox
Me.Panel302 = New System.Windows.Forms.Panel
Me.TextBox115 = New System.Windows.Forms.TextBox
Me.Panel303 = New System.Windows.Forms.Panel
Me.TextBox116 = New System.Windows.Forms.TextBox
Me.Panel304 = New System.Windows.Forms.Panel
Me.Label112 = New System.Windows.Forms.Label
Me.Panel305 = New System.Windows.Forms.Panel
Me.TextBox117 = New System.Windows.Forms.TextBox
Me.Panel306 = New System.Windows.Forms.Panel
Me.TextBox118 = New System.Windows.Forms.TextBox
Me.Panel307 = New System.Windows.Forms.Panel
Me.Label113 = New System.Windows.Forms.Label
Me.Panel308 = New System.Windows.Forms.Panel
Me.TextBox119 = New System.Windows.Forms.TextBox
Me.Panel309 = New System.Windows.Forms.Panel
Me.TextBox120 = New System.Windows.Forms.TextBox
Me.Panel310 = New System.Windows.Forms.Panel
Me.TextBox197 = New System.Windows.Forms.TextBox
Me.Panel311 = New System.Windows.Forms.Panel
Me.TextBox198 = New System.Windows.Forms.TextBox
Me.Panel312 = New System.Windows.Forms.Panel
Me.TextBox199 = New System.Windows.Forms.TextBox
Me.Panel313 = New System.Windows.Forms.Panel
Me.Label114 = New System.Windows.Forms.Label
Me.Panel314 = New System.Windows.Forms.Panel
Me.Label115 = New System.Windows.Forms.Label
Me.Panel315 = New System.Windows.Forms.Panel
Me.Label116 = New System.Windows.Forms.Label
Me.Panel316 = New System.Windows.Forms.Panel
Me.TextBox200 = New System.Windows.Forms.TextBox
Me.Panel317 = New System.Windows.Forms.Panel
Me.TextBox201 = New System.Windows.Forms.TextBox
Me.Panel318 = New System.Windows.Forms.Panel
Me.Label117 = New System.Windows.Forms.Label
Me.Panel319 = New System.Windows.Forms.Panel
Me.Label118 = New System.Windows.Forms.Label
Me.Label119 = New System.Windows.Forms.Label
Me.TextBox202 = New System.Windows.Forms.TextBox
Me.TextBox203 = New System.Windows.Forms.TextBox
Me.Panel320 = New System.Windows.Forms.Panel
Me.TextBox204 = New System.Windows.Forms.TextBox
Me.Panel321 = New System.Windows.Forms.Panel
Me.Label120 = New System.Windows.Forms.Label
Me.Label121 = New System.Windows.Forms.Label
Me.Panel322 = New System.Windows.Forms.Panel
Me.TextBox205 = New System.Windows.Forms.TextBox
Me.Panel372 = New System.Windows.Forms.Panel
Me.TextBox206 = New System.Windows.Forms.TextBox
Me.Panel373 = New System.Windows.Forms.Panel
Me.Label223 = New System.Windows.Forms.Label
Me.Panel374 = New System.Windows.Forms.Panel
Me.Label224 = New System.Windows.Forms.Label
Me.Panel375 = New System.Windows.Forms.Panel
Me.Label225 = New System.Windows.Forms.Label
Me.Panel376 = New System.Windows.Forms.Panel
Me.TextBox207 = New System.Windows.Forms.TextBox
Me.Panel377 = New System.Windows.Forms.Panel
Me.Label226 = New System.Windows.Forms.Label
Me.Panel378 = New System.Windows.Forms.Panel
Me.Label227 = New System.Windows.Forms.Label
Me.Panel379 = New System.Windows.Forms.Panel
Me.Label228 = New System.Windows.Forms.Label
Me.Panel380 = New System.Windows.Forms.Panel
Me.TextBox208 = New System.Windows.Forms.TextBox
Me.Panel381 = New System.Windows.Forms.Panel
Me.Label229 = New System.Windows.Forms.Label
Me.Panel382 = New System.Windows.Forms.Panel
Me.Label230 = New System.Windows.Forms.Label
Me.Panel383 = New System.Windows.Forms.Panel
Me.Label231 = New System.Windows.Forms.Label
Me.Panel384 = New System.Windows.Forms.Panel
Me.TextBox209 = New System.Windows.Forms.TextBox
Me.Panel385 = New System.Windows.Forms.Panel
Me.TextBox210 = New System.Windows.Forms.TextBox
Me.Panel386 = New System.Windows.Forms.Panel
Me.TextBox211 = New System.Windows.Forms.TextBox
Me.Panel387 = New System.Windows.Forms.Panel
Me.Label232 = New System.Windows.Forms.Label
Me.Panel388 = New System.Windows.Forms.Panel
Me.Label233 = New System.Windows.Forms.Label
Me.Panel389 = New System.Windows.Forms.Panel
Me.TextBox212 = New System.Windows.Forms.TextBox
Me.Panel390 = New System.Windows.Forms.Panel
Me.TextBox213 = New System.Windows.Forms.TextBox
Me.Panel391 = New System.Windows.Forms.Panel
Me.Label234 = New System.Windows.Forms.Label
Me.Panel392 = New System.Windows.Forms.Panel
Me.TextBox214 = New System.Windows.Forms.TextBox
Me.Panel393 = New System.Windows.Forms.Panel
Me.TextBox215 = New System.Windows.Forms.TextBox
Me.Panel394 = New System.Windows.Forms.Panel
Me.TextBox216 = New System.Windows.Forms.TextBox
Me.Panel395 = New System.Windows.Forms.Panel
Me.TextBox217 = New System.Windows.Forms.TextBox
Me.Panel396 = New System.Windows.Forms.Panel
Me.TextBox218 = New System.Windows.Forms.TextBox
Me.Panel397 = New System.Windows.Forms.Panel
Me.TextBox219 = New System.Windows.Forms.TextBox
Me.Panel398 = New System.Windows.Forms.Panel
Me.TextBox220 = New System.Windows.Forms.TextBox
Me.Panel399 = New System.Windows.Forms.Panel
Me.TextBox221 = New System.Windows.Forms.TextBox
Me.Panel400 = New System.Windows.Forms.Panel
Me.TextBox222 = New System.Windows.Forms.TextBox
Me.Panel401 = New System.Windows.Forms.Panel
Me.TextBox223 = New System.Windows.Forms.TextBox
Me.Panel402 = New System.Windows.Forms.Panel
Me.TextBox224 = New System.Windows.Forms.TextBox
Me.Panel403 = New System.Windows.Forms.Panel
Me.TextBox225 = New System.Windows.Forms.TextBox
Me.Panel404 = New System.Windows.Forms.Panel
Me.TextBox226 = New System.Windows.Forms.TextBox
Me.Panel405 = New System.Windows.Forms.Panel
Me.TextBox227 = New System.Windows.Forms.TextBox
Me.Panel406 = New System.Windows.Forms.Panel
Me.TextBox228 = New System.Windows.Forms.TextBox
Me.Panel407 = New System.Windows.Forms.Panel
Me.TextBox229 = New System.Windows.Forms.TextBox
Me.Panel408 = New System.Windows.Forms.Panel
Me.Label235 = New System.Windows.Forms.Label
Me.Panel409 = New System.Windows.Forms.Panel
Me.TextBox230 = New System.Windows.Forms.TextBox
Me.Panel410 = New System.Windows.Forms.Panel
Me.TextBox231 = New System.Windows.Forms.TextBox
Me.Panel411 = New System.Windows.Forms.Panel
Me.TextBox232 = New System.Windows.Forms.TextBox
Me.Panel412 = New System.Windows.Forms.Panel
Me.Label236 = New System.Windows.Forms.Label
Me.Panel413 = New System.Windows.Forms.Panel
Me.TextBox353 = New System.Windows.Forms.TextBox
Me.Panel498 = New System.Windows.Forms.Panel
Me.TextBox354 = New System.Windows.Forms.TextBox
Me.Panel499 = New System.Windows.Forms.Panel
Me.Label237 = New System.Windows.Forms.Label
Me.Panel500 = New System.Windows.Forms.Panel
Me.TextBox355 = New System.Windows.Forms.TextBox
Me.Panel501 = New System.Windows.Forms.Panel
Me.TextBox356 = New System.Windows.Forms.TextBox
Me.Panel414 = New System.Windows.Forms.Panel
Me.TextBox357 = New System.Windows.Forms.TextBox
Me.Panel415 = New System.Windows.Forms.Panel
Me.TextBox358 = New System.Windows.Forms.TextBox
Me.Panel416 = New System.Windows.Forms.Panel
Me.TextBox359 = New System.Windows.Forms.TextBox
Me.Panel417 = New System.Windows.Forms.Panel
Me.Label238 = New System.Windows.Forms.Label
Me.Panel418 = New System.Windows.Forms.Panel
Me.Label239 = New System.Windows.Forms.Label
Me.Panel419 = New System.Windows.Forms.Panel
Me.Label240 = New System.Windows.Forms.Label
Me.Panel420 = New System.Windows.Forms.Panel
Me.TextBox360 = New System.Windows.Forms.TextBox
Me.Panel421 = New System.Windows.Forms.Panel
Me.TextBox361 = New System.Windows.Forms.TextBox
Me.Panel422 = New System.Windows.Forms.Panel
Me.Label241 = New System.Windows.Forms.Label
Me.Panel423 = New System.Windows.Forms.Panel
Me.Label242 = New System.Windows.Forms.Label
Me.Label243 = New System.Windows.Forms.Label
Me.TextBox362 = New System.Windows.Forms.TextBox
Me.TextBox363 = New System.Windows.Forms.TextBox
Me.Panel424 = New System.Windows.Forms.Panel
Me.TextBox364 = New System.Windows.Forms.TextBox
Me.Panel425 = New System.Windows.Forms.Panel
Me.Label244 = New System.Windows.Forms.Label
Me.Label245 = New System.Windows.Forms.Label
Me.Panel426 = New System.Windows.Forms.Panel
Me.TextBox365 = New System.Windows.Forms.TextBox
Me.Panel427 = New System.Windows.Forms.Panel
Me.TextBox366 = New System.Windows.Forms.TextBox
Me.Panel428 = New System.Windows.Forms.Panel
Me.Label246 = New System.Windows.Forms.Label
Me.Panel429 = New System.Windows.Forms.Panel
Me.Label247 = New System.Windows.Forms.Label
Me.Panel430 = New System.Windows.Forms.Panel
Me.Label248 = New System.Windows.Forms.Label
Me.Panel431 = New System.Windows.Forms.Panel
Me.TextBox367 = New System.Windows.Forms.TextBox
Me.Panel432 = New System.Windows.Forms.Panel
Me.Label249 = New System.Windows.Forms.Label
Me.Panel433 = New System.Windows.Forms.Panel
Me.Label250 = New System.Windows.Forms.Label
Me.Panel434 = New System.Windows.Forms.Panel
Me.Label251 = New System.Windows.Forms.Label
Me.Panel435 = New System.Windows.Forms.Panel
Me.TextBox368 = New System.Windows.Forms.TextBox
Me.Panel436 = New System.Windows.Forms.Panel
Me.Label252 = New System.Windows.Forms.Label
Me.Panel437 = New System.Windows.Forms.Panel
Me.Label253 = New System.Windows.Forms.Label
Me.Panel438 = New System.Windows.Forms.Panel
Me.Label254 = New System.Windows.Forms.Label
Me.Panel439 = New System.Windows.Forms.Panel
Me.TextBox369 = New System.Windows.Forms.TextBox
Me.Panel440 = New System.Windows.Forms.Panel
Me.TextBox370 = New System.Windows.Forms.TextBox
Me.Panel441 = New System.Windows.Forms.Panel
Me.TextBox371 = New System.Windows.Forms.TextBox
Me.Panel442 = New System.Windows.Forms.Panel
Me.Label255 = New System.Windows.Forms.Label
Me.Panel443 = New System.Windows.Forms.Panel
Me.Label256 = New System.Windows.Forms.Label
Me.Panel444 = New System.Windows.Forms.Panel
Me.TextBox372 = New System.Windows.Forms.TextBox
Me.Panel445 = New System.Windows.Forms.Panel
Me.TextBox373 = New System.Windows.Forms.TextBox
Me.Panel446 = New System.Windows.Forms.Panel
Me.Label257 = New System.Windows.Forms.Label
Me.Panel447 = New System.Windows.Forms.Panel
Me.TextBox374 = New System.Windows.Forms.TextBox
Me.Panel448 = New System.Windows.Forms.Panel
Me.TextBox375 = New System.Windows.Forms.TextBox
Me.Panel449 = New System.Windows.Forms.Panel
Me.TextBox376 = New System.Windows.Forms.TextBox
Me.Panel450 = New System.Windows.Forms.Panel
Me.TextBox377 = New System.Windows.Forms.TextBox
Me.Panel451 = New System.Windows.Forms.Panel
Me.TextBox378 = New System.Windows.Forms.TextBox
Me.Panel452 = New System.Windows.Forms.Panel
Me.TextBox379 = New System.Windows.Forms.TextBox
Me.Panel453 = New System.Windows.Forms.Panel
Me.TextBox380 = New System.Windows.Forms.TextBox
Me.Panel454 = New System.Windows.Forms.Panel
Me.TextBox381 = New System.Windows.Forms.TextBox
Me.Panel455 = New System.Windows.Forms.Panel
Me.TextBox382 = New System.Windows.Forms.TextBox
Me.Panel502 = New System.Windows.Forms.Panel
Me.TextBox383 = New System.Windows.Forms.TextBox
Me.Panel503 = New System.Windows.Forms.Panel
Me.TextBox384 = New System.Windows.Forms.TextBox
Me.Panel504 = New System.Windows.Forms.Panel
Me.TextBox385 = New System.Windows.Forms.TextBox
Me.Panel505 = New System.Windows.Forms.Panel
Me.TextBox386 = New System.Windows.Forms.TextBox
Me.Panel506 = New System.Windows.Forms.Panel
Me.TextBox387 = New System.Windows.Forms.TextBox
Me.Panel507 = New System.Windows.Forms.Panel
Me.TextBox388 = New System.Windows.Forms.TextBox
Me.Panel508 = New System.Windows.Forms.Panel
Me.TextBox389 = New System.Windows.Forms.TextBox
Me.Panel509 = New System.Windows.Forms.Panel
Me.Label258 = New System.Windows.Forms.Label
Me.Panel510 = New System.Windows.Forms.Panel
Me.TextBox390 = New System.Windows.Forms.TextBox
Me.Panel511 = New System.Windows.Forms.Panel
Me.TextBox391 = New System.Windows.Forms.TextBox
Me.Panel512 = New System.Windows.Forms.Panel
Me.TextBox392 = New System.Windows.Forms.TextBox
Me.Panel513 = New System.Windows.Forms.Panel
Me.Label259 = New System.Windows.Forms.Label
Me.Panel514 = New System.Windows.Forms.Panel
Me.TextBox393 = New System.Windows.Forms.TextBox
Me.Panel515 = New System.Windows.Forms.Panel
Me.TextBox394 = New System.Windows.Forms.TextBox
Me.Panel516 = New System.Windows.Forms.Panel
Me.Label260 = New System.Windows.Forms.Label
Me.Panel517 = New System.Windows.Forms.Panel
Me.TextBox395 = New System.Windows.Forms.TextBox
Me.Panel518 = New System.Windows.Forms.Panel
Me.TextBox396 = New System.Windows.Forms.TextBox
Me.Panel456 = New System.Windows.Forms.Panel
Me.TextBox397 = New System.Windows.Forms.TextBox
Me.Panel457 = New System.Windows.Forms.Panel
Me.TextBox398 = New System.Windows.Forms.TextBox
Me.Panel458 = New System.Windows.Forms.Panel
Me.TextBox399 = New System.Windows.Forms.TextBox
Me.Panel459 = New System.Windows.Forms.Panel
Me.Label261 = New System.Windows.Forms.Label
Me.Panel460 = New System.Windows.Forms.Panel
Me.Label262 = New System.Windows.Forms.Label
Me.Panel461 = New System.Windows.Forms.Panel
Me.Label263 = New System.Windows.Forms.Label
Me.Panel462 = New System.Windows.Forms.Panel
Me.TextBox400 = New System.Windows.Forms.TextBox
Me.Panel463 = New System.Windows.Forms.Panel
Me.TextBox401 = New System.Windows.Forms.TextBox
Me.Panel464 = New System.Windows.Forms.Panel
Me.Label264 = New System.Windows.Forms.Label
Me.Panel465 = New System.Windows.Forms.Panel
Me.Label265 = New System.Windows.Forms.Label
Me.Label266 = New System.Windows.Forms.Label
Me.TextBox402 = New System.Windows.Forms.TextBox
Me.TextBox403 = New System.Windows.Forms.TextBox
Me.Panel466 = New System.Windows.Forms.Panel
Me.TextBox404 = New System.Windows.Forms.TextBox
Me.Panel467 = New System.Windows.Forms.Panel
Me.Label267 = New System.Windows.Forms.Label
Me.Label268 = New System.Windows.Forms.Label
Me.Panel468 = New System.Windows.Forms.Panel
Me.TextBox405 = New System.Windows.Forms.TextBox
Me.Panel469 = New System.Windows.Forms.Panel
Me.TextBox406 = New System.Windows.Forms.TextBox
Me.Panel470 = New System.Windows.Forms.Panel
Me.Label269 = New System.Windows.Forms.Label
Me.Panel471 = New System.Windows.Forms.Panel
Me.Label270 = New System.Windows.Forms.Label
Me.Panel472 = New System.Windows.Forms.Panel
Me.Label271 = New System.Windows.Forms.Label
Me.Panel473 = New System.Windows.Forms.Panel
Me.TextBox407 = New System.Windows.Forms.TextBox
Me.Panel474 = New System.Windows.Forms.Panel
Me.Label272 = New System.Windows.Forms.Label
Me.Panel475 = New System.Windows.Forms.Panel
Me.Label273 = New System.Windows.Forms.Label
Me.Panel476 = New System.Windows.Forms.Panel
Me.Label274 = New System.Windows.Forms.Label
Me.Panel477 = New System.Windows.Forms.Panel
Me.TextBox408 = New System.Windows.Forms.TextBox
Me.Panel478 = New System.Windows.Forms.Panel
Me.Label275 = New System.Windows.Forms.Label
Me.Panel479 = New System.Windows.Forms.Panel
Me.Label276 = New System.Windows.Forms.Label
Me.Panel480 = New System.Windows.Forms.Panel
Me.Label277 = New System.Windows.Forms.Label
Me.Panel481 = New System.Windows.Forms.Panel
Me.TextBox409 = New System.Windows.Forms.TextBox
Me.Panel482 = New System.Windows.Forms.Panel
Me.TextBox410 = New System.Windows.Forms.TextBox
Me.Panel483 = New System.Windows.Forms.Panel
Me.TextBox411 = New System.Windows.Forms.TextBox
Me.Panel484 = New System.Windows.Forms.Panel
Me.Label278 = New System.Windows.Forms.Label
Me.Panel485 = New System.Windows.Forms.Panel
Me.Label279 = New System.Windows.Forms.Label
Me.Panel486 = New System.Windows.Forms.Panel
Me.TextBox412 = New System.Windows.Forms.TextBox
Me.Panel487 = New System.Windows.Forms.Panel
Me.TextBox413 = New System.Windows.Forms.TextBox
Me.Panel488 = New System.Windows.Forms.Panel
Me.Label280 = New System.Windows.Forms.Label
Me.Panel489 = New System.Windows.Forms.Panel
Me.TextBox414 = New System.Windows.Forms.TextBox
Me.Panel490 = New System.Windows.Forms.Panel
Me.TextBox415 = New System.Windows.Forms.TextBox
Me.Panel491 = New System.Windows.Forms.Panel
Me.TextBox416 = New System.Windows.Forms.TextBox
Me.Panel492 = New System.Windows.Forms.Panel
Me.TextBox417 = New System.Windows.Forms.TextBox
Me.Panel493 = New System.Windows.Forms.Panel
Me.TextBox418 = New System.Windows.Forms.TextBox
Me.Panel494 = New System.Windows.Forms.Panel
Me.TextBox419 = New System.Windows.Forms.TextBox
Me.Panel495 = New System.Windows.Forms.Panel
Me.TextBox420 = New System.Windows.Forms.TextBox
Me.Panel496 = New System.Windows.Forms.Panel
Me.TextBox421 = New System.Windows.Forms.TextBox
Me.Panel497 = New System.Windows.Forms.Panel
Me.TextBox422 = New System.Windows.Forms.TextBox
Me.Panel519 = New System.Windows.Forms.Panel
Me.TextBox423 = New System.Windows.Forms.TextBox
Me.Panel520 = New System.Windows.Forms.Panel
Me.TextBox424 = New System.Windows.Forms.TextBox
Me.Panel521 = New System.Windows.Forms.Panel
Me.TextBox425 = New System.Windows.Forms.TextBox
Me.Panel522 = New System.Windows.Forms.Panel
Me.TextBox426 = New System.Windows.Forms.TextBox
Me.Panel523 = New System.Windows.Forms.Panel
Me.TextBox427 = New System.Windows.Forms.TextBox
Me.Panel524 = New System.Windows.Forms.Panel
Me.TextBox428 = New System.Windows.Forms.TextBox
Me.Panel525 = New System.Windows.Forms.Panel
Me.TextBox429 = New System.Windows.Forms.TextBox
Me.Panel526 = New System.Windows.Forms.Panel
Me.Label281 = New System.Windows.Forms.Label
Me.Panel527 = New System.Windows.Forms.Panel
Me.TextBox430 = New System.Windows.Forms.TextBox
Me.Panel528 = New System.Windows.Forms.Panel
Me.TextBox431 = New System.Windows.Forms.TextBox
Me.Panel529 = New System.Windows.Forms.Panel
Me.TextBox432 = New System.Windows.Forms.TextBox
Me.Panel530 = New System.Windows.Forms.Panel
Me.Label282 = New System.Windows.Forms.Label
Me.Panel531 = New System.Windows.Forms.Panel
Me.TextBox433 = New System.Windows.Forms.TextBox
Me.Panel532 = New System.Windows.Forms.Panel
Me.TextBox434 = New System.Windows.Forms.TextBox
Me.Panel533 = New System.Windows.Forms.Panel
Me.Label283 = New System.Windows.Forms.Label
Me.Panel534 = New System.Windows.Forms.Panel
Me.TextBox435 = New System.Windows.Forms.TextBox
Me.Panel535 = New System.Windows.Forms.Panel
Me.TextBox436 = New System.Windows.Forms.TextBox
Me.Panel14.SuspendLayout
Me.Panel21.SuspendLayout
Me.Panel22.SuspendLayout
Me.Panel23.SuspendLayout
Me.Panel24.SuspendLayout
Me.Panel25.SuspendLayout
Me.Panel26.SuspendLayout
Me.Panel27.SuspendLayout
Me.Panel28.SuspendLayout
Me.Panel29.SuspendLayout
Me.Panel30.SuspendLayout
Me.Panel31.SuspendLayout
Me.Panel32.SuspendLayout
Me.Panel33.SuspendLayout
Me.Panel34.SuspendLayout
Me.Panel35.SuspendLayout
Me.Panel36.SuspendLayout
Me.Panel37.SuspendLayout
Me.Panel38.SuspendLayout
Me.Panel39.SuspendLayout
Me.Panel40.SuspendLayout
Me.Panel41.SuspendLayout
Me.Panel42.SuspendLayout
Me.Panel43.SuspendLayout
Me.Panel44.SuspendLayout
Me.Panel45.SuspendLayout
Me.Panel46.SuspendLayout
Me.Panel47.SuspendLayout
Me.Panel48.SuspendLayout
Me.Panel49.SuspendLayout
Me.Panel52.SuspendLayout
Me.Panel53.SuspendLayout
Me.Panel54.SuspendLayout
Me.Panel55.SuspendLayout
Me.Panel56.SuspendLayout
Me.Panel57.SuspendLayout
Me.Panel58.SuspendLayout
Me.Panel59.SuspendLayout
Me.Panel63.SuspendLayout
Me.Panel64.SuspendLayout
Me.Panel83.SuspendLayout
Me.Panel84.SuspendLayout
Me.Panel1.SuspendLayout
Me.Panel2.SuspendLayout
Me.Panel3.SuspendLayout
Me.Panel4.SuspendLayout
Me.Panel5.SuspendLayout
Me.Panel6.SuspendLayout
Me.Panel7.SuspendLayout
Me.Panel8.SuspendLayout
Me.Panel9.SuspendLayout
Me.Panel10.SuspendLayout
Me.Panel11.SuspendLayout
Me.Panel13.SuspendLayout
Me.Panel16.SuspendLayout
Me.Panel18.SuspendLayout
Me.Panel20.SuspendLayout
Me.Panel50.SuspendLayout
Me.Panel51.SuspendLayout
Me.Panel60.SuspendLayout
Me.Panel61.SuspendLayout
Me.Panel62.SuspendLayout
Me.Panel65.SuspendLayout
Me.Panel66.SuspendLayout
Me.Panel67.SuspendLayout
Me.Panel68.SuspendLayout
Me.Panel70.SuspendLayout
Me.Panel71.SuspendLayout
Me.Panel73.SuspendLayout
Me.Panel75.SuspendLayout
Me.Panel76.SuspendLayout
Me.Panel78.SuspendLayout
Me.Panel79.SuspendLayout
Me.Panel93.SuspendLayout
Me.Panel94.SuspendLayout
Me.Panel95.SuspendLayout
Me.Panel96.SuspendLayout
Me.Panel97.SuspendLayout
Me.Panel98.SuspendLayout
Me.Panel99.SuspendLayout
Me.Panel100.SuspendLayout
Me.Panel101.SuspendLayout
Me.Panel102.SuspendLayout
Me.Panel103.SuspendLayout
Me.Panel104.SuspendLayout
Me.Panel105.SuspendLayout
Me.Panel106.SuspendLayout
Me.Panel107.SuspendLayout
Me.Panel108.SuspendLayout
Me.Panel110.SuspendLayout
Me.Panel111.SuspendLayout
Me.Panel112.SuspendLayout
Me.Panel113.SuspendLayout
Me.Panel114.SuspendLayout
Me.Panel115.SuspendLayout
Me.Panel116.SuspendLayout
Me.Panel117.SuspendLayout
Me.Panel118.SuspendLayout
Me.Panel119.SuspendLayout
Me.Panel120.SuspendLayout
Me.Panel122.SuspendLayout
Me.diagBuses_tab_pressionTroncons.SuspendLayout
Me.TabPage1.SuspendLayout
Me.Panel12.SuspendLayout
Me.Panel15.SuspendLayout
Me.Panel17.SuspendLayout
Me.Panel19.SuspendLayout
Me.Panel69.SuspendLayout
Me.Panel72.SuspendLayout
Me.Panel74.SuspendLayout
Me.Panel77.SuspendLayout
Me.Panel80.SuspendLayout
Me.Panel81.SuspendLayout
Me.Panel82.SuspendLayout
Me.Panel109.SuspendLayout
Me.Panel121.SuspendLayout
Me.Panel123.SuspendLayout
Me.Panel124.SuspendLayout
Me.Panel125.SuspendLayout
Me.Panel127.SuspendLayout
Me.Panel128.SuspendLayout
Me.Panel129.SuspendLayout
Me.Panel130.SuspendLayout
Me.Panel132.SuspendLayout
Me.Panel133.SuspendLayout
Me.Panel166.SuspendLayout
Me.Panel167.SuspendLayout
Me.Panel168.SuspendLayout
Me.Panel169.SuspendLayout
Me.Panel170.SuspendLayout
Me.Panel171.SuspendLayout
Me.Panel172.SuspendLayout
Me.Panel173.SuspendLayout
Me.Panel174.SuspendLayout
Me.Panel175.SuspendLayout
Me.Panel176.SuspendLayout
Me.Panel177.SuspendLayout
Me.Panel178.SuspendLayout
Me.Panel179.SuspendLayout
Me.Panel180.SuspendLayout
Me.Panel181.SuspendLayout
Me.Panel182.SuspendLayout
Me.Panel183.SuspendLayout
Me.Panel184.SuspendLayout
Me.Panel185.SuspendLayout
Me.Panel186.SuspendLayout
Me.Panel187.SuspendLayout
Me.Panel188.SuspendLayout
Me.Panel189.SuspendLayout
Me.Panel190.SuspendLayout
Me.Panel191.SuspendLayout
Me.Panel192.SuspendLayout
Me.Panel193.SuspendLayout
Me.Panel194.SuspendLayout
Me.Panel195.SuspendLayout
Me.Panel196.SuspendLayout
Me.Panel197.SuspendLayout
Me.Panel198.SuspendLayout
Me.Panel199.SuspendLayout
Me.Panel200.SuspendLayout
Me.Panel201.SuspendLayout
Me.Panel202.SuspendLayout
Me.Panel203.SuspendLayout
Me.Panel204.SuspendLayout
Me.Panel205.SuspendLayout
Me.Panel206.SuspendLayout
Me.Panel207.SuspendLayout
Me.Panel208.SuspendLayout
Me.Panel209.SuspendLayout
Me.Panel210.SuspendLayout
Me.Panel211.SuspendLayout
Me.Panel212.SuspendLayout
Me.Panel213.SuspendLayout
Me.Panel214.SuspendLayout
Me.Panel215.SuspendLayout
Me.TabPage2.SuspendLayout
Me.Panel216.SuspendLayout
Me.Panel217.SuspendLayout
Me.Panel218.SuspendLayout
Me.Panel219.SuspendLayout
Me.Panel220.SuspendLayout
Me.Panel221.SuspendLayout
Me.Panel222.SuspendLayout
Me.Panel223.SuspendLayout
Me.Panel224.SuspendLayout
Me.Panel225.SuspendLayout
Me.Panel226.SuspendLayout
Me.Panel227.SuspendLayout
Me.Panel228.SuspendLayout
Me.Panel229.SuspendLayout
Me.Panel230.SuspendLayout
Me.Panel231.SuspendLayout
Me.Panel232.SuspendLayout
Me.Panel233.SuspendLayout
Me.Panel234.SuspendLayout
Me.Panel235.SuspendLayout
Me.Panel236.SuspendLayout
Me.Panel237.SuspendLayout
Me.Panel238.SuspendLayout
Me.Panel239.SuspendLayout
Me.Panel240.SuspendLayout
Me.Panel241.SuspendLayout
Me.Panel242.SuspendLayout
Me.Panel243.SuspendLayout
Me.Panel244.SuspendLayout
Me.Panel245.SuspendLayout
Me.Panel246.SuspendLayout
Me.Panel247.SuspendLayout
Me.Panel248.SuspendLayout
Me.Panel249.SuspendLayout
Me.Panel250.SuspendLayout
Me.Panel251.SuspendLayout
Me.Panel252.SuspendLayout
Me.Panel253.SuspendLayout
Me.Panel254.SuspendLayout
Me.Panel255.SuspendLayout
Me.Panel256.SuspendLayout
Me.Panel257.SuspendLayout
Me.TabPage8.SuspendLayout
Me.Panel258.SuspendLayout
Me.Panel259.SuspendLayout
Me.Panel260.SuspendLayout
Me.Panel261.SuspendLayout
Me.Panel262.SuspendLayout
Me.Panel263.SuspendLayout
Me.Panel264.SuspendLayout
Me.Panel265.SuspendLayout
Me.Panel266.SuspendLayout
Me.Panel267.SuspendLayout
Me.Panel268.SuspendLayout
Me.Panel269.SuspendLayout
Me.Panel270.SuspendLayout
Me.Panel271.SuspendLayout
Me.Panel272.SuspendLayout
Me.Panel273.SuspendLayout
Me.Panel274.SuspendLayout
Me.Panel275.SuspendLayout
Me.Panel276.SuspendLayout
Me.Panel277.SuspendLayout
Me.Panel278.SuspendLayout
Me.Panel279.SuspendLayout
Me.Panel280.SuspendLayout
Me.Panel281.SuspendLayout
Me.Panel282.SuspendLayout
Me.Panel283.SuspendLayout
Me.Panel284.SuspendLayout
Me.Panel285.SuspendLayout
Me.Panel286.SuspendLayout
Me.Panel287.SuspendLayout
Me.Panel288.SuspendLayout
Me.Panel289.SuspendLayout
Me.Panel290.SuspendLayout
Me.Panel291.SuspendLayout
Me.Panel292.SuspendLayout
Me.Panel323.SuspendLayout
Me.Panel324.SuspendLayout
Me.Panel325.SuspendLayout
Me.Panel326.SuspendLayout
Me.Panel327.SuspendLayout
Me.Panel328.SuspendLayout
Me.Panel329.SuspendLayout
Me.TabPage9.SuspendLayout
Me.Panel330.SuspendLayout
Me.Panel331.SuspendLayout
Me.Panel332.SuspendLayout
Me.Panel333.SuspendLayout
Me.Panel334.SuspendLayout
Me.Panel335.SuspendLayout
Me.Panel336.SuspendLayout
Me.Panel337.SuspendLayout
Me.Panel338.SuspendLayout
Me.Panel339.SuspendLayout
Me.Panel340.SuspendLayout
Me.Panel341.SuspendLayout
Me.Panel342.SuspendLayout
Me.Panel343.SuspendLayout
Me.Panel344.SuspendLayout
Me.Panel345.SuspendLayout
Me.Panel346.SuspendLayout
Me.Panel347.SuspendLayout
Me.Panel348.SuspendLayout
Me.Panel349.SuspendLayout
Me.Panel350.SuspendLayout
Me.Panel351.SuspendLayout
Me.Panel352.SuspendLayout
Me.Panel353.SuspendLayout
Me.Panel354.SuspendLayout
Me.Panel355.SuspendLayout
Me.Panel356.SuspendLayout
Me.Panel357.SuspendLayout
Me.Panel358.SuspendLayout
Me.Panel359.SuspendLayout
Me.Panel360.SuspendLayout
Me.Panel361.SuspendLayout
Me.Panel362.SuspendLayout
Me.Panel363.SuspendLayout
Me.Panel364.SuspendLayout
Me.Panel365.SuspendLayout
Me.Panel366.SuspendLayout
Me.Panel367.SuspendLayout
Me.Panel368.SuspendLayout
Me.Panel369.SuspendLayout
Me.Panel370.SuspendLayout
Me.Panel371.SuspendLayout
Me.diagBuses_tab_pressionTroncons_rampe.SuspendLayout
Me.TabPage3.SuspendLayout
Me.TabPage4.SuspendLayout
Me.TabPage5.SuspendLayout
Me.TabPage6.SuspendLayout
Me.Panel85.SuspendLayout
Me.Panel86.SuspendLayout
Me.Panel87.SuspendLayout
Me.Panel88.SuspendLayout
Me.Panel89.SuspendLayout
Me.Panel90.SuspendLayout
Me.Panel91.SuspendLayout
Me.Panel92.SuspendLayout
Me.Panel126.SuspendLayout
Me.Panel131.SuspendLayout
Me.Panel134.SuspendLayout
Me.Panel135.SuspendLayout
Me.Panel136.SuspendLayout
Me.Panel137.SuspendLayout
Me.Panel138.SuspendLayout
Me.Panel139.SuspendLayout
Me.Panel140.SuspendLayout
Me.Panel141.SuspendLayout
Me.Panel142.SuspendLayout
Me.Panel143.SuspendLayout
Me.Panel144.SuspendLayout
Me.Panel145.SuspendLayout
Me.Panel146.SuspendLayout
Me.Panel147.SuspendLayout
Me.Panel148.SuspendLayout
Me.Panel149.SuspendLayout
Me.Panel150.SuspendLayout
Me.Panel151.SuspendLayout
Me.Panel152.SuspendLayout
Me.Panel153.SuspendLayout
Me.Panel154.SuspendLayout
Me.Panel155.SuspendLayout
Me.Panel156.SuspendLayout
Me.Panel157.SuspendLayout
Me.Panel158.SuspendLayout
Me.Panel159.SuspendLayout
Me.Panel160.SuspendLayout
Me.Panel161.SuspendLayout
Me.Panel162.SuspendLayout
Me.Panel163.SuspendLayout
Me.Panel164.SuspendLayout
Me.Panel165.SuspendLayout
Me.Panel293.SuspendLayout
Me.Panel294.SuspendLayout
Me.Panel295.SuspendLayout
Me.Panel296.SuspendLayout
Me.Panel297.SuspendLayout
Me.Panel298.SuspendLayout
Me.Panel299.SuspendLayout
Me.Panel300.SuspendLayout
Me.Panel301.SuspendLayout
Me.Panel302.SuspendLayout
Me.Panel303.SuspendLayout
Me.Panel304.SuspendLayout
Me.Panel305.SuspendLayout
Me.Panel306.SuspendLayout
Me.Panel307.SuspendLayout
Me.Panel308.SuspendLayout
Me.Panel309.SuspendLayout
Me.Panel310.SuspendLayout
Me.Panel311.SuspendLayout
Me.Panel312.SuspendLayout
Me.Panel313.SuspendLayout
Me.Panel314.SuspendLayout
Me.Panel315.SuspendLayout
Me.Panel316.SuspendLayout
Me.Panel317.SuspendLayout
Me.Panel318.SuspendLayout
Me.Panel319.SuspendLayout
Me.Panel320.SuspendLayout
Me.Panel321.SuspendLayout
Me.Panel322.SuspendLayout
Me.Panel372.SuspendLayout
Me.Panel373.SuspendLayout
Me.Panel374.SuspendLayout
Me.Panel375.SuspendLayout
Me.Panel376.SuspendLayout
Me.Panel377.SuspendLayout
Me.Panel378.SuspendLayout
Me.Panel379.SuspendLayout
Me.Panel380.SuspendLayout
Me.Panel381.SuspendLayout
Me.Panel382.SuspendLayout
Me.Panel383.SuspendLayout
Me.Panel384.SuspendLayout
Me.Panel385.SuspendLayout
Me.Panel386.SuspendLayout
Me.Panel387.SuspendLayout
Me.Panel388.SuspendLayout
Me.Panel389.SuspendLayout
Me.Panel390.SuspendLayout
Me.Panel391.SuspendLayout
Me.Panel392.SuspendLayout
Me.Panel393.SuspendLayout
Me.Panel394.SuspendLayout
Me.Panel395.SuspendLayout
Me.Panel396.SuspendLayout
Me.Panel397.SuspendLayout
Me.Panel398.SuspendLayout
Me.Panel399.SuspendLayout
Me.Panel400.SuspendLayout
Me.Panel401.SuspendLayout
Me.Panel402.SuspendLayout
Me.Panel403.SuspendLayout
Me.Panel404.SuspendLayout
Me.Panel405.SuspendLayout
Me.Panel406.SuspendLayout
Me.Panel407.SuspendLayout
Me.Panel408.SuspendLayout
Me.Panel409.SuspendLayout
Me.Panel410.SuspendLayout
Me.Panel411.SuspendLayout
Me.Panel412.SuspendLayout
Me.Panel413.SuspendLayout
Me.Panel498.SuspendLayout
Me.Panel499.SuspendLayout
Me.Panel500.SuspendLayout
Me.Panel501.SuspendLayout
Me.Panel414.SuspendLayout
Me.Panel415.SuspendLayout
Me.Panel416.SuspendLayout
Me.Panel417.SuspendLayout
Me.Panel418.SuspendLayout
Me.Panel419.SuspendLayout
Me.Panel420.SuspendLayout
Me.Panel421.SuspendLayout
Me.Panel422.SuspendLayout
Me.Panel423.SuspendLayout
Me.Panel424.SuspendLayout
Me.Panel425.SuspendLayout
Me.Panel426.SuspendLayout
Me.Panel427.SuspendLayout
Me.Panel428.SuspendLayout
Me.Panel429.SuspendLayout
Me.Panel430.SuspendLayout
Me.Panel431.SuspendLayout
Me.Panel432.SuspendLayout
Me.Panel433.SuspendLayout
Me.Panel434.SuspendLayout
Me.Panel435.SuspendLayout
Me.Panel436.SuspendLayout
Me.Panel437.SuspendLayout
Me.Panel438.SuspendLayout
Me.Panel439.SuspendLayout
Me.Panel440.SuspendLayout
Me.Panel441.SuspendLayout
Me.Panel442.SuspendLayout
Me.Panel443.SuspendLayout
Me.Panel444.SuspendLayout
Me.Panel445.SuspendLayout
Me.Panel446.SuspendLayout
Me.Panel447.SuspendLayout
Me.Panel448.SuspendLayout
Me.Panel449.SuspendLayout
Me.Panel450.SuspendLayout
Me.Panel451.SuspendLayout
Me.Panel452.SuspendLayout
Me.Panel453.SuspendLayout
Me.Panel454.SuspendLayout
Me.Panel455.SuspendLayout
Me.Panel502.SuspendLayout
Me.Panel503.SuspendLayout
Me.Panel504.SuspendLayout
Me.Panel505.SuspendLayout
Me.Panel506.SuspendLayout
Me.Panel507.SuspendLayout
Me.Panel508.SuspendLayout
Me.Panel509.SuspendLayout
Me.Panel510.SuspendLayout
Me.Panel511.SuspendLayout
Me.Panel512.SuspendLayout
Me.Panel513.SuspendLayout
Me.Panel514.SuspendLayout
Me.Panel515.SuspendLayout
Me.Panel516.SuspendLayout
Me.Panel517.SuspendLayout
Me.Panel518.SuspendLayout
Me.Panel456.SuspendLayout
Me.Panel457.SuspendLayout
Me.Panel458.SuspendLayout
Me.Panel459.SuspendLayout
Me.Panel460.SuspendLayout
Me.Panel461.SuspendLayout
Me.Panel462.SuspendLayout
Me.Panel463.SuspendLayout
Me.Panel464.SuspendLayout
Me.Panel465.SuspendLayout
Me.Panel466.SuspendLayout
Me.Panel467.SuspendLayout
Me.Panel468.SuspendLayout
Me.Panel469.SuspendLayout
Me.Panel470.SuspendLayout
Me.Panel471.SuspendLayout
Me.Panel472.SuspendLayout
Me.Panel473.SuspendLayout
Me.Panel474.SuspendLayout
Me.Panel475.SuspendLayout
Me.Panel476.SuspendLayout
Me.Panel477.SuspendLayout
Me.Panel478.SuspendLayout
Me.Panel479.SuspendLayout
Me.Panel480.SuspendLayout
Me.Panel481.SuspendLayout
Me.Panel482.SuspendLayout
Me.Panel483.SuspendLayout
Me.Panel484.SuspendLayout
Me.Panel485.SuspendLayout
Me.Panel486.SuspendLayout
Me.Panel487.SuspendLayout
Me.Panel488.SuspendLayout
Me.Panel489.SuspendLayout
Me.Panel490.SuspendLayout
Me.Panel491.SuspendLayout
Me.Panel492.SuspendLayout
Me.Panel493.SuspendLayout
Me.Panel494.SuspendLayout
Me.Panel495.SuspendLayout
Me.Panel496.SuspendLayout
Me.Panel497.SuspendLayout
Me.Panel519.SuspendLayout
Me.Panel520.SuspendLayout
Me.Panel521.SuspendLayout
Me.Panel522.SuspendLayout
Me.Panel523.SuspendLayout
Me.Panel524.SuspendLayout
Me.Panel525.SuspendLayout
Me.Panel526.SuspendLayout
Me.Panel527.SuspendLayout
Me.Panel528.SuspendLayout
Me.Panel529.SuspendLayout
Me.Panel530.SuspendLayout
Me.Panel531.SuspendLayout
Me.Panel532.SuspendLayout
Me.Panel533.SuspendLayout
Me.Panel534.SuspendLayout
Me.Panel535.SuspendLayout
Me.SuspendLayout
'
'Panel14
'
Me.Panel14.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel14.Controls.Add(Me.Label10)
Me.Panel14.Controls.Add(Me.Label22)
Me.Panel14.Controls.Add(Me.TextBox43)
Me.Panel14.Controls.Add(Me.TextBox44)
Me.Panel14.Location = New System.Drawing.Point(48, 8)
Me.Panel14.Name = "Panel14"
Me.Panel14.Size = New System.Drawing.Size(673, 24)
Me.Panel14.TabIndex = 20
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label10.Location = New System.Drawing.Point(8, 4)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(128, 16)
Me.Label10.TabIndex = 6
Me.Label10.Text = "Pression Mano Pulvé :"
Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label22
'
Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label22.Location = New System.Drawing.Point(392, 4)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(136, 16)
Me.Label22.TabIndex = 6
Me.Label22.Text = "Moyenne des pressions :"
Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox43
'
Me.TextBox43.Location = New System.Drawing.Point(144, 2)
Me.TextBox43.Name = "TextBox43"
Me.TextBox43.ReadOnly = true
Me.TextBox43.Size = New System.Drawing.Size(83, 20)
Me.TextBox43.TabIndex = 8
Me.TextBox43.Text = ""
'
'TextBox44
'
Me.TextBox44.Location = New System.Drawing.Point(536, 2)
Me.TextBox44.Name = "TextBox44"
Me.TextBox44.ReadOnly = true
Me.TextBox44.Size = New System.Drawing.Size(83, 20)
Me.TextBox44.TabIndex = 8
Me.TextBox44.Text = ""
'
'Panel21
'
Me.Panel21.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel21.Controls.Add(Me.Label11)
Me.Panel21.Location = New System.Drawing.Point(48, 32)
Me.Panel21.Name = "Panel21"
Me.Panel21.Size = New System.Drawing.Size(144, 24)
Me.Panel21.TabIndex = 20
'
'Label11
'
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label11.Location = New System.Drawing.Point(8, 4)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(128, 16)
Me.Label11.TabIndex = 6
Me.Label11.Text = "Niveau"
Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel22
'
Me.Panel22.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel22.Controls.Add(Me.Label12)
Me.Panel22.Location = New System.Drawing.Point(48, 56)
Me.Panel22.Name = "Panel22"
Me.Panel22.Size = New System.Drawing.Size(144, 24)
Me.Panel22.TabIndex = 20
'
'Label12
'
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label12.Location = New System.Drawing.Point(8, 4)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(128, 16)
Me.Label12.TabIndex = 6
Me.Label12.Text = "Section Gauche/Droite"
Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel23
'
Me.Panel23.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel23.Controls.Add(Me.Label17)
Me.Panel23.Location = New System.Drawing.Point(48, 80)
Me.Panel23.Name = "Panel23"
Me.Panel23.Size = New System.Drawing.Size(144, 24)
Me.Panel23.TabIndex = 20
'
'Label17
'
Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label17.Location = New System.Drawing.Point(8, 4)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(128, 16)
Me.Label17.TabIndex = 6
Me.Label17.Text = "P sortie"
Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel24
'
Me.Panel24.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel24.Controls.Add(Me.Label18)
Me.Panel24.Location = New System.Drawing.Point(48, 104)
Me.Panel24.Name = "Panel24"
Me.Panel24.Size = New System.Drawing.Size(144, 24)
Me.Panel24.TabIndex = 20
'
'Label18
'
Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label18.Location = New System.Drawing.Point(8, 4)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(128, 16)
Me.Label18.TabIndex = 6
Me.Label18.Text = "Ecart"
Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel25
'
Me.Panel25.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel25.Controls.Add(Me.Label19)
Me.Panel25.Location = New System.Drawing.Point(48, 128)
Me.Panel25.Name = "Panel25"
Me.Panel25.Size = New System.Drawing.Size(144, 24)
Me.Panel25.TabIndex = 20
'
'Label19
'
Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label19.Location = New System.Drawing.Point(8, 4)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(128, 16)
Me.Label19.TabIndex = 6
Me.Label19.Text = "Perte charge"
Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel26
'
Me.Panel26.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel26.Controls.Add(Me.Label20)
Me.Panel26.Location = New System.Drawing.Point(48, 152)
Me.Panel26.Name = "Panel26"
Me.Panel26.Size = New System.Drawing.Size(144, 24)
Me.Panel26.TabIndex = 20
'
'Label20
'
Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label20.Location = New System.Drawing.Point(8, 4)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(128, 16)
Me.Label20.TabIndex = 6
Me.Label20.Text = "Perte de charge moy"
Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel27
'
Me.Panel27.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel27.Controls.Add(Me.Label21)
Me.Panel27.Location = New System.Drawing.Point(48, 176)
Me.Panel27.Name = "Panel27"
Me.Panel27.Size = New System.Drawing.Size(144, 24)
Me.Panel27.TabIndex = 20
'
'Label21
'
Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label21.Location = New System.Drawing.Point(8, 4)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(128, 16)
Me.Label21.TabIndex = 6
Me.Label21.Text = "Perte de charge max"
Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel28
'
Me.Panel28.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel28.Controls.Add(Me.Label23)
Me.Panel28.Location = New System.Drawing.Point(192, 32)
Me.Panel28.Name = "Panel28"
Me.Panel28.Size = New System.Drawing.Size(89, 24)
Me.Panel28.TabIndex = 20
'
'Label23
'
Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label23.Location = New System.Drawing.Point(8, 4)
Me.Label23.Name = "Label23"
Me.Label23.Size = New System.Drawing.Size(80, 16)
Me.Label23.TabIndex = 6
Me.Label23.Text = "1"
Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel29
'
Me.Panel29.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel29.Controls.Add(Me.Label24)
Me.Panel29.Controls.Add(Me.Label25)
Me.Panel29.Location = New System.Drawing.Point(192, 56)
Me.Panel29.Name = "Panel29"
Me.Panel29.Size = New System.Drawing.Size(89, 24)
Me.Panel29.TabIndex = 20
'
'Label24
'
Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label24.Location = New System.Drawing.Point(8, 4)
Me.Label24.Name = "Label24"
Me.Label24.Size = New System.Drawing.Size(40, 16)
Me.Label24.TabIndex = 6
Me.Label24.Text = "G"
Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label25
'
Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label25.Location = New System.Drawing.Point(48, 4)
Me.Label25.Name = "Label25"
Me.Label25.Size = New System.Drawing.Size(40, 16)
Me.Label25.TabIndex = 6
Me.Label25.Text = "D"
Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel30
'
Me.Panel30.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel30.Controls.Add(Me.Label26)
Me.Panel30.Controls.Add(Me.Label34)
Me.Panel30.Location = New System.Drawing.Point(280, 56)
Me.Panel30.Name = "Panel30"
Me.Panel30.Size = New System.Drawing.Size(89, 24)
Me.Panel30.TabIndex = 20
'
'Label26
'
Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label26.Location = New System.Drawing.Point(8, 4)
Me.Label26.Name = "Label26"
Me.Label26.Size = New System.Drawing.Size(40, 16)
Me.Label26.TabIndex = 6
Me.Label26.Text = "G"
Me.Label26.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label34
'
Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label34.Location = New System.Drawing.Point(48, 4)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(40, 16)
Me.Label34.TabIndex = 6
Me.Label34.Text = "D"
Me.Label34.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel31
'
Me.Panel31.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel31.Controls.Add(Me.Label35)
Me.Panel31.Location = New System.Drawing.Point(280, 32)
Me.Panel31.Name = "Panel31"
Me.Panel31.Size = New System.Drawing.Size(89, 24)
Me.Panel31.TabIndex = 20
'
'Label35
'
Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label35.Location = New System.Drawing.Point(8, 4)
Me.Label35.Name = "Label35"
Me.Label35.Size = New System.Drawing.Size(80, 16)
Me.Label35.TabIndex = 6
Me.Label35.Text = "2"
Me.Label35.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel32
'
Me.Panel32.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel32.Controls.Add(Me.Label36)
Me.Panel32.Location = New System.Drawing.Point(368, 32)
Me.Panel32.Name = "Panel32"
Me.Panel32.Size = New System.Drawing.Size(89, 24)
Me.Panel32.TabIndex = 20
'
'Label36
'
Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label36.Location = New System.Drawing.Point(8, 4)
Me.Label36.Name = "Label36"
Me.Label36.Size = New System.Drawing.Size(80, 16)
Me.Label36.TabIndex = 6
Me.Label36.Text = "3"
Me.Label36.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel33
'
Me.Panel33.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel33.Controls.Add(Me.Label37)
Me.Panel33.Controls.Add(Me.Label38)
Me.Panel33.Location = New System.Drawing.Point(368, 56)
Me.Panel33.Name = "Panel33"
Me.Panel33.Size = New System.Drawing.Size(89, 24)
Me.Panel33.TabIndex = 20
'
'Label37
'
Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label37.Location = New System.Drawing.Point(8, 4)
Me.Label37.Name = "Label37"
Me.Label37.Size = New System.Drawing.Size(40, 16)
Me.Label37.TabIndex = 6
Me.Label37.Text = "G"
Me.Label37.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label38
'
Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label38.Location = New System.Drawing.Point(48, 4)
Me.Label38.Name = "Label38"
Me.Label38.Size = New System.Drawing.Size(40, 16)
Me.Label38.TabIndex = 6
Me.Label38.Text = "D"
Me.Label38.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel34
'
Me.Panel34.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel34.Controls.Add(Me.Label39)
Me.Panel34.Controls.Add(Me.Label40)
Me.Panel34.Location = New System.Drawing.Point(456, 56)
Me.Panel34.Name = "Panel34"
Me.Panel34.Size = New System.Drawing.Size(89, 24)
Me.Panel34.TabIndex = 20
'
'Label39
'
Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label39.Location = New System.Drawing.Point(8, 4)
Me.Label39.Name = "Label39"
Me.Label39.Size = New System.Drawing.Size(40, 16)
Me.Label39.TabIndex = 6
Me.Label39.Text = "G"
Me.Label39.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label40
'
Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label40.Location = New System.Drawing.Point(48, 4)
Me.Label40.Name = "Label40"
Me.Label40.Size = New System.Drawing.Size(40, 16)
Me.Label40.TabIndex = 6
Me.Label40.Text = "D"
Me.Label40.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel35
'
Me.Panel35.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel35.Controls.Add(Me.Label41)
Me.Panel35.Location = New System.Drawing.Point(456, 32)
Me.Panel35.Name = "Panel35"
Me.Panel35.Size = New System.Drawing.Size(89, 24)
Me.Panel35.TabIndex = 20
'
'Label41
'
Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label41.Location = New System.Drawing.Point(8, 4)
Me.Label41.Name = "Label41"
Me.Label41.Size = New System.Drawing.Size(80, 16)
Me.Label41.TabIndex = 6
Me.Label41.Text = "4"
Me.Label41.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel36
'
Me.Panel36.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel36.Controls.Add(Me.Label42)
Me.Panel36.Location = New System.Drawing.Point(544, 32)
Me.Panel36.Name = "Panel36"
Me.Panel36.Size = New System.Drawing.Size(89, 24)
Me.Panel36.TabIndex = 20
'
'Label42
'
Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label42.Location = New System.Drawing.Point(8, 4)
Me.Label42.Name = "Label42"
Me.Label42.Size = New System.Drawing.Size(80, 16)
Me.Label42.TabIndex = 6
Me.Label42.Text = "5"
Me.Label42.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel37
'
Me.Panel37.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel37.Controls.Add(Me.Label43)
Me.Panel37.Controls.Add(Me.Label44)
Me.Panel37.Location = New System.Drawing.Point(544, 56)
Me.Panel37.Name = "Panel37"
Me.Panel37.Size = New System.Drawing.Size(89, 24)
Me.Panel37.TabIndex = 20
'
'Label43
'
Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label43.Location = New System.Drawing.Point(8, 4)
Me.Label43.Name = "Label43"
Me.Label43.Size = New System.Drawing.Size(40, 16)
Me.Label43.TabIndex = 6
Me.Label43.Text = "G"
Me.Label43.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label44
'
Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label44.Location = New System.Drawing.Point(48, 4)
Me.Label44.Name = "Label44"
Me.Label44.Size = New System.Drawing.Size(40, 16)
Me.Label44.TabIndex = 6
Me.Label44.Text = "D"
Me.Label44.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel38
'
Me.Panel38.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel38.Controls.Add(Me.Label45)
Me.Panel38.Controls.Add(Me.Label46)
Me.Panel38.Location = New System.Drawing.Point(632, 56)
Me.Panel38.Name = "Panel38"
Me.Panel38.Size = New System.Drawing.Size(89, 24)
Me.Panel38.TabIndex = 20
'
'Label45
'
Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label45.Location = New System.Drawing.Point(8, 4)
Me.Label45.Name = "Label45"
Me.Label45.Size = New System.Drawing.Size(40, 16)
Me.Label45.TabIndex = 6
Me.Label45.Text = "G"
Me.Label45.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label46
'
Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label46.Location = New System.Drawing.Point(48, 4)
Me.Label46.Name = "Label46"
Me.Label46.Size = New System.Drawing.Size(40, 16)
Me.Label46.TabIndex = 6
Me.Label46.Text = "D"
Me.Label46.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel39
'
Me.Panel39.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel39.Controls.Add(Me.Label47)
Me.Panel39.Location = New System.Drawing.Point(632, 32)
Me.Panel39.Name = "Panel39"
Me.Panel39.Size = New System.Drawing.Size(89, 24)
Me.Panel39.TabIndex = 20
'
'Label47
'
Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label47.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label47.Location = New System.Drawing.Point(8, 4)
Me.Label47.Name = "Label47"
Me.Label47.Size = New System.Drawing.Size(80, 16)
Me.Label47.TabIndex = 6
Me.Label47.Text = "6"
Me.Label47.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel40
'
Me.Panel40.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel40.Controls.Add(Me.TextBox4)
Me.Panel40.Controls.Add(Me.TextBox3)
Me.Panel40.Location = New System.Drawing.Point(192, 80)
Me.Panel40.Name = "Panel40"
Me.Panel40.Size = New System.Drawing.Size(89, 24)
Me.Panel40.TabIndex = 20
'
'TextBox4
'
Me.TextBox4.Location = New System.Drawing.Point(3, 2)
Me.TextBox4.Name = "TextBox4"
Me.TextBox4.Size = New System.Drawing.Size(40, 20)
Me.TextBox4.TabIndex = 8
Me.TextBox4.Text = ""
'
'TextBox3
'
Me.TextBox3.Location = New System.Drawing.Point(46, 2)
Me.TextBox3.Name = "TextBox3"
Me.TextBox3.Size = New System.Drawing.Size(40, 20)
Me.TextBox3.TabIndex = 7
Me.TextBox3.Text = ""
'
'Panel41
'
Me.Panel41.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel41.Controls.Add(Me.TextBox5)
Me.Panel41.Controls.Add(Me.TextBox6)
Me.Panel41.Location = New System.Drawing.Point(280, 80)
Me.Panel41.Name = "Panel41"
Me.Panel41.Size = New System.Drawing.Size(89, 24)
Me.Panel41.TabIndex = 20
'
'TextBox5
'
Me.TextBox5.Location = New System.Drawing.Point(3, 2)
Me.TextBox5.Name = "TextBox5"
Me.TextBox5.Size = New System.Drawing.Size(40, 20)
Me.TextBox5.TabIndex = 8
Me.TextBox5.Text = ""
'
'TextBox6
'
Me.TextBox6.Location = New System.Drawing.Point(46, 2)
Me.TextBox6.Name = "TextBox6"
Me.TextBox6.Size = New System.Drawing.Size(40, 20)
Me.TextBox6.TabIndex = 7
Me.TextBox6.Text = ""
'
'Panel42
'
Me.Panel42.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel42.Controls.Add(Me.TextBox11)
Me.Panel42.Controls.Add(Me.TextBox12)
Me.Panel42.Location = New System.Drawing.Point(368, 80)
Me.Panel42.Name = "Panel42"
Me.Panel42.Size = New System.Drawing.Size(89, 24)
Me.Panel42.TabIndex = 20
'
'TextBox11
'
Me.TextBox11.Location = New System.Drawing.Point(3, 2)
Me.TextBox11.Name = "TextBox11"
Me.TextBox11.Size = New System.Drawing.Size(40, 20)
Me.TextBox11.TabIndex = 8
Me.TextBox11.Text = ""
'
'TextBox12
'
Me.TextBox12.Location = New System.Drawing.Point(46, 2)
Me.TextBox12.Name = "TextBox12"
Me.TextBox12.Size = New System.Drawing.Size(40, 20)
Me.TextBox12.TabIndex = 7
Me.TextBox12.Text = ""
'
'Panel43
'
Me.Panel43.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel43.Controls.Add(Me.TextBox13)
Me.Panel43.Controls.Add(Me.TextBox14)
Me.Panel43.Location = New System.Drawing.Point(456, 80)
Me.Panel43.Name = "Panel43"
Me.Panel43.Size = New System.Drawing.Size(89, 24)
Me.Panel43.TabIndex = 20
'
'TextBox13
'
Me.TextBox13.Location = New System.Drawing.Point(3, 2)
Me.TextBox13.Name = "TextBox13"
Me.TextBox13.Size = New System.Drawing.Size(40, 20)
Me.TextBox13.TabIndex = 8
Me.TextBox13.Text = ""
'
'TextBox14
'
Me.TextBox14.Location = New System.Drawing.Point(46, 2)
Me.TextBox14.Name = "TextBox14"
Me.TextBox14.Size = New System.Drawing.Size(40, 20)
Me.TextBox14.TabIndex = 7
Me.TextBox14.Text = ""
'
'Panel44
'
Me.Panel44.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel44.Controls.Add(Me.TextBox15)
Me.Panel44.Controls.Add(Me.TextBox16)
Me.Panel44.Location = New System.Drawing.Point(544, 80)
Me.Panel44.Name = "Panel44"
Me.Panel44.Size = New System.Drawing.Size(89, 24)
Me.Panel44.TabIndex = 20
'
'TextBox15
'
Me.TextBox15.Location = New System.Drawing.Point(3, 2)
Me.TextBox15.Name = "TextBox15"
Me.TextBox15.Size = New System.Drawing.Size(40, 20)
Me.TextBox15.TabIndex = 8
Me.TextBox15.Text = ""
'
'TextBox16
'
Me.TextBox16.Location = New System.Drawing.Point(46, 2)
Me.TextBox16.Name = "TextBox16"
Me.TextBox16.Size = New System.Drawing.Size(40, 20)
Me.TextBox16.TabIndex = 7
Me.TextBox16.Text = ""
'
'Panel45
'
Me.Panel45.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel45.Controls.Add(Me.TextBox17)
Me.Panel45.Controls.Add(Me.TextBox18)
Me.Panel45.Location = New System.Drawing.Point(632, 80)
Me.Panel45.Name = "Panel45"
Me.Panel45.Size = New System.Drawing.Size(89, 24)
Me.Panel45.TabIndex = 20
'
'TextBox17
'
Me.TextBox17.Location = New System.Drawing.Point(3, 2)
Me.TextBox17.Name = "TextBox17"
Me.TextBox17.Size = New System.Drawing.Size(40, 20)
Me.TextBox17.TabIndex = 8
Me.TextBox17.Text = ""
'
'TextBox18
'
Me.TextBox18.Location = New System.Drawing.Point(46, 2)
Me.TextBox18.Name = "TextBox18"
Me.TextBox18.Size = New System.Drawing.Size(40, 20)
Me.TextBox18.TabIndex = 7
Me.TextBox18.Text = ""
'
'Panel46
'
Me.Panel46.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel46.Controls.Add(Me.TextBox19)
Me.Panel46.Controls.Add(Me.TextBox20)
Me.Panel46.Location = New System.Drawing.Point(280, 104)
Me.Panel46.Name = "Panel46"
Me.Panel46.Size = New System.Drawing.Size(89, 24)
Me.Panel46.TabIndex = 20
'
'TextBox19
'
Me.TextBox19.Location = New System.Drawing.Point(3, 2)
Me.TextBox19.Name = "TextBox19"
Me.TextBox19.ReadOnly = true
Me.TextBox19.Size = New System.Drawing.Size(40, 20)
Me.TextBox19.TabIndex = 8
Me.TextBox19.Text = ""
'
'TextBox20
'
Me.TextBox20.Location = New System.Drawing.Point(46, 2)
Me.TextBox20.Name = "TextBox20"
Me.TextBox20.ReadOnly = true
Me.TextBox20.Size = New System.Drawing.Size(40, 20)
Me.TextBox20.TabIndex = 7
Me.TextBox20.Text = ""
'
'Panel47
'
Me.Panel47.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel47.Controls.Add(Me.TextBox21)
Me.Panel47.Controls.Add(Me.TextBox22)
Me.Panel47.Location = New System.Drawing.Point(632, 104)
Me.Panel47.Name = "Panel47"
Me.Panel47.Size = New System.Drawing.Size(89, 24)
Me.Panel47.TabIndex = 20
'
'TextBox21
'
Me.TextBox21.Location = New System.Drawing.Point(3, 2)
Me.TextBox21.Name = "TextBox21"
Me.TextBox21.ReadOnly = true
Me.TextBox21.Size = New System.Drawing.Size(40, 20)
Me.TextBox21.TabIndex = 8
Me.TextBox21.Text = ""
'
'TextBox22
'
Me.TextBox22.Location = New System.Drawing.Point(46, 2)
Me.TextBox22.Name = "TextBox22"
Me.TextBox22.ReadOnly = true
Me.TextBox22.Size = New System.Drawing.Size(40, 20)
Me.TextBox22.TabIndex = 7
Me.TextBox22.Text = ""
'
'Panel48
'
Me.Panel48.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel48.Controls.Add(Me.TextBox23)
Me.Panel48.Controls.Add(Me.TextBox24)
Me.Panel48.Location = New System.Drawing.Point(456, 104)
Me.Panel48.Name = "Panel48"
Me.Panel48.Size = New System.Drawing.Size(89, 24)
Me.Panel48.TabIndex = 20
'
'TextBox23
'
Me.TextBox23.Location = New System.Drawing.Point(3, 2)
Me.TextBox23.Name = "TextBox23"
Me.TextBox23.ReadOnly = true
Me.TextBox23.Size = New System.Drawing.Size(40, 20)
Me.TextBox23.TabIndex = 8
Me.TextBox23.Text = ""
'
'TextBox24
'
Me.TextBox24.Location = New System.Drawing.Point(46, 2)
Me.TextBox24.Name = "TextBox24"
Me.TextBox24.ReadOnly = true
Me.TextBox24.Size = New System.Drawing.Size(40, 20)
Me.TextBox24.TabIndex = 7
Me.TextBox24.Text = ""
'
'Panel49
'
Me.Panel49.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel49.Controls.Add(Me.TextBox25)
Me.Panel49.Controls.Add(Me.TextBox26)
Me.Panel49.Location = New System.Drawing.Point(544, 104)
Me.Panel49.Name = "Panel49"
Me.Panel49.Size = New System.Drawing.Size(89, 24)
Me.Panel49.TabIndex = 20
'
'TextBox25
'
Me.TextBox25.Location = New System.Drawing.Point(3, 2)
Me.TextBox25.Name = "TextBox25"
Me.TextBox25.ReadOnly = true
Me.TextBox25.Size = New System.Drawing.Size(40, 20)
Me.TextBox25.TabIndex = 8
Me.TextBox25.Text = ""
'
'TextBox26
'
Me.TextBox26.Location = New System.Drawing.Point(46, 2)
Me.TextBox26.Name = "TextBox26"
Me.TextBox26.ReadOnly = true
Me.TextBox26.Size = New System.Drawing.Size(40, 20)
Me.TextBox26.TabIndex = 7
Me.TextBox26.Text = ""
'
'Panel52
'
Me.Panel52.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel52.Controls.Add(Me.TextBox27)
Me.Panel52.Controls.Add(Me.TextBox28)
Me.Panel52.Location = New System.Drawing.Point(192, 104)
Me.Panel52.Name = "Panel52"
Me.Panel52.Size = New System.Drawing.Size(89, 24)
Me.Panel52.TabIndex = 20
'
'TextBox27
'
Me.TextBox27.Location = New System.Drawing.Point(3, 2)
Me.TextBox27.Name = "TextBox27"
Me.TextBox27.ReadOnly = true
Me.TextBox27.Size = New System.Drawing.Size(40, 20)
Me.TextBox27.TabIndex = 8
Me.TextBox27.Text = ""
'
'TextBox28
'
Me.TextBox28.Location = New System.Drawing.Point(46, 2)
Me.TextBox28.Name = "TextBox28"
Me.TextBox28.ReadOnly = true
Me.TextBox28.Size = New System.Drawing.Size(40, 20)
Me.TextBox28.TabIndex = 7
Me.TextBox28.Text = ""
'
'Panel53
'
Me.Panel53.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel53.Controls.Add(Me.TextBox29)
Me.Panel53.Controls.Add(Me.TextBox30)
Me.Panel53.Location = New System.Drawing.Point(368, 104)
Me.Panel53.Name = "Panel53"
Me.Panel53.Size = New System.Drawing.Size(89, 24)
Me.Panel53.TabIndex = 20
'
'TextBox29
'
Me.TextBox29.Location = New System.Drawing.Point(3, 2)
Me.TextBox29.Name = "TextBox29"
Me.TextBox29.ReadOnly = true
Me.TextBox29.Size = New System.Drawing.Size(40, 20)
Me.TextBox29.TabIndex = 8
Me.TextBox29.Text = ""
'
'TextBox30
'
Me.TextBox30.Location = New System.Drawing.Point(46, 2)
Me.TextBox30.Name = "TextBox30"
Me.TextBox30.ReadOnly = true
Me.TextBox30.Size = New System.Drawing.Size(40, 20)
Me.TextBox30.TabIndex = 7
Me.TextBox30.Text = ""
'
'Panel54
'
Me.Panel54.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel54.Controls.Add(Me.TextBox31)
Me.Panel54.Controls.Add(Me.TextBox32)
Me.Panel54.Location = New System.Drawing.Point(456, 128)
Me.Panel54.Name = "Panel54"
Me.Panel54.Size = New System.Drawing.Size(89, 24)
Me.Panel54.TabIndex = 20
'
'TextBox31
'
Me.TextBox31.Location = New System.Drawing.Point(3, 2)
Me.TextBox31.Name = "TextBox31"
Me.TextBox31.ReadOnly = true
Me.TextBox31.Size = New System.Drawing.Size(40, 20)
Me.TextBox31.TabIndex = 8
Me.TextBox31.Text = ""
'
'TextBox32
'
Me.TextBox32.Location = New System.Drawing.Point(46, 2)
Me.TextBox32.Name = "TextBox32"
Me.TextBox32.ReadOnly = true
Me.TextBox32.Size = New System.Drawing.Size(40, 20)
Me.TextBox32.TabIndex = 7
Me.TextBox32.Text = ""
'
'Panel55
'
Me.Panel55.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel55.Controls.Add(Me.TextBox33)
Me.Panel55.Controls.Add(Me.TextBox34)
Me.Panel55.Location = New System.Drawing.Point(544, 128)
Me.Panel55.Name = "Panel55"
Me.Panel55.Size = New System.Drawing.Size(89, 24)
Me.Panel55.TabIndex = 20
'
'TextBox33
'
Me.TextBox33.Location = New System.Drawing.Point(3, 2)
Me.TextBox33.Name = "TextBox33"
Me.TextBox33.ReadOnly = true
Me.TextBox33.Size = New System.Drawing.Size(40, 20)
Me.TextBox33.TabIndex = 8
Me.TextBox33.Text = ""
'
'TextBox34
'
Me.TextBox34.Location = New System.Drawing.Point(46, 2)
Me.TextBox34.Name = "TextBox34"
Me.TextBox34.ReadOnly = true
Me.TextBox34.Size = New System.Drawing.Size(40, 20)
Me.TextBox34.TabIndex = 7
Me.TextBox34.Text = ""
'
'Panel56
'
Me.Panel56.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel56.Controls.Add(Me.TextBox35)
Me.Panel56.Controls.Add(Me.TextBox36)
Me.Panel56.Location = New System.Drawing.Point(632, 128)
Me.Panel56.Name = "Panel56"
Me.Panel56.Size = New System.Drawing.Size(89, 24)
Me.Panel56.TabIndex = 20
'
'TextBox35
'
Me.TextBox35.Location = New System.Drawing.Point(3, 2)
Me.TextBox35.Name = "TextBox35"
Me.TextBox35.ReadOnly = true
Me.TextBox35.Size = New System.Drawing.Size(40, 20)
Me.TextBox35.TabIndex = 8
Me.TextBox35.Text = ""
'
'TextBox36
'
Me.TextBox36.Location = New System.Drawing.Point(46, 2)
Me.TextBox36.Name = "TextBox36"
Me.TextBox36.ReadOnly = true
Me.TextBox36.Size = New System.Drawing.Size(40, 20)
Me.TextBox36.TabIndex = 7
Me.TextBox36.Text = ""
'
'Panel57
'
Me.Panel57.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel57.Controls.Add(Me.TextBox37)
Me.Panel57.Controls.Add(Me.TextBox38)
Me.Panel57.Location = New System.Drawing.Point(280, 128)
Me.Panel57.Name = "Panel57"
Me.Panel57.Size = New System.Drawing.Size(89, 24)
Me.Panel57.TabIndex = 20
'
'TextBox37
'
Me.TextBox37.Location = New System.Drawing.Point(3, 2)
Me.TextBox37.Name = "TextBox37"
Me.TextBox37.ReadOnly = true
Me.TextBox37.Size = New System.Drawing.Size(40, 20)
Me.TextBox37.TabIndex = 8
Me.TextBox37.Text = ""
'
'TextBox38
'
Me.TextBox38.Location = New System.Drawing.Point(46, 2)
Me.TextBox38.Name = "TextBox38"
Me.TextBox38.ReadOnly = true
Me.TextBox38.Size = New System.Drawing.Size(40, 20)
Me.TextBox38.TabIndex = 7
Me.TextBox38.Text = ""
'
'Panel58
'
Me.Panel58.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel58.Controls.Add(Me.TextBox39)
Me.Panel58.Controls.Add(Me.TextBox40)
Me.Panel58.Location = New System.Drawing.Point(192, 128)
Me.Panel58.Name = "Panel58"
Me.Panel58.Size = New System.Drawing.Size(89, 24)
Me.Panel58.TabIndex = 20
'
'TextBox39
'
Me.TextBox39.Location = New System.Drawing.Point(3, 2)
Me.TextBox39.Name = "TextBox39"
Me.TextBox39.ReadOnly = true
Me.TextBox39.Size = New System.Drawing.Size(40, 20)
Me.TextBox39.TabIndex = 8
Me.TextBox39.Text = ""
'
'TextBox40
'
Me.TextBox40.Location = New System.Drawing.Point(46, 2)
Me.TextBox40.Name = "TextBox40"
Me.TextBox40.ReadOnly = true
Me.TextBox40.Size = New System.Drawing.Size(40, 20)
Me.TextBox40.TabIndex = 7
Me.TextBox40.Text = ""
'
'Panel59
'
Me.Panel59.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel59.Controls.Add(Me.TextBox41)
Me.Panel59.Controls.Add(Me.TextBox42)
Me.Panel59.Location = New System.Drawing.Point(368, 128)
Me.Panel59.Name = "Panel59"
Me.Panel59.Size = New System.Drawing.Size(89, 24)
Me.Panel59.TabIndex = 20
'
'TextBox41
'
Me.TextBox41.Location = New System.Drawing.Point(3, 2)
Me.TextBox41.Name = "TextBox41"
Me.TextBox41.ReadOnly = true
Me.TextBox41.Size = New System.Drawing.Size(40, 20)
Me.TextBox41.TabIndex = 8
Me.TextBox41.Text = ""
'
'TextBox42
'
Me.TextBox42.Location = New System.Drawing.Point(46, 2)
Me.TextBox42.Name = "TextBox42"
Me.TextBox42.ReadOnly = true
Me.TextBox42.Size = New System.Drawing.Size(40, 20)
Me.TextBox42.TabIndex = 7
Me.TextBox42.Text = ""
'
'Panel63
'
Me.Panel63.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel63.Controls.Add(Me.TextBox46)
Me.Panel63.Location = New System.Drawing.Point(192, 152)
Me.Panel63.Name = "Panel63"
Me.Panel63.Size = New System.Drawing.Size(89, 24)
Me.Panel63.TabIndex = 20
'
'TextBox46
'
Me.TextBox46.Location = New System.Drawing.Point(3, 2)
Me.TextBox46.Name = "TextBox46"
Me.TextBox46.ReadOnly = true
Me.TextBox46.Size = New System.Drawing.Size(83, 20)
Me.TextBox46.TabIndex = 8
Me.TextBox46.Text = ""
'
'Panel64
'
Me.Panel64.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel64.Controls.Add(Me.TextBox45)
Me.Panel64.Location = New System.Drawing.Point(192, 176)
Me.Panel64.Name = "Panel64"
Me.Panel64.Size = New System.Drawing.Size(89, 24)
Me.Panel64.TabIndex = 20
'
'TextBox45
'
Me.TextBox45.Location = New System.Drawing.Point(3, 2)
Me.TextBox45.Name = "TextBox45"
Me.TextBox45.ReadOnly = true
Me.TextBox45.Size = New System.Drawing.Size(83, 20)
Me.TextBox45.TabIndex = 8
Me.TextBox45.Text = ""
'
'Panel83
'
Me.Panel83.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel83.Controls.Add(Me.Label48)
Me.Panel83.Location = New System.Drawing.Point(280, 152)
Me.Panel83.Name = "Panel83"
Me.Panel83.Size = New System.Drawing.Size(177, 48)
Me.Panel83.TabIndex = 20
'
'Label48
'
Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label48.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label48.Location = New System.Drawing.Point(8, 16)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(160, 16)
Me.Label48.TabIndex = 6
Me.Label48.Text = "Hétérogénité d'alimentation :"
Me.Label48.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel84
'
Me.Panel84.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel84.Controls.Add(Me.Label49)
Me.Panel84.Controls.Add(Me.Label54)
Me.Panel84.Location = New System.Drawing.Point(456, 152)
Me.Panel84.Name = "Panel84"
Me.Panel84.Size = New System.Drawing.Size(265, 48)
Me.Panel84.TabIndex = 20
'
'Label49
'
Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label49.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label49.Location = New System.Drawing.Point(48, 16)
Me.Label49.Name = "Label49"
Me.Label49.Size = New System.Drawing.Size(168, 16)
Me.Label49.TabIndex = 29
Me.Label49.Text = "OK"
Me.Label49.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label54
'
Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label54.ForeColor = System.Drawing.Color.Red
Me.Label54.Location = New System.Drawing.Point(48, 16)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(168, 16)
Me.Label54.TabIndex = 28
Me.Label54.Text = "DEFAUT"
Me.Label54.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel1
'
Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel1.Controls.Add(Me.TextBox1)
Me.Panel1.Location = New System.Drawing.Point(320, 352)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(64, 24)
Me.Panel1.TabIndex = 129
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(3, 2)
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.ReadOnly = true
Me.TextBox1.Size = New System.Drawing.Size(55, 20)
Me.TextBox1.TabIndex = 8
Me.TextBox1.Text = ""
'
'Panel2
'
Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel2.Controls.Add(Me.TextBox7)
Me.Panel2.Location = New System.Drawing.Point(896, 328)
Me.Panel2.Name = "Panel2"
Me.Panel2.Size = New System.Drawing.Size(64, 24)
Me.Panel2.TabIndex = 107
'
'TextBox7
'
Me.TextBox7.Location = New System.Drawing.Point(3, 2)
Me.TextBox7.Name = "TextBox7"
Me.TextBox7.ReadOnly = true
Me.TextBox7.Size = New System.Drawing.Size(55, 20)
Me.TextBox7.TabIndex = 8
Me.TextBox7.Text = ""
'
'Panel3
'
Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel3.Controls.Add(Me.TextBox9)
Me.Panel3.Location = New System.Drawing.Point(192, 376)
Me.Panel3.Name = "Panel3"
Me.Panel3.Size = New System.Drawing.Size(89, 24)
Me.Panel3.TabIndex = 128
'
'TextBox9
'
Me.TextBox9.Location = New System.Drawing.Point(3, 2)
Me.TextBox9.Name = "TextBox9"
Me.TextBox9.ReadOnly = true
Me.TextBox9.Size = New System.Drawing.Size(83, 20)
Me.TextBox9.TabIndex = 8
Me.TextBox9.Text = ""
'
'Panel4
'
Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel4.Controls.Add(Me.Label1)
Me.Panel4.Location = New System.Drawing.Point(896, 280)
Me.Panel4.Name = "Panel4"
Me.Panel4.Size = New System.Drawing.Size(64, 24)
Me.Panel4.TabIndex = 165
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label1.Location = New System.Drawing.Point(8, 4)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(48, 16)
Me.Label1.TabIndex = 6
Me.Label1.Text = "12"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel5
'
Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel5.Controls.Add(Me.Label2)
Me.Panel5.Location = New System.Drawing.Point(192, 280)
Me.Panel5.Name = "Panel5"
Me.Panel5.Size = New System.Drawing.Size(64, 24)
Me.Panel5.TabIndex = 148
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label2.Location = New System.Drawing.Point(8, 4)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(48, 16)
Me.Label2.TabIndex = 6
Me.Label2.Text = "1"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel6
'
Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel6.Controls.Add(Me.Label3)
Me.Panel6.Location = New System.Drawing.Point(704, 280)
Me.Panel6.Name = "Panel6"
Me.Panel6.Size = New System.Drawing.Size(64, 24)
Me.Panel6.TabIndex = 171
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label3.Location = New System.Drawing.Point(8, 4)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(48, 16)
Me.Label3.TabIndex = 6
Me.Label3.Text = "9"
Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel7
'
Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel7.Controls.Add(Me.TextBox10)
Me.Panel7.Location = New System.Drawing.Point(192, 400)
Me.Panel7.Name = "Panel7"
Me.Panel7.Size = New System.Drawing.Size(89, 24)
Me.Panel7.TabIndex = 130
'
'TextBox10
'
Me.TextBox10.Location = New System.Drawing.Point(3, 2)
Me.TextBox10.Name = "TextBox10"
Me.TextBox10.ReadOnly = true
Me.TextBox10.Size = New System.Drawing.Size(83, 20)
Me.TextBox10.TabIndex = 8
Me.TextBox10.Text = ""
'
'Panel8
'
Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel8.Controls.Add(Me.TextBox47)
Me.Panel8.Location = New System.Drawing.Point(704, 352)
Me.Panel8.Name = "Panel8"
Me.Panel8.Size = New System.Drawing.Size(64, 24)
Me.Panel8.TabIndex = 135
'
'TextBox47
'
Me.TextBox47.Location = New System.Drawing.Point(3, 2)
Me.TextBox47.Name = "TextBox47"
Me.TextBox47.ReadOnly = true
Me.TextBox47.Size = New System.Drawing.Size(55, 20)
Me.TextBox47.TabIndex = 8
Me.TextBox47.Text = ""
'
'Panel9
'
Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel9.Controls.Add(Me.Label4)
Me.Panel9.Location = New System.Drawing.Point(280, 376)
Me.Panel9.Name = "Panel9"
Me.Panel9.Size = New System.Drawing.Size(177, 48)
Me.Panel9.TabIndex = 132
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label4.Location = New System.Drawing.Point(8, 16)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(160, 16)
Me.Label4.TabIndex = 6
Me.Label4.Text = "Hétérogénité d'alimentation :"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel10
'
Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel10.Controls.Add(Me.Label5)
Me.Panel10.Controls.Add(Me.Label6)
Me.Panel10.Controls.Add(Me.TextBox49)
Me.Panel10.Controls.Add(Me.TextBox50)
Me.Panel10.Location = New System.Drawing.Point(48, 256)
Me.Panel10.Name = "Panel10"
Me.Panel10.Size = New System.Drawing.Size(912, 24)
Me.Panel10.TabIndex = 150
'
'Label5
'
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label5.Location = New System.Drawing.Point(8, 4)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(128, 16)
Me.Label5.TabIndex = 6
Me.Label5.Text = "Pression Mano Pulvé :"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label6
'
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label6.Location = New System.Drawing.Point(632, 4)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(136, 16)
Me.Label6.TabIndex = 6
Me.Label6.Text = "Moyenne des pressions :"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox49
'
Me.TextBox49.Location = New System.Drawing.Point(144, 2)
Me.TextBox49.Name = "TextBox49"
Me.TextBox49.ReadOnly = true
Me.TextBox49.Size = New System.Drawing.Size(83, 20)
Me.TextBox49.TabIndex = 8
Me.TextBox49.Text = "5"
'
'TextBox50
'
Me.TextBox50.Location = New System.Drawing.Point(776, 2)
Me.TextBox50.Name = "TextBox50"
Me.TextBox50.ReadOnly = true
Me.TextBox50.Size = New System.Drawing.Size(83, 20)
Me.TextBox50.TabIndex = 8
Me.TextBox50.Text = ""
'
'Panel11
'
Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel11.Controls.Add(Me.TextBox51)
Me.Panel11.Location = New System.Drawing.Point(768, 328)
Me.Panel11.Name = "Panel11"
Me.Panel11.Size = New System.Drawing.Size(64, 24)
Me.Panel11.TabIndex = 108
'
'TextBox51
'
Me.TextBox51.Location = New System.Drawing.Point(3, 2)
Me.TextBox51.Name = "TextBox51"
Me.TextBox51.ReadOnly = true
Me.TextBox51.Size = New System.Drawing.Size(55, 20)
Me.TextBox51.TabIndex = 8
Me.TextBox51.Text = ""
'
'Panel13
'
Me.Panel13.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel13.Controls.Add(Me.Label9)
Me.Panel13.Controls.Add(Me.Label13)
Me.Panel13.Location = New System.Drawing.Point(456, 376)
Me.Panel13.Name = "Panel13"
Me.Panel13.Size = New System.Drawing.Size(504, 48)
Me.Panel13.TabIndex = 131
'
'Label9
'
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label9.Location = New System.Drawing.Point(48, 16)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(168, 16)
Me.Label9.TabIndex = 29
Me.Label9.Text = "OK"
Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label13
'
Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label13.ForeColor = System.Drawing.Color.Red
Me.Label13.Location = New System.Drawing.Point(48, 16)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(168, 16)
Me.Label13.TabIndex = 28
Me.Label13.Text = "DEFAUT"
Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel16
'
Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel16.Controls.Add(Me.TextBox53)
Me.Panel16.Location = New System.Drawing.Point(640, 352)
Me.Panel16.Name = "Panel16"
Me.Panel16.Size = New System.Drawing.Size(64, 24)
Me.Panel16.TabIndex = 137
'
'TextBox53
'
Me.TextBox53.Location = New System.Drawing.Point(3, 2)
Me.TextBox53.Name = "TextBox53"
Me.TextBox53.ReadOnly = true
Me.TextBox53.Size = New System.Drawing.Size(55, 20)
Me.TextBox53.TabIndex = 8
Me.TextBox53.Text = ""
'
'Panel18
'
Me.Panel18.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel18.Controls.Add(Me.TextBox55)
Me.Panel18.Location = New System.Drawing.Point(768, 304)
Me.Panel18.Name = "Panel18"
Me.Panel18.Size = New System.Drawing.Size(64, 24)
Me.Panel18.TabIndex = 122
'
'TextBox55
'
Me.TextBox55.Location = New System.Drawing.Point(3, 2)
Me.TextBox55.Name = "TextBox55"
Me.TextBox55.Size = New System.Drawing.Size(55, 20)
Me.TextBox55.TabIndex = 8
Me.TextBox55.Text = ""
'
'Panel20
'
Me.Panel20.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel20.Controls.Add(Me.Label30)
Me.Panel20.Location = New System.Drawing.Point(768, 280)
Me.Panel20.Name = "Panel20"
Me.Panel20.Size = New System.Drawing.Size(64, 24)
Me.Panel20.TabIndex = 170
'
'Label30
'
Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label30.Location = New System.Drawing.Point(8, 4)
Me.Label30.Name = "Label30"
Me.Label30.Size = New System.Drawing.Size(48, 16)
Me.Label30.TabIndex = 6
Me.Label30.Text = "10"
Me.Label30.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel50
'
Me.Panel50.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel50.Controls.Add(Me.Label31)
Me.Panel50.Location = New System.Drawing.Point(256, 280)
Me.Panel50.Name = "Panel50"
Me.Panel50.Size = New System.Drawing.Size(64, 24)
Me.Panel50.TabIndex = 173
'
'Label31
'
Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label31.Location = New System.Drawing.Point(8, 4)
Me.Label31.Name = "Label31"
Me.Label31.Size = New System.Drawing.Size(48, 16)
Me.Label31.TabIndex = 6
Me.Label31.Text = "2"
Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel51
'
Me.Panel51.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel51.Controls.Add(Me.Label32)
Me.Panel51.Location = New System.Drawing.Point(48, 304)
Me.Panel51.Name = "Panel51"
Me.Panel51.Size = New System.Drawing.Size(144, 24)
Me.Panel51.TabIndex = 153
'
'Label32
'
Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label32.Location = New System.Drawing.Point(8, 4)
Me.Label32.Name = "Label32"
Me.Label32.Size = New System.Drawing.Size(128, 16)
Me.Label32.TabIndex = 6
Me.Label32.Text = "P sortie"
Me.Label32.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel60
'
Me.Panel60.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel60.Controls.Add(Me.TextBox57)
Me.Panel60.Location = New System.Drawing.Point(704, 328)
Me.Panel60.Name = "Panel60"
Me.Panel60.Size = New System.Drawing.Size(64, 24)
Me.Panel60.TabIndex = 109
'
'TextBox57
'
Me.TextBox57.Location = New System.Drawing.Point(3, 2)
Me.TextBox57.Name = "TextBox57"
Me.TextBox57.ReadOnly = true
Me.TextBox57.Size = New System.Drawing.Size(55, 20)
Me.TextBox57.TabIndex = 8
Me.TextBox57.Text = ""
'
'Panel61
'
Me.Panel61.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel61.Controls.Add(Me.Label33)
Me.Panel61.Location = New System.Drawing.Point(48, 328)
Me.Panel61.Name = "Panel61"
Me.Panel61.Size = New System.Drawing.Size(144, 24)
Me.Panel61.TabIndex = 152
'
'Label33
'
Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label33.Location = New System.Drawing.Point(8, 4)
Me.Label33.Name = "Label33"
Me.Label33.Size = New System.Drawing.Size(128, 16)
Me.Label33.TabIndex = 6
Me.Label33.Text = "Ecart"
Me.Label33.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel62
'
Me.Panel62.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel62.Controls.Add(Me.Label50)
Me.Panel62.Location = New System.Drawing.Point(48, 352)
Me.Panel62.Name = "Panel62"
Me.Panel62.Size = New System.Drawing.Size(144, 24)
Me.Panel62.TabIndex = 145
'
'Label50
'
Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label50.Location = New System.Drawing.Point(8, 4)
Me.Label50.Name = "Label50"
Me.Label50.Size = New System.Drawing.Size(128, 16)
Me.Label50.TabIndex = 6
Me.Label50.Text = "Perte charge"
Me.Label50.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel65
'
Me.Panel65.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel65.Controls.Add(Me.Label51)
Me.Panel65.Location = New System.Drawing.Point(48, 376)
Me.Panel65.Name = "Panel65"
Me.Panel65.Size = New System.Drawing.Size(144, 24)
Me.Panel65.TabIndex = 144
'
'Label51
'
Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label51.Location = New System.Drawing.Point(8, 4)
Me.Label51.Name = "Label51"
Me.Label51.Size = New System.Drawing.Size(128, 16)
Me.Label51.TabIndex = 6
Me.Label51.Text = "Perte de charge moy"
Me.Label51.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel66
'
Me.Panel66.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel66.Controls.Add(Me.TextBox59)
Me.Panel66.Location = New System.Drawing.Point(832, 328)
Me.Panel66.Name = "Panel66"
Me.Panel66.Size = New System.Drawing.Size(64, 24)
Me.Panel66.TabIndex = 105
'
'TextBox59
'
Me.TextBox59.Location = New System.Drawing.Point(3, 2)
Me.TextBox59.Name = "TextBox59"
Me.TextBox59.ReadOnly = true
Me.TextBox59.Size = New System.Drawing.Size(55, 20)
Me.TextBox59.TabIndex = 8
Me.TextBox59.Text = ""
'
'Panel67
'
Me.Panel67.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel67.Controls.Add(Me.Label52)
Me.Panel67.Location = New System.Drawing.Point(48, 400)
Me.Panel67.Name = "Panel67"
Me.Panel67.Size = New System.Drawing.Size(144, 24)
Me.Panel67.TabIndex = 146
'
'Label52
'
Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label52.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label52.Location = New System.Drawing.Point(8, 4)
Me.Label52.Name = "Label52"
Me.Label52.Size = New System.Drawing.Size(128, 16)
Me.Label52.TabIndex = 6
Me.Label52.Text = "Perte de charge max"
Me.Label52.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel68
'
Me.Panel68.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel68.Controls.Add(Me.Label53)
Me.Panel68.Location = New System.Drawing.Point(48, 280)
Me.Panel68.Name = "Panel68"
Me.Panel68.Size = New System.Drawing.Size(144, 24)
Me.Panel68.TabIndex = 149
'
'Label53
'
Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label53.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label53.Location = New System.Drawing.Point(8, 4)
Me.Label53.Name = "Label53"
Me.Label53.Size = New System.Drawing.Size(128, 16)
Me.Label53.TabIndex = 6
Me.Label53.Text = "Tronçon"
Me.Label53.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel70
'
Me.Panel70.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel70.Controls.Add(Me.Label56)
Me.Panel70.Location = New System.Drawing.Point(320, 280)
Me.Panel70.Name = "Panel70"
Me.Panel70.Size = New System.Drawing.Size(64, 24)
Me.Panel70.TabIndex = 172
'
'Label56
'
Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label56.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label56.Location = New System.Drawing.Point(8, 4)
Me.Label56.Name = "Label56"
Me.Label56.Size = New System.Drawing.Size(48, 16)
Me.Label56.TabIndex = 6
Me.Label56.Text = "3"
Me.Label56.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel71
'
Me.Panel71.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel71.Controls.Add(Me.TextBox61)
Me.Panel71.Location = New System.Drawing.Point(896, 352)
Me.Panel71.Name = "Panel71"
Me.Panel71.Size = New System.Drawing.Size(64, 24)
Me.Panel71.TabIndex = 139
'
'TextBox61
'
Me.TextBox61.Location = New System.Drawing.Point(3, 2)
Me.TextBox61.Name = "TextBox61"
Me.TextBox61.ReadOnly = true
Me.TextBox61.Size = New System.Drawing.Size(55, 20)
Me.TextBox61.TabIndex = 8
Me.TextBox61.Text = ""
'
'Panel73
'
Me.Panel73.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel73.Controls.Add(Me.TextBox63)
Me.Panel73.Location = New System.Drawing.Point(832, 304)
Me.Panel73.Name = "Panel73"
Me.Panel73.Size = New System.Drawing.Size(64, 24)
Me.Panel73.TabIndex = 123
'
'TextBox63
'
Me.TextBox63.Location = New System.Drawing.Point(3, 2)
Me.TextBox63.Name = "TextBox63"
Me.TextBox63.Size = New System.Drawing.Size(55, 20)
Me.TextBox63.TabIndex = 8
Me.TextBox63.Text = ""
'
'Panel75
'
Me.Panel75.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel75.Controls.Add(Me.TextBox65)
Me.Panel75.Location = New System.Drawing.Point(832, 352)
Me.Panel75.Name = "Panel75"
Me.Panel75.Size = New System.Drawing.Size(64, 24)
Me.Panel75.TabIndex = 138
'
'TextBox65
'
Me.TextBox65.Location = New System.Drawing.Point(3, 2)
Me.TextBox65.Name = "TextBox65"
Me.TextBox65.ReadOnly = true
Me.TextBox65.Size = New System.Drawing.Size(55, 20)
Me.TextBox65.TabIndex = 8
Me.TextBox65.Text = ""
'
'Panel76
'
Me.Panel76.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel76.Controls.Add(Me.Label69)
Me.Panel76.Location = New System.Drawing.Point(384, 280)
Me.Panel76.Name = "Panel76"
Me.Panel76.Size = New System.Drawing.Size(64, 24)
Me.Panel76.TabIndex = 175
'
'Label69
'
Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label69.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label69.Location = New System.Drawing.Point(8, 4)
Me.Label69.Name = "Label69"
Me.Label69.Size = New System.Drawing.Size(48, 16)
Me.Label69.TabIndex = 6
Me.Label69.Text = "4"
Me.Label69.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel78
'
Me.Panel78.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel78.Controls.Add(Me.Label75)
Me.Panel78.Location = New System.Drawing.Point(448, 280)
Me.Panel78.Name = "Panel78"
Me.Panel78.Size = New System.Drawing.Size(64, 24)
Me.Panel78.TabIndex = 156
'
'Label75
'
Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label75.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label75.Location = New System.Drawing.Point(8, 4)
Me.Label75.Name = "Label75"
Me.Label75.Size = New System.Drawing.Size(48, 16)
Me.Label75.TabIndex = 6
Me.Label75.Text = "5"
Me.Label75.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel79
'
Me.Panel79.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel79.Controls.Add(Me.TextBox67)
Me.Panel79.Location = New System.Drawing.Point(640, 328)
Me.Panel79.Name = "Panel79"
Me.Panel79.Size = New System.Drawing.Size(64, 24)
Me.Panel79.TabIndex = 110
'
'TextBox67
'
Me.TextBox67.Location = New System.Drawing.Point(3, 2)
Me.TextBox67.Name = "TextBox67"
Me.TextBox67.ReadOnly = true
Me.TextBox67.Size = New System.Drawing.Size(55, 20)
Me.TextBox67.TabIndex = 8
Me.TextBox67.Text = ""
'
'Panel93
'
Me.Panel93.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel93.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel93.Controls.Add(Me.TextBox69)
Me.Panel93.Location = New System.Drawing.Point(640, 304)
Me.Panel93.Name = "Panel93"
Me.Panel93.Size = New System.Drawing.Size(64, 24)
Me.Panel93.TabIndex = 124
'
'TextBox69
'
Me.TextBox69.Location = New System.Drawing.Point(3, 2)
Me.TextBox69.Name = "TextBox69"
Me.TextBox69.Size = New System.Drawing.Size(55, 20)
Me.TextBox69.TabIndex = 8
Me.TextBox69.Text = ""
'
'Panel94
'
Me.Panel94.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel94.Controls.Add(Me.Label82)
Me.Panel94.Location = New System.Drawing.Point(512, 280)
Me.Panel94.Name = "Panel94"
Me.Panel94.Size = New System.Drawing.Size(64, 24)
Me.Panel94.TabIndex = 168
'
'Label82
'
Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label82.Location = New System.Drawing.Point(8, 4)
Me.Label82.Name = "Label82"
Me.Label82.Size = New System.Drawing.Size(48, 16)
Me.Label82.TabIndex = 6
Me.Label82.Text = "6"
Me.Label82.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel95
'
Me.Panel95.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel95.Controls.Add(Me.TextBox71)
Me.Panel95.Location = New System.Drawing.Point(192, 304)
Me.Panel95.Name = "Panel95"
Me.Panel95.Size = New System.Drawing.Size(64, 24)
Me.Panel95.TabIndex = 164
'
'TextBox71
'
Me.TextBox71.Location = New System.Drawing.Point(3, 2)
Me.TextBox71.Name = "TextBox71"
Me.TextBox71.Size = New System.Drawing.Size(55, 20)
Me.TextBox71.TabIndex = 8
Me.TextBox71.Text = ""
'
'Panel96
'
Me.Panel96.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel96.Controls.Add(Me.TextBox73)
Me.Panel96.Location = New System.Drawing.Point(256, 304)
Me.Panel96.Name = "Panel96"
Me.Panel96.Size = New System.Drawing.Size(64, 24)
Me.Panel96.TabIndex = 117
'
'TextBox73
'
Me.TextBox73.Location = New System.Drawing.Point(3, 2)
Me.TextBox73.Name = "TextBox73"
Me.TextBox73.Size = New System.Drawing.Size(55, 20)
Me.TextBox73.TabIndex = 8
Me.TextBox73.Text = ""
'
'Panel97
'
Me.Panel97.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel97.Controls.Add(Me.TextBox75)
Me.Panel97.Location = New System.Drawing.Point(704, 304)
Me.Panel97.Name = "Panel97"
Me.Panel97.Size = New System.Drawing.Size(64, 24)
Me.Panel97.TabIndex = 125
'
'TextBox75
'
Me.TextBox75.Location = New System.Drawing.Point(3, 2)
Me.TextBox75.Name = "TextBox75"
Me.TextBox75.Size = New System.Drawing.Size(55, 20)
Me.TextBox75.TabIndex = 8
Me.TextBox75.Text = ""
'
'Panel98
'
Me.Panel98.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel98.Controls.Add(Me.TextBox77)
Me.Panel98.Location = New System.Drawing.Point(320, 304)
Me.Panel98.Name = "Panel98"
Me.Panel98.Size = New System.Drawing.Size(64, 24)
Me.Panel98.TabIndex = 116
'
'TextBox77
'
Me.TextBox77.Location = New System.Drawing.Point(3, 2)
Me.TextBox77.Name = "TextBox77"
Me.TextBox77.Size = New System.Drawing.Size(55, 20)
Me.TextBox77.TabIndex = 8
Me.TextBox77.Text = ""
'
'Panel99
'
Me.Panel99.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel99.Controls.Add(Me.TextBox79)
Me.Panel99.Location = New System.Drawing.Point(384, 304)
Me.Panel99.Name = "Panel99"
Me.Panel99.Size = New System.Drawing.Size(64, 24)
Me.Panel99.TabIndex = 118
'
'TextBox79
'
Me.TextBox79.Location = New System.Drawing.Point(3, 2)
Me.TextBox79.Name = "TextBox79"
Me.TextBox79.Size = New System.Drawing.Size(55, 20)
Me.TextBox79.TabIndex = 8
Me.TextBox79.Text = ""
'
'Panel100
'
Me.Panel100.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel100.Controls.Add(Me.TextBox121)
Me.Panel100.Location = New System.Drawing.Point(896, 304)
Me.Panel100.Name = "Panel100"
Me.Panel100.Size = New System.Drawing.Size(64, 24)
Me.Panel100.TabIndex = 120
'
'TextBox121
'
Me.TextBox121.Location = New System.Drawing.Point(3, 2)
Me.TextBox121.Name = "TextBox121"
Me.TextBox121.Size = New System.Drawing.Size(55, 20)
Me.TextBox121.TabIndex = 8
Me.TextBox121.Text = ""
'
'Panel101
'
Me.Panel101.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel101.Controls.Add(Me.TextBox123)
Me.Panel101.Location = New System.Drawing.Point(448, 304)
Me.Panel101.Name = "Panel101"
Me.Panel101.Size = New System.Drawing.Size(64, 24)
Me.Panel101.TabIndex = 126
'
'TextBox123
'
Me.TextBox123.Location = New System.Drawing.Point(3, 2)
Me.TextBox123.Name = "TextBox123"
Me.TextBox123.Size = New System.Drawing.Size(55, 20)
Me.TextBox123.TabIndex = 8
Me.TextBox123.Text = ""
'
'Panel102
'
Me.Panel102.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel102.Controls.Add(Me.TextBox125)
Me.Panel102.Location = New System.Drawing.Point(256, 328)
Me.Panel102.Name = "Panel102"
Me.Panel102.Size = New System.Drawing.Size(64, 24)
Me.Panel102.TabIndex = 112
'
'TextBox125
'
Me.TextBox125.Location = New System.Drawing.Point(3, 2)
Me.TextBox125.Name = "TextBox125"
Me.TextBox125.ReadOnly = true
Me.TextBox125.Size = New System.Drawing.Size(55, 20)
Me.TextBox125.TabIndex = 8
Me.TextBox125.Text = ""
'
'Panel103
'
Me.Panel103.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel103.Controls.Add(Me.TextBox127)
Me.Panel103.Location = New System.Drawing.Point(512, 304)
Me.Panel103.Name = "Panel103"
Me.Panel103.Size = New System.Drawing.Size(64, 24)
Me.Panel103.TabIndex = 121
'
'TextBox127
'
Me.TextBox127.Location = New System.Drawing.Point(3, 2)
Me.TextBox127.Name = "TextBox127"
Me.TextBox127.Size = New System.Drawing.Size(55, 20)
Me.TextBox127.TabIndex = 8
Me.TextBox127.Text = ""
'
'Panel104
'
Me.Panel104.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel104.Controls.Add(Me.TextBox129)
Me.Panel104.Location = New System.Drawing.Point(512, 328)
Me.Panel104.Name = "Panel104"
Me.Panel104.Size = New System.Drawing.Size(64, 24)
Me.Panel104.TabIndex = 111
'
'TextBox129
'
Me.TextBox129.Location = New System.Drawing.Point(3, 2)
Me.TextBox129.Name = "TextBox129"
Me.TextBox129.ReadOnly = true
Me.TextBox129.Size = New System.Drawing.Size(55, 20)
Me.TextBox129.TabIndex = 8
Me.TextBox129.Text = ""
'
'Panel105
'
Me.Panel105.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel105.Controls.Add(Me.TextBox131)
Me.Panel105.Location = New System.Drawing.Point(576, 304)
Me.Panel105.Name = "Panel105"
Me.Panel105.Size = New System.Drawing.Size(64, 24)
Me.Panel105.TabIndex = 119
'
'TextBox131
'
Me.TextBox131.Location = New System.Drawing.Point(3, 2)
Me.TextBox131.Name = "TextBox131"
Me.TextBox131.Size = New System.Drawing.Size(55, 20)
Me.TextBox131.TabIndex = 8
Me.TextBox131.Text = ""
'
'Panel106
'
Me.Panel106.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel106.Controls.Add(Me.TextBox133)
Me.Panel106.Location = New System.Drawing.Point(384, 328)
Me.Panel106.Name = "Panel106"
Me.Panel106.Size = New System.Drawing.Size(64, 24)
Me.Panel106.TabIndex = 113
'
'TextBox133
'
Me.TextBox133.Location = New System.Drawing.Point(3, 2)
Me.TextBox133.Name = "TextBox133"
Me.TextBox133.ReadOnly = true
Me.TextBox133.Size = New System.Drawing.Size(55, 20)
Me.TextBox133.TabIndex = 8
Me.TextBox133.Text = ""
'
'Panel107
'
Me.Panel107.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel107.Controls.Add(Me.TextBox135)
Me.Panel107.Location = New System.Drawing.Point(576, 328)
Me.Panel107.Name = "Panel107"
Me.Panel107.Size = New System.Drawing.Size(64, 24)
Me.Panel107.TabIndex = 106
'
'TextBox135
'
Me.TextBox135.Location = New System.Drawing.Point(3, 2)
Me.TextBox135.Name = "TextBox135"
Me.TextBox135.ReadOnly = true
Me.TextBox135.Size = New System.Drawing.Size(55, 20)
Me.TextBox135.TabIndex = 8
Me.TextBox135.Text = ""
'
'Panel108
'
Me.Panel108.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel108.Controls.Add(Me.TextBox137)
Me.Panel108.Location = New System.Drawing.Point(448, 328)
Me.Panel108.Name = "Panel108"
Me.Panel108.Size = New System.Drawing.Size(64, 24)
Me.Panel108.TabIndex = 115
'
'TextBox137
'
Me.TextBox137.Location = New System.Drawing.Point(3, 2)
Me.TextBox137.Name = "TextBox137"
Me.TextBox137.ReadOnly = true
Me.TextBox137.Size = New System.Drawing.Size(55, 20)
Me.TextBox137.TabIndex = 8
Me.TextBox137.Text = ""
'
'Panel110
'
Me.Panel110.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel110.Controls.Add(Me.TextBox139)
Me.Panel110.Location = New System.Drawing.Point(192, 328)
Me.Panel110.Name = "Panel110"
Me.Panel110.Size = New System.Drawing.Size(64, 24)
Me.Panel110.TabIndex = 114
'
'TextBox139
'
Me.TextBox139.Location = New System.Drawing.Point(3, 2)
Me.TextBox139.Name = "TextBox139"
Me.TextBox139.ReadOnly = true
Me.TextBox139.Size = New System.Drawing.Size(55, 20)
Me.TextBox139.TabIndex = 8
Me.TextBox139.Text = ""
'
'Panel111
'
Me.Panel111.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel111.Controls.Add(Me.TextBox141)
Me.Panel111.Location = New System.Drawing.Point(768, 352)
Me.Panel111.Name = "Panel111"
Me.Panel111.Size = New System.Drawing.Size(64, 24)
Me.Panel111.TabIndex = 141
'
'TextBox141
'
Me.TextBox141.Location = New System.Drawing.Point(3, 2)
Me.TextBox141.Name = "TextBox141"
Me.TextBox141.ReadOnly = true
Me.TextBox141.Size = New System.Drawing.Size(55, 20)
Me.TextBox141.TabIndex = 8
Me.TextBox141.Text = ""
'
'Panel112
'
Me.Panel112.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel112.Controls.Add(Me.Label85)
Me.Panel112.Location = New System.Drawing.Point(576, 280)
Me.Panel112.Name = "Panel112"
Me.Panel112.Size = New System.Drawing.Size(64, 24)
Me.Panel112.TabIndex = 167
'
'Label85
'
Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label85.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label85.Location = New System.Drawing.Point(8, 4)
Me.Label85.Name = "Label85"
Me.Label85.Size = New System.Drawing.Size(48, 16)
Me.Label85.TabIndex = 6
Me.Label85.Text = "7"
Me.Label85.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel113
'
Me.Panel113.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel113.Controls.Add(Me.TextBox143)
Me.Panel113.Location = New System.Drawing.Point(320, 328)
Me.Panel113.Name = "Panel113"
Me.Panel113.Size = New System.Drawing.Size(64, 24)
Me.Panel113.TabIndex = 127
'
'TextBox143
'
Me.TextBox143.Location = New System.Drawing.Point(3, 2)
Me.TextBox143.Name = "TextBox143"
Me.TextBox143.ReadOnly = true
Me.TextBox143.Size = New System.Drawing.Size(55, 20)
Me.TextBox143.TabIndex = 8
Me.TextBox143.Text = ""
'
'Panel114
'
Me.Panel114.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel114.Controls.Add(Me.TextBox145)
Me.Panel114.Location = New System.Drawing.Point(576, 352)
Me.Panel114.Name = "Panel114"
Me.Panel114.Size = New System.Drawing.Size(64, 24)
Me.Panel114.TabIndex = 136
'
'TextBox145
'
Me.TextBox145.Location = New System.Drawing.Point(3, 2)
Me.TextBox145.Name = "TextBox145"
Me.TextBox145.ReadOnly = true
Me.TextBox145.Size = New System.Drawing.Size(55, 20)
Me.TextBox145.TabIndex = 8
Me.TextBox145.Text = ""
'
'Panel115
'
Me.Panel115.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel115.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel115.Controls.Add(Me.TextBox147)
Me.Panel115.Location = New System.Drawing.Point(384, 352)
Me.Panel115.Name = "Panel115"
Me.Panel115.Size = New System.Drawing.Size(64, 24)
Me.Panel115.TabIndex = 134
'
'TextBox147
'
Me.TextBox147.Location = New System.Drawing.Point(3, 2)
Me.TextBox147.Name = "TextBox147"
Me.TextBox147.ReadOnly = true
Me.TextBox147.Size = New System.Drawing.Size(55, 20)
Me.TextBox147.TabIndex = 8
Me.TextBox147.Text = ""
'
'Panel116
'
Me.Panel116.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel116.Controls.Add(Me.Label86)
Me.Panel116.Location = New System.Drawing.Point(640, 280)
Me.Panel116.Name = "Panel116"
Me.Panel116.Size = New System.Drawing.Size(64, 24)
Me.Panel116.TabIndex = 169
'
'Label86
'
Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label86.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label86.Location = New System.Drawing.Point(8, 4)
Me.Label86.Name = "Label86"
Me.Label86.Size = New System.Drawing.Size(48, 16)
Me.Label86.TabIndex = 6
Me.Label86.Text = "8"
Me.Label86.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel117
'
Me.Panel117.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel117.Controls.Add(Me.TextBox149)
Me.Panel117.Location = New System.Drawing.Point(448, 352)
Me.Panel117.Name = "Panel117"
Me.Panel117.Size = New System.Drawing.Size(64, 24)
Me.Panel117.TabIndex = 133
'
'TextBox149
'
Me.TextBox149.Location = New System.Drawing.Point(3, 2)
Me.TextBox149.Name = "TextBox149"
Me.TextBox149.ReadOnly = true
Me.TextBox149.Size = New System.Drawing.Size(55, 20)
Me.TextBox149.TabIndex = 8
Me.TextBox149.Text = ""
'
'Panel118
'
Me.Panel118.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel118.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel118.Controls.Add(Me.TextBox151)
Me.Panel118.Location = New System.Drawing.Point(512, 352)
Me.Panel118.Name = "Panel118"
Me.Panel118.Size = New System.Drawing.Size(64, 24)
Me.Panel118.TabIndex = 140
'
'TextBox151
'
Me.TextBox151.Location = New System.Drawing.Point(3, 2)
Me.TextBox151.Name = "TextBox151"
Me.TextBox151.ReadOnly = true
Me.TextBox151.Size = New System.Drawing.Size(55, 20)
Me.TextBox151.TabIndex = 8
Me.TextBox151.Text = ""
'
'Panel119
'
Me.Panel119.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel119.Controls.Add(Me.Label87)
Me.Panel119.Location = New System.Drawing.Point(832, 280)
Me.Panel119.Name = "Panel119"
Me.Panel119.Size = New System.Drawing.Size(64, 24)
Me.Panel119.TabIndex = 166
'
'Label87
'
Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label87.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label87.Location = New System.Drawing.Point(8, 4)
Me.Label87.Name = "Label87"
Me.Label87.Size = New System.Drawing.Size(48, 16)
Me.Label87.TabIndex = 6
Me.Label87.Text = "11"
Me.Label87.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel120
'
Me.Panel120.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel120.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel120.Controls.Add(Me.TextBox153)
Me.Panel120.Location = New System.Drawing.Point(256, 352)
Me.Panel120.Name = "Panel120"
Me.Panel120.Size = New System.Drawing.Size(64, 24)
Me.Panel120.TabIndex = 143
'
'TextBox153
'
Me.TextBox153.Location = New System.Drawing.Point(3, 2)
Me.TextBox153.Name = "TextBox153"
Me.TextBox153.ReadOnly = true
Me.TextBox153.Size = New System.Drawing.Size(55, 20)
Me.TextBox153.TabIndex = 8
Me.TextBox153.Text = ""
'
'Panel122
'
Me.Panel122.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel122.Controls.Add(Me.TextBox155)
Me.Panel122.Location = New System.Drawing.Point(192, 352)
Me.Panel122.Name = "Panel122"
Me.Panel122.Size = New System.Drawing.Size(64, 24)
Me.Panel122.TabIndex = 142
'
'TextBox155
'
Me.TextBox155.Location = New System.Drawing.Point(3, 2)
Me.TextBox155.Name = "TextBox155"
Me.TextBox155.ReadOnly = true
Me.TextBox155.Size = New System.Drawing.Size(55, 20)
Me.TextBox155.TabIndex = 8
Me.TextBox155.Text = ""
'
'diagBuses_tab_pressionTroncons
'
Me.diagBuses_tab_pressionTroncons.Controls.Add(Me.TabPage1)
Me.diagBuses_tab_pressionTroncons.Controls.Add(Me.TabPage2)
Me.diagBuses_tab_pressionTroncons.Controls.Add(Me.TabPage8)
Me.diagBuses_tab_pressionTroncons.Controls.Add(Me.TabPage9)
Me.diagBuses_tab_pressionTroncons.Location = New System.Drawing.Point(16, 720)
Me.diagBuses_tab_pressionTroncons.Name = "diagBuses_tab_pressionTroncons"
Me.diagBuses_tab_pressionTroncons.SelectedIndex = 0
Me.diagBuses_tab_pressionTroncons.Size = New System.Drawing.Size(976, 248)
Me.diagBuses_tab_pressionTroncons.TabIndex = 177
'
'TabPage1
'
Me.TabPage1.Controls.Add(Me.Panel12)
Me.TabPage1.Controls.Add(Me.Panel15)
Me.TabPage1.Controls.Add(Me.Panel17)
Me.TabPage1.Controls.Add(Me.Panel19)
Me.TabPage1.Controls.Add(Me.Panel69)
Me.TabPage1.Controls.Add(Me.Panel72)
Me.TabPage1.Controls.Add(Me.Panel74)
Me.TabPage1.Controls.Add(Me.Panel77)
Me.TabPage1.Controls.Add(Me.Panel80)
Me.TabPage1.Controls.Add(Me.Panel81)
Me.TabPage1.Controls.Add(Me.Panel82)
Me.TabPage1.Controls.Add(Me.Panel109)
Me.TabPage1.Controls.Add(Me.Panel121)
Me.TabPage1.Controls.Add(Me.Panel123)
Me.TabPage1.Controls.Add(Me.Panel124)
Me.TabPage1.Controls.Add(Me.Panel125)
Me.TabPage1.Controls.Add(Me.Panel127)
Me.TabPage1.Controls.Add(Me.Panel128)
Me.TabPage1.Controls.Add(Me.Panel129)
Me.TabPage1.Controls.Add(Me.Panel130)
Me.TabPage1.Controls.Add(Me.Panel132)
Me.TabPage1.Controls.Add(Me.Panel133)
Me.TabPage1.Controls.Add(Me.Panel166)
Me.TabPage1.Controls.Add(Me.Panel167)
Me.TabPage1.Controls.Add(Me.Panel168)
Me.TabPage1.Controls.Add(Me.Panel169)
Me.TabPage1.Controls.Add(Me.Panel170)
Me.TabPage1.Controls.Add(Me.Panel171)
Me.TabPage1.Controls.Add(Me.Panel172)
Me.TabPage1.Controls.Add(Me.Panel173)
Me.TabPage1.Controls.Add(Me.Panel174)
Me.TabPage1.Controls.Add(Me.Panel175)
Me.TabPage1.Controls.Add(Me.Panel176)
Me.TabPage1.Controls.Add(Me.Panel177)
Me.TabPage1.Controls.Add(Me.Panel178)
Me.TabPage1.Controls.Add(Me.Panel179)
Me.TabPage1.Controls.Add(Me.Panel180)
Me.TabPage1.Controls.Add(Me.Panel181)
Me.TabPage1.Controls.Add(Me.Panel182)
Me.TabPage1.Controls.Add(Me.Panel183)
Me.TabPage1.Controls.Add(Me.Panel184)
Me.TabPage1.Controls.Add(Me.Panel185)
Me.TabPage1.Controls.Add(Me.Panel186)
Me.TabPage1.Controls.Add(Me.Panel187)
Me.TabPage1.Controls.Add(Me.Panel188)
Me.TabPage1.Controls.Add(Me.Panel189)
Me.TabPage1.Controls.Add(Me.Panel190)
Me.TabPage1.Controls.Add(Me.Panel191)
Me.TabPage1.Controls.Add(Me.Panel192)
Me.TabPage1.Controls.Add(Me.Panel193)
Me.TabPage1.Controls.Add(Me.Panel194)
Me.TabPage1.Controls.Add(Me.Panel195)
Me.TabPage1.Controls.Add(Me.Panel196)
Me.TabPage1.Controls.Add(Me.Panel197)
Me.TabPage1.Controls.Add(Me.Panel198)
Me.TabPage1.Controls.Add(Me.Panel199)
Me.TabPage1.Controls.Add(Me.Panel200)
Me.TabPage1.Controls.Add(Me.Panel201)
Me.TabPage1.Controls.Add(Me.Panel202)
Me.TabPage1.Controls.Add(Me.Panel203)
Me.TabPage1.Controls.Add(Me.Panel204)
Me.TabPage1.Controls.Add(Me.Panel205)
Me.TabPage1.Controls.Add(Me.Panel206)
Me.TabPage1.Controls.Add(Me.Panel207)
Me.TabPage1.Controls.Add(Me.Panel208)
Me.TabPage1.Controls.Add(Me.Panel209)
Me.TabPage1.Controls.Add(Me.Panel210)
Me.TabPage1.Controls.Add(Me.Panel211)
Me.TabPage1.Controls.Add(Me.Panel212)
Me.TabPage1.Controls.Add(Me.Panel213)
Me.TabPage1.Controls.Add(Me.Panel214)
Me.TabPage1.Controls.Add(Me.Panel215)
Me.TabPage1.Location = New System.Drawing.Point(4, 22)
Me.TabPage1.Name = "TabPage1"
Me.TabPage1.Size = New System.Drawing.Size(968, 222)
Me.TabPage1.TabIndex = 0
Me.TabPage1.Text = "5 bar"
'
'Panel12
'
Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel12.Controls.Add(Me.TextBox2)
Me.Panel12.Controls.Add(Me.TextBox8)
Me.Panel12.Location = New System.Drawing.Point(236, 111)
Me.Panel12.Name = "Panel12"
Me.Panel12.Size = New System.Drawing.Size(64, 24)
Me.Panel12.TabIndex = 64
'
'TextBox2
'
Me.TextBox2.Location = New System.Drawing.Point(3, 2)
Me.TextBox2.Name = "TextBox2"
Me.TextBox2.ReadOnly = true
Me.TextBox2.Size = New System.Drawing.Size(29, 20)
Me.TextBox2.TabIndex = 8
Me.TextBox2.Text = ""
'
'TextBox8
'
Me.TextBox8.Location = New System.Drawing.Point(32, 2)
Me.TextBox8.Name = "TextBox8"
Me.TextBox8.ReadOnly = true
Me.TextBox8.Size = New System.Drawing.Size(29, 20)
Me.TextBox8.TabIndex = 7
Me.TextBox8.Text = ""
'
'Panel15
'
Me.Panel15.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel15.Controls.Add(Me.TextBox48)
Me.Panel15.Controls.Add(Me.TextBox52)
Me.Panel15.Location = New System.Drawing.Point(492, 111)
Me.Panel15.Name = "Panel15"
Me.Panel15.Size = New System.Drawing.Size(64, 24)
Me.Panel15.TabIndex = 63
'
'TextBox48
'
Me.TextBox48.Location = New System.Drawing.Point(3, 2)
Me.TextBox48.Name = "TextBox48"
Me.TextBox48.ReadOnly = true
Me.TextBox48.Size = New System.Drawing.Size(29, 20)
Me.TextBox48.TabIndex = 8
Me.TextBox48.Text = ""
'
'TextBox52
'
Me.TextBox52.Location = New System.Drawing.Point(32, 2)
Me.TextBox52.Name = "TextBox52"
Me.TextBox52.ReadOnly = true
Me.TextBox52.Size = New System.Drawing.Size(29, 20)
Me.TextBox52.TabIndex = 7
Me.TextBox52.Text = ""
'
'Panel17
'
Me.Panel17.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel17.Controls.Add(Me.TextBox54)
Me.Panel17.Controls.Add(Me.TextBox56)
Me.Panel17.Location = New System.Drawing.Point(364, 111)
Me.Panel17.Name = "Panel17"
Me.Panel17.Size = New System.Drawing.Size(64, 24)
Me.Panel17.TabIndex = 65
'
'TextBox54
'
Me.TextBox54.Location = New System.Drawing.Point(3, 2)
Me.TextBox54.Name = "TextBox54"
Me.TextBox54.ReadOnly = true
Me.TextBox54.Size = New System.Drawing.Size(29, 20)
Me.TextBox54.TabIndex = 8
Me.TextBox54.Text = ""
'
'TextBox56
'
Me.TextBox56.Location = New System.Drawing.Point(32, 2)
Me.TextBox56.Name = "TextBox56"
Me.TextBox56.ReadOnly = true
Me.TextBox56.Size = New System.Drawing.Size(29, 20)
Me.TextBox56.TabIndex = 7
Me.TextBox56.Text = ""
'
'Panel19
'
Me.Panel19.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel19.Controls.Add(Me.TextBox58)
Me.Panel19.Controls.Add(Me.TextBox60)
Me.Panel19.Location = New System.Drawing.Point(428, 111)
Me.Panel19.Name = "Panel19"
Me.Panel19.Size = New System.Drawing.Size(64, 24)
Me.Panel19.TabIndex = 67
'
'TextBox58
'
Me.TextBox58.Location = New System.Drawing.Point(3, 2)
Me.TextBox58.Name = "TextBox58"
Me.TextBox58.ReadOnly = true
Me.TextBox58.Size = New System.Drawing.Size(29, 20)
Me.TextBox58.TabIndex = 8
Me.TextBox58.Text = ""
'
'TextBox60
'
Me.TextBox60.Location = New System.Drawing.Point(32, 2)
Me.TextBox60.Name = "TextBox60"
Me.TextBox60.ReadOnly = true
Me.TextBox60.Size = New System.Drawing.Size(29, 20)
Me.TextBox60.TabIndex = 7
Me.TextBox60.Text = ""
'
'Panel69
'
Me.Panel69.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel69.Controls.Add(Me.TextBox62)
Me.Panel69.Controls.Add(Me.TextBox64)
Me.Panel69.Location = New System.Drawing.Point(172, 111)
Me.Panel69.Name = "Panel69"
Me.Panel69.Size = New System.Drawing.Size(64, 24)
Me.Panel69.TabIndex = 66
'
'TextBox62
'
Me.TextBox62.Location = New System.Drawing.Point(3, 2)
Me.TextBox62.Name = "TextBox62"
Me.TextBox62.ReadOnly = true
Me.TextBox62.Size = New System.Drawing.Size(29, 20)
Me.TextBox62.TabIndex = 8
Me.TextBox62.Text = ""
'
'TextBox64
'
Me.TextBox64.Location = New System.Drawing.Point(32, 2)
Me.TextBox64.Name = "TextBox64"
Me.TextBox64.ReadOnly = true
Me.TextBox64.Size = New System.Drawing.Size(29, 20)
Me.TextBox64.TabIndex = 7
Me.TextBox64.Text = ""
'
'Panel72
'
Me.Panel72.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel72.Controls.Add(Me.TextBox66)
Me.Panel72.Controls.Add(Me.TextBox68)
Me.Panel72.Location = New System.Drawing.Point(300, 111)
Me.Panel72.Name = "Panel72"
Me.Panel72.Size = New System.Drawing.Size(64, 24)
Me.Panel72.TabIndex = 73
'
'TextBox66
'
Me.TextBox66.Location = New System.Drawing.Point(3, 2)
Me.TextBox66.Name = "TextBox66"
Me.TextBox66.ReadOnly = true
Me.TextBox66.Size = New System.Drawing.Size(29, 20)
Me.TextBox66.TabIndex = 8
Me.TextBox66.Text = ""
'
'TextBox68
'
Me.TextBox68.Location = New System.Drawing.Point(32, 2)
Me.TextBox68.Name = "TextBox68"
Me.TextBox68.ReadOnly = true
Me.TextBox68.Size = New System.Drawing.Size(29, 20)
Me.TextBox68.TabIndex = 7
Me.TextBox68.Text = ""
'
'Panel74
'
Me.Panel74.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel74.Controls.Add(Me.TextBox70)
Me.Panel74.Controls.Add(Me.TextBox72)
Me.Panel74.Location = New System.Drawing.Point(364, 135)
Me.Panel74.Name = "Panel74"
Me.Panel74.Size = New System.Drawing.Size(64, 24)
Me.Panel74.TabIndex = 80
'
'TextBox70
'
Me.TextBox70.Location = New System.Drawing.Point(3, 2)
Me.TextBox70.Name = "TextBox70"
Me.TextBox70.ReadOnly = true
Me.TextBox70.Size = New System.Drawing.Size(29, 20)
Me.TextBox70.TabIndex = 8
Me.TextBox70.Text = ""
'
'TextBox72
'
Me.TextBox72.Location = New System.Drawing.Point(32, 2)
Me.TextBox72.Name = "TextBox72"
Me.TextBox72.ReadOnly = true
Me.TextBox72.Size = New System.Drawing.Size(29, 20)
Me.TextBox72.TabIndex = 7
Me.TextBox72.Text = ""
'
'Panel77
'
Me.Panel77.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel77.Controls.Add(Me.TextBox74)
Me.Panel77.Controls.Add(Me.TextBox76)
Me.Panel77.Location = New System.Drawing.Point(428, 135)
Me.Panel77.Name = "Panel77"
Me.Panel77.Size = New System.Drawing.Size(64, 24)
Me.Panel77.TabIndex = 79
'
'TextBox74
'
Me.TextBox74.Location = New System.Drawing.Point(3, 2)
Me.TextBox74.Name = "TextBox74"
Me.TextBox74.ReadOnly = true
Me.TextBox74.Size = New System.Drawing.Size(29, 20)
Me.TextBox74.TabIndex = 8
Me.TextBox74.Text = ""
'
'TextBox76
'
Me.TextBox76.Location = New System.Drawing.Point(32, 2)
Me.TextBox76.Name = "TextBox76"
Me.TextBox76.ReadOnly = true
Me.TextBox76.Size = New System.Drawing.Size(29, 20)
Me.TextBox76.TabIndex = 7
Me.TextBox76.Text = ""
'
'Panel80
'
Me.Panel80.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel80.Controls.Add(Me.TextBox78)
Me.Panel80.Controls.Add(Me.TextBox80)
Me.Panel80.Location = New System.Drawing.Point(492, 135)
Me.Panel80.Name = "Panel80"
Me.Panel80.Size = New System.Drawing.Size(64, 24)
Me.Panel80.TabIndex = 81
'
'TextBox78
'
Me.TextBox78.Location = New System.Drawing.Point(3, 2)
Me.TextBox78.Name = "TextBox78"
Me.TextBox78.ReadOnly = true
Me.TextBox78.Size = New System.Drawing.Size(29, 20)
Me.TextBox78.TabIndex = 8
Me.TextBox78.Text = ""
'
'TextBox80
'
Me.TextBox80.Location = New System.Drawing.Point(32, 2)
Me.TextBox80.Name = "TextBox80"
Me.TextBox80.ReadOnly = true
Me.TextBox80.Size = New System.Drawing.Size(29, 20)
Me.TextBox80.TabIndex = 7
Me.TextBox80.Text = ""
'
'Panel81
'
Me.Panel81.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel81.Controls.Add(Me.TextBox122)
Me.Panel81.Controls.Add(Me.TextBox124)
Me.Panel81.Location = New System.Drawing.Point(236, 135)
Me.Panel81.Name = "Panel81"
Me.Panel81.Size = New System.Drawing.Size(64, 24)
Me.Panel81.TabIndex = 83
'
'TextBox122
'
Me.TextBox122.Location = New System.Drawing.Point(3, 2)
Me.TextBox122.Name = "TextBox122"
Me.TextBox122.ReadOnly = true
Me.TextBox122.Size = New System.Drawing.Size(29, 20)
Me.TextBox122.TabIndex = 8
Me.TextBox122.Text = ""
'
'TextBox124
'
Me.TextBox124.Location = New System.Drawing.Point(32, 2)
Me.TextBox124.Name = "TextBox124"
Me.TextBox124.ReadOnly = true
Me.TextBox124.Size = New System.Drawing.Size(29, 20)
Me.TextBox124.TabIndex = 7
Me.TextBox124.Text = ""
'
'Panel82
'
Me.Panel82.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel82.Controls.Add(Me.TextBox126)
Me.Panel82.Controls.Add(Me.TextBox128)
Me.Panel82.Location = New System.Drawing.Point(172, 135)
Me.Panel82.Name = "Panel82"
Me.Panel82.Size = New System.Drawing.Size(64, 24)
Me.Panel82.TabIndex = 82
'
'TextBox126
'
Me.TextBox126.Location = New System.Drawing.Point(3, 2)
Me.TextBox126.Name = "TextBox126"
Me.TextBox126.ReadOnly = true
Me.TextBox126.Size = New System.Drawing.Size(29, 20)
Me.TextBox126.TabIndex = 8
Me.TextBox126.Text = ""
'
'TextBox128
'
Me.TextBox128.Location = New System.Drawing.Point(32, 2)
Me.TextBox128.Name = "TextBox128"
Me.TextBox128.ReadOnly = true
Me.TextBox128.Size = New System.Drawing.Size(29, 20)
Me.TextBox128.TabIndex = 7
Me.TextBox128.Text = ""
'
'Panel109
'
Me.Panel109.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel109.Controls.Add(Me.TextBox130)
Me.Panel109.Controls.Add(Me.TextBox132)
Me.Panel109.Location = New System.Drawing.Point(300, 135)
Me.Panel109.Name = "Panel109"
Me.Panel109.Size = New System.Drawing.Size(64, 24)
Me.Panel109.TabIndex = 75
'
'TextBox130
'
Me.TextBox130.Location = New System.Drawing.Point(3, 2)
Me.TextBox130.Name = "TextBox130"
Me.TextBox130.ReadOnly = true
Me.TextBox130.Size = New System.Drawing.Size(29, 20)
Me.TextBox130.TabIndex = 8
Me.TextBox130.Text = ""
'
'TextBox132
'
Me.TextBox132.Location = New System.Drawing.Point(32, 2)
Me.TextBox132.Name = "TextBox132"
Me.TextBox132.ReadOnly = true
Me.TextBox132.Size = New System.Drawing.Size(29, 20)
Me.TextBox132.TabIndex = 7
Me.TextBox132.Text = ""
'
'Panel121
'
Me.Panel121.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel121.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel121.Controls.Add(Me.TextBox134)
Me.Panel121.Location = New System.Drawing.Point(172, 159)
Me.Panel121.Name = "Panel121"
Me.Panel121.Size = New System.Drawing.Size(89, 24)
Me.Panel121.TabIndex = 74
'
'TextBox134
'
Me.TextBox134.Location = New System.Drawing.Point(3, 2)
Me.TextBox134.Name = "TextBox134"
Me.TextBox134.ReadOnly = true
Me.TextBox134.Size = New System.Drawing.Size(83, 20)
Me.TextBox134.TabIndex = 8
Me.TextBox134.Text = ""
'
'Panel123
'
Me.Panel123.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel123.Controls.Add(Me.Label7)
Me.Panel123.Location = New System.Drawing.Point(172, 39)
Me.Panel123.Name = "Panel123"
Me.Panel123.Size = New System.Drawing.Size(64, 24)
Me.Panel123.TabIndex = 88
'
'Label7
'
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label7.Location = New System.Drawing.Point(8, 4)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(48, 16)
Me.Label7.TabIndex = 6
Me.Label7.Text = "1"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel124
'
Me.Panel124.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel124.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel124.Controls.Add(Me.TextBox136)
Me.Panel124.Location = New System.Drawing.Point(172, 183)
Me.Panel124.Name = "Panel124"
Me.Panel124.Size = New System.Drawing.Size(89, 24)
Me.Panel124.TabIndex = 76
'
'TextBox136
'
Me.TextBox136.Location = New System.Drawing.Point(3, 2)
Me.TextBox136.Name = "TextBox136"
Me.TextBox136.ReadOnly = true
Me.TextBox136.Size = New System.Drawing.Size(83, 20)
Me.TextBox136.TabIndex = 8
Me.TextBox136.Text = ""
'
'Panel125
'
Me.Panel125.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel125.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel125.Controls.Add(Me.Label8)
Me.Panel125.Location = New System.Drawing.Point(260, 159)
Me.Panel125.Name = "Panel125"
Me.Panel125.Size = New System.Drawing.Size(177, 48)
Me.Panel125.TabIndex = 78
'
'Label8
'
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label8.Location = New System.Drawing.Point(8, 16)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(160, 16)
Me.Label8.TabIndex = 6
Me.Label8.Text = "Hétérogénité d'alimentation :"
Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel127
'
Me.Panel127.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel127.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel127.Controls.Add(Me.Label14)
Me.Panel127.Controls.Add(Me.Label15)
Me.Panel127.Controls.Add(Me.TextBox138)
Me.Panel127.Controls.Add(Me.TextBox140)
Me.Panel127.Location = New System.Drawing.Point(28, 15)
Me.Panel127.Name = "Panel127"
Me.Panel127.Size = New System.Drawing.Size(912, 24)
Me.Panel127.TabIndex = 90
'
'Label14
'
Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label14.Location = New System.Drawing.Point(8, 4)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(128, 16)
Me.Label14.TabIndex = 6
Me.Label14.Text = "Pression Mano Pulvé :"
Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label15
'
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label15.Location = New System.Drawing.Point(632, 4)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(136, 16)
Me.Label15.TabIndex = 6
Me.Label15.Text = "Moyenne des pressions :"
Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox138
'
Me.TextBox138.Location = New System.Drawing.Point(144, 2)
Me.TextBox138.Name = "TextBox138"
Me.TextBox138.ReadOnly = true
Me.TextBox138.Size = New System.Drawing.Size(83, 20)
Me.TextBox138.TabIndex = 8
Me.TextBox138.Text = "5"
'
'TextBox140
'
Me.TextBox140.Location = New System.Drawing.Point(776, 2)
Me.TextBox140.Name = "TextBox140"
Me.TextBox140.ReadOnly = true
Me.TextBox140.Size = New System.Drawing.Size(83, 20)
Me.TextBox140.TabIndex = 8
Me.TextBox140.Text = ""
'
'Panel128
'
Me.Panel128.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel128.Controls.Add(Me.Label16)
Me.Panel128.Controls.Add(Me.Label27)
Me.Panel128.Location = New System.Drawing.Point(436, 159)
Me.Panel128.Name = "Panel128"
Me.Panel128.Size = New System.Drawing.Size(504, 48)
Me.Panel128.TabIndex = 77
'
'Label16
'
Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label16.Location = New System.Drawing.Point(48, 16)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(168, 16)
Me.Label16.TabIndex = 29
Me.Label16.Text = "OK"
Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label27
'
Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label27.ForeColor = System.Drawing.Color.Red
Me.Label27.Location = New System.Drawing.Point(48, 16)
Me.Label27.Name = "Label27"
Me.Label27.Size = New System.Drawing.Size(168, 16)
Me.Label27.TabIndex = 28
Me.Label27.Text = "DEFAUT"
Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel129
'
Me.Panel129.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel129.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel129.Controls.Add(Me.Label28)
Me.Panel129.Controls.Add(Me.Label29)
Me.Panel129.Location = New System.Drawing.Point(172, 63)
Me.Panel129.Name = "Panel129"
Me.Panel129.Size = New System.Drawing.Size(64, 24)
Me.Panel129.TabIndex = 87
'
'Label28
'
Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label28.Location = New System.Drawing.Point(8, 4)
Me.Label28.Name = "Label28"
Me.Label28.Size = New System.Drawing.Size(24, 16)
Me.Label28.TabIndex = 6
Me.Label28.Text = "G"
Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label29
'
Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label29.Location = New System.Drawing.Point(35, 4)
Me.Label29.Name = "Label29"
Me.Label29.Size = New System.Drawing.Size(24, 16)
Me.Label29.TabIndex = 6
Me.Label29.Text = "D"
Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel130
'
Me.Panel130.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel130.Controls.Add(Me.Label55)
Me.Panel130.Controls.Add(Me.Label57)
Me.Panel130.Location = New System.Drawing.Point(236, 63)
Me.Panel130.Name = "Panel130"
Me.Panel130.Size = New System.Drawing.Size(64, 24)
Me.Panel130.TabIndex = 94
'
'Label55
'
Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label55.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label55.Location = New System.Drawing.Point(8, 4)
Me.Label55.Name = "Label55"
Me.Label55.Size = New System.Drawing.Size(24, 16)
Me.Label55.TabIndex = 6
Me.Label55.Text = "G"
Me.Label55.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label57
'
Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label57.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label57.Location = New System.Drawing.Point(36, 4)
Me.Label57.Name = "Label57"
Me.Label57.Size = New System.Drawing.Size(24, 16)
Me.Label57.TabIndex = 6
Me.Label57.Text = "D"
Me.Label57.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel132
'
Me.Panel132.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel132.Controls.Add(Me.Label58)
Me.Panel132.Location = New System.Drawing.Point(236, 39)
Me.Panel132.Name = "Panel132"
Me.Panel132.Size = New System.Drawing.Size(64, 24)
Me.Panel132.TabIndex = 101
'
'Label58
'
Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label58.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label58.Location = New System.Drawing.Point(8, 4)
Me.Label58.Name = "Label58"
Me.Label58.Size = New System.Drawing.Size(48, 16)
Me.Label58.TabIndex = 6
Me.Label58.Text = "2"
Me.Label58.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel133
'
Me.Panel133.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel133.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel133.Controls.Add(Me.Label59)
Me.Panel133.Location = New System.Drawing.Point(28, 87)
Me.Panel133.Name = "Panel133"
Me.Panel133.Size = New System.Drawing.Size(144, 24)
Me.Panel133.TabIndex = 93
'
'Label59
'
Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label59.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label59.Location = New System.Drawing.Point(8, 4)
Me.Label59.Name = "Label59"
Me.Label59.Size = New System.Drawing.Size(128, 16)
Me.Label59.TabIndex = 6
Me.Label59.Text = "P sortie"
Me.Label59.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel166
'
Me.Panel166.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel166.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel166.Controls.Add(Me.Label60)
Me.Panel166.Location = New System.Drawing.Point(28, 111)
Me.Panel166.Name = "Panel166"
Me.Panel166.Size = New System.Drawing.Size(144, 24)
Me.Panel166.TabIndex = 92
'
'Label60
'
Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label60.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label60.Location = New System.Drawing.Point(8, 4)
Me.Label60.Name = "Label60"
Me.Label60.Size = New System.Drawing.Size(128, 16)
Me.Label60.TabIndex = 6
Me.Label60.Text = "Ecart"
Me.Label60.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel167
'
Me.Panel167.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel167.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel167.Controls.Add(Me.Label70)
Me.Panel167.Location = New System.Drawing.Point(28, 135)
Me.Panel167.Name = "Panel167"
Me.Panel167.Size = New System.Drawing.Size(144, 24)
Me.Panel167.TabIndex = 85
'
'Label70
'
Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label70.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label70.Location = New System.Drawing.Point(8, 4)
Me.Label70.Name = "Label70"
Me.Label70.Size = New System.Drawing.Size(128, 16)
Me.Label70.TabIndex = 6
Me.Label70.Text = "Perte charge"
Me.Label70.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel168
'
Me.Panel168.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel168.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel168.Controls.Add(Me.Label74)
Me.Panel168.Location = New System.Drawing.Point(28, 159)
Me.Panel168.Name = "Panel168"
Me.Panel168.Size = New System.Drawing.Size(144, 24)
Me.Panel168.TabIndex = 84
'
'Label74
'
Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label74.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label74.Location = New System.Drawing.Point(8, 4)
Me.Label74.Name = "Label74"
Me.Label74.Size = New System.Drawing.Size(128, 16)
Me.Label74.TabIndex = 6
Me.Label74.Text = "Perte de charge moy"
Me.Label74.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel169
'
Me.Panel169.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel169.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel169.Controls.Add(Me.Label76)
Me.Panel169.Location = New System.Drawing.Point(28, 183)
Me.Panel169.Name = "Panel169"
Me.Panel169.Size = New System.Drawing.Size(144, 24)
Me.Panel169.TabIndex = 86
'
'Label76
'
Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label76.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label76.Location = New System.Drawing.Point(8, 4)
Me.Label76.Name = "Label76"
Me.Label76.Size = New System.Drawing.Size(128, 16)
Me.Label76.TabIndex = 6
Me.Label76.Text = "Perte de charge max"
Me.Label76.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel170
'
Me.Panel170.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel170.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel170.Controls.Add(Me.Label77)
Me.Panel170.Location = New System.Drawing.Point(28, 39)
Me.Panel170.Name = "Panel170"
Me.Panel170.Size = New System.Drawing.Size(144, 24)
Me.Panel170.TabIndex = 89
'
'Label77
'
Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label77.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label77.Location = New System.Drawing.Point(8, 4)
Me.Label77.Name = "Label77"
Me.Label77.Size = New System.Drawing.Size(128, 16)
Me.Label77.TabIndex = 6
Me.Label77.Text = "Niveau"
Me.Label77.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel171
'
Me.Panel171.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel171.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel171.Controls.Add(Me.Label78)
Me.Panel171.Location = New System.Drawing.Point(28, 63)
Me.Panel171.Name = "Panel171"
Me.Panel171.Size = New System.Drawing.Size(144, 24)
Me.Panel171.TabIndex = 91
'
'Label78
'
Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label78.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label78.Location = New System.Drawing.Point(8, 4)
Me.Label78.Name = "Label78"
Me.Label78.Size = New System.Drawing.Size(128, 16)
Me.Label78.TabIndex = 6
Me.Label78.Text = "Section Gauche/Droite"
Me.Label78.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel172
'
Me.Panel172.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel172.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel172.Controls.Add(Me.Label79)
Me.Panel172.Location = New System.Drawing.Point(300, 39)
Me.Panel172.Name = "Panel172"
Me.Panel172.Size = New System.Drawing.Size(64, 24)
Me.Panel172.TabIndex = 100
'
'Label79
'
Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label79.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label79.Location = New System.Drawing.Point(8, 4)
Me.Label79.Name = "Label79"
Me.Label79.Size = New System.Drawing.Size(48, 16)
Me.Label79.TabIndex = 6
Me.Label79.Text = "3"
Me.Label79.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel173
'
Me.Panel173.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel173.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel173.Controls.Add(Me.Label80)
Me.Panel173.Controls.Add(Me.Label81)
Me.Panel173.Location = New System.Drawing.Point(300, 63)
Me.Panel173.Name = "Panel173"
Me.Panel173.Size = New System.Drawing.Size(64, 24)
Me.Panel173.TabIndex = 102
'
'Label80
'
Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label80.Location = New System.Drawing.Point(8, 4)
Me.Label80.Name = "Label80"
Me.Label80.Size = New System.Drawing.Size(24, 16)
Me.Label80.TabIndex = 6
Me.Label80.Text = "G"
Me.Label80.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label81
'
Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label81.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label81.Location = New System.Drawing.Point(36, 4)
Me.Label81.Name = "Label81"
Me.Label81.Size = New System.Drawing.Size(24, 16)
Me.Label81.TabIndex = 6
Me.Label81.Text = "D"
Me.Label81.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel174
'
Me.Panel174.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel174.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel174.Controls.Add(Me.Label83)
Me.Panel174.Controls.Add(Me.Label84)
Me.Panel174.Location = New System.Drawing.Point(364, 63)
Me.Panel174.Name = "Panel174"
Me.Panel174.Size = New System.Drawing.Size(64, 24)
Me.Panel174.TabIndex = 104
'
'Label83
'
Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label83.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label83.Location = New System.Drawing.Point(8, 4)
Me.Label83.Name = "Label83"
Me.Label83.Size = New System.Drawing.Size(24, 16)
Me.Label83.TabIndex = 6
Me.Label83.Text = "G"
Me.Label83.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label84
'
Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label84.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label84.Location = New System.Drawing.Point(36, 4)
Me.Label84.Name = "Label84"
Me.Label84.Size = New System.Drawing.Size(24, 16)
Me.Label84.TabIndex = 6
Me.Label84.Text = "D"
Me.Label84.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel175
'
Me.Panel175.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel175.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel175.Controls.Add(Me.Label88)
Me.Panel175.Location = New System.Drawing.Point(364, 39)
Me.Panel175.Name = "Panel175"
Me.Panel175.Size = New System.Drawing.Size(64, 24)
Me.Panel175.TabIndex = 103
'
'Label88
'
Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label88.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label88.Location = New System.Drawing.Point(8, 4)
Me.Label88.Name = "Label88"
Me.Label88.Size = New System.Drawing.Size(48, 16)
Me.Label88.TabIndex = 6
Me.Label88.Text = "4"
Me.Label88.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel176
'
Me.Panel176.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel176.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel176.Controls.Add(Me.Label89)
Me.Panel176.Location = New System.Drawing.Point(428, 39)
Me.Panel176.Name = "Panel176"
Me.Panel176.Size = New System.Drawing.Size(64, 24)
Me.Panel176.TabIndex = 96
'
'Label89
'
Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label89.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label89.Location = New System.Drawing.Point(8, 4)
Me.Label89.Name = "Label89"
Me.Label89.Size = New System.Drawing.Size(48, 16)
Me.Label89.TabIndex = 6
Me.Label89.Text = "5"
Me.Label89.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel177
'
Me.Panel177.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel177.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel177.Controls.Add(Me.Label91)
Me.Panel177.Controls.Add(Me.Label92)
Me.Panel177.Location = New System.Drawing.Point(428, 63)
Me.Panel177.Name = "Panel177"
Me.Panel177.Size = New System.Drawing.Size(64, 24)
Me.Panel177.TabIndex = 95
'
'Label91
'
Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label91.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label91.Location = New System.Drawing.Point(8, 4)
Me.Label91.Name = "Label91"
Me.Label91.Size = New System.Drawing.Size(24, 16)
Me.Label91.TabIndex = 6
Me.Label91.Text = "G"
Me.Label91.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label92
'
Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label92.Location = New System.Drawing.Point(36, 4)
Me.Label92.Name = "Label92"
Me.Label92.Size = New System.Drawing.Size(24, 16)
Me.Label92.TabIndex = 6
Me.Label92.Text = "D"
Me.Label92.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel178
'
Me.Panel178.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel178.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel178.Controls.Add(Me.Label93)
Me.Panel178.Controls.Add(Me.Label94)
Me.Panel178.Location = New System.Drawing.Point(492, 63)
Me.Panel178.Name = "Panel178"
Me.Panel178.Size = New System.Drawing.Size(64, 24)
Me.Panel178.TabIndex = 97
'
'Label93
'
Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label93.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label93.Location = New System.Drawing.Point(8, 4)
Me.Label93.Name = "Label93"
Me.Label93.Size = New System.Drawing.Size(24, 16)
Me.Label93.TabIndex = 6
Me.Label93.Text = "G"
Me.Label93.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label94
'
Me.Label94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label94.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label94.Location = New System.Drawing.Point(36, 4)
Me.Label94.Name = "Label94"
Me.Label94.Size = New System.Drawing.Size(24, 16)
Me.Label94.TabIndex = 6
Me.Label94.Text = "D"
Me.Label94.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel179
'
Me.Panel179.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel179.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel179.Controls.Add(Me.Label95)
Me.Panel179.Location = New System.Drawing.Point(492, 39)
Me.Panel179.Name = "Panel179"
Me.Panel179.Size = New System.Drawing.Size(64, 24)
Me.Panel179.TabIndex = 99
'
'Label95
'
Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label95.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label95.Location = New System.Drawing.Point(8, 4)
Me.Label95.Name = "Label95"
Me.Label95.Size = New System.Drawing.Size(48, 16)
Me.Label95.TabIndex = 6
Me.Label95.Text = "6"
Me.Label95.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel180
'
Me.Panel180.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel180.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel180.Controls.Add(Me.TextBox142)
Me.Panel180.Controls.Add(Me.TextBox144)
Me.Panel180.Location = New System.Drawing.Point(172, 87)
Me.Panel180.Name = "Panel180"
Me.Panel180.Size = New System.Drawing.Size(64, 24)
Me.Panel180.TabIndex = 98
'
'TextBox142
'
Me.TextBox142.Location = New System.Drawing.Point(3, 2)
Me.TextBox142.Name = "TextBox142"
Me.TextBox142.Size = New System.Drawing.Size(29, 20)
Me.TextBox142.TabIndex = 8
Me.TextBox142.Text = ""
'
'TextBox144
'
Me.TextBox144.Location = New System.Drawing.Point(32, 2)
Me.TextBox144.Name = "TextBox144"
Me.TextBox144.Size = New System.Drawing.Size(29, 20)
Me.TextBox144.TabIndex = 7
Me.TextBox144.Text = ""
'
'Panel181
'
Me.Panel181.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel181.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel181.Controls.Add(Me.TextBox146)
Me.Panel181.Controls.Add(Me.TextBox148)
Me.Panel181.Location = New System.Drawing.Point(236, 87)
Me.Panel181.Name = "Panel181"
Me.Panel181.Size = New System.Drawing.Size(64, 24)
Me.Panel181.TabIndex = 69
'
'TextBox146
'
Me.TextBox146.Location = New System.Drawing.Point(3, 2)
Me.TextBox146.Name = "TextBox146"
Me.TextBox146.Size = New System.Drawing.Size(29, 20)
Me.TextBox146.TabIndex = 8
Me.TextBox146.Text = ""
'
'TextBox148
'
Me.TextBox148.Location = New System.Drawing.Point(32, 2)
Me.TextBox148.Name = "TextBox148"
Me.TextBox148.Size = New System.Drawing.Size(29, 20)
Me.TextBox148.TabIndex = 7
Me.TextBox148.Text = ""
'
'Panel182
'
Me.Panel182.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel182.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel182.Controls.Add(Me.TextBox150)
Me.Panel182.Controls.Add(Me.TextBox152)
Me.Panel182.Location = New System.Drawing.Point(300, 87)
Me.Panel182.Name = "Panel182"
Me.Panel182.Size = New System.Drawing.Size(64, 24)
Me.Panel182.TabIndex = 68
'
'TextBox150
'
Me.TextBox150.Location = New System.Drawing.Point(3, 2)
Me.TextBox150.Name = "TextBox150"
Me.TextBox150.Size = New System.Drawing.Size(29, 20)
Me.TextBox150.TabIndex = 8
Me.TextBox150.Text = ""
'
'TextBox152
'
Me.TextBox152.Location = New System.Drawing.Point(32, 2)
Me.TextBox152.Name = "TextBox152"
Me.TextBox152.Size = New System.Drawing.Size(29, 20)
Me.TextBox152.TabIndex = 7
Me.TextBox152.Text = ""
'
'Panel183
'
Me.Panel183.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel183.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel183.Controls.Add(Me.TextBox154)
Me.Panel183.Controls.Add(Me.TextBox156)
Me.Panel183.Location = New System.Drawing.Point(364, 87)
Me.Panel183.Name = "Panel183"
Me.Panel183.Size = New System.Drawing.Size(64, 24)
Me.Panel183.TabIndex = 70
'
'TextBox154
'
Me.TextBox154.Location = New System.Drawing.Point(3, 2)
Me.TextBox154.Name = "TextBox154"
Me.TextBox154.Size = New System.Drawing.Size(29, 20)
Me.TextBox154.TabIndex = 8
Me.TextBox154.Text = ""
'
'TextBox156
'
Me.TextBox156.Location = New System.Drawing.Point(32, 2)
Me.TextBox156.Name = "TextBox156"
Me.TextBox156.Size = New System.Drawing.Size(29, 20)
Me.TextBox156.TabIndex = 7
Me.TextBox156.Text = ""
'
'Panel184
'
Me.Panel184.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel184.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel184.Controls.Add(Me.TextBox157)
Me.Panel184.Controls.Add(Me.TextBox158)
Me.Panel184.Location = New System.Drawing.Point(428, 87)
Me.Panel184.Name = "Panel184"
Me.Panel184.Size = New System.Drawing.Size(64, 24)
Me.Panel184.TabIndex = 72
'
'TextBox157
'
Me.TextBox157.Location = New System.Drawing.Point(3, 2)
Me.TextBox157.Name = "TextBox157"
Me.TextBox157.Size = New System.Drawing.Size(29, 20)
Me.TextBox157.TabIndex = 8
Me.TextBox157.Text = ""
'
'TextBox158
'
Me.TextBox158.Location = New System.Drawing.Point(32, 2)
Me.TextBox158.Name = "TextBox158"
Me.TextBox158.Size = New System.Drawing.Size(29, 20)
Me.TextBox158.TabIndex = 7
Me.TextBox158.Text = ""
'
'Panel185
'
Me.Panel185.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel185.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel185.Controls.Add(Me.TextBox159)
Me.Panel185.Controls.Add(Me.TextBox160)
Me.Panel185.Location = New System.Drawing.Point(492, 87)
Me.Panel185.Name = "Panel185"
Me.Panel185.Size = New System.Drawing.Size(64, 24)
Me.Panel185.TabIndex = 71
'
'TextBox159
'
Me.TextBox159.Location = New System.Drawing.Point(3, 2)
Me.TextBox159.Name = "TextBox159"
Me.TextBox159.Size = New System.Drawing.Size(29, 20)
Me.TextBox159.TabIndex = 8
Me.TextBox159.Text = ""
'
'TextBox160
'
Me.TextBox160.Location = New System.Drawing.Point(32, 2)
Me.TextBox160.Name = "TextBox160"
Me.TextBox160.Size = New System.Drawing.Size(29, 20)
Me.TextBox160.TabIndex = 7
Me.TextBox160.Text = ""
'
'Panel186
'
Me.Panel186.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel186.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel186.Controls.Add(Me.TextBox161)
Me.Panel186.Controls.Add(Me.TextBox162)
Me.Panel186.Location = New System.Drawing.Point(556, 87)
Me.Panel186.Name = "Panel186"
Me.Panel186.Size = New System.Drawing.Size(64, 24)
Me.Panel186.TabIndex = 71
'
'TextBox161
'
Me.TextBox161.Location = New System.Drawing.Point(3, 2)
Me.TextBox161.Name = "TextBox161"
Me.TextBox161.Size = New System.Drawing.Size(29, 20)
Me.TextBox161.TabIndex = 8
Me.TextBox161.Text = ""
'
'TextBox162
'
Me.TextBox162.Location = New System.Drawing.Point(32, 2)
Me.TextBox162.Name = "TextBox162"
Me.TextBox162.Size = New System.Drawing.Size(29, 20)
Me.TextBox162.TabIndex = 7
Me.TextBox162.Text = ""
'
'Panel187
'
Me.Panel187.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel187.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel187.Controls.Add(Me.TextBox163)
Me.Panel187.Controls.Add(Me.TextBox164)
Me.Panel187.Location = New System.Drawing.Point(556, 111)
Me.Panel187.Name = "Panel187"
Me.Panel187.Size = New System.Drawing.Size(64, 24)
Me.Panel187.TabIndex = 63
'
'TextBox163
'
Me.TextBox163.Location = New System.Drawing.Point(3, 2)
Me.TextBox163.Name = "TextBox163"
Me.TextBox163.ReadOnly = true
Me.TextBox163.Size = New System.Drawing.Size(29, 20)
Me.TextBox163.TabIndex = 8
Me.TextBox163.Text = ""
'
'TextBox164
'
Me.TextBox164.Location = New System.Drawing.Point(32, 2)
Me.TextBox164.Name = "TextBox164"
Me.TextBox164.ReadOnly = true
Me.TextBox164.Size = New System.Drawing.Size(29, 20)
Me.TextBox164.TabIndex = 7
Me.TextBox164.Text = ""
'
'Panel188
'
Me.Panel188.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel188.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel188.Controls.Add(Me.Label96)
Me.Panel188.Controls.Add(Me.Label97)
Me.Panel188.Location = New System.Drawing.Point(556, 63)
Me.Panel188.Name = "Panel188"
Me.Panel188.Size = New System.Drawing.Size(64, 24)
Me.Panel188.TabIndex = 97
'
'Label96
'
Me.Label96.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label96.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label96.Location = New System.Drawing.Point(8, 4)
Me.Label96.Name = "Label96"
Me.Label96.Size = New System.Drawing.Size(24, 16)
Me.Label96.TabIndex = 6
Me.Label96.Text = "G"
Me.Label96.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label97
'
Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label97.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label97.Location = New System.Drawing.Point(36, 4)
Me.Label97.Name = "Label97"
Me.Label97.Size = New System.Drawing.Size(24, 16)
Me.Label97.TabIndex = 6
Me.Label97.Text = "D"
Me.Label97.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel189
'
Me.Panel189.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel189.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel189.Controls.Add(Me.Label98)
Me.Panel189.Location = New System.Drawing.Point(556, 39)
Me.Panel189.Name = "Panel189"
Me.Panel189.Size = New System.Drawing.Size(64, 24)
Me.Panel189.TabIndex = 99
'
'Label98
'
Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label98.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label98.Location = New System.Drawing.Point(8, 4)
Me.Label98.Name = "Label98"
Me.Label98.Size = New System.Drawing.Size(48, 16)
Me.Label98.TabIndex = 6
Me.Label98.Text = "7"
Me.Label98.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel190
'
Me.Panel190.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel190.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel190.Controls.Add(Me.TextBox165)
Me.Panel190.Controls.Add(Me.TextBox166)
Me.Panel190.Location = New System.Drawing.Point(556, 135)
Me.Panel190.Name = "Panel190"
Me.Panel190.Size = New System.Drawing.Size(64, 24)
Me.Panel190.TabIndex = 81
'
'TextBox165
'
Me.TextBox165.Location = New System.Drawing.Point(3, 2)
Me.TextBox165.Name = "TextBox165"
Me.TextBox165.ReadOnly = true
Me.TextBox165.Size = New System.Drawing.Size(29, 20)
Me.TextBox165.TabIndex = 8
Me.TextBox165.Text = ""
'
'TextBox166
'
Me.TextBox166.Location = New System.Drawing.Point(32, 2)
Me.TextBox166.Name = "TextBox166"
Me.TextBox166.ReadOnly = true
Me.TextBox166.Size = New System.Drawing.Size(29, 20)
Me.TextBox166.TabIndex = 7
Me.TextBox166.Text = ""
'
'Panel191
'
Me.Panel191.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel191.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel191.Controls.Add(Me.Label99)
Me.Panel191.Location = New System.Drawing.Point(620, 39)
Me.Panel191.Name = "Panel191"
Me.Panel191.Size = New System.Drawing.Size(64, 24)
Me.Panel191.TabIndex = 99
'
'Label99
'
Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label99.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label99.Location = New System.Drawing.Point(8, 4)
Me.Label99.Name = "Label99"
Me.Label99.Size = New System.Drawing.Size(48, 16)
Me.Label99.TabIndex = 6
Me.Label99.Text = "8"
Me.Label99.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel192
'
Me.Panel192.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel192.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel192.Controls.Add(Me.TextBox167)
Me.Panel192.Controls.Add(Me.TextBox168)
Me.Panel192.Location = New System.Drawing.Point(620, 135)
Me.Panel192.Name = "Panel192"
Me.Panel192.Size = New System.Drawing.Size(64, 24)
Me.Panel192.TabIndex = 81
'
'TextBox167
'
Me.TextBox167.Location = New System.Drawing.Point(3, 2)
Me.TextBox167.Name = "TextBox167"
Me.TextBox167.ReadOnly = true
Me.TextBox167.Size = New System.Drawing.Size(29, 20)
Me.TextBox167.TabIndex = 8
Me.TextBox167.Text = ""
'
'TextBox168
'
Me.TextBox168.Location = New System.Drawing.Point(32, 2)
Me.TextBox168.Name = "TextBox168"
Me.TextBox168.ReadOnly = true
Me.TextBox168.Size = New System.Drawing.Size(29, 20)
Me.TextBox168.TabIndex = 7
Me.TextBox168.Text = ""
'
'Panel193
'
Me.Panel193.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel193.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel193.Controls.Add(Me.TextBox169)
Me.Panel193.Controls.Add(Me.TextBox170)
Me.Panel193.Location = New System.Drawing.Point(620, 111)
Me.Panel193.Name = "Panel193"
Me.Panel193.Size = New System.Drawing.Size(64, 24)
Me.Panel193.TabIndex = 63
'
'TextBox169
'
Me.TextBox169.Location = New System.Drawing.Point(3, 2)
Me.TextBox169.Name = "TextBox169"
Me.TextBox169.ReadOnly = true
Me.TextBox169.Size = New System.Drawing.Size(29, 20)
Me.TextBox169.TabIndex = 8
Me.TextBox169.Text = ""
'
'TextBox170
'
Me.TextBox170.Location = New System.Drawing.Point(32, 2)
Me.TextBox170.Name = "TextBox170"
Me.TextBox170.ReadOnly = true
Me.TextBox170.Size = New System.Drawing.Size(29, 20)
Me.TextBox170.TabIndex = 7
Me.TextBox170.Text = ""
'
'Panel194
'
Me.Panel194.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel194.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel194.Controls.Add(Me.Label100)
Me.Panel194.Controls.Add(Me.Label101)
Me.Panel194.Location = New System.Drawing.Point(620, 63)
Me.Panel194.Name = "Panel194"
Me.Panel194.Size = New System.Drawing.Size(64, 24)
Me.Panel194.TabIndex = 97
'
'Label100
'
Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label100.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label100.Location = New System.Drawing.Point(8, 4)
Me.Label100.Name = "Label100"
Me.Label100.Size = New System.Drawing.Size(24, 16)
Me.Label100.TabIndex = 6
Me.Label100.Text = "G"
Me.Label100.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label101
'
Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label101.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label101.Location = New System.Drawing.Point(34, 4)
Me.Label101.Name = "Label101"
Me.Label101.Size = New System.Drawing.Size(24, 16)
Me.Label101.TabIndex = 6
Me.Label101.Text = "D"
Me.Label101.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel195
'
Me.Panel195.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel195.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel195.Controls.Add(Me.TextBox171)
Me.Panel195.Controls.Add(Me.TextBox172)
Me.Panel195.Location = New System.Drawing.Point(620, 87)
Me.Panel195.Name = "Panel195"
Me.Panel195.Size = New System.Drawing.Size(64, 24)
Me.Panel195.TabIndex = 71
'
'TextBox171
'
Me.TextBox171.Location = New System.Drawing.Point(3, 2)
Me.TextBox171.Name = "TextBox171"
Me.TextBox171.Size = New System.Drawing.Size(29, 20)
Me.TextBox171.TabIndex = 8
Me.TextBox171.Text = ""
'
'TextBox172
'
Me.TextBox172.Location = New System.Drawing.Point(32, 2)
Me.TextBox172.Name = "TextBox172"
Me.TextBox172.Size = New System.Drawing.Size(29, 20)
Me.TextBox172.TabIndex = 7
Me.TextBox172.Text = ""
'
'Panel196
'
Me.Panel196.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel196.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel196.Controls.Add(Me.Label102)
Me.Panel196.Controls.Add(Me.Label122)
Me.Panel196.Location = New System.Drawing.Point(684, 63)
Me.Panel196.Name = "Panel196"
Me.Panel196.Size = New System.Drawing.Size(64, 24)
Me.Panel196.TabIndex = 97
'
'Label102
'
Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label102.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label102.Location = New System.Drawing.Point(8, 4)
Me.Label102.Name = "Label102"
Me.Label102.Size = New System.Drawing.Size(24, 16)
Me.Label102.TabIndex = 6
Me.Label102.Text = "G"
Me.Label102.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label122
'
Me.Label122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label122.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label122.Location = New System.Drawing.Point(35, 4)
Me.Label122.Name = "Label122"
Me.Label122.Size = New System.Drawing.Size(24, 16)
Me.Label122.TabIndex = 6
Me.Label122.Text = "D"
Me.Label122.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel197
'
Me.Panel197.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel197.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel197.Controls.Add(Me.TextBox173)
Me.Panel197.Controls.Add(Me.TextBox174)
Me.Panel197.Location = New System.Drawing.Point(684, 87)
Me.Panel197.Name = "Panel197"
Me.Panel197.Size = New System.Drawing.Size(64, 24)
Me.Panel197.TabIndex = 71
'
'TextBox173
'
Me.TextBox173.Location = New System.Drawing.Point(3, 2)
Me.TextBox173.Name = "TextBox173"
Me.TextBox173.Size = New System.Drawing.Size(29, 20)
Me.TextBox173.TabIndex = 8
Me.TextBox173.Text = ""
'
'TextBox174
'
Me.TextBox174.Location = New System.Drawing.Point(32, 2)
Me.TextBox174.Name = "TextBox174"
Me.TextBox174.Size = New System.Drawing.Size(29, 20)
Me.TextBox174.TabIndex = 7
Me.TextBox174.Text = ""
'
'Panel198
'
Me.Panel198.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel198.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel198.Controls.Add(Me.Label123)
Me.Panel198.Location = New System.Drawing.Point(684, 39)
Me.Panel198.Name = "Panel198"
Me.Panel198.Size = New System.Drawing.Size(64, 24)
Me.Panel198.TabIndex = 99
'
'Label123
'
Me.Label123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label123.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label123.Location = New System.Drawing.Point(8, 4)
Me.Label123.Name = "Label123"
Me.Label123.Size = New System.Drawing.Size(48, 16)
Me.Label123.TabIndex = 6
Me.Label123.Text = "9"
Me.Label123.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel199
'
Me.Panel199.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel199.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel199.Controls.Add(Me.TextBox175)
Me.Panel199.Controls.Add(Me.TextBox176)
Me.Panel199.Location = New System.Drawing.Point(684, 135)
Me.Panel199.Name = "Panel199"
Me.Panel199.Size = New System.Drawing.Size(64, 24)
Me.Panel199.TabIndex = 81
'
'TextBox175
'
Me.TextBox175.Location = New System.Drawing.Point(3, 2)
Me.TextBox175.Name = "TextBox175"
Me.TextBox175.ReadOnly = true
Me.TextBox175.Size = New System.Drawing.Size(29, 20)
Me.TextBox175.TabIndex = 8
Me.TextBox175.Text = ""
'
'TextBox176
'
Me.TextBox176.Location = New System.Drawing.Point(32, 2)
Me.TextBox176.Name = "TextBox176"
Me.TextBox176.ReadOnly = true
Me.TextBox176.Size = New System.Drawing.Size(29, 20)
Me.TextBox176.TabIndex = 7
Me.TextBox176.Text = ""
'
'Panel200
'
Me.Panel200.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel200.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel200.Controls.Add(Me.TextBox177)
Me.Panel200.Controls.Add(Me.TextBox178)
Me.Panel200.Location = New System.Drawing.Point(684, 111)
Me.Panel200.Name = "Panel200"
Me.Panel200.Size = New System.Drawing.Size(64, 24)
Me.Panel200.TabIndex = 63
'
'TextBox177
'
Me.TextBox177.Location = New System.Drawing.Point(3, 2)
Me.TextBox177.Name = "TextBox177"
Me.TextBox177.ReadOnly = true
Me.TextBox177.Size = New System.Drawing.Size(29, 20)
Me.TextBox177.TabIndex = 8
Me.TextBox177.Text = ""
'
'TextBox178
'
Me.TextBox178.Location = New System.Drawing.Point(32, 2)
Me.TextBox178.Name = "TextBox178"
Me.TextBox178.ReadOnly = true
Me.TextBox178.Size = New System.Drawing.Size(29, 20)
Me.TextBox178.TabIndex = 7
Me.TextBox178.Text = ""
'
'Panel201
'
Me.Panel201.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel201.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel201.Controls.Add(Me.TextBox179)
Me.Panel201.Controls.Add(Me.TextBox180)
Me.Panel201.Location = New System.Drawing.Point(748, 111)
Me.Panel201.Name = "Panel201"
Me.Panel201.Size = New System.Drawing.Size(64, 24)
Me.Panel201.TabIndex = 63
'
'TextBox179
'
Me.TextBox179.Location = New System.Drawing.Point(3, 2)
Me.TextBox179.Name = "TextBox179"
Me.TextBox179.ReadOnly = true
Me.TextBox179.Size = New System.Drawing.Size(29, 20)
Me.TextBox179.TabIndex = 8
Me.TextBox179.Text = ""
'
'TextBox180
'
Me.TextBox180.Location = New System.Drawing.Point(32, 2)
Me.TextBox180.Name = "TextBox180"
Me.TextBox180.ReadOnly = true
Me.TextBox180.Size = New System.Drawing.Size(29, 20)
Me.TextBox180.TabIndex = 7
Me.TextBox180.Text = ""
'
'Panel202
'
Me.Panel202.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel202.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel202.Controls.Add(Me.Label124)
Me.Panel202.Controls.Add(Me.Label125)
Me.Panel202.Location = New System.Drawing.Point(748, 63)
Me.Panel202.Name = "Panel202"
Me.Panel202.Size = New System.Drawing.Size(64, 24)
Me.Panel202.TabIndex = 97
'
'Label124
'
Me.Label124.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label124.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label124.Location = New System.Drawing.Point(8, 4)
Me.Label124.Name = "Label124"
Me.Label124.Size = New System.Drawing.Size(24, 16)
Me.Label124.TabIndex = 6
Me.Label124.Text = "G"
Me.Label124.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label125
'
Me.Label125.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label125.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label125.Location = New System.Drawing.Point(35, 4)
Me.Label125.Name = "Label125"
Me.Label125.Size = New System.Drawing.Size(24, 16)
Me.Label125.TabIndex = 6
Me.Label125.Text = "D"
Me.Label125.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel203
'
Me.Panel203.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel203.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel203.Controls.Add(Me.TextBox181)
Me.Panel203.Controls.Add(Me.TextBox182)
Me.Panel203.Location = New System.Drawing.Point(748, 87)
Me.Panel203.Name = "Panel203"
Me.Panel203.Size = New System.Drawing.Size(64, 24)
Me.Panel203.TabIndex = 71
'
'TextBox181
'
Me.TextBox181.Location = New System.Drawing.Point(3, 2)
Me.TextBox181.Name = "TextBox181"
Me.TextBox181.Size = New System.Drawing.Size(29, 20)
Me.TextBox181.TabIndex = 8
Me.TextBox181.Text = ""
'
'TextBox182
'
Me.TextBox182.Location = New System.Drawing.Point(32, 2)
Me.TextBox182.Name = "TextBox182"
Me.TextBox182.Size = New System.Drawing.Size(29, 20)
Me.TextBox182.TabIndex = 7
Me.TextBox182.Text = ""
'
'Panel204
'
Me.Panel204.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel204.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel204.Controls.Add(Me.Label126)
Me.Panel204.Location = New System.Drawing.Point(748, 39)
Me.Panel204.Name = "Panel204"
Me.Panel204.Size = New System.Drawing.Size(64, 24)
Me.Panel204.TabIndex = 99
'
'Label126
'
Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label126.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label126.Location = New System.Drawing.Point(8, 4)
Me.Label126.Name = "Label126"
Me.Label126.Size = New System.Drawing.Size(48, 16)
Me.Label126.TabIndex = 6
Me.Label126.Text = "10"
Me.Label126.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel205
'
Me.Panel205.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel205.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel205.Controls.Add(Me.TextBox183)
Me.Panel205.Controls.Add(Me.TextBox184)
Me.Panel205.Location = New System.Drawing.Point(748, 135)
Me.Panel205.Name = "Panel205"
Me.Panel205.Size = New System.Drawing.Size(64, 24)
Me.Panel205.TabIndex = 81
'
'TextBox183
'
Me.TextBox183.Location = New System.Drawing.Point(3, 2)
Me.TextBox183.Name = "TextBox183"
Me.TextBox183.ReadOnly = true
Me.TextBox183.Size = New System.Drawing.Size(29, 20)
Me.TextBox183.TabIndex = 8
Me.TextBox183.Text = ""
'
'TextBox184
'
Me.TextBox184.Location = New System.Drawing.Point(32, 2)
Me.TextBox184.Name = "TextBox184"
Me.TextBox184.ReadOnly = true
Me.TextBox184.Size = New System.Drawing.Size(29, 20)
Me.TextBox184.TabIndex = 7
Me.TextBox184.Text = ""
'
'Panel206
'
Me.Panel206.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel206.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel206.Controls.Add(Me.TextBox185)
Me.Panel206.Controls.Add(Me.TextBox186)
Me.Panel206.Location = New System.Drawing.Point(812, 87)
Me.Panel206.Name = "Panel206"
Me.Panel206.Size = New System.Drawing.Size(64, 24)
Me.Panel206.TabIndex = 71
'
'TextBox185
'
Me.TextBox185.Location = New System.Drawing.Point(3, 2)
Me.TextBox185.Name = "TextBox185"
Me.TextBox185.Size = New System.Drawing.Size(29, 20)
Me.TextBox185.TabIndex = 8
Me.TextBox185.Text = ""
'
'TextBox186
'
Me.TextBox186.Location = New System.Drawing.Point(32, 2)
Me.TextBox186.Name = "TextBox186"
Me.TextBox186.Size = New System.Drawing.Size(29, 20)
Me.TextBox186.TabIndex = 7
Me.TextBox186.Text = ""
'
'Panel207
'
Me.Panel207.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel207.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel207.Controls.Add(Me.TextBox187)
Me.Panel207.Controls.Add(Me.TextBox188)
Me.Panel207.Location = New System.Drawing.Point(812, 135)
Me.Panel207.Name = "Panel207"
Me.Panel207.Size = New System.Drawing.Size(64, 24)
Me.Panel207.TabIndex = 81
'
'TextBox187
'
Me.TextBox187.Location = New System.Drawing.Point(3, 2)
Me.TextBox187.Name = "TextBox187"
Me.TextBox187.ReadOnly = true
Me.TextBox187.Size = New System.Drawing.Size(29, 20)
Me.TextBox187.TabIndex = 8
Me.TextBox187.Text = ""
'
'TextBox188
'
Me.TextBox188.Location = New System.Drawing.Point(32, 2)
Me.TextBox188.Name = "TextBox188"
Me.TextBox188.ReadOnly = true
Me.TextBox188.Size = New System.Drawing.Size(29, 20)
Me.TextBox188.TabIndex = 7
Me.TextBox188.Text = ""
'
'Panel208
'
Me.Panel208.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel208.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel208.Controls.Add(Me.TextBox189)
Me.Panel208.Controls.Add(Me.TextBox190)
Me.Panel208.Location = New System.Drawing.Point(812, 111)
Me.Panel208.Name = "Panel208"
Me.Panel208.Size = New System.Drawing.Size(64, 24)
Me.Panel208.TabIndex = 63
'
'TextBox189
'
Me.TextBox189.Location = New System.Drawing.Point(3, 2)
Me.TextBox189.Name = "TextBox189"
Me.TextBox189.ReadOnly = true
Me.TextBox189.Size = New System.Drawing.Size(29, 20)
Me.TextBox189.TabIndex = 8
Me.TextBox189.Text = ""
'
'TextBox190
'
Me.TextBox190.Location = New System.Drawing.Point(32, 2)
Me.TextBox190.Name = "TextBox190"
Me.TextBox190.ReadOnly = true
Me.TextBox190.Size = New System.Drawing.Size(29, 20)
Me.TextBox190.TabIndex = 7
Me.TextBox190.Text = ""
'
'Panel209
'
Me.Panel209.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel209.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel209.Controls.Add(Me.Label127)
Me.Panel209.Location = New System.Drawing.Point(812, 39)
Me.Panel209.Name = "Panel209"
Me.Panel209.Size = New System.Drawing.Size(64, 24)
Me.Panel209.TabIndex = 99
'
'Label127
'
Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label127.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label127.Location = New System.Drawing.Point(8, 4)
Me.Label127.Name = "Label127"
Me.Label127.Size = New System.Drawing.Size(48, 16)
Me.Label127.TabIndex = 6
Me.Label127.Text = "11"
Me.Label127.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel210
'
Me.Panel210.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel210.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel210.Controls.Add(Me.Label128)
Me.Panel210.Controls.Add(Me.Label129)
Me.Panel210.Location = New System.Drawing.Point(812, 63)
Me.Panel210.Name = "Panel210"
Me.Panel210.Size = New System.Drawing.Size(64, 24)
Me.Panel210.TabIndex = 97
'
'Label128
'
Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label128.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label128.Location = New System.Drawing.Point(8, 4)
Me.Label128.Name = "Label128"
Me.Label128.Size = New System.Drawing.Size(24, 16)
Me.Label128.TabIndex = 6
Me.Label128.Text = "G"
Me.Label128.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label129
'
Me.Label129.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label129.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label129.Location = New System.Drawing.Point(35, 4)
Me.Label129.Name = "Label129"
Me.Label129.Size = New System.Drawing.Size(24, 16)
Me.Label129.TabIndex = 6
Me.Label129.Text = "D"
Me.Label129.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel211
'
Me.Panel211.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel211.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel211.Controls.Add(Me.TextBox191)
Me.Panel211.Controls.Add(Me.TextBox192)
Me.Panel211.Location = New System.Drawing.Point(876, 135)
Me.Panel211.Name = "Panel211"
Me.Panel211.Size = New System.Drawing.Size(64, 24)
Me.Panel211.TabIndex = 81
'
'TextBox191
'
Me.TextBox191.Location = New System.Drawing.Point(3, 2)
Me.TextBox191.Name = "TextBox191"
Me.TextBox191.ReadOnly = true
Me.TextBox191.Size = New System.Drawing.Size(29, 20)
Me.TextBox191.TabIndex = 8
Me.TextBox191.Text = ""
'
'TextBox192
'
Me.TextBox192.Location = New System.Drawing.Point(32, 2)
Me.TextBox192.Name = "TextBox192"
Me.TextBox192.ReadOnly = true
Me.TextBox192.Size = New System.Drawing.Size(29, 20)
Me.TextBox192.TabIndex = 7
Me.TextBox192.Text = ""
'
'Panel212
'
Me.Panel212.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel212.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel212.Controls.Add(Me.TextBox193)
Me.Panel212.Controls.Add(Me.TextBox194)
Me.Panel212.Location = New System.Drawing.Point(876, 111)
Me.Panel212.Name = "Panel212"
Me.Panel212.Size = New System.Drawing.Size(64, 24)
Me.Panel212.TabIndex = 63
'
'TextBox193
'
Me.TextBox193.Location = New System.Drawing.Point(3, 2)
Me.TextBox193.Name = "TextBox193"
Me.TextBox193.ReadOnly = true
Me.TextBox193.Size = New System.Drawing.Size(29, 20)
Me.TextBox193.TabIndex = 8
Me.TextBox193.Text = ""
'
'TextBox194
'
Me.TextBox194.Location = New System.Drawing.Point(32, 2)
Me.TextBox194.Name = "TextBox194"
Me.TextBox194.ReadOnly = true
Me.TextBox194.Size = New System.Drawing.Size(29, 20)
Me.TextBox194.TabIndex = 7
Me.TextBox194.Text = ""
'
'Panel213
'
Me.Panel213.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel213.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel213.Controls.Add(Me.Label130)
Me.Panel213.Location = New System.Drawing.Point(876, 39)
Me.Panel213.Name = "Panel213"
Me.Panel213.Size = New System.Drawing.Size(64, 24)
Me.Panel213.TabIndex = 99
'
'Label130
'
Me.Label130.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label130.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label130.Location = New System.Drawing.Point(8, 4)
Me.Label130.Name = "Label130"
Me.Label130.Size = New System.Drawing.Size(48, 16)
Me.Label130.TabIndex = 6
Me.Label130.Text = "12"
Me.Label130.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel214
'
Me.Panel214.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel214.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel214.Controls.Add(Me.Label131)
Me.Panel214.Controls.Add(Me.Label132)
Me.Panel214.Location = New System.Drawing.Point(876, 63)
Me.Panel214.Name = "Panel214"
Me.Panel214.Size = New System.Drawing.Size(64, 24)
Me.Panel214.TabIndex = 97
'
'Label131
'
Me.Label131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label131.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label131.Location = New System.Drawing.Point(8, 4)
Me.Label131.Name = "Label131"
Me.Label131.Size = New System.Drawing.Size(24, 16)
Me.Label131.TabIndex = 6
Me.Label131.Text = "G"
Me.Label131.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label132
'
Me.Label132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label132.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label132.Location = New System.Drawing.Point(35, 4)
Me.Label132.Name = "Label132"
Me.Label132.Size = New System.Drawing.Size(24, 16)
Me.Label132.TabIndex = 6
Me.Label132.Text = "D"
Me.Label132.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel215
'
Me.Panel215.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel215.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel215.Controls.Add(Me.TextBox195)
Me.Panel215.Controls.Add(Me.TextBox196)
Me.Panel215.Location = New System.Drawing.Point(876, 87)
Me.Panel215.Name = "Panel215"
Me.Panel215.Size = New System.Drawing.Size(64, 24)
Me.Panel215.TabIndex = 71
'
'TextBox195
'
Me.TextBox195.Location = New System.Drawing.Point(3, 2)
Me.TextBox195.Name = "TextBox195"
Me.TextBox195.Size = New System.Drawing.Size(29, 20)
Me.TextBox195.TabIndex = 8
Me.TextBox195.Text = ""
'
'TextBox196
'
Me.TextBox196.Location = New System.Drawing.Point(32, 2)
Me.TextBox196.Name = "TextBox196"
Me.TextBox196.Size = New System.Drawing.Size(29, 20)
Me.TextBox196.TabIndex = 7
Me.TextBox196.Text = ""
'
'TabPage2
'
Me.TabPage2.Controls.Add(Me.Panel216)
Me.TabPage2.Controls.Add(Me.Panel217)
Me.TabPage2.Controls.Add(Me.Panel218)
Me.TabPage2.Controls.Add(Me.Panel219)
Me.TabPage2.Controls.Add(Me.Panel220)
Me.TabPage2.Controls.Add(Me.Panel221)
Me.TabPage2.Controls.Add(Me.Panel222)
Me.TabPage2.Controls.Add(Me.Panel223)
Me.TabPage2.Controls.Add(Me.Panel224)
Me.TabPage2.Controls.Add(Me.Panel225)
Me.TabPage2.Controls.Add(Me.Panel226)
Me.TabPage2.Controls.Add(Me.Panel227)
Me.TabPage2.Controls.Add(Me.Panel228)
Me.TabPage2.Controls.Add(Me.Panel229)
Me.TabPage2.Controls.Add(Me.Panel230)
Me.TabPage2.Controls.Add(Me.Panel231)
Me.TabPage2.Controls.Add(Me.Panel232)
Me.TabPage2.Controls.Add(Me.Panel233)
Me.TabPage2.Controls.Add(Me.Panel234)
Me.TabPage2.Controls.Add(Me.Panel235)
Me.TabPage2.Controls.Add(Me.Panel236)
Me.TabPage2.Controls.Add(Me.Panel237)
Me.TabPage2.Controls.Add(Me.Panel238)
Me.TabPage2.Controls.Add(Me.Panel239)
Me.TabPage2.Controls.Add(Me.Panel240)
Me.TabPage2.Controls.Add(Me.Panel241)
Me.TabPage2.Controls.Add(Me.Panel242)
Me.TabPage2.Controls.Add(Me.Panel243)
Me.TabPage2.Controls.Add(Me.Panel244)
Me.TabPage2.Controls.Add(Me.Panel245)
Me.TabPage2.Controls.Add(Me.Panel246)
Me.TabPage2.Controls.Add(Me.Panel247)
Me.TabPage2.Controls.Add(Me.Panel248)
Me.TabPage2.Controls.Add(Me.Panel249)
Me.TabPage2.Controls.Add(Me.Panel250)
Me.TabPage2.Controls.Add(Me.Panel251)
Me.TabPage2.Controls.Add(Me.Panel252)
Me.TabPage2.Controls.Add(Me.Panel253)
Me.TabPage2.Controls.Add(Me.Panel254)
Me.TabPage2.Controls.Add(Me.Panel255)
Me.TabPage2.Controls.Add(Me.Panel256)
Me.TabPage2.Controls.Add(Me.Panel257)
Me.TabPage2.Location = New System.Drawing.Point(4, 22)
Me.TabPage2.Name = "TabPage2"
Me.TabPage2.Size = New System.Drawing.Size(968, 222)
Me.TabPage2.TabIndex = 1
Me.TabPage2.Text = "10 bar"
Me.TabPage2.Visible = false
'
'Panel216
'
Me.Panel216.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel216.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel216.Controls.Add(Me.TextBox233)
Me.Panel216.Controls.Add(Me.TextBox234)
Me.Panel216.Location = New System.Drawing.Point(380, 111)
Me.Panel216.Name = "Panel216"
Me.Panel216.Size = New System.Drawing.Size(89, 24)
Me.Panel216.TabIndex = 64
'
'TextBox233
'
Me.TextBox233.Location = New System.Drawing.Point(3, 2)
Me.TextBox233.Name = "TextBox233"
Me.TextBox233.ReadOnly = true
Me.TextBox233.Size = New System.Drawing.Size(40, 20)
Me.TextBox233.TabIndex = 8
Me.TextBox233.Text = ""
'
'TextBox234
'
Me.TextBox234.Location = New System.Drawing.Point(46, 2)
Me.TextBox234.Name = "TextBox234"
Me.TextBox234.ReadOnly = true
Me.TextBox234.Size = New System.Drawing.Size(40, 20)
Me.TextBox234.TabIndex = 7
Me.TextBox234.Text = ""
'
'Panel217
'
Me.Panel217.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel217.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel217.Controls.Add(Me.TextBox235)
Me.Panel217.Controls.Add(Me.TextBox236)
Me.Panel217.Location = New System.Drawing.Point(732, 111)
Me.Panel217.Name = "Panel217"
Me.Panel217.Size = New System.Drawing.Size(89, 24)
Me.Panel217.TabIndex = 63
'
'TextBox235
'
Me.TextBox235.Location = New System.Drawing.Point(3, 2)
Me.TextBox235.Name = "TextBox235"
Me.TextBox235.ReadOnly = true
Me.TextBox235.Size = New System.Drawing.Size(40, 20)
Me.TextBox235.TabIndex = 8
Me.TextBox235.Text = ""
'
'TextBox236
'
Me.TextBox236.Location = New System.Drawing.Point(46, 2)
Me.TextBox236.Name = "TextBox236"
Me.TextBox236.ReadOnly = true
Me.TextBox236.Size = New System.Drawing.Size(40, 20)
Me.TextBox236.TabIndex = 7
Me.TextBox236.Text = ""
'
'Panel218
'
Me.Panel218.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel218.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel218.Controls.Add(Me.TextBox237)
Me.Panel218.Controls.Add(Me.TextBox238)
Me.Panel218.Location = New System.Drawing.Point(556, 111)
Me.Panel218.Name = "Panel218"
Me.Panel218.Size = New System.Drawing.Size(89, 24)
Me.Panel218.TabIndex = 65
'
'TextBox237
'
Me.TextBox237.Location = New System.Drawing.Point(3, 2)
Me.TextBox237.Name = "TextBox237"
Me.TextBox237.ReadOnly = true
Me.TextBox237.Size = New System.Drawing.Size(40, 20)
Me.TextBox237.TabIndex = 8
Me.TextBox237.Text = ""
'
'TextBox238
'
Me.TextBox238.Location = New System.Drawing.Point(46, 2)
Me.TextBox238.Name = "TextBox238"
Me.TextBox238.ReadOnly = true
Me.TextBox238.Size = New System.Drawing.Size(40, 20)
Me.TextBox238.TabIndex = 7
Me.TextBox238.Text = ""
'
'Panel219
'
Me.Panel219.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel219.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel219.Controls.Add(Me.TextBox239)
Me.Panel219.Controls.Add(Me.TextBox240)
Me.Panel219.Location = New System.Drawing.Point(644, 111)
Me.Panel219.Name = "Panel219"
Me.Panel219.Size = New System.Drawing.Size(89, 24)
Me.Panel219.TabIndex = 67
'
'TextBox239
'
Me.TextBox239.Location = New System.Drawing.Point(3, 2)
Me.TextBox239.Name = "TextBox239"
Me.TextBox239.ReadOnly = true
Me.TextBox239.Size = New System.Drawing.Size(40, 20)
Me.TextBox239.TabIndex = 8
Me.TextBox239.Text = ""
'
'TextBox240
'
Me.TextBox240.Location = New System.Drawing.Point(46, 2)
Me.TextBox240.Name = "TextBox240"
Me.TextBox240.ReadOnly = true
Me.TextBox240.Size = New System.Drawing.Size(40, 20)
Me.TextBox240.TabIndex = 7
Me.TextBox240.Text = ""
'
'Panel220
'
Me.Panel220.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel220.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel220.Controls.Add(Me.TextBox241)
Me.Panel220.Controls.Add(Me.TextBox242)
Me.Panel220.Location = New System.Drawing.Point(292, 111)
Me.Panel220.Name = "Panel220"
Me.Panel220.Size = New System.Drawing.Size(89, 24)
Me.Panel220.TabIndex = 66
'
'TextBox241
'
Me.TextBox241.Location = New System.Drawing.Point(3, 2)
Me.TextBox241.Name = "TextBox241"
Me.TextBox241.ReadOnly = true
Me.TextBox241.Size = New System.Drawing.Size(40, 20)
Me.TextBox241.TabIndex = 8
Me.TextBox241.Text = ""
'
'TextBox242
'
Me.TextBox242.Location = New System.Drawing.Point(46, 2)
Me.TextBox242.Name = "TextBox242"
Me.TextBox242.ReadOnly = true
Me.TextBox242.Size = New System.Drawing.Size(40, 20)
Me.TextBox242.TabIndex = 7
Me.TextBox242.Text = ""
'
'Panel221
'
Me.Panel221.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel221.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel221.Controls.Add(Me.TextBox243)
Me.Panel221.Controls.Add(Me.TextBox244)
Me.Panel221.Location = New System.Drawing.Point(468, 111)
Me.Panel221.Name = "Panel221"
Me.Panel221.Size = New System.Drawing.Size(89, 24)
Me.Panel221.TabIndex = 73
'
'TextBox243
'
Me.TextBox243.Location = New System.Drawing.Point(3, 2)
Me.TextBox243.Name = "TextBox243"
Me.TextBox243.ReadOnly = true
Me.TextBox243.Size = New System.Drawing.Size(40, 20)
Me.TextBox243.TabIndex = 8
Me.TextBox243.Text = ""
'
'TextBox244
'
Me.TextBox244.Location = New System.Drawing.Point(46, 2)
Me.TextBox244.Name = "TextBox244"
Me.TextBox244.ReadOnly = true
Me.TextBox244.Size = New System.Drawing.Size(40, 20)
Me.TextBox244.TabIndex = 7
Me.TextBox244.Text = ""
'
'Panel222
'
Me.Panel222.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel222.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel222.Controls.Add(Me.TextBox245)
Me.Panel222.Controls.Add(Me.TextBox246)
Me.Panel222.Location = New System.Drawing.Point(556, 135)
Me.Panel222.Name = "Panel222"
Me.Panel222.Size = New System.Drawing.Size(89, 24)
Me.Panel222.TabIndex = 80
'
'TextBox245
'
Me.TextBox245.Location = New System.Drawing.Point(3, 2)
Me.TextBox245.Name = "TextBox245"
Me.TextBox245.ReadOnly = true
Me.TextBox245.Size = New System.Drawing.Size(40, 20)
Me.TextBox245.TabIndex = 8
Me.TextBox245.Text = ""
'
'TextBox246
'
Me.TextBox246.Location = New System.Drawing.Point(46, 2)
Me.TextBox246.Name = "TextBox246"
Me.TextBox246.ReadOnly = true
Me.TextBox246.Size = New System.Drawing.Size(40, 20)
Me.TextBox246.TabIndex = 7
Me.TextBox246.Text = ""
'
'Panel223
'
Me.Panel223.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel223.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel223.Controls.Add(Me.TextBox247)
Me.Panel223.Controls.Add(Me.TextBox248)
Me.Panel223.Location = New System.Drawing.Point(644, 135)
Me.Panel223.Name = "Panel223"
Me.Panel223.Size = New System.Drawing.Size(89, 24)
Me.Panel223.TabIndex = 79
'
'TextBox247
'
Me.TextBox247.Location = New System.Drawing.Point(3, 2)
Me.TextBox247.Name = "TextBox247"
Me.TextBox247.ReadOnly = true
Me.TextBox247.Size = New System.Drawing.Size(40, 20)
Me.TextBox247.TabIndex = 8
Me.TextBox247.Text = ""
'
'TextBox248
'
Me.TextBox248.Location = New System.Drawing.Point(46, 2)
Me.TextBox248.Name = "TextBox248"
Me.TextBox248.ReadOnly = true
Me.TextBox248.Size = New System.Drawing.Size(40, 20)
Me.TextBox248.TabIndex = 7
Me.TextBox248.Text = ""
'
'Panel224
'
Me.Panel224.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel224.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel224.Controls.Add(Me.TextBox249)
Me.Panel224.Controls.Add(Me.TextBox250)
Me.Panel224.Location = New System.Drawing.Point(732, 135)
Me.Panel224.Name = "Panel224"
Me.Panel224.Size = New System.Drawing.Size(89, 24)
Me.Panel224.TabIndex = 81
'
'TextBox249
'
Me.TextBox249.Location = New System.Drawing.Point(3, 2)
Me.TextBox249.Name = "TextBox249"
Me.TextBox249.ReadOnly = true
Me.TextBox249.Size = New System.Drawing.Size(40, 20)
Me.TextBox249.TabIndex = 8
Me.TextBox249.Text = ""
'
'TextBox250
'
Me.TextBox250.Location = New System.Drawing.Point(46, 2)
Me.TextBox250.Name = "TextBox250"
Me.TextBox250.ReadOnly = true
Me.TextBox250.Size = New System.Drawing.Size(40, 20)
Me.TextBox250.TabIndex = 7
Me.TextBox250.Text = ""
'
'Panel225
'
Me.Panel225.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel225.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel225.Controls.Add(Me.TextBox251)
Me.Panel225.Controls.Add(Me.TextBox252)
Me.Panel225.Location = New System.Drawing.Point(380, 135)
Me.Panel225.Name = "Panel225"
Me.Panel225.Size = New System.Drawing.Size(89, 24)
Me.Panel225.TabIndex = 83
'
'TextBox251
'
Me.TextBox251.Location = New System.Drawing.Point(3, 2)
Me.TextBox251.Name = "TextBox251"
Me.TextBox251.ReadOnly = true
Me.TextBox251.Size = New System.Drawing.Size(40, 20)
Me.TextBox251.TabIndex = 8
Me.TextBox251.Text = ""
'
'TextBox252
'
Me.TextBox252.Location = New System.Drawing.Point(46, 2)
Me.TextBox252.Name = "TextBox252"
Me.TextBox252.ReadOnly = true
Me.TextBox252.Size = New System.Drawing.Size(40, 20)
Me.TextBox252.TabIndex = 7
Me.TextBox252.Text = ""
'
'Panel226
'
Me.Panel226.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel226.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel226.Controls.Add(Me.TextBox253)
Me.Panel226.Controls.Add(Me.TextBox254)
Me.Panel226.Location = New System.Drawing.Point(292, 135)
Me.Panel226.Name = "Panel226"
Me.Panel226.Size = New System.Drawing.Size(89, 24)
Me.Panel226.TabIndex = 82
'
'TextBox253
'
Me.TextBox253.Location = New System.Drawing.Point(3, 2)
Me.TextBox253.Name = "TextBox253"
Me.TextBox253.ReadOnly = true
Me.TextBox253.Size = New System.Drawing.Size(40, 20)
Me.TextBox253.TabIndex = 8
Me.TextBox253.Text = ""
'
'TextBox254
'
Me.TextBox254.Location = New System.Drawing.Point(46, 2)
Me.TextBox254.Name = "TextBox254"
Me.TextBox254.ReadOnly = true
Me.TextBox254.Size = New System.Drawing.Size(40, 20)
Me.TextBox254.TabIndex = 7
Me.TextBox254.Text = ""
'
'Panel227
'
Me.Panel227.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel227.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel227.Controls.Add(Me.TextBox255)
Me.Panel227.Controls.Add(Me.TextBox256)
Me.Panel227.Location = New System.Drawing.Point(468, 135)
Me.Panel227.Name = "Panel227"
Me.Panel227.Size = New System.Drawing.Size(89, 24)
Me.Panel227.TabIndex = 75
'
'TextBox255
'
Me.TextBox255.Location = New System.Drawing.Point(3, 2)
Me.TextBox255.Name = "TextBox255"
Me.TextBox255.ReadOnly = true
Me.TextBox255.Size = New System.Drawing.Size(40, 20)
Me.TextBox255.TabIndex = 8
Me.TextBox255.Text = ""
'
'TextBox256
'
Me.TextBox256.Location = New System.Drawing.Point(46, 2)
Me.TextBox256.Name = "TextBox256"
Me.TextBox256.ReadOnly = true
Me.TextBox256.Size = New System.Drawing.Size(40, 20)
Me.TextBox256.TabIndex = 7
Me.TextBox256.Text = ""
'
'Panel228
'
Me.Panel228.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel228.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel228.Controls.Add(Me.TextBox257)
Me.Panel228.Location = New System.Drawing.Point(292, 159)
Me.Panel228.Name = "Panel228"
Me.Panel228.Size = New System.Drawing.Size(89, 24)
Me.Panel228.TabIndex = 74
'
'TextBox257
'
Me.TextBox257.Location = New System.Drawing.Point(3, 2)
Me.TextBox257.Name = "TextBox257"
Me.TextBox257.ReadOnly = true
Me.TextBox257.Size = New System.Drawing.Size(83, 20)
Me.TextBox257.TabIndex = 8
Me.TextBox257.Text = ""
'
'Panel229
'
Me.Panel229.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel229.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel229.Controls.Add(Me.Label133)
Me.Panel229.Location = New System.Drawing.Point(292, 39)
Me.Panel229.Name = "Panel229"
Me.Panel229.Size = New System.Drawing.Size(89, 24)
Me.Panel229.TabIndex = 88
'
'Label133
'
Me.Label133.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label133.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label133.Location = New System.Drawing.Point(8, 4)
Me.Label133.Name = "Label133"
Me.Label133.Size = New System.Drawing.Size(80, 16)
Me.Label133.TabIndex = 6
Me.Label133.Text = "1"
Me.Label133.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel230
'
Me.Panel230.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel230.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel230.Controls.Add(Me.TextBox258)
Me.Panel230.Location = New System.Drawing.Point(292, 183)
Me.Panel230.Name = "Panel230"
Me.Panel230.Size = New System.Drawing.Size(89, 24)
Me.Panel230.TabIndex = 76
'
'TextBox258
'
Me.TextBox258.Location = New System.Drawing.Point(3, 2)
Me.TextBox258.Name = "TextBox258"
Me.TextBox258.ReadOnly = true
Me.TextBox258.Size = New System.Drawing.Size(83, 20)
Me.TextBox258.TabIndex = 8
Me.TextBox258.Text = ""
'
'Panel231
'
Me.Panel231.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel231.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel231.Controls.Add(Me.Label134)
Me.Panel231.Location = New System.Drawing.Point(380, 159)
Me.Panel231.Name = "Panel231"
Me.Panel231.Size = New System.Drawing.Size(177, 48)
Me.Panel231.TabIndex = 78
'
'Label134
'
Me.Label134.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label134.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label134.Location = New System.Drawing.Point(8, 16)
Me.Label134.Name = "Label134"
Me.Label134.Size = New System.Drawing.Size(160, 16)
Me.Label134.TabIndex = 6
Me.Label134.Text = "Hétérogénité d'alimentation :"
Me.Label134.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel232
'
Me.Panel232.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel232.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel232.Controls.Add(Me.Label135)
Me.Panel232.Controls.Add(Me.Label136)
Me.Panel232.Controls.Add(Me.TextBox259)
Me.Panel232.Controls.Add(Me.TextBox260)
Me.Panel232.Location = New System.Drawing.Point(148, 15)
Me.Panel232.Name = "Panel232"
Me.Panel232.Size = New System.Drawing.Size(673, 24)
Me.Panel232.TabIndex = 90
'
'Label135
'
Me.Label135.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label135.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label135.Location = New System.Drawing.Point(8, 4)
Me.Label135.Name = "Label135"
Me.Label135.Size = New System.Drawing.Size(128, 16)
Me.Label135.TabIndex = 6
Me.Label135.Text = "Pression Mano Pulvé :"
Me.Label135.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label136
'
Me.Label136.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label136.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label136.Location = New System.Drawing.Point(392, 4)
Me.Label136.Name = "Label136"
Me.Label136.Size = New System.Drawing.Size(136, 16)
Me.Label136.TabIndex = 6
Me.Label136.Text = "Moyenne des pressions :"
Me.Label136.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox259
'
Me.TextBox259.Location = New System.Drawing.Point(144, 2)
Me.TextBox259.Name = "TextBox259"
Me.TextBox259.ReadOnly = true
Me.TextBox259.Size = New System.Drawing.Size(83, 20)
Me.TextBox259.TabIndex = 8
Me.TextBox259.Text = "10"
'
'TextBox260
'
Me.TextBox260.Location = New System.Drawing.Point(536, 2)
Me.TextBox260.Name = "TextBox260"
Me.TextBox260.ReadOnly = true
Me.TextBox260.Size = New System.Drawing.Size(83, 20)
Me.TextBox260.TabIndex = 8
Me.TextBox260.Text = ""
'
'Panel233
'
Me.Panel233.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel233.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel233.Controls.Add(Me.Label137)
Me.Panel233.Controls.Add(Me.Label138)
Me.Panel233.Location = New System.Drawing.Point(556, 159)
Me.Panel233.Name = "Panel233"
Me.Panel233.Size = New System.Drawing.Size(265, 48)
Me.Panel233.TabIndex = 77
'
'Label137
'
Me.Label137.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label137.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label137.Location = New System.Drawing.Point(48, 16)
Me.Label137.Name = "Label137"
Me.Label137.Size = New System.Drawing.Size(168, 16)
Me.Label137.TabIndex = 29
Me.Label137.Text = "OK"
Me.Label137.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label138
'
Me.Label138.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label138.ForeColor = System.Drawing.Color.Red
Me.Label138.Location = New System.Drawing.Point(48, 16)
Me.Label138.Name = "Label138"
Me.Label138.Size = New System.Drawing.Size(168, 16)
Me.Label138.TabIndex = 28
Me.Label138.Text = "DEFAUT"
Me.Label138.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel234
'
Me.Panel234.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel234.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel234.Controls.Add(Me.Label139)
Me.Panel234.Controls.Add(Me.Label140)
Me.Panel234.Location = New System.Drawing.Point(292, 63)
Me.Panel234.Name = "Panel234"
Me.Panel234.Size = New System.Drawing.Size(89, 24)
Me.Panel234.TabIndex = 87
'
'Label139
'
Me.Label139.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label139.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label139.Location = New System.Drawing.Point(8, 4)
Me.Label139.Name = "Label139"
Me.Label139.Size = New System.Drawing.Size(40, 16)
Me.Label139.TabIndex = 6
Me.Label139.Text = "G"
Me.Label139.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label140
'
Me.Label140.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label140.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label140.Location = New System.Drawing.Point(48, 4)
Me.Label140.Name = "Label140"
Me.Label140.Size = New System.Drawing.Size(40, 16)
Me.Label140.TabIndex = 6
Me.Label140.Text = "D"
Me.Label140.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel235
'
Me.Panel235.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel235.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel235.Controls.Add(Me.Label141)
Me.Panel235.Controls.Add(Me.Label142)
Me.Panel235.Location = New System.Drawing.Point(380, 63)
Me.Panel235.Name = "Panel235"
Me.Panel235.Size = New System.Drawing.Size(89, 24)
Me.Panel235.TabIndex = 94
'
'Label141
'
Me.Label141.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label141.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label141.Location = New System.Drawing.Point(8, 4)
Me.Label141.Name = "Label141"
Me.Label141.Size = New System.Drawing.Size(40, 16)
Me.Label141.TabIndex = 6
Me.Label141.Text = "G"
Me.Label141.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label142
'
Me.Label142.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label142.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label142.Location = New System.Drawing.Point(48, 4)
Me.Label142.Name = "Label142"
Me.Label142.Size = New System.Drawing.Size(40, 16)
Me.Label142.TabIndex = 6
Me.Label142.Text = "D"
Me.Label142.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel236
'
Me.Panel236.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel236.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel236.Controls.Add(Me.Label143)
Me.Panel236.Location = New System.Drawing.Point(380, 39)
Me.Panel236.Name = "Panel236"
Me.Panel236.Size = New System.Drawing.Size(89, 24)
Me.Panel236.TabIndex = 101
'
'Label143
'
Me.Label143.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label143.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label143.Location = New System.Drawing.Point(8, 4)
Me.Label143.Name = "Label143"
Me.Label143.Size = New System.Drawing.Size(80, 16)
Me.Label143.TabIndex = 6
Me.Label143.Text = "2"
Me.Label143.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel237
'
Me.Panel237.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel237.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel237.Controls.Add(Me.Label144)
Me.Panel237.Location = New System.Drawing.Point(148, 87)
Me.Panel237.Name = "Panel237"
Me.Panel237.Size = New System.Drawing.Size(144, 24)
Me.Panel237.TabIndex = 93
'
'Label144
'
Me.Label144.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label144.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label144.Location = New System.Drawing.Point(8, 4)
Me.Label144.Name = "Label144"
Me.Label144.Size = New System.Drawing.Size(128, 16)
Me.Label144.TabIndex = 6
Me.Label144.Text = "P sortie"
Me.Label144.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel238
'
Me.Panel238.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel238.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel238.Controls.Add(Me.Label145)
Me.Panel238.Location = New System.Drawing.Point(148, 111)
Me.Panel238.Name = "Panel238"
Me.Panel238.Size = New System.Drawing.Size(144, 24)
Me.Panel238.TabIndex = 92
'
'Label145
'
Me.Label145.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label145.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label145.Location = New System.Drawing.Point(8, 4)
Me.Label145.Name = "Label145"
Me.Label145.Size = New System.Drawing.Size(128, 16)
Me.Label145.TabIndex = 6
Me.Label145.Text = "Ecart"
Me.Label145.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel239
'
Me.Panel239.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel239.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel239.Controls.Add(Me.Label146)
Me.Panel239.Location = New System.Drawing.Point(148, 135)
Me.Panel239.Name = "Panel239"
Me.Panel239.Size = New System.Drawing.Size(144, 24)
Me.Panel239.TabIndex = 85
'
'Label146
'
Me.Label146.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label146.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label146.Location = New System.Drawing.Point(8, 4)
Me.Label146.Name = "Label146"
Me.Label146.Size = New System.Drawing.Size(128, 16)
Me.Label146.TabIndex = 6
Me.Label146.Text = "Perte charge"
Me.Label146.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel240
'
Me.Panel240.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel240.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel240.Controls.Add(Me.Label147)
Me.Panel240.Location = New System.Drawing.Point(148, 159)
Me.Panel240.Name = "Panel240"
Me.Panel240.Size = New System.Drawing.Size(144, 24)
Me.Panel240.TabIndex = 84
'
'Label147
'
Me.Label147.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label147.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label147.Location = New System.Drawing.Point(8, 4)
Me.Label147.Name = "Label147"
Me.Label147.Size = New System.Drawing.Size(128, 16)
Me.Label147.TabIndex = 6
Me.Label147.Text = "Perte de charge moy"
Me.Label147.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel241
'
Me.Panel241.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel241.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel241.Controls.Add(Me.Label148)
Me.Panel241.Location = New System.Drawing.Point(148, 183)
Me.Panel241.Name = "Panel241"
Me.Panel241.Size = New System.Drawing.Size(144, 24)
Me.Panel241.TabIndex = 86
'
'Label148
'
Me.Label148.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label148.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label148.Location = New System.Drawing.Point(8, 4)
Me.Label148.Name = "Label148"
Me.Label148.Size = New System.Drawing.Size(128, 16)
Me.Label148.TabIndex = 6
Me.Label148.Text = "Perte de charge max"
Me.Label148.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel242
'
Me.Panel242.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel242.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel242.Controls.Add(Me.Label149)
Me.Panel242.Location = New System.Drawing.Point(148, 39)
Me.Panel242.Name = "Panel242"
Me.Panel242.Size = New System.Drawing.Size(144, 24)
Me.Panel242.TabIndex = 89
'
'Label149
'
Me.Label149.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label149.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label149.Location = New System.Drawing.Point(8, 4)
Me.Label149.Name = "Label149"
Me.Label149.Size = New System.Drawing.Size(128, 16)
Me.Label149.TabIndex = 6
Me.Label149.Text = "Niveau"
Me.Label149.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel243
'
Me.Panel243.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel243.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel243.Controls.Add(Me.Label150)
Me.Panel243.Location = New System.Drawing.Point(148, 63)
Me.Panel243.Name = "Panel243"
Me.Panel243.Size = New System.Drawing.Size(144, 24)
Me.Panel243.TabIndex = 91
'
'Label150
'
Me.Label150.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label150.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label150.Location = New System.Drawing.Point(8, 4)
Me.Label150.Name = "Label150"
Me.Label150.Size = New System.Drawing.Size(128, 16)
Me.Label150.TabIndex = 6
Me.Label150.Text = "Section Gauche/Droite"
Me.Label150.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel244
'
Me.Panel244.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel244.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel244.Controls.Add(Me.Label151)
Me.Panel244.Location = New System.Drawing.Point(468, 39)
Me.Panel244.Name = "Panel244"
Me.Panel244.Size = New System.Drawing.Size(89, 24)
Me.Panel244.TabIndex = 100
'
'Label151
'
Me.Label151.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label151.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label151.Location = New System.Drawing.Point(8, 4)
Me.Label151.Name = "Label151"
Me.Label151.Size = New System.Drawing.Size(80, 16)
Me.Label151.TabIndex = 6
Me.Label151.Text = "3"
Me.Label151.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel245
'
Me.Panel245.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel245.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel245.Controls.Add(Me.Label152)
Me.Panel245.Controls.Add(Me.Label153)
Me.Panel245.Location = New System.Drawing.Point(468, 63)
Me.Panel245.Name = "Panel245"
Me.Panel245.Size = New System.Drawing.Size(89, 24)
Me.Panel245.TabIndex = 102
'
'Label152
'
Me.Label152.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label152.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label152.Location = New System.Drawing.Point(8, 4)
Me.Label152.Name = "Label152"
Me.Label152.Size = New System.Drawing.Size(40, 16)
Me.Label152.TabIndex = 6
Me.Label152.Text = "G"
Me.Label152.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label153
'
Me.Label153.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label153.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label153.Location = New System.Drawing.Point(48, 4)
Me.Label153.Name = "Label153"
Me.Label153.Size = New System.Drawing.Size(40, 16)
Me.Label153.TabIndex = 6
Me.Label153.Text = "D"
Me.Label153.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel246
'
Me.Panel246.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel246.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel246.Controls.Add(Me.Label154)
Me.Panel246.Controls.Add(Me.Label155)
Me.Panel246.Location = New System.Drawing.Point(556, 63)
Me.Panel246.Name = "Panel246"
Me.Panel246.Size = New System.Drawing.Size(89, 24)
Me.Panel246.TabIndex = 104
'
'Label154
'
Me.Label154.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label154.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label154.Location = New System.Drawing.Point(8, 4)
Me.Label154.Name = "Label154"
Me.Label154.Size = New System.Drawing.Size(40, 16)
Me.Label154.TabIndex = 6
Me.Label154.Text = "G"
Me.Label154.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label155
'
Me.Label155.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label155.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label155.Location = New System.Drawing.Point(48, 4)
Me.Label155.Name = "Label155"
Me.Label155.Size = New System.Drawing.Size(40, 16)
Me.Label155.TabIndex = 6
Me.Label155.Text = "D"
Me.Label155.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel247
'
Me.Panel247.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel247.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel247.Controls.Add(Me.Label156)
Me.Panel247.Location = New System.Drawing.Point(556, 39)
Me.Panel247.Name = "Panel247"
Me.Panel247.Size = New System.Drawing.Size(89, 24)
Me.Panel247.TabIndex = 103
'
'Label156
'
Me.Label156.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label156.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label156.Location = New System.Drawing.Point(8, 4)
Me.Label156.Name = "Label156"
Me.Label156.Size = New System.Drawing.Size(80, 16)
Me.Label156.TabIndex = 6
Me.Label156.Text = "4"
Me.Label156.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel248
'
Me.Panel248.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel248.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel248.Controls.Add(Me.Label157)
Me.Panel248.Location = New System.Drawing.Point(644, 39)
Me.Panel248.Name = "Panel248"
Me.Panel248.Size = New System.Drawing.Size(89, 24)
Me.Panel248.TabIndex = 96
'
'Label157
'
Me.Label157.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label157.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label157.Location = New System.Drawing.Point(8, 4)
Me.Label157.Name = "Label157"
Me.Label157.Size = New System.Drawing.Size(80, 16)
Me.Label157.TabIndex = 6
Me.Label157.Text = "5"
Me.Label157.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel249
'
Me.Panel249.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel249.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel249.Controls.Add(Me.Label158)
Me.Panel249.Controls.Add(Me.Label159)
Me.Panel249.Location = New System.Drawing.Point(644, 63)
Me.Panel249.Name = "Panel249"
Me.Panel249.Size = New System.Drawing.Size(89, 24)
Me.Panel249.TabIndex = 95
'
'Label158
'
Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label158.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label158.Location = New System.Drawing.Point(8, 4)
Me.Label158.Name = "Label158"
Me.Label158.Size = New System.Drawing.Size(40, 16)
Me.Label158.TabIndex = 6
Me.Label158.Text = "G"
Me.Label158.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label159
'
Me.Label159.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label159.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label159.Location = New System.Drawing.Point(48, 4)
Me.Label159.Name = "Label159"
Me.Label159.Size = New System.Drawing.Size(40, 16)
Me.Label159.TabIndex = 6
Me.Label159.Text = "D"
Me.Label159.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel250
'
Me.Panel250.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel250.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel250.Controls.Add(Me.Label160)
Me.Panel250.Controls.Add(Me.Label161)
Me.Panel250.Location = New System.Drawing.Point(732, 63)
Me.Panel250.Name = "Panel250"
Me.Panel250.Size = New System.Drawing.Size(89, 24)
Me.Panel250.TabIndex = 97
'
'Label160
'
Me.Label160.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label160.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label160.Location = New System.Drawing.Point(8, 4)
Me.Label160.Name = "Label160"
Me.Label160.Size = New System.Drawing.Size(40, 16)
Me.Label160.TabIndex = 6
Me.Label160.Text = "G"
Me.Label160.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label161
'
Me.Label161.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label161.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label161.Location = New System.Drawing.Point(48, 4)
Me.Label161.Name = "Label161"
Me.Label161.Size = New System.Drawing.Size(40, 16)
Me.Label161.TabIndex = 6
Me.Label161.Text = "D"
Me.Label161.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel251
'
Me.Panel251.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel251.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel251.Controls.Add(Me.Label162)
Me.Panel251.Location = New System.Drawing.Point(732, 39)
Me.Panel251.Name = "Panel251"
Me.Panel251.Size = New System.Drawing.Size(89, 24)
Me.Panel251.TabIndex = 99
'
'Label162
'
Me.Label162.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label162.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label162.Location = New System.Drawing.Point(8, 4)
Me.Label162.Name = "Label162"
Me.Label162.Size = New System.Drawing.Size(80, 16)
Me.Label162.TabIndex = 6
Me.Label162.Text = "6"
Me.Label162.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel252
'
Me.Panel252.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel252.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel252.Controls.Add(Me.TextBox261)
Me.Panel252.Controls.Add(Me.TextBox262)
Me.Panel252.Location = New System.Drawing.Point(292, 87)
Me.Panel252.Name = "Panel252"
Me.Panel252.Size = New System.Drawing.Size(89, 24)
Me.Panel252.TabIndex = 98
'
'TextBox261
'
Me.TextBox261.Location = New System.Drawing.Point(3, 2)
Me.TextBox261.Name = "TextBox261"
Me.TextBox261.Size = New System.Drawing.Size(40, 20)
Me.TextBox261.TabIndex = 8
Me.TextBox261.Text = ""
'
'TextBox262
'
Me.TextBox262.Location = New System.Drawing.Point(46, 2)
Me.TextBox262.Name = "TextBox262"
Me.TextBox262.Size = New System.Drawing.Size(40, 20)
Me.TextBox262.TabIndex = 7
Me.TextBox262.Text = ""
'
'Panel253
'
Me.Panel253.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel253.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel253.Controls.Add(Me.TextBox263)
Me.Panel253.Controls.Add(Me.TextBox264)
Me.Panel253.Location = New System.Drawing.Point(380, 87)
Me.Panel253.Name = "Panel253"
Me.Panel253.Size = New System.Drawing.Size(89, 24)
Me.Panel253.TabIndex = 69
'
'TextBox263
'
Me.TextBox263.Location = New System.Drawing.Point(3, 2)
Me.TextBox263.Name = "TextBox263"
Me.TextBox263.Size = New System.Drawing.Size(40, 20)
Me.TextBox263.TabIndex = 8
Me.TextBox263.Text = ""
'
'TextBox264
'
Me.TextBox264.Location = New System.Drawing.Point(46, 2)
Me.TextBox264.Name = "TextBox264"
Me.TextBox264.Size = New System.Drawing.Size(40, 20)
Me.TextBox264.TabIndex = 7
Me.TextBox264.Text = ""
'
'Panel254
'
Me.Panel254.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel254.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel254.Controls.Add(Me.TextBox265)
Me.Panel254.Controls.Add(Me.TextBox266)
Me.Panel254.Location = New System.Drawing.Point(468, 87)
Me.Panel254.Name = "Panel254"
Me.Panel254.Size = New System.Drawing.Size(89, 24)
Me.Panel254.TabIndex = 68
'
'TextBox265
'
Me.TextBox265.Location = New System.Drawing.Point(3, 2)
Me.TextBox265.Name = "TextBox265"
Me.TextBox265.Size = New System.Drawing.Size(40, 20)
Me.TextBox265.TabIndex = 8
Me.TextBox265.Text = ""
'
'TextBox266
'
Me.TextBox266.Location = New System.Drawing.Point(46, 2)
Me.TextBox266.Name = "TextBox266"
Me.TextBox266.Size = New System.Drawing.Size(40, 20)
Me.TextBox266.TabIndex = 7
Me.TextBox266.Text = ""
'
'Panel255
'
Me.Panel255.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel255.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel255.Controls.Add(Me.TextBox267)
Me.Panel255.Controls.Add(Me.TextBox268)
Me.Panel255.Location = New System.Drawing.Point(556, 87)
Me.Panel255.Name = "Panel255"
Me.Panel255.Size = New System.Drawing.Size(89, 24)
Me.Panel255.TabIndex = 70
'
'TextBox267
'
Me.TextBox267.Location = New System.Drawing.Point(3, 2)
Me.TextBox267.Name = "TextBox267"
Me.TextBox267.Size = New System.Drawing.Size(40, 20)
Me.TextBox267.TabIndex = 8
Me.TextBox267.Text = ""
'
'TextBox268
'
Me.TextBox268.Location = New System.Drawing.Point(46, 2)
Me.TextBox268.Name = "TextBox268"
Me.TextBox268.Size = New System.Drawing.Size(40, 20)
Me.TextBox268.TabIndex = 7
Me.TextBox268.Text = ""
'
'Panel256
'
Me.Panel256.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel256.Controls.Add(Me.TextBox269)
Me.Panel256.Controls.Add(Me.TextBox270)
Me.Panel256.Location = New System.Drawing.Point(644, 87)
Me.Panel256.Name = "Panel256"
Me.Panel256.Size = New System.Drawing.Size(89, 24)
Me.Panel256.TabIndex = 72
'
'TextBox269
'
Me.TextBox269.Location = New System.Drawing.Point(3, 2)
Me.TextBox269.Name = "TextBox269"
Me.TextBox269.Size = New System.Drawing.Size(40, 20)
Me.TextBox269.TabIndex = 8
Me.TextBox269.Text = ""
'
'TextBox270
'
Me.TextBox270.Location = New System.Drawing.Point(46, 2)
Me.TextBox270.Name = "TextBox270"
Me.TextBox270.Size = New System.Drawing.Size(40, 20)
Me.TextBox270.TabIndex = 7
Me.TextBox270.Text = ""
'
'Panel257
'
Me.Panel257.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel257.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel257.Controls.Add(Me.TextBox271)
Me.Panel257.Controls.Add(Me.TextBox272)
Me.Panel257.Location = New System.Drawing.Point(732, 87)
Me.Panel257.Name = "Panel257"
Me.Panel257.Size = New System.Drawing.Size(89, 24)
Me.Panel257.TabIndex = 71
'
'TextBox271
'
Me.TextBox271.Location = New System.Drawing.Point(3, 2)
Me.TextBox271.Name = "TextBox271"
Me.TextBox271.Size = New System.Drawing.Size(40, 20)
Me.TextBox271.TabIndex = 8
Me.TextBox271.Text = ""
'
'TextBox272
'
Me.TextBox272.Location = New System.Drawing.Point(46, 2)
Me.TextBox272.Name = "TextBox272"
Me.TextBox272.Size = New System.Drawing.Size(40, 20)
Me.TextBox272.TabIndex = 7
Me.TextBox272.Text = ""
'
'TabPage8
'
Me.TabPage8.Controls.Add(Me.Panel258)
Me.TabPage8.Controls.Add(Me.Panel259)
Me.TabPage8.Controls.Add(Me.Panel260)
Me.TabPage8.Controls.Add(Me.Panel261)
Me.TabPage8.Controls.Add(Me.Panel262)
Me.TabPage8.Controls.Add(Me.Panel263)
Me.TabPage8.Controls.Add(Me.Panel264)
Me.TabPage8.Controls.Add(Me.Panel265)
Me.TabPage8.Controls.Add(Me.Panel266)
Me.TabPage8.Controls.Add(Me.Panel267)
Me.TabPage8.Controls.Add(Me.Panel268)
Me.TabPage8.Controls.Add(Me.Panel269)
Me.TabPage8.Controls.Add(Me.Panel270)
Me.TabPage8.Controls.Add(Me.Panel271)
Me.TabPage8.Controls.Add(Me.Panel272)
Me.TabPage8.Controls.Add(Me.Panel273)
Me.TabPage8.Controls.Add(Me.Panel274)
Me.TabPage8.Controls.Add(Me.Panel275)
Me.TabPage8.Controls.Add(Me.Panel276)
Me.TabPage8.Controls.Add(Me.Panel277)
Me.TabPage8.Controls.Add(Me.Panel278)
Me.TabPage8.Controls.Add(Me.Panel279)
Me.TabPage8.Controls.Add(Me.Panel280)
Me.TabPage8.Controls.Add(Me.Panel281)
Me.TabPage8.Controls.Add(Me.Panel282)
Me.TabPage8.Controls.Add(Me.Panel283)
Me.TabPage8.Controls.Add(Me.Panel284)
Me.TabPage8.Controls.Add(Me.Panel285)
Me.TabPage8.Controls.Add(Me.Panel286)
Me.TabPage8.Controls.Add(Me.Panel287)
Me.TabPage8.Controls.Add(Me.Panel288)
Me.TabPage8.Controls.Add(Me.Panel289)
Me.TabPage8.Controls.Add(Me.Panel290)
Me.TabPage8.Controls.Add(Me.Panel291)
Me.TabPage8.Controls.Add(Me.Panel292)
Me.TabPage8.Controls.Add(Me.Panel323)
Me.TabPage8.Controls.Add(Me.Panel324)
Me.TabPage8.Controls.Add(Me.Panel325)
Me.TabPage8.Controls.Add(Me.Panel326)
Me.TabPage8.Controls.Add(Me.Panel327)
Me.TabPage8.Controls.Add(Me.Panel328)
Me.TabPage8.Controls.Add(Me.Panel329)
Me.TabPage8.Location = New System.Drawing.Point(4, 22)
Me.TabPage8.Name = "TabPage8"
Me.TabPage8.Size = New System.Drawing.Size(968, 222)
Me.TabPage8.TabIndex = 2
Me.TabPage8.Text = "15 bar"
Me.TabPage8.Visible = false
'
'Panel258
'
Me.Panel258.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel258.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel258.Controls.Add(Me.TextBox273)
Me.Panel258.Controls.Add(Me.TextBox274)
Me.Panel258.Location = New System.Drawing.Point(380, 111)
Me.Panel258.Name = "Panel258"
Me.Panel258.Size = New System.Drawing.Size(89, 24)
Me.Panel258.TabIndex = 64
'
'TextBox273
'
Me.TextBox273.Location = New System.Drawing.Point(3, 2)
Me.TextBox273.Name = "TextBox273"
Me.TextBox273.ReadOnly = true
Me.TextBox273.Size = New System.Drawing.Size(40, 20)
Me.TextBox273.TabIndex = 8
Me.TextBox273.Text = ""
'
'TextBox274
'
Me.TextBox274.Location = New System.Drawing.Point(46, 2)
Me.TextBox274.Name = "TextBox274"
Me.TextBox274.ReadOnly = true
Me.TextBox274.Size = New System.Drawing.Size(40, 20)
Me.TextBox274.TabIndex = 7
Me.TextBox274.Text = ""
'
'Panel259
'
Me.Panel259.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel259.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel259.Controls.Add(Me.TextBox275)
Me.Panel259.Controls.Add(Me.TextBox276)
Me.Panel259.Location = New System.Drawing.Point(732, 111)
Me.Panel259.Name = "Panel259"
Me.Panel259.Size = New System.Drawing.Size(89, 24)
Me.Panel259.TabIndex = 63
'
'TextBox275
'
Me.TextBox275.Location = New System.Drawing.Point(3, 2)
Me.TextBox275.Name = "TextBox275"
Me.TextBox275.ReadOnly = true
Me.TextBox275.Size = New System.Drawing.Size(40, 20)
Me.TextBox275.TabIndex = 8
Me.TextBox275.Text = ""
'
'TextBox276
'
Me.TextBox276.Location = New System.Drawing.Point(46, 2)
Me.TextBox276.Name = "TextBox276"
Me.TextBox276.ReadOnly = true
Me.TextBox276.Size = New System.Drawing.Size(40, 20)
Me.TextBox276.TabIndex = 7
Me.TextBox276.Text = ""
'
'Panel260
'
Me.Panel260.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel260.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel260.Controls.Add(Me.TextBox277)
Me.Panel260.Controls.Add(Me.TextBox278)
Me.Panel260.Location = New System.Drawing.Point(556, 111)
Me.Panel260.Name = "Panel260"
Me.Panel260.Size = New System.Drawing.Size(89, 24)
Me.Panel260.TabIndex = 65
'
'TextBox277
'
Me.TextBox277.Location = New System.Drawing.Point(3, 2)
Me.TextBox277.Name = "TextBox277"
Me.TextBox277.ReadOnly = true
Me.TextBox277.Size = New System.Drawing.Size(40, 20)
Me.TextBox277.TabIndex = 8
Me.TextBox277.Text = ""
'
'TextBox278
'
Me.TextBox278.Location = New System.Drawing.Point(46, 2)
Me.TextBox278.Name = "TextBox278"
Me.TextBox278.ReadOnly = true
Me.TextBox278.Size = New System.Drawing.Size(40, 20)
Me.TextBox278.TabIndex = 7
Me.TextBox278.Text = ""
'
'Panel261
'
Me.Panel261.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel261.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel261.Controls.Add(Me.TextBox279)
Me.Panel261.Controls.Add(Me.TextBox280)
Me.Panel261.Location = New System.Drawing.Point(644, 111)
Me.Panel261.Name = "Panel261"
Me.Panel261.Size = New System.Drawing.Size(89, 24)
Me.Panel261.TabIndex = 67
'
'TextBox279
'
Me.TextBox279.Location = New System.Drawing.Point(3, 2)
Me.TextBox279.Name = "TextBox279"
Me.TextBox279.ReadOnly = true
Me.TextBox279.Size = New System.Drawing.Size(40, 20)
Me.TextBox279.TabIndex = 8
Me.TextBox279.Text = ""
'
'TextBox280
'
Me.TextBox280.Location = New System.Drawing.Point(46, 2)
Me.TextBox280.Name = "TextBox280"
Me.TextBox280.ReadOnly = true
Me.TextBox280.Size = New System.Drawing.Size(40, 20)
Me.TextBox280.TabIndex = 7
Me.TextBox280.Text = ""
'
'Panel262
'
Me.Panel262.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel262.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel262.Controls.Add(Me.TextBox281)
Me.Panel262.Controls.Add(Me.TextBox282)
Me.Panel262.Location = New System.Drawing.Point(292, 111)
Me.Panel262.Name = "Panel262"
Me.Panel262.Size = New System.Drawing.Size(89, 24)
Me.Panel262.TabIndex = 66
'
'TextBox281
'
Me.TextBox281.Location = New System.Drawing.Point(3, 2)
Me.TextBox281.Name = "TextBox281"
Me.TextBox281.ReadOnly = true
Me.TextBox281.Size = New System.Drawing.Size(40, 20)
Me.TextBox281.TabIndex = 8
Me.TextBox281.Text = ""
'
'TextBox282
'
Me.TextBox282.Location = New System.Drawing.Point(46, 2)
Me.TextBox282.Name = "TextBox282"
Me.TextBox282.ReadOnly = true
Me.TextBox282.Size = New System.Drawing.Size(40, 20)
Me.TextBox282.TabIndex = 7
Me.TextBox282.Text = ""
'
'Panel263
'
Me.Panel263.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel263.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel263.Controls.Add(Me.TextBox283)
Me.Panel263.Controls.Add(Me.TextBox284)
Me.Panel263.Location = New System.Drawing.Point(468, 111)
Me.Panel263.Name = "Panel263"
Me.Panel263.Size = New System.Drawing.Size(89, 24)
Me.Panel263.TabIndex = 73
'
'TextBox283
'
Me.TextBox283.Location = New System.Drawing.Point(3, 2)
Me.TextBox283.Name = "TextBox283"
Me.TextBox283.ReadOnly = true
Me.TextBox283.Size = New System.Drawing.Size(40, 20)
Me.TextBox283.TabIndex = 8
Me.TextBox283.Text = ""
'
'TextBox284
'
Me.TextBox284.Location = New System.Drawing.Point(46, 2)
Me.TextBox284.Name = "TextBox284"
Me.TextBox284.ReadOnly = true
Me.TextBox284.Size = New System.Drawing.Size(40, 20)
Me.TextBox284.TabIndex = 7
Me.TextBox284.Text = ""
'
'Panel264
'
Me.Panel264.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel264.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel264.Controls.Add(Me.TextBox285)
Me.Panel264.Controls.Add(Me.TextBox286)
Me.Panel264.Location = New System.Drawing.Point(556, 135)
Me.Panel264.Name = "Panel264"
Me.Panel264.Size = New System.Drawing.Size(89, 24)
Me.Panel264.TabIndex = 80
'
'TextBox285
'
Me.TextBox285.Location = New System.Drawing.Point(3, 2)
Me.TextBox285.Name = "TextBox285"
Me.TextBox285.ReadOnly = true
Me.TextBox285.Size = New System.Drawing.Size(40, 20)
Me.TextBox285.TabIndex = 8
Me.TextBox285.Text = ""
'
'TextBox286
'
Me.TextBox286.Location = New System.Drawing.Point(46, 2)
Me.TextBox286.Name = "TextBox286"
Me.TextBox286.ReadOnly = true
Me.TextBox286.Size = New System.Drawing.Size(40, 20)
Me.TextBox286.TabIndex = 7
Me.TextBox286.Text = ""
'
'Panel265
'
Me.Panel265.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel265.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel265.Controls.Add(Me.TextBox287)
Me.Panel265.Controls.Add(Me.TextBox288)
Me.Panel265.Location = New System.Drawing.Point(644, 135)
Me.Panel265.Name = "Panel265"
Me.Panel265.Size = New System.Drawing.Size(89, 24)
Me.Panel265.TabIndex = 79
'
'TextBox287
'
Me.TextBox287.Location = New System.Drawing.Point(3, 2)
Me.TextBox287.Name = "TextBox287"
Me.TextBox287.ReadOnly = true
Me.TextBox287.Size = New System.Drawing.Size(40, 20)
Me.TextBox287.TabIndex = 8
Me.TextBox287.Text = ""
'
'TextBox288
'
Me.TextBox288.Location = New System.Drawing.Point(46, 2)
Me.TextBox288.Name = "TextBox288"
Me.TextBox288.ReadOnly = true
Me.TextBox288.Size = New System.Drawing.Size(40, 20)
Me.TextBox288.TabIndex = 7
Me.TextBox288.Text = ""
'
'Panel266
'
Me.Panel266.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel266.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel266.Controls.Add(Me.TextBox289)
Me.Panel266.Controls.Add(Me.TextBox290)
Me.Panel266.Location = New System.Drawing.Point(732, 135)
Me.Panel266.Name = "Panel266"
Me.Panel266.Size = New System.Drawing.Size(89, 24)
Me.Panel266.TabIndex = 81
'
'TextBox289
'
Me.TextBox289.Location = New System.Drawing.Point(3, 2)
Me.TextBox289.Name = "TextBox289"
Me.TextBox289.ReadOnly = true
Me.TextBox289.Size = New System.Drawing.Size(40, 20)
Me.TextBox289.TabIndex = 8
Me.TextBox289.Text = ""
'
'TextBox290
'
Me.TextBox290.Location = New System.Drawing.Point(46, 2)
Me.TextBox290.Name = "TextBox290"
Me.TextBox290.ReadOnly = true
Me.TextBox290.Size = New System.Drawing.Size(40, 20)
Me.TextBox290.TabIndex = 7
Me.TextBox290.Text = ""
'
'Panel267
'
Me.Panel267.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel267.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel267.Controls.Add(Me.TextBox291)
Me.Panel267.Controls.Add(Me.TextBox292)
Me.Panel267.Location = New System.Drawing.Point(380, 135)
Me.Panel267.Name = "Panel267"
Me.Panel267.Size = New System.Drawing.Size(89, 24)
Me.Panel267.TabIndex = 83
'
'TextBox291
'
Me.TextBox291.Location = New System.Drawing.Point(3, 2)
Me.TextBox291.Name = "TextBox291"
Me.TextBox291.ReadOnly = true
Me.TextBox291.Size = New System.Drawing.Size(40, 20)
Me.TextBox291.TabIndex = 8
Me.TextBox291.Text = ""
'
'TextBox292
'
Me.TextBox292.Location = New System.Drawing.Point(46, 2)
Me.TextBox292.Name = "TextBox292"
Me.TextBox292.ReadOnly = true
Me.TextBox292.Size = New System.Drawing.Size(40, 20)
Me.TextBox292.TabIndex = 7
Me.TextBox292.Text = ""
'
'Panel268
'
Me.Panel268.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel268.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel268.Controls.Add(Me.TextBox293)
Me.Panel268.Controls.Add(Me.TextBox294)
Me.Panel268.Location = New System.Drawing.Point(292, 135)
Me.Panel268.Name = "Panel268"
Me.Panel268.Size = New System.Drawing.Size(89, 24)
Me.Panel268.TabIndex = 82
'
'TextBox293
'
Me.TextBox293.Location = New System.Drawing.Point(3, 2)
Me.TextBox293.Name = "TextBox293"
Me.TextBox293.ReadOnly = true
Me.TextBox293.Size = New System.Drawing.Size(40, 20)
Me.TextBox293.TabIndex = 8
Me.TextBox293.Text = ""
'
'TextBox294
'
Me.TextBox294.Location = New System.Drawing.Point(46, 2)
Me.TextBox294.Name = "TextBox294"
Me.TextBox294.ReadOnly = true
Me.TextBox294.Size = New System.Drawing.Size(40, 20)
Me.TextBox294.TabIndex = 7
Me.TextBox294.Text = ""
'
'Panel269
'
Me.Panel269.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel269.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel269.Controls.Add(Me.TextBox295)
Me.Panel269.Controls.Add(Me.TextBox296)
Me.Panel269.Location = New System.Drawing.Point(468, 135)
Me.Panel269.Name = "Panel269"
Me.Panel269.Size = New System.Drawing.Size(89, 24)
Me.Panel269.TabIndex = 75
'
'TextBox295
'
Me.TextBox295.Location = New System.Drawing.Point(3, 2)
Me.TextBox295.Name = "TextBox295"
Me.TextBox295.ReadOnly = true
Me.TextBox295.Size = New System.Drawing.Size(40, 20)
Me.TextBox295.TabIndex = 8
Me.TextBox295.Text = ""
'
'TextBox296
'
Me.TextBox296.Location = New System.Drawing.Point(46, 2)
Me.TextBox296.Name = "TextBox296"
Me.TextBox296.ReadOnly = true
Me.TextBox296.Size = New System.Drawing.Size(40, 20)
Me.TextBox296.TabIndex = 7
Me.TextBox296.Text = ""
'
'Panel270
'
Me.Panel270.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel270.Controls.Add(Me.TextBox297)
Me.Panel270.Location = New System.Drawing.Point(292, 159)
Me.Panel270.Name = "Panel270"
Me.Panel270.Size = New System.Drawing.Size(89, 24)
Me.Panel270.TabIndex = 74
'
'TextBox297
'
Me.TextBox297.Location = New System.Drawing.Point(3, 2)
Me.TextBox297.Name = "TextBox297"
Me.TextBox297.ReadOnly = true
Me.TextBox297.Size = New System.Drawing.Size(83, 20)
Me.TextBox297.TabIndex = 8
Me.TextBox297.Text = ""
'
'Panel271
'
Me.Panel271.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel271.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel271.Controls.Add(Me.Label163)
Me.Panel271.Location = New System.Drawing.Point(292, 39)
Me.Panel271.Name = "Panel271"
Me.Panel271.Size = New System.Drawing.Size(89, 24)
Me.Panel271.TabIndex = 88
'
'Label163
'
Me.Label163.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label163.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label163.Location = New System.Drawing.Point(8, 4)
Me.Label163.Name = "Label163"
Me.Label163.Size = New System.Drawing.Size(80, 16)
Me.Label163.TabIndex = 6
Me.Label163.Text = "1"
Me.Label163.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel272
'
Me.Panel272.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel272.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel272.Controls.Add(Me.TextBox298)
Me.Panel272.Location = New System.Drawing.Point(292, 183)
Me.Panel272.Name = "Panel272"
Me.Panel272.Size = New System.Drawing.Size(89, 24)
Me.Panel272.TabIndex = 76
'
'TextBox298
'
Me.TextBox298.Location = New System.Drawing.Point(3, 2)
Me.TextBox298.Name = "TextBox298"
Me.TextBox298.ReadOnly = true
Me.TextBox298.Size = New System.Drawing.Size(83, 20)
Me.TextBox298.TabIndex = 8
Me.TextBox298.Text = ""
'
'Panel273
'
Me.Panel273.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel273.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel273.Controls.Add(Me.Label164)
Me.Panel273.Location = New System.Drawing.Point(380, 159)
Me.Panel273.Name = "Panel273"
Me.Panel273.Size = New System.Drawing.Size(177, 48)
Me.Panel273.TabIndex = 78
'
'Label164
'
Me.Label164.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label164.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label164.Location = New System.Drawing.Point(8, 16)
Me.Label164.Name = "Label164"
Me.Label164.Size = New System.Drawing.Size(160, 16)
Me.Label164.TabIndex = 6
Me.Label164.Text = "Hétérogénité d'alimentation :"
Me.Label164.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel274
'
Me.Panel274.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel274.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel274.Controls.Add(Me.Label165)
Me.Panel274.Controls.Add(Me.Label166)
Me.Panel274.Controls.Add(Me.TextBox299)
Me.Panel274.Controls.Add(Me.TextBox300)
Me.Panel274.Location = New System.Drawing.Point(148, 15)
Me.Panel274.Name = "Panel274"
Me.Panel274.Size = New System.Drawing.Size(673, 24)
Me.Panel274.TabIndex = 90
'
'Label165
'
Me.Label165.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label165.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label165.Location = New System.Drawing.Point(8, 4)
Me.Label165.Name = "Label165"
Me.Label165.Size = New System.Drawing.Size(128, 16)
Me.Label165.TabIndex = 6
Me.Label165.Text = "Pression Mano Pulvé :"
Me.Label165.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label166
'
Me.Label166.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label166.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label166.Location = New System.Drawing.Point(392, 4)
Me.Label166.Name = "Label166"
Me.Label166.Size = New System.Drawing.Size(136, 16)
Me.Label166.TabIndex = 6
Me.Label166.Text = "Moyenne des pressions :"
Me.Label166.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox299
'
Me.TextBox299.Location = New System.Drawing.Point(144, 2)
Me.TextBox299.Name = "TextBox299"
Me.TextBox299.ReadOnly = true
Me.TextBox299.Size = New System.Drawing.Size(83, 20)
Me.TextBox299.TabIndex = 8
Me.TextBox299.Text = "15"
'
'TextBox300
'
Me.TextBox300.Location = New System.Drawing.Point(536, 2)
Me.TextBox300.Name = "TextBox300"
Me.TextBox300.ReadOnly = true
Me.TextBox300.Size = New System.Drawing.Size(83, 20)
Me.TextBox300.TabIndex = 8
Me.TextBox300.Text = ""
'
'Panel275
'
Me.Panel275.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel275.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel275.Controls.Add(Me.Label167)
Me.Panel275.Controls.Add(Me.Label168)
Me.Panel275.Location = New System.Drawing.Point(556, 159)
Me.Panel275.Name = "Panel275"
Me.Panel275.Size = New System.Drawing.Size(265, 48)
Me.Panel275.TabIndex = 77
'
'Label167
'
Me.Label167.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label167.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label167.Location = New System.Drawing.Point(48, 16)
Me.Label167.Name = "Label167"
Me.Label167.Size = New System.Drawing.Size(168, 16)
Me.Label167.TabIndex = 29
Me.Label167.Text = "OK"
Me.Label167.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label168
'
Me.Label168.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label168.ForeColor = System.Drawing.Color.Red
Me.Label168.Location = New System.Drawing.Point(48, 16)
Me.Label168.Name = "Label168"
Me.Label168.Size = New System.Drawing.Size(168, 16)
Me.Label168.TabIndex = 28
Me.Label168.Text = "DEFAUT"
Me.Label168.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel276
'
Me.Panel276.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel276.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel276.Controls.Add(Me.Label169)
Me.Panel276.Controls.Add(Me.Label170)
Me.Panel276.Location = New System.Drawing.Point(292, 63)
Me.Panel276.Name = "Panel276"
Me.Panel276.Size = New System.Drawing.Size(89, 24)
Me.Panel276.TabIndex = 87
'
'Label169
'
Me.Label169.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label169.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label169.Location = New System.Drawing.Point(8, 4)
Me.Label169.Name = "Label169"
Me.Label169.Size = New System.Drawing.Size(40, 16)
Me.Label169.TabIndex = 6
Me.Label169.Text = "G"
Me.Label169.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label170
'
Me.Label170.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label170.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label170.Location = New System.Drawing.Point(48, 4)
Me.Label170.Name = "Label170"
Me.Label170.Size = New System.Drawing.Size(40, 16)
Me.Label170.TabIndex = 6
Me.Label170.Text = "D"
Me.Label170.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel277
'
Me.Panel277.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel277.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel277.Controls.Add(Me.Label171)
Me.Panel277.Controls.Add(Me.Label172)
Me.Panel277.Location = New System.Drawing.Point(380, 63)
Me.Panel277.Name = "Panel277"
Me.Panel277.Size = New System.Drawing.Size(89, 24)
Me.Panel277.TabIndex = 94
'
'Label171
'
Me.Label171.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label171.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label171.Location = New System.Drawing.Point(8, 4)
Me.Label171.Name = "Label171"
Me.Label171.Size = New System.Drawing.Size(40, 16)
Me.Label171.TabIndex = 6
Me.Label171.Text = "G"
Me.Label171.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label172
'
Me.Label172.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label172.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label172.Location = New System.Drawing.Point(48, 4)
Me.Label172.Name = "Label172"
Me.Label172.Size = New System.Drawing.Size(40, 16)
Me.Label172.TabIndex = 6
Me.Label172.Text = "D"
Me.Label172.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel278
'
Me.Panel278.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel278.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel278.Controls.Add(Me.Label173)
Me.Panel278.Location = New System.Drawing.Point(380, 39)
Me.Panel278.Name = "Panel278"
Me.Panel278.Size = New System.Drawing.Size(89, 24)
Me.Panel278.TabIndex = 101
'
'Label173
'
Me.Label173.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label173.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label173.Location = New System.Drawing.Point(8, 4)
Me.Label173.Name = "Label173"
Me.Label173.Size = New System.Drawing.Size(80, 16)
Me.Label173.TabIndex = 6
Me.Label173.Text = "2"
Me.Label173.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel279
'
Me.Panel279.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel279.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel279.Controls.Add(Me.Label174)
Me.Panel279.Location = New System.Drawing.Point(148, 87)
Me.Panel279.Name = "Panel279"
Me.Panel279.Size = New System.Drawing.Size(144, 24)
Me.Panel279.TabIndex = 93
'
'Label174
'
Me.Label174.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label174.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label174.Location = New System.Drawing.Point(8, 4)
Me.Label174.Name = "Label174"
Me.Label174.Size = New System.Drawing.Size(128, 16)
Me.Label174.TabIndex = 6
Me.Label174.Text = "P sortie"
Me.Label174.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel280
'
Me.Panel280.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel280.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel280.Controls.Add(Me.Label175)
Me.Panel280.Location = New System.Drawing.Point(148, 111)
Me.Panel280.Name = "Panel280"
Me.Panel280.Size = New System.Drawing.Size(144, 24)
Me.Panel280.TabIndex = 92
'
'Label175
'
Me.Label175.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label175.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label175.Location = New System.Drawing.Point(8, 4)
Me.Label175.Name = "Label175"
Me.Label175.Size = New System.Drawing.Size(128, 16)
Me.Label175.TabIndex = 6
Me.Label175.Text = "Ecart"
Me.Label175.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel281
'
Me.Panel281.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel281.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel281.Controls.Add(Me.Label176)
Me.Panel281.Location = New System.Drawing.Point(148, 135)
Me.Panel281.Name = "Panel281"
Me.Panel281.Size = New System.Drawing.Size(144, 24)
Me.Panel281.TabIndex = 85
'
'Label176
'
Me.Label176.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label176.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label176.Location = New System.Drawing.Point(8, 4)
Me.Label176.Name = "Label176"
Me.Label176.Size = New System.Drawing.Size(128, 16)
Me.Label176.TabIndex = 6
Me.Label176.Text = "Perte charge"
Me.Label176.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel282
'
Me.Panel282.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel282.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel282.Controls.Add(Me.Label177)
Me.Panel282.Location = New System.Drawing.Point(148, 159)
Me.Panel282.Name = "Panel282"
Me.Panel282.Size = New System.Drawing.Size(144, 24)
Me.Panel282.TabIndex = 84
'
'Label177
'
Me.Label177.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label177.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label177.Location = New System.Drawing.Point(8, 4)
Me.Label177.Name = "Label177"
Me.Label177.Size = New System.Drawing.Size(128, 16)
Me.Label177.TabIndex = 6
Me.Label177.Text = "Perte de charge moy"
Me.Label177.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel283
'
Me.Panel283.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel283.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel283.Controls.Add(Me.Label178)
Me.Panel283.Location = New System.Drawing.Point(148, 183)
Me.Panel283.Name = "Panel283"
Me.Panel283.Size = New System.Drawing.Size(144, 24)
Me.Panel283.TabIndex = 86
'
'Label178
'
Me.Label178.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label178.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label178.Location = New System.Drawing.Point(8, 4)
Me.Label178.Name = "Label178"
Me.Label178.Size = New System.Drawing.Size(128, 16)
Me.Label178.TabIndex = 6
Me.Label178.Text = "Perte de charge max"
Me.Label178.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel284
'
Me.Panel284.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel284.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel284.Controls.Add(Me.Label179)
Me.Panel284.Location = New System.Drawing.Point(148, 39)
Me.Panel284.Name = "Panel284"
Me.Panel284.Size = New System.Drawing.Size(144, 24)
Me.Panel284.TabIndex = 89
'
'Label179
'
Me.Label179.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label179.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label179.Location = New System.Drawing.Point(8, 4)
Me.Label179.Name = "Label179"
Me.Label179.Size = New System.Drawing.Size(128, 16)
Me.Label179.TabIndex = 6
Me.Label179.Text = "Niveau"
Me.Label179.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel285
'
Me.Panel285.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel285.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel285.Controls.Add(Me.Label180)
Me.Panel285.Location = New System.Drawing.Point(148, 63)
Me.Panel285.Name = "Panel285"
Me.Panel285.Size = New System.Drawing.Size(144, 24)
Me.Panel285.TabIndex = 91
'
'Label180
'
Me.Label180.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label180.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label180.Location = New System.Drawing.Point(8, 4)
Me.Label180.Name = "Label180"
Me.Label180.Size = New System.Drawing.Size(128, 16)
Me.Label180.TabIndex = 6
Me.Label180.Text = "Section Gauche/Droite"
Me.Label180.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel286
'
Me.Panel286.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel286.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel286.Controls.Add(Me.Label181)
Me.Panel286.Location = New System.Drawing.Point(468, 39)
Me.Panel286.Name = "Panel286"
Me.Panel286.Size = New System.Drawing.Size(89, 24)
Me.Panel286.TabIndex = 100
'
'Label181
'
Me.Label181.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label181.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label181.Location = New System.Drawing.Point(8, 4)
Me.Label181.Name = "Label181"
Me.Label181.Size = New System.Drawing.Size(80, 16)
Me.Label181.TabIndex = 6
Me.Label181.Text = "3"
Me.Label181.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel287
'
Me.Panel287.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel287.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel287.Controls.Add(Me.Label182)
Me.Panel287.Controls.Add(Me.Label183)
Me.Panel287.Location = New System.Drawing.Point(468, 63)
Me.Panel287.Name = "Panel287"
Me.Panel287.Size = New System.Drawing.Size(89, 24)
Me.Panel287.TabIndex = 102
'
'Label182
'
Me.Label182.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label182.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label182.Location = New System.Drawing.Point(8, 4)
Me.Label182.Name = "Label182"
Me.Label182.Size = New System.Drawing.Size(40, 16)
Me.Label182.TabIndex = 6
Me.Label182.Text = "G"
Me.Label182.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label183
'
Me.Label183.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label183.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label183.Location = New System.Drawing.Point(48, 4)
Me.Label183.Name = "Label183"
Me.Label183.Size = New System.Drawing.Size(40, 16)
Me.Label183.TabIndex = 6
Me.Label183.Text = "D"
Me.Label183.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel288
'
Me.Panel288.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel288.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel288.Controls.Add(Me.Label184)
Me.Panel288.Controls.Add(Me.Label185)
Me.Panel288.Location = New System.Drawing.Point(556, 63)
Me.Panel288.Name = "Panel288"
Me.Panel288.Size = New System.Drawing.Size(89, 24)
Me.Panel288.TabIndex = 104
'
'Label184
'
Me.Label184.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label184.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label184.Location = New System.Drawing.Point(8, 4)
Me.Label184.Name = "Label184"
Me.Label184.Size = New System.Drawing.Size(40, 16)
Me.Label184.TabIndex = 6
Me.Label184.Text = "G"
Me.Label184.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label185
'
Me.Label185.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label185.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label185.Location = New System.Drawing.Point(48, 4)
Me.Label185.Name = "Label185"
Me.Label185.Size = New System.Drawing.Size(40, 16)
Me.Label185.TabIndex = 6
Me.Label185.Text = "D"
Me.Label185.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel289
'
Me.Panel289.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel289.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel289.Controls.Add(Me.Label186)
Me.Panel289.Location = New System.Drawing.Point(556, 39)
Me.Panel289.Name = "Panel289"
Me.Panel289.Size = New System.Drawing.Size(89, 24)
Me.Panel289.TabIndex = 103
'
'Label186
'
Me.Label186.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label186.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label186.Location = New System.Drawing.Point(8, 4)
Me.Label186.Name = "Label186"
Me.Label186.Size = New System.Drawing.Size(80, 16)
Me.Label186.TabIndex = 6
Me.Label186.Text = "4"
Me.Label186.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel290
'
Me.Panel290.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel290.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel290.Controls.Add(Me.Label187)
Me.Panel290.Location = New System.Drawing.Point(644, 39)
Me.Panel290.Name = "Panel290"
Me.Panel290.Size = New System.Drawing.Size(89, 24)
Me.Panel290.TabIndex = 96
'
'Label187
'
Me.Label187.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label187.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label187.Location = New System.Drawing.Point(8, 4)
Me.Label187.Name = "Label187"
Me.Label187.Size = New System.Drawing.Size(80, 16)
Me.Label187.TabIndex = 6
Me.Label187.Text = "5"
Me.Label187.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel291
'
Me.Panel291.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel291.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel291.Controls.Add(Me.Label188)
Me.Panel291.Controls.Add(Me.Label189)
Me.Panel291.Location = New System.Drawing.Point(644, 63)
Me.Panel291.Name = "Panel291"
Me.Panel291.Size = New System.Drawing.Size(89, 24)
Me.Panel291.TabIndex = 95
'
'Label188
'
Me.Label188.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label188.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label188.Location = New System.Drawing.Point(8, 4)
Me.Label188.Name = "Label188"
Me.Label188.Size = New System.Drawing.Size(40, 16)
Me.Label188.TabIndex = 6
Me.Label188.Text = "G"
Me.Label188.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label189
'
Me.Label189.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label189.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label189.Location = New System.Drawing.Point(48, 4)
Me.Label189.Name = "Label189"
Me.Label189.Size = New System.Drawing.Size(40, 16)
Me.Label189.TabIndex = 6
Me.Label189.Text = "D"
Me.Label189.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel292
'
Me.Panel292.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel292.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel292.Controls.Add(Me.Label190)
Me.Panel292.Controls.Add(Me.Label191)
Me.Panel292.Location = New System.Drawing.Point(732, 63)
Me.Panel292.Name = "Panel292"
Me.Panel292.Size = New System.Drawing.Size(89, 24)
Me.Panel292.TabIndex = 97
'
'Label190
'
Me.Label190.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label190.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label190.Location = New System.Drawing.Point(8, 4)
Me.Label190.Name = "Label190"
Me.Label190.Size = New System.Drawing.Size(40, 16)
Me.Label190.TabIndex = 6
Me.Label190.Text = "G"
Me.Label190.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label191
'
Me.Label191.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label191.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label191.Location = New System.Drawing.Point(48, 4)
Me.Label191.Name = "Label191"
Me.Label191.Size = New System.Drawing.Size(40, 16)
Me.Label191.TabIndex = 6
Me.Label191.Text = "D"
Me.Label191.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel323
'
Me.Panel323.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel323.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel323.Controls.Add(Me.Label192)
Me.Panel323.Location = New System.Drawing.Point(732, 39)
Me.Panel323.Name = "Panel323"
Me.Panel323.Size = New System.Drawing.Size(89, 24)
Me.Panel323.TabIndex = 99
'
'Label192
'
Me.Label192.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label192.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label192.Location = New System.Drawing.Point(8, 4)
Me.Label192.Name = "Label192"
Me.Label192.Size = New System.Drawing.Size(80, 16)
Me.Label192.TabIndex = 6
Me.Label192.Text = "6"
Me.Label192.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel324
'
Me.Panel324.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel324.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel324.Controls.Add(Me.TextBox301)
Me.Panel324.Controls.Add(Me.TextBox302)
Me.Panel324.Location = New System.Drawing.Point(292, 87)
Me.Panel324.Name = "Panel324"
Me.Panel324.Size = New System.Drawing.Size(89, 24)
Me.Panel324.TabIndex = 98
'
'TextBox301
'
Me.TextBox301.Location = New System.Drawing.Point(3, 2)
Me.TextBox301.Name = "TextBox301"
Me.TextBox301.Size = New System.Drawing.Size(40, 20)
Me.TextBox301.TabIndex = 8
Me.TextBox301.Text = ""
'
'TextBox302
'
Me.TextBox302.Location = New System.Drawing.Point(46, 2)
Me.TextBox302.Name = "TextBox302"
Me.TextBox302.Size = New System.Drawing.Size(40, 20)
Me.TextBox302.TabIndex = 7
Me.TextBox302.Text = ""
'
'Panel325
'
Me.Panel325.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel325.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel325.Controls.Add(Me.TextBox303)
Me.Panel325.Controls.Add(Me.TextBox304)
Me.Panel325.Location = New System.Drawing.Point(380, 87)
Me.Panel325.Name = "Panel325"
Me.Panel325.Size = New System.Drawing.Size(89, 24)
Me.Panel325.TabIndex = 69
'
'TextBox303
'
Me.TextBox303.Location = New System.Drawing.Point(3, 2)
Me.TextBox303.Name = "TextBox303"
Me.TextBox303.Size = New System.Drawing.Size(40, 20)
Me.TextBox303.TabIndex = 8
Me.TextBox303.Text = ""
'
'TextBox304
'
Me.TextBox304.Location = New System.Drawing.Point(46, 2)
Me.TextBox304.Name = "TextBox304"
Me.TextBox304.Size = New System.Drawing.Size(40, 20)
Me.TextBox304.TabIndex = 7
Me.TextBox304.Text = ""
'
'Panel326
'
Me.Panel326.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel326.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel326.Controls.Add(Me.TextBox305)
Me.Panel326.Controls.Add(Me.TextBox306)
Me.Panel326.Location = New System.Drawing.Point(468, 87)
Me.Panel326.Name = "Panel326"
Me.Panel326.Size = New System.Drawing.Size(89, 24)
Me.Panel326.TabIndex = 68
'
'TextBox305
'
Me.TextBox305.Location = New System.Drawing.Point(3, 2)
Me.TextBox305.Name = "TextBox305"
Me.TextBox305.Size = New System.Drawing.Size(40, 20)
Me.TextBox305.TabIndex = 8
Me.TextBox305.Text = ""
'
'TextBox306
'
Me.TextBox306.Location = New System.Drawing.Point(46, 2)
Me.TextBox306.Name = "TextBox306"
Me.TextBox306.Size = New System.Drawing.Size(40, 20)
Me.TextBox306.TabIndex = 7
Me.TextBox306.Text = ""
'
'Panel327
'
Me.Panel327.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel327.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel327.Controls.Add(Me.TextBox307)
Me.Panel327.Controls.Add(Me.TextBox308)
Me.Panel327.Location = New System.Drawing.Point(556, 87)
Me.Panel327.Name = "Panel327"
Me.Panel327.Size = New System.Drawing.Size(89, 24)
Me.Panel327.TabIndex = 70
'
'TextBox307
'
Me.TextBox307.Location = New System.Drawing.Point(3, 2)
Me.TextBox307.Name = "TextBox307"
Me.TextBox307.Size = New System.Drawing.Size(40, 20)
Me.TextBox307.TabIndex = 8
Me.TextBox307.Text = ""
'
'TextBox308
'
Me.TextBox308.Location = New System.Drawing.Point(46, 2)
Me.TextBox308.Name = "TextBox308"
Me.TextBox308.Size = New System.Drawing.Size(40, 20)
Me.TextBox308.TabIndex = 7
Me.TextBox308.Text = ""
'
'Panel328
'
Me.Panel328.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel328.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel328.Controls.Add(Me.TextBox309)
Me.Panel328.Controls.Add(Me.TextBox310)
Me.Panel328.Location = New System.Drawing.Point(644, 87)
Me.Panel328.Name = "Panel328"
Me.Panel328.Size = New System.Drawing.Size(89, 24)
Me.Panel328.TabIndex = 72
'
'TextBox309
'
Me.TextBox309.Location = New System.Drawing.Point(3, 2)
Me.TextBox309.Name = "TextBox309"
Me.TextBox309.Size = New System.Drawing.Size(40, 20)
Me.TextBox309.TabIndex = 8
Me.TextBox309.Text = ""
'
'TextBox310
'
Me.TextBox310.Location = New System.Drawing.Point(46, 2)
Me.TextBox310.Name = "TextBox310"
Me.TextBox310.Size = New System.Drawing.Size(40, 20)
Me.TextBox310.TabIndex = 7
Me.TextBox310.Text = ""
'
'Panel329
'
Me.Panel329.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel329.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel329.Controls.Add(Me.TextBox311)
Me.Panel329.Controls.Add(Me.TextBox312)
Me.Panel329.Location = New System.Drawing.Point(732, 87)
Me.Panel329.Name = "Panel329"
Me.Panel329.Size = New System.Drawing.Size(89, 24)
Me.Panel329.TabIndex = 71
'
'TextBox311
'
Me.TextBox311.Location = New System.Drawing.Point(3, 2)
Me.TextBox311.Name = "TextBox311"
Me.TextBox311.Size = New System.Drawing.Size(40, 20)
Me.TextBox311.TabIndex = 8
Me.TextBox311.Text = ""
'
'TextBox312
'
Me.TextBox312.Location = New System.Drawing.Point(46, 2)
Me.TextBox312.Name = "TextBox312"
Me.TextBox312.Size = New System.Drawing.Size(40, 20)
Me.TextBox312.TabIndex = 7
Me.TextBox312.Text = ""
'
'TabPage9
'
Me.TabPage9.Controls.Add(Me.Panel330)
Me.TabPage9.Controls.Add(Me.Panel331)
Me.TabPage9.Controls.Add(Me.Panel332)
Me.TabPage9.Controls.Add(Me.Panel333)
Me.TabPage9.Controls.Add(Me.Panel334)
Me.TabPage9.Controls.Add(Me.Panel335)
Me.TabPage9.Controls.Add(Me.Panel336)
Me.TabPage9.Controls.Add(Me.Panel337)
Me.TabPage9.Controls.Add(Me.Panel338)
Me.TabPage9.Controls.Add(Me.Panel339)
Me.TabPage9.Controls.Add(Me.Panel340)
Me.TabPage9.Controls.Add(Me.Panel341)
Me.TabPage9.Controls.Add(Me.Panel342)
Me.TabPage9.Controls.Add(Me.Panel343)
Me.TabPage9.Controls.Add(Me.Panel344)
Me.TabPage9.Controls.Add(Me.Panel345)
Me.TabPage9.Controls.Add(Me.Panel346)
Me.TabPage9.Controls.Add(Me.Panel347)
Me.TabPage9.Controls.Add(Me.Panel348)
Me.TabPage9.Controls.Add(Me.Panel349)
Me.TabPage9.Controls.Add(Me.Panel350)
Me.TabPage9.Controls.Add(Me.Panel351)
Me.TabPage9.Controls.Add(Me.Panel352)
Me.TabPage9.Controls.Add(Me.Panel353)
Me.TabPage9.Controls.Add(Me.Panel354)
Me.TabPage9.Controls.Add(Me.Panel355)
Me.TabPage9.Controls.Add(Me.Panel356)
Me.TabPage9.Controls.Add(Me.Panel357)
Me.TabPage9.Controls.Add(Me.Panel358)
Me.TabPage9.Controls.Add(Me.Panel359)
Me.TabPage9.Controls.Add(Me.Panel360)
Me.TabPage9.Controls.Add(Me.Panel361)
Me.TabPage9.Controls.Add(Me.Panel362)
Me.TabPage9.Controls.Add(Me.Panel363)
Me.TabPage9.Controls.Add(Me.Panel364)
Me.TabPage9.Controls.Add(Me.Panel365)
Me.TabPage9.Controls.Add(Me.Panel366)
Me.TabPage9.Controls.Add(Me.Panel367)
Me.TabPage9.Controls.Add(Me.Panel368)
Me.TabPage9.Controls.Add(Me.Panel369)
Me.TabPage9.Controls.Add(Me.Panel370)
Me.TabPage9.Controls.Add(Me.Panel371)
Me.TabPage9.Location = New System.Drawing.Point(4, 22)
Me.TabPage9.Name = "TabPage9"
Me.TabPage9.Size = New System.Drawing.Size(968, 222)
Me.TabPage9.TabIndex = 3
Me.TabPage9.Text = "20 bar"
Me.TabPage9.Visible = false
'
'Panel330
'
Me.Panel330.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel330.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel330.Controls.Add(Me.TextBox313)
Me.Panel330.Controls.Add(Me.TextBox314)
Me.Panel330.Location = New System.Drawing.Point(380, 111)
Me.Panel330.Name = "Panel330"
Me.Panel330.Size = New System.Drawing.Size(89, 24)
Me.Panel330.TabIndex = 64
'
'TextBox313
'
Me.TextBox313.Location = New System.Drawing.Point(3, 2)
Me.TextBox313.Name = "TextBox313"
Me.TextBox313.ReadOnly = true
Me.TextBox313.Size = New System.Drawing.Size(40, 20)
Me.TextBox313.TabIndex = 8
Me.TextBox313.Text = ""
'
'TextBox314
'
Me.TextBox314.Location = New System.Drawing.Point(46, 2)
Me.TextBox314.Name = "TextBox314"
Me.TextBox314.ReadOnly = true
Me.TextBox314.Size = New System.Drawing.Size(40, 20)
Me.TextBox314.TabIndex = 7
Me.TextBox314.Text = ""
'
'Panel331
'
Me.Panel331.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel331.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel331.Controls.Add(Me.TextBox315)
Me.Panel331.Controls.Add(Me.TextBox316)
Me.Panel331.Location = New System.Drawing.Point(732, 111)
Me.Panel331.Name = "Panel331"
Me.Panel331.Size = New System.Drawing.Size(89, 24)
Me.Panel331.TabIndex = 63
'
'TextBox315
'
Me.TextBox315.Location = New System.Drawing.Point(3, 2)
Me.TextBox315.Name = "TextBox315"
Me.TextBox315.ReadOnly = true
Me.TextBox315.Size = New System.Drawing.Size(40, 20)
Me.TextBox315.TabIndex = 8
Me.TextBox315.Text = ""
'
'TextBox316
'
Me.TextBox316.Location = New System.Drawing.Point(46, 2)
Me.TextBox316.Name = "TextBox316"
Me.TextBox316.ReadOnly = true
Me.TextBox316.Size = New System.Drawing.Size(40, 20)
Me.TextBox316.TabIndex = 7
Me.TextBox316.Text = ""
'
'Panel332
'
Me.Panel332.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel332.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel332.Controls.Add(Me.TextBox317)
Me.Panel332.Controls.Add(Me.TextBox318)
Me.Panel332.Location = New System.Drawing.Point(556, 111)
Me.Panel332.Name = "Panel332"
Me.Panel332.Size = New System.Drawing.Size(89, 24)
Me.Panel332.TabIndex = 65
'
'TextBox317
'
Me.TextBox317.Location = New System.Drawing.Point(3, 2)
Me.TextBox317.Name = "TextBox317"
Me.TextBox317.ReadOnly = true
Me.TextBox317.Size = New System.Drawing.Size(40, 20)
Me.TextBox317.TabIndex = 8
Me.TextBox317.Text = ""
'
'TextBox318
'
Me.TextBox318.Location = New System.Drawing.Point(46, 2)
Me.TextBox318.Name = "TextBox318"
Me.TextBox318.ReadOnly = true
Me.TextBox318.Size = New System.Drawing.Size(40, 20)
Me.TextBox318.TabIndex = 7
Me.TextBox318.Text = ""
'
'Panel333
'
Me.Panel333.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel333.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel333.Controls.Add(Me.TextBox319)
Me.Panel333.Controls.Add(Me.TextBox320)
Me.Panel333.Location = New System.Drawing.Point(644, 111)
Me.Panel333.Name = "Panel333"
Me.Panel333.Size = New System.Drawing.Size(89, 24)
Me.Panel333.TabIndex = 67
'
'TextBox319
'
Me.TextBox319.Location = New System.Drawing.Point(3, 2)
Me.TextBox319.Name = "TextBox319"
Me.TextBox319.ReadOnly = true
Me.TextBox319.Size = New System.Drawing.Size(40, 20)
Me.TextBox319.TabIndex = 8
Me.TextBox319.Text = ""
'
'TextBox320
'
Me.TextBox320.Location = New System.Drawing.Point(46, 2)
Me.TextBox320.Name = "TextBox320"
Me.TextBox320.ReadOnly = true
Me.TextBox320.Size = New System.Drawing.Size(40, 20)
Me.TextBox320.TabIndex = 7
Me.TextBox320.Text = ""
'
'Panel334
'
Me.Panel334.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel334.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel334.Controls.Add(Me.TextBox321)
Me.Panel334.Controls.Add(Me.TextBox322)
Me.Panel334.Location = New System.Drawing.Point(292, 111)
Me.Panel334.Name = "Panel334"
Me.Panel334.Size = New System.Drawing.Size(89, 24)
Me.Panel334.TabIndex = 66
'
'TextBox321
'
Me.TextBox321.Location = New System.Drawing.Point(3, 2)
Me.TextBox321.Name = "TextBox321"
Me.TextBox321.ReadOnly = true
Me.TextBox321.Size = New System.Drawing.Size(40, 20)
Me.TextBox321.TabIndex = 8
Me.TextBox321.Text = ""
'
'TextBox322
'
Me.TextBox322.Location = New System.Drawing.Point(46, 2)
Me.TextBox322.Name = "TextBox322"
Me.TextBox322.ReadOnly = true
Me.TextBox322.Size = New System.Drawing.Size(40, 20)
Me.TextBox322.TabIndex = 7
Me.TextBox322.Text = ""
'
'Panel335
'
Me.Panel335.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel335.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel335.Controls.Add(Me.TextBox323)
Me.Panel335.Controls.Add(Me.TextBox324)
Me.Panel335.Location = New System.Drawing.Point(468, 111)
Me.Panel335.Name = "Panel335"
Me.Panel335.Size = New System.Drawing.Size(89, 24)
Me.Panel335.TabIndex = 73
'
'TextBox323
'
Me.TextBox323.Location = New System.Drawing.Point(3, 2)
Me.TextBox323.Name = "TextBox323"
Me.TextBox323.ReadOnly = true
Me.TextBox323.Size = New System.Drawing.Size(40, 20)
Me.TextBox323.TabIndex = 8
Me.TextBox323.Text = ""
'
'TextBox324
'
Me.TextBox324.Location = New System.Drawing.Point(46, 2)
Me.TextBox324.Name = "TextBox324"
Me.TextBox324.ReadOnly = true
Me.TextBox324.Size = New System.Drawing.Size(40, 20)
Me.TextBox324.TabIndex = 7
Me.TextBox324.Text = ""
'
'Panel336
'
Me.Panel336.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel336.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel336.Controls.Add(Me.TextBox325)
Me.Panel336.Controls.Add(Me.TextBox326)
Me.Panel336.Location = New System.Drawing.Point(556, 135)
Me.Panel336.Name = "Panel336"
Me.Panel336.Size = New System.Drawing.Size(89, 24)
Me.Panel336.TabIndex = 80
'
'TextBox325
'
Me.TextBox325.Location = New System.Drawing.Point(3, 2)
Me.TextBox325.Name = "TextBox325"
Me.TextBox325.ReadOnly = true
Me.TextBox325.Size = New System.Drawing.Size(40, 20)
Me.TextBox325.TabIndex = 8
Me.TextBox325.Text = ""
'
'TextBox326
'
Me.TextBox326.Location = New System.Drawing.Point(46, 2)
Me.TextBox326.Name = "TextBox326"
Me.TextBox326.ReadOnly = true
Me.TextBox326.Size = New System.Drawing.Size(40, 20)
Me.TextBox326.TabIndex = 7
Me.TextBox326.Text = ""
'
'Panel337
'
Me.Panel337.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel337.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel337.Controls.Add(Me.TextBox327)
Me.Panel337.Controls.Add(Me.TextBox328)
Me.Panel337.Location = New System.Drawing.Point(644, 135)
Me.Panel337.Name = "Panel337"
Me.Panel337.Size = New System.Drawing.Size(89, 24)
Me.Panel337.TabIndex = 79
'
'TextBox327
'
Me.TextBox327.Location = New System.Drawing.Point(3, 2)
Me.TextBox327.Name = "TextBox327"
Me.TextBox327.ReadOnly = true
Me.TextBox327.Size = New System.Drawing.Size(40, 20)
Me.TextBox327.TabIndex = 8
Me.TextBox327.Text = ""
'
'TextBox328
'
Me.TextBox328.Location = New System.Drawing.Point(46, 2)
Me.TextBox328.Name = "TextBox328"
Me.TextBox328.ReadOnly = true
Me.TextBox328.Size = New System.Drawing.Size(40, 20)
Me.TextBox328.TabIndex = 7
Me.TextBox328.Text = ""
'
'Panel338
'
Me.Panel338.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel338.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel338.Controls.Add(Me.TextBox329)
Me.Panel338.Controls.Add(Me.TextBox330)
Me.Panel338.Location = New System.Drawing.Point(732, 135)
Me.Panel338.Name = "Panel338"
Me.Panel338.Size = New System.Drawing.Size(89, 24)
Me.Panel338.TabIndex = 81
'
'TextBox329
'
Me.TextBox329.Location = New System.Drawing.Point(3, 2)
Me.TextBox329.Name = "TextBox329"
Me.TextBox329.ReadOnly = true
Me.TextBox329.Size = New System.Drawing.Size(40, 20)
Me.TextBox329.TabIndex = 8
Me.TextBox329.Text = ""
'
'TextBox330
'
Me.TextBox330.Location = New System.Drawing.Point(46, 2)
Me.TextBox330.Name = "TextBox330"
Me.TextBox330.ReadOnly = true
Me.TextBox330.Size = New System.Drawing.Size(40, 20)
Me.TextBox330.TabIndex = 7
Me.TextBox330.Text = ""
'
'Panel339
'
Me.Panel339.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel339.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel339.Controls.Add(Me.TextBox331)
Me.Panel339.Controls.Add(Me.TextBox332)
Me.Panel339.Location = New System.Drawing.Point(380, 135)
Me.Panel339.Name = "Panel339"
Me.Panel339.Size = New System.Drawing.Size(89, 24)
Me.Panel339.TabIndex = 83
'
'TextBox331
'
Me.TextBox331.Location = New System.Drawing.Point(3, 2)
Me.TextBox331.Name = "TextBox331"
Me.TextBox331.ReadOnly = true
Me.TextBox331.Size = New System.Drawing.Size(40, 20)
Me.TextBox331.TabIndex = 8
Me.TextBox331.Text = ""
'
'TextBox332
'
Me.TextBox332.Location = New System.Drawing.Point(46, 2)
Me.TextBox332.Name = "TextBox332"
Me.TextBox332.ReadOnly = true
Me.TextBox332.Size = New System.Drawing.Size(40, 20)
Me.TextBox332.TabIndex = 7
Me.TextBox332.Text = ""
'
'Panel340
'
Me.Panel340.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel340.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel340.Controls.Add(Me.TextBox333)
Me.Panel340.Controls.Add(Me.TextBox334)
Me.Panel340.Location = New System.Drawing.Point(292, 135)
Me.Panel340.Name = "Panel340"
Me.Panel340.Size = New System.Drawing.Size(89, 24)
Me.Panel340.TabIndex = 82
'
'TextBox333
'
Me.TextBox333.Location = New System.Drawing.Point(3, 2)
Me.TextBox333.Name = "TextBox333"
Me.TextBox333.ReadOnly = true
Me.TextBox333.Size = New System.Drawing.Size(40, 20)
Me.TextBox333.TabIndex = 8
Me.TextBox333.Text = ""
'
'TextBox334
'
Me.TextBox334.Location = New System.Drawing.Point(46, 2)
Me.TextBox334.Name = "TextBox334"
Me.TextBox334.ReadOnly = true
Me.TextBox334.Size = New System.Drawing.Size(40, 20)
Me.TextBox334.TabIndex = 7
Me.TextBox334.Text = ""
'
'Panel341
'
Me.Panel341.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel341.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel341.Controls.Add(Me.TextBox335)
Me.Panel341.Controls.Add(Me.TextBox336)
Me.Panel341.Location = New System.Drawing.Point(468, 135)
Me.Panel341.Name = "Panel341"
Me.Panel341.Size = New System.Drawing.Size(89, 24)
Me.Panel341.TabIndex = 75
'
'TextBox335
'
Me.TextBox335.Location = New System.Drawing.Point(3, 2)
Me.TextBox335.Name = "TextBox335"
Me.TextBox335.ReadOnly = true
Me.TextBox335.Size = New System.Drawing.Size(40, 20)
Me.TextBox335.TabIndex = 8
Me.TextBox335.Text = ""
'
'TextBox336
'
Me.TextBox336.Location = New System.Drawing.Point(46, 2)
Me.TextBox336.Name = "TextBox336"
Me.TextBox336.ReadOnly = true
Me.TextBox336.Size = New System.Drawing.Size(40, 20)
Me.TextBox336.TabIndex = 7
Me.TextBox336.Text = ""
'
'Panel342
'
Me.Panel342.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel342.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel342.Controls.Add(Me.TextBox337)
Me.Panel342.Location = New System.Drawing.Point(292, 159)
Me.Panel342.Name = "Panel342"
Me.Panel342.Size = New System.Drawing.Size(89, 24)
Me.Panel342.TabIndex = 74
'
'TextBox337
'
Me.TextBox337.Location = New System.Drawing.Point(3, 2)
Me.TextBox337.Name = "TextBox337"
Me.TextBox337.ReadOnly = true
Me.TextBox337.Size = New System.Drawing.Size(83, 20)
Me.TextBox337.TabIndex = 8
Me.TextBox337.Text = ""
'
'Panel343
'
Me.Panel343.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel343.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel343.Controls.Add(Me.Label193)
Me.Panel343.Location = New System.Drawing.Point(292, 39)
Me.Panel343.Name = "Panel343"
Me.Panel343.Size = New System.Drawing.Size(89, 24)
Me.Panel343.TabIndex = 88
'
'Label193
'
Me.Label193.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label193.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label193.Location = New System.Drawing.Point(8, 4)
Me.Label193.Name = "Label193"
Me.Label193.Size = New System.Drawing.Size(80, 16)
Me.Label193.TabIndex = 6
Me.Label193.Text = "1"
Me.Label193.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel344
'
Me.Panel344.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel344.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel344.Controls.Add(Me.TextBox338)
Me.Panel344.Location = New System.Drawing.Point(292, 183)
Me.Panel344.Name = "Panel344"
Me.Panel344.Size = New System.Drawing.Size(89, 24)
Me.Panel344.TabIndex = 76
'
'TextBox338
'
Me.TextBox338.Location = New System.Drawing.Point(3, 2)
Me.TextBox338.Name = "TextBox338"
Me.TextBox338.ReadOnly = true
Me.TextBox338.Size = New System.Drawing.Size(83, 20)
Me.TextBox338.TabIndex = 8
Me.TextBox338.Text = ""
'
'Panel345
'
Me.Panel345.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel345.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel345.Controls.Add(Me.Label194)
Me.Panel345.Location = New System.Drawing.Point(380, 159)
Me.Panel345.Name = "Panel345"
Me.Panel345.Size = New System.Drawing.Size(177, 48)
Me.Panel345.TabIndex = 78
'
'Label194
'
Me.Label194.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label194.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label194.Location = New System.Drawing.Point(8, 16)
Me.Label194.Name = "Label194"
Me.Label194.Size = New System.Drawing.Size(160, 16)
Me.Label194.TabIndex = 6
Me.Label194.Text = "Hétérogénité d'alimentation :"
Me.Label194.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel346
'
Me.Panel346.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel346.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel346.Controls.Add(Me.Label195)
Me.Panel346.Controls.Add(Me.Label196)
Me.Panel346.Controls.Add(Me.TextBox339)
Me.Panel346.Controls.Add(Me.TextBox340)
Me.Panel346.Location = New System.Drawing.Point(148, 15)
Me.Panel346.Name = "Panel346"
Me.Panel346.Size = New System.Drawing.Size(673, 24)
Me.Panel346.TabIndex = 90
'
'Label195
'
Me.Label195.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label195.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label195.Location = New System.Drawing.Point(8, 4)
Me.Label195.Name = "Label195"
Me.Label195.Size = New System.Drawing.Size(128, 16)
Me.Label195.TabIndex = 6
Me.Label195.Text = "Pression Mano Pulvé :"
Me.Label195.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label196
'
Me.Label196.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label196.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label196.Location = New System.Drawing.Point(392, 4)
Me.Label196.Name = "Label196"
Me.Label196.Size = New System.Drawing.Size(136, 16)
Me.Label196.TabIndex = 6
Me.Label196.Text = "Moyenne des pressions :"
Me.Label196.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox339
'
Me.TextBox339.Location = New System.Drawing.Point(144, 2)
Me.TextBox339.Name = "TextBox339"
Me.TextBox339.ReadOnly = true
Me.TextBox339.Size = New System.Drawing.Size(83, 20)
Me.TextBox339.TabIndex = 8
Me.TextBox339.Text = "20"
'
'TextBox340
'
Me.TextBox340.Location = New System.Drawing.Point(536, 2)
Me.TextBox340.Name = "TextBox340"
Me.TextBox340.ReadOnly = true
Me.TextBox340.Size = New System.Drawing.Size(83, 20)
Me.TextBox340.TabIndex = 8
Me.TextBox340.Text = ""
'
'Panel347
'
Me.Panel347.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel347.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel347.Controls.Add(Me.Label197)
Me.Panel347.Controls.Add(Me.Label198)
Me.Panel347.Location = New System.Drawing.Point(556, 159)
Me.Panel347.Name = "Panel347"
Me.Panel347.Size = New System.Drawing.Size(265, 48)
Me.Panel347.TabIndex = 77
'
'Label197
'
Me.Label197.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label197.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label197.Location = New System.Drawing.Point(48, 16)
Me.Label197.Name = "Label197"
Me.Label197.Size = New System.Drawing.Size(168, 16)
Me.Label197.TabIndex = 29
Me.Label197.Text = "OK"
Me.Label197.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label198
'
Me.Label198.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label198.ForeColor = System.Drawing.Color.Red
Me.Label198.Location = New System.Drawing.Point(48, 16)
Me.Label198.Name = "Label198"
Me.Label198.Size = New System.Drawing.Size(168, 16)
Me.Label198.TabIndex = 28
Me.Label198.Text = "DEFAUT"
Me.Label198.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel348
'
Me.Panel348.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel348.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel348.Controls.Add(Me.Label199)
Me.Panel348.Controls.Add(Me.Label200)
Me.Panel348.Location = New System.Drawing.Point(292, 63)
Me.Panel348.Name = "Panel348"
Me.Panel348.Size = New System.Drawing.Size(89, 24)
Me.Panel348.TabIndex = 87
'
'Label199
'
Me.Label199.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label199.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label199.Location = New System.Drawing.Point(8, 4)
Me.Label199.Name = "Label199"
Me.Label199.Size = New System.Drawing.Size(40, 16)
Me.Label199.TabIndex = 6
Me.Label199.Text = "G"
Me.Label199.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label200
'
Me.Label200.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label200.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label200.Location = New System.Drawing.Point(48, 4)
Me.Label200.Name = "Label200"
Me.Label200.Size = New System.Drawing.Size(40, 16)
Me.Label200.TabIndex = 6
Me.Label200.Text = "D"
Me.Label200.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel349
'
Me.Panel349.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel349.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel349.Controls.Add(Me.Label201)
Me.Panel349.Controls.Add(Me.Label202)
Me.Panel349.Location = New System.Drawing.Point(380, 63)
Me.Panel349.Name = "Panel349"
Me.Panel349.Size = New System.Drawing.Size(89, 24)
Me.Panel349.TabIndex = 94
'
'Label201
'
Me.Label201.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label201.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label201.Location = New System.Drawing.Point(8, 4)
Me.Label201.Name = "Label201"
Me.Label201.Size = New System.Drawing.Size(40, 16)
Me.Label201.TabIndex = 6
Me.Label201.Text = "G"
Me.Label201.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label202
'
Me.Label202.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label202.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label202.Location = New System.Drawing.Point(48, 4)
Me.Label202.Name = "Label202"
Me.Label202.Size = New System.Drawing.Size(40, 16)
Me.Label202.TabIndex = 6
Me.Label202.Text = "D"
Me.Label202.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel350
'
Me.Panel350.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel350.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel350.Controls.Add(Me.Label203)
Me.Panel350.Location = New System.Drawing.Point(380, 39)
Me.Panel350.Name = "Panel350"
Me.Panel350.Size = New System.Drawing.Size(89, 24)
Me.Panel350.TabIndex = 101
'
'Label203
'
Me.Label203.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label203.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label203.Location = New System.Drawing.Point(8, 4)
Me.Label203.Name = "Label203"
Me.Label203.Size = New System.Drawing.Size(80, 16)
Me.Label203.TabIndex = 6
Me.Label203.Text = "2"
Me.Label203.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel351
'
Me.Panel351.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel351.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel351.Controls.Add(Me.Label204)
Me.Panel351.Location = New System.Drawing.Point(148, 87)
Me.Panel351.Name = "Panel351"
Me.Panel351.Size = New System.Drawing.Size(144, 24)
Me.Panel351.TabIndex = 93
'
'Label204
'
Me.Label204.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label204.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label204.Location = New System.Drawing.Point(8, 4)
Me.Label204.Name = "Label204"
Me.Label204.Size = New System.Drawing.Size(128, 16)
Me.Label204.TabIndex = 6
Me.Label204.Text = "P sortie"
Me.Label204.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel352
'
Me.Panel352.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel352.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel352.Controls.Add(Me.Label205)
Me.Panel352.Location = New System.Drawing.Point(148, 111)
Me.Panel352.Name = "Panel352"
Me.Panel352.Size = New System.Drawing.Size(144, 24)
Me.Panel352.TabIndex = 92
'
'Label205
'
Me.Label205.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label205.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label205.Location = New System.Drawing.Point(8, 4)
Me.Label205.Name = "Label205"
Me.Label205.Size = New System.Drawing.Size(128, 16)
Me.Label205.TabIndex = 6
Me.Label205.Text = "Ecart"
Me.Label205.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel353
'
Me.Panel353.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel353.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel353.Controls.Add(Me.Label206)
Me.Panel353.Location = New System.Drawing.Point(148, 135)
Me.Panel353.Name = "Panel353"
Me.Panel353.Size = New System.Drawing.Size(144, 24)
Me.Panel353.TabIndex = 85
'
'Label206
'
Me.Label206.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label206.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label206.Location = New System.Drawing.Point(8, 4)
Me.Label206.Name = "Label206"
Me.Label206.Size = New System.Drawing.Size(128, 16)
Me.Label206.TabIndex = 6
Me.Label206.Text = "Perte charge"
Me.Label206.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel354
'
Me.Panel354.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel354.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel354.Controls.Add(Me.Label207)
Me.Panel354.Location = New System.Drawing.Point(148, 159)
Me.Panel354.Name = "Panel354"
Me.Panel354.Size = New System.Drawing.Size(144, 24)
Me.Panel354.TabIndex = 84
'
'Label207
'
Me.Label207.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label207.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label207.Location = New System.Drawing.Point(8, 4)
Me.Label207.Name = "Label207"
Me.Label207.Size = New System.Drawing.Size(128, 16)
Me.Label207.TabIndex = 6
Me.Label207.Text = "Perte de charge moy"
Me.Label207.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel355
'
Me.Panel355.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel355.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel355.Controls.Add(Me.Label208)
Me.Panel355.Location = New System.Drawing.Point(148, 183)
Me.Panel355.Name = "Panel355"
Me.Panel355.Size = New System.Drawing.Size(144, 24)
Me.Panel355.TabIndex = 86
'
'Label208
'
Me.Label208.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label208.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label208.Location = New System.Drawing.Point(8, 4)
Me.Label208.Name = "Label208"
Me.Label208.Size = New System.Drawing.Size(128, 16)
Me.Label208.TabIndex = 6
Me.Label208.Text = "Perte de charge max"
Me.Label208.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel356
'
Me.Panel356.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel356.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel356.Controls.Add(Me.Label209)
Me.Panel356.Location = New System.Drawing.Point(148, 39)
Me.Panel356.Name = "Panel356"
Me.Panel356.Size = New System.Drawing.Size(144, 24)
Me.Panel356.TabIndex = 89
'
'Label209
'
Me.Label209.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label209.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label209.Location = New System.Drawing.Point(8, 4)
Me.Label209.Name = "Label209"
Me.Label209.Size = New System.Drawing.Size(128, 16)
Me.Label209.TabIndex = 6
Me.Label209.Text = "Niveau"
Me.Label209.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel357
'
Me.Panel357.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel357.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel357.Controls.Add(Me.Label210)
Me.Panel357.Location = New System.Drawing.Point(148, 63)
Me.Panel357.Name = "Panel357"
Me.Panel357.Size = New System.Drawing.Size(144, 24)
Me.Panel357.TabIndex = 91
'
'Label210
'
Me.Label210.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label210.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label210.Location = New System.Drawing.Point(8, 4)
Me.Label210.Name = "Label210"
Me.Label210.Size = New System.Drawing.Size(128, 16)
Me.Label210.TabIndex = 6
Me.Label210.Text = "Section Gauche/Droite"
Me.Label210.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel358
'
Me.Panel358.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel358.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel358.Controls.Add(Me.Label211)
Me.Panel358.Location = New System.Drawing.Point(468, 39)
Me.Panel358.Name = "Panel358"
Me.Panel358.Size = New System.Drawing.Size(89, 24)
Me.Panel358.TabIndex = 100
'
'Label211
'
Me.Label211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label211.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label211.Location = New System.Drawing.Point(8, 4)
Me.Label211.Name = "Label211"
Me.Label211.Size = New System.Drawing.Size(80, 16)
Me.Label211.TabIndex = 6
Me.Label211.Text = "3"
Me.Label211.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel359
'
Me.Panel359.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel359.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel359.Controls.Add(Me.Label212)
Me.Panel359.Controls.Add(Me.Label213)
Me.Panel359.Location = New System.Drawing.Point(468, 63)
Me.Panel359.Name = "Panel359"
Me.Panel359.Size = New System.Drawing.Size(89, 24)
Me.Panel359.TabIndex = 102
'
'Label212
'
Me.Label212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label212.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label212.Location = New System.Drawing.Point(8, 4)
Me.Label212.Name = "Label212"
Me.Label212.Size = New System.Drawing.Size(40, 16)
Me.Label212.TabIndex = 6
Me.Label212.Text = "G"
Me.Label212.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label213
'
Me.Label213.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label213.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label213.Location = New System.Drawing.Point(48, 4)
Me.Label213.Name = "Label213"
Me.Label213.Size = New System.Drawing.Size(40, 16)
Me.Label213.TabIndex = 6
Me.Label213.Text = "D"
Me.Label213.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel360
'
Me.Panel360.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel360.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel360.Controls.Add(Me.Label214)
Me.Panel360.Controls.Add(Me.Label215)
Me.Panel360.Location = New System.Drawing.Point(556, 63)
Me.Panel360.Name = "Panel360"
Me.Panel360.Size = New System.Drawing.Size(89, 24)
Me.Panel360.TabIndex = 104
'
'Label214
'
Me.Label214.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label214.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label214.Location = New System.Drawing.Point(8, 4)
Me.Label214.Name = "Label214"
Me.Label214.Size = New System.Drawing.Size(40, 16)
Me.Label214.TabIndex = 6
Me.Label214.Text = "G"
Me.Label214.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label215
'
Me.Label215.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label215.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label215.Location = New System.Drawing.Point(48, 4)
Me.Label215.Name = "Label215"
Me.Label215.Size = New System.Drawing.Size(40, 16)
Me.Label215.TabIndex = 6
Me.Label215.Text = "D"
Me.Label215.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel361
'
Me.Panel361.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel361.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel361.Controls.Add(Me.Label216)
Me.Panel361.Location = New System.Drawing.Point(556, 39)
Me.Panel361.Name = "Panel361"
Me.Panel361.Size = New System.Drawing.Size(89, 24)
Me.Panel361.TabIndex = 103
'
'Label216
'
Me.Label216.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label216.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label216.Location = New System.Drawing.Point(8, 4)
Me.Label216.Name = "Label216"
Me.Label216.Size = New System.Drawing.Size(80, 16)
Me.Label216.TabIndex = 6
Me.Label216.Text = "4"
Me.Label216.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel362
'
Me.Panel362.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel362.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel362.Controls.Add(Me.Label217)
Me.Panel362.Location = New System.Drawing.Point(644, 39)
Me.Panel362.Name = "Panel362"
Me.Panel362.Size = New System.Drawing.Size(89, 24)
Me.Panel362.TabIndex = 96
'
'Label217
'
Me.Label217.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label217.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label217.Location = New System.Drawing.Point(8, 4)
Me.Label217.Name = "Label217"
Me.Label217.Size = New System.Drawing.Size(80, 16)
Me.Label217.TabIndex = 6
Me.Label217.Text = "5"
Me.Label217.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel363
'
Me.Panel363.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel363.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel363.Controls.Add(Me.Label218)
Me.Panel363.Controls.Add(Me.Label219)
Me.Panel363.Location = New System.Drawing.Point(644, 63)
Me.Panel363.Name = "Panel363"
Me.Panel363.Size = New System.Drawing.Size(89, 24)
Me.Panel363.TabIndex = 95
'
'Label218
'
Me.Label218.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label218.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label218.Location = New System.Drawing.Point(8, 4)
Me.Label218.Name = "Label218"
Me.Label218.Size = New System.Drawing.Size(40, 16)
Me.Label218.TabIndex = 6
Me.Label218.Text = "G"
Me.Label218.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label219
'
Me.Label219.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label219.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label219.Location = New System.Drawing.Point(48, 4)
Me.Label219.Name = "Label219"
Me.Label219.Size = New System.Drawing.Size(40, 16)
Me.Label219.TabIndex = 6
Me.Label219.Text = "D"
Me.Label219.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel364
'
Me.Panel364.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel364.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel364.Controls.Add(Me.Label220)
Me.Panel364.Controls.Add(Me.Label221)
Me.Panel364.Location = New System.Drawing.Point(732, 63)
Me.Panel364.Name = "Panel364"
Me.Panel364.Size = New System.Drawing.Size(89, 24)
Me.Panel364.TabIndex = 97
'
'Label220
'
Me.Label220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label220.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label220.Location = New System.Drawing.Point(8, 4)
Me.Label220.Name = "Label220"
Me.Label220.Size = New System.Drawing.Size(40, 16)
Me.Label220.TabIndex = 6
Me.Label220.Text = "G"
Me.Label220.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label221
'
Me.Label221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label221.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label221.Location = New System.Drawing.Point(48, 4)
Me.Label221.Name = "Label221"
Me.Label221.Size = New System.Drawing.Size(40, 16)
Me.Label221.TabIndex = 6
Me.Label221.Text = "D"
Me.Label221.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel365
'
Me.Panel365.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel365.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel365.Controls.Add(Me.Label222)
Me.Panel365.Location = New System.Drawing.Point(732, 39)
Me.Panel365.Name = "Panel365"
Me.Panel365.Size = New System.Drawing.Size(89, 24)
Me.Panel365.TabIndex = 99
'
'Label222
'
Me.Label222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label222.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label222.Location = New System.Drawing.Point(8, 4)
Me.Label222.Name = "Label222"
Me.Label222.Size = New System.Drawing.Size(80, 16)
Me.Label222.TabIndex = 6
Me.Label222.Text = "6"
Me.Label222.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel366
'
Me.Panel366.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel366.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel366.Controls.Add(Me.TextBox341)
Me.Panel366.Controls.Add(Me.TextBox342)
Me.Panel366.Location = New System.Drawing.Point(292, 87)
Me.Panel366.Name = "Panel366"
Me.Panel366.Size = New System.Drawing.Size(89, 24)
Me.Panel366.TabIndex = 98
'
'TextBox341
'
Me.TextBox341.Location = New System.Drawing.Point(3, 2)
Me.TextBox341.Name = "TextBox341"
Me.TextBox341.Size = New System.Drawing.Size(40, 20)
Me.TextBox341.TabIndex = 8
Me.TextBox341.Text = ""
'
'TextBox342
'
Me.TextBox342.Location = New System.Drawing.Point(46, 2)
Me.TextBox342.Name = "TextBox342"
Me.TextBox342.Size = New System.Drawing.Size(40, 20)
Me.TextBox342.TabIndex = 7
Me.TextBox342.Text = ""
'
'Panel367
'
Me.Panel367.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel367.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel367.Controls.Add(Me.TextBox343)
Me.Panel367.Controls.Add(Me.TextBox344)
Me.Panel367.Location = New System.Drawing.Point(380, 87)
Me.Panel367.Name = "Panel367"
Me.Panel367.Size = New System.Drawing.Size(89, 24)
Me.Panel367.TabIndex = 69
'
'TextBox343
'
Me.TextBox343.Location = New System.Drawing.Point(3, 2)
Me.TextBox343.Name = "TextBox343"
Me.TextBox343.Size = New System.Drawing.Size(40, 20)
Me.TextBox343.TabIndex = 8
Me.TextBox343.Text = ""
'
'TextBox344
'
Me.TextBox344.Location = New System.Drawing.Point(46, 2)
Me.TextBox344.Name = "TextBox344"
Me.TextBox344.Size = New System.Drawing.Size(40, 20)
Me.TextBox344.TabIndex = 7
Me.TextBox344.Text = ""
'
'Panel368
'
Me.Panel368.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel368.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel368.Controls.Add(Me.TextBox345)
Me.Panel368.Controls.Add(Me.TextBox346)
Me.Panel368.Location = New System.Drawing.Point(468, 87)
Me.Panel368.Name = "Panel368"
Me.Panel368.Size = New System.Drawing.Size(89, 24)
Me.Panel368.TabIndex = 68
'
'TextBox345
'
Me.TextBox345.Location = New System.Drawing.Point(3, 2)
Me.TextBox345.Name = "TextBox345"
Me.TextBox345.Size = New System.Drawing.Size(40, 20)
Me.TextBox345.TabIndex = 8
Me.TextBox345.Text = ""
'
'TextBox346
'
Me.TextBox346.Location = New System.Drawing.Point(46, 2)
Me.TextBox346.Name = "TextBox346"
Me.TextBox346.Size = New System.Drawing.Size(40, 20)
Me.TextBox346.TabIndex = 7
Me.TextBox346.Text = ""
'
'Panel369
'
Me.Panel369.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel369.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel369.Controls.Add(Me.TextBox347)
Me.Panel369.Controls.Add(Me.TextBox348)
Me.Panel369.Location = New System.Drawing.Point(556, 87)
Me.Panel369.Name = "Panel369"
Me.Panel369.Size = New System.Drawing.Size(89, 24)
Me.Panel369.TabIndex = 70
'
'TextBox347
'
Me.TextBox347.Location = New System.Drawing.Point(3, 2)
Me.TextBox347.Name = "TextBox347"
Me.TextBox347.Size = New System.Drawing.Size(40, 20)
Me.TextBox347.TabIndex = 8
Me.TextBox347.Text = ""
'
'TextBox348
'
Me.TextBox348.Location = New System.Drawing.Point(46, 2)
Me.TextBox348.Name = "TextBox348"
Me.TextBox348.Size = New System.Drawing.Size(40, 20)
Me.TextBox348.TabIndex = 7
Me.TextBox348.Text = ""
'
'Panel370
'
Me.Panel370.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel370.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel370.Controls.Add(Me.TextBox349)
Me.Panel370.Controls.Add(Me.TextBox350)
Me.Panel370.Location = New System.Drawing.Point(644, 87)
Me.Panel370.Name = "Panel370"
Me.Panel370.Size = New System.Drawing.Size(89, 24)
Me.Panel370.TabIndex = 72
'
'TextBox349
'
Me.TextBox349.Location = New System.Drawing.Point(3, 2)
Me.TextBox349.Name = "TextBox349"
Me.TextBox349.Size = New System.Drawing.Size(40, 20)
Me.TextBox349.TabIndex = 8
Me.TextBox349.Text = ""
'
'TextBox350
'
Me.TextBox350.Location = New System.Drawing.Point(46, 2)
Me.TextBox350.Name = "TextBox350"
Me.TextBox350.Size = New System.Drawing.Size(40, 20)
Me.TextBox350.TabIndex = 7
Me.TextBox350.Text = ""
'
'Panel371
'
Me.Panel371.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel371.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel371.Controls.Add(Me.TextBox351)
Me.Panel371.Controls.Add(Me.TextBox352)
Me.Panel371.Location = New System.Drawing.Point(732, 87)
Me.Panel371.Name = "Panel371"
Me.Panel371.Size = New System.Drawing.Size(89, 24)
Me.Panel371.TabIndex = 71
'
'TextBox351
'
Me.TextBox351.Location = New System.Drawing.Point(3, 2)
Me.TextBox351.Name = "TextBox351"
Me.TextBox351.Size = New System.Drawing.Size(40, 20)
Me.TextBox351.TabIndex = 8
Me.TextBox351.Text = ""
'
'TextBox352
'
Me.TextBox352.Location = New System.Drawing.Point(46, 2)
Me.TextBox352.Name = "TextBox352"
Me.TextBox352.Size = New System.Drawing.Size(40, 20)
Me.TextBox352.TabIndex = 7
Me.TextBox352.Text = ""
'
'diagBuses_tab_pressionTroncons_rampe
'
Me.diagBuses_tab_pressionTroncons_rampe.Controls.Add(Me.TabPage3)
Me.diagBuses_tab_pressionTroncons_rampe.Controls.Add(Me.TabPage4)
Me.diagBuses_tab_pressionTroncons_rampe.Controls.Add(Me.TabPage5)
Me.diagBuses_tab_pressionTroncons_rampe.Controls.Add(Me.TabPage6)
Me.diagBuses_tab_pressionTroncons_rampe.Location = New System.Drawing.Point(16, 448)
Me.diagBuses_tab_pressionTroncons_rampe.Name = "diagBuses_tab_pressionTroncons_rampe"
Me.diagBuses_tab_pressionTroncons_rampe.SelectedIndex = 0
Me.diagBuses_tab_pressionTroncons_rampe.Size = New System.Drawing.Size(976, 248)
Me.diagBuses_tab_pressionTroncons_rampe.TabIndex = 177
'
'TabPage3
'
Me.TabPage3.Controls.Add(Me.Panel85)
Me.TabPage3.Controls.Add(Me.Panel86)
Me.TabPage3.Controls.Add(Me.Panel87)
Me.TabPage3.Controls.Add(Me.Panel88)
Me.TabPage3.Controls.Add(Me.Panel89)
Me.TabPage3.Controls.Add(Me.Panel90)
Me.TabPage3.Controls.Add(Me.Panel91)
Me.TabPage3.Controls.Add(Me.Panel92)
Me.TabPage3.Controls.Add(Me.Panel126)
Me.TabPage3.Controls.Add(Me.Panel131)
Me.TabPage3.Controls.Add(Me.Panel134)
Me.TabPage3.Controls.Add(Me.Panel135)
Me.TabPage3.Controls.Add(Me.Panel136)
Me.TabPage3.Controls.Add(Me.Panel137)
Me.TabPage3.Controls.Add(Me.Panel138)
Me.TabPage3.Controls.Add(Me.Panel139)
Me.TabPage3.Controls.Add(Me.Panel140)
Me.TabPage3.Controls.Add(Me.Panel141)
Me.TabPage3.Controls.Add(Me.Panel142)
Me.TabPage3.Controls.Add(Me.Panel143)
Me.TabPage3.Controls.Add(Me.Panel144)
Me.TabPage3.Controls.Add(Me.Panel145)
Me.TabPage3.Controls.Add(Me.Panel146)
Me.TabPage3.Controls.Add(Me.Panel147)
Me.TabPage3.Controls.Add(Me.Panel148)
Me.TabPage3.Controls.Add(Me.Panel149)
Me.TabPage3.Controls.Add(Me.Panel150)
Me.TabPage3.Controls.Add(Me.Panel151)
Me.TabPage3.Controls.Add(Me.Panel152)
Me.TabPage3.Controls.Add(Me.Panel153)
Me.TabPage3.Controls.Add(Me.Panel154)
Me.TabPage3.Controls.Add(Me.Panel155)
Me.TabPage3.Controls.Add(Me.Panel156)
Me.TabPage3.Controls.Add(Me.Panel157)
Me.TabPage3.Controls.Add(Me.Panel158)
Me.TabPage3.Controls.Add(Me.Panel159)
Me.TabPage3.Controls.Add(Me.Panel160)
Me.TabPage3.Controls.Add(Me.Panel161)
Me.TabPage3.Controls.Add(Me.Panel162)
Me.TabPage3.Controls.Add(Me.Panel163)
Me.TabPage3.Controls.Add(Me.Panel164)
Me.TabPage3.Controls.Add(Me.Panel165)
Me.TabPage3.Controls.Add(Me.Panel293)
Me.TabPage3.Controls.Add(Me.Panel294)
Me.TabPage3.Controls.Add(Me.Panel295)
Me.TabPage3.Controls.Add(Me.Panel296)
Me.TabPage3.Controls.Add(Me.Panel297)
Me.TabPage3.Controls.Add(Me.Panel298)
Me.TabPage3.Controls.Add(Me.Panel299)
Me.TabPage3.Controls.Add(Me.Panel300)
Me.TabPage3.Controls.Add(Me.Panel301)
Me.TabPage3.Controls.Add(Me.Panel302)
Me.TabPage3.Controls.Add(Me.Panel303)
Me.TabPage3.Controls.Add(Me.Panel304)
Me.TabPage3.Controls.Add(Me.Panel305)
Me.TabPage3.Controls.Add(Me.Panel306)
Me.TabPage3.Controls.Add(Me.Panel307)
Me.TabPage3.Controls.Add(Me.Panel308)
Me.TabPage3.Controls.Add(Me.Panel309)
Me.TabPage3.Location = New System.Drawing.Point(4, 22)
Me.TabPage3.Name = "TabPage3"
Me.TabPage3.Size = New System.Drawing.Size(968, 222)
Me.TabPage3.TabIndex = 0
Me.TabPage3.Text = "5 bar"
'
'TabPage4
'
Me.TabPage4.Controls.Add(Me.Panel310)
Me.TabPage4.Controls.Add(Me.Panel311)
Me.TabPage4.Controls.Add(Me.Panel312)
Me.TabPage4.Controls.Add(Me.Panel313)
Me.TabPage4.Controls.Add(Me.Panel314)
Me.TabPage4.Controls.Add(Me.Panel315)
Me.TabPage4.Controls.Add(Me.Panel316)
Me.TabPage4.Controls.Add(Me.Panel317)
Me.TabPage4.Controls.Add(Me.Panel318)
Me.TabPage4.Controls.Add(Me.Panel319)
Me.TabPage4.Controls.Add(Me.Panel320)
Me.TabPage4.Controls.Add(Me.Panel321)
Me.TabPage4.Controls.Add(Me.Panel322)
Me.TabPage4.Controls.Add(Me.Panel372)
Me.TabPage4.Controls.Add(Me.Panel373)
Me.TabPage4.Controls.Add(Me.Panel374)
Me.TabPage4.Controls.Add(Me.Panel375)
Me.TabPage4.Controls.Add(Me.Panel376)
Me.TabPage4.Controls.Add(Me.Panel377)
Me.TabPage4.Controls.Add(Me.Panel378)
Me.TabPage4.Controls.Add(Me.Panel379)
Me.TabPage4.Controls.Add(Me.Panel380)
Me.TabPage4.Controls.Add(Me.Panel381)
Me.TabPage4.Controls.Add(Me.Panel382)
Me.TabPage4.Controls.Add(Me.Panel383)
Me.TabPage4.Controls.Add(Me.Panel384)
Me.TabPage4.Controls.Add(Me.Panel385)
Me.TabPage4.Controls.Add(Me.Panel386)
Me.TabPage4.Controls.Add(Me.Panel387)
Me.TabPage4.Controls.Add(Me.Panel388)
Me.TabPage4.Controls.Add(Me.Panel389)
Me.TabPage4.Controls.Add(Me.Panel390)
Me.TabPage4.Controls.Add(Me.Panel391)
Me.TabPage4.Controls.Add(Me.Panel392)
Me.TabPage4.Controls.Add(Me.Panel393)
Me.TabPage4.Controls.Add(Me.Panel394)
Me.TabPage4.Controls.Add(Me.Panel395)
Me.TabPage4.Controls.Add(Me.Panel396)
Me.TabPage4.Controls.Add(Me.Panel397)
Me.TabPage4.Controls.Add(Me.Panel398)
Me.TabPage4.Controls.Add(Me.Panel399)
Me.TabPage4.Controls.Add(Me.Panel400)
Me.TabPage4.Controls.Add(Me.Panel401)
Me.TabPage4.Controls.Add(Me.Panel402)
Me.TabPage4.Controls.Add(Me.Panel403)
Me.TabPage4.Controls.Add(Me.Panel404)
Me.TabPage4.Controls.Add(Me.Panel405)
Me.TabPage4.Controls.Add(Me.Panel406)
Me.TabPage4.Controls.Add(Me.Panel407)
Me.TabPage4.Controls.Add(Me.Panel408)
Me.TabPage4.Controls.Add(Me.Panel409)
Me.TabPage4.Controls.Add(Me.Panel410)
Me.TabPage4.Controls.Add(Me.Panel411)
Me.TabPage4.Controls.Add(Me.Panel412)
Me.TabPage4.Controls.Add(Me.Panel413)
Me.TabPage4.Controls.Add(Me.Panel498)
Me.TabPage4.Controls.Add(Me.Panel499)
Me.TabPage4.Controls.Add(Me.Panel500)
Me.TabPage4.Controls.Add(Me.Panel501)
Me.TabPage4.Location = New System.Drawing.Point(4, 22)
Me.TabPage4.Name = "TabPage4"
Me.TabPage4.Size = New System.Drawing.Size(968, 222)
Me.TabPage4.TabIndex = 1
Me.TabPage4.Text = "10 bar"
Me.TabPage4.Visible = false
'
'TabPage5
'
Me.TabPage5.Controls.Add(Me.Panel414)
Me.TabPage5.Controls.Add(Me.Panel415)
Me.TabPage5.Controls.Add(Me.Panel416)
Me.TabPage5.Controls.Add(Me.Panel417)
Me.TabPage5.Controls.Add(Me.Panel418)
Me.TabPage5.Controls.Add(Me.Panel419)
Me.TabPage5.Controls.Add(Me.Panel420)
Me.TabPage5.Controls.Add(Me.Panel421)
Me.TabPage5.Controls.Add(Me.Panel422)
Me.TabPage5.Controls.Add(Me.Panel423)
Me.TabPage5.Controls.Add(Me.Panel424)
Me.TabPage5.Controls.Add(Me.Panel425)
Me.TabPage5.Controls.Add(Me.Panel426)
Me.TabPage5.Controls.Add(Me.Panel427)
Me.TabPage5.Controls.Add(Me.Panel428)
Me.TabPage5.Controls.Add(Me.Panel429)
Me.TabPage5.Controls.Add(Me.Panel430)
Me.TabPage5.Controls.Add(Me.Panel431)
Me.TabPage5.Controls.Add(Me.Panel432)
Me.TabPage5.Controls.Add(Me.Panel433)
Me.TabPage5.Controls.Add(Me.Panel434)
Me.TabPage5.Controls.Add(Me.Panel435)
Me.TabPage5.Controls.Add(Me.Panel436)
Me.TabPage5.Controls.Add(Me.Panel437)
Me.TabPage5.Controls.Add(Me.Panel438)
Me.TabPage5.Controls.Add(Me.Panel439)
Me.TabPage5.Controls.Add(Me.Panel440)
Me.TabPage5.Controls.Add(Me.Panel441)
Me.TabPage5.Controls.Add(Me.Panel442)
Me.TabPage5.Controls.Add(Me.Panel443)
Me.TabPage5.Controls.Add(Me.Panel444)
Me.TabPage5.Controls.Add(Me.Panel445)
Me.TabPage5.Controls.Add(Me.Panel446)
Me.TabPage5.Controls.Add(Me.Panel447)
Me.TabPage5.Controls.Add(Me.Panel448)
Me.TabPage5.Controls.Add(Me.Panel449)
Me.TabPage5.Controls.Add(Me.Panel450)
Me.TabPage5.Controls.Add(Me.Panel451)
Me.TabPage5.Controls.Add(Me.Panel452)
Me.TabPage5.Controls.Add(Me.Panel453)
Me.TabPage5.Controls.Add(Me.Panel454)
Me.TabPage5.Controls.Add(Me.Panel455)
Me.TabPage5.Controls.Add(Me.Panel502)
Me.TabPage5.Controls.Add(Me.Panel503)
Me.TabPage5.Controls.Add(Me.Panel504)
Me.TabPage5.Controls.Add(Me.Panel505)
Me.TabPage5.Controls.Add(Me.Panel506)
Me.TabPage5.Controls.Add(Me.Panel507)
Me.TabPage5.Controls.Add(Me.Panel508)
Me.TabPage5.Controls.Add(Me.Panel509)
Me.TabPage5.Controls.Add(Me.Panel510)
Me.TabPage5.Controls.Add(Me.Panel511)
Me.TabPage5.Controls.Add(Me.Panel512)
Me.TabPage5.Controls.Add(Me.Panel513)
Me.TabPage5.Controls.Add(Me.Panel514)
Me.TabPage5.Controls.Add(Me.Panel515)
Me.TabPage5.Controls.Add(Me.Panel516)
Me.TabPage5.Controls.Add(Me.Panel517)
Me.TabPage5.Controls.Add(Me.Panel518)
Me.TabPage5.Location = New System.Drawing.Point(4, 22)
Me.TabPage5.Name = "TabPage5"
Me.TabPage5.Size = New System.Drawing.Size(968, 222)
Me.TabPage5.TabIndex = 2
Me.TabPage5.Text = "15 bar"
Me.TabPage5.Visible = false
'
'TabPage6
'
Me.TabPage6.Controls.Add(Me.Panel456)
Me.TabPage6.Controls.Add(Me.Panel457)
Me.TabPage6.Controls.Add(Me.Panel458)
Me.TabPage6.Controls.Add(Me.Panel459)
Me.TabPage6.Controls.Add(Me.Panel460)
Me.TabPage6.Controls.Add(Me.Panel461)
Me.TabPage6.Controls.Add(Me.Panel462)
Me.TabPage6.Controls.Add(Me.Panel463)
Me.TabPage6.Controls.Add(Me.Panel464)
Me.TabPage6.Controls.Add(Me.Panel465)
Me.TabPage6.Controls.Add(Me.Panel466)
Me.TabPage6.Controls.Add(Me.Panel467)
Me.TabPage6.Controls.Add(Me.Panel468)
Me.TabPage6.Controls.Add(Me.Panel469)
Me.TabPage6.Controls.Add(Me.Panel470)
Me.TabPage6.Controls.Add(Me.Panel471)
Me.TabPage6.Controls.Add(Me.Panel472)
Me.TabPage6.Controls.Add(Me.Panel473)
Me.TabPage6.Controls.Add(Me.Panel474)
Me.TabPage6.Controls.Add(Me.Panel475)
Me.TabPage6.Controls.Add(Me.Panel476)
Me.TabPage6.Controls.Add(Me.Panel477)
Me.TabPage6.Controls.Add(Me.Panel478)
Me.TabPage6.Controls.Add(Me.Panel479)
Me.TabPage6.Controls.Add(Me.Panel480)
Me.TabPage6.Controls.Add(Me.Panel481)
Me.TabPage6.Controls.Add(Me.Panel482)
Me.TabPage6.Controls.Add(Me.Panel483)
Me.TabPage6.Controls.Add(Me.Panel484)
Me.TabPage6.Controls.Add(Me.Panel485)
Me.TabPage6.Controls.Add(Me.Panel486)
Me.TabPage6.Controls.Add(Me.Panel487)
Me.TabPage6.Controls.Add(Me.Panel488)
Me.TabPage6.Controls.Add(Me.Panel489)
Me.TabPage6.Controls.Add(Me.Panel490)
Me.TabPage6.Controls.Add(Me.Panel491)
Me.TabPage6.Controls.Add(Me.Panel492)
Me.TabPage6.Controls.Add(Me.Panel493)
Me.TabPage6.Controls.Add(Me.Panel494)
Me.TabPage6.Controls.Add(Me.Panel495)
Me.TabPage6.Controls.Add(Me.Panel496)
Me.TabPage6.Controls.Add(Me.Panel497)
Me.TabPage6.Controls.Add(Me.Panel519)
Me.TabPage6.Controls.Add(Me.Panel520)
Me.TabPage6.Controls.Add(Me.Panel521)
Me.TabPage6.Controls.Add(Me.Panel522)
Me.TabPage6.Controls.Add(Me.Panel523)
Me.TabPage6.Controls.Add(Me.Panel524)
Me.TabPage6.Controls.Add(Me.Panel525)
Me.TabPage6.Controls.Add(Me.Panel526)
Me.TabPage6.Controls.Add(Me.Panel527)
Me.TabPage6.Controls.Add(Me.Panel528)
Me.TabPage6.Controls.Add(Me.Panel529)
Me.TabPage6.Controls.Add(Me.Panel530)
Me.TabPage6.Controls.Add(Me.Panel531)
Me.TabPage6.Controls.Add(Me.Panel532)
Me.TabPage6.Controls.Add(Me.Panel533)
Me.TabPage6.Controls.Add(Me.Panel534)
Me.TabPage6.Controls.Add(Me.Panel535)
Me.TabPage6.Location = New System.Drawing.Point(4, 22)
Me.TabPage6.Name = "TabPage6"
Me.TabPage6.Size = New System.Drawing.Size(968, 222)
Me.TabPage6.TabIndex = 3
Me.TabPage6.Text = "20 bar"
Me.TabPage6.Visible = false
'
'Panel85
'
Me.Panel85.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel85.Controls.Add(Me.TextBox81)
Me.Panel85.Location = New System.Drawing.Point(300, 123)
Me.Panel85.Name = "Panel85"
Me.Panel85.Size = New System.Drawing.Size(64, 24)
Me.Panel85.TabIndex = 200
'
'TextBox81
'
Me.TextBox81.Location = New System.Drawing.Point(3, 2)
Me.TextBox81.Name = "TextBox81"
Me.TextBox81.ReadOnly = true
Me.TextBox81.Size = New System.Drawing.Size(55, 20)
Me.TextBox81.TabIndex = 8
Me.TextBox81.Text = ""
'
'Panel86
'
Me.Panel86.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel86.Controls.Add(Me.TextBox82)
Me.Panel86.Location = New System.Drawing.Point(876, 99)
Me.Panel86.Name = "Panel86"
Me.Panel86.Size = New System.Drawing.Size(64, 24)
Me.Panel86.TabIndex = 178
'
'TextBox82
'
Me.TextBox82.Location = New System.Drawing.Point(3, 2)
Me.TextBox82.Name = "TextBox82"
Me.TextBox82.ReadOnly = true
Me.TextBox82.Size = New System.Drawing.Size(55, 20)
Me.TextBox82.TabIndex = 8
Me.TextBox82.Text = ""
'
'Panel87
'
Me.Panel87.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel87.Controls.Add(Me.TextBox83)
Me.Panel87.Location = New System.Drawing.Point(172, 147)
Me.Panel87.Name = "Panel87"
Me.Panel87.Size = New System.Drawing.Size(89, 24)
Me.Panel87.TabIndex = 199
'
'TextBox83
'
Me.TextBox83.Location = New System.Drawing.Point(3, 2)
Me.TextBox83.Name = "TextBox83"
Me.TextBox83.ReadOnly = true
Me.TextBox83.Size = New System.Drawing.Size(83, 20)
Me.TextBox83.TabIndex = 8
Me.TextBox83.Text = ""
'
'Panel88
'
Me.Panel88.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel88.Controls.Add(Me.Label61)
Me.Panel88.Location = New System.Drawing.Point(876, 51)
Me.Panel88.Name = "Panel88"
Me.Panel88.Size = New System.Drawing.Size(64, 24)
Me.Panel88.TabIndex = 225
'
'Label61
'
Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label61.Location = New System.Drawing.Point(8, 4)
Me.Label61.Name = "Label61"
Me.Label61.Size = New System.Drawing.Size(48, 16)
Me.Label61.TabIndex = 6
Me.Label61.Text = "12"
Me.Label61.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel89
'
Me.Panel89.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel89.Controls.Add(Me.Label62)
Me.Panel89.Location = New System.Drawing.Point(172, 51)
Me.Panel89.Name = "Panel89"
Me.Panel89.Size = New System.Drawing.Size(64, 24)
Me.Panel89.TabIndex = 218
'
'Label62
'
Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label62.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label62.Location = New System.Drawing.Point(8, 4)
Me.Label62.Name = "Label62"
Me.Label62.Size = New System.Drawing.Size(48, 16)
Me.Label62.TabIndex = 6
Me.Label62.Text = "1"
Me.Label62.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel90
'
Me.Panel90.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel90.Controls.Add(Me.Label63)
Me.Panel90.Location = New System.Drawing.Point(684, 51)
Me.Panel90.Name = "Panel90"
Me.Panel90.Size = New System.Drawing.Size(64, 24)
Me.Panel90.TabIndex = 231
'
'Label63
'
Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label63.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label63.Location = New System.Drawing.Point(8, 4)
Me.Label63.Name = "Label63"
Me.Label63.Size = New System.Drawing.Size(48, 16)
Me.Label63.TabIndex = 6
Me.Label63.Text = "9"
Me.Label63.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel91
'
Me.Panel91.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel91.Controls.Add(Me.TextBox84)
Me.Panel91.Location = New System.Drawing.Point(172, 171)
Me.Panel91.Name = "Panel91"
Me.Panel91.Size = New System.Drawing.Size(89, 24)
Me.Panel91.TabIndex = 201
'
'TextBox84
'
Me.TextBox84.Location = New System.Drawing.Point(3, 2)
Me.TextBox84.Name = "TextBox84"
Me.TextBox84.ReadOnly = true
Me.TextBox84.Size = New System.Drawing.Size(83, 20)
Me.TextBox84.TabIndex = 8
Me.TextBox84.Text = ""
'
'Panel92
'
Me.Panel92.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel92.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel92.Controls.Add(Me.TextBox85)
Me.Panel92.Location = New System.Drawing.Point(684, 123)
Me.Panel92.Name = "Panel92"
Me.Panel92.Size = New System.Drawing.Size(64, 24)
Me.Panel92.TabIndex = 206
'
'TextBox85
'
Me.TextBox85.Location = New System.Drawing.Point(3, 2)
Me.TextBox85.Name = "TextBox85"
Me.TextBox85.ReadOnly = true
Me.TextBox85.Size = New System.Drawing.Size(55, 20)
Me.TextBox85.TabIndex = 8
Me.TextBox85.Text = ""
'
'Panel126
'
Me.Panel126.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel126.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel126.Controls.Add(Me.Label64)
Me.Panel126.Location = New System.Drawing.Point(260, 147)
Me.Panel126.Name = "Panel126"
Me.Panel126.Size = New System.Drawing.Size(177, 48)
Me.Panel126.TabIndex = 203
'
'Label64
'
Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label64.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label64.Location = New System.Drawing.Point(8, 16)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(160, 16)
Me.Label64.TabIndex = 6
Me.Label64.Text = "Hétérogénité d'alimentation :"
Me.Label64.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel131
'
Me.Panel131.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel131.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel131.Controls.Add(Me.Label65)
Me.Panel131.Controls.Add(Me.Label66)
Me.Panel131.Controls.Add(Me.TextBox86)
Me.Panel131.Controls.Add(Me.TextBox87)
Me.Panel131.Location = New System.Drawing.Point(28, 27)
Me.Panel131.Name = "Panel131"
Me.Panel131.Size = New System.Drawing.Size(912, 24)
Me.Panel131.TabIndex = 220
'
'Label65
'
Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label65.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label65.Location = New System.Drawing.Point(8, 4)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(128, 16)
Me.Label65.TabIndex = 6
Me.Label65.Text = "Pression Mano Pulvé :"
Me.Label65.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label66
'
Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label66.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label66.Location = New System.Drawing.Point(632, 4)
Me.Label66.Name = "Label66"
Me.Label66.Size = New System.Drawing.Size(136, 16)
Me.Label66.TabIndex = 6
Me.Label66.Text = "Moyenne des pressions :"
Me.Label66.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox86
'
Me.TextBox86.Location = New System.Drawing.Point(144, 2)
Me.TextBox86.Name = "TextBox86"
Me.TextBox86.ReadOnly = true
Me.TextBox86.Size = New System.Drawing.Size(83, 20)
Me.TextBox86.TabIndex = 8
Me.TextBox86.Text = "5"
'
'TextBox87
'
Me.TextBox87.Location = New System.Drawing.Point(776, 2)
Me.TextBox87.Name = "TextBox87"
Me.TextBox87.ReadOnly = true
Me.TextBox87.Size = New System.Drawing.Size(83, 20)
Me.TextBox87.TabIndex = 8
Me.TextBox87.Text = ""
'
'Panel134
'
Me.Panel134.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel134.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel134.Controls.Add(Me.TextBox88)
Me.Panel134.Location = New System.Drawing.Point(748, 99)
Me.Panel134.Name = "Panel134"
Me.Panel134.Size = New System.Drawing.Size(64, 24)
Me.Panel134.TabIndex = 179
'
'TextBox88
'
Me.TextBox88.Location = New System.Drawing.Point(3, 2)
Me.TextBox88.Name = "TextBox88"
Me.TextBox88.ReadOnly = true
Me.TextBox88.Size = New System.Drawing.Size(55, 20)
Me.TextBox88.TabIndex = 8
Me.TextBox88.Text = ""
'
'Panel135
'
Me.Panel135.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel135.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel135.Controls.Add(Me.Label67)
Me.Panel135.Controls.Add(Me.Label68)
Me.Panel135.Location = New System.Drawing.Point(436, 147)
Me.Panel135.Name = "Panel135"
Me.Panel135.Size = New System.Drawing.Size(504, 48)
Me.Panel135.TabIndex = 202
'
'Label67
'
Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label67.Location = New System.Drawing.Point(48, 16)
Me.Label67.Name = "Label67"
Me.Label67.Size = New System.Drawing.Size(168, 16)
Me.Label67.TabIndex = 29
Me.Label67.Text = "OK"
Me.Label67.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label68
'
Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label68.ForeColor = System.Drawing.Color.Red
Me.Label68.Location = New System.Drawing.Point(48, 16)
Me.Label68.Name = "Label68"
Me.Label68.Size = New System.Drawing.Size(168, 16)
Me.Label68.TabIndex = 28
Me.Label68.Text = "DEFAUT"
Me.Label68.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel136
'
Me.Panel136.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel136.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel136.Controls.Add(Me.TextBox89)
Me.Panel136.Location = New System.Drawing.Point(620, 123)
Me.Panel136.Name = "Panel136"
Me.Panel136.Size = New System.Drawing.Size(64, 24)
Me.Panel136.TabIndex = 208
'
'TextBox89
'
Me.TextBox89.Location = New System.Drawing.Point(3, 2)
Me.TextBox89.Name = "TextBox89"
Me.TextBox89.ReadOnly = true
Me.TextBox89.Size = New System.Drawing.Size(55, 20)
Me.TextBox89.TabIndex = 8
Me.TextBox89.Text = ""
'
'Panel137
'
Me.Panel137.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel137.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel137.Controls.Add(Me.TextBox90)
Me.Panel137.Location = New System.Drawing.Point(748, 75)
Me.Panel137.Name = "Panel137"
Me.Panel137.Size = New System.Drawing.Size(64, 24)
Me.Panel137.TabIndex = 193
'
'TextBox90
'
Me.TextBox90.Location = New System.Drawing.Point(3, 2)
Me.TextBox90.Name = "TextBox90"
Me.TextBox90.Size = New System.Drawing.Size(55, 20)
Me.TextBox90.TabIndex = 8
Me.TextBox90.Text = ""
'
'Panel138
'
Me.Panel138.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel138.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel138.Controls.Add(Me.Label71)
Me.Panel138.Location = New System.Drawing.Point(748, 51)
Me.Panel138.Name = "Panel138"
Me.Panel138.Size = New System.Drawing.Size(64, 24)
Me.Panel138.TabIndex = 230
'
'Label71
'
Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label71.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label71.Location = New System.Drawing.Point(8, 4)
Me.Label71.Name = "Label71"
Me.Label71.Size = New System.Drawing.Size(48, 16)
Me.Label71.TabIndex = 6
Me.Label71.Text = "10"
Me.Label71.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel139
'
Me.Panel139.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel139.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel139.Controls.Add(Me.Label72)
Me.Panel139.Location = New System.Drawing.Point(236, 51)
Me.Panel139.Name = "Panel139"
Me.Panel139.Size = New System.Drawing.Size(64, 24)
Me.Panel139.TabIndex = 233
'
'Label72
'
Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label72.Location = New System.Drawing.Point(8, 4)
Me.Label72.Name = "Label72"
Me.Label72.Size = New System.Drawing.Size(48, 16)
Me.Label72.TabIndex = 6
Me.Label72.Text = "2"
Me.Label72.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel140
'
Me.Panel140.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel140.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel140.Controls.Add(Me.Label73)
Me.Panel140.Location = New System.Drawing.Point(28, 75)
Me.Panel140.Name = "Panel140"
Me.Panel140.Size = New System.Drawing.Size(144, 24)
Me.Panel140.TabIndex = 222
'
'Label73
'
Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label73.Location = New System.Drawing.Point(8, 4)
Me.Label73.Name = "Label73"
Me.Label73.Size = New System.Drawing.Size(128, 16)
Me.Label73.TabIndex = 6
Me.Label73.Text = "P sortie"
Me.Label73.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel141
'
Me.Panel141.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel141.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel141.Controls.Add(Me.TextBox91)
Me.Panel141.Location = New System.Drawing.Point(684, 99)
Me.Panel141.Name = "Panel141"
Me.Panel141.Size = New System.Drawing.Size(64, 24)
Me.Panel141.TabIndex = 180
'
'TextBox91
'
Me.TextBox91.Location = New System.Drawing.Point(3, 2)
Me.TextBox91.Name = "TextBox91"
Me.TextBox91.ReadOnly = true
Me.TextBox91.Size = New System.Drawing.Size(55, 20)
Me.TextBox91.TabIndex = 8
Me.TextBox91.Text = ""
'
'Panel142
'
Me.Panel142.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel142.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel142.Controls.Add(Me.Label90)
Me.Panel142.Location = New System.Drawing.Point(28, 99)
Me.Panel142.Name = "Panel142"
Me.Panel142.Size = New System.Drawing.Size(144, 24)
Me.Panel142.TabIndex = 221
'
'Label90
'
Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label90.Location = New System.Drawing.Point(8, 4)
Me.Label90.Name = "Label90"
Me.Label90.Size = New System.Drawing.Size(128, 16)
Me.Label90.TabIndex = 6
Me.Label90.Text = "Ecart"
Me.Label90.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel143
'
Me.Panel143.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel143.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel143.Controls.Add(Me.Label103)
Me.Panel143.Location = New System.Drawing.Point(28, 123)
Me.Panel143.Name = "Panel143"
Me.Panel143.Size = New System.Drawing.Size(144, 24)
Me.Panel143.TabIndex = 216
'
'Label103
'
Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label103.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label103.Location = New System.Drawing.Point(8, 4)
Me.Label103.Name = "Label103"
Me.Label103.Size = New System.Drawing.Size(128, 16)
Me.Label103.TabIndex = 6
Me.Label103.Text = "Perte charge"
Me.Label103.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel144
'
Me.Panel144.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel144.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel144.Controls.Add(Me.Label104)
Me.Panel144.Location = New System.Drawing.Point(28, 147)
Me.Panel144.Name = "Panel144"
Me.Panel144.Size = New System.Drawing.Size(144, 24)
Me.Panel144.TabIndex = 215
'
'Label104
'
Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label104.Location = New System.Drawing.Point(8, 4)
Me.Label104.Name = "Label104"
Me.Label104.Size = New System.Drawing.Size(128, 16)
Me.Label104.TabIndex = 6
Me.Label104.Text = "Perte de charge moy"
Me.Label104.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel145
'
Me.Panel145.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel145.Controls.Add(Me.TextBox92)
Me.Panel145.Location = New System.Drawing.Point(812, 99)
Me.Panel145.Name = "Panel145"
Me.Panel145.Size = New System.Drawing.Size(64, 24)
Me.Panel145.TabIndex = 176
'
'TextBox92
'
Me.TextBox92.Location = New System.Drawing.Point(3, 2)
Me.TextBox92.Name = "TextBox92"
Me.TextBox92.ReadOnly = true
Me.TextBox92.Size = New System.Drawing.Size(55, 20)
Me.TextBox92.TabIndex = 8
Me.TextBox92.Text = ""
'
'Panel146
'
Me.Panel146.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel146.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel146.Controls.Add(Me.Label105)
Me.Panel146.Location = New System.Drawing.Point(28, 171)
Me.Panel146.Name = "Panel146"
Me.Panel146.Size = New System.Drawing.Size(144, 24)
Me.Panel146.TabIndex = 217
'
'Label105
'
Me.Label105.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label105.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label105.Location = New System.Drawing.Point(8, 4)
Me.Label105.Name = "Label105"
Me.Label105.Size = New System.Drawing.Size(128, 16)
Me.Label105.TabIndex = 6
Me.Label105.Text = "Perte de charge max"
Me.Label105.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel147
'
Me.Panel147.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel147.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel147.Controls.Add(Me.Label106)
Me.Panel147.Location = New System.Drawing.Point(28, 51)
Me.Panel147.Name = "Panel147"
Me.Panel147.Size = New System.Drawing.Size(144, 24)
Me.Panel147.TabIndex = 219
'
'Label106
'
Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label106.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label106.Location = New System.Drawing.Point(8, 4)
Me.Label106.Name = "Label106"
Me.Label106.Size = New System.Drawing.Size(128, 16)
Me.Label106.TabIndex = 6
Me.Label106.Text = "Tronçon"
Me.Label106.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel148
'
Me.Panel148.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel148.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel148.Controls.Add(Me.Label107)
Me.Panel148.Location = New System.Drawing.Point(300, 51)
Me.Panel148.Name = "Panel148"
Me.Panel148.Size = New System.Drawing.Size(64, 24)
Me.Panel148.TabIndex = 232
'
'Label107
'
Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label107.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label107.Location = New System.Drawing.Point(8, 4)
Me.Label107.Name = "Label107"
Me.Label107.Size = New System.Drawing.Size(48, 16)
Me.Label107.TabIndex = 6
Me.Label107.Text = "3"
Me.Label107.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel149
'
Me.Panel149.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel149.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel149.Controls.Add(Me.TextBox93)
Me.Panel149.Location = New System.Drawing.Point(876, 123)
Me.Panel149.Name = "Panel149"
Me.Panel149.Size = New System.Drawing.Size(64, 24)
Me.Panel149.TabIndex = 210
'
'TextBox93
'
Me.TextBox93.Location = New System.Drawing.Point(3, 2)
Me.TextBox93.Name = "TextBox93"
Me.TextBox93.ReadOnly = true
Me.TextBox93.Size = New System.Drawing.Size(55, 20)
Me.TextBox93.TabIndex = 8
Me.TextBox93.Text = ""
'
'Panel150
'
Me.Panel150.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel150.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel150.Controls.Add(Me.TextBox94)
Me.Panel150.Location = New System.Drawing.Point(812, 75)
Me.Panel150.Name = "Panel150"
Me.Panel150.Size = New System.Drawing.Size(64, 24)
Me.Panel150.TabIndex = 194
'
'TextBox94
'
Me.TextBox94.Location = New System.Drawing.Point(3, 2)
Me.TextBox94.Name = "TextBox94"
Me.TextBox94.Size = New System.Drawing.Size(55, 20)
Me.TextBox94.TabIndex = 8
Me.TextBox94.Text = ""
'
'Panel151
'
Me.Panel151.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel151.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel151.Controls.Add(Me.TextBox95)
Me.Panel151.Location = New System.Drawing.Point(812, 123)
Me.Panel151.Name = "Panel151"
Me.Panel151.Size = New System.Drawing.Size(64, 24)
Me.Panel151.TabIndex = 209
'
'TextBox95
'
Me.TextBox95.Location = New System.Drawing.Point(3, 2)
Me.TextBox95.Name = "TextBox95"
Me.TextBox95.ReadOnly = true
Me.TextBox95.Size = New System.Drawing.Size(55, 20)
Me.TextBox95.TabIndex = 8
Me.TextBox95.Text = ""
'
'Panel152
'
Me.Panel152.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel152.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel152.Controls.Add(Me.Label108)
Me.Panel152.Location = New System.Drawing.Point(364, 51)
Me.Panel152.Name = "Panel152"
Me.Panel152.Size = New System.Drawing.Size(64, 24)
Me.Panel152.TabIndex = 234
'
'Label108
'
Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label108.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label108.Location = New System.Drawing.Point(8, 4)
Me.Label108.Name = "Label108"
Me.Label108.Size = New System.Drawing.Size(48, 16)
Me.Label108.TabIndex = 6
Me.Label108.Text = "4"
Me.Label108.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel153
'
Me.Panel153.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel153.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel153.Controls.Add(Me.Label109)
Me.Panel153.Location = New System.Drawing.Point(428, 51)
Me.Panel153.Name = "Panel153"
Me.Panel153.Size = New System.Drawing.Size(64, 24)
Me.Panel153.TabIndex = 223
'
'Label109
'
Me.Label109.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label109.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label109.Location = New System.Drawing.Point(8, 4)
Me.Label109.Name = "Label109"
Me.Label109.Size = New System.Drawing.Size(48, 16)
Me.Label109.TabIndex = 6
Me.Label109.Text = "5"
Me.Label109.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel154
'
Me.Panel154.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel154.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel154.Controls.Add(Me.TextBox96)
Me.Panel154.Location = New System.Drawing.Point(620, 99)
Me.Panel154.Name = "Panel154"
Me.Panel154.Size = New System.Drawing.Size(64, 24)
Me.Panel154.TabIndex = 181
'
'TextBox96
'
Me.TextBox96.Location = New System.Drawing.Point(3, 2)
Me.TextBox96.Name = "TextBox96"
Me.TextBox96.ReadOnly = true
Me.TextBox96.Size = New System.Drawing.Size(55, 20)
Me.TextBox96.TabIndex = 8
Me.TextBox96.Text = ""
'
'Panel155
'
Me.Panel155.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel155.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel155.Controls.Add(Me.TextBox97)
Me.Panel155.Location = New System.Drawing.Point(620, 75)
Me.Panel155.Name = "Panel155"
Me.Panel155.Size = New System.Drawing.Size(64, 24)
Me.Panel155.TabIndex = 195
'
'TextBox97
'
Me.TextBox97.Location = New System.Drawing.Point(3, 2)
Me.TextBox97.Name = "TextBox97"
Me.TextBox97.Size = New System.Drawing.Size(55, 20)
Me.TextBox97.TabIndex = 8
Me.TextBox97.Text = ""
'
'Panel156
'
Me.Panel156.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel156.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel156.Controls.Add(Me.Label110)
Me.Panel156.Location = New System.Drawing.Point(492, 51)
Me.Panel156.Name = "Panel156"
Me.Panel156.Size = New System.Drawing.Size(64, 24)
Me.Panel156.TabIndex = 228
'
'Label110
'
Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label110.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label110.Location = New System.Drawing.Point(8, 4)
Me.Label110.Name = "Label110"
Me.Label110.Size = New System.Drawing.Size(48, 16)
Me.Label110.TabIndex = 6
Me.Label110.Text = "6"
Me.Label110.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel157
'
Me.Panel157.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel157.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel157.Controls.Add(Me.TextBox98)
Me.Panel157.Location = New System.Drawing.Point(172, 75)
Me.Panel157.Name = "Panel157"
Me.Panel157.Size = New System.Drawing.Size(64, 24)
Me.Panel157.TabIndex = 224
'
'TextBox98
'
Me.TextBox98.Location = New System.Drawing.Point(3, 2)
Me.TextBox98.Name = "TextBox98"
Me.TextBox98.Size = New System.Drawing.Size(55, 20)
Me.TextBox98.TabIndex = 8
Me.TextBox98.Text = ""
'
'Panel158
'
Me.Panel158.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel158.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel158.Controls.Add(Me.TextBox99)
Me.Panel158.Location = New System.Drawing.Point(236, 75)
Me.Panel158.Name = "Panel158"
Me.Panel158.Size = New System.Drawing.Size(64, 24)
Me.Panel158.TabIndex = 188
'
'TextBox99
'
Me.TextBox99.Location = New System.Drawing.Point(3, 2)
Me.TextBox99.Name = "TextBox99"
Me.TextBox99.Size = New System.Drawing.Size(55, 20)
Me.TextBox99.TabIndex = 8
Me.TextBox99.Text = ""
'
'Panel159
'
Me.Panel159.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel159.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel159.Controls.Add(Me.TextBox100)
Me.Panel159.Location = New System.Drawing.Point(684, 75)
Me.Panel159.Name = "Panel159"
Me.Panel159.Size = New System.Drawing.Size(64, 24)
Me.Panel159.TabIndex = 196
'
'TextBox100
'
Me.TextBox100.Location = New System.Drawing.Point(3, 2)
Me.TextBox100.Name = "TextBox100"
Me.TextBox100.Size = New System.Drawing.Size(55, 20)
Me.TextBox100.TabIndex = 8
Me.TextBox100.Text = ""
'
'Panel160
'
Me.Panel160.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel160.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel160.Controls.Add(Me.TextBox101)
Me.Panel160.Location = New System.Drawing.Point(300, 75)
Me.Panel160.Name = "Panel160"
Me.Panel160.Size = New System.Drawing.Size(64, 24)
Me.Panel160.TabIndex = 187
'
'TextBox101
'
Me.TextBox101.Location = New System.Drawing.Point(3, 2)
Me.TextBox101.Name = "TextBox101"
Me.TextBox101.Size = New System.Drawing.Size(55, 20)
Me.TextBox101.TabIndex = 8
Me.TextBox101.Text = ""
'
'Panel161
'
Me.Panel161.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel161.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel161.Controls.Add(Me.TextBox102)
Me.Panel161.Location = New System.Drawing.Point(364, 75)
Me.Panel161.Name = "Panel161"
Me.Panel161.Size = New System.Drawing.Size(64, 24)
Me.Panel161.TabIndex = 189
'
'TextBox102
'
Me.TextBox102.Location = New System.Drawing.Point(3, 2)
Me.TextBox102.Name = "TextBox102"
Me.TextBox102.Size = New System.Drawing.Size(55, 20)
Me.TextBox102.TabIndex = 8
Me.TextBox102.Text = ""
'
'Panel162
'
Me.Panel162.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel162.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel162.Controls.Add(Me.TextBox103)
Me.Panel162.Location = New System.Drawing.Point(876, 75)
Me.Panel162.Name = "Panel162"
Me.Panel162.Size = New System.Drawing.Size(64, 24)
Me.Panel162.TabIndex = 191
'
'TextBox103
'
Me.TextBox103.Location = New System.Drawing.Point(3, 2)
Me.TextBox103.Name = "TextBox103"
Me.TextBox103.Size = New System.Drawing.Size(55, 20)
Me.TextBox103.TabIndex = 8
Me.TextBox103.Text = ""
'
'Panel163
'
Me.Panel163.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel163.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel163.Controls.Add(Me.TextBox104)
Me.Panel163.Location = New System.Drawing.Point(428, 75)
Me.Panel163.Name = "Panel163"
Me.Panel163.Size = New System.Drawing.Size(64, 24)
Me.Panel163.TabIndex = 197
'
'TextBox104
'
Me.TextBox104.Location = New System.Drawing.Point(3, 2)
Me.TextBox104.Name = "TextBox104"
Me.TextBox104.Size = New System.Drawing.Size(55, 20)
Me.TextBox104.TabIndex = 8
Me.TextBox104.Text = ""
'
'Panel164
'
Me.Panel164.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel164.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel164.Controls.Add(Me.TextBox105)
Me.Panel164.Location = New System.Drawing.Point(236, 99)
Me.Panel164.Name = "Panel164"
Me.Panel164.Size = New System.Drawing.Size(64, 24)
Me.Panel164.TabIndex = 183
'
'TextBox105
'
Me.TextBox105.Location = New System.Drawing.Point(3, 2)
Me.TextBox105.Name = "TextBox105"
Me.TextBox105.ReadOnly = true
Me.TextBox105.Size = New System.Drawing.Size(55, 20)
Me.TextBox105.TabIndex = 8
Me.TextBox105.Text = ""
'
'Panel165
'
Me.Panel165.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel165.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel165.Controls.Add(Me.TextBox106)
Me.Panel165.Location = New System.Drawing.Point(492, 75)
Me.Panel165.Name = "Panel165"
Me.Panel165.Size = New System.Drawing.Size(64, 24)
Me.Panel165.TabIndex = 192
'
'TextBox106
'
Me.TextBox106.Location = New System.Drawing.Point(3, 2)
Me.TextBox106.Name = "TextBox106"
Me.TextBox106.Size = New System.Drawing.Size(55, 20)
Me.TextBox106.TabIndex = 8
Me.TextBox106.Text = ""
'
'Panel293
'
Me.Panel293.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel293.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel293.Controls.Add(Me.TextBox107)
Me.Panel293.Location = New System.Drawing.Point(492, 99)
Me.Panel293.Name = "Panel293"
Me.Panel293.Size = New System.Drawing.Size(64, 24)
Me.Panel293.TabIndex = 182
'
'TextBox107
'
Me.TextBox107.Location = New System.Drawing.Point(3, 2)
Me.TextBox107.Name = "TextBox107"
Me.TextBox107.ReadOnly = true
Me.TextBox107.Size = New System.Drawing.Size(55, 20)
Me.TextBox107.TabIndex = 8
Me.TextBox107.Text = ""
'
'Panel294
'
Me.Panel294.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel294.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel294.Controls.Add(Me.TextBox108)
Me.Panel294.Location = New System.Drawing.Point(556, 75)
Me.Panel294.Name = "Panel294"
Me.Panel294.Size = New System.Drawing.Size(64, 24)
Me.Panel294.TabIndex = 190
'
'TextBox108
'
Me.TextBox108.Location = New System.Drawing.Point(3, 2)
Me.TextBox108.Name = "TextBox108"
Me.TextBox108.Size = New System.Drawing.Size(55, 20)
Me.TextBox108.TabIndex = 8
Me.TextBox108.Text = ""
'
'Panel295
'
Me.Panel295.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel295.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel295.Controls.Add(Me.TextBox109)
Me.Panel295.Location = New System.Drawing.Point(364, 99)
Me.Panel295.Name = "Panel295"
Me.Panel295.Size = New System.Drawing.Size(64, 24)
Me.Panel295.TabIndex = 184
'
'TextBox109
'
Me.TextBox109.Location = New System.Drawing.Point(3, 2)
Me.TextBox109.Name = "TextBox109"
Me.TextBox109.ReadOnly = true
Me.TextBox109.Size = New System.Drawing.Size(55, 20)
Me.TextBox109.TabIndex = 8
Me.TextBox109.Text = ""
'
'Panel296
'
Me.Panel296.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel296.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel296.Controls.Add(Me.TextBox110)
Me.Panel296.Location = New System.Drawing.Point(556, 99)
Me.Panel296.Name = "Panel296"
Me.Panel296.Size = New System.Drawing.Size(64, 24)
Me.Panel296.TabIndex = 177
'
'TextBox110
'
Me.TextBox110.Location = New System.Drawing.Point(3, 2)
Me.TextBox110.Name = "TextBox110"
Me.TextBox110.ReadOnly = true
Me.TextBox110.Size = New System.Drawing.Size(55, 20)
Me.TextBox110.TabIndex = 8
Me.TextBox110.Text = ""
'
'Panel297
'
Me.Panel297.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel297.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel297.Controls.Add(Me.TextBox111)
Me.Panel297.Location = New System.Drawing.Point(428, 99)
Me.Panel297.Name = "Panel297"
Me.Panel297.Size = New System.Drawing.Size(64, 24)
Me.Panel297.TabIndex = 186
'
'TextBox111
'
Me.TextBox111.Location = New System.Drawing.Point(3, 2)
Me.TextBox111.Name = "TextBox111"
Me.TextBox111.ReadOnly = true
Me.TextBox111.Size = New System.Drawing.Size(55, 20)
Me.TextBox111.TabIndex = 8
Me.TextBox111.Text = ""
'
'Panel298
'
Me.Panel298.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel298.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel298.Controls.Add(Me.TextBox112)
Me.Panel298.Location = New System.Drawing.Point(172, 99)
Me.Panel298.Name = "Panel298"
Me.Panel298.Size = New System.Drawing.Size(64, 24)
Me.Panel298.TabIndex = 185
'
'TextBox112
'
Me.TextBox112.Location = New System.Drawing.Point(3, 2)
Me.TextBox112.Name = "TextBox112"
Me.TextBox112.ReadOnly = true
Me.TextBox112.Size = New System.Drawing.Size(55, 20)
Me.TextBox112.TabIndex = 8
Me.TextBox112.Text = ""
'
'Panel299
'
Me.Panel299.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel299.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel299.Controls.Add(Me.TextBox113)
Me.Panel299.Location = New System.Drawing.Point(748, 123)
Me.Panel299.Name = "Panel299"
Me.Panel299.Size = New System.Drawing.Size(64, 24)
Me.Panel299.TabIndex = 212
'
'TextBox113
'
Me.TextBox113.Location = New System.Drawing.Point(3, 2)
Me.TextBox113.Name = "TextBox113"
Me.TextBox113.ReadOnly = true
Me.TextBox113.Size = New System.Drawing.Size(55, 20)
Me.TextBox113.TabIndex = 8
Me.TextBox113.Text = ""
'
'Panel300
'
Me.Panel300.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel300.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel300.Controls.Add(Me.Label111)
Me.Panel300.Location = New System.Drawing.Point(556, 51)
Me.Panel300.Name = "Panel300"
Me.Panel300.Size = New System.Drawing.Size(64, 24)
Me.Panel300.TabIndex = 227
'
'Label111
'
Me.Label111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label111.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label111.Location = New System.Drawing.Point(8, 4)
Me.Label111.Name = "Label111"
Me.Label111.Size = New System.Drawing.Size(48, 16)
Me.Label111.TabIndex = 6
Me.Label111.Text = "7"
Me.Label111.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel301
'
Me.Panel301.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel301.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel301.Controls.Add(Me.TextBox114)
Me.Panel301.Location = New System.Drawing.Point(300, 99)
Me.Panel301.Name = "Panel301"
Me.Panel301.Size = New System.Drawing.Size(64, 24)
Me.Panel301.TabIndex = 198
'
'TextBox114
'
Me.TextBox114.Location = New System.Drawing.Point(3, 2)
Me.TextBox114.Name = "TextBox114"
Me.TextBox114.ReadOnly = true
Me.TextBox114.Size = New System.Drawing.Size(55, 20)
Me.TextBox114.TabIndex = 8
Me.TextBox114.Text = ""
'
'Panel302
'
Me.Panel302.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel302.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel302.Controls.Add(Me.TextBox115)
Me.Panel302.Location = New System.Drawing.Point(556, 123)
Me.Panel302.Name = "Panel302"
Me.Panel302.Size = New System.Drawing.Size(64, 24)
Me.Panel302.TabIndex = 207
'
'TextBox115
'
Me.TextBox115.Location = New System.Drawing.Point(3, 2)
Me.TextBox115.Name = "TextBox115"
Me.TextBox115.ReadOnly = true
Me.TextBox115.Size = New System.Drawing.Size(55, 20)
Me.TextBox115.TabIndex = 8
Me.TextBox115.Text = ""
'
'Panel303
'
Me.Panel303.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel303.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel303.Controls.Add(Me.TextBox116)
Me.Panel303.Location = New System.Drawing.Point(364, 123)
Me.Panel303.Name = "Panel303"
Me.Panel303.Size = New System.Drawing.Size(64, 24)
Me.Panel303.TabIndex = 205
'
'TextBox116
'
Me.TextBox116.Location = New System.Drawing.Point(3, 2)
Me.TextBox116.Name = "TextBox116"
Me.TextBox116.ReadOnly = true
Me.TextBox116.Size = New System.Drawing.Size(55, 20)
Me.TextBox116.TabIndex = 8
Me.TextBox116.Text = ""
'
'Panel304
'
Me.Panel304.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel304.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel304.Controls.Add(Me.Label112)
Me.Panel304.Location = New System.Drawing.Point(620, 51)
Me.Panel304.Name = "Panel304"
Me.Panel304.Size = New System.Drawing.Size(64, 24)
Me.Panel304.TabIndex = 229
'
'Label112
'
Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label112.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label112.Location = New System.Drawing.Point(8, 4)
Me.Label112.Name = "Label112"
Me.Label112.Size = New System.Drawing.Size(48, 16)
Me.Label112.TabIndex = 6
Me.Label112.Text = "8"
Me.Label112.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel305
'
Me.Panel305.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel305.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel305.Controls.Add(Me.TextBox117)
Me.Panel305.Location = New System.Drawing.Point(428, 123)
Me.Panel305.Name = "Panel305"
Me.Panel305.Size = New System.Drawing.Size(64, 24)
Me.Panel305.TabIndex = 204
'
'TextBox117
'
Me.TextBox117.Location = New System.Drawing.Point(3, 2)
Me.TextBox117.Name = "TextBox117"
Me.TextBox117.ReadOnly = true
Me.TextBox117.Size = New System.Drawing.Size(55, 20)
Me.TextBox117.TabIndex = 8
Me.TextBox117.Text = ""
'
'Panel306
'
Me.Panel306.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel306.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel306.Controls.Add(Me.TextBox118)
Me.Panel306.Location = New System.Drawing.Point(492, 123)
Me.Panel306.Name = "Panel306"
Me.Panel306.Size = New System.Drawing.Size(64, 24)
Me.Panel306.TabIndex = 211
'
'TextBox118
'
Me.TextBox118.Location = New System.Drawing.Point(3, 2)
Me.TextBox118.Name = "TextBox118"
Me.TextBox118.ReadOnly = true
Me.TextBox118.Size = New System.Drawing.Size(55, 20)
Me.TextBox118.TabIndex = 8
Me.TextBox118.Text = ""
'
'Panel307
'
Me.Panel307.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel307.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel307.Controls.Add(Me.Label113)
Me.Panel307.Location = New System.Drawing.Point(812, 51)
Me.Panel307.Name = "Panel307"
Me.Panel307.Size = New System.Drawing.Size(64, 24)
Me.Panel307.TabIndex = 226
'
'Label113
'
Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label113.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label113.Location = New System.Drawing.Point(8, 4)
Me.Label113.Name = "Label113"
Me.Label113.Size = New System.Drawing.Size(48, 16)
Me.Label113.TabIndex = 6
Me.Label113.Text = "11"
Me.Label113.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel308
'
Me.Panel308.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel308.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel308.Controls.Add(Me.TextBox119)
Me.Panel308.Location = New System.Drawing.Point(236, 123)
Me.Panel308.Name = "Panel308"
Me.Panel308.Size = New System.Drawing.Size(64, 24)
Me.Panel308.TabIndex = 214
'
'TextBox119
'
Me.TextBox119.Location = New System.Drawing.Point(3, 2)
Me.TextBox119.Name = "TextBox119"
Me.TextBox119.ReadOnly = true
Me.TextBox119.Size = New System.Drawing.Size(55, 20)
Me.TextBox119.TabIndex = 8
Me.TextBox119.Text = ""
'
'Panel309
'
Me.Panel309.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel309.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel309.Controls.Add(Me.TextBox120)
Me.Panel309.Location = New System.Drawing.Point(172, 123)
Me.Panel309.Name = "Panel309"
Me.Panel309.Size = New System.Drawing.Size(64, 24)
Me.Panel309.TabIndex = 213
'
'TextBox120
'
Me.TextBox120.Location = New System.Drawing.Point(3, 2)
Me.TextBox120.Name = "TextBox120"
Me.TextBox120.ReadOnly = true
Me.TextBox120.Size = New System.Drawing.Size(55, 20)
Me.TextBox120.TabIndex = 8
Me.TextBox120.Text = ""
'
'Panel310
'
Me.Panel310.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel310.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel310.Controls.Add(Me.TextBox197)
Me.Panel310.Location = New System.Drawing.Point(300, 123)
Me.Panel310.Name = "Panel310"
Me.Panel310.Size = New System.Drawing.Size(64, 24)
Me.Panel310.TabIndex = 200
'
'TextBox197
'
Me.TextBox197.Location = New System.Drawing.Point(3, 2)
Me.TextBox197.Name = "TextBox197"
Me.TextBox197.ReadOnly = true
Me.TextBox197.Size = New System.Drawing.Size(55, 20)
Me.TextBox197.TabIndex = 8
Me.TextBox197.Text = ""
'
'Panel311
'
Me.Panel311.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel311.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel311.Controls.Add(Me.TextBox198)
Me.Panel311.Location = New System.Drawing.Point(876, 99)
Me.Panel311.Name = "Panel311"
Me.Panel311.Size = New System.Drawing.Size(64, 24)
Me.Panel311.TabIndex = 178
'
'TextBox198
'
Me.TextBox198.Location = New System.Drawing.Point(3, 2)
Me.TextBox198.Name = "TextBox198"
Me.TextBox198.ReadOnly = true
Me.TextBox198.Size = New System.Drawing.Size(55, 20)
Me.TextBox198.TabIndex = 8
Me.TextBox198.Text = ""
'
'Panel312
'
Me.Panel312.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel312.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel312.Controls.Add(Me.TextBox199)
Me.Panel312.Location = New System.Drawing.Point(172, 147)
Me.Panel312.Name = "Panel312"
Me.Panel312.Size = New System.Drawing.Size(89, 24)
Me.Panel312.TabIndex = 199
'
'TextBox199
'
Me.TextBox199.Location = New System.Drawing.Point(3, 2)
Me.TextBox199.Name = "TextBox199"
Me.TextBox199.ReadOnly = true
Me.TextBox199.Size = New System.Drawing.Size(83, 20)
Me.TextBox199.TabIndex = 8
Me.TextBox199.Text = ""
'
'Panel313
'
Me.Panel313.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel313.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel313.Controls.Add(Me.Label114)
Me.Panel313.Location = New System.Drawing.Point(876, 51)
Me.Panel313.Name = "Panel313"
Me.Panel313.Size = New System.Drawing.Size(64, 24)
Me.Panel313.TabIndex = 225
'
'Label114
'
Me.Label114.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label114.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label114.Location = New System.Drawing.Point(8, 4)
Me.Label114.Name = "Label114"
Me.Label114.Size = New System.Drawing.Size(48, 16)
Me.Label114.TabIndex = 6
Me.Label114.Text = "12"
Me.Label114.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel314
'
Me.Panel314.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel314.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel314.Controls.Add(Me.Label115)
Me.Panel314.Location = New System.Drawing.Point(172, 51)
Me.Panel314.Name = "Panel314"
Me.Panel314.Size = New System.Drawing.Size(64, 24)
Me.Panel314.TabIndex = 218
'
'Label115
'
Me.Label115.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label115.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label115.Location = New System.Drawing.Point(8, 4)
Me.Label115.Name = "Label115"
Me.Label115.Size = New System.Drawing.Size(48, 16)
Me.Label115.TabIndex = 6
Me.Label115.Text = "1"
Me.Label115.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel315
'
Me.Panel315.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel315.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel315.Controls.Add(Me.Label116)
Me.Panel315.Location = New System.Drawing.Point(684, 51)
Me.Panel315.Name = "Panel315"
Me.Panel315.Size = New System.Drawing.Size(64, 24)
Me.Panel315.TabIndex = 231
'
'Label116
'
Me.Label116.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label116.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label116.Location = New System.Drawing.Point(8, 4)
Me.Label116.Name = "Label116"
Me.Label116.Size = New System.Drawing.Size(48, 16)
Me.Label116.TabIndex = 6
Me.Label116.Text = "9"
Me.Label116.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel316
'
Me.Panel316.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel316.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel316.Controls.Add(Me.TextBox200)
Me.Panel316.Location = New System.Drawing.Point(172, 171)
Me.Panel316.Name = "Panel316"
Me.Panel316.Size = New System.Drawing.Size(89, 24)
Me.Panel316.TabIndex = 201
'
'TextBox200
'
Me.TextBox200.Location = New System.Drawing.Point(3, 2)
Me.TextBox200.Name = "TextBox200"
Me.TextBox200.ReadOnly = true
Me.TextBox200.Size = New System.Drawing.Size(83, 20)
Me.TextBox200.TabIndex = 8
Me.TextBox200.Text = ""
'
'Panel317
'
Me.Panel317.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel317.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel317.Controls.Add(Me.TextBox201)
Me.Panel317.Location = New System.Drawing.Point(684, 123)
Me.Panel317.Name = "Panel317"
Me.Panel317.Size = New System.Drawing.Size(64, 24)
Me.Panel317.TabIndex = 206
'
'TextBox201
'
Me.TextBox201.Location = New System.Drawing.Point(3, 2)
Me.TextBox201.Name = "TextBox201"
Me.TextBox201.ReadOnly = true
Me.TextBox201.Size = New System.Drawing.Size(55, 20)
Me.TextBox201.TabIndex = 8
Me.TextBox201.Text = ""
'
'Panel318
'
Me.Panel318.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel318.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel318.Controls.Add(Me.Label117)
Me.Panel318.Location = New System.Drawing.Point(260, 147)
Me.Panel318.Name = "Panel318"
Me.Panel318.Size = New System.Drawing.Size(177, 48)
Me.Panel318.TabIndex = 203
'
'Label117
'
Me.Label117.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label117.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label117.Location = New System.Drawing.Point(8, 16)
Me.Label117.Name = "Label117"
Me.Label117.Size = New System.Drawing.Size(160, 16)
Me.Label117.TabIndex = 6
Me.Label117.Text = "Hétérogénité d'alimentation :"
Me.Label117.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel319
'
Me.Panel319.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel319.Controls.Add(Me.Label118)
Me.Panel319.Controls.Add(Me.Label119)
Me.Panel319.Controls.Add(Me.TextBox202)
Me.Panel319.Controls.Add(Me.TextBox203)
Me.Panel319.Location = New System.Drawing.Point(28, 27)
Me.Panel319.Name = "Panel319"
Me.Panel319.Size = New System.Drawing.Size(912, 24)
Me.Panel319.TabIndex = 220
'
'Label118
'
Me.Label118.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label118.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label118.Location = New System.Drawing.Point(8, 4)
Me.Label118.Name = "Label118"
Me.Label118.Size = New System.Drawing.Size(128, 16)
Me.Label118.TabIndex = 6
Me.Label118.Text = "Pression Mano Pulvé :"
Me.Label118.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label119
'
Me.Label119.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label119.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label119.Location = New System.Drawing.Point(632, 4)
Me.Label119.Name = "Label119"
Me.Label119.Size = New System.Drawing.Size(136, 16)
Me.Label119.TabIndex = 6
Me.Label119.Text = "Moyenne des pressions :"
Me.Label119.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox202
'
Me.TextBox202.Location = New System.Drawing.Point(144, 2)
Me.TextBox202.Name = "TextBox202"
Me.TextBox202.ReadOnly = true
Me.TextBox202.Size = New System.Drawing.Size(83, 20)
Me.TextBox202.TabIndex = 8
Me.TextBox202.Text = "5"
'
'TextBox203
'
Me.TextBox203.Location = New System.Drawing.Point(776, 2)
Me.TextBox203.Name = "TextBox203"
Me.TextBox203.ReadOnly = true
Me.TextBox203.Size = New System.Drawing.Size(83, 20)
Me.TextBox203.TabIndex = 8
Me.TextBox203.Text = ""
'
'Panel320
'
Me.Panel320.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel320.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel320.Controls.Add(Me.TextBox204)
Me.Panel320.Location = New System.Drawing.Point(748, 99)
Me.Panel320.Name = "Panel320"
Me.Panel320.Size = New System.Drawing.Size(64, 24)
Me.Panel320.TabIndex = 179
'
'TextBox204
'
Me.TextBox204.Location = New System.Drawing.Point(3, 2)
Me.TextBox204.Name = "TextBox204"
Me.TextBox204.ReadOnly = true
Me.TextBox204.Size = New System.Drawing.Size(55, 20)
Me.TextBox204.TabIndex = 8
Me.TextBox204.Text = ""
'
'Panel321
'
Me.Panel321.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel321.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel321.Controls.Add(Me.Label120)
Me.Panel321.Controls.Add(Me.Label121)
Me.Panel321.Location = New System.Drawing.Point(436, 147)
Me.Panel321.Name = "Panel321"
Me.Panel321.Size = New System.Drawing.Size(504, 48)
Me.Panel321.TabIndex = 202
'
'Label120
'
Me.Label120.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label120.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label120.Location = New System.Drawing.Point(48, 16)
Me.Label120.Name = "Label120"
Me.Label120.Size = New System.Drawing.Size(168, 16)
Me.Label120.TabIndex = 29
Me.Label120.Text = "OK"
Me.Label120.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label121
'
Me.Label121.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label121.ForeColor = System.Drawing.Color.Red
Me.Label121.Location = New System.Drawing.Point(48, 16)
Me.Label121.Name = "Label121"
Me.Label121.Size = New System.Drawing.Size(168, 16)
Me.Label121.TabIndex = 28
Me.Label121.Text = "DEFAUT"
Me.Label121.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel322
'
Me.Panel322.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel322.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel322.Controls.Add(Me.TextBox205)
Me.Panel322.Location = New System.Drawing.Point(620, 123)
Me.Panel322.Name = "Panel322"
Me.Panel322.Size = New System.Drawing.Size(64, 24)
Me.Panel322.TabIndex = 208
'
'TextBox205
'
Me.TextBox205.Location = New System.Drawing.Point(3, 2)
Me.TextBox205.Name = "TextBox205"
Me.TextBox205.ReadOnly = true
Me.TextBox205.Size = New System.Drawing.Size(55, 20)
Me.TextBox205.TabIndex = 8
Me.TextBox205.Text = ""
'
'Panel372
'
Me.Panel372.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel372.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel372.Controls.Add(Me.TextBox206)
Me.Panel372.Location = New System.Drawing.Point(748, 75)
Me.Panel372.Name = "Panel372"
Me.Panel372.Size = New System.Drawing.Size(64, 24)
Me.Panel372.TabIndex = 193
'
'TextBox206
'
Me.TextBox206.Location = New System.Drawing.Point(3, 2)
Me.TextBox206.Name = "TextBox206"
Me.TextBox206.Size = New System.Drawing.Size(55, 20)
Me.TextBox206.TabIndex = 8
Me.TextBox206.Text = ""
'
'Panel373
'
Me.Panel373.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel373.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel373.Controls.Add(Me.Label223)
Me.Panel373.Location = New System.Drawing.Point(748, 51)
Me.Panel373.Name = "Panel373"
Me.Panel373.Size = New System.Drawing.Size(64, 24)
Me.Panel373.TabIndex = 230
'
'Label223
'
Me.Label223.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label223.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label223.Location = New System.Drawing.Point(8, 4)
Me.Label223.Name = "Label223"
Me.Label223.Size = New System.Drawing.Size(48, 16)
Me.Label223.TabIndex = 6
Me.Label223.Text = "10"
Me.Label223.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel374
'
Me.Panel374.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel374.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel374.Controls.Add(Me.Label224)
Me.Panel374.Location = New System.Drawing.Point(236, 51)
Me.Panel374.Name = "Panel374"
Me.Panel374.Size = New System.Drawing.Size(64, 24)
Me.Panel374.TabIndex = 233
'
'Label224
'
Me.Label224.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label224.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label224.Location = New System.Drawing.Point(8, 4)
Me.Label224.Name = "Label224"
Me.Label224.Size = New System.Drawing.Size(48, 16)
Me.Label224.TabIndex = 6
Me.Label224.Text = "2"
Me.Label224.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel375
'
Me.Panel375.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel375.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel375.Controls.Add(Me.Label225)
Me.Panel375.Location = New System.Drawing.Point(28, 75)
Me.Panel375.Name = "Panel375"
Me.Panel375.Size = New System.Drawing.Size(144, 24)
Me.Panel375.TabIndex = 222
'
'Label225
'
Me.Label225.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label225.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label225.Location = New System.Drawing.Point(8, 4)
Me.Label225.Name = "Label225"
Me.Label225.Size = New System.Drawing.Size(128, 16)
Me.Label225.TabIndex = 6
Me.Label225.Text = "P sortie"
Me.Label225.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel376
'
Me.Panel376.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel376.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel376.Controls.Add(Me.TextBox207)
Me.Panel376.Location = New System.Drawing.Point(684, 99)
Me.Panel376.Name = "Panel376"
Me.Panel376.Size = New System.Drawing.Size(64, 24)
Me.Panel376.TabIndex = 180
'
'TextBox207
'
Me.TextBox207.Location = New System.Drawing.Point(3, 2)
Me.TextBox207.Name = "TextBox207"
Me.TextBox207.ReadOnly = true
Me.TextBox207.Size = New System.Drawing.Size(55, 20)
Me.TextBox207.TabIndex = 8
Me.TextBox207.Text = ""
'
'Panel377
'
Me.Panel377.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel377.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel377.Controls.Add(Me.Label226)
Me.Panel377.Location = New System.Drawing.Point(28, 99)
Me.Panel377.Name = "Panel377"
Me.Panel377.Size = New System.Drawing.Size(144, 24)
Me.Panel377.TabIndex = 221
'
'Label226
'
Me.Label226.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label226.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label226.Location = New System.Drawing.Point(8, 4)
Me.Label226.Name = "Label226"
Me.Label226.Size = New System.Drawing.Size(128, 16)
Me.Label226.TabIndex = 6
Me.Label226.Text = "Ecart"
Me.Label226.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel378
'
Me.Panel378.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel378.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel378.Controls.Add(Me.Label227)
Me.Panel378.Location = New System.Drawing.Point(28, 123)
Me.Panel378.Name = "Panel378"
Me.Panel378.Size = New System.Drawing.Size(144, 24)
Me.Panel378.TabIndex = 216
'
'Label227
'
Me.Label227.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label227.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label227.Location = New System.Drawing.Point(8, 4)
Me.Label227.Name = "Label227"
Me.Label227.Size = New System.Drawing.Size(128, 16)
Me.Label227.TabIndex = 6
Me.Label227.Text = "Perte charge"
Me.Label227.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel379
'
Me.Panel379.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel379.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel379.Controls.Add(Me.Label228)
Me.Panel379.Location = New System.Drawing.Point(28, 147)
Me.Panel379.Name = "Panel379"
Me.Panel379.Size = New System.Drawing.Size(144, 24)
Me.Panel379.TabIndex = 215
'
'Label228
'
Me.Label228.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label228.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label228.Location = New System.Drawing.Point(8, 4)
Me.Label228.Name = "Label228"
Me.Label228.Size = New System.Drawing.Size(128, 16)
Me.Label228.TabIndex = 6
Me.Label228.Text = "Perte de charge moy"
Me.Label228.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel380
'
Me.Panel380.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel380.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel380.Controls.Add(Me.TextBox208)
Me.Panel380.Location = New System.Drawing.Point(812, 99)
Me.Panel380.Name = "Panel380"
Me.Panel380.Size = New System.Drawing.Size(64, 24)
Me.Panel380.TabIndex = 176
'
'TextBox208
'
Me.TextBox208.Location = New System.Drawing.Point(3, 2)
Me.TextBox208.Name = "TextBox208"
Me.TextBox208.ReadOnly = true
Me.TextBox208.Size = New System.Drawing.Size(55, 20)
Me.TextBox208.TabIndex = 8
Me.TextBox208.Text = ""
'
'Panel381
'
Me.Panel381.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel381.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel381.Controls.Add(Me.Label229)
Me.Panel381.Location = New System.Drawing.Point(28, 171)
Me.Panel381.Name = "Panel381"
Me.Panel381.Size = New System.Drawing.Size(144, 24)
Me.Panel381.TabIndex = 217
'
'Label229
'
Me.Label229.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label229.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label229.Location = New System.Drawing.Point(8, 4)
Me.Label229.Name = "Label229"
Me.Label229.Size = New System.Drawing.Size(128, 16)
Me.Label229.TabIndex = 6
Me.Label229.Text = "Perte de charge max"
Me.Label229.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel382
'
Me.Panel382.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel382.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel382.Controls.Add(Me.Label230)
Me.Panel382.Location = New System.Drawing.Point(28, 51)
Me.Panel382.Name = "Panel382"
Me.Panel382.Size = New System.Drawing.Size(144, 24)
Me.Panel382.TabIndex = 219
'
'Label230
'
Me.Label230.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label230.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label230.Location = New System.Drawing.Point(8, 4)
Me.Label230.Name = "Label230"
Me.Label230.Size = New System.Drawing.Size(128, 16)
Me.Label230.TabIndex = 6
Me.Label230.Text = "Tronçon"
Me.Label230.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel383
'
Me.Panel383.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel383.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel383.Controls.Add(Me.Label231)
Me.Panel383.Location = New System.Drawing.Point(300, 51)
Me.Panel383.Name = "Panel383"
Me.Panel383.Size = New System.Drawing.Size(64, 24)
Me.Panel383.TabIndex = 232
'
'Label231
'
Me.Label231.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label231.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label231.Location = New System.Drawing.Point(8, 4)
Me.Label231.Name = "Label231"
Me.Label231.Size = New System.Drawing.Size(48, 16)
Me.Label231.TabIndex = 6
Me.Label231.Text = "3"
Me.Label231.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel384
'
Me.Panel384.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel384.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel384.Controls.Add(Me.TextBox209)
Me.Panel384.Location = New System.Drawing.Point(876, 123)
Me.Panel384.Name = "Panel384"
Me.Panel384.Size = New System.Drawing.Size(64, 24)
Me.Panel384.TabIndex = 210
'
'TextBox209
'
Me.TextBox209.Location = New System.Drawing.Point(3, 2)
Me.TextBox209.Name = "TextBox209"
Me.TextBox209.ReadOnly = true
Me.TextBox209.Size = New System.Drawing.Size(55, 20)
Me.TextBox209.TabIndex = 8
Me.TextBox209.Text = ""
'
'Panel385
'
Me.Panel385.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel385.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel385.Controls.Add(Me.TextBox210)
Me.Panel385.Location = New System.Drawing.Point(812, 75)
Me.Panel385.Name = "Panel385"
Me.Panel385.Size = New System.Drawing.Size(64, 24)
Me.Panel385.TabIndex = 194
'
'TextBox210
'
Me.TextBox210.Location = New System.Drawing.Point(3, 2)
Me.TextBox210.Name = "TextBox210"
Me.TextBox210.Size = New System.Drawing.Size(55, 20)
Me.TextBox210.TabIndex = 8
Me.TextBox210.Text = ""
'
'Panel386
'
Me.Panel386.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel386.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel386.Controls.Add(Me.TextBox211)
Me.Panel386.Location = New System.Drawing.Point(812, 123)
Me.Panel386.Name = "Panel386"
Me.Panel386.Size = New System.Drawing.Size(64, 24)
Me.Panel386.TabIndex = 209
'
'TextBox211
'
Me.TextBox211.Location = New System.Drawing.Point(3, 2)
Me.TextBox211.Name = "TextBox211"
Me.TextBox211.ReadOnly = true
Me.TextBox211.Size = New System.Drawing.Size(55, 20)
Me.TextBox211.TabIndex = 8
Me.TextBox211.Text = ""
'
'Panel387
'
Me.Panel387.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel387.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel387.Controls.Add(Me.Label232)
Me.Panel387.Location = New System.Drawing.Point(364, 51)
Me.Panel387.Name = "Panel387"
Me.Panel387.Size = New System.Drawing.Size(64, 24)
Me.Panel387.TabIndex = 234
'
'Label232
'
Me.Label232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label232.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label232.Location = New System.Drawing.Point(8, 4)
Me.Label232.Name = "Label232"
Me.Label232.Size = New System.Drawing.Size(48, 16)
Me.Label232.TabIndex = 6
Me.Label232.Text = "4"
Me.Label232.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel388
'
Me.Panel388.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel388.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel388.Controls.Add(Me.Label233)
Me.Panel388.Location = New System.Drawing.Point(428, 51)
Me.Panel388.Name = "Panel388"
Me.Panel388.Size = New System.Drawing.Size(64, 24)
Me.Panel388.TabIndex = 223
'
'Label233
'
Me.Label233.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label233.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label233.Location = New System.Drawing.Point(8, 4)
Me.Label233.Name = "Label233"
Me.Label233.Size = New System.Drawing.Size(48, 16)
Me.Label233.TabIndex = 6
Me.Label233.Text = "5"
Me.Label233.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel389
'
Me.Panel389.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel389.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel389.Controls.Add(Me.TextBox212)
Me.Panel389.Location = New System.Drawing.Point(620, 99)
Me.Panel389.Name = "Panel389"
Me.Panel389.Size = New System.Drawing.Size(64, 24)
Me.Panel389.TabIndex = 181
'
'TextBox212
'
Me.TextBox212.Location = New System.Drawing.Point(3, 2)
Me.TextBox212.Name = "TextBox212"
Me.TextBox212.ReadOnly = true
Me.TextBox212.Size = New System.Drawing.Size(55, 20)
Me.TextBox212.TabIndex = 8
Me.TextBox212.Text = ""
'
'Panel390
'
Me.Panel390.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel390.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel390.Controls.Add(Me.TextBox213)
Me.Panel390.Location = New System.Drawing.Point(620, 75)
Me.Panel390.Name = "Panel390"
Me.Panel390.Size = New System.Drawing.Size(64, 24)
Me.Panel390.TabIndex = 195
'
'TextBox213
'
Me.TextBox213.Location = New System.Drawing.Point(3, 2)
Me.TextBox213.Name = "TextBox213"
Me.TextBox213.Size = New System.Drawing.Size(55, 20)
Me.TextBox213.TabIndex = 8
Me.TextBox213.Text = ""
'
'Panel391
'
Me.Panel391.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel391.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel391.Controls.Add(Me.Label234)
Me.Panel391.Location = New System.Drawing.Point(492, 51)
Me.Panel391.Name = "Panel391"
Me.Panel391.Size = New System.Drawing.Size(64, 24)
Me.Panel391.TabIndex = 228
'
'Label234
'
Me.Label234.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label234.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label234.Location = New System.Drawing.Point(8, 4)
Me.Label234.Name = "Label234"
Me.Label234.Size = New System.Drawing.Size(48, 16)
Me.Label234.TabIndex = 6
Me.Label234.Text = "6"
Me.Label234.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel392
'
Me.Panel392.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel392.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel392.Controls.Add(Me.TextBox214)
Me.Panel392.Location = New System.Drawing.Point(172, 75)
Me.Panel392.Name = "Panel392"
Me.Panel392.Size = New System.Drawing.Size(64, 24)
Me.Panel392.TabIndex = 224
'
'TextBox214
'
Me.TextBox214.Location = New System.Drawing.Point(3, 2)
Me.TextBox214.Name = "TextBox214"
Me.TextBox214.Size = New System.Drawing.Size(55, 20)
Me.TextBox214.TabIndex = 8
Me.TextBox214.Text = ""
'
'Panel393
'
Me.Panel393.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel393.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel393.Controls.Add(Me.TextBox215)
Me.Panel393.Location = New System.Drawing.Point(236, 75)
Me.Panel393.Name = "Panel393"
Me.Panel393.Size = New System.Drawing.Size(64, 24)
Me.Panel393.TabIndex = 188
'
'TextBox215
'
Me.TextBox215.Location = New System.Drawing.Point(3, 2)
Me.TextBox215.Name = "TextBox215"
Me.TextBox215.Size = New System.Drawing.Size(55, 20)
Me.TextBox215.TabIndex = 8
Me.TextBox215.Text = ""
'
'Panel394
'
Me.Panel394.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel394.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel394.Controls.Add(Me.TextBox216)
Me.Panel394.Location = New System.Drawing.Point(684, 75)
Me.Panel394.Name = "Panel394"
Me.Panel394.Size = New System.Drawing.Size(64, 24)
Me.Panel394.TabIndex = 196
'
'TextBox216
'
Me.TextBox216.Location = New System.Drawing.Point(3, 2)
Me.TextBox216.Name = "TextBox216"
Me.TextBox216.Size = New System.Drawing.Size(55, 20)
Me.TextBox216.TabIndex = 8
Me.TextBox216.Text = ""
'
'Panel395
'
Me.Panel395.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel395.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel395.Controls.Add(Me.TextBox217)
Me.Panel395.Location = New System.Drawing.Point(300, 75)
Me.Panel395.Name = "Panel395"
Me.Panel395.Size = New System.Drawing.Size(64, 24)
Me.Panel395.TabIndex = 187
'
'TextBox217
'
Me.TextBox217.Location = New System.Drawing.Point(3, 2)
Me.TextBox217.Name = "TextBox217"
Me.TextBox217.Size = New System.Drawing.Size(55, 20)
Me.TextBox217.TabIndex = 8
Me.TextBox217.Text = ""
'
'Panel396
'
Me.Panel396.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel396.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel396.Controls.Add(Me.TextBox218)
Me.Panel396.Location = New System.Drawing.Point(364, 75)
Me.Panel396.Name = "Panel396"
Me.Panel396.Size = New System.Drawing.Size(64, 24)
Me.Panel396.TabIndex = 189
'
'TextBox218
'
Me.TextBox218.Location = New System.Drawing.Point(3, 2)
Me.TextBox218.Name = "TextBox218"
Me.TextBox218.Size = New System.Drawing.Size(55, 20)
Me.TextBox218.TabIndex = 8
Me.TextBox218.Text = ""
'
'Panel397
'
Me.Panel397.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel397.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel397.Controls.Add(Me.TextBox219)
Me.Panel397.Location = New System.Drawing.Point(876, 75)
Me.Panel397.Name = "Panel397"
Me.Panel397.Size = New System.Drawing.Size(64, 24)
Me.Panel397.TabIndex = 191
'
'TextBox219
'
Me.TextBox219.Location = New System.Drawing.Point(3, 2)
Me.TextBox219.Name = "TextBox219"
Me.TextBox219.Size = New System.Drawing.Size(55, 20)
Me.TextBox219.TabIndex = 8
Me.TextBox219.Text = ""
'
'Panel398
'
Me.Panel398.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel398.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel398.Controls.Add(Me.TextBox220)
Me.Panel398.Location = New System.Drawing.Point(428, 75)
Me.Panel398.Name = "Panel398"
Me.Panel398.Size = New System.Drawing.Size(64, 24)
Me.Panel398.TabIndex = 197
'
'TextBox220
'
Me.TextBox220.Location = New System.Drawing.Point(3, 2)
Me.TextBox220.Name = "TextBox220"
Me.TextBox220.Size = New System.Drawing.Size(55, 20)
Me.TextBox220.TabIndex = 8
Me.TextBox220.Text = ""
'
'Panel399
'
Me.Panel399.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel399.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel399.Controls.Add(Me.TextBox221)
Me.Panel399.Location = New System.Drawing.Point(236, 99)
Me.Panel399.Name = "Panel399"
Me.Panel399.Size = New System.Drawing.Size(64, 24)
Me.Panel399.TabIndex = 183
'
'TextBox221
'
Me.TextBox221.Location = New System.Drawing.Point(3, 2)
Me.TextBox221.Name = "TextBox221"
Me.TextBox221.ReadOnly = true
Me.TextBox221.Size = New System.Drawing.Size(55, 20)
Me.TextBox221.TabIndex = 8
Me.TextBox221.Text = ""
'
'Panel400
'
Me.Panel400.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel400.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel400.Controls.Add(Me.TextBox222)
Me.Panel400.Location = New System.Drawing.Point(492, 75)
Me.Panel400.Name = "Panel400"
Me.Panel400.Size = New System.Drawing.Size(64, 24)
Me.Panel400.TabIndex = 192
'
'TextBox222
'
Me.TextBox222.Location = New System.Drawing.Point(3, 2)
Me.TextBox222.Name = "TextBox222"
Me.TextBox222.Size = New System.Drawing.Size(55, 20)
Me.TextBox222.TabIndex = 8
Me.TextBox222.Text = ""
'
'Panel401
'
Me.Panel401.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel401.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel401.Controls.Add(Me.TextBox223)
Me.Panel401.Location = New System.Drawing.Point(492, 99)
Me.Panel401.Name = "Panel401"
Me.Panel401.Size = New System.Drawing.Size(64, 24)
Me.Panel401.TabIndex = 182
'
'TextBox223
'
Me.TextBox223.Location = New System.Drawing.Point(3, 2)
Me.TextBox223.Name = "TextBox223"
Me.TextBox223.ReadOnly = true
Me.TextBox223.Size = New System.Drawing.Size(55, 20)
Me.TextBox223.TabIndex = 8
Me.TextBox223.Text = ""
'
'Panel402
'
Me.Panel402.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel402.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel402.Controls.Add(Me.TextBox224)
Me.Panel402.Location = New System.Drawing.Point(556, 75)
Me.Panel402.Name = "Panel402"
Me.Panel402.Size = New System.Drawing.Size(64, 24)
Me.Panel402.TabIndex = 190
'
'TextBox224
'
Me.TextBox224.Location = New System.Drawing.Point(3, 2)
Me.TextBox224.Name = "TextBox224"
Me.TextBox224.Size = New System.Drawing.Size(55, 20)
Me.TextBox224.TabIndex = 8
Me.TextBox224.Text = ""
'
'Panel403
'
Me.Panel403.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel403.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel403.Controls.Add(Me.TextBox225)
Me.Panel403.Location = New System.Drawing.Point(364, 99)
Me.Panel403.Name = "Panel403"
Me.Panel403.Size = New System.Drawing.Size(64, 24)
Me.Panel403.TabIndex = 184
'
'TextBox225
'
Me.TextBox225.Location = New System.Drawing.Point(3, 2)
Me.TextBox225.Name = "TextBox225"
Me.TextBox225.ReadOnly = true
Me.TextBox225.Size = New System.Drawing.Size(55, 20)
Me.TextBox225.TabIndex = 8
Me.TextBox225.Text = ""
'
'Panel404
'
Me.Panel404.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel404.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel404.Controls.Add(Me.TextBox226)
Me.Panel404.Location = New System.Drawing.Point(556, 99)
Me.Panel404.Name = "Panel404"
Me.Panel404.Size = New System.Drawing.Size(64, 24)
Me.Panel404.TabIndex = 177
'
'TextBox226
'
Me.TextBox226.Location = New System.Drawing.Point(3, 2)
Me.TextBox226.Name = "TextBox226"
Me.TextBox226.ReadOnly = true
Me.TextBox226.Size = New System.Drawing.Size(55, 20)
Me.TextBox226.TabIndex = 8
Me.TextBox226.Text = ""
'
'Panel405
'
Me.Panel405.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel405.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel405.Controls.Add(Me.TextBox227)
Me.Panel405.Location = New System.Drawing.Point(428, 99)
Me.Panel405.Name = "Panel405"
Me.Panel405.Size = New System.Drawing.Size(64, 24)
Me.Panel405.TabIndex = 186
'
'TextBox227
'
Me.TextBox227.Location = New System.Drawing.Point(3, 2)
Me.TextBox227.Name = "TextBox227"
Me.TextBox227.ReadOnly = true
Me.TextBox227.Size = New System.Drawing.Size(55, 20)
Me.TextBox227.TabIndex = 8
Me.TextBox227.Text = ""
'
'Panel406
'
Me.Panel406.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel406.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel406.Controls.Add(Me.TextBox228)
Me.Panel406.Location = New System.Drawing.Point(172, 99)
Me.Panel406.Name = "Panel406"
Me.Panel406.Size = New System.Drawing.Size(64, 24)
Me.Panel406.TabIndex = 185
'
'TextBox228
'
Me.TextBox228.Location = New System.Drawing.Point(3, 2)
Me.TextBox228.Name = "TextBox228"
Me.TextBox228.ReadOnly = true
Me.TextBox228.Size = New System.Drawing.Size(55, 20)
Me.TextBox228.TabIndex = 8
Me.TextBox228.Text = ""
'
'Panel407
'
Me.Panel407.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel407.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel407.Controls.Add(Me.TextBox229)
Me.Panel407.Location = New System.Drawing.Point(748, 123)
Me.Panel407.Name = "Panel407"
Me.Panel407.Size = New System.Drawing.Size(64, 24)
Me.Panel407.TabIndex = 212
'
'TextBox229
'
Me.TextBox229.Location = New System.Drawing.Point(3, 2)
Me.TextBox229.Name = "TextBox229"
Me.TextBox229.ReadOnly = true
Me.TextBox229.Size = New System.Drawing.Size(55, 20)
Me.TextBox229.TabIndex = 8
Me.TextBox229.Text = ""
'
'Panel408
'
Me.Panel408.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel408.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel408.Controls.Add(Me.Label235)
Me.Panel408.Location = New System.Drawing.Point(556, 51)
Me.Panel408.Name = "Panel408"
Me.Panel408.Size = New System.Drawing.Size(64, 24)
Me.Panel408.TabIndex = 227
'
'Label235
'
Me.Label235.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label235.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label235.Location = New System.Drawing.Point(8, 4)
Me.Label235.Name = "Label235"
Me.Label235.Size = New System.Drawing.Size(48, 16)
Me.Label235.TabIndex = 6
Me.Label235.Text = "7"
Me.Label235.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel409
'
Me.Panel409.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel409.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel409.Controls.Add(Me.TextBox230)
Me.Panel409.Location = New System.Drawing.Point(300, 99)
Me.Panel409.Name = "Panel409"
Me.Panel409.Size = New System.Drawing.Size(64, 24)
Me.Panel409.TabIndex = 198
'
'TextBox230
'
Me.TextBox230.Location = New System.Drawing.Point(3, 2)
Me.TextBox230.Name = "TextBox230"
Me.TextBox230.ReadOnly = true
Me.TextBox230.Size = New System.Drawing.Size(55, 20)
Me.TextBox230.TabIndex = 8
Me.TextBox230.Text = ""
'
'Panel410
'
Me.Panel410.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel410.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel410.Controls.Add(Me.TextBox231)
Me.Panel410.Location = New System.Drawing.Point(556, 123)
Me.Panel410.Name = "Panel410"
Me.Panel410.Size = New System.Drawing.Size(64, 24)
Me.Panel410.TabIndex = 207
'
'TextBox231
'
Me.TextBox231.Location = New System.Drawing.Point(3, 2)
Me.TextBox231.Name = "TextBox231"
Me.TextBox231.ReadOnly = true
Me.TextBox231.Size = New System.Drawing.Size(55, 20)
Me.TextBox231.TabIndex = 8
Me.TextBox231.Text = ""
'
'Panel411
'
Me.Panel411.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel411.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel411.Controls.Add(Me.TextBox232)
Me.Panel411.Location = New System.Drawing.Point(364, 123)
Me.Panel411.Name = "Panel411"
Me.Panel411.Size = New System.Drawing.Size(64, 24)
Me.Panel411.TabIndex = 205
'
'TextBox232
'
Me.TextBox232.Location = New System.Drawing.Point(3, 2)
Me.TextBox232.Name = "TextBox232"
Me.TextBox232.ReadOnly = true
Me.TextBox232.Size = New System.Drawing.Size(55, 20)
Me.TextBox232.TabIndex = 8
Me.TextBox232.Text = ""
'
'Panel412
'
Me.Panel412.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel412.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel412.Controls.Add(Me.Label236)
Me.Panel412.Location = New System.Drawing.Point(620, 51)
Me.Panel412.Name = "Panel412"
Me.Panel412.Size = New System.Drawing.Size(64, 24)
Me.Panel412.TabIndex = 229
'
'Label236
'
Me.Label236.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label236.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label236.Location = New System.Drawing.Point(8, 4)
Me.Label236.Name = "Label236"
Me.Label236.Size = New System.Drawing.Size(48, 16)
Me.Label236.TabIndex = 6
Me.Label236.Text = "8"
Me.Label236.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel413
'
Me.Panel413.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel413.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel413.Controls.Add(Me.TextBox353)
Me.Panel413.Location = New System.Drawing.Point(428, 123)
Me.Panel413.Name = "Panel413"
Me.Panel413.Size = New System.Drawing.Size(64, 24)
Me.Panel413.TabIndex = 204
'
'TextBox353
'
Me.TextBox353.Location = New System.Drawing.Point(3, 2)
Me.TextBox353.Name = "TextBox353"
Me.TextBox353.ReadOnly = true
Me.TextBox353.Size = New System.Drawing.Size(55, 20)
Me.TextBox353.TabIndex = 8
Me.TextBox353.Text = ""
'
'Panel498
'
Me.Panel498.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel498.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel498.Controls.Add(Me.TextBox354)
Me.Panel498.Location = New System.Drawing.Point(492, 123)
Me.Panel498.Name = "Panel498"
Me.Panel498.Size = New System.Drawing.Size(64, 24)
Me.Panel498.TabIndex = 211
'
'TextBox354
'
Me.TextBox354.Location = New System.Drawing.Point(3, 2)
Me.TextBox354.Name = "TextBox354"
Me.TextBox354.ReadOnly = true
Me.TextBox354.Size = New System.Drawing.Size(55, 20)
Me.TextBox354.TabIndex = 8
Me.TextBox354.Text = ""
'
'Panel499
'
Me.Panel499.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel499.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel499.Controls.Add(Me.Label237)
Me.Panel499.Location = New System.Drawing.Point(812, 51)
Me.Panel499.Name = "Panel499"
Me.Panel499.Size = New System.Drawing.Size(64, 24)
Me.Panel499.TabIndex = 226
'
'Label237
'
Me.Label237.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label237.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label237.Location = New System.Drawing.Point(8, 4)
Me.Label237.Name = "Label237"
Me.Label237.Size = New System.Drawing.Size(48, 16)
Me.Label237.TabIndex = 6
Me.Label237.Text = "11"
Me.Label237.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel500
'
Me.Panel500.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel500.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel500.Controls.Add(Me.TextBox355)
Me.Panel500.Location = New System.Drawing.Point(236, 123)
Me.Panel500.Name = "Panel500"
Me.Panel500.Size = New System.Drawing.Size(64, 24)
Me.Panel500.TabIndex = 214
'
'TextBox355
'
Me.TextBox355.Location = New System.Drawing.Point(3, 2)
Me.TextBox355.Name = "TextBox355"
Me.TextBox355.ReadOnly = true
Me.TextBox355.Size = New System.Drawing.Size(55, 20)
Me.TextBox355.TabIndex = 8
Me.TextBox355.Text = ""
'
'Panel501
'
Me.Panel501.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel501.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel501.Controls.Add(Me.TextBox356)
Me.Panel501.Location = New System.Drawing.Point(172, 123)
Me.Panel501.Name = "Panel501"
Me.Panel501.Size = New System.Drawing.Size(64, 24)
Me.Panel501.TabIndex = 213
'
'TextBox356
'
Me.TextBox356.Location = New System.Drawing.Point(3, 2)
Me.TextBox356.Name = "TextBox356"
Me.TextBox356.ReadOnly = true
Me.TextBox356.Size = New System.Drawing.Size(55, 20)
Me.TextBox356.TabIndex = 8
Me.TextBox356.Text = ""
'
'Panel414
'
Me.Panel414.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel414.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel414.Controls.Add(Me.TextBox357)
Me.Panel414.Location = New System.Drawing.Point(300, 123)
Me.Panel414.Name = "Panel414"
Me.Panel414.Size = New System.Drawing.Size(64, 24)
Me.Panel414.TabIndex = 200
'
'TextBox357
'
Me.TextBox357.Location = New System.Drawing.Point(3, 2)
Me.TextBox357.Name = "TextBox357"
Me.TextBox357.ReadOnly = true
Me.TextBox357.Size = New System.Drawing.Size(55, 20)
Me.TextBox357.TabIndex = 8
Me.TextBox357.Text = ""
'
'Panel415
'
Me.Panel415.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel415.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel415.Controls.Add(Me.TextBox358)
Me.Panel415.Location = New System.Drawing.Point(876, 99)
Me.Panel415.Name = "Panel415"
Me.Panel415.Size = New System.Drawing.Size(64, 24)
Me.Panel415.TabIndex = 178
'
'TextBox358
'
Me.TextBox358.Location = New System.Drawing.Point(3, 2)
Me.TextBox358.Name = "TextBox358"
Me.TextBox358.ReadOnly = true
Me.TextBox358.Size = New System.Drawing.Size(55, 20)
Me.TextBox358.TabIndex = 8
Me.TextBox358.Text = ""
'
'Panel416
'
Me.Panel416.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel416.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel416.Controls.Add(Me.TextBox359)
Me.Panel416.Location = New System.Drawing.Point(172, 147)
Me.Panel416.Name = "Panel416"
Me.Panel416.Size = New System.Drawing.Size(89, 24)
Me.Panel416.TabIndex = 199
'
'TextBox359
'
Me.TextBox359.Location = New System.Drawing.Point(3, 2)
Me.TextBox359.Name = "TextBox359"
Me.TextBox359.ReadOnly = true
Me.TextBox359.Size = New System.Drawing.Size(83, 20)
Me.TextBox359.TabIndex = 8
Me.TextBox359.Text = ""
'
'Panel417
'
Me.Panel417.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel417.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel417.Controls.Add(Me.Label238)
Me.Panel417.Location = New System.Drawing.Point(876, 51)
Me.Panel417.Name = "Panel417"
Me.Panel417.Size = New System.Drawing.Size(64, 24)
Me.Panel417.TabIndex = 225
'
'Label238
'
Me.Label238.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label238.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label238.Location = New System.Drawing.Point(8, 4)
Me.Label238.Name = "Label238"
Me.Label238.Size = New System.Drawing.Size(48, 16)
Me.Label238.TabIndex = 6
Me.Label238.Text = "12"
Me.Label238.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel418
'
Me.Panel418.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel418.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel418.Controls.Add(Me.Label239)
Me.Panel418.Location = New System.Drawing.Point(172, 51)
Me.Panel418.Name = "Panel418"
Me.Panel418.Size = New System.Drawing.Size(64, 24)
Me.Panel418.TabIndex = 218
'
'Label239
'
Me.Label239.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label239.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label239.Location = New System.Drawing.Point(8, 4)
Me.Label239.Name = "Label239"
Me.Label239.Size = New System.Drawing.Size(48, 16)
Me.Label239.TabIndex = 6
Me.Label239.Text = "1"
Me.Label239.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel419
'
Me.Panel419.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel419.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel419.Controls.Add(Me.Label240)
Me.Panel419.Location = New System.Drawing.Point(684, 51)
Me.Panel419.Name = "Panel419"
Me.Panel419.Size = New System.Drawing.Size(64, 24)
Me.Panel419.TabIndex = 231
'
'Label240
'
Me.Label240.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label240.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label240.Location = New System.Drawing.Point(8, 4)
Me.Label240.Name = "Label240"
Me.Label240.Size = New System.Drawing.Size(48, 16)
Me.Label240.TabIndex = 6
Me.Label240.Text = "9"
Me.Label240.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel420
'
Me.Panel420.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel420.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel420.Controls.Add(Me.TextBox360)
Me.Panel420.Location = New System.Drawing.Point(172, 171)
Me.Panel420.Name = "Panel420"
Me.Panel420.Size = New System.Drawing.Size(89, 24)
Me.Panel420.TabIndex = 201
'
'TextBox360
'
Me.TextBox360.Location = New System.Drawing.Point(3, 2)
Me.TextBox360.Name = "TextBox360"
Me.TextBox360.ReadOnly = true
Me.TextBox360.Size = New System.Drawing.Size(83, 20)
Me.TextBox360.TabIndex = 8
Me.TextBox360.Text = ""
'
'Panel421
'
Me.Panel421.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel421.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel421.Controls.Add(Me.TextBox361)
Me.Panel421.Location = New System.Drawing.Point(684, 123)
Me.Panel421.Name = "Panel421"
Me.Panel421.Size = New System.Drawing.Size(64, 24)
Me.Panel421.TabIndex = 206
'
'TextBox361
'
Me.TextBox361.Location = New System.Drawing.Point(3, 2)
Me.TextBox361.Name = "TextBox361"
Me.TextBox361.ReadOnly = true
Me.TextBox361.Size = New System.Drawing.Size(55, 20)
Me.TextBox361.TabIndex = 8
Me.TextBox361.Text = ""
'
'Panel422
'
Me.Panel422.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel422.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel422.Controls.Add(Me.Label241)
Me.Panel422.Location = New System.Drawing.Point(260, 147)
Me.Panel422.Name = "Panel422"
Me.Panel422.Size = New System.Drawing.Size(177, 48)
Me.Panel422.TabIndex = 203
'
'Label241
'
Me.Label241.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label241.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label241.Location = New System.Drawing.Point(8, 16)
Me.Label241.Name = "Label241"
Me.Label241.Size = New System.Drawing.Size(160, 16)
Me.Label241.TabIndex = 6
Me.Label241.Text = "Hétérogénité d'alimentation :"
Me.Label241.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel423
'
Me.Panel423.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel423.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel423.Controls.Add(Me.Label242)
Me.Panel423.Controls.Add(Me.Label243)
Me.Panel423.Controls.Add(Me.TextBox362)
Me.Panel423.Controls.Add(Me.TextBox363)
Me.Panel423.Location = New System.Drawing.Point(28, 27)
Me.Panel423.Name = "Panel423"
Me.Panel423.Size = New System.Drawing.Size(912, 24)
Me.Panel423.TabIndex = 220
'
'Label242
'
Me.Label242.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label242.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label242.Location = New System.Drawing.Point(8, 4)
Me.Label242.Name = "Label242"
Me.Label242.Size = New System.Drawing.Size(128, 16)
Me.Label242.TabIndex = 6
Me.Label242.Text = "Pression Mano Pulvé :"
Me.Label242.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label243
'
Me.Label243.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label243.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label243.Location = New System.Drawing.Point(632, 4)
Me.Label243.Name = "Label243"
Me.Label243.Size = New System.Drawing.Size(136, 16)
Me.Label243.TabIndex = 6
Me.Label243.Text = "Moyenne des pressions :"
Me.Label243.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox362
'
Me.TextBox362.Location = New System.Drawing.Point(144, 2)
Me.TextBox362.Name = "TextBox362"
Me.TextBox362.ReadOnly = true
Me.TextBox362.Size = New System.Drawing.Size(83, 20)
Me.TextBox362.TabIndex = 8
Me.TextBox362.Text = "5"
'
'TextBox363
'
Me.TextBox363.Location = New System.Drawing.Point(776, 2)
Me.TextBox363.Name = "TextBox363"
Me.TextBox363.ReadOnly = true
Me.TextBox363.Size = New System.Drawing.Size(83, 20)
Me.TextBox363.TabIndex = 8
Me.TextBox363.Text = ""
'
'Panel424
'
Me.Panel424.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel424.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel424.Controls.Add(Me.TextBox364)
Me.Panel424.Location = New System.Drawing.Point(748, 99)
Me.Panel424.Name = "Panel424"
Me.Panel424.Size = New System.Drawing.Size(64, 24)
Me.Panel424.TabIndex = 179
'
'TextBox364
'
Me.TextBox364.Location = New System.Drawing.Point(3, 2)
Me.TextBox364.Name = "TextBox364"
Me.TextBox364.ReadOnly = true
Me.TextBox364.Size = New System.Drawing.Size(55, 20)
Me.TextBox364.TabIndex = 8
Me.TextBox364.Text = ""
'
'Panel425
'
Me.Panel425.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel425.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel425.Controls.Add(Me.Label244)
Me.Panel425.Controls.Add(Me.Label245)
Me.Panel425.Location = New System.Drawing.Point(436, 147)
Me.Panel425.Name = "Panel425"
Me.Panel425.Size = New System.Drawing.Size(504, 48)
Me.Panel425.TabIndex = 202
'
'Label244
'
Me.Label244.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label244.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label244.Location = New System.Drawing.Point(48, 16)
Me.Label244.Name = "Label244"
Me.Label244.Size = New System.Drawing.Size(168, 16)
Me.Label244.TabIndex = 29
Me.Label244.Text = "OK"
Me.Label244.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label245
'
Me.Label245.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label245.ForeColor = System.Drawing.Color.Red
Me.Label245.Location = New System.Drawing.Point(48, 16)
Me.Label245.Name = "Label245"
Me.Label245.Size = New System.Drawing.Size(168, 16)
Me.Label245.TabIndex = 28
Me.Label245.Text = "DEFAUT"
Me.Label245.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel426
'
Me.Panel426.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel426.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel426.Controls.Add(Me.TextBox365)
Me.Panel426.Location = New System.Drawing.Point(620, 123)
Me.Panel426.Name = "Panel426"
Me.Panel426.Size = New System.Drawing.Size(64, 24)
Me.Panel426.TabIndex = 208
'
'TextBox365
'
Me.TextBox365.Location = New System.Drawing.Point(3, 2)
Me.TextBox365.Name = "TextBox365"
Me.TextBox365.ReadOnly = true
Me.TextBox365.Size = New System.Drawing.Size(55, 20)
Me.TextBox365.TabIndex = 8
Me.TextBox365.Text = ""
'
'Panel427
'
Me.Panel427.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel427.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel427.Controls.Add(Me.TextBox366)
Me.Panel427.Location = New System.Drawing.Point(748, 75)
Me.Panel427.Name = "Panel427"
Me.Panel427.Size = New System.Drawing.Size(64, 24)
Me.Panel427.TabIndex = 193
'
'TextBox366
'
Me.TextBox366.Location = New System.Drawing.Point(3, 2)
Me.TextBox366.Name = "TextBox366"
Me.TextBox366.Size = New System.Drawing.Size(55, 20)
Me.TextBox366.TabIndex = 8
Me.TextBox366.Text = ""
'
'Panel428
'
Me.Panel428.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel428.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel428.Controls.Add(Me.Label246)
Me.Panel428.Location = New System.Drawing.Point(748, 51)
Me.Panel428.Name = "Panel428"
Me.Panel428.Size = New System.Drawing.Size(64, 24)
Me.Panel428.TabIndex = 230
'
'Label246
'
Me.Label246.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label246.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label246.Location = New System.Drawing.Point(8, 4)
Me.Label246.Name = "Label246"
Me.Label246.Size = New System.Drawing.Size(48, 16)
Me.Label246.TabIndex = 6
Me.Label246.Text = "10"
Me.Label246.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel429
'
Me.Panel429.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel429.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel429.Controls.Add(Me.Label247)
Me.Panel429.Location = New System.Drawing.Point(236, 51)
Me.Panel429.Name = "Panel429"
Me.Panel429.Size = New System.Drawing.Size(64, 24)
Me.Panel429.TabIndex = 233
'
'Label247
'
Me.Label247.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label247.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label247.Location = New System.Drawing.Point(8, 4)
Me.Label247.Name = "Label247"
Me.Label247.Size = New System.Drawing.Size(48, 16)
Me.Label247.TabIndex = 6
Me.Label247.Text = "2"
Me.Label247.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel430
'
Me.Panel430.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel430.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel430.Controls.Add(Me.Label248)
Me.Panel430.Location = New System.Drawing.Point(28, 75)
Me.Panel430.Name = "Panel430"
Me.Panel430.Size = New System.Drawing.Size(144, 24)
Me.Panel430.TabIndex = 222
'
'Label248
'
Me.Label248.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label248.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label248.Location = New System.Drawing.Point(8, 4)
Me.Label248.Name = "Label248"
Me.Label248.Size = New System.Drawing.Size(128, 16)
Me.Label248.TabIndex = 6
Me.Label248.Text = "P sortie"
Me.Label248.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel431
'
Me.Panel431.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel431.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel431.Controls.Add(Me.TextBox367)
Me.Panel431.Location = New System.Drawing.Point(684, 99)
Me.Panel431.Name = "Panel431"
Me.Panel431.Size = New System.Drawing.Size(64, 24)
Me.Panel431.TabIndex = 180
'
'TextBox367
'
Me.TextBox367.Location = New System.Drawing.Point(3, 2)
Me.TextBox367.Name = "TextBox367"
Me.TextBox367.ReadOnly = true
Me.TextBox367.Size = New System.Drawing.Size(55, 20)
Me.TextBox367.TabIndex = 8
Me.TextBox367.Text = ""
'
'Panel432
'
Me.Panel432.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel432.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel432.Controls.Add(Me.Label249)
Me.Panel432.Location = New System.Drawing.Point(28, 99)
Me.Panel432.Name = "Panel432"
Me.Panel432.Size = New System.Drawing.Size(144, 24)
Me.Panel432.TabIndex = 221
'
'Label249
'
Me.Label249.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label249.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label249.Location = New System.Drawing.Point(8, 4)
Me.Label249.Name = "Label249"
Me.Label249.Size = New System.Drawing.Size(128, 16)
Me.Label249.TabIndex = 6
Me.Label249.Text = "Ecart"
Me.Label249.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel433
'
Me.Panel433.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel433.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel433.Controls.Add(Me.Label250)
Me.Panel433.Location = New System.Drawing.Point(28, 123)
Me.Panel433.Name = "Panel433"
Me.Panel433.Size = New System.Drawing.Size(144, 24)
Me.Panel433.TabIndex = 216
'
'Label250
'
Me.Label250.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label250.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label250.Location = New System.Drawing.Point(8, 4)
Me.Label250.Name = "Label250"
Me.Label250.Size = New System.Drawing.Size(128, 16)
Me.Label250.TabIndex = 6
Me.Label250.Text = "Perte charge"
Me.Label250.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel434
'
Me.Panel434.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel434.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel434.Controls.Add(Me.Label251)
Me.Panel434.Location = New System.Drawing.Point(28, 147)
Me.Panel434.Name = "Panel434"
Me.Panel434.Size = New System.Drawing.Size(144, 24)
Me.Panel434.TabIndex = 215
'
'Label251
'
Me.Label251.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label251.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label251.Location = New System.Drawing.Point(8, 4)
Me.Label251.Name = "Label251"
Me.Label251.Size = New System.Drawing.Size(128, 16)
Me.Label251.TabIndex = 6
Me.Label251.Text = "Perte de charge moy"
Me.Label251.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel435
'
Me.Panel435.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel435.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel435.Controls.Add(Me.TextBox368)
Me.Panel435.Location = New System.Drawing.Point(812, 99)
Me.Panel435.Name = "Panel435"
Me.Panel435.Size = New System.Drawing.Size(64, 24)
Me.Panel435.TabIndex = 176
'
'TextBox368
'
Me.TextBox368.Location = New System.Drawing.Point(3, 2)
Me.TextBox368.Name = "TextBox368"
Me.TextBox368.ReadOnly = true
Me.TextBox368.Size = New System.Drawing.Size(55, 20)
Me.TextBox368.TabIndex = 8
Me.TextBox368.Text = ""
'
'Panel436
'
Me.Panel436.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel436.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel436.Controls.Add(Me.Label252)
Me.Panel436.Location = New System.Drawing.Point(28, 171)
Me.Panel436.Name = "Panel436"
Me.Panel436.Size = New System.Drawing.Size(144, 24)
Me.Panel436.TabIndex = 217
'
'Label252
'
Me.Label252.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label252.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label252.Location = New System.Drawing.Point(8, 4)
Me.Label252.Name = "Label252"
Me.Label252.Size = New System.Drawing.Size(128, 16)
Me.Label252.TabIndex = 6
Me.Label252.Text = "Perte de charge max"
Me.Label252.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel437
'
Me.Panel437.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel437.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel437.Controls.Add(Me.Label253)
Me.Panel437.Location = New System.Drawing.Point(28, 51)
Me.Panel437.Name = "Panel437"
Me.Panel437.Size = New System.Drawing.Size(144, 24)
Me.Panel437.TabIndex = 219
'
'Label253
'
Me.Label253.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label253.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label253.Location = New System.Drawing.Point(8, 4)
Me.Label253.Name = "Label253"
Me.Label253.Size = New System.Drawing.Size(128, 16)
Me.Label253.TabIndex = 6
Me.Label253.Text = "Tronçon"
Me.Label253.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel438
'
Me.Panel438.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel438.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel438.Controls.Add(Me.Label254)
Me.Panel438.Location = New System.Drawing.Point(300, 51)
Me.Panel438.Name = "Panel438"
Me.Panel438.Size = New System.Drawing.Size(64, 24)
Me.Panel438.TabIndex = 232
'
'Label254
'
Me.Label254.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label254.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label254.Location = New System.Drawing.Point(8, 4)
Me.Label254.Name = "Label254"
Me.Label254.Size = New System.Drawing.Size(48, 16)
Me.Label254.TabIndex = 6
Me.Label254.Text = "3"
Me.Label254.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel439
'
Me.Panel439.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel439.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel439.Controls.Add(Me.TextBox369)
Me.Panel439.Location = New System.Drawing.Point(876, 123)
Me.Panel439.Name = "Panel439"
Me.Panel439.Size = New System.Drawing.Size(64, 24)
Me.Panel439.TabIndex = 210
'
'TextBox369
'
Me.TextBox369.Location = New System.Drawing.Point(3, 2)
Me.TextBox369.Name = "TextBox369"
Me.TextBox369.ReadOnly = true
Me.TextBox369.Size = New System.Drawing.Size(55, 20)
Me.TextBox369.TabIndex = 8
Me.TextBox369.Text = ""
'
'Panel440
'
Me.Panel440.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel440.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel440.Controls.Add(Me.TextBox370)
Me.Panel440.Location = New System.Drawing.Point(812, 75)
Me.Panel440.Name = "Panel440"
Me.Panel440.Size = New System.Drawing.Size(64, 24)
Me.Panel440.TabIndex = 194
'
'TextBox370
'
Me.TextBox370.Location = New System.Drawing.Point(3, 2)
Me.TextBox370.Name = "TextBox370"
Me.TextBox370.Size = New System.Drawing.Size(55, 20)
Me.TextBox370.TabIndex = 8
Me.TextBox370.Text = ""
'
'Panel441
'
Me.Panel441.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel441.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel441.Controls.Add(Me.TextBox371)
Me.Panel441.Location = New System.Drawing.Point(812, 123)
Me.Panel441.Name = "Panel441"
Me.Panel441.Size = New System.Drawing.Size(64, 24)
Me.Panel441.TabIndex = 209
'
'TextBox371
'
Me.TextBox371.Location = New System.Drawing.Point(3, 2)
Me.TextBox371.Name = "TextBox371"
Me.TextBox371.ReadOnly = true
Me.TextBox371.Size = New System.Drawing.Size(55, 20)
Me.TextBox371.TabIndex = 8
Me.TextBox371.Text = ""
'
'Panel442
'
Me.Panel442.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel442.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel442.Controls.Add(Me.Label255)
Me.Panel442.Location = New System.Drawing.Point(364, 51)
Me.Panel442.Name = "Panel442"
Me.Panel442.Size = New System.Drawing.Size(64, 24)
Me.Panel442.TabIndex = 234
'
'Label255
'
Me.Label255.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label255.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label255.Location = New System.Drawing.Point(8, 4)
Me.Label255.Name = "Label255"
Me.Label255.Size = New System.Drawing.Size(48, 16)
Me.Label255.TabIndex = 6
Me.Label255.Text = "4"
Me.Label255.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel443
'
Me.Panel443.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel443.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel443.Controls.Add(Me.Label256)
Me.Panel443.Location = New System.Drawing.Point(428, 51)
Me.Panel443.Name = "Panel443"
Me.Panel443.Size = New System.Drawing.Size(64, 24)
Me.Panel443.TabIndex = 223
'
'Label256
'
Me.Label256.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label256.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label256.Location = New System.Drawing.Point(8, 4)
Me.Label256.Name = "Label256"
Me.Label256.Size = New System.Drawing.Size(48, 16)
Me.Label256.TabIndex = 6
Me.Label256.Text = "5"
Me.Label256.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel444
'
Me.Panel444.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel444.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel444.Controls.Add(Me.TextBox372)
Me.Panel444.Location = New System.Drawing.Point(620, 99)
Me.Panel444.Name = "Panel444"
Me.Panel444.Size = New System.Drawing.Size(64, 24)
Me.Panel444.TabIndex = 181
'
'TextBox372
'
Me.TextBox372.Location = New System.Drawing.Point(3, 2)
Me.TextBox372.Name = "TextBox372"
Me.TextBox372.ReadOnly = true
Me.TextBox372.Size = New System.Drawing.Size(55, 20)
Me.TextBox372.TabIndex = 8
Me.TextBox372.Text = ""
'
'Panel445
'
Me.Panel445.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel445.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel445.Controls.Add(Me.TextBox373)
Me.Panel445.Location = New System.Drawing.Point(620, 75)
Me.Panel445.Name = "Panel445"
Me.Panel445.Size = New System.Drawing.Size(64, 24)
Me.Panel445.TabIndex = 195
'
'TextBox373
'
Me.TextBox373.Location = New System.Drawing.Point(3, 2)
Me.TextBox373.Name = "TextBox373"
Me.TextBox373.Size = New System.Drawing.Size(55, 20)
Me.TextBox373.TabIndex = 8
Me.TextBox373.Text = ""
'
'Panel446
'
Me.Panel446.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel446.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel446.Controls.Add(Me.Label257)
Me.Panel446.Location = New System.Drawing.Point(492, 51)
Me.Panel446.Name = "Panel446"
Me.Panel446.Size = New System.Drawing.Size(64, 24)
Me.Panel446.TabIndex = 228
'
'Label257
'
Me.Label257.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label257.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label257.Location = New System.Drawing.Point(8, 4)
Me.Label257.Name = "Label257"
Me.Label257.Size = New System.Drawing.Size(48, 16)
Me.Label257.TabIndex = 6
Me.Label257.Text = "6"
Me.Label257.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel447
'
Me.Panel447.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel447.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel447.Controls.Add(Me.TextBox374)
Me.Panel447.Location = New System.Drawing.Point(172, 75)
Me.Panel447.Name = "Panel447"
Me.Panel447.Size = New System.Drawing.Size(64, 24)
Me.Panel447.TabIndex = 224
'
'TextBox374
'
Me.TextBox374.Location = New System.Drawing.Point(3, 2)
Me.TextBox374.Name = "TextBox374"
Me.TextBox374.Size = New System.Drawing.Size(55, 20)
Me.TextBox374.TabIndex = 8
Me.TextBox374.Text = ""
'
'Panel448
'
Me.Panel448.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel448.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel448.Controls.Add(Me.TextBox375)
Me.Panel448.Location = New System.Drawing.Point(236, 75)
Me.Panel448.Name = "Panel448"
Me.Panel448.Size = New System.Drawing.Size(64, 24)
Me.Panel448.TabIndex = 188
'
'TextBox375
'
Me.TextBox375.Location = New System.Drawing.Point(3, 2)
Me.TextBox375.Name = "TextBox375"
Me.TextBox375.Size = New System.Drawing.Size(55, 20)
Me.TextBox375.TabIndex = 8
Me.TextBox375.Text = ""
'
'Panel449
'
Me.Panel449.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel449.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel449.Controls.Add(Me.TextBox376)
Me.Panel449.Location = New System.Drawing.Point(684, 75)
Me.Panel449.Name = "Panel449"
Me.Panel449.Size = New System.Drawing.Size(64, 24)
Me.Panel449.TabIndex = 196
'
'TextBox376
'
Me.TextBox376.Location = New System.Drawing.Point(3, 2)
Me.TextBox376.Name = "TextBox376"
Me.TextBox376.Size = New System.Drawing.Size(55, 20)
Me.TextBox376.TabIndex = 8
Me.TextBox376.Text = ""
'
'Panel450
'
Me.Panel450.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel450.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel450.Controls.Add(Me.TextBox377)
Me.Panel450.Location = New System.Drawing.Point(300, 75)
Me.Panel450.Name = "Panel450"
Me.Panel450.Size = New System.Drawing.Size(64, 24)
Me.Panel450.TabIndex = 187
'
'TextBox377
'
Me.TextBox377.Location = New System.Drawing.Point(3, 2)
Me.TextBox377.Name = "TextBox377"
Me.TextBox377.Size = New System.Drawing.Size(55, 20)
Me.TextBox377.TabIndex = 8
Me.TextBox377.Text = ""
'
'Panel451
'
Me.Panel451.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel451.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel451.Controls.Add(Me.TextBox378)
Me.Panel451.Location = New System.Drawing.Point(364, 75)
Me.Panel451.Name = "Panel451"
Me.Panel451.Size = New System.Drawing.Size(64, 24)
Me.Panel451.TabIndex = 189
'
'TextBox378
'
Me.TextBox378.Location = New System.Drawing.Point(3, 2)
Me.TextBox378.Name = "TextBox378"
Me.TextBox378.Size = New System.Drawing.Size(55, 20)
Me.TextBox378.TabIndex = 8
Me.TextBox378.Text = ""
'
'Panel452
'
Me.Panel452.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel452.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel452.Controls.Add(Me.TextBox379)
Me.Panel452.Location = New System.Drawing.Point(876, 75)
Me.Panel452.Name = "Panel452"
Me.Panel452.Size = New System.Drawing.Size(64, 24)
Me.Panel452.TabIndex = 191
'
'TextBox379
'
Me.TextBox379.Location = New System.Drawing.Point(3, 2)
Me.TextBox379.Name = "TextBox379"
Me.TextBox379.Size = New System.Drawing.Size(55, 20)
Me.TextBox379.TabIndex = 8
Me.TextBox379.Text = ""
'
'Panel453
'
Me.Panel453.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel453.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel453.Controls.Add(Me.TextBox380)
Me.Panel453.Location = New System.Drawing.Point(428, 75)
Me.Panel453.Name = "Panel453"
Me.Panel453.Size = New System.Drawing.Size(64, 24)
Me.Panel453.TabIndex = 197
'
'TextBox380
'
Me.TextBox380.Location = New System.Drawing.Point(3, 2)
Me.TextBox380.Name = "TextBox380"
Me.TextBox380.Size = New System.Drawing.Size(55, 20)
Me.TextBox380.TabIndex = 8
Me.TextBox380.Text = ""
'
'Panel454
'
Me.Panel454.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel454.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel454.Controls.Add(Me.TextBox381)
Me.Panel454.Location = New System.Drawing.Point(236, 99)
Me.Panel454.Name = "Panel454"
Me.Panel454.Size = New System.Drawing.Size(64, 24)
Me.Panel454.TabIndex = 183
'
'TextBox381
'
Me.TextBox381.Location = New System.Drawing.Point(3, 2)
Me.TextBox381.Name = "TextBox381"
Me.TextBox381.ReadOnly = true
Me.TextBox381.Size = New System.Drawing.Size(55, 20)
Me.TextBox381.TabIndex = 8
Me.TextBox381.Text = ""
'
'Panel455
'
Me.Panel455.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel455.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel455.Controls.Add(Me.TextBox382)
Me.Panel455.Location = New System.Drawing.Point(492, 75)
Me.Panel455.Name = "Panel455"
Me.Panel455.Size = New System.Drawing.Size(64, 24)
Me.Panel455.TabIndex = 192
'
'TextBox382
'
Me.TextBox382.Location = New System.Drawing.Point(3, 2)
Me.TextBox382.Name = "TextBox382"
Me.TextBox382.Size = New System.Drawing.Size(55, 20)
Me.TextBox382.TabIndex = 8
Me.TextBox382.Text = ""
'
'Panel502
'
Me.Panel502.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel502.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel502.Controls.Add(Me.TextBox383)
Me.Panel502.Location = New System.Drawing.Point(492, 99)
Me.Panel502.Name = "Panel502"
Me.Panel502.Size = New System.Drawing.Size(64, 24)
Me.Panel502.TabIndex = 182
'
'TextBox383
'
Me.TextBox383.Location = New System.Drawing.Point(3, 2)
Me.TextBox383.Name = "TextBox383"
Me.TextBox383.ReadOnly = true
Me.TextBox383.Size = New System.Drawing.Size(55, 20)
Me.TextBox383.TabIndex = 8
Me.TextBox383.Text = ""
'
'Panel503
'
Me.Panel503.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel503.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel503.Controls.Add(Me.TextBox384)
Me.Panel503.Location = New System.Drawing.Point(556, 75)
Me.Panel503.Name = "Panel503"
Me.Panel503.Size = New System.Drawing.Size(64, 24)
Me.Panel503.TabIndex = 190
'
'TextBox384
'
Me.TextBox384.Location = New System.Drawing.Point(3, 2)
Me.TextBox384.Name = "TextBox384"
Me.TextBox384.Size = New System.Drawing.Size(55, 20)
Me.TextBox384.TabIndex = 8
Me.TextBox384.Text = ""
'
'Panel504
'
Me.Panel504.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel504.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel504.Controls.Add(Me.TextBox385)
Me.Panel504.Location = New System.Drawing.Point(364, 99)
Me.Panel504.Name = "Panel504"
Me.Panel504.Size = New System.Drawing.Size(64, 24)
Me.Panel504.TabIndex = 184
'
'TextBox385
'
Me.TextBox385.Location = New System.Drawing.Point(3, 2)
Me.TextBox385.Name = "TextBox385"
Me.TextBox385.ReadOnly = true
Me.TextBox385.Size = New System.Drawing.Size(55, 20)
Me.TextBox385.TabIndex = 8
Me.TextBox385.Text = ""
'
'Panel505
'
Me.Panel505.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel505.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel505.Controls.Add(Me.TextBox386)
Me.Panel505.Location = New System.Drawing.Point(556, 99)
Me.Panel505.Name = "Panel505"
Me.Panel505.Size = New System.Drawing.Size(64, 24)
Me.Panel505.TabIndex = 177
'
'TextBox386
'
Me.TextBox386.Location = New System.Drawing.Point(3, 2)
Me.TextBox386.Name = "TextBox386"
Me.TextBox386.ReadOnly = true
Me.TextBox386.Size = New System.Drawing.Size(55, 20)
Me.TextBox386.TabIndex = 8
Me.TextBox386.Text = ""
'
'Panel506
'
Me.Panel506.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel506.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel506.Controls.Add(Me.TextBox387)
Me.Panel506.Location = New System.Drawing.Point(428, 99)
Me.Panel506.Name = "Panel506"
Me.Panel506.Size = New System.Drawing.Size(64, 24)
Me.Panel506.TabIndex = 186
'
'TextBox387
'
Me.TextBox387.Location = New System.Drawing.Point(3, 2)
Me.TextBox387.Name = "TextBox387"
Me.TextBox387.ReadOnly = true
Me.TextBox387.Size = New System.Drawing.Size(55, 20)
Me.TextBox387.TabIndex = 8
Me.TextBox387.Text = ""
'
'Panel507
'
Me.Panel507.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel507.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel507.Controls.Add(Me.TextBox388)
Me.Panel507.Location = New System.Drawing.Point(172, 99)
Me.Panel507.Name = "Panel507"
Me.Panel507.Size = New System.Drawing.Size(64, 24)
Me.Panel507.TabIndex = 185
'
'TextBox388
'
Me.TextBox388.Location = New System.Drawing.Point(3, 2)
Me.TextBox388.Name = "TextBox388"
Me.TextBox388.ReadOnly = true
Me.TextBox388.Size = New System.Drawing.Size(55, 20)
Me.TextBox388.TabIndex = 8
Me.TextBox388.Text = ""
'
'Panel508
'
Me.Panel508.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel508.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel508.Controls.Add(Me.TextBox389)
Me.Panel508.Location = New System.Drawing.Point(748, 123)
Me.Panel508.Name = "Panel508"
Me.Panel508.Size = New System.Drawing.Size(64, 24)
Me.Panel508.TabIndex = 212
'
'TextBox389
'
Me.TextBox389.Location = New System.Drawing.Point(3, 2)
Me.TextBox389.Name = "TextBox389"
Me.TextBox389.ReadOnly = true
Me.TextBox389.Size = New System.Drawing.Size(55, 20)
Me.TextBox389.TabIndex = 8
Me.TextBox389.Text = ""
'
'Panel509
'
Me.Panel509.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel509.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel509.Controls.Add(Me.Label258)
Me.Panel509.Location = New System.Drawing.Point(556, 51)
Me.Panel509.Name = "Panel509"
Me.Panel509.Size = New System.Drawing.Size(64, 24)
Me.Panel509.TabIndex = 227
'
'Label258
'
Me.Label258.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label258.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label258.Location = New System.Drawing.Point(8, 4)
Me.Label258.Name = "Label258"
Me.Label258.Size = New System.Drawing.Size(48, 16)
Me.Label258.TabIndex = 6
Me.Label258.Text = "7"
Me.Label258.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel510
'
Me.Panel510.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel510.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel510.Controls.Add(Me.TextBox390)
Me.Panel510.Location = New System.Drawing.Point(300, 99)
Me.Panel510.Name = "Panel510"
Me.Panel510.Size = New System.Drawing.Size(64, 24)
Me.Panel510.TabIndex = 198
'
'TextBox390
'
Me.TextBox390.Location = New System.Drawing.Point(3, 2)
Me.TextBox390.Name = "TextBox390"
Me.TextBox390.ReadOnly = true
Me.TextBox390.Size = New System.Drawing.Size(55, 20)
Me.TextBox390.TabIndex = 8
Me.TextBox390.Text = ""
'
'Panel511
'
Me.Panel511.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel511.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel511.Controls.Add(Me.TextBox391)
Me.Panel511.Location = New System.Drawing.Point(556, 123)
Me.Panel511.Name = "Panel511"
Me.Panel511.Size = New System.Drawing.Size(64, 24)
Me.Panel511.TabIndex = 207
'
'TextBox391
'
Me.TextBox391.Location = New System.Drawing.Point(3, 2)
Me.TextBox391.Name = "TextBox391"
Me.TextBox391.ReadOnly = true
Me.TextBox391.Size = New System.Drawing.Size(55, 20)
Me.TextBox391.TabIndex = 8
Me.TextBox391.Text = ""
'
'Panel512
'
Me.Panel512.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel512.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel512.Controls.Add(Me.TextBox392)
Me.Panel512.Location = New System.Drawing.Point(364, 123)
Me.Panel512.Name = "Panel512"
Me.Panel512.Size = New System.Drawing.Size(64, 24)
Me.Panel512.TabIndex = 205
'
'TextBox392
'
Me.TextBox392.Location = New System.Drawing.Point(3, 2)
Me.TextBox392.Name = "TextBox392"
Me.TextBox392.ReadOnly = true
Me.TextBox392.Size = New System.Drawing.Size(55, 20)
Me.TextBox392.TabIndex = 8
Me.TextBox392.Text = ""
'
'Panel513
'
Me.Panel513.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel513.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel513.Controls.Add(Me.Label259)
Me.Panel513.Location = New System.Drawing.Point(620, 51)
Me.Panel513.Name = "Panel513"
Me.Panel513.Size = New System.Drawing.Size(64, 24)
Me.Panel513.TabIndex = 229
'
'Label259
'
Me.Label259.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label259.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label259.Location = New System.Drawing.Point(8, 4)
Me.Label259.Name = "Label259"
Me.Label259.Size = New System.Drawing.Size(48, 16)
Me.Label259.TabIndex = 6
Me.Label259.Text = "8"
Me.Label259.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel514
'
Me.Panel514.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel514.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel514.Controls.Add(Me.TextBox393)
Me.Panel514.Location = New System.Drawing.Point(428, 123)
Me.Panel514.Name = "Panel514"
Me.Panel514.Size = New System.Drawing.Size(64, 24)
Me.Panel514.TabIndex = 204
'
'TextBox393
'
Me.TextBox393.Location = New System.Drawing.Point(3, 2)
Me.TextBox393.Name = "TextBox393"
Me.TextBox393.ReadOnly = true
Me.TextBox393.Size = New System.Drawing.Size(55, 20)
Me.TextBox393.TabIndex = 8
Me.TextBox393.Text = ""
'
'Panel515
'
Me.Panel515.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel515.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel515.Controls.Add(Me.TextBox394)
Me.Panel515.Location = New System.Drawing.Point(492, 123)
Me.Panel515.Name = "Panel515"
Me.Panel515.Size = New System.Drawing.Size(64, 24)
Me.Panel515.TabIndex = 211
'
'TextBox394
'
Me.TextBox394.Location = New System.Drawing.Point(3, 2)
Me.TextBox394.Name = "TextBox394"
Me.TextBox394.ReadOnly = true
Me.TextBox394.Size = New System.Drawing.Size(55, 20)
Me.TextBox394.TabIndex = 8
Me.TextBox394.Text = ""
'
'Panel516
'
Me.Panel516.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel516.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel516.Controls.Add(Me.Label260)
Me.Panel516.Location = New System.Drawing.Point(812, 51)
Me.Panel516.Name = "Panel516"
Me.Panel516.Size = New System.Drawing.Size(64, 24)
Me.Panel516.TabIndex = 226
'
'Label260
'
Me.Label260.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label260.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label260.Location = New System.Drawing.Point(8, 4)
Me.Label260.Name = "Label260"
Me.Label260.Size = New System.Drawing.Size(48, 16)
Me.Label260.TabIndex = 6
Me.Label260.Text = "11"
Me.Label260.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel517
'
Me.Panel517.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel517.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel517.Controls.Add(Me.TextBox395)
Me.Panel517.Location = New System.Drawing.Point(236, 123)
Me.Panel517.Name = "Panel517"
Me.Panel517.Size = New System.Drawing.Size(64, 24)
Me.Panel517.TabIndex = 214
'
'TextBox395
'
Me.TextBox395.Location = New System.Drawing.Point(3, 2)
Me.TextBox395.Name = "TextBox395"
Me.TextBox395.ReadOnly = true
Me.TextBox395.Size = New System.Drawing.Size(55, 20)
Me.TextBox395.TabIndex = 8
Me.TextBox395.Text = ""
'
'Panel518
'
Me.Panel518.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel518.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel518.Controls.Add(Me.TextBox396)
Me.Panel518.Location = New System.Drawing.Point(172, 123)
Me.Panel518.Name = "Panel518"
Me.Panel518.Size = New System.Drawing.Size(64, 24)
Me.Panel518.TabIndex = 213
'
'TextBox396
'
Me.TextBox396.Location = New System.Drawing.Point(3, 2)
Me.TextBox396.Name = "TextBox396"
Me.TextBox396.ReadOnly = true
Me.TextBox396.Size = New System.Drawing.Size(55, 20)
Me.TextBox396.TabIndex = 8
Me.TextBox396.Text = ""
'
'Panel456
'
Me.Panel456.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel456.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel456.Controls.Add(Me.TextBox397)
Me.Panel456.Location = New System.Drawing.Point(300, 123)
Me.Panel456.Name = "Panel456"
Me.Panel456.Size = New System.Drawing.Size(64, 24)
Me.Panel456.TabIndex = 200
'
'TextBox397
'
Me.TextBox397.Location = New System.Drawing.Point(3, 2)
Me.TextBox397.Name = "TextBox397"
Me.TextBox397.ReadOnly = true
Me.TextBox397.Size = New System.Drawing.Size(55, 20)
Me.TextBox397.TabIndex = 8
Me.TextBox397.Text = ""
'
'Panel457
'
Me.Panel457.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel457.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel457.Controls.Add(Me.TextBox398)
Me.Panel457.Location = New System.Drawing.Point(876, 99)
Me.Panel457.Name = "Panel457"
Me.Panel457.Size = New System.Drawing.Size(64, 24)
Me.Panel457.TabIndex = 178
'
'TextBox398
'
Me.TextBox398.Location = New System.Drawing.Point(3, 2)
Me.TextBox398.Name = "TextBox398"
Me.TextBox398.ReadOnly = true
Me.TextBox398.Size = New System.Drawing.Size(55, 20)
Me.TextBox398.TabIndex = 8
Me.TextBox398.Text = ""
'
'Panel458
'
Me.Panel458.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel458.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel458.Controls.Add(Me.TextBox399)
Me.Panel458.Location = New System.Drawing.Point(172, 147)
Me.Panel458.Name = "Panel458"
Me.Panel458.Size = New System.Drawing.Size(89, 24)
Me.Panel458.TabIndex = 199
'
'TextBox399
'
Me.TextBox399.Location = New System.Drawing.Point(3, 2)
Me.TextBox399.Name = "TextBox399"
Me.TextBox399.ReadOnly = true
Me.TextBox399.Size = New System.Drawing.Size(83, 20)
Me.TextBox399.TabIndex = 8
Me.TextBox399.Text = ""
'
'Panel459
'
Me.Panel459.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel459.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel459.Controls.Add(Me.Label261)
Me.Panel459.Location = New System.Drawing.Point(876, 51)
Me.Panel459.Name = "Panel459"
Me.Panel459.Size = New System.Drawing.Size(64, 24)
Me.Panel459.TabIndex = 225
'
'Label261
'
Me.Label261.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label261.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label261.Location = New System.Drawing.Point(8, 4)
Me.Label261.Name = "Label261"
Me.Label261.Size = New System.Drawing.Size(48, 16)
Me.Label261.TabIndex = 6
Me.Label261.Text = "12"
Me.Label261.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel460
'
Me.Panel460.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel460.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel460.Controls.Add(Me.Label262)
Me.Panel460.Location = New System.Drawing.Point(172, 51)
Me.Panel460.Name = "Panel460"
Me.Panel460.Size = New System.Drawing.Size(64, 24)
Me.Panel460.TabIndex = 218
'
'Label262
'
Me.Label262.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label262.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label262.Location = New System.Drawing.Point(8, 4)
Me.Label262.Name = "Label262"
Me.Label262.Size = New System.Drawing.Size(48, 16)
Me.Label262.TabIndex = 6
Me.Label262.Text = "1"
Me.Label262.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel461
'
Me.Panel461.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel461.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel461.Controls.Add(Me.Label263)
Me.Panel461.Location = New System.Drawing.Point(684, 51)
Me.Panel461.Name = "Panel461"
Me.Panel461.Size = New System.Drawing.Size(64, 24)
Me.Panel461.TabIndex = 231
'
'Label263
'
Me.Label263.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label263.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label263.Location = New System.Drawing.Point(8, 4)
Me.Label263.Name = "Label263"
Me.Label263.Size = New System.Drawing.Size(48, 16)
Me.Label263.TabIndex = 6
Me.Label263.Text = "9"
Me.Label263.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel462
'
Me.Panel462.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel462.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel462.Controls.Add(Me.TextBox400)
Me.Panel462.Location = New System.Drawing.Point(172, 171)
Me.Panel462.Name = "Panel462"
Me.Panel462.Size = New System.Drawing.Size(89, 24)
Me.Panel462.TabIndex = 201
'
'TextBox400
'
Me.TextBox400.Location = New System.Drawing.Point(3, 2)
Me.TextBox400.Name = "TextBox400"
Me.TextBox400.ReadOnly = true
Me.TextBox400.Size = New System.Drawing.Size(83, 20)
Me.TextBox400.TabIndex = 8
Me.TextBox400.Text = ""
'
'Panel463
'
Me.Panel463.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel463.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel463.Controls.Add(Me.TextBox401)
Me.Panel463.Location = New System.Drawing.Point(684, 123)
Me.Panel463.Name = "Panel463"
Me.Panel463.Size = New System.Drawing.Size(64, 24)
Me.Panel463.TabIndex = 206
'
'TextBox401
'
Me.TextBox401.Location = New System.Drawing.Point(3, 2)
Me.TextBox401.Name = "TextBox401"
Me.TextBox401.ReadOnly = true
Me.TextBox401.Size = New System.Drawing.Size(55, 20)
Me.TextBox401.TabIndex = 8
Me.TextBox401.Text = ""
'
'Panel464
'
Me.Panel464.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel464.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel464.Controls.Add(Me.Label264)
Me.Panel464.Location = New System.Drawing.Point(260, 147)
Me.Panel464.Name = "Panel464"
Me.Panel464.Size = New System.Drawing.Size(177, 48)
Me.Panel464.TabIndex = 203
'
'Label264
'
Me.Label264.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label264.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label264.Location = New System.Drawing.Point(8, 16)
Me.Label264.Name = "Label264"
Me.Label264.Size = New System.Drawing.Size(160, 16)
Me.Label264.TabIndex = 6
Me.Label264.Text = "Hétérogénité d'alimentation :"
Me.Label264.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel465
'
Me.Panel465.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel465.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel465.Controls.Add(Me.Label265)
Me.Panel465.Controls.Add(Me.Label266)
Me.Panel465.Controls.Add(Me.TextBox402)
Me.Panel465.Controls.Add(Me.TextBox403)
Me.Panel465.Location = New System.Drawing.Point(28, 27)
Me.Panel465.Name = "Panel465"
Me.Panel465.Size = New System.Drawing.Size(912, 24)
Me.Panel465.TabIndex = 220
'
'Label265
'
Me.Label265.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label265.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label265.Location = New System.Drawing.Point(8, 4)
Me.Label265.Name = "Label265"
Me.Label265.Size = New System.Drawing.Size(128, 16)
Me.Label265.TabIndex = 6
Me.Label265.Text = "Pression Mano Pulvé :"
Me.Label265.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'Label266
'
Me.Label266.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label266.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label266.Location = New System.Drawing.Point(632, 4)
Me.Label266.Name = "Label266"
Me.Label266.Size = New System.Drawing.Size(136, 16)
Me.Label266.TabIndex = 6
Me.Label266.Text = "Moyenne des pressions :"
Me.Label266.TextAlign = System.Drawing.ContentAlignment.BottomRight
'
'TextBox402
'
Me.TextBox402.Location = New System.Drawing.Point(144, 2)
Me.TextBox402.Name = "TextBox402"
Me.TextBox402.ReadOnly = true
Me.TextBox402.Size = New System.Drawing.Size(83, 20)
Me.TextBox402.TabIndex = 8
Me.TextBox402.Text = "5"
'
'TextBox403
'
Me.TextBox403.Location = New System.Drawing.Point(776, 2)
Me.TextBox403.Name = "TextBox403"
Me.TextBox403.ReadOnly = true
Me.TextBox403.Size = New System.Drawing.Size(83, 20)
Me.TextBox403.TabIndex = 8
Me.TextBox403.Text = ""
'
'Panel466
'
Me.Panel466.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel466.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel466.Controls.Add(Me.TextBox404)
Me.Panel466.Location = New System.Drawing.Point(748, 99)
Me.Panel466.Name = "Panel466"
Me.Panel466.Size = New System.Drawing.Size(64, 24)
Me.Panel466.TabIndex = 179
'
'TextBox404
'
Me.TextBox404.Location = New System.Drawing.Point(3, 2)
Me.TextBox404.Name = "TextBox404"
Me.TextBox404.ReadOnly = true
Me.TextBox404.Size = New System.Drawing.Size(55, 20)
Me.TextBox404.TabIndex = 8
Me.TextBox404.Text = ""
'
'Panel467
'
Me.Panel467.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel467.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel467.Controls.Add(Me.Label267)
Me.Panel467.Controls.Add(Me.Label268)
Me.Panel467.Location = New System.Drawing.Point(436, 147)
Me.Panel467.Name = "Panel467"
Me.Panel467.Size = New System.Drawing.Size(504, 48)
Me.Panel467.TabIndex = 202
'
'Label267
'
Me.Label267.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label267.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(192,Byte), CType(0,Byte))
Me.Label267.Location = New System.Drawing.Point(48, 16)
Me.Label267.Name = "Label267"
Me.Label267.Size = New System.Drawing.Size(168, 16)
Me.Label267.TabIndex = 29
Me.Label267.Text = "OK"
Me.Label267.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Label268
'
Me.Label268.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label268.ForeColor = System.Drawing.Color.Red
Me.Label268.Location = New System.Drawing.Point(48, 16)
Me.Label268.Name = "Label268"
Me.Label268.Size = New System.Drawing.Size(168, 16)
Me.Label268.TabIndex = 28
Me.Label268.Text = "DEFAUT"
Me.Label268.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel468
'
Me.Panel468.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel468.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel468.Controls.Add(Me.TextBox405)
Me.Panel468.Location = New System.Drawing.Point(620, 123)
Me.Panel468.Name = "Panel468"
Me.Panel468.Size = New System.Drawing.Size(64, 24)
Me.Panel468.TabIndex = 208
'
'TextBox405
'
Me.TextBox405.Location = New System.Drawing.Point(3, 2)
Me.TextBox405.Name = "TextBox405"
Me.TextBox405.ReadOnly = true
Me.TextBox405.Size = New System.Drawing.Size(55, 20)
Me.TextBox405.TabIndex = 8
Me.TextBox405.Text = ""
'
'Panel469
'
Me.Panel469.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel469.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel469.Controls.Add(Me.TextBox406)
Me.Panel469.Location = New System.Drawing.Point(748, 75)
Me.Panel469.Name = "Panel469"
Me.Panel469.Size = New System.Drawing.Size(64, 24)
Me.Panel469.TabIndex = 193
'
'TextBox406
'
Me.TextBox406.Location = New System.Drawing.Point(3, 2)
Me.TextBox406.Name = "TextBox406"
Me.TextBox406.Size = New System.Drawing.Size(55, 20)
Me.TextBox406.TabIndex = 8
Me.TextBox406.Text = ""
'
'Panel470
'
Me.Panel470.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel470.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel470.Controls.Add(Me.Label269)
Me.Panel470.Location = New System.Drawing.Point(748, 51)
Me.Panel470.Name = "Panel470"
Me.Panel470.Size = New System.Drawing.Size(64, 24)
Me.Panel470.TabIndex = 230
'
'Label269
'
Me.Label269.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label269.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label269.Location = New System.Drawing.Point(8, 4)
Me.Label269.Name = "Label269"
Me.Label269.Size = New System.Drawing.Size(48, 16)
Me.Label269.TabIndex = 6
Me.Label269.Text = "10"
Me.Label269.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel471
'
Me.Panel471.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel471.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel471.Controls.Add(Me.Label270)
Me.Panel471.Location = New System.Drawing.Point(236, 51)
Me.Panel471.Name = "Panel471"
Me.Panel471.Size = New System.Drawing.Size(64, 24)
Me.Panel471.TabIndex = 233
'
'Label270
'
Me.Label270.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label270.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label270.Location = New System.Drawing.Point(8, 4)
Me.Label270.Name = "Label270"
Me.Label270.Size = New System.Drawing.Size(48, 16)
Me.Label270.TabIndex = 6
Me.Label270.Text = "2"
Me.Label270.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel472
'
Me.Panel472.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel472.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel472.Controls.Add(Me.Label271)
Me.Panel472.Location = New System.Drawing.Point(28, 75)
Me.Panel472.Name = "Panel472"
Me.Panel472.Size = New System.Drawing.Size(144, 24)
Me.Panel472.TabIndex = 222
'
'Label271
'
Me.Label271.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label271.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label271.Location = New System.Drawing.Point(8, 4)
Me.Label271.Name = "Label271"
Me.Label271.Size = New System.Drawing.Size(128, 16)
Me.Label271.TabIndex = 6
Me.Label271.Text = "P sortie"
Me.Label271.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel473
'
Me.Panel473.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel473.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel473.Controls.Add(Me.TextBox407)
Me.Panel473.Location = New System.Drawing.Point(684, 99)
Me.Panel473.Name = "Panel473"
Me.Panel473.Size = New System.Drawing.Size(64, 24)
Me.Panel473.TabIndex = 180
'
'TextBox407
'
Me.TextBox407.Location = New System.Drawing.Point(3, 2)
Me.TextBox407.Name = "TextBox407"
Me.TextBox407.ReadOnly = true
Me.TextBox407.Size = New System.Drawing.Size(55, 20)
Me.TextBox407.TabIndex = 8
Me.TextBox407.Text = ""
'
'Panel474
'
Me.Panel474.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel474.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel474.Controls.Add(Me.Label272)
Me.Panel474.Location = New System.Drawing.Point(28, 99)
Me.Panel474.Name = "Panel474"
Me.Panel474.Size = New System.Drawing.Size(144, 24)
Me.Panel474.TabIndex = 221
'
'Label272
'
Me.Label272.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label272.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label272.Location = New System.Drawing.Point(8, 4)
Me.Label272.Name = "Label272"
Me.Label272.Size = New System.Drawing.Size(128, 16)
Me.Label272.TabIndex = 6
Me.Label272.Text = "Ecart"
Me.Label272.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel475
'
Me.Panel475.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel475.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel475.Controls.Add(Me.Label273)
Me.Panel475.Location = New System.Drawing.Point(28, 123)
Me.Panel475.Name = "Panel475"
Me.Panel475.Size = New System.Drawing.Size(144, 24)
Me.Panel475.TabIndex = 216
'
'Label273
'
Me.Label273.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label273.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label273.Location = New System.Drawing.Point(8, 4)
Me.Label273.Name = "Label273"
Me.Label273.Size = New System.Drawing.Size(128, 16)
Me.Label273.TabIndex = 6
Me.Label273.Text = "Perte charge"
Me.Label273.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel476
'
Me.Panel476.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel476.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel476.Controls.Add(Me.Label274)
Me.Panel476.Location = New System.Drawing.Point(28, 147)
Me.Panel476.Name = "Panel476"
Me.Panel476.Size = New System.Drawing.Size(144, 24)
Me.Panel476.TabIndex = 215
'
'Label274
'
Me.Label274.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label274.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label274.Location = New System.Drawing.Point(8, 4)
Me.Label274.Name = "Label274"
Me.Label274.Size = New System.Drawing.Size(128, 16)
Me.Label274.TabIndex = 6
Me.Label274.Text = "Perte de charge moy"
Me.Label274.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel477
'
Me.Panel477.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel477.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel477.Controls.Add(Me.TextBox408)
Me.Panel477.Location = New System.Drawing.Point(812, 99)
Me.Panel477.Name = "Panel477"
Me.Panel477.Size = New System.Drawing.Size(64, 24)
Me.Panel477.TabIndex = 176
'
'TextBox408
'
Me.TextBox408.Location = New System.Drawing.Point(3, 2)
Me.TextBox408.Name = "TextBox408"
Me.TextBox408.ReadOnly = true
Me.TextBox408.Size = New System.Drawing.Size(55, 20)
Me.TextBox408.TabIndex = 8
Me.TextBox408.Text = ""
'
'Panel478
'
Me.Panel478.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel478.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel478.Controls.Add(Me.Label275)
Me.Panel478.Location = New System.Drawing.Point(28, 171)
Me.Panel478.Name = "Panel478"
Me.Panel478.Size = New System.Drawing.Size(144, 24)
Me.Panel478.TabIndex = 217
'
'Label275
'
Me.Label275.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label275.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label275.Location = New System.Drawing.Point(8, 4)
Me.Label275.Name = "Label275"
Me.Label275.Size = New System.Drawing.Size(128, 16)
Me.Label275.TabIndex = 6
Me.Label275.Text = "Perte de charge max"
Me.Label275.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel479
'
Me.Panel479.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel479.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel479.Controls.Add(Me.Label276)
Me.Panel479.Location = New System.Drawing.Point(28, 51)
Me.Panel479.Name = "Panel479"
Me.Panel479.Size = New System.Drawing.Size(144, 24)
Me.Panel479.TabIndex = 219
'
'Label276
'
Me.Label276.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label276.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label276.Location = New System.Drawing.Point(8, 4)
Me.Label276.Name = "Label276"
Me.Label276.Size = New System.Drawing.Size(128, 16)
Me.Label276.TabIndex = 6
Me.Label276.Text = "Tronçon"
Me.Label276.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel480
'
Me.Panel480.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel480.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel480.Controls.Add(Me.Label277)
Me.Panel480.Location = New System.Drawing.Point(300, 51)
Me.Panel480.Name = "Panel480"
Me.Panel480.Size = New System.Drawing.Size(64, 24)
Me.Panel480.TabIndex = 232
'
'Label277
'
Me.Label277.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label277.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label277.Location = New System.Drawing.Point(8, 4)
Me.Label277.Name = "Label277"
Me.Label277.Size = New System.Drawing.Size(48, 16)
Me.Label277.TabIndex = 6
Me.Label277.Text = "3"
Me.Label277.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel481
'
Me.Panel481.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel481.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel481.Controls.Add(Me.TextBox409)
Me.Panel481.Location = New System.Drawing.Point(876, 123)
Me.Panel481.Name = "Panel481"
Me.Panel481.Size = New System.Drawing.Size(64, 24)
Me.Panel481.TabIndex = 210
'
'TextBox409
'
Me.TextBox409.Location = New System.Drawing.Point(3, 2)
Me.TextBox409.Name = "TextBox409"
Me.TextBox409.ReadOnly = true
Me.TextBox409.Size = New System.Drawing.Size(55, 20)
Me.TextBox409.TabIndex = 8
Me.TextBox409.Text = ""
'
'Panel482
'
Me.Panel482.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel482.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel482.Controls.Add(Me.TextBox410)
Me.Panel482.Location = New System.Drawing.Point(812, 75)
Me.Panel482.Name = "Panel482"
Me.Panel482.Size = New System.Drawing.Size(64, 24)
Me.Panel482.TabIndex = 194
'
'TextBox410
'
Me.TextBox410.Location = New System.Drawing.Point(3, 2)
Me.TextBox410.Name = "TextBox410"
Me.TextBox410.Size = New System.Drawing.Size(55, 20)
Me.TextBox410.TabIndex = 8
Me.TextBox410.Text = ""
'
'Panel483
'
Me.Panel483.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel483.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel483.Controls.Add(Me.TextBox411)
Me.Panel483.Location = New System.Drawing.Point(812, 123)
Me.Panel483.Name = "Panel483"
Me.Panel483.Size = New System.Drawing.Size(64, 24)
Me.Panel483.TabIndex = 209
'
'TextBox411
'
Me.TextBox411.Location = New System.Drawing.Point(3, 2)
Me.TextBox411.Name = "TextBox411"
Me.TextBox411.ReadOnly = true
Me.TextBox411.Size = New System.Drawing.Size(55, 20)
Me.TextBox411.TabIndex = 8
Me.TextBox411.Text = ""
'
'Panel484
'
Me.Panel484.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel484.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel484.Controls.Add(Me.Label278)
Me.Panel484.Location = New System.Drawing.Point(364, 51)
Me.Panel484.Name = "Panel484"
Me.Panel484.Size = New System.Drawing.Size(64, 24)
Me.Panel484.TabIndex = 234
'
'Label278
'
Me.Label278.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label278.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label278.Location = New System.Drawing.Point(8, 4)
Me.Label278.Name = "Label278"
Me.Label278.Size = New System.Drawing.Size(48, 16)
Me.Label278.TabIndex = 6
Me.Label278.Text = "4"
Me.Label278.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel485
'
Me.Panel485.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel485.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel485.Controls.Add(Me.Label279)
Me.Panel485.Location = New System.Drawing.Point(428, 51)
Me.Panel485.Name = "Panel485"
Me.Panel485.Size = New System.Drawing.Size(64, 24)
Me.Panel485.TabIndex = 223
'
'Label279
'
Me.Label279.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label279.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label279.Location = New System.Drawing.Point(8, 4)
Me.Label279.Name = "Label279"
Me.Label279.Size = New System.Drawing.Size(48, 16)
Me.Label279.TabIndex = 6
Me.Label279.Text = "5"
Me.Label279.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel486
'
Me.Panel486.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel486.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel486.Controls.Add(Me.TextBox412)
Me.Panel486.Location = New System.Drawing.Point(620, 99)
Me.Panel486.Name = "Panel486"
Me.Panel486.Size = New System.Drawing.Size(64, 24)
Me.Panel486.TabIndex = 181
'
'TextBox412
'
Me.TextBox412.Location = New System.Drawing.Point(3, 2)
Me.TextBox412.Name = "TextBox412"
Me.TextBox412.ReadOnly = true
Me.TextBox412.Size = New System.Drawing.Size(55, 20)
Me.TextBox412.TabIndex = 8
Me.TextBox412.Text = ""
'
'Panel487
'
Me.Panel487.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel487.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel487.Controls.Add(Me.TextBox413)
Me.Panel487.Location = New System.Drawing.Point(620, 75)
Me.Panel487.Name = "Panel487"
Me.Panel487.Size = New System.Drawing.Size(64, 24)
Me.Panel487.TabIndex = 195
'
'TextBox413
'
Me.TextBox413.Location = New System.Drawing.Point(3, 2)
Me.TextBox413.Name = "TextBox413"
Me.TextBox413.Size = New System.Drawing.Size(55, 20)
Me.TextBox413.TabIndex = 8
Me.TextBox413.Text = ""
'
'Panel488
'
Me.Panel488.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel488.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel488.Controls.Add(Me.Label280)
Me.Panel488.Location = New System.Drawing.Point(492, 51)
Me.Panel488.Name = "Panel488"
Me.Panel488.Size = New System.Drawing.Size(64, 24)
Me.Panel488.TabIndex = 228
'
'Label280
'
Me.Label280.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label280.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label280.Location = New System.Drawing.Point(8, 4)
Me.Label280.Name = "Label280"
Me.Label280.Size = New System.Drawing.Size(48, 16)
Me.Label280.TabIndex = 6
Me.Label280.Text = "6"
Me.Label280.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel489
'
Me.Panel489.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel489.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel489.Controls.Add(Me.TextBox414)
Me.Panel489.Location = New System.Drawing.Point(172, 75)
Me.Panel489.Name = "Panel489"
Me.Panel489.Size = New System.Drawing.Size(64, 24)
Me.Panel489.TabIndex = 224
'
'TextBox414
'
Me.TextBox414.Location = New System.Drawing.Point(3, 2)
Me.TextBox414.Name = "TextBox414"
Me.TextBox414.Size = New System.Drawing.Size(55, 20)
Me.TextBox414.TabIndex = 8
Me.TextBox414.Text = ""
'
'Panel490
'
Me.Panel490.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel490.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel490.Controls.Add(Me.TextBox415)
Me.Panel490.Location = New System.Drawing.Point(236, 75)
Me.Panel490.Name = "Panel490"
Me.Panel490.Size = New System.Drawing.Size(64, 24)
Me.Panel490.TabIndex = 188
'
'TextBox415
'
Me.TextBox415.Location = New System.Drawing.Point(3, 2)
Me.TextBox415.Name = "TextBox415"
Me.TextBox415.Size = New System.Drawing.Size(55, 20)
Me.TextBox415.TabIndex = 8
Me.TextBox415.Text = ""
'
'Panel491
'
Me.Panel491.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel491.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel491.Controls.Add(Me.TextBox416)
Me.Panel491.Location = New System.Drawing.Point(684, 75)
Me.Panel491.Name = "Panel491"
Me.Panel491.Size = New System.Drawing.Size(64, 24)
Me.Panel491.TabIndex = 196
'
'TextBox416
'
Me.TextBox416.Location = New System.Drawing.Point(3, 2)
Me.TextBox416.Name = "TextBox416"
Me.TextBox416.Size = New System.Drawing.Size(55, 20)
Me.TextBox416.TabIndex = 8
Me.TextBox416.Text = ""
'
'Panel492
'
Me.Panel492.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel492.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel492.Controls.Add(Me.TextBox417)
Me.Panel492.Location = New System.Drawing.Point(300, 75)
Me.Panel492.Name = "Panel492"
Me.Panel492.Size = New System.Drawing.Size(64, 24)
Me.Panel492.TabIndex = 187
'
'TextBox417
'
Me.TextBox417.Location = New System.Drawing.Point(3, 2)
Me.TextBox417.Name = "TextBox417"
Me.TextBox417.Size = New System.Drawing.Size(55, 20)
Me.TextBox417.TabIndex = 8
Me.TextBox417.Text = ""
'
'Panel493
'
Me.Panel493.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel493.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel493.Controls.Add(Me.TextBox418)
Me.Panel493.Location = New System.Drawing.Point(364, 75)
Me.Panel493.Name = "Panel493"
Me.Panel493.Size = New System.Drawing.Size(64, 24)
Me.Panel493.TabIndex = 189
'
'TextBox418
'
Me.TextBox418.Location = New System.Drawing.Point(3, 2)
Me.TextBox418.Name = "TextBox418"
Me.TextBox418.Size = New System.Drawing.Size(55, 20)
Me.TextBox418.TabIndex = 8
Me.TextBox418.Text = ""
'
'Panel494
'
Me.Panel494.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel494.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel494.Controls.Add(Me.TextBox419)
Me.Panel494.Location = New System.Drawing.Point(876, 75)
Me.Panel494.Name = "Panel494"
Me.Panel494.Size = New System.Drawing.Size(64, 24)
Me.Panel494.TabIndex = 191
'
'TextBox419
'
Me.TextBox419.Location = New System.Drawing.Point(3, 2)
Me.TextBox419.Name = "TextBox419"
Me.TextBox419.Size = New System.Drawing.Size(55, 20)
Me.TextBox419.TabIndex = 8
Me.TextBox419.Text = ""
'
'Panel495
'
Me.Panel495.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel495.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel495.Controls.Add(Me.TextBox420)
Me.Panel495.Location = New System.Drawing.Point(428, 75)
Me.Panel495.Name = "Panel495"
Me.Panel495.Size = New System.Drawing.Size(64, 24)
Me.Panel495.TabIndex = 197
'
'TextBox420
'
Me.TextBox420.Location = New System.Drawing.Point(3, 2)
Me.TextBox420.Name = "TextBox420"
Me.TextBox420.Size = New System.Drawing.Size(55, 20)
Me.TextBox420.TabIndex = 8
Me.TextBox420.Text = ""
'
'Panel496
'
Me.Panel496.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel496.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel496.Controls.Add(Me.TextBox421)
Me.Panel496.Location = New System.Drawing.Point(236, 99)
Me.Panel496.Name = "Panel496"
Me.Panel496.Size = New System.Drawing.Size(64, 24)
Me.Panel496.TabIndex = 183
'
'TextBox421
'
Me.TextBox421.Location = New System.Drawing.Point(3, 2)
Me.TextBox421.Name = "TextBox421"
Me.TextBox421.ReadOnly = true
Me.TextBox421.Size = New System.Drawing.Size(55, 20)
Me.TextBox421.TabIndex = 8
Me.TextBox421.Text = ""
'
'Panel497
'
Me.Panel497.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel497.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel497.Controls.Add(Me.TextBox422)
Me.Panel497.Location = New System.Drawing.Point(492, 75)
Me.Panel497.Name = "Panel497"
Me.Panel497.Size = New System.Drawing.Size(64, 24)
Me.Panel497.TabIndex = 192
'
'TextBox422
'
Me.TextBox422.Location = New System.Drawing.Point(3, 2)
Me.TextBox422.Name = "TextBox422"
Me.TextBox422.Size = New System.Drawing.Size(55, 20)
Me.TextBox422.TabIndex = 8
Me.TextBox422.Text = ""
'
'Panel519
'
Me.Panel519.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel519.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel519.Controls.Add(Me.TextBox423)
Me.Panel519.Location = New System.Drawing.Point(492, 99)
Me.Panel519.Name = "Panel519"
Me.Panel519.Size = New System.Drawing.Size(64, 24)
Me.Panel519.TabIndex = 182
'
'TextBox423
'
Me.TextBox423.Location = New System.Drawing.Point(3, 2)
Me.TextBox423.Name = "TextBox423"
Me.TextBox423.ReadOnly = true
Me.TextBox423.Size = New System.Drawing.Size(55, 20)
Me.TextBox423.TabIndex = 8
Me.TextBox423.Text = ""
'
'Panel520
'
Me.Panel520.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel520.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel520.Controls.Add(Me.TextBox424)
Me.Panel520.Location = New System.Drawing.Point(556, 75)
Me.Panel520.Name = "Panel520"
Me.Panel520.Size = New System.Drawing.Size(64, 24)
Me.Panel520.TabIndex = 190
'
'TextBox424
'
Me.TextBox424.Location = New System.Drawing.Point(3, 2)
Me.TextBox424.Name = "TextBox424"
Me.TextBox424.Size = New System.Drawing.Size(55, 20)
Me.TextBox424.TabIndex = 8
Me.TextBox424.Text = ""
'
'Panel521
'
Me.Panel521.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel521.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel521.Controls.Add(Me.TextBox425)
Me.Panel521.Location = New System.Drawing.Point(364, 99)
Me.Panel521.Name = "Panel521"
Me.Panel521.Size = New System.Drawing.Size(64, 24)
Me.Panel521.TabIndex = 184
'
'TextBox425
'
Me.TextBox425.Location = New System.Drawing.Point(3, 2)
Me.TextBox425.Name = "TextBox425"
Me.TextBox425.ReadOnly = true
Me.TextBox425.Size = New System.Drawing.Size(55, 20)
Me.TextBox425.TabIndex = 8
Me.TextBox425.Text = ""
'
'Panel522
'
Me.Panel522.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel522.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel522.Controls.Add(Me.TextBox426)
Me.Panel522.Location = New System.Drawing.Point(556, 99)
Me.Panel522.Name = "Panel522"
Me.Panel522.Size = New System.Drawing.Size(64, 24)
Me.Panel522.TabIndex = 177
'
'TextBox426
'
Me.TextBox426.Location = New System.Drawing.Point(3, 2)
Me.TextBox426.Name = "TextBox426"
Me.TextBox426.ReadOnly = true
Me.TextBox426.Size = New System.Drawing.Size(55, 20)
Me.TextBox426.TabIndex = 8
Me.TextBox426.Text = ""
'
'Panel523
'
Me.Panel523.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel523.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel523.Controls.Add(Me.TextBox427)
Me.Panel523.Location = New System.Drawing.Point(428, 99)
Me.Panel523.Name = "Panel523"
Me.Panel523.Size = New System.Drawing.Size(64, 24)
Me.Panel523.TabIndex = 186
'
'TextBox427
'
Me.TextBox427.Location = New System.Drawing.Point(3, 2)
Me.TextBox427.Name = "TextBox427"
Me.TextBox427.ReadOnly = true
Me.TextBox427.Size = New System.Drawing.Size(55, 20)
Me.TextBox427.TabIndex = 8
Me.TextBox427.Text = ""
'
'Panel524
'
Me.Panel524.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel524.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel524.Controls.Add(Me.TextBox428)
Me.Panel524.Location = New System.Drawing.Point(172, 99)
Me.Panel524.Name = "Panel524"
Me.Panel524.Size = New System.Drawing.Size(64, 24)
Me.Panel524.TabIndex = 185
'
'TextBox428
'
Me.TextBox428.Location = New System.Drawing.Point(3, 2)
Me.TextBox428.Name = "TextBox428"
Me.TextBox428.ReadOnly = true
Me.TextBox428.Size = New System.Drawing.Size(55, 20)
Me.TextBox428.TabIndex = 8
Me.TextBox428.Text = ""
'
'Panel525
'
Me.Panel525.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel525.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel525.Controls.Add(Me.TextBox429)
Me.Panel525.Location = New System.Drawing.Point(748, 123)
Me.Panel525.Name = "Panel525"
Me.Panel525.Size = New System.Drawing.Size(64, 24)
Me.Panel525.TabIndex = 212
'
'TextBox429
'
Me.TextBox429.Location = New System.Drawing.Point(3, 2)
Me.TextBox429.Name = "TextBox429"
Me.TextBox429.ReadOnly = true
Me.TextBox429.Size = New System.Drawing.Size(55, 20)
Me.TextBox429.TabIndex = 8
Me.TextBox429.Text = ""
'
'Panel526
'
Me.Panel526.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel526.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel526.Controls.Add(Me.Label281)
Me.Panel526.Location = New System.Drawing.Point(556, 51)
Me.Panel526.Name = "Panel526"
Me.Panel526.Size = New System.Drawing.Size(64, 24)
Me.Panel526.TabIndex = 227
'
'Label281
'
Me.Label281.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label281.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label281.Location = New System.Drawing.Point(8, 4)
Me.Label281.Name = "Label281"
Me.Label281.Size = New System.Drawing.Size(48, 16)
Me.Label281.TabIndex = 6
Me.Label281.Text = "7"
Me.Label281.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel527
'
Me.Panel527.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel527.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel527.Controls.Add(Me.TextBox430)
Me.Panel527.Location = New System.Drawing.Point(300, 99)
Me.Panel527.Name = "Panel527"
Me.Panel527.Size = New System.Drawing.Size(64, 24)
Me.Panel527.TabIndex = 198
'
'TextBox430
'
Me.TextBox430.Location = New System.Drawing.Point(3, 2)
Me.TextBox430.Name = "TextBox430"
Me.TextBox430.ReadOnly = true
Me.TextBox430.Size = New System.Drawing.Size(55, 20)
Me.TextBox430.TabIndex = 8
Me.TextBox430.Text = ""
'
'Panel528
'
Me.Panel528.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel528.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel528.Controls.Add(Me.TextBox431)
Me.Panel528.Location = New System.Drawing.Point(556, 123)
Me.Panel528.Name = "Panel528"
Me.Panel528.Size = New System.Drawing.Size(64, 24)
Me.Panel528.TabIndex = 207
'
'TextBox431
'
Me.TextBox431.Location = New System.Drawing.Point(3, 2)
Me.TextBox431.Name = "TextBox431"
Me.TextBox431.ReadOnly = true
Me.TextBox431.Size = New System.Drawing.Size(55, 20)
Me.TextBox431.TabIndex = 8
Me.TextBox431.Text = ""
'
'Panel529
'
Me.Panel529.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel529.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel529.Controls.Add(Me.TextBox432)
Me.Panel529.Location = New System.Drawing.Point(364, 123)
Me.Panel529.Name = "Panel529"
Me.Panel529.Size = New System.Drawing.Size(64, 24)
Me.Panel529.TabIndex = 205
'
'TextBox432
'
Me.TextBox432.Location = New System.Drawing.Point(3, 2)
Me.TextBox432.Name = "TextBox432"
Me.TextBox432.ReadOnly = true
Me.TextBox432.Size = New System.Drawing.Size(55, 20)
Me.TextBox432.TabIndex = 8
Me.TextBox432.Text = ""
'
'Panel530
'
Me.Panel530.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel530.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel530.Controls.Add(Me.Label282)
Me.Panel530.Location = New System.Drawing.Point(620, 51)
Me.Panel530.Name = "Panel530"
Me.Panel530.Size = New System.Drawing.Size(64, 24)
Me.Panel530.TabIndex = 229
'
'Label282
'
Me.Label282.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label282.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label282.Location = New System.Drawing.Point(8, 4)
Me.Label282.Name = "Label282"
Me.Label282.Size = New System.Drawing.Size(48, 16)
Me.Label282.TabIndex = 6
Me.Label282.Text = "8"
Me.Label282.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel531
'
Me.Panel531.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel531.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel531.Controls.Add(Me.TextBox433)
Me.Panel531.Location = New System.Drawing.Point(428, 123)
Me.Panel531.Name = "Panel531"
Me.Panel531.Size = New System.Drawing.Size(64, 24)
Me.Panel531.TabIndex = 204
'
'TextBox433
'
Me.TextBox433.Location = New System.Drawing.Point(3, 2)
Me.TextBox433.Name = "TextBox433"
Me.TextBox433.ReadOnly = true
Me.TextBox433.Size = New System.Drawing.Size(55, 20)
Me.TextBox433.TabIndex = 8
Me.TextBox433.Text = ""
'
'Panel532
'
Me.Panel532.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel532.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel532.Controls.Add(Me.TextBox434)
Me.Panel532.Location = New System.Drawing.Point(492, 123)
Me.Panel532.Name = "Panel532"
Me.Panel532.Size = New System.Drawing.Size(64, 24)
Me.Panel532.TabIndex = 211
'
'TextBox434
'
Me.TextBox434.Location = New System.Drawing.Point(3, 2)
Me.TextBox434.Name = "TextBox434"
Me.TextBox434.ReadOnly = true
Me.TextBox434.Size = New System.Drawing.Size(55, 20)
Me.TextBox434.TabIndex = 8
Me.TextBox434.Text = ""
'
'Panel533
'
Me.Panel533.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel533.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel533.Controls.Add(Me.Label283)
Me.Panel533.Location = New System.Drawing.Point(812, 51)
Me.Panel533.Name = "Panel533"
Me.Panel533.Size = New System.Drawing.Size(64, 24)
Me.Panel533.TabIndex = 226
'
'Label283
'
Me.Label283.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label283.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(125,Byte), CType(192,Byte))
Me.Label283.Location = New System.Drawing.Point(8, 4)
Me.Label283.Name = "Label283"
Me.Label283.Size = New System.Drawing.Size(48, 16)
Me.Label283.TabIndex = 6
Me.Label283.Text = "11"
Me.Label283.TextAlign = System.Drawing.ContentAlignment.BottomCenter
'
'Panel534
'
Me.Panel534.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel534.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel534.Controls.Add(Me.TextBox435)
Me.Panel534.Location = New System.Drawing.Point(236, 123)
Me.Panel534.Name = "Panel534"
Me.Panel534.Size = New System.Drawing.Size(64, 24)
Me.Panel534.TabIndex = 214
'
'TextBox435
'
Me.TextBox435.Location = New System.Drawing.Point(3, 2)
Me.TextBox435.Name = "TextBox435"
Me.TextBox435.ReadOnly = true
Me.TextBox435.Size = New System.Drawing.Size(55, 20)
Me.TextBox435.TabIndex = 8
Me.TextBox435.Text = ""
'
'Panel535
'
Me.Panel535.BackColor = System.Drawing.Color.FromArgb(CType(234,Byte), CType(234,Byte), CType(236,Byte))
Me.Panel535.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel535.Controls.Add(Me.TextBox436)
Me.Panel535.Location = New System.Drawing.Point(172, 123)
Me.Panel535.Name = "Panel535"
Me.Panel535.Size = New System.Drawing.Size(64, 24)
Me.Panel535.TabIndex = 213
'
'TextBox436
'
Me.TextBox436.Location = New System.Drawing.Point(3, 2)
Me.TextBox436.Name = "TextBox436"
Me.TextBox436.ReadOnly = true
Me.TextBox436.Size = New System.Drawing.Size(55, 20)
Me.TextBox436.TabIndex = 8
Me.TextBox436.Text = ""
'
'diag_test
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(1008, 992)
Me.Controls.Add(Me.diagBuses_tab_pressionTroncons)
Me.Controls.Add(Me.Panel14)
Me.Controls.Add(Me.Panel21)
Me.Controls.Add(Me.Panel22)
Me.Controls.Add(Me.Panel23)
Me.Controls.Add(Me.Panel24)
Me.Controls.Add(Me.Panel25)
Me.Controls.Add(Me.Panel26)
Me.Controls.Add(Me.Panel27)
Me.Controls.Add(Me.Panel28)
Me.Controls.Add(Me.Panel29)
Me.Controls.Add(Me.Panel30)
Me.Controls.Add(Me.Panel31)
Me.Controls.Add(Me.Panel32)
Me.Controls.Add(Me.Panel33)
Me.Controls.Add(Me.Panel34)
Me.Controls.Add(Me.Panel35)
Me.Controls.Add(Me.Panel36)
Me.Controls.Add(Me.Panel37)
Me.Controls.Add(Me.Panel38)
Me.Controls.Add(Me.Panel39)
Me.Controls.Add(Me.Panel40)
Me.Controls.Add(Me.Panel41)
Me.Controls.Add(Me.Panel42)
Me.Controls.Add(Me.Panel43)
Me.Controls.Add(Me.Panel44)
Me.Controls.Add(Me.Panel45)
Me.Controls.Add(Me.Panel46)
Me.Controls.Add(Me.Panel47)
Me.Controls.Add(Me.Panel48)
Me.Controls.Add(Me.Panel49)
Me.Controls.Add(Me.Panel52)
Me.Controls.Add(Me.Panel53)
Me.Controls.Add(Me.Panel54)
Me.Controls.Add(Me.Panel55)
Me.Controls.Add(Me.Panel56)
Me.Controls.Add(Me.Panel57)
Me.Controls.Add(Me.Panel58)
Me.Controls.Add(Me.Panel59)
Me.Controls.Add(Me.Panel63)
Me.Controls.Add(Me.Panel64)
Me.Controls.Add(Me.Panel83)
Me.Controls.Add(Me.Panel84)
Me.Controls.Add(Me.Panel1)
Me.Controls.Add(Me.Panel2)
Me.Controls.Add(Me.Panel3)
Me.Controls.Add(Me.Panel4)
Me.Controls.Add(Me.Panel5)
Me.Controls.Add(Me.Panel6)
Me.Controls.Add(Me.Panel7)
Me.Controls.Add(Me.Panel8)
Me.Controls.Add(Me.Panel9)
Me.Controls.Add(Me.Panel10)
Me.Controls.Add(Me.Panel11)
Me.Controls.Add(Me.Panel13)
Me.Controls.Add(Me.Panel16)
Me.Controls.Add(Me.Panel18)
Me.Controls.Add(Me.Panel20)
Me.Controls.Add(Me.Panel50)
Me.Controls.Add(Me.Panel51)
Me.Controls.Add(Me.Panel60)
Me.Controls.Add(Me.Panel61)
Me.Controls.Add(Me.Panel62)
Me.Controls.Add(Me.Panel65)
Me.Controls.Add(Me.Panel66)
Me.Controls.Add(Me.Panel67)
Me.Controls.Add(Me.Panel68)
Me.Controls.Add(Me.Panel70)
Me.Controls.Add(Me.Panel71)
Me.Controls.Add(Me.Panel73)
Me.Controls.Add(Me.Panel75)
Me.Controls.Add(Me.Panel76)
Me.Controls.Add(Me.Panel78)
Me.Controls.Add(Me.Panel79)
Me.Controls.Add(Me.Panel93)
Me.Controls.Add(Me.Panel94)
Me.Controls.Add(Me.Panel95)
Me.Controls.Add(Me.Panel96)
Me.Controls.Add(Me.Panel97)
Me.Controls.Add(Me.Panel98)
Me.Controls.Add(Me.Panel99)
Me.Controls.Add(Me.Panel100)
Me.Controls.Add(Me.Panel101)
Me.Controls.Add(Me.Panel102)
Me.Controls.Add(Me.Panel103)
Me.Controls.Add(Me.Panel104)
Me.Controls.Add(Me.Panel105)
Me.Controls.Add(Me.Panel106)
Me.Controls.Add(Me.Panel107)
Me.Controls.Add(Me.Panel108)
Me.Controls.Add(Me.Panel110)
Me.Controls.Add(Me.Panel111)
Me.Controls.Add(Me.Panel112)
Me.Controls.Add(Me.Panel113)
Me.Controls.Add(Me.Panel114)
Me.Controls.Add(Me.Panel115)
Me.Controls.Add(Me.Panel116)
Me.Controls.Add(Me.Panel117)
Me.Controls.Add(Me.Panel118)
Me.Controls.Add(Me.Panel119)
Me.Controls.Add(Me.Panel120)
Me.Controls.Add(Me.Panel122)
Me.Controls.Add(Me.diagBuses_tab_pressionTroncons_rampe)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
Me.Name = "diag_test"
Me.Text = "diag_test"
Me.Panel14.ResumeLayout(false)
Me.Panel21.ResumeLayout(false)
Me.Panel22.ResumeLayout(false)
Me.Panel23.ResumeLayout(false)
Me.Panel24.ResumeLayout(false)
Me.Panel25.ResumeLayout(false)
Me.Panel26.ResumeLayout(false)
Me.Panel27.ResumeLayout(false)
Me.Panel28.ResumeLayout(false)
Me.Panel29.ResumeLayout(false)
Me.Panel30.ResumeLayout(false)
Me.Panel31.ResumeLayout(false)
Me.Panel32.ResumeLayout(false)
Me.Panel33.ResumeLayout(false)
Me.Panel34.ResumeLayout(false)
Me.Panel35.ResumeLayout(false)
Me.Panel36.ResumeLayout(false)
Me.Panel37.ResumeLayout(false)
Me.Panel38.ResumeLayout(false)
Me.Panel39.ResumeLayout(false)
Me.Panel40.ResumeLayout(false)
Me.Panel41.ResumeLayout(false)
Me.Panel42.ResumeLayout(false)
Me.Panel43.ResumeLayout(false)
Me.Panel44.ResumeLayout(false)
Me.Panel45.ResumeLayout(false)
Me.Panel46.ResumeLayout(false)
Me.Panel47.ResumeLayout(false)
Me.Panel48.ResumeLayout(false)
Me.Panel49.ResumeLayout(false)
Me.Panel52.ResumeLayout(false)
Me.Panel53.ResumeLayout(false)
Me.Panel54.ResumeLayout(false)
Me.Panel55.ResumeLayout(false)
Me.Panel56.ResumeLayout(false)
Me.Panel57.ResumeLayout(false)
Me.Panel58.ResumeLayout(false)
Me.Panel59.ResumeLayout(false)
Me.Panel63.ResumeLayout(false)
Me.Panel64.ResumeLayout(false)
Me.Panel83.ResumeLayout(false)
Me.Panel84.ResumeLayout(false)
Me.Panel1.ResumeLayout(false)
Me.Panel2.ResumeLayout(false)
Me.Panel3.ResumeLayout(false)
Me.Panel4.ResumeLayout(false)
Me.Panel5.ResumeLayout(false)
Me.Panel6.ResumeLayout(false)
Me.Panel7.ResumeLayout(false)
Me.Panel8.ResumeLayout(false)
Me.Panel9.ResumeLayout(false)
Me.Panel10.ResumeLayout(false)
Me.Panel11.ResumeLayout(false)
Me.Panel13.ResumeLayout(false)
Me.Panel16.ResumeLayout(false)
Me.Panel18.ResumeLayout(false)
Me.Panel20.ResumeLayout(false)
Me.Panel50.ResumeLayout(false)
Me.Panel51.ResumeLayout(false)
Me.Panel60.ResumeLayout(false)
Me.Panel61.ResumeLayout(false)
Me.Panel62.ResumeLayout(false)
Me.Panel65.ResumeLayout(false)
Me.Panel66.ResumeLayout(false)
Me.Panel67.ResumeLayout(false)
Me.Panel68.ResumeLayout(false)
Me.Panel70.ResumeLayout(false)
Me.Panel71.ResumeLayout(false)
Me.Panel73.ResumeLayout(false)
Me.Panel75.ResumeLayout(false)
Me.Panel76.ResumeLayout(false)
Me.Panel78.ResumeLayout(false)
Me.Panel79.ResumeLayout(false)
Me.Panel93.ResumeLayout(false)
Me.Panel94.ResumeLayout(false)
Me.Panel95.ResumeLayout(false)
Me.Panel96.ResumeLayout(false)
Me.Panel97.ResumeLayout(false)
Me.Panel98.ResumeLayout(false)
Me.Panel99.ResumeLayout(false)
Me.Panel100.ResumeLayout(false)
Me.Panel101.ResumeLayout(false)
Me.Panel102.ResumeLayout(false)
Me.Panel103.ResumeLayout(false)
Me.Panel104.ResumeLayout(false)
Me.Panel105.ResumeLayout(false)
Me.Panel106.ResumeLayout(false)
Me.Panel107.ResumeLayout(false)
Me.Panel108.ResumeLayout(false)
Me.Panel110.ResumeLayout(false)
Me.Panel111.ResumeLayout(false)
Me.Panel112.ResumeLayout(false)
Me.Panel113.ResumeLayout(false)
Me.Panel114.ResumeLayout(false)
Me.Panel115.ResumeLayout(false)
Me.Panel116.ResumeLayout(false)
Me.Panel117.ResumeLayout(false)
Me.Panel118.ResumeLayout(false)
Me.Panel119.ResumeLayout(false)
Me.Panel120.ResumeLayout(false)
Me.Panel122.ResumeLayout(false)
Me.diagBuses_tab_pressionTroncons.ResumeLayout(false)
Me.TabPage1.ResumeLayout(false)
Me.Panel12.ResumeLayout(false)
Me.Panel15.ResumeLayout(false)
Me.Panel17.ResumeLayout(false)
Me.Panel19.ResumeLayout(false)
Me.Panel69.ResumeLayout(false)
Me.Panel72.ResumeLayout(false)
Me.Panel74.ResumeLayout(false)
Me.Panel77.ResumeLayout(false)
Me.Panel80.ResumeLayout(false)
Me.Panel81.ResumeLayout(false)
Me.Panel82.ResumeLayout(false)
Me.Panel109.ResumeLayout(false)
Me.Panel121.ResumeLayout(false)
Me.Panel123.ResumeLayout(false)
Me.Panel124.ResumeLayout(false)
Me.Panel125.ResumeLayout(false)
Me.Panel127.ResumeLayout(false)
Me.Panel128.ResumeLayout(false)
Me.Panel129.ResumeLayout(false)
Me.Panel130.ResumeLayout(false)
Me.Panel132.ResumeLayout(false)
Me.Panel133.ResumeLayout(false)
Me.Panel166.ResumeLayout(false)
Me.Panel167.ResumeLayout(false)
Me.Panel168.ResumeLayout(false)
Me.Panel169.ResumeLayout(false)
Me.Panel170.ResumeLayout(false)
Me.Panel171.ResumeLayout(false)
Me.Panel172.ResumeLayout(false)
Me.Panel173.ResumeLayout(false)
Me.Panel174.ResumeLayout(false)
Me.Panel175.ResumeLayout(false)
Me.Panel176.ResumeLayout(false)
Me.Panel177.ResumeLayout(false)
Me.Panel178.ResumeLayout(false)
Me.Panel179.ResumeLayout(false)
Me.Panel180.ResumeLayout(false)
Me.Panel181.ResumeLayout(false)
Me.Panel182.ResumeLayout(false)
Me.Panel183.ResumeLayout(false)
Me.Panel184.ResumeLayout(false)
Me.Panel185.ResumeLayout(false)
Me.Panel186.ResumeLayout(false)
Me.Panel187.ResumeLayout(false)
Me.Panel188.ResumeLayout(false)
Me.Panel189.ResumeLayout(false)
Me.Panel190.ResumeLayout(false)
Me.Panel191.ResumeLayout(false)
Me.Panel192.ResumeLayout(false)
Me.Panel193.ResumeLayout(false)
Me.Panel194.ResumeLayout(false)
Me.Panel195.ResumeLayout(false)
Me.Panel196.ResumeLayout(false)
Me.Panel197.ResumeLayout(false)
Me.Panel198.ResumeLayout(false)
Me.Panel199.ResumeLayout(false)
Me.Panel200.ResumeLayout(false)
Me.Panel201.ResumeLayout(false)
Me.Panel202.ResumeLayout(false)
Me.Panel203.ResumeLayout(false)
Me.Panel204.ResumeLayout(false)
Me.Panel205.ResumeLayout(false)
Me.Panel206.ResumeLayout(false)
Me.Panel207.ResumeLayout(false)
Me.Panel208.ResumeLayout(false)
Me.Panel209.ResumeLayout(false)
Me.Panel210.ResumeLayout(false)
Me.Panel211.ResumeLayout(false)
Me.Panel212.ResumeLayout(false)
Me.Panel213.ResumeLayout(false)
Me.Panel214.ResumeLayout(false)
Me.Panel215.ResumeLayout(false)
Me.TabPage2.ResumeLayout(false)
Me.Panel216.ResumeLayout(false)
Me.Panel217.ResumeLayout(false)
Me.Panel218.ResumeLayout(false)
Me.Panel219.ResumeLayout(false)
Me.Panel220.ResumeLayout(false)
Me.Panel221.ResumeLayout(false)
Me.Panel222.ResumeLayout(false)
Me.Panel223.ResumeLayout(false)
Me.Panel224.ResumeLayout(false)
Me.Panel225.ResumeLayout(false)
Me.Panel226.ResumeLayout(false)
Me.Panel227.ResumeLayout(false)
Me.Panel228.ResumeLayout(false)
Me.Panel229.ResumeLayout(false)
Me.Panel230.ResumeLayout(false)
Me.Panel231.ResumeLayout(false)
Me.Panel232.ResumeLayout(false)
Me.Panel233.ResumeLayout(false)
Me.Panel234.ResumeLayout(false)
Me.Panel235.ResumeLayout(false)
Me.Panel236.ResumeLayout(false)
Me.Panel237.ResumeLayout(false)
Me.Panel238.ResumeLayout(false)
Me.Panel239.ResumeLayout(false)
Me.Panel240.ResumeLayout(false)
Me.Panel241.ResumeLayout(false)
Me.Panel242.ResumeLayout(false)
Me.Panel243.ResumeLayout(false)
Me.Panel244.ResumeLayout(false)
Me.Panel245.ResumeLayout(false)
Me.Panel246.ResumeLayout(false)
Me.Panel247.ResumeLayout(false)
Me.Panel248.ResumeLayout(false)
Me.Panel249.ResumeLayout(false)
Me.Panel250.ResumeLayout(false)
Me.Panel251.ResumeLayout(false)
Me.Panel252.ResumeLayout(false)
Me.Panel253.ResumeLayout(false)
Me.Panel254.ResumeLayout(false)
Me.Panel255.ResumeLayout(false)
Me.Panel256.ResumeLayout(false)
Me.Panel257.ResumeLayout(false)
Me.TabPage8.ResumeLayout(false)
Me.Panel258.ResumeLayout(false)
Me.Panel259.ResumeLayout(false)
Me.Panel260.ResumeLayout(false)
Me.Panel261.ResumeLayout(false)
Me.Panel262.ResumeLayout(false)
Me.Panel263.ResumeLayout(false)
Me.Panel264.ResumeLayout(false)
Me.Panel265.ResumeLayout(false)
Me.Panel266.ResumeLayout(false)
Me.Panel267.ResumeLayout(false)
Me.Panel268.ResumeLayout(false)
Me.Panel269.ResumeLayout(false)
Me.Panel270.ResumeLayout(false)
Me.Panel271.ResumeLayout(false)
Me.Panel272.ResumeLayout(false)
Me.Panel273.ResumeLayout(false)
Me.Panel274.ResumeLayout(false)
Me.Panel275.ResumeLayout(false)
Me.Panel276.ResumeLayout(false)
Me.Panel277.ResumeLayout(false)
Me.Panel278.ResumeLayout(false)
Me.Panel279.ResumeLayout(false)
Me.Panel280.ResumeLayout(false)
Me.Panel281.ResumeLayout(false)
Me.Panel282.ResumeLayout(false)
Me.Panel283.ResumeLayout(false)
Me.Panel284.ResumeLayout(false)
Me.Panel285.ResumeLayout(false)
Me.Panel286.ResumeLayout(false)
Me.Panel287.ResumeLayout(false)
Me.Panel288.ResumeLayout(false)
Me.Panel289.ResumeLayout(false)
Me.Panel290.ResumeLayout(false)
Me.Panel291.ResumeLayout(false)
Me.Panel292.ResumeLayout(false)
Me.Panel323.ResumeLayout(false)
Me.Panel324.ResumeLayout(false)
Me.Panel325.ResumeLayout(false)
Me.Panel326.ResumeLayout(false)
Me.Panel327.ResumeLayout(false)
Me.Panel328.ResumeLayout(false)
Me.Panel329.ResumeLayout(false)
Me.TabPage9.ResumeLayout(false)
Me.Panel330.ResumeLayout(false)
Me.Panel331.ResumeLayout(false)
Me.Panel332.ResumeLayout(false)
Me.Panel333.ResumeLayout(false)
Me.Panel334.ResumeLayout(false)
Me.Panel335.ResumeLayout(false)
Me.Panel336.ResumeLayout(false)
Me.Panel337.ResumeLayout(false)
Me.Panel338.ResumeLayout(false)
Me.Panel339.ResumeLayout(false)
Me.Panel340.ResumeLayout(false)
Me.Panel341.ResumeLayout(false)
Me.Panel342.ResumeLayout(false)
Me.Panel343.ResumeLayout(false)
Me.Panel344.ResumeLayout(false)
Me.Panel345.ResumeLayout(false)
Me.Panel346.ResumeLayout(false)
Me.Panel347.ResumeLayout(false)
Me.Panel348.ResumeLayout(false)
Me.Panel349.ResumeLayout(false)
Me.Panel350.ResumeLayout(false)
Me.Panel351.ResumeLayout(false)
Me.Panel352.ResumeLayout(false)
Me.Panel353.ResumeLayout(false)
Me.Panel354.ResumeLayout(false)
Me.Panel355.ResumeLayout(false)
Me.Panel356.ResumeLayout(false)
Me.Panel357.ResumeLayout(false)
Me.Panel358.ResumeLayout(false)
Me.Panel359.ResumeLayout(false)
Me.Panel360.ResumeLayout(false)
Me.Panel361.ResumeLayout(false)
Me.Panel362.ResumeLayout(false)
Me.Panel363.ResumeLayout(false)
Me.Panel364.ResumeLayout(false)
Me.Panel365.ResumeLayout(false)
Me.Panel366.ResumeLayout(false)
Me.Panel367.ResumeLayout(false)
Me.Panel368.ResumeLayout(false)
Me.Panel369.ResumeLayout(false)
Me.Panel370.ResumeLayout(false)
Me.Panel371.ResumeLayout(false)
Me.diagBuses_tab_pressionTroncons_rampe.ResumeLayout(false)
Me.TabPage3.ResumeLayout(false)
Me.TabPage4.ResumeLayout(false)
Me.TabPage5.ResumeLayout(false)
Me.TabPage6.ResumeLayout(false)
Me.Panel85.ResumeLayout(false)
Me.Panel86.ResumeLayout(false)
Me.Panel87.ResumeLayout(false)
Me.Panel88.ResumeLayout(false)
Me.Panel89.ResumeLayout(false)
Me.Panel90.ResumeLayout(false)
Me.Panel91.ResumeLayout(false)
Me.Panel92.ResumeLayout(false)
Me.Panel126.ResumeLayout(false)
Me.Panel131.ResumeLayout(false)
Me.Panel134.ResumeLayout(false)
Me.Panel135.ResumeLayout(false)
Me.Panel136.ResumeLayout(false)
Me.Panel137.ResumeLayout(false)
Me.Panel138.ResumeLayout(false)
Me.Panel139.ResumeLayout(false)
Me.Panel140.ResumeLayout(false)
Me.Panel141.ResumeLayout(false)
Me.Panel142.ResumeLayout(false)
Me.Panel143.ResumeLayout(false)
Me.Panel144.ResumeLayout(false)
Me.Panel145.ResumeLayout(false)
Me.Panel146.ResumeLayout(false)
Me.Panel147.ResumeLayout(false)
Me.Panel148.ResumeLayout(false)
Me.Panel149.ResumeLayout(false)
Me.Panel150.ResumeLayout(false)
Me.Panel151.ResumeLayout(false)
Me.Panel152.ResumeLayout(false)
Me.Panel153.ResumeLayout(false)
Me.Panel154.ResumeLayout(false)
Me.Panel155.ResumeLayout(false)
Me.Panel156.ResumeLayout(false)
Me.Panel157.ResumeLayout(false)
Me.Panel158.ResumeLayout(false)
Me.Panel159.ResumeLayout(false)
Me.Panel160.ResumeLayout(false)
Me.Panel161.ResumeLayout(false)
Me.Panel162.ResumeLayout(false)
Me.Panel163.ResumeLayout(false)
Me.Panel164.ResumeLayout(false)
Me.Panel165.ResumeLayout(false)
Me.Panel293.ResumeLayout(false)
Me.Panel294.ResumeLayout(false)
Me.Panel295.ResumeLayout(false)
Me.Panel296.ResumeLayout(false)
Me.Panel297.ResumeLayout(false)
Me.Panel298.ResumeLayout(false)
Me.Panel299.ResumeLayout(false)
Me.Panel300.ResumeLayout(false)
Me.Panel301.ResumeLayout(false)
Me.Panel302.ResumeLayout(false)
Me.Panel303.ResumeLayout(false)
Me.Panel304.ResumeLayout(false)
Me.Panel305.ResumeLayout(false)
Me.Panel306.ResumeLayout(false)
Me.Panel307.ResumeLayout(false)
Me.Panel308.ResumeLayout(false)
Me.Panel309.ResumeLayout(false)
Me.Panel310.ResumeLayout(false)
Me.Panel311.ResumeLayout(false)
Me.Panel312.ResumeLayout(false)
Me.Panel313.ResumeLayout(false)
Me.Panel314.ResumeLayout(false)
Me.Panel315.ResumeLayout(false)
Me.Panel316.ResumeLayout(false)
Me.Panel317.ResumeLayout(false)
Me.Panel318.ResumeLayout(false)
Me.Panel319.ResumeLayout(false)
Me.Panel320.ResumeLayout(false)
Me.Panel321.ResumeLayout(false)
Me.Panel322.ResumeLayout(false)
Me.Panel372.ResumeLayout(false)
Me.Panel373.ResumeLayout(false)
Me.Panel374.ResumeLayout(false)
Me.Panel375.ResumeLayout(false)
Me.Panel376.ResumeLayout(false)
Me.Panel377.ResumeLayout(false)
Me.Panel378.ResumeLayout(false)
Me.Panel379.ResumeLayout(false)
Me.Panel380.ResumeLayout(false)
Me.Panel381.ResumeLayout(false)
Me.Panel382.ResumeLayout(false)
Me.Panel383.ResumeLayout(false)
Me.Panel384.ResumeLayout(false)
Me.Panel385.ResumeLayout(false)
Me.Panel386.ResumeLayout(false)
Me.Panel387.ResumeLayout(false)
Me.Panel388.ResumeLayout(false)
Me.Panel389.ResumeLayout(false)
Me.Panel390.ResumeLayout(false)
Me.Panel391.ResumeLayout(false)
Me.Panel392.ResumeLayout(false)
Me.Panel393.ResumeLayout(false)
Me.Panel394.ResumeLayout(false)
Me.Panel395.ResumeLayout(false)
Me.Panel396.ResumeLayout(false)
Me.Panel397.ResumeLayout(false)
Me.Panel398.ResumeLayout(false)
Me.Panel399.ResumeLayout(false)
Me.Panel400.ResumeLayout(false)
Me.Panel401.ResumeLayout(false)
Me.Panel402.ResumeLayout(false)
Me.Panel403.ResumeLayout(false)
Me.Panel404.ResumeLayout(false)
Me.Panel405.ResumeLayout(false)
Me.Panel406.ResumeLayout(false)
Me.Panel407.ResumeLayout(false)
Me.Panel408.ResumeLayout(false)
Me.Panel409.ResumeLayout(false)
Me.Panel410.ResumeLayout(false)
Me.Panel411.ResumeLayout(false)
Me.Panel412.ResumeLayout(false)
Me.Panel413.ResumeLayout(false)
Me.Panel498.ResumeLayout(false)
Me.Panel499.ResumeLayout(false)
Me.Panel500.ResumeLayout(false)
Me.Panel501.ResumeLayout(false)
Me.Panel414.ResumeLayout(false)
Me.Panel415.ResumeLayout(false)
Me.Panel416.ResumeLayout(false)
Me.Panel417.ResumeLayout(false)
Me.Panel418.ResumeLayout(false)
Me.Panel419.ResumeLayout(false)
Me.Panel420.ResumeLayout(false)
Me.Panel421.ResumeLayout(false)
Me.Panel422.ResumeLayout(false)
Me.Panel423.ResumeLayout(false)
Me.Panel424.ResumeLayout(false)
Me.Panel425.ResumeLayout(false)
Me.Panel426.ResumeLayout(false)
Me.Panel427.ResumeLayout(false)
Me.Panel428.ResumeLayout(false)
Me.Panel429.ResumeLayout(false)
Me.Panel430.ResumeLayout(false)
Me.Panel431.ResumeLayout(false)
Me.Panel432.ResumeLayout(false)
Me.Panel433.ResumeLayout(false)
Me.Panel434.ResumeLayout(false)
Me.Panel435.ResumeLayout(false)
Me.Panel436.ResumeLayout(false)
Me.Panel437.ResumeLayout(false)
Me.Panel438.ResumeLayout(false)
Me.Panel439.ResumeLayout(false)
Me.Panel440.ResumeLayout(false)
Me.Panel441.ResumeLayout(false)
Me.Panel442.ResumeLayout(false)
Me.Panel443.ResumeLayout(false)
Me.Panel444.ResumeLayout(false)
Me.Panel445.ResumeLayout(false)
Me.Panel446.ResumeLayout(false)
Me.Panel447.ResumeLayout(false)
Me.Panel448.ResumeLayout(false)
Me.Panel449.ResumeLayout(false)
Me.Panel450.ResumeLayout(false)
Me.Panel451.ResumeLayout(false)
Me.Panel452.ResumeLayout(false)
Me.Panel453.ResumeLayout(false)
Me.Panel454.ResumeLayout(false)
Me.Panel455.ResumeLayout(false)
Me.Panel502.ResumeLayout(false)
Me.Panel503.ResumeLayout(false)
Me.Panel504.ResumeLayout(false)
Me.Panel505.ResumeLayout(false)
Me.Panel506.ResumeLayout(false)
Me.Panel507.ResumeLayout(false)
Me.Panel508.ResumeLayout(false)
Me.Panel509.ResumeLayout(false)
Me.Panel510.ResumeLayout(false)
Me.Panel511.ResumeLayout(false)
Me.Panel512.ResumeLayout(false)
Me.Panel513.ResumeLayout(false)
Me.Panel514.ResumeLayout(false)
Me.Panel515.ResumeLayout(false)
Me.Panel516.ResumeLayout(false)
Me.Panel517.ResumeLayout(false)
Me.Panel518.ResumeLayout(false)
Me.Panel456.ResumeLayout(false)
Me.Panel457.ResumeLayout(false)
Me.Panel458.ResumeLayout(false)
Me.Panel459.ResumeLayout(false)
Me.Panel460.ResumeLayout(false)
Me.Panel461.ResumeLayout(false)
Me.Panel462.ResumeLayout(false)
Me.Panel463.ResumeLayout(false)
Me.Panel464.ResumeLayout(false)
Me.Panel465.ResumeLayout(false)
Me.Panel466.ResumeLayout(false)
Me.Panel467.ResumeLayout(false)
Me.Panel468.ResumeLayout(false)
Me.Panel469.ResumeLayout(false)
Me.Panel470.ResumeLayout(false)
Me.Panel471.ResumeLayout(false)
Me.Panel472.ResumeLayout(false)
Me.Panel473.ResumeLayout(false)
Me.Panel474.ResumeLayout(false)
Me.Panel475.ResumeLayout(false)
Me.Panel476.ResumeLayout(false)
Me.Panel477.ResumeLayout(false)
Me.Panel478.ResumeLayout(false)
Me.Panel479.ResumeLayout(false)
Me.Panel480.ResumeLayout(false)
Me.Panel481.ResumeLayout(false)
Me.Panel482.ResumeLayout(false)
Me.Panel483.ResumeLayout(false)
Me.Panel484.ResumeLayout(false)
Me.Panel485.ResumeLayout(false)
Me.Panel486.ResumeLayout(false)
Me.Panel487.ResumeLayout(false)
Me.Panel488.ResumeLayout(false)
Me.Panel489.ResumeLayout(false)
Me.Panel490.ResumeLayout(false)
Me.Panel491.ResumeLayout(false)
Me.Panel492.ResumeLayout(false)
Me.Panel493.ResumeLayout(false)
Me.Panel494.ResumeLayout(false)
Me.Panel495.ResumeLayout(false)
Me.Panel496.ResumeLayout(false)
Me.Panel497.ResumeLayout(false)
Me.Panel519.ResumeLayout(false)
Me.Panel520.ResumeLayout(false)
Me.Panel521.ResumeLayout(false)
Me.Panel522.ResumeLayout(false)
Me.Panel523.ResumeLayout(false)
Me.Panel524.ResumeLayout(false)
Me.Panel525.ResumeLayout(false)
Me.Panel526.ResumeLayout(false)
Me.Panel527.ResumeLayout(false)
Me.Panel528.ResumeLayout(false)
Me.Panel529.ResumeLayout(false)
Me.Panel530.ResumeLayout(false)
Me.Panel531.ResumeLayout(false)
Me.Panel532.ResumeLayout(false)
Me.Panel533.ResumeLayout(false)
Me.Panel534.ResumeLayout(false)
Me.Panel535.ResumeLayout(false)
Me.ResumeLayout(false)

    End Sub

#End Region





End Class